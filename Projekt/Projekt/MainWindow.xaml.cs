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
using System.Security.Cryptography;

namespace Projekt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int g = 3;
     
        public MainWindow()
        {
            
            InitializeComponent();

            
        }

        private void exet_Click(object sender, RoutedEventArgs e)
        {
            
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string login = login_TextBox.Text;
                string passwordFind = ConvertToHash(password_Password.Password);
                

                var user = Instances.db.users.FirstOrDefault(q => q.login.Contains(login) && q.password.Contains(passwordFind));
                if (user != null)
                {
                    MessageBox.Show("MOLODES");
                    sortirovka bmiWindow = new sortirovka(user);
                    this.Close();
                    bmiWindow.Show();
                }
                else
                {
                    if (g > 0)
                    {
                        MessageBox.Show("Осталось: " + g + " попытки");
                        g = g - 1;
                    }
                    else if (g <= 0)
                    {
                        Capsa capsa = new Capsa();
                        this.Close(); 
                        capsa.Show();

                    }

                }
                    
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private string ConvertToHash(string whoFind)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(whoFind);
                byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                string findOut = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                return findOut;
            }
            return "";
        }
    }
}
