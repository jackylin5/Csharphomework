using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public string RectName;
        public string ParentPic;
        public int R;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            RectName = textBox1.Text;
            ParentPic = textBox2.Text;

            R = int.Parse(textBox3.Text);
            

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
