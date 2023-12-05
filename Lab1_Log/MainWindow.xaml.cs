using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;
using Lab1_Log.src.HAL;

namespace Lab1_Log
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BotPacket my_bot = new BotPacket();

        public MainWindow()
        {
            // event 등록도 여기서...
            InitializeComponent();
            frame_uart.Source = new Uri("SerialPort_Setting.xaml", UriKind.Relative);
            SerialPort_Setting.PropertyChanged += eventClass_PropertyChanged;
        }

        private void eventClass_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            byte[] rec_bytes = e.PropertyName.Split('-').Select(x => Convert.ToByte(x, 16)).ToArray<byte>();
            string rec_hexstring = BitConverter.ToString(rec_bytes);
            btn_page5.Content = rec_hexstring;
        }

        #region 페이지이동 함수
        private void btn_page1_Click(object sender, RoutedEventArgs e)
        {
            frame_content.Source = new Uri("Page1.xaml", UriKind.Relative);
        }
        private void btn_page2_Click(object sender, RoutedEventArgs e)
        {
            frame_content.Source = new Uri("Page2.xaml", UriKind.Relative);
        }
        private void btn_page3_Click(object sender, RoutedEventArgs e)
        {
            frame_content.Source = new Uri("Page3.xaml", UriKind.Relative);
        }
        private void btn_page4_Click(object sender, RoutedEventArgs e)
        {
            frame_content.Source = new Uri("Page4.xaml", UriKind.Relative);
        }
        private void btn_page5_Click(object sender, RoutedEventArgs e)
        {
            //frame_content.Source = new Uri("SerialPort_Setting.xaml", UriKind.Relative);
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte[] packet = my_bot.SerializeExe(ExecutionCMD.InverterOn);
            SerialPort_Setting.SendBytes(packet);
        }

        private void Button_off_Click(object sender, RoutedEventArgs e)
        {
            string msg = "sample turn off message";
            SerialPort_Setting.SendString(msg);
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("C#테스트 프로그램 입니다.", "H/W 정보", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

    }   //end of class
}   // end of namespace