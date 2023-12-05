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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab1_Log
{
    /// <summary>
    /// Page4.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (radiobtn1_a.IsChecked == true) System.Windows.MessageBox.Show(radiobtn1_a.Content.ToString());
            else if (radiobtn1_b.IsChecked == true) System.Windows.MessageBox.Show(radiobtn1_b.Content.ToString());
            else if (radiobtn1_c.IsChecked == true) System.Windows.MessageBox.Show(radiobtn1_c.Content.ToString());
            else if (radiobtn1_d.IsChecked == true) System.Windows.MessageBox.Show(radiobtn1_d.Content.ToString());

            if (radiobtn2_a.IsChecked == true) System.Windows.MessageBox.Show(radiobtn2_a.Content.ToString());
            else if (radiobtn2_b.IsChecked == true) System.Windows.MessageBox.Show(radiobtn2_b.Content.ToString());
            else if (radiobtn2_c.IsChecked == true) System.Windows.MessageBox.Show(radiobtn2_c.Content.ToString());
        }
    }
}
