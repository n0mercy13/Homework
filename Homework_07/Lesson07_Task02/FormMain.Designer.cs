namespace Lesson07_Task02
{
    partial class FormMain
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
            this.labelNumberInputed = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelTurns = new System.Windows.Forms.Label();
            this.buttonPlayRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNumberInputed
            // 
            this.labelNumberInputed.Font = new System.Drawing.Font("Comic Sans MS", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNumberInputed.Location = new System.Drawing.Point(8, 5);
            this.labelNumberInputed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNumberInputed.Name = "labelNumberInputed";
            this.labelNumberInputed.Size = new System.Drawing.Size(265, 171);
            this.labelNumberInputed.TabIndex = 0;
            this.labelNumberInputed.Text = "???";
            this.labelNumberInputed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;            
            // 
            // labelInfo
            // 
            this.labelInfo.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelInfo.Location = new System.Drawing.Point(8, 187);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(265, 32);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "Press \'Play\' to start game";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTurns
            // 
            this.labelTurns.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTurns.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTurns.Location = new System.Drawing.Point(8, 226);
            this.labelTurns.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTurns.Name = "labelTurns";
            this.labelTurns.Size = new System.Drawing.Size(265, 28);
            this.labelTurns.TabIndex = 2;
            this.labelTurns.Text = "Turns: 0";
            this.labelTurns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPlayRestart
            // 
            this.buttonPlayRestart.Location = new System.Drawing.Point(102, 266);
            this.buttonPlayRestart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPlayRestart.Name = "buttonPlayRestart";
            this.buttonPlayRestart.Size = new System.Drawing.Size(78, 27);
            this.buttonPlayRestart.TabIndex = 3;
            this.buttonPlayRestart.Text = "Play";
            this.buttonPlayRestart.UseVisualStyleBackColor = true;
            this.buttonPlayRestart.Click += new System.EventHandler(this.buttonPlayRestart_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 306);
            this.Controls.Add(this.buttonPlayRestart);
            this.Controls.Add(this.labelTurns);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelNumberInputed);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guess Random Number";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelNumberInputed;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelTurns;
        private System.Windows.Forms.Button buttonPlayRestart;
    }
}
