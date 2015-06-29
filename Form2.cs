using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCompression
{
    public partial class Form2 : Form
    {
        static Form2 form;
        public Form2(string msg)
        {
            InitializeComponent();
            label1.Text = msg;
        }

        public static void Show(String msg)
        {
            form = new Form2(msg);
            //form.ShowDialog();
            form.Show();
        }

        public new static void Hide()
        {
            form.Dispose();
        }
    }
}
