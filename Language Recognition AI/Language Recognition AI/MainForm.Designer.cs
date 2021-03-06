﻿namespace Language_Recognition_AI
{
    partial class MainForm
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
            this.tvDataStats = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbInputString = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.flpModels = new System.Windows.Forms.FlowLayoutPanel();
            this.pbDataLoading = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // tvDataStats
            // 
            this.tvDataStats.Location = new System.Drawing.Point(12, 42);
            this.tvDataStats.Name = "tvDataStats";
            this.tvDataStats.ShowPlusMinus = false;
            this.tvDataStats.Size = new System.Drawing.Size(213, 361);
            this.tvDataStats.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Processing Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Model Stats";
            // 
            // tbInputString
            // 
            this.tbInputString.Location = new System.Drawing.Point(12, 438);
            this.tbInputString.Multiline = true;
            this.tbInputString.Name = "tbInputString";
            this.tbInputString.Size = new System.Drawing.Size(1007, 67);
            this.tbInputString.TabIndex = 4;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(1025, 436);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToResizeColumns = false;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvResults.Location = new System.Drawing.Point(12, 511);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(1088, 111);
            this.dgvResults.TabIndex = 6;
            // 
            // flpModels
            // 
            this.flpModels.AutoScroll = true;
            this.flpModels.Location = new System.Drawing.Point(233, 29);
            this.flpModels.Name = "flpModels";
            this.flpModels.Size = new System.Drawing.Size(867, 374);
            this.flpModels.TabIndex = 7;
            // 
            // pbDataLoading
            // 
            this.pbDataLoading.Location = new System.Drawing.Point(100, 13);
            this.pbDataLoading.Name = "pbDataLoading";
            this.pbDataLoading.Size = new System.Drawing.Size(127, 23);
            this.pbDataLoading.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 634);
            this.Controls.Add(this.pbDataLoading);
            this.Controls.Add(this.flpModels);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.tbInputString);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvDataStats);
            this.Name = "MainForm";
            this.Text = "Language Recognition AI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvDataStats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbInputString;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.FlowLayoutPanel flpModels;
        private System.Windows.Forms.ProgressBar pbDataLoading;
    }
}