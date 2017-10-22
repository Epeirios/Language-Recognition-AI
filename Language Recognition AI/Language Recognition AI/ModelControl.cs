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

        public IModel Model
        {
            get
            {
                return model;
            }
        }

        public ModelControl(IModel model, string modelName)
        {
            InitializeComponent();

            this.model = model;

            AddNode(modelName);
        }

        public void AddNode(string nodeName)
        {
            tvControl.Nodes.Add(nodeName);
        }
    }
}
