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
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Логика взаимодействия для Capsa.xaml
    /// </summary>
    public partial class Capsa : Window
    {
        public string CaptchaValue { get; set; }
        public event EventHandler CaptchaRefreshed;
        public string captcha = "";
        public Capsa()
        {
            InitializeComponent();
            CreateCaptcha();
        }
        public void CreateCaptcha()
        {
            string allowchar = string.Empty;
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
           // allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            string[] ar = allowchar.Split(a);
            string temp = string.Empty;
            string pwd = string.Empty;

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                temp = ar[(random.Next(0, ar.Length))];
                pwd += temp;
            }
            generateCaptchaTextBox.Text = pwd;
            captcha = pwd;
            CaptchaValue = generateCaptchaTextBox.Text;
            CaptchaRefreshed?.Invoke(this, EventArgs.Empty);
        }
        private void continueBtn_Click(object sender, RoutedEventArgs e)
        {
            string usertext = captchaTextBox.Text;
            if (captcha == usertext)
            {
                MainWindow loginWindow = new MainWindow();
                this.Close();
                loginWindow.Show();
            }
            else
                CreateCaptcha();
        }

        private void regenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateCaptcha();
        }
    }
}
