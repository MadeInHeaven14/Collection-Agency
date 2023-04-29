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
using System.Windows.Shapes;

namespace CollectionAgency
{
    /// <summary>
    /// Логика взаимодействия для CollectorOffice.xaml
    /// </summary>
    public partial class CollectorOffice : Window
    {
        public CollectorOffice()
        {
            InitializeComponent();
            lb_login.Content = CollectorService.FIO;
            ClientList.ItemsSource = DBConnection.connection.Client.ToList();
        }

        private void btn_ClientAdd_Click(object sender, RoutedEventArgs e)
        {
            ClientAddPage win = new ClientAddPage();
            win.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ClientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client client = (Client)ClientList.SelectedItem;
            var clientData = DBConnection.connection.Client.Where(x => x.FIO == client.FIO).FirstOrDefault();
            ClientService.ReturnClient(clientData);
            ClientInfoWindow win = new ClientInfoWindow();
            win.Show();
            this.Close();
        }
    }
}
