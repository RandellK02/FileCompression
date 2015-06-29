using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileExplorer
{
    public partial class ExportLevels : Form
    {
        public ExportLevels()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 3;
            this.button1.DialogResult = DialogResult.OK;
            //this.AcceptButton = button1;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
