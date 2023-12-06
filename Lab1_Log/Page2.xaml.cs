using System;
using System.Collections.Generic;
using System.Drawing;
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
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;

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
            string temp_s = temp.ToString();
            TextBox_value.Text = temp_s;

            RichTextBox_state.AppendText(">> Target value : " + temp_s, Brushes.White);
        }

        private void Button_down_Click(object sender, RoutedEventArgs e)
        {
            double temp = Convert.ToInt64(TextBox_value.Text) - Convert.ToInt64(TextBox_step.Text);
            string temp_s = temp.ToString();
            TextBox_value.Text = temp_s;

            RichTextBox_state.AppendText(">> Target value : " + temp_s, Brushes.YellowGreen);
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

        private void MenuItem__Clear_Click(object sender, RoutedEventArgs e)
        {
            RichTextBox_state.Document.Blocks.Clear();
        }

    } //end of main class



    // Extendion Method방법
    public static class RichTextBoxExtension
    {
        public static void AppendText(this RichTextBox rtb, string text, SolidColorBrush new_brush)
        {
            SolidColorBrush previous_brush = (SolidColorBrush)rtb.Foreground;

            TextRange range = new TextRange(rtb.Document.ContentEnd, rtb.Document.ContentEnd);
            range.Text = text;
            range.ApplyPropertyValue(TextElement.ForegroundProperty, new_brush);

            TextRange range_end = new TextRange(rtb.Document.ContentEnd, rtb.Document.ContentEnd);
            range_end.Text = "\r";
            range_end.ApplyPropertyValue(TextElement.ForegroundProperty, previous_brush);
        }
    }   
}
