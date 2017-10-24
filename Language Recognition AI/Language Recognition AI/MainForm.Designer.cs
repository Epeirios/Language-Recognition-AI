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
            this.flpTraining = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // tvDataStats
            // 
            this.tvDataStats.Location = new System.Drawing.Point(12, 29);
            this.tvDataStats.Name = "tvDataStats";
            this.tvDataStats.ShowPlusMinus = false;
            this.tvDataStats.Size = new System.Drawing.Size(213, 374);
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
            this.label2.Location = new System.Drawing.Point(507, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Model Stats";
            // 
            // tbInputString
            // 
            this.tbInputString.Location = new System.Drawing.Point(12, 460);
            this.tbInputString.Multiline = true;
            this.tbInputString.Name = "tbInputString";
            this.tbInputString.Size = new System.Drawing.Size(411, 204);
            this.tbInputString.TabIndex = 4;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(429, 553);
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
            this.dgvResults.Location = new System.Drawing.Point(510, 460);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(846, 204);
            this.dgvResults.TabIndex = 6;
            // 
            // flpModels
            // 
            this.flpModels.Location = new System.Drawing.Point(510, 29);
            this.flpModels.Name = "flpModels";
            this.flpModels.Size = new System.Drawing.Size(846, 374);
            this.flpModels.TabIndex = 7;
            // 
            // flpTraining
            // 
            this.flpTraining.Location = new System.Drawing.Point(231, 29);
            this.flpTraining.Name = "flpTraining";
            this.flpTraining.Size = new System.Drawing.Size(273, 374);
            this.flpTraining.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Training Progress";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 676);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flpTraining);
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
        private System.Windows.Forms.FlowLayoutPanel flpTraining;
        private System.Windows.Forms.Label label3;
    }
}