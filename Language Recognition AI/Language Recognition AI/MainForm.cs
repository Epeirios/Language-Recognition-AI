using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            //models.Add(new ModelControl("NeuralNetwork"), new NeuralNetworkFacade());

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            backgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (var item in models)
            {
                flpModels.Controls.Add(item.Key);

                BackgroundWorker localbackgroundWorker = new BackgroundWorker();
                localbackgroundWorker.WorkerReportsProgress = true;
                localbackgroundWorker.DoWork += new DoWorkEventHandler(
                delegate (object o, DoWorkEventArgs args)
                {
                    BackgroundWorker b = o as BackgroundWorker;

                    for (int i = 0; i < dataManager.TrainingData.Length; i++)
                    {
                        b.ReportProgress((int)(10 + i * 10));
                        item.Value.TrainModel(new LanguageRecords[] { dataManager.TrainingData[i] });
                    }

                    for (int i = 0; i < dataManager.ValidationData.Length; i++)
                    {
                        b.ReportProgress((int)(82.5 + i * 2.5f));
                        item.Value.ValidateModel(new LanguageRecords[] { dataManager.ValidationData[i] });
                    }

                    ValidationReport report = item.Value.GetValidationReport();
                    ModelHelper.ValidationReportToTreeView(item.Key.ReportView, report);

                    b.ReportProgress(100);
                });

                localbackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(
                delegate (object o, ProgressChangedEventArgs args)
                {
                    item.Key.UpdateProgressBar(args.ProgressPercentage);
                });

                localbackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate (object o, RunWorkerCompletedEventArgs args)
                {
                    item.Key.UpdateProgressBar(100);
                });

                localbackgroundWorker.RunWorkerAsync();
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

                Dictionary<Languages, double> propabilities = model.Value.ValidateSentence(tbInputString.Text);

                foreach (var item in propabilities)
                {
                    double value = item.Value;

                    if (value > highestValue)
                    {
                        highestValue = value;
                        highestLang = item.Key.ToString();
                    }

                    cells.Add(value.ToString());
                }

                cells.Add(highestLang.ToString());

                dgvResults.Rows.Add(cells.ToArray());
            }
        }
    }
}
