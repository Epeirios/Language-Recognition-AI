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
        private ModelControl[] modelControls;
        BackgroundWorker backgroundWorker;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            modelControls = new ModelControl[] { new ModelControl(new BiGramModel(), "BiGram") };

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            backgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (var modelControl in modelControls)
            {
                listView1.Controls.Add(modelControl);
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            FillTvStats();
        }

        private void FillTvStats()
        {
            LanguageRecords[] trainingData = DataManager.Instance.TrainingData;

            foreach (var item in trainingData)
            {
                TreeNode recordCount = new TreeNode(string.Format("Record Count: {0}", item.RecordCount));
                TreeNode maxLength = new TreeNode(string.Format("Max Length record: {0}", item.MaxLenghtRecord));
                TreeNode minLength = new TreeNode(string.Format("Min Length record: {0}", item.MinLenghtRecord));
                TreeNode dictLength = new TreeNode(string.Format("Dict Lenght: {0}", item.CharDictionary.Count));

                TreeNode[] array = new TreeNode[] { recordCount, maxLength, minLength, dictLength };

                this.InvokeEx(f => f.tvDataStats.Nodes.Add(new TreeNode(item.Language.ToString(), array)));
            }

            this.InvokeEx(f => f.tvDataStats.ExpandAll());
        }
    }
}
