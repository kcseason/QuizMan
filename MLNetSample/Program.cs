using Microsoft.ML;
using Microsoft.ML.Data;

namespace MLNetSample
{
    // 训练数据结构
    public class SentimentData
    {
        public string Text { get; set; }
        public bool Label { get; set; }

        public SentimentData() { }

        public SentimentData(string text, bool label)
        {
            Text = text;
            Label = label;
        }
    }

    // 预测结果结构
    public class SentimentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        public float Score { get; set; }
    }

    internal static class Program
    {
        private static void Main()
        {
            var mlContext = new MLContext(seed: 0);

            // 示例数据（扩展到更多条以减少随机极端情况）
            var samples = new[]
            {
                new SentimentData("This is a great product", true),
                new SentimentData("I love this!", true),
                new SentimentData("Works well, I'm happy", true),
                new SentimentData("Absolutely fantastic", true),
                new SentimentData("Not good, I hate it", false),
                new SentimentData("Worst experience ever", false),
                new SentimentData("Terrible, do not buy", false),
                new SentimentData("Very disappointing", false)
            };

            // 使用分层拆分，保证训练/测试集中标签都存在
            var (trainData, testData) = StratifiedSplit(mlContext, samples, testFraction: 0.25, seed: 0);

            // 构建管道：文本特征化 -> 二分类训练器（Sdca）
            var pipeline = mlContext.Transforms.Text.FeaturizeText("Features", nameof(SentimentData.Text))
                .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                    labelColumnName: nameof(SentimentData.Label),
                    featureColumnName: "Features"));

            // 训练模型
            var model = pipeline.Fit(trainData);

            // 在测试集上评估，但先检查测试集标签分布以避免 AUC 未定义
            var predictions = model.Transform(testData);

            var testList = mlContext.Data.CreateEnumerable<SentimentData>(testData, reuseRowObject: false).ToList();
            int posCount = testList.Count(s => s.Label);
            int negCount = testList.Count - posCount;

            if (posCount == 0 || negCount == 0)
            {
                Console.WriteLine($"测试集只包含单一类别 (正例:{posCount}, 负例:{negCount})，跳过 AUC 计算。");
                var metricsNoAuc = mlContext.BinaryClassification.EvaluateNonCalibrated(predictions, labelColumnName: nameof(SentimentData.Label));
                Console.WriteLine($"Accuracy: {metricsNoAuc.Accuracy:P2}");
            }
            else
            {
                var metrics = mlContext.BinaryClassification.Evaluate(predictions, labelColumnName: nameof(SentimentData.Label));
                Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}, AUC: {metrics.AreaUnderRocCurve:P2}");
            }

            // 单条预测示例
            var predictor = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
            var sample = new SentimentData("I really enjoy using this", default);
            var pred = predictor.Predict(sample);
            Console.WriteLine($"Text: {sample.Text}");
            Console.WriteLine($"Prediction: {(pred.Prediction ? "Positive" : "Negative")}, Score: {pred.Score}");

            sample = new SentimentData("I love this so so so much", default);
            pred = predictor.Predict(sample);
            Console.WriteLine($"Text: {sample.Text}");
            Console.WriteLine($"Prediction: {(pred.Prediction ? "Positive" : "Negative")}, Score: {pred.Score}");

            sample = new SentimentData("This is a great product", default);
            pred = predictor.Predict(sample);
            Console.WriteLine($"Text: {sample.Text}");
            Console.WriteLine($"Prediction: {(pred.Prediction ? "Positive" : "Negative")}, Score: {pred.Score}");

            // 保存模型
            var modelPath = "sentiment_model.zip";
            mlContext.Model.Save(model, trainData.Schema, modelPath);
            Console.WriteLine($"Model saved to {modelPath}"); 
        }

        // 简单分层拆分实现：按 Label 分组，再按比例抽取测试集
        private static (IDataView Train, IDataView Test) StratifiedSplit(MLContext mlContext, IEnumerable<SentimentData> allData, double testFraction, int seed = 0)
        {
            var rng = new Random(seed);
            var trainList = new List<SentimentData>();
            var testList = new List<SentimentData>();

            foreach (var group in allData.GroupBy(d => d.Label))
            {
                var list = group.ToList();
                int testCount = Math.Max(1, (int)Math.Round(list.Count * testFraction)); // 至少保留 1 个到测试集中（小数据集时更稳健）
                var shuffled = list.OrderBy(_ => rng.Next()).ToList();
                testList.AddRange(shuffled.Take(testCount));
                trainList.AddRange(shuffled.Skip(testCount));
            }

            var train = mlContext.Data.LoadFromEnumerable(trainList);
            var test = mlContext.Data.LoadFromEnumerable(testList);
            return (train, test);
        }
    }
}