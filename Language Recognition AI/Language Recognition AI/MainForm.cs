using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Language_Recognition_AI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillTvStats();
        }

        private void FillTvStats()
        {
            object[] data = { DataManager.Instance.TrainingData, DataManager.Instance.ValidationData };

            LanguageRecords[] trainingData = DataManager.Instance.TrainingData;
            LanguageRecords[] validationData = DataManager.Instance.ValidationData;

            foreach (var item in trainingData)
            {
                TreeNode recordCount = new TreeNode(string.Format("Record Count:\t{0}", item.RecordCount));
                TreeNode maxLength = new TreeNode(string.Format("Max Length record:\t{0}", item.MaxLenghtRecord));
                TreeNode minLength = new TreeNode(string.Format("Min Length record:\t{0}", item.MinLenghtRecord));

                TreeNode[] array = new TreeNode[] { recordCount, maxLength, minLength };

                tvDataStats.Nodes.Add(new TreeNode(item.Language, array));
            }

            tvDataStats.ExpandAll();
        }
    }
}
