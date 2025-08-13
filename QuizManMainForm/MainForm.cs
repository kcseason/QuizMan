using CommonCore.MongoDB;
using QuizMan;
using QuizManModel;

namespace QuizManMainForm
{
    public partial class MainForm : Form
    {
        public MainForm()
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

            if (!QuizManHelper.Validation(qt))
                return;

            var handler = new EntityMongoDBHandler<Question>(true, "QuizMan", "Question");
            try
            {
                await handler.InsertEntityAsync(qt);
                MessageBox.Show("Question saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewQuestion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving question: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbLoadPDFQuestion_Click(object sender, EventArgs e)
        {
            var folderPath = Directory.GetCurrentDirectory() + "\\File\\";
            var searchPattern = "*.pdf";
            var dirInfo = new DirectoryInfo(folderPath);
            foreach (var file in dirInfo.GetFiles(searchPattern))
            {
                QuizManHelper.LoadPDFQuestion(file.FullName);
            }
            MessageBox.Show("Questions loaded successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void TsbStart_Click(object sender, EventArgs e)
        {
            var setForm = new SettingForm();
            if (setForm.ShowDialog() == DialogResult.OK)
            {
                var questionNumber = setForm.QuestionNumber;
                var candidateName = setForm.CandidateName;
                var quiz = new Quiz
                {
                    CandidateName = candidateName,
                    StartTime = DateTime.Now,
                    SetTime = questionNumber,
                    QuestionNumber = questionNumber,
                    CorrectNumber = 0,
                    InCorrectNumber = 0
                };
                var quizHandler = new EntityMongoDBHandler<BasicModel > (false, "QuizMan", "Quiz");
                try
                {
                    await quizHandler.InsertEntityAsync(quiz);
                    var myAnswerList = new List<MyAnswer>();
                    var quizQuestions = await QuizManHelper.GetQuizQuestionsAsync(questionNumber.Value);
                    foreach (var question in quizQuestions)
                    {
                        var myAnswer = new MyAnswer
                        {
                            QuizId = quiz.Id,
                            QuestionId = question.Id
                        };
                        var myAnswerHandler = new EntityMongoDBHandler<BasicModel>(false, "QuizMan", "MyAnswer");
                        await myAnswerHandler.InsertEntityAsync(myAnswer);
                        myAnswerList.Add(myAnswer);
                    }

                    MessageBox.Show("Finished", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error starting quiz: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
    }
}
