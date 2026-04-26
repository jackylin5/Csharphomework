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
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace WindowsFormsApp2
{
    
    public partial class Form1 : Form
    {
        int n = 6;
        TextBox[,] board = new TextBox[6, 6];
        int[,] arr = new int[6, 6];
        int[,] max = new int[6, 6];
        


        int count = 1;

        
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    board[i, j] = this.Controls["textbox" + count] as TextBox;
                    count++;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "a(*.dat)|*.dat";
           /* if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo f = new FileInfo(openFileDialog1.FileName);

                using (StreamReader sr = f.OpenText())
                {
                    int row = 0;

                    while (!sr.EndOfStream && row < 6)
                    {
                        string line = sr.ReadLine();
                        string[] values = Regex.Split(line.Trim(), @"\s+");
                        foreach (char c in line)
                        {
                            Console.WriteLine((int)c);
                        }
                        // 用空白或逗號切開
                        //string[] values = line.Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (char c in line)
                        {
                            Console.WriteLine($"char: {c}  code: {(int)c}");
                        }
                        for (int col = 0; col < 6 && col < values.Length; col++)
                        {
                            board[row, col].Text = values[col];
                        }

                        row++;
                    }
                }
            } 
            */

           if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        board[i, j].Text = "";
                        board[i, j].ForeColor = Color.Black;
                        textBox37.Text = "";
                    }
                }
                Array.Clear(arr, 0, arr.Length);
                List<string> numbers = new List<string>();
                numbers.Clear();
                
                using (BinaryReader br = new BinaryReader(File.Open(openFileDialog1.FileName, FileMode.Open)))
                {
                    
                    StringBuilder current = new StringBuilder();

                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        byte b = br.ReadByte();

                        if (b == 2 || b == 3) // 分隔符
                        {
                            if (current.Length > 0)
                            {
                                numbers.Add(current.ToString());
                                current.Clear();
                            }
                        }
                        else
                        {
                            current.Append((char)b);
                        }
                    }

                    // 塞進 6x6
                    for (int i = 0; i < numbers.Count && i < 36; i++)
                    {
                        int row = i / 6;
                        int col = i % 6;
                        if (i % 6 == 0)
                        {
                            Console.Write("\n");
                        }
                        board[row, col].Text = numbers[i];
                        
                        arr[i / 6, i % 6] = Convert.ToInt32(numbers[i]);
                        Console.Write(arr[i / 6, i % 6] + " ");
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] dp = new int[6, 6];
            char[,] dir = new char[6, 6]; // 'U' or 'L'

            // 初始化
            dp[0, 0] = arr[0, 0];

            // 第一列（只能從左邊來）
            for (int j = 1; j < n; j++)
            {
                dp[0, j] = dp[0, j - 1] + arr[0, j];
                dir[0, j] = 'L';
            }

            // 第一行（只能從上面來）
            for (int i = 1; i < n; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + arr[i, 0];
                dir[i, 0] = 'U';
            }

            // 填 DP
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (dp[i - 1, j] > dp[i, j - 1])
                    {
                        dp[i, j] = dp[i - 1, j] + arr[i, j];
                        dir[i, j] = 'U';
                    }
                    else
                    {
                        dp[i, j] = dp[i, j - 1] + arr[i, j];
                        dir[i, j] = 'L';
                    }
                }
            }

            // 最大值
            Console.WriteLine("最大總和: " + dp[5, 5]);

            // 🔙 回溯路徑
            List<Tuple<int, int>> path = new List<Tuple<int, int>>(); ;

            int x = 5, y = 5;
            while (!(x == 0 && y == 0))
            {
                path.Add(Tuple.Create(x, y));

                if (dir[x, y] == 'U')
                    x--;
                else
                    y--;
            }

            path.Add(Tuple.Create(0, 0));

            // 反轉（從起點到終點）
            path.Reverse();

            // 印出路徑
            Console.WriteLine("路徑:");
            foreach (var p in path)
            {
                Console.Write($"({p.Item1},{p.Item2}) ");
            }
            foreach (var p in path)
            {
                board[p.Item1, p.Item2].ForeColor = Color.Red;
            }
            textBox37.Text = dp[5, 5].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "DAT files (*.dat)|*.dat";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(sfd.FileName, FileMode.Create)))
                {
                    for (int i = 0; i < 36; i++)
                    {
                        int row = i / 6;
                        int col = i % 6;

                        string text = board[row, col].Text;

                        // 寫入數字（轉成 byte）
                        byte[] bytes = Encoding.ASCII.GetBytes(text);
                        bw.Write(bytes);

                        // 👉 加分隔符（交替 2 / 3）
                        if (i % 2 == 0)
                            bw.Write((byte)2);
                        else
                            bw.Write((byte)3);
                    }
                }
            }
        }
    }
}
