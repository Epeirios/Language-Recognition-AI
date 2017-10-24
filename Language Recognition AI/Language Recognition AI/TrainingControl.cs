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
    public partial class TrainingControl : UserControl
    {
        string name;
        NGramMatrix ngramMatrix;
        BackgroundWorker backgroundWorker;

        public string GetMatrixName
        {
            get
            {
                return name;
            }
        }

        public NGramMatrix GetNGramMatrix
        {
            get
            {
                return ngramMatrix;
            }
        }

        public TrainingControl(NGramMatrix ngramMatrix, string name)
        {
            InitializeComponent();

            this.ngramMatrix = ngramMatrix;
            groupBox.Text = name;
            this.name = name;

            ngramMatrix.EventProgress += NGramMatrix_EventProgress;

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ngramMatrix.Train(DataManager.Instance.TrainingData);
        }

        public void Train()
        {
            backgroundWorker.RunWorkerAsync();
        }

        private void NGramMatrix_EventProgress(object sender, EventArgsProgress e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgsProgress>(NGramMatrix_EventProgress), sender, e);
                return;
            }

            pbTraining.Value = e.Progress;
        }
    }
}
