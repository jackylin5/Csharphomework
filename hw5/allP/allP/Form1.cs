using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace allP
{
    using System;
    using System.Collections.Generic;

    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int multi(int a) {
            if (a == 0) return 1;
            if (a == 1 ) return a;
            return multi(a-1) * (a);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String a;
            a = textBox1.Text;
            int len = a.Length;
            //Console.WriteLine(multi(len));
            textBox2.Text = (multi(len)).ToString();
            string result = Permutation.GetPermutations(a);
            foreach (var p in result)
            {
                Console.WriteLine(p);
            }
            Console.Write(result);
            textBox3.Text = result;
            

        }
    }
    public class Permutation
    {
        public static string GetPermutations(string input)
        {
            List<string> result = new List<string>();
            char[] arr = input.ToCharArray();
            Permute(arr, 0, result);

            return string.Join(",", result);
        }

        private static void Permute(char[] arr, int start, List<string> result)
        {
            if (start == arr.Length)
            {
                result.Add(new string(arr));
                return;
            }

            for (int i = start; i < arr.Length; i++)
            {
                Swap(arr, start, i);        // 取一個跟前面交換
                Permute(arr, start + 1, result); // 遞迴裡面
                Swap(arr, start, i);        // 還原（Backtrack）
            }
        }

        private static void Swap(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
