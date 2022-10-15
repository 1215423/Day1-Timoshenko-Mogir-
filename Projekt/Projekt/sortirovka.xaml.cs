using System;
using System.Collections.Generic;
using System.IO;
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
        user user;
        DateTime startSessionTime;
        DateTime endSessionTime;
        private int aic = 0;
        private int eic = 0;
        private int dic = 0;
        private int oic = 0;
        public user User { get => user; set => user = value; }

        public int AddedCount { get => aic; set => aic = value; }
        public int EditedCount { get => eic; set => eic = value; }
        
        public int DeletedCount { get => dic; set => dic = value; }
        public int OprationsCount { get => oic; set => oic = value; }



        public sortirovka(user newUser)
        {
            InitializeComponent();
            user = newUser;
            gg.ItemsSource = Instances.db.products_users_table.Where(q => q.fk_user_id == user.pk_user_id).Take(100).ToList();
            this.ComboBox.ItemsSource = Instances.db.categories.ToList();   

            startSessionTime = DateTime.Now;
            endSessionTime = DateTime.Now;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tovar bmiWindow = new Tovar();
            bmiWindow.Show();
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите это удалить ?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (gg.SelectedItems.Count != 0)
                {
                    var data = gg.SelectedItems.Cast<products_users_table>().ToList();

                    Instances.db.products_users_table.RemoveRange(data);
                    Instances.db.SaveChanges();

                    gg.ItemsSource = Instances.db.products_users_table.Where(q => q.fk_user_id == user.pk_user_id).Take(100).ToList();

                }
            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            listpay bmiWindow = new listpay();
            
            bmiWindow.Show();
            gg.ItemsSource = Instances.db.products_users_table.Take(500).ToList();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
                MainWindow mai = new MainWindow();
                mai.Show();

            using (StreamWriter streamWriter = new StreamWriter("W:/!Личная/fff/" + user.login + ".csv"))
            {
                streamWriter.WriteLine("start " + startSessionTime.ToString());
                streamWriter.WriteLine("end " + endSessionTime.ToString());
                streamWriter.WriteLine("add " + aic);
                streamWriter.WriteLine("restart add " + eic);
                streamWriter.WriteLine("delete " + dic);
                streamWriter.WriteLine("number of added " + oic);
            }
        }

           
        
    }
}
