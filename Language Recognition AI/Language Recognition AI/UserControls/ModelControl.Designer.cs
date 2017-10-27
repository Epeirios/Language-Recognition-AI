namespace Language_Recognition_AI
{
    partial class ModelControl
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
            this.tvControl = new System.Windows.Forms.TreeView();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvControl
            // 
            this.tvControl.Location = new System.Drawing.Point(3, 19);
            this.tvControl.Name = "tvControl";
            this.tvControl.Size = new System.Drawing.Size(244, 236);
            this.tvControl.TabIndex = 0;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.pbProgress);
            this.groupBox.Controls.Add(this.tvControl);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(250, 290);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "gbName";
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(6, 261);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(241, 23);
            this.pbProgress.TabIndex = 5;
            // 
            // ModelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "ModelControl";
            this.Size = new System.Drawing.Size(250, 290);
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvControl;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ProgressBar pbProgress;
    }
}
