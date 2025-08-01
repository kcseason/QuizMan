using QuizManModel;
using System.Text.RegularExpressions;

namespace QuizManMainForm
{
    public partial class QuizMan : Form
    {
        public QuizMan()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var qt = new Question
            {
                Topic = tbTopic.Text,
                Explanation = tbExplanation.Text,
                Remark = tbRemark.Text,
                Difficulty = (Difficulty)cbDifficulty.SelectedIndex,
                Category = (Category)cbCategory.SelectedIndex,
                ShortName = tbShortName.Text,
                FullName = tbFullName.Text
            };

            var answers = new List<Answer>();
            foreach (var ctl in pnlOptions.Controls)
            {
                if (ctl is Panel p)
                {
                    var answer = new Answer();
                    foreach (var subCtl in p.Controls)
                    {
                        if (subCtl is TextBox t)
                        {
                            if (!string.IsNullOrEmpty(t.Text))
                            {
                                answer.AnswerString = t?.Text;
                            }
                        }
                        if (subCtl is CheckBox cb)
                        {
                            answer.RightOrWrong = cb.Checked ? RightOrWrong.Right : RightOrWrong.Wrong;
                        }
                    }

                    if (!string.IsNullOrEmpty(answer.AnswerString))
                    {
                        answers.Add(answer);
                    }
                }
            }

            qt.AnswerList = answers;

            if (!Validation(qt))
                return;

            var handler = new QuestionMongoHandler(true, "QuizMan", "QuestionList");
            try
            {
                await handler.InsertQuestionAsync(qt);
                MessageBox.Show("Question saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewQuestion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving question: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NewQuestion()
        {
            tbTopic.Text = string.Empty;
            tbRemark.Text = string.Empty;
            tbExplanation.Text = string.Empty;

            foreach (var ctl in pnlOptions.Controls)
            {
                if (ctl is Panel p)
                {
                    foreach (var subCtl in p.Controls)
                    {
                        if (subCtl is TextBox t)
                        {
                            t.Text = string.Empty;
                        }
                    }
                }
            }
        }

        private bool Validation(Question qt)
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

        private void TsbLoadPDFQuestion_Click(object sender, EventArgs e)
        {
            var folderPath = Directory.GetCurrentDirectory() + "\\File\\";
            var searchPattern = "*.pdf";
            var dirInfo = new DirectoryInfo(folderPath);
            foreach (var file in dirInfo.GetFiles(searchPattern))
            {
                LoadPDFQuestion(file.FullName);
            }
            MessageBox.Show("Questions loaded successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void LoadPDFQuestion(string pdfPath)
        {
            var content = PDFHelper.iText.ReadPDF(pdfPath);
            // Regex pattern to match blank lines (including lines with only whitespace)
            var pattern = @"^[\s]*$[\r\n]*";
            // Replace blank lines with an empty string
            var newContent = Regex.Replace(content, pattern, string.Empty, RegexOptions.Multiline);
            var newQts = GetQuestionListByPDF(newContent, pdfPath);

            var handler = new QuestionMongoHandler(false, "QuizMan", "QuestionList");
            try
            {
                foreach (var qt in newQts)
                {
                    await handler.InsertQuestionAsync(qt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving question: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Question> GetQuestionListByPDF(string content, string pdfPath)
        {
            if (pdfPath.Contains("gratisexam.com"))
                return GetQuestionsByGratiseExcam(content);
            if (pdfPath.Contains("KaoShiBao"))
                return GetQuestionsByKaoShiBao(content);

            return [];
        }

        private List<Question> GetQuestionsByKaoShiBao(string content)
        {
            var replaceStr = @"\d{0,3} of \d{1,3}[\r\n]|Scrum - PSM-I[\r\n]|µÍ∆Ã£∫—ßœ∞–°µÍ66[\r\n]";
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

        private List<Question> GetQuestionsByGratiseExcam(string content)
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
