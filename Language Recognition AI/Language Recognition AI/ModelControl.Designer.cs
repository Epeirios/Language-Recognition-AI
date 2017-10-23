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
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.pbTraining = new System.Windows.Forms.ProgressBar();
            this.pbValidating = new System.Windows.Forms.ProgressBar();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvControl
            // 
            this.tvControl.Location = new System.Drawing.Point(6, 19);
            this.tvControl.Name = "tvControl";
            this.tvControl.Size = new System.Drawing.Size(238, 130);
            this.tvControl.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(169, 174);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.pbValidating);
            this.groupBox.Controls.Add(this.pbTraining);
            this.groupBox.Controls.Add(this.tbLog);
            this.groupBox.Controls.Add(this.tvControl);
            this.groupBox.Controls.Add(this.btnStart);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(250, 290);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "gbName";
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(3, 203);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(241, 81);
            this.tbLog.TabIndex = 3;
            // 
            // pbTraining
            // 
            this.pbTraining.Location = new System.Drawing.Point(6, 174);
            this.pbTraining.Name = "pbTraining";
            this.pbTraining.Size = new System.Drawing.Size(100, 23);
            this.pbTraining.TabIndex = 4;
            // 
            // pbValidating
            // 
            this.pbValidating.Location = new System.Drawing.Point(112, 174);
            this.pbValidating.Name = "pbValidating";
            this.pbValidating.Size = new System.Drawing.Size(51, 23);
            this.pbValidating.TabIndex = 5;
            // 
            // ModelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "ModelControl";
            this.Size = new System.Drawing.Size(250, 290);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvControl;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.ProgressBar pbValidating;
        private System.Windows.Forms.ProgressBar pbTraining;
    }
}
