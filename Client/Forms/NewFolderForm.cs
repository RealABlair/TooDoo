using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABSoftware;
using ABSoftware.UI;

namespace Client
{
    public partial class NewFolderForm : DraggableForm
    {
        public NewFolderForm()
        {
            InitializeComponent();
        }

        public string GroupName { get; private set; }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.GroupName = NewGroupNameTB.Text;
        }
    }
}
