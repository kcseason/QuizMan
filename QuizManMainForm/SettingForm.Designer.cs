
namespace QuizManMainForm
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            btnCancel = new Button();
            btnStart = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 14F);
            label1.Location = new Point(53, 25);
            label1.Name = "label1";
            label1.Size = new Size(181, 25);
            label1.TabIndex = 0;
            label1.Text = "Question Number:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Microsoft YaHei UI", 14F);
            textBox1.Location = new Point(240, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 31);
            textBox1.TabIndex = 1;
            textBox1.Text = "60";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Microsoft YaHei UI", 14F);
            textBox2.Location = new Point(240, 69);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 31);
            textBox2.TabIndex = 3;
            textBox2.Text = "40";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 14F);
            label2.Location = new Point(43, 72);
            label2.Name = "label2";
            label2.Size = new Size(191, 25);
            label2.TabIndex = 2;
            label2.Text = "Duration time(min):";
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Microsoft YaHei UI", 14F);
            btnCancel.Location = new Point(94, 146);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(93, 36);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Microsoft YaHei UI", 14F);
            btnStart.Location = new Point(193, 146);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(93, 36);
            btnStart.TabIndex = 5;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += BtnStart_Click;
            // 
            // SettingForm
            // 
            AcceptButton = btnStart;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(372, 212);
            ControlBox = false;
            Controls.Add(btnStart);
            Controls.Add(btnCancel);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QuizSetForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Button btnCancel;
        private Button btnStart;
    }
}