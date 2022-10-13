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
    /// Логика взаимодействия для sortirovka.xaml
    /// </summary>
    public partial class sortirovka : Window
    {
        public sortirovka()
        {
            InitializeComponent();

            gg.ItemsSource = Instances.db.products_users_table.Take(50000).ToList();
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tovar bmiWindow = new Tovar();
            
            bmiWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            deleted bmiWindow = new deleted();
            
            bmiWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            listpay bmiWindow = new listpay();
            
            bmiWindow.Show();
        }
    }
}
