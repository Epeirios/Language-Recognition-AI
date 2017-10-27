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
        string modelName;

        public string ModelName
        {
            get
            {
                return modelName;
            }
        }

        public ModelControl(string modelName)
        {
            InitializeComponent();

            this.modelName = modelName;
            groupBox.Text = modelName;
        }
    }
}
