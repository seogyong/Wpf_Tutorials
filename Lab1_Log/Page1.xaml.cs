using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Diagnostics;

namespace WpfController
{
    /// <summary>
    /// MainPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page1 : Page
    {
        static int nCount = 0;

        public Page1()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();    //객체생성
            timer.Interval = TimeSpan.FromMilliseconds(0.01);    //시간간격 설정
            timer.Tick += new EventHandler(timer_Tick);          //이벤트 추가
            timer.Start();                                       //타이머 시작. 종료는 timer.Stop(); 으로 한다

            nCount++;
        }
        
        private void timer_Tick(object sender, EventArgs e)
        {
        //여기에 실행시킬 구문을 입력하면 된다

        }
    }
}
