namespace QuestionsEditor
{
    partial class AddQuestion
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonFalse = new System.Windows.Forms.RadioButton();
            this.radioButtonTrue = new System.Windows.Forms.RadioButton();
            this.buttonAddQuestion = new System.Windows.Forms.Button();
            this.buttonAddCanceled = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxQuestionText = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonFalse);
            this.groupBox3.Controls.Add(this.radioButtonTrue);
            this.groupBox3.Location = new System.Drawing.Point(12, 274);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(611, 79);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Answer";
            // 
            // radioButtonFalse
            // 
            this.radioButtonFalse.AutoSize = true;
            this.radioButtonFalse.Location = new System.Drawing.Point(426, 30);
            this.radioButtonFalse.Name = "radioButtonFalse";
            this.radioButtonFalse.Size = new System.Drawing.Size(75, 29);
            this.radioButtonFalse.TabIndex = 1;
            this.radioButtonFalse.Text = "False";
            this.radioButtonFalse.UseVisualStyleBackColor = true;
            // 
            // radioButtonTrue
            // 
            this.radioButtonTrue.AutoSize = true;
            this.radioButtonTrue.Checked = true;
            this.radioButtonTrue.Location = new System.Drawing.Point(243, 30);
            this.radioButtonTrue.Name = "radioButtonTrue";
            this.radioButtonTrue.Size = new System.Drawing.Size(69, 29);
            this.radioButtonTrue.TabIndex = 0;
            this.radioButtonTrue.TabStop = true;
            this.radioButtonTrue.Text = "True";
            this.radioButtonTrue.UseVisualStyleBackColor = true;
            // 
            // buttonAddQuestion
            // 
            this.buttonAddQuestion.Location = new System.Drawing.Point(287, 373);
            this.buttonAddQuestion.Name = "buttonAddQuestion";
            this.buttonAddQuestion.Size = new System.Drawing.Size(165, 51);
            this.buttonAddQuestion.TabIndex = 2;
            this.buttonAddQuestion.Text = "Add Question";
            this.buttonAddQuestion.UseVisualStyleBackColor = true;
            this.buttonAddQuestion.Click += new System.EventHandler(this.buttonAddQuestion_Click);
            // 
            // buttonAddCanceled
            // 
            this.buttonAddCanceled.Location = new System.Drawing.Point(458, 373);
            this.buttonAddCanceled.Name = "buttonAddCanceled";
            this.buttonAddCanceled.Size = new System.Drawing.Size(165, 51);
            this.buttonAddCanceled.TabIndex = 3;
            this.buttonAddCanceled.Text = "Cancel";
            this.buttonAddCanceled.UseVisualStyleBackColor = true;
            this.buttonAddCanceled.Click += new System.EventHandler(this.buttonAddCanceled_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxQuestionText);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(609, 256);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Question";
            // 
            // textBoxQuestionText
            // 
            this.textBoxQuestionText.Location = new System.Drawing.Point(6, 30);
            this.textBoxQuestionText.Multiline = true;
            this.textBoxQuestionText.Name = "textBoxQuestionText";
            this.textBoxQuestionText.Size = new System.Drawing.Size(597, 220);
            this.textBoxQuestionText.TabIndex = 0;
            // 
            // AddQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 438);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonAddCanceled);
            this.Controls.Add(this.buttonAddQuestion);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddQuestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Question Dialog";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonFalse;
        internal System.Windows.Forms.RadioButton radioButtonTrue;
        internal System.Windows.Forms.Button buttonAddQuestion;
        private System.Windows.Forms.Button buttonAddCanceled;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox textBoxQuestionText;
    }
}