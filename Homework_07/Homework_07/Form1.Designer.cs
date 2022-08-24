namespace Task01
{
    partial class Form1
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
            this.labelCurrentNumber = new System.Windows.Forms.Label();
            this.buttonPlusOne = new System.Windows.Forms.Button();
            this.buttonMultiplyByTwo = new System.Windows.Forms.Button();
            this.buttonPlayRestart = new System.Windows.Forms.Button();
            this.buttonTurnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCurrentTurn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNumberToReach = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCurrentNumber
            // 
            this.labelCurrentNumber.AutoSize = true;
            this.labelCurrentNumber.Location = new System.Drawing.Point(12, 58);
            this.labelCurrentNumber.Name = "labelCurrentNumber";
            this.labelCurrentNumber.Size = new System.Drawing.Size(22, 25);
            this.labelCurrentNumber.TabIndex = 0;
            this.labelCurrentNumber.Text = "0";
            this.labelCurrentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonPlusOne
            // 
            this.buttonPlusOne.Location = new System.Drawing.Point(191, 9);
            this.buttonPlusOne.Name = "buttonPlusOne";
            this.buttonPlusOne.Size = new System.Drawing.Size(112, 34);
            this.buttonPlusOne.TabIndex = 1;
            this.buttonPlusOne.Text = "+ 1";
            this.buttonPlusOne.UseVisualStyleBackColor = true;
            this.buttonPlusOne.Click += new System.EventHandler(this.buttonPlusOne_Click);
            // 
            // buttonMultiplyByTwo
            // 
            this.buttonMultiplyByTwo.Location = new System.Drawing.Point(191, 49);
            this.buttonMultiplyByTwo.Name = "buttonMultiplyByTwo";
            this.buttonMultiplyByTwo.Size = new System.Drawing.Size(112, 34);
            this.buttonMultiplyByTwo.TabIndex = 2;
            this.buttonMultiplyByTwo.Text = "x 2";
            this.buttonMultiplyByTwo.UseVisualStyleBackColor = true;
            this.buttonMultiplyByTwo.Click += new System.EventHandler(this.buttonMultiplyByTwo_Click);
            // 
            // buttonPlayRestart
            // 
            this.buttonPlayRestart.Location = new System.Drawing.Point(191, 129);
            this.buttonPlayRestart.Name = "buttonPlayRestart";
            this.buttonPlayRestart.Size = new System.Drawing.Size(112, 34);
            this.buttonPlayRestart.TabIndex = 3;
            this.buttonPlayRestart.Text = "Play";
            this.buttonPlayRestart.UseVisualStyleBackColor = true;
            this.buttonPlayRestart.Click += new System.EventHandler(this.buttonPlayRestart_Click);
            // 
            // buttonTurnBack
            // 
            this.buttonTurnBack.Location = new System.Drawing.Point(191, 89);
            this.buttonTurnBack.Name = "buttonTurnBack";
            this.buttonTurnBack.Size = new System.Drawing.Size(112, 34);
            this.buttonTurnBack.TabIndex = 4;
            this.buttonTurnBack.Text = "Undo";
            this.buttonTurnBack.UseVisualStyleBackColor = true;
            this.buttonTurnBack.Click += new System.EventHandler(this.buttonTurnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Current Turn:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCurrentTurn
            // 
            this.labelCurrentTurn.AutoSize = true;
            this.labelCurrentTurn.Location = new System.Drawing.Point(12, 138);
            this.labelCurrentTurn.Name = "labelCurrentTurn";
            this.labelCurrentTurn.Size = new System.Drawing.Size(22, 25);
            this.labelCurrentTurn.TabIndex = 6;
            this.labelCurrentTurn.Text = "0";
            this.labelCurrentTurn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Number:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNumberToReach
            // 
            this.labelNumberToReach.Location = new System.Drawing.Point(12, 190);
            this.labelNumberToReach.Name = "labelNumberToReach";
            this.labelNumberToReach.Size = new System.Drawing.Size(291, 38);
            this.labelNumberToReach.TabIndex = 8;
            this.labelNumberToReach.Text = "Press \'Play\' to start new game";
            this.labelNumberToReach.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 237);
            this.Controls.Add(this.labelNumberToReach);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCurrentTurn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTurnBack);
            this.Controls.Add(this.buttonPlayRestart);
            this.Controls.Add(this.buttonMultiplyByTwo);
            this.Controls.Add(this.buttonPlusOne);
            this.Controls.Add(this.labelCurrentNumber);
            this.Name = "Form1";
            this.Text = "Doubler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCurrentNumber;
        private System.Windows.Forms.Button buttonPlusOne;
        private System.Windows.Forms.Button buttonMultiplyByTwo;
        private System.Windows.Forms.Button buttonPlayRestart;
        private System.Windows.Forms.Button buttonTurnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCurrentTurn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNumberToReach;
    }
}
