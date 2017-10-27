using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace Language_Recognition_AI
{
    public partial class MainForm : Form
    {
        Dictionary<ModelControl, IModelFacade> models;
        BackgroundWorker backgroundWorker;
        DataManager.DataManager dataManager;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataManager = new DataManager.DataManager();

            this.models = new Dictionary<ModelControl, IModelFacade>();

            models.Add(new ModelControl("Trigram"), new NGramFacade(3));
            models.Add(new ModelControl("QuadGram"), new NGramFacade(4));

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            backgroundWorker.RunWorkerAsync();
        }

        private void DataManager_EventProgress(object sender, EventArgsProgress e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgsProgress>(DataManager_EventProgress), sender, e);
                return;
            }

            pbDataLoading.Value = e.Progress;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (var item in models)
            {
                flpModels.Controls.Add(item.Key);
                item.Value.TrainModel(dataManager.TrainingData);
                item.Value.ValidateModel(dataManager.TrainingData);
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            dataManager.ProcessData();
            FillTvStats();
        }

        private void FillTvStats()
        {
            LanguageRecords[] trainingData = dataManager.TrainingData;

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

        private void btnProcess_Click(object sender, EventArgs e)
        {
            dgvResults.Rows.Clear();
            dgvResults.Columns.Clear();

            dgvResults.Columns.Add("Model", "Model");

            foreach (var language in Enum.GetNames(typeof(Languages)))
            {
                dgvResults.Columns.Add(string.Format("Col{0}", language), language);
            }

            dgvResults.Columns.Add("Highest", "Highest");

            foreach (var model in models)
            {
                double highestValue = 0.0f;
                string highestLang = "None";

                List<string> cells = new List<string>();

                cells.Add(model.Key.ModelName);

                Dictionary<string, double> propabilities = model.Value.ValidateSentence(tbInputString.Text);

                foreach (var item in propabilities)
                {
                    double value = item.Value;

                    if (value > highestValue)
                    {
                        highestValue = value;
                        highestLang = item.Key;
                    }

                    cells.Add(value.ToString());
                }

                cells.Add(highestLang.ToString());

                dgvResults.Rows.Add(cells.ToArray());
            }
        }
    }
}
