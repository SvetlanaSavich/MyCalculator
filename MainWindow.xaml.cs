// Decompiled with JetBrains decompiler
// Type: MyCalculatorv1.MainWindow
// Assembly: MyCalculatorv1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8E4247A5-25E4-47A6-84F4-A414933F7536
// Assembly location: C:\.NET\ProfilingTools\DumpHomework\MyCalculator.exe

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace MyCalculatorv1
{
    public partial class MainWindow : Window, IComponentConnector
    {
        private static char[] operations = new[] { '+', '-', '/', '*' };
        public MainWindow() => this.InitializeComponent();

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if(tb.Text.Contains("="))
            {
                tb.Text = "";
            }

            if(tb.Text.IndexOfAny(operations) > -1 && operations.Any(o => o == button.Content.ToString().First()) || (tb.Text.Length == 0 && operations.Any( o=> o == button.Content.ToString().First())))
            {
                return;
            }

            this.tb.Text += button.Content.ToString();
        }

        private void Result_click(object sender, RoutedEventArgs e) => this.Result();

        private void Disable_Keyboard(object sender, RoutedEventArgs e) => e.Handled = true;

        private void Result()
        {
            if (this.tb.Text.IndexOf("=") > -1 || operations.Any(o=>o == tb.Text.Last()) || this.tb.Text.IndexOfAny(operations) < 0)
            {
                return;
            }

            int num1 = tb.Text.IndexOfAny(operations);

            string str = this.tb.Text.Substring(num1, 1);
            double num2 = Convert.ToDouble(this.tb.Text.Substring(0, num1));
            double num3 = Convert.ToDouble(this.tb.Text.Substring(num1 + 1, this.tb.Text.Length - num1 - 1));
            if (str == "+")
            {
                TextBox tb = this.tb;
                tb.Text = tb.Text + "=" + (object)(num2 + num3);
            }
            else if (str == "-")
            {
                TextBox tb = this.tb;
                tb.Text = tb.Text + "=" + (object)(num2 - num3);
            }
            else if (str == "*")
            {
                TextBox tb = this.tb;
                tb.Text = tb.Text + "=" + (object)(num2 * num3);
            }
            else
            {
                TextBox tb = this.tb;
                tb.Text = tb.Text + "=" + (object)(num2 / num3);
            }
        }

        private void Off_Click_1(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void Del_Click(object sender, RoutedEventArgs e) => this.tb.Text = "";

        private void R_Click(object sender, RoutedEventArgs e)
        {
            if (this.tb.Text.Length <= 0)
                return;
            this.tb.Text = this.tb.Text.Substring(0, this.tb.Text.Length - 1);
        }
    }
}
