using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

namespace Lab1_Log
{
    /// <summary>
    /// SerialPort_Setting.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SerialPort_Setting : Page
    {
        public static SerialPort my_serial = new SerialPort();

        public SerialPort_Setting()
        {
            InitializeComponent();
        }

        private void ComboBox_port_DropDownOpened(object sender, EventArgs e)
        {
            ComboBox_port.Items.Clear();
            foreach (string each_port in SerialPort.GetPortNames())
            {
                ComboBox_port.Items.Add(each_port);
            }
        }

        private void Button_connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region 시리얼포트설정코드
                if (!my_serial.IsOpen)
                {
                    my_serial.PortName = ComboBox_port.Text;
                    my_serial.BaudRate = Convert.ToInt32(ComboBox_baudrate.Text);
                    my_serial.DataBits = Convert.ToInt16(ComboBox_databits.Text);
                    my_serial.Parity = (Parity)Enum.Parse(typeof(Parity), ComboBox_parity.Text);
                    my_serial.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ComboBox_stopbits.Text);
                    my_serial.Handshake = (Handshake)Enum.Parse(typeof(Handshake), ComboBox_flowcontrol.Text);
                    my_serial.DataReceived += DataReceivedHandler;
                    my_serial.NewLine = "\r\n";

                    my_serial.Open();
                    Trace.WriteLine(my_serial.PortName + '-' + my_serial.BaudRate + '-' + my_serial.DataBits + '-' + my_serial.Parity + '-' + my_serial.StopBits + '-' + my_serial.Handshake + '\r');
                    GroupBox_settings.IsEnabled = false;
                    Button_connect.Content = "Disconnected";

                }
                #endregion
                else
                {
                    my_serial.Close();
                    GroupBox_settings.IsEnabled = true;
                    Button_connect.Content = "Connect";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Serial Port Exception: " + ex.Message, "Error");
            }
        }

        #region 송/수신 구문
        public static void SendBytes(byte[] packet)
        {
            try
            {
                if (my_serial.IsOpen)
                {
                    my_serial.Write(packet, 0, packet.Length);
                    Debug.Write(">> >> [Tx] Bytes [0x] : ");
                    Debug.WriteLine(BitConverter.ToString(packet));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Serial Port Exception: " + ex.Message, "Error");
            }
        }
        public static void SendString(string msg)
        {
            try
            {
                if (my_serial.IsOpen)
                {
                    my_serial.Write(msg);
                    Debug.Write(">> [Tx] String : ");
                    Debug.WriteLine(msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Serial Port Exception: " + ex.Message, "Error");
            }
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
            {
                // 여기에 코드 입력
                Delay_ms(20);
                SerialPort sp = (SerialPort)sender;
                int RecvSize = sp.BytesToRead;
                if (RecvSize != 0)
                {
                    byte[] buff = new byte[RecvSize];
                    sp.Read(buff, 0, RecvSize);

                    string sASCII = Encoding.Default.GetString(buff);
                    string sHex = BitConverter.ToString(buff);
                    Debug.WriteLine(sHex);
                    ByteBuff = sHex;
                }
            }));
        }
        #endregion

        public static DateTime Delay_ms(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }

        #region 수신data변경시 이벤트 발생시키는 구문
        public static event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(null, new PropertyChangedEventArgs(info));
            }
        }
        private string byteBuff;
        public string ByteBuff
        {
            get { return byteBuff; }
            set
            {
                byteBuff = value;
                NotifyPropertyChanged(ByteBuff);
            }
        }
        #endregion

    }  //end of class
}
