using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        bool start = false;
        bool[] card=new bool[52];
        int[] dealer = new int[5];
        int[] player = new int[5];
        Random ran = new Random();
        int N1, N2, d, p, dn, pn,dc,pc;
        

        private void Button12_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("a");
            if (start == true)
            {
                //Console.WriteLine("b");
                if (p < 5)
                {
                   // Console.WriteLine("c");
                    do { player[p] = ran.Next(52); } while (card[player[p]] == true);
                    card[player[p]] = true;
                    if (p == 2)
                    {
                        button8.Content = GenerateColor(player[p]);
                        button8.Visibility = System.Windows.Visibility.Visible;
                    }
                    else if (p == 3)
                    {
                        button9.Content = GenerateColor(player[p]);
                        button9.Visibility = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        button10.Content = GenerateColor(player[p]);
                        button10.Visibility = System.Windows.Visibility.Visible;
                    }
                    //Console.WriteLine("d");
                    if (player[p] % 13 == 0) pc += 1;
                    
                    if (player[p] % 13 < 9) pn += player[p] % 13 + 1; else pn += 10;
                    p += 1;
                    if (pn > 21)
                    {
                        if (pc > 0)
                        {
                            pc -= 1;
                            pn -= 10;

                        }
                        button1.Content = GenerateColor(dealer[0]);
                        textBox1.Text = "" + (N1 - N2);
                        MessageBox.Show("玩家爆掉，你輸了" + N2 + "籌碼");
                        start = false;
                        return;
                        
                    }
                }
            }   
        }

        private void Button13_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("a");
            if (start == true)
            {
                //Console.WriteLine("b");
                if (d < 5)
                {
                    do
                    {
                        if (dn >= 17) break;
                        do { dealer[d] = ran.Next(52); } while (card[dealer[d]] == true);
                        card[dealer[d]] = true;
                        if (d == 2)
                        {
                            button3.Content = GenerateColor(dealer[d]);
                            button3.Visibility = System.Windows.Visibility.Visible;
                        }
                        else if (d == 3)
                        {
                            button4.Content = GenerateColor(dealer[d]);
                            button4.Visibility = System.Windows.Visibility.Visible;
                        }
                        else
                        {
                            button5.Content = GenerateColor(dealer[d]);
                            button5.Visibility = System.Windows.Visibility.Visible;
                        }
                        if (dealer[d] % 13 == 0) dc += 1;
                        if (dealer[d] % 13 < 9) dn += dealer[d] % 13 + 1; else dn += 10;
                        d += 1;
                        if (dn > 21)
                        {
                            if (dc > 0)
                            {
                                dc -= 1;
                                dn -= 10;

                            }
                            button1.Content = GenerateColor(dealer[0]);
                            textBox1.Text = "" + (N1 + N2);
                            MessageBox.Show("莊家爆掉，你贏了" + N2 + "籌碼");
                            Console.WriteLine("a" + dn + " " + dealer[0] % 13 + " " + dealer[1] % 13 + " " + dealer[2] % 13 + " " + dealer[3] % 13 + " " + dealer[4] % 13);
                            start = false;
                            return;

                        }
                        if(dn<17&& dc >= 0)
                        {
                            if (dn + 10 <= 21)
                            {
                                break;
                            }
                        }
                    } while (dn < 17);

                    
                    while (dn < pn)
                    {
                        if (dn < pn)
                        {
                            do { dealer[d] = ran.Next(52); } while (card[dealer[d]] == true);
                            card[dealer[d]] = true;
                            if (d == 2)
                            {
                                button3.Content = GenerateColor(dealer[d]);
                                button3.Visibility = System.Windows.Visibility.Visible;
                            }
                            else if (d == 3)
                            {
                                button4.Content = GenerateColor(dealer[d]);
                                button4.Visibility = System.Windows.Visibility.Visible;
                            }
                            else
                            {
                                button5.Content = GenerateColor(dealer[d]);
                                button5.Visibility = System.Windows.Visibility.Visible;
                            }
                            if (dealer[d] % 13 == 0) dc += 1;
                            if (dealer[d] % 13 < 9) dn += dealer[d] % 13 + 1; else dn += 10;
                            d += 1;
                            if (dn > 21)
                            {
                                if (dc > 0)
                                {
                                    dc -= 1;
                                    dn -= 10;

                                }
                                button1.Content = GenerateColor(dealer[0]);
                                textBox1.Text = "" + (N1 + N2);
                                MessageBox.Show("莊家爆掉，你贏了" + N2 + "籌碼");
                                Console.WriteLine("b" + dn + " " + dealer[0] % 13 + " " + dealer[1] % 13 + " " + dealer[2] % 13 + " " + dealer[3] % 13 + " " + dealer[4] % 13);
                                start = false;
                                return;
                            }
                        }
                    }

                        if (pn > dn)
                        {
                            
                            button1.Content = GenerateColor(dealer[0]);
                            textBox1.Text = "" + (N1 + N2);
                            MessageBox.Show("玩家點數較高，你贏了" + N2 + "籌碼");
                        Console.WriteLine("b" + dn + " " + dealer[0]%13 + " " + dealer[1]%13 + " " + dealer[2]%13 + " " + dealer[3]%13 + " " + dealer[4]%13);
                        start = false;
                            return;
                        }
                        else if (pn < dn)
                        {
                            button1.Content = GenerateColor(dealer[0]);
                            textBox1.Text = "" + (N1 - N2);
                            MessageBox.Show("莊家點數較高，你輸了" + N2 + "籌碼");
                        Console.WriteLine("b" + dn + " " + dealer[0] % 13 + " " + dealer[1] % 13 + " " + dealer[2] % 13 + " " + dealer[3] % 13 + " " + dealer[4] % 13);
                        start = false;
                            return;
                        }
                        else
                        {
                            button1.Content = GenerateColor(dealer[0]);
                            MessageBox.Show("雙方點數相等，平手");
                        Console.WriteLine("b" + dn + " " + dealer[0] % 13 + " " + dealer[1] % 13 + " " + dealer[2] % 13 + " " + dealer[3] % 13 + " " + dealer[4] % 13);
                        start = false;
                            return;
                        }
                    
                    // Console.WriteLine("c");
                    
                    //Console.WriteLine("d");

                    
                }
                else
                {
                    //c
                    if (pn > dn)
                    {
                        button1.Content = GenerateColor(dealer[0]);
                        textBox1.Text = "" + (N1 + N2);
                        MessageBox.Show("玩家點數較高，你贏了" + N2 + "籌碼");
                        start = false;
                        return;
                    }
                    else if(pn < dn)
                    {
                        button1.Content = GenerateColor(dealer[0]);
                        textBox1.Text = "" + (N1 - N2);
                        MessageBox.Show("莊家點數較高，你輸了" + "N2" + "籌碼");
                        start = false;
                        return;
                    }
                    else
                    {
                        button1.Content = GenerateColor(dealer[0]);
                        MessageBox.Show("雙方點數相等，平手" );
                        start = false;
                        return;
                    }
                    //c
                }
            }
        }

        string GenerateColor(int a)
        {
            string color;
            if (a <= 12)
            {
                color = "\u2660\r\n";
            }
                else if (a <= 25)
                {
                    color = "\u2665\r\n";
                }
                else if (a <= 38)
                {
                    color = "\u2666\r\n";
                }
                else
                {
                    color = "\u2663\r\n";
                }
            if (a % 13 == 0)
            {
                color += 'A';
            }
                else if (a % 13 == 12)
                {
                    color += 'K';
                }
                else if (a % 13 == 11)
                {
                    color += 'Q';
                }
                else if (a % 13 == 10)
                {
                    color += 'J';
                }
                else
                {
                color += (a % 13 + 1);
                }
            return color;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ;
        }

        private void Button11_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (start == false)
                {
                    d = 2; p = 2; dn = 0; pn = 0;
                    button3.Visibility = System.Windows.Visibility.Hidden;
                    button4.Visibility = System.Windows.Visibility.Hidden;
                    button5.Visibility = System.Windows.Visibility.Hidden;
                    button8.Visibility = System.Windows.Visibility.Hidden;
                    button9.Visibility = System.Windows.Visibility.Hidden;
                    button10.Visibility = System.Windows.Visibility.Hidden;
                    N1 = Convert.ToInt32(textBox1.Text);
                    N2 = Convert.ToInt32(textBox2.Text);
                    if (N2 > N1) throw new Exception("籌碼不足");
                    if (N2 <= 0) throw new Exception("下注籌碼不可為0");
                    textBox2.IsReadOnly = true;
                    int i;
                    for (i = 0; i < 52; i++) card[i] = false;
                    for (i = 0; i < 5; i++) { dealer[i] = -1; player[i] = -1; }
                    dealer[0] = ran.Next(52);
                    card[dealer[0]] = true;
                    button1.Content = "";
                    do { dealer[1] = ran.Next(52); } while (card[dealer[1]] == true);
                    card[dealer[1]] = true;
                    button2.Content = GenerateColor(dealer[1]);
                    do { player[0] = ran.Next(52); } while (card[player[0]] == true);
                    card[player[0]] = true;
                    button6.Content = GenerateColor(player[0]);
                    do { player[1] = ran.Next(52); } while (card[player[1]] == true);
                    card[player[1]] = true;
                    button7.Content = GenerateColor(player[1]);
                    if(dealer[0]%13==0 && dealer[1]%13>=9 || dealer[0]%13>=9 && dealer[1] % 13 == 0)
                    {
                        if (player[0] % 13 == 0 && player[1] % 13 >= 9 || player[0] % 13 >= 9 && player[1] % 13 == 0)
                        {
                            button1.Content = GenerateColor(dealer[0]);
                            MessageBox.Show("雙方都是blackjack，平手", "和局");
                            return;

                        }
                        else
                        {
                            button1.Content = GenerateColor(dealer[0]);
                            textBox1.Text = "" + (N1 - N2);
                            MessageBox.Show("莊家blackjack，你輸了" + "N2" + "籌碼");
                            return;
                        }
                        
                    }
                    else if(player[0] % 13 == 0 && player[1] % 13 >= 9 || player[0] % 13 >= 9 && player[1] % 13 == 0)
                    {
                        button1.Content = GenerateColor(dealer[0]);
                        textBox1.Text = "" + (N1 + N2);
                        MessageBox.Show("玩家blackjack，你贏了" + "N2" + "籌碼");
                        return;
                    }
                    start = true;
                    textBox2.IsReadOnly = true;
                    dc = 0;
                    pc = 0;
                    if (dealer[0] % 13 < 9) dn += dealer[0] % 13 + 1; else dn += 10;
                    if (dealer[1] % 13 < 9) dn += dealer[1] % 13 + 1; else dn += 10;
                    if (player[0] % 13 < 9) pn += player[0] % 13 + 1; else pn += 10;
                    if (player[1] % 13 < 9) pn += player[1] % 13 + 1; else pn += 10;
                    if (dealer[0] % 13==0) dc+=1;
                    if (dealer[1] % 13 == 0) dc += 1;
                    if (player[0] % 13 == 0) pc += 1;
                    if (player[1] % 13 == 0) pc += 1;


                    p = 2;d = 2;
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message,"錯誤訊息"); }
            ;
        }
    }
}
