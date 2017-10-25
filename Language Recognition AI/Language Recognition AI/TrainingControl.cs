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

        public string GetMatrixName
        {
            get
            {
                return name;
            }
        }

        public TrainingControl(string name)
        {
            InitializeComponent();
            lblName.Text = name;
            this.name = name;
        }

        public void UpdateProgress(int progress)
        {
            if (progress <= 100 && progress >= 0)
            {
                pbTraining.Value = progress;
            }
        }
    }
}
