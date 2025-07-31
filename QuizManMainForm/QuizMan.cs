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

        private async void tsbLoadPDFQuestion_Click(object sender, EventArgs e)
        {
            //var file1 = "Scrum-PSM-I_268.pdf";
            var file1 = "gratisexam.com-Scrum.testking.PSM-I.v2021-04-27.by.emil.108q.pdf";
            var file2 = "gratisexam.com-Scrum.realtests.PSM-I.v2020-07-24.by.thea.95q.pdf";
            var file3 = "gratisexam.com-Scrum.practiceexam.PSM-II.v2020-03-25.by.rosie.93q.pdf";
            var fileList = new List<string> { file1, file2, file3 };

            foreach (var file in fileList)
            {
                LoadPDFQuestion(file);
            }
            MessageBox.Show("Questions loaded successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void LoadPDFQuestion(string fileName)
        {
            var pdfPath = Path.Combine(Directory.GetCurrentDirectory() + "\\File\\", fileName);
            var content = PDFHelper.iText.ReadPDF(pdfPath);
            content = content.Replace("https://www.gratisexam.com/", string.Empty);

            // Regex pattern to match blank lines (including lines with only whitespace)
            var pattern = @"^[\s]*$[\r\n]*";
            // Replace blank lines with an empty string
            var newContent = Regex.Replace(content, pattern, string.Empty, RegexOptions.Multiline);

            var qts = Regex.Split(newContent, @"QUESTION \d{1,3}");
            var newQts = new List<Question>();
            foreach (var qt in qts)
            {
                var qtContent = qt.Trim();
                if (!qtContent.Contains("Explanation"))
                    continue;

                var newQt = new Question();
                var regexTopic = ".*?(\\?|\\.)(?=[\\r\\n]A)";
                newQt.Topic = Regex.Match(qtContent, regexTopic).Value.ToString();

                newQt.AnswerList = [];
                var regexCorrect = "(?<=Correct Answer: )[A-Z](?=[\r\n])";
                var correctAnswer = Regex.Match(qtContent, regexCorrect).Value.ToString();

                var regexAnswers = "(?<=[\\r\\n])[A-Z]\\..*?(?=[\\r\\n])";
                var matches = Regex.Matches(qtContent, regexAnswers);
                foreach (var match in matches)
                {
                    var answerText = Regex.Replace(match.ToString().Trim(), "[A-Z]. ", string.Empty);
                    var correct = match.ToString().Contains(correctAnswer + ". ") ? RightOrWrong.Right : RightOrWrong.Wrong;
                    newQt.AnswerList.Add(new Answer(answerText, correct));
                }

                newQt.CreatedBy = "System";
                newQt.CreateTime = DateTime.Now;
                newQts.Add(newQt);
            }

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
    }
}
