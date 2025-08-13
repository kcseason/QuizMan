using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizManMainForm
{
    public partial class SettingForm : Form
    {
        public int? QuestionNumber { get; set; }
        public string? CandidateName { get; set; }
        public SettingForm()
        {
            InitializeComponent();
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            QuestionNumber = int.TryParse(textBox1.Text, out int questionNumber) ? questionNumber : (int?)null;
            CandidateName = textBox2.Text.Trim();
            if (QuestionNumber.HasValue && !string.IsNullOrEmpty(CandidateName))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid question number and candidate name.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
