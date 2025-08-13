using QuizManModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuizMan
{
    internal static class QuizManHelper
    {
        public static bool Validation(Question qt)
        {
            var errorString = string.Empty;

            if (string.IsNullOrEmpty(qt.Topic))
            {
                errorString += "Topic can not be empty.\n";
            }
            if (qt.AnswerList == null || qt.AnswerList.Count == 0)
            {
                errorString += "Answers can not be empty.\n";
            }
            else
            {
                if (!qt.AnswerList.Any(o => o.RightOrWrong == RightOrWrong.Right))
                {
                    errorString += "Must have at least one correct answer.\n";
                }
            }

            if (!string.IsNullOrEmpty(errorString))
            {
                MessageBox.Show(errorString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return string.IsNullOrEmpty(errorString);
        }

        public static async void LoadPDFQuestion(string pdfPath)
        {
            var content = PDFHelper.iText.ReadPDF(pdfPath);
            // Regex pattern to match blank lines (including lines with only whitespace)
            var pattern = @"^[\s]*$[\r\n]*";
            // Replace blank lines with an empty string
            var newContent = Regex.Replace(content, pattern, string.Empty, RegexOptions.Multiline);
            var newQts = GetQuestionListByPDF(newContent, pdfPath);

            var handler = new EntityMongoDBHandler<Question>(false, "QuizMan", "Question");
            try
            {
                foreach (var qt in newQts)
                {
                    await handler.InsertEntityAsync(qt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving question: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task<List<Question>> GetQuizQuestionsAsync(int number)
        {
            var handler = new EntityMongoDBHandler<Question>(false, "QuizMan", "Question");
            try
            {
                var random = new Random();
                var allQuestions = await handler.GetAllEntitiesAsync();
                return allQuestions.OrderBy(x => random.NextDouble()).Take(number).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving questions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return [];
            }
        }

        private static List<Question> GetQuestionListByPDF(string content, string pdfPath)
        {
            if (pdfPath.Contains("gratisexam.com"))
                return GetQuestionsByGratiseExcam(content);
            if (pdfPath.Contains("KaoShiBao"))
                return GetQuestionsByKaoShiBao(content);

            return [];
        }

        private static List<Question> GetQuestionsByKaoShiBao(string content)
        {
            var replaceStr = @"\d{0,3} of \d{1,3}[\r\n]|Scrum - PSM-I[\r\n]|店铺：学习小店66[\r\n]";
            var newContent = Regex.Replace(content, replaceStr, string.Empty);
            var pattern = @"^[\s]*$[\r\n]*";
            newContent = Regex.Replace(newContent, pattern, string.Empty, RegexOptions.Multiline);
            var qts = Regex.Split(newContent, @"Question #:\d{1,3}");
            var newQts = new List<Question>();
            var i = 0;
            foreach (var qt in qts)
            {
                i++;
                var qtContent = qt.Trim();
                if (!qtContent.Contains("Answer:"))
                    continue;

                var newQt = new Question();
                var regexTopic = @"[\s\S]*?(\?|\.|\)|:)(?=[\r\n]A\.)";
                var topic = Regex.Match(qtContent, regexTopic).Value.ToString();
                newQt.Topic = Regex.Replace(topic, replaceStr, string.Empty);

                newQt.AnswerList = [];
                var regexCorrect = @"(?<=Answer: )[A-Z](?=[\r\n])";
                var correctAnswer = Regex.Match(qtContent, regexCorrect).Value.ToString();

                var regexAnswers = @"(?<=[\r\n])[A-Z]\..*?(?=[\r\n])";
                var matches = Regex.Matches(qtContent, regexAnswers);
                foreach (var match in matches)
                {
                    var answerText = Regex.Replace(match.ToString().Trim(), "[A-Z].  ", string.Empty);
                    var correct = match.ToString().Contains(correctAnswer + ".  ") ? RightOrWrong.Right : RightOrWrong.Wrong;
                    newQt.AnswerList.Add(new Answer(answerText, correct));
                }

                var regexExplanation = @"(?<=Explanation[\r\n])[\s\S]*";
                var exp = Regex.Match(qtContent, regexExplanation).Value.ToString();
                newQt.Explanation = Regex.Replace(exp, replaceStr, string.Empty);

                newQt.ShortName = "PSM-I";
                newQt.FullName = "Prefessianl Scrum Master I";
                newQt.CreatedBy = "System";
                newQt.CreateTime = DateTime.Now;
                newQts.Add(newQt);
            }
            return newQts;
        }

        private static List<Question> GetQuestionsByGratiseExcam(string content)
        {
            content = content.Replace("https://www.gratisexam.com/", string.Empty).Replace("885CB989129A5F974833949052CFB2F2", string.Empty);
            var qts = Regex.Split(content, @"QUESTION \d{1,3}");
            var newQts = new List<Question>();

            foreach (var qt in qts)
            {
                var qtContent = qt.Trim();
                if (!qtContent.Contains("Explanation"))
                    continue;

                var newQt = new Question();
                var regexTopic = @"[\s\S]*?(\?|\.|:)(?=[\s\S]*A. )";
                newQt.Topic = Regex.Match(qtContent, regexTopic).Value.ToString();

                newQt.AnswerList = [];
                var regexCorrect = @"(?<=Correct Answer: )[A-Z](?=[\r\n])";
                var correctAnswer = Regex.Match(qtContent, regexCorrect).Value.ToString();

                var regexAnswers = @"(?<=[\r\n])[A-Z]\..*?(?=[\r\n])";
                var matches = Regex.Matches(qtContent, regexAnswers);
                foreach (var match in matches)
                {
                    var answerText = Regex.Replace(match.ToString().Trim(), "[A-Z]. ", string.Empty);
                    var correct = match.ToString().Contains(correctAnswer + ". ") ? RightOrWrong.Right : RightOrWrong.Wrong;
                    newQt.AnswerList.Add(new Answer(answerText, correct));
                }
                newQt.ShortName = "PSM-I";
                newQt.FullName = "Prefessianl Scrum Master I";
                newQt.CreatedBy = "System";
                newQt.CreateTime = DateTime.Now;
                newQts.Add(newQt);
            }
            return newQts;
        }
    }
}
