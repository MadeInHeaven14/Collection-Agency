using CollectionAgency.ADOApp;
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

namespace CollectionAgency
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_SignUp_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow win = new RegistrationWindow();
            win.Show();
            this.Close();
        }

        private void btn_SignIn_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Login != null && tb_Password != null)
            {
                var login = DBConnection.connection.Collector.Where(x => x.Login == tb_Login.Text).FirstOrDefault();
                if (login != null)
                {
                    if (login.Password == tb_Password.Password)
                    {
                        CollectorService.ReturnCollector(login);
                        CollectorOffice win = new CollectorOffice(); 
                        win.Show();
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Неверный логин или пароль!");
                    }
                }

                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
        }
    }
}
