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
        MainForm mainForm;

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

        public ModelControl(string modelName, MainForm mainForm, IModel model)
        {
            InitializeComponent();

            this.mainForm = mainForm;

            this.model = model;
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            this.modelName = modelName;
            groupBox.Text = modelName;
            AddLogRecord("--Initialized--");

            model.EventProgress += Model_EventProgress;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnValidate.Enabled = true;
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
            model.EventProgress -= Model_EventProgress;

            model = mainForm.GetNGramModel(modelName);

            model.EventProgress += Model_EventProgress;

            backgroundWorker.RunWorkerAsync();
            btnValidate.Enabled = false;
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
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

        private void btnValidate_Click(object sender, EventArgs e)
        {
            Runworker();
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
