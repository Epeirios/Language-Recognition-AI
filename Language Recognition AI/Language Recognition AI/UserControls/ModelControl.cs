using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace Language_Recognition_AI
{
    public partial class ModelControl : UserControl
    {
        string modelName;

        public string ModelName
        {
            get
            {
                return modelName;
            }
        }

        public TreeView ReportView
        {
            get
            {
                return tvControl;
            }
        }

        public Label LabelTrainingTime
        {
            get
            {
                return lblTrainingTime;
            }
        }

        public ModelControl(string modelName)
        {
            InitializeComponent();

            this.modelName = modelName;
            groupBox.Text = modelName;

            lblTrainingTime.Text = string.Empty;
        }

        public void SetTrainingTime(long trainingTime)
        {
            this.InvokeEx(f => f.lblTrainingTime.Text = trainingTime.ToString());
        }

        public void UpdateProgressBar(int progress)
        {
            if (0 <= progress && progress <= 100)
            {
                this.InvokeEx(f => f.pbProgress.Value = progress);
            }
        }
    }
}
