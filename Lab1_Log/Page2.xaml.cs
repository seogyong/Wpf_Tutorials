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

namespace Lab1_Log
{
    /// <summary>
    /// Page2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            RichTextBox_state.Document.Blocks.Clear();
            RichTextBox_state.AppendText(">> Program Start\r");
        }


        private void Button_up_Click(object sender, RoutedEventArgs e)
        {
            double temp = Convert.ToInt64(TextBox_value.Text) + Convert.ToInt64(TextBox_step.Text);
            TextBox_value.Text = temp.ToString();
            RichTextBox_state.AppendText(">> Target value : " + temp.ToString() + '\r');

        }

        private void Button_down_Click(object sender, RoutedEventArgs e)
        {
            double temp = Convert.ToInt64(TextBox_value.Text) - Convert.ToInt64(TextBox_step.Text);
            TextBox_value.Text = temp.ToString();
            RichTextBox_state.AppendText(">> Target value : " + temp.ToString() + '\r');
        }

        private void TextBox_step_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var isNumber = (e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || (e.Key == Key.Back);

            if (!isNumber)
            {
                e.Handled = true;
            }
        }

        private void RichTextBox_state_TextChanged(object sender, TextChangedEventArgs e)
        {
            RichTextBox_state.ScrollToEnd();
        }
    }
}
