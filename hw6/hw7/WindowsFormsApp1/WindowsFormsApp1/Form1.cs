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
        double totalArea = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();

            if (f2.ShowDialog() == DialogResult.OK)
            {
                string childPic = f2.PictureName; //例如 P2
                string parentPic = f2.ParentPic;  //例如 P1

                string newPic =
                    "{Picture " +
                    childPic +
                    ":}";

                string search =
                    "{Picture " +
                    parentPic +
                    ":";

                if (textBox1.Text.Contains(search))
                {
                    int pos = textBox1.Text.IndexOf(search);

                    //找 parent picture 對應的右括號
                    int braceCount = 0;
                    int insertPos = -1;

                    for (int i = pos; i < textBox1.Text.Length; i++)
                    {
                        if (textBox1.Text[i] == '{')
                            braceCount++;

                        if (textBox1.Text[i] == '}')
                        {
                            braceCount--;

                            if (braceCount == 0)
                            {
                                insertPos = i;
                                break;
                            }
                        }
                    }

                    if (insertPos != -1)
                    {
                        textBox1.Text =
                            textBox1.Text.Insert(
                                insertPos,
                                " " + newPic
                            );
                    }
                }
                else
                {
                    MessageBox.Show(
                        "不存在的Picture容器: " + f2.ParentPic,
                        "錯誤",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();

            if (f3.ShowDialog() == DialogResult.OK)
            {
                string rect =
                    "Rectangle " +
                    f3.RectName +
                    "(" +
                    f3.H +
                    "," +
                    f3.W +
                    ")";

                //加總面積
                


                string search = "{Picture " + f3.ParentPic + ":";

                if (textBox1.Text.Contains(search))
                {

                    int pos = textBox1.Text.IndexOf(search);

                    //找目前Picture真正結尾
                    int level = 0;
                    int insertPos = -1;

                    for (int i = pos; i < textBox1.Text.Length; i++)
                    {
                        if (textBox1.Text[i] == '{')
                            level++;

                        if (textBox1.Text[i] == '}')
                        {
                            level--;

                            if (level == 0)
                            {
                                insertPos = i;
                                break;
                            }
                        }
                    }

                    if (insertPos != -1)
                    {
                        totalArea += f3.H * f3.W;
                        //判斷Picture裡是否已有內容
                        string before =
                            textBox1.Text.Substring(
                                pos + search.Length,
                                insertPos - (pos + search.Length)
                            );

                        string addText =
                            (before.Trim() == "" ? "" : " ")
                            + rect;

                        textBox1.Text =
                            textBox1.Text.Insert(
                                insertPos,
                                addText
                            );
                    }
                }
                else
                {
                    MessageBox.Show(
                        "不存在的Picture容器: " + f3.ParentPic,
                        "錯誤",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                //如果有顯示總面積的textbox2
                //textBox2.Text = totalArea.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();

            if (f4.ShowDialog() == DialogResult.OK)
            {
                string rect =
                    "Triangle " +
                    f4.RectName +
                    "(" +
                    f4.H +
                    "," +
                    f4.W +
                    ")";

                //加總面積
                


                string search = "{Picture " + f4.ParentPic + ":";

                if (textBox1.Text.Contains(search))
                {
                    int pos = textBox1.Text.IndexOf(search);

                    //找目前Picture真正結尾
                    int level = 0;
                    int insertPos = -1;

                    for (int i = pos; i < textBox1.Text.Length; i++)
                    {
                        if (textBox1.Text[i] == '{')
                            level++;

                        if (textBox1.Text[i] == '}')
                        {
                            level--;

                            if (level == 0)
                            {
                                insertPos = i;
                                break;
                            }
                        }
                    }

                    if (insertPos != -1)
                    {
                        //判斷Picture裡是否已有內容
                        totalArea += f4.H * f4.W / (2.0);
                        string before =
                            textBox1.Text.Substring(
                                pos + search.Length,
                                insertPos - (pos + search.Length)
                            );

                        string addText =
                            (before.Trim() == "" ? "" : " ")
                            + rect;

                        textBox1.Text =
                            textBox1.Text.Insert(
                                insertPos,
                                addText
                            );
                    }
                }
                else
                {
                    MessageBox.Show(
                        "不存在的Picture容器: " + f4.ParentPic,
                        "錯誤",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                //如果有顯示總面積的textbox2
                //textBox2.Text = totalArea.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();

            if (f5.ShowDialog() == DialogResult.OK)
            {
                string rect =
                    "Circle " +
                    f5.RectName +
                    "(" +
                    f5.R +
                    ")";

                //加總面積
                


                string search = "{Picture " + f5.ParentPic + ":";

                if (textBox1.Text.Contains(search))
                {
                    int pos = textBox1.Text.IndexOf(search);

                    //找目前Picture真正結尾
                    int level = 0;
                    int insertPos = -1;

                    for (int i = pos; i < textBox1.Text.Length; i++)
                    {
                        if (textBox1.Text[i] == '{')
                            level++;

                        if (textBox1.Text[i] == '}')
                        {
                            level--;

                            if (level == 0)
                            {
                                insertPos = i;
                                break;
                            }
                        }
                    }

                    if (insertPos != -1)
                    {
                        totalArea += f5.R * f5.R * Math.PI;
                        //判斷Picture裡是否已有內容
                        string before =
                            textBox1.Text.Substring(
                                pos + search.Length,
                                insertPos - (pos + search.Length)
                            );

                        string addText =
                            (before.Trim() == "" ? "" : " ")
                            + rect;

                        textBox1.Text =
                            textBox1.Text.Insert(
                                insertPos,
                                addText
                            );
                    }
                }
                else
                {
                    MessageBox.Show(
                        "不存在的Picture容器: " + f5.ParentPic,
                        "錯誤",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                //如果有顯示總面積的textbox2
                //textBox2.Text = totalArea.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = totalArea.ToString();
        }
    }
}
