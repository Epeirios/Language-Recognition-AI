using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Language_Recognition_AI
{
    public partial class ModelControl : UserControl
    {
        IModel model;
        string modelName;
        DataManager dataManager;

        BackgroundWorker backgroundWorker;

        public IModel Model
        {
            get
            {
                return model;
            }
        }

        public string ModelName
        {
            get
            {
                return modelName;
            }
        }

        public IModel SetModel
        {
            set
            {
                model = value;
            }
        }

        public ModelControl(string modelName, IModel model, DataManager dataManager)
        {
            InitializeComponent();
            this.dataManager = dataManager;

            this.model = model;
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            this.modelName = modelName;
            groupBox.Text = modelName;

            flpTraining.Controls.AddRange(new Control[]{
                new TrainingControl("Ngram 1"),
                new TrainingControl("Ngram 2"),
            });

            model.EventProgress += Model_EventProgress;
            model.N1Grams.EventProgress += N1Grams_EventProgress;
            model.N2Grams.EventProgress += N2Grams_EventProgress;
        }

        private void N2Grams_EventProgress(object sender, EventArgsProgress e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgsProgress>(N2Grams_EventProgress), sender, e);
                return;
            }

            ((TrainingControl)(flpTraining.Controls[1])).UpdateProgress(e.Progress);
        }

        private void N1Grams_EventProgress(object sender, EventArgsProgress e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgsProgress>(N1Grams_EventProgress), sender, e);
                return;
            }

            ((TrainingControl)(flpTraining.Controls[0])).UpdateProgress(e.Progress);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void Model_EventProgress(object sender, EventArgsProgress e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgsProgress>(Model_EventProgress), sender, e);
                return;
            }

            pbValidating.Value = e.Progress;
        }

        public void Runworker()
        {
            backgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            model.N1Grams.Train(dataManager.TrainingData);
            model.N2Grams.Train(dataManager.TrainingData);

            ValidateModel();
        }

        private void AddNode(string nodeName)
        {
            this.InvokeEx(f => f.tvControl.Nodes.Add(nodeName));
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            Runworker();
        }

        private void ValidateModel()
        {
            tvControl.Nodes.Clear();
            pbValidating.Value = 0;

            Report report = model.Validate(dataManager.ValidationData);

            AddNode(string.Format("Number of Cases: {0}", report.CountCases));
            AddNode(string.Format("Cases Correct: {0}", report.CountCorrect));
            AddNode(string.Format("Cases Incorrect: {0}", report.CountIncorrect));
        }
    }
}
