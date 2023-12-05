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

namespace Lab1_Log
{
    /// <summary>
    /// Page3.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page3 : Page
    {
        Person man_1 = new Person();

        public Page3()
        {
            InitializeComponent();
            man_1.Name = "seogyong";
            Label_from_variable.DataContext = man_1;
        }

        private void Button_start_Click(object sender, RoutedEventArgs e)
        {
            //Trace.WriteLine(string.Format("{0} 해당값이 전송되었습니다.", TextBox_value.Text));
            Trace.WriteLine(string.Format("{0} 해당값이 전송되었습니다.", man_1.Name));
            Debug.WriteLine(string.Format("{0} 해당값이 전송되었습니다.", man_1.Name));
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
