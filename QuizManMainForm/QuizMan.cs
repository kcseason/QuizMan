using QuizManModel;

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
            Question qt = new Question
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
                if (ctl is Panel)
                {
                    var p = ctl as Panel;
                    var answer = new Answer();
                    foreach (var subCtl in p.Controls)
                    {
                        if (subCtl is TextBox)
                        {
                            var t = subCtl as TextBox;
                            if (!string.IsNullOrEmpty(t?.Text))
                            {
                                answer.AnswerString = t?.Text;
                            }
                        }
                        if (subCtl is CheckBox)
                        {
                            var cb = subCtl as CheckBox;
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

            var handler = new QuestionMongoHandler(true, "QuizMan", "QuestionList");
            try
            {
                await handler.InsertQuestionAsync(qt);
                MessageBox.Show("Question saved successfully!", "Info", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving question: {ex.Message}");
            }
        }

    }
}
