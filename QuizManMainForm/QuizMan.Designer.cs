namespace QuizManMainForm
{
    partial class QuizMan
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizMan));
            toolStrip1 = new ToolStrip();
            tsbAddQuestion = new ToolStripButton();
            panel1 = new Panel();
            pnlOptions = new Panel();
            panel8 = new Panel();
            textBox7 = new TextBox();
            checkBox6 = new CheckBox();
            panel7 = new Panel();
            textBox6 = new TextBox();
            checkBox5 = new CheckBox();
            panel6 = new Panel();
            textBox5 = new TextBox();
            checkBox4 = new CheckBox();
            panel5 = new Panel();
            textBox4 = new TextBox();
            checkBox3 = new CheckBox();
            panel4 = new Panel();
            textBox3 = new TextBox();
            checkBox2 = new CheckBox();
            panel3 = new Panel();
            textBox2 = new TextBox();
            checkBox1 = new CheckBox();
            panel2 = new Panel();
            textBox1 = new TextBox();
            checkBox8 = new CheckBox();
            tbRemark = new TextBox();
            label9 = new Label();
            tbExplanation = new TextBox();
            label8 = new Label();
            btnSave = new Button();
            tbFullName = new TextBox();
            tbShortName = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            cbQuizType = new ComboBox();
            label4 = new Label();
            cbCategory = new ComboBox();
            label3 = new Label();
            cbDifficulty = new ComboBox();
            label2 = new Label();
            tbTopic = new TextBox();
            label1 = new Label();
            tsbLoadPDFQuestion = new ToolStripButton();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            pnlOptions.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbAddQuestion, tsbLoadPDFQuestion });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1578, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbAddQuestion
            // 
            tsbAddQuestion.Image = (Image)resources.GetObject("tsbAddQuestion.Image");
            tsbAddQuestion.ImageTransparentColor = Color.Magenta;
            tsbAddQuestion.Name = "tsbAddQuestion";
            tsbAddQuestion.Size = new Size(108, 22);
            tsbAddQuestion.Text = "Add Question";
            // 
            // panel1
            // 
            panel1.Controls.Add(pnlOptions);
            panel1.Controls.Add(tbRemark);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(tbExplanation);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(tbFullName);
            panel1.Controls.Add(tbShortName);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cbQuizType);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cbCategory);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cbDifficulty);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(tbTopic);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(1578, 920);
            panel1.TabIndex = 1;
            // 
            // pnlOptions
            // 
            pnlOptions.Controls.Add(panel8);
            pnlOptions.Controls.Add(panel7);
            pnlOptions.Controls.Add(panel6);
            pnlOptions.Controls.Add(panel5);
            pnlOptions.Controls.Add(panel4);
            pnlOptions.Controls.Add(panel3);
            pnlOptions.Controls.Add(panel2);
            pnlOptions.Location = new Point(31, 203);
            pnlOptions.Name = "pnlOptions";
            pnlOptions.Size = new Size(1033, 647);
            pnlOptions.TabIndex = 38;
            // 
            // panel8
            // 
            panel8.Controls.Add(textBox7);
            panel8.Controls.Add(checkBox6);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 528);
            panel8.Name = "panel8";
            panel8.Size = new Size(1033, 88);
            panel8.TabIndex = 52;
            // 
            // textBox7
            // 
            textBox7.Font = new Font("Microsoft YaHei UI", 14F);
            textBox7.Location = new Point(53, 4);
            textBox7.Multiline = true;
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(965, 72);
            textBox7.TabIndex = 35;
            // 
            // checkBox6
            // 
            checkBox6.Appearance = Appearance.Button;
            checkBox6.FlatStyle = FlatStyle.Flat;
            checkBox6.Font = new Font("Microsoft YaHei UI", 14F);
            checkBox6.Location = new Point(13, 28);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(25, 25);
            checkBox6.TabIndex = 34;
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            panel7.Controls.Add(textBox6);
            panel7.Controls.Add(checkBox5);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 440);
            panel7.Name = "panel7";
            panel7.Size = new Size(1033, 88);
            panel7.TabIndex = 51;
            // 
            // textBox6
            // 
            textBox6.Font = new Font("Microsoft YaHei UI", 14F);
            textBox6.Location = new Point(53, 4);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(965, 72);
            textBox6.TabIndex = 35;
            // 
            // checkBox5
            // 
            checkBox5.Appearance = Appearance.Button;
            checkBox5.FlatStyle = FlatStyle.Flat;
            checkBox5.Font = new Font("Microsoft YaHei UI", 14F);
            checkBox5.Location = new Point(13, 28);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(25, 25);
            checkBox5.TabIndex = 34;
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            panel6.Controls.Add(textBox5);
            panel6.Controls.Add(checkBox4);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 352);
            panel6.Name = "panel6";
            panel6.Size = new Size(1033, 88);
            panel6.TabIndex = 50;
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Microsoft YaHei UI", 14F);
            textBox5.Location = new Point(53, 4);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(965, 72);
            textBox5.TabIndex = 35;
            // 
            // checkBox4
            // 
            checkBox4.Appearance = Appearance.Button;
            checkBox4.FlatStyle = FlatStyle.Flat;
            checkBox4.Font = new Font("Microsoft YaHei UI", 14F);
            checkBox4.Location = new Point(13, 28);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(25, 25);
            checkBox4.TabIndex = 34;
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Controls.Add(textBox4);
            panel5.Controls.Add(checkBox3);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 264);
            panel5.Name = "panel5";
            panel5.Size = new Size(1033, 88);
            panel5.TabIndex = 49;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Microsoft YaHei UI", 14F);
            textBox4.Location = new Point(53, 4);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(965, 72);
            textBox4.TabIndex = 35;
            // 
            // checkBox3
            // 
            checkBox3.Appearance = Appearance.Button;
            checkBox3.FlatStyle = FlatStyle.Flat;
            checkBox3.Font = new Font("Microsoft YaHei UI", 14F);
            checkBox3.Location = new Point(13, 28);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(25, 25);
            checkBox3.TabIndex = 34;
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(textBox3);
            panel4.Controls.Add(checkBox2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 176);
            panel4.Name = "panel4";
            panel4.Size = new Size(1033, 88);
            panel4.TabIndex = 48;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Microsoft YaHei UI", 14F);
            textBox3.Location = new Point(53, 4);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(965, 72);
            textBox3.TabIndex = 35;
            // 
            // checkBox2
            // 
            checkBox2.Appearance = Appearance.Button;
            checkBox2.FlatStyle = FlatStyle.Flat;
            checkBox2.Font = new Font("Microsoft YaHei UI", 14F);
            checkBox2.Location = new Point(13, 28);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(25, 25);
            checkBox2.TabIndex = 34;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(checkBox1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 88);
            panel3.Name = "panel3";
            panel3.Size = new Size(1033, 88);
            panel3.TabIndex = 47;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Microsoft YaHei UI", 14F);
            textBox2.Location = new Point(53, 4);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(965, 72);
            textBox2.TabIndex = 35;
            // 
            // checkBox1
            // 
            checkBox1.Appearance = Appearance.Button;
            checkBox1.FlatStyle = FlatStyle.Flat;
            checkBox1.Font = new Font("Microsoft YaHei UI", 14F);
            checkBox1.Location = new Point(13, 28);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(25, 25);
            checkBox1.TabIndex = 34;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(checkBox8);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1033, 88);
            panel2.TabIndex = 46;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Microsoft YaHei UI", 14F);
            textBox1.Location = new Point(53, 4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(965, 72);
            textBox1.TabIndex = 35;
            // 
            // checkBox8
            // 
            checkBox8.Appearance = Appearance.Button;
            checkBox8.BackColor = SystemColors.Control;
            checkBox8.FlatStyle = FlatStyle.Flat;
            checkBox8.Font = new Font("Microsoft YaHei UI", 14F);
            checkBox8.Location = new Point(13, 28);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(25, 25);
            checkBox8.TabIndex = 34;
            checkBox8.UseVisualStyleBackColor = false;
            // 
            // tbRemark
            // 
            tbRemark.Location = new Point(1080, 406);
            tbRemark.Multiline = true;
            tbRemark.Name = "tbRemark";
            tbRemark.Size = new Size(417, 159);
            tbRemark.TabIndex = 37;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft YaHei UI", 14F);
            label9.Location = new Point(1080, 378);
            label9.Name = "label9";
            label9.Size = new Size(86, 25);
            label9.TabIndex = 36;
            label9.Text = "Remark:";
            // 
            // tbExplanation
            // 
            tbExplanation.Location = new Point(1080, 203);
            tbExplanation.Multiline = true;
            tbExplanation.Name = "tbExplanation";
            tbExplanation.Size = new Size(417, 159);
            tbExplanation.TabIndex = 35;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft YaHei UI", 14F);
            label8.Location = new Point(1080, 175);
            label8.Name = "label8";
            label8.Size = new Size(124, 25);
            label8.TabIndex = 34;
            label8.Text = "Explanation:";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft YaHei UI", 16F);
            btnSave.Location = new Point(942, 856);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(113, 35);
            btnSave.TabIndex = 29;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // tbFullName
            // 
            tbFullName.Location = new Point(1183, 101);
            tbFullName.Name = "tbFullName";
            tbFullName.Size = new Size(314, 23);
            tbFullName.TabIndex = 28;
            tbFullName.Text = "Professional Scrum Master I ";
            // 
            // tbShortName
            // 
            tbShortName.Location = new Point(1183, 69);
            tbShortName.Name = "tbShortName";
            tbShortName.Size = new Size(314, 23);
            tbShortName.TabIndex = 27;
            tbShortName.Text = "PSM-I";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft YaHei UI", 14F);
            label7.Location = new Point(1073, 99);
            label7.Name = "label7";
            label7.Size = new Size(104, 25);
            label7.TabIndex = 26;
            label7.Text = "FullName:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft YaHei UI", 14F);
            label6.Location = new Point(1058, 65);
            label6.Name = "label6";
            label6.Size = new Size(121, 25);
            label6.TabIndex = 25;
            label6.Text = "ShortName:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft YaHei UI", 14F);
            label5.Location = new Point(1077, 34);
            label5.Name = "label5";
            label5.Size = new Size(102, 25);
            label5.TabIndex = 24;
            label5.Text = "QuizType:";
            // 
            // cbQuizType
            // 
            cbQuizType.FormattingEnabled = true;
            cbQuizType.Items.AddRange(new object[] { "PSM1", "PSM2", "PSM3" });
            cbQuizType.Location = new Point(1183, 34);
            cbQuizType.Name = "cbQuizType";
            cbQuizType.Size = new Size(78, 25);
            cbQuizType.TabIndex = 23;
            cbQuizType.Text = "PSM1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 14F);
            label4.Location = new Point(1282, 135);
            label4.Name = "label4";
            label4.Size = new Size(100, 25);
            label4.TabIndex = 22;
            label4.Text = "Category:";
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Items.AddRange(new object[] { "None", "SingleChoice", "MultipleChoice", "TrueOrFalse", "FillInTheBlank" });
            cbCategory.Location = new Point(1388, 135);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(109, 25);
            cbCategory.TabIndex = 21;
            cbCategory.Text = "SingleChoice";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 14F);
            label3.Location = new Point(1080, 135);
            label3.Name = "label3";
            label3.Size = new Size(99, 25);
            label3.TabIndex = 20;
            label3.Text = "Difficulty:";
            // 
            // cbDifficulty
            // 
            cbDifficulty.FormattingEnabled = true;
            cbDifficulty.Items.AddRange(new object[] { "Easy", "Medium", "Hard" });
            cbDifficulty.Location = new Point(1183, 135);
            cbDifficulty.Name = "cbDifficulty";
            cbDifficulty.Size = new Size(78, 25);
            cbDifficulty.TabIndex = 19;
            cbDifficulty.Text = "Medium";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 14F);
            label2.Location = new Point(31, 175);
            label2.Name = "label2";
            label2.Size = new Size(89, 25);
            label2.TabIndex = 2;
            label2.Text = "Options:";
            // 
            // tbTopic
            // 
            tbTopic.Font = new Font("Microsoft YaHei UI", 14F);
            tbTopic.Location = new Point(31, 34);
            tbTopic.Multiline = true;
            tbTopic.Name = "tbTopic";
            tbTopic.Size = new Size(1024, 126);
            tbTopic.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 14F);
            label1.Location = new Point(31, 6);
            label1.Name = "label1";
            label1.Size = new Size(100, 25);
            label1.TabIndex = 0;
            label1.Text = "Question:";
            // 
            // tsbLoadPDFQuestion
            // 
            tsbLoadPDFQuestion.Image = (Image)resources.GetObject("tsbLoadPDFQuestion.Image");
            tsbLoadPDFQuestion.ImageTransparentColor = Color.Magenta;
            tsbLoadPDFQuestion.Name = "tsbLoadPDFQuestion";
            tsbLoadPDFQuestion.Size = new Size(88, 22);
            tsbLoadPDFQuestion.Text = "Load Data";
            tsbLoadPDFQuestion.Click += TsbLoadPDFQuestion_Click;
            // 
            // QuizMan
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 945);
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            Name = "QuizMan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlOptions.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbAddQuestion;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox tbTopic;
        private Label label4;
        private ComboBox cbCategory;
        private Label label3;
        private ComboBox cbDifficulty;
        private Label label5;
        private ComboBox cbQuizType;
        private Label label6;
        private TextBox tbFullName;
        private TextBox tbShortName;
        private Label label7;
        private Button btnSave;
        private TextBox tbExplanation;
        private Label label8;
        private TextBox tbRemark;
        private Label label9;
        private Panel pnlOptions;
        private Panel panel8;
        private TextBox textBox7;
        private CheckBox checkBox6;
        private Panel panel7;
        private TextBox textBox6;
        private CheckBox checkBox5;
        private Panel panel6;
        private TextBox textBox5;
        private CheckBox checkBox4;
        private Panel panel5;
        private TextBox textBox4;
        private CheckBox checkBox3;
        private Panel panel4;
        private TextBox textBox3;
        private CheckBox checkBox2;
        private Panel panel3;
        private TextBox textBox2;
        private CheckBox checkBox1;
        private Panel panel2;
        private TextBox textBox1;
        private CheckBox checkBox8;
        private ToolStripButton tsbLoadPDFQuestion;
    }
}
