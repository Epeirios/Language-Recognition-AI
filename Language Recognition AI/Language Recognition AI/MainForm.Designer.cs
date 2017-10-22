namespace Language_Recognition_AI
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // tvDataStats
            // 
            this.tvDataStats.Location = new System.Drawing.Point(12, 12);
            this.tvDataStats.Name = "tvDataStats";
            this.tvDataStats.ShowPlusMinus = false;
            this.tvDataStats.Size = new System.Drawing.Size(213, 318);
            this.tvDataStats.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(231, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(573, 318);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 342);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.tvDataStats);
            this.Name = "MainForm";
            this.Text = "Language Recognition AI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvDataStats;
        private System.Windows.Forms.ListView listView1;
    }
}