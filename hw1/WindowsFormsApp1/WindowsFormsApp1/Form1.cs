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
    public partial class Form1 : Form
    {
        string[,] name = new string[50, 2];
        int[,] scores = new int[50, 2];
        int counter = 0, math = 0, chinese = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //123
            string a= "學號\t姓名\t國文\t數學\t\r\n";
            for(int i = 0; i < counter; i++)
            {
                a += name[i, 0];
                a += "\t";
                a += name[i, 1];
                a += "\t";
                a += scores[i, 0];
                a += "\t";
                a += scores[i, 1];
                a += "\t";
                a += "\r\n";
            }
            a += "\r\n";
            textBox5.Text = a;
            //123
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            int f = 0;
            //123
            string a = "學號\t姓名\t國文\t數學\t\r\n";
            for (int i = 0; i < counter; i++)
            {
                if (name[i, 0] == s)
                {
                    f = 1;
                    a += name[i, 0];
                    a += "\t";
                    a += name[i, 1];
                    a += "\t";
                    a += scores[i, 0];
                    a += "\t";
                    a += scores[i, 1];
                    a += "\t";
                    a += "\r\n";
                }
                
            }
            if (f == 0)
            {
                MessageBox.Show("資料不存在", "搜尋學號"+textBox1.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                a += "\r\n";
                textBox5.Text = a;
            }
            
            //123

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Array.Clear(name,0,name.Length);
            Array.Clear(scores, 0, name.Length);
            //123
            string a = "學號\t姓名\t國文\t數學\t\r\n";
            for (int i = 0; i < counter; i++)
            {
                a += name[i, 0];
                a += "\t";
                a += name[i, 1];
                a += "\t";
                a += scores[i, 0];
                a += "\t";
                a += scores[i, 1];
                a += "\t";
                a += "\r\n";
            }
            a += "\r\n";
            textBox5.Text = a;
            //123
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(textBox3.Text);
                int b = Convert.ToInt32(textBox4.Text);
            }
            catch
            {
                MessageBox.Show("輸入字串格式不正確。", "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                name[counter, 0] = textBox1.Text;
                name[counter, 1] = textBox2.Text;
                scores[counter, 0] = Convert.ToInt32(textBox4.Text);
                scores[counter, 1] = Convert.ToInt32(textBox3.Text);

                counter += 1;
                textBox6.Text = counter.ToString();
                float avmath, avchin;
                int sum = 0;
                for(int i = 0; i <= counter - 1; i++)
                {
                    sum += scores[i, 0];
                }
                avmath = (float)sum / counter;
                sum = 0;
                for (int i = 0; i <= counter - 1; i++)
                {
                    sum += scores[i, 1];
                }
                avchin = (float)sum / counter;
                textBox7.Text = avmath.ToString();
                textBox8.Text = avchin.ToString();

                //123
                string a = "學號\t姓名\t國文\t數學\t\r\n";
                for (int i = 0; i < counter; i++)
                {
                    a += name[i, 0];
                    a += "\t";
                    a += name[i, 1];
                    a += "\t";
                    a += scores[i, 0];
                    a += "\t";
                    a += scores[i, 1];
                    a += "\t";
                    a += "\r\n";
                }
                a += "\r\n";
                textBox5.Text = a;
                //123
            }

        }
    }
}
