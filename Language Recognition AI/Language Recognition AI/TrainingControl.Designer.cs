namespace Language_Recognition_AI
{
    partial class TrainingControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbTraining = new System.Windows.Forms.ProgressBar();
            this.lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbTraining
            // 
            this.pbTraining.Location = new System.Drawing.Point(77, 3);
            this.pbTraining.Name = "pbTraining";
            this.pbTraining.Size = new System.Drawing.Size(129, 13);
            this.pbTraining.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            // 
            // TrainingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbTraining);
            this.Name = "TrainingControl";
            this.Size = new System.Drawing.Size(209, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar pbTraining;
        private System.Windows.Forms.Label lblName;
    }
}
