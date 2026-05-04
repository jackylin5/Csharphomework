using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace infix
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int index = 0;
            string a = "", b = "";
            a = textBox1.Text;
            int len = a.Length;
            int i = 0;
            char[] stack = new char[100];
            

            while (i < len)
            {
                Console.Write("Stack: ");
                for (int j = 0; j < index; j++)
                {
                    Console.Write(stack[j] + " ");
                }
                Console.WriteLine();
                if (a[i] == '+'|| a[i] == '-'||a[i] == '*'|| a[i] == '/'|| a[i] == '%')
                {
                    if (index > 0) {
                        while ( stack[index - 1] == '*' || stack[index - 1] == '/' || stack[index - 1] == '%'
                            || (stack[index - 1] == '+' && (a[i] == '+' || a[i] == '-'))
                            || (stack[index - 1] == '-' && (a[i] == '+' || a[i] == '-')))
                        {
                            b += stack[index - 1];
                            stack[index - 1] = '\0';
                            index--;
                        }
                    }
                    stack[index] = a[i];
                    index++;
                }
                else if (a[i] == '(')
                {
                    stack[index] = '(';
                    index++;
                }
                else if (a[i] == ')')
                {
                    index--;
                    while(stack[index] != '(')
                    {
                        b += stack[index];
                        stack[index] = '\0';
                        index--;
                    }
                    
                    
                    index++;
                    
                }
                else
                {
                    b += a[i];
                }
                    i += 1;
            }
            while (index >= 0)
            {
                index--;
                if (index < 0)
                {
                    break;
                }
                if(stack[index]!='(') b += stack[index];


            }
            textBox2.Text = b;
        }
    }
}
//A+B*C%(D+((E*F-G/H)*I-J)*K+L)*M-N*P
/*int Priority(char op)
{
    if (op == '+' || op == '-') return 1;
    if (op == '*' || op == '/' || op == '%') return 2;
    return 0;
}

while (i < len)
{
    if ("+-*delete/%".Contains(a[i]))
    {
        while (index > 0 && stack[index - 1] != '(' &&
               Priority(stack[index - 1]) >= Priority(a[i]))
        {
            b += stack[index - 1];
            index--;
        }

        stack[index++] = a[i];
    }
    else if (a[i] == '(')
    {
        stack[index++] = '(';
    }
    else if (a[i] == ')')
    {
        while (index > 0 && stack[index - 1] != '(')
        {
            b += stack[index - 1];
            index--;
        }

        if (index > 0) index--; // pop '('
    }
    else
    {
        b += a[i];
    }

    i++;
}

while (index > 0)
{
    b += stack[--index];
}*/