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

        public ModelControl(IModel model, string modelName)
        {
            InitializeComponent();

            this.model = model;
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;

            this.modelName = modelName;
            groupBox.Text = modelName;
            AddLogRecord("--Initialized--");

            model.EventValidationProgress += Model_EventValidationProgress;
            model.EventTrainingProgress += Model_EventTrainingProgress;
        }

        private void Model_EventTrainingProgress(object sender, EventArgsProgress e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgsProgress>(Model_EventTrainingProgress), sender, e);
                return;
            }

            pbTraining.Value = e.Progress;
        }

        private void Model_EventValidationProgress(object sender, EventArgsProgress e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgsProgress>(Model_EventValidationProgress), sender, e);
                return;
            }

            pbValidating.Value = e.Progress;
        }

        public void Runworker()
        {
            backgroundWorker.RunWorkerAsync();
            btnStart.Enabled = false;
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            TrainModel();
            ValidateModel();
        }

        private void AddNode(string nodeName)
        {
            this.InvokeEx(f => f.tvControl.Nodes.Add(nodeName));
        }

        private void AddLogRecord(string record)
        {
            this.InvokeEx(f => f.tbLog.AppendText((record)));
            this.InvokeEx(f => f.tbLog.AppendText(Environment.NewLine));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Runworker();
        }

        private void TrainModel()
        {
            AddLogRecord("Started:\t Training Model");

            model.Train(DataManager.Instance.TrainingData);

            AddLogRecord("Done:\t Training Model");
        }

        private void ValidateModel()
        {
            AddLogRecord("Started:\t Validating Model");

            Report report = model.Validate(DataManager.Instance.ValidationData);

            AddLogRecord("Done:\t Validating Model");

            AddNode(string.Format("Number of Cases: {0}", report.CountCases));
            AddNode(string.Format("Cases Correct: {0}", report.CountCorrect));
            AddNode(string.Format("Cases Incorrect: {0}", report.CountIncorrect));

            AddLogRecord("Report:\t Validation Model");
        }
    }
}
