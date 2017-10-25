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
            this.pbValidating = new System.Windows.Forms.ProgressBar();
            this.flpTraining = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvControl
            // 
            this.tvControl.Location = new System.Drawing.Point(3, 19);
            this.tvControl.Name = "tvControl";
            this.tvControl.Size = new System.Drawing.Size(244, 106);
            this.tvControl.TabIndex = 0;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.flpTraining);
            this.groupBox.Controls.Add(this.pbValidating);
            this.groupBox.Controls.Add(this.tvControl);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(250, 290);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "gbName";
            // 
            // pbValidating
            // 
            this.pbValidating.Location = new System.Drawing.Point(65, 261);
            this.pbValidating.Name = "pbValidating";
            this.pbValidating.Size = new System.Drawing.Size(182, 23);
            this.pbValidating.TabIndex = 5;
            // 
            // flpTraining
            // 
            this.flpTraining.AutoScroll = true;
            this.flpTraining.Location = new System.Drawing.Point(3, 144);
            this.flpTraining.Name = "flpTraining";
            this.flpTraining.Size = new System.Drawing.Size(244, 111);
            this.flpTraining.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Training";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Validating";
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
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ProgressBar pbValidating;
        private System.Windows.Forms.FlowLayoutPanel flpTraining;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
