using CollectionAgency.ADOApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

namespace CollectionAgency
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void btn_SignUp_Click(object sender, RoutedEventArgs e)
        {
            if (tb_FIO != null && tb_Login != null && tb_Password != null)
            {
                var login = DBConnection.connection.Collector.Where(x => x.Login == tb_Login.Text).FirstOrDefault();
                if (login == null)
                {
                    Collector collector = new Collector
                    {
                        FIO = tb_FIO.Text,
                        Login = tb_Login.Text,
                        Password = tb_Password.Password
                    };
                    DBConnection.connection.Collector.Add(collector);
                    DBConnection.connection.SaveChanges();
                    CollectorService.ReturnCollector(collector);
                    MessageBox.Show("Вы зарегистрированы!");
                    CollectorOffice win = new CollectorOffice();
                    win.Show();
                    this.Close();
                }
            }
        }
    }
}
