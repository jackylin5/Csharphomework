using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int[,] pic = new int[9, 9];
        TextBox[,,] result = new TextBox[3, 7, 7];
        int[,,] feature = new int[3, 3, 3]
        {
            { 
                {1,-1,-1},{-1,1,-1},{-1,-1,1}
            }
            ,
            {{1,-1,1 },{ -1,1,-1},{ 1,-1,1} }
            ,
            {{-1,-1,1 },{ -1,1,-1},{ 1,-1,-1} }
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowImagePixelated(int scale = 20) // scale 表示每個像素放大倍數
        {
            int width = pic.GetLength(1);
            int height = pic.GetLength(0);

            Bitmap bmp = new Bitmap(width * scale, height * scale);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White); // 背景白色

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color color = (pic[y, x] == 1) ? Color.Black : Color.White;
                        using (Brush brush = new SolidBrush(color))
                        {
                            g.FillRectangle(brush, x * scale, y * scale, scale, scale);
                        }
                    }
                }
            }

            pictureBox1.Image = bmp;
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel檔案(*.csv)|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string[] input = new string[9];
                int i = 0, j;
                while (sr.Peek() >= 0)
                {
                    input = sr.ReadLine().Split(',');
                    for (j = 0; j < 9; j++)
                    {
                        pic[i, j] = Convert.ToInt32(input[j]);
                    }
                    i++;
                }
                ShowImagePixelated();
                sr.Close();
                for (int f = 0; f < 3; f++) // feature 層
                {
                    for (int r = 0; r < 7; r++) // output row
                    {
                        for (int c = 0; c < 7; c++) // output col
                        {
                            int sum = 0;
                            for (int iRow = 0; iRow < 3; iRow++)
                            {
                                for (int iCol = 0; iCol < 3; iCol++)
                                {
                                    sum += pic[r + iRow, c + iCol] * feature[f, iRow, iCol];
                                }
                            }
                            // 將卷積結果填入對應 TextBox
                            if (result[f, r, c] != null)
                            {
                                float value = (float)sum / 9;
                                value = (float)Math.Floor(value * 100) / 100; // 無條件捨去到小數點後兩位
                                if (value < 0) { value += 0.01f; }
                                result[f, r, c].Text = value.ToString("F2");

                            }
                        }
                    }
                }
            }


           
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        /*private void Form1_Load(object sender, EventArgs e)
        {
            result[0, 0, 0] = textBox1;
            result[0, 0, 1] = textBox2;
            result[0, 0, 2] = textBox3;
            result[0, 0, 3] = textBox4;
            result[0, 6, 5] = textBox48;
            result[0, 6, 6] = textBox49;

            result[1, 0, 0] = textBox50;
            result[1, 0, 1] = textBox51;
            result[1, 6, 5] = textBox97;
            result[1, 6, 6] = textBox98;

            result[2, 0, 0] = textBox99;
            result[2, 0, 1] = textBox100;
            result[2, 6, 5] = textBox146;
            result[2, 6, 6] = textBox147;


        }*/
        private void Form1_Load(object sender, EventArgs e)
        {
            int layers = 3;    // 層數
            int rows = 7;      // 行數
            int cols = 7;      // 列數
            result = new TextBox[layers, rows, cols];

            int counter = 1;   // 對應 textBox1, textBox2, ...

            for (int l = 0; l < layers; l++)
            {
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        string textBoxName = "textBox" + counter;
                        TextBox tb = this.Controls.Find(textBoxName, true).FirstOrDefault() as TextBox;

                        if (tb != null)
                        {
                            result[l, r, c] = tb;
                        }
                        counter++;
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
