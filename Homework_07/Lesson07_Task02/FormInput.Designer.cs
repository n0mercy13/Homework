namespace Lesson07_Task02
{
    partial class FormInput
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
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonTryNumber = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(12, 12);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(100, 23);
            this.textBoxInput.TabIndex = 0;
            // 
            // buttonTryNumber
            // 
            this.buttonTryNumber.Location = new System.Drawing.Point(129, 12);
            this.buttonTryNumber.Name = "buttonTryNumber";
            this.buttonTryNumber.Size = new System.Drawing.Size(75, 23);
            this.buttonTryNumber.TabIndex = 1;
            this.buttonTryNumber.Text = "Try";
            this.buttonTryNumber.UseVisualStyleBackColor = true;
            this.buttonTryNumber.Click += new System.EventHandler(this.buttonTryNumber_Click);
            // 
            // FormInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 49);
            this.Controls.Add(this.buttonTryNumber);
            this.Controls.Add(this.textBoxInput);
            this.Name = "FormInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Guess number";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonTryNumber;
    }
}