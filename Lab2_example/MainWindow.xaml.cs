using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace Lab2_example
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
            CallConfig();
            timer.Tick += TimerFunction;
            timer.Interval = TimeSpan.FromMilliseconds(500);
        }

        private void CallConfig()
        {
            label_title.Content = Properties.Settings.Default.TITLE;
        }

        void TimerFunction(object sender, EventArgs e)
        {
            RichTextBox_state.AppendText("TimerFunction was called : " + i.ToString() + '\r');
            i++;
        }

        private void btn_timer_start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            RichTextBox_state.AppendText(">> Timer start" + '\r');
        }

        private void btn_timer_stop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            RichTextBox_state.AppendText(">> Timer stopped" + '\r');

            TextPointer contentStart = RichTextBox_state.Document.ContentStart;
            TextPointer contentEnd = RichTextBox_state.Document.ContentEnd;
        }

        private void RichTextBox_state_TextChanged(object sender, TextChangedEventArgs e)
        {
            RichTextBox_state.ScrollToEnd();
        }
    }
}
