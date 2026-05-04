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
    public partial class Form3 : Form
    {
        public string RectName;
        public string ParentPic;
        public int H;
        public int W;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RectName = textBox1.Text;
            ParentPic = textBox2.Text;

            H = int.Parse(textBox3.Text);
            W = int.Parse(textBox4.Text);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
