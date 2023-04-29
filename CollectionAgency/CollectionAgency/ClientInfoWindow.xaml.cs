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
    /// Логика взаимодействия для ClientInfoWindow.xaml
    /// </summary>
    public partial class ClientInfoWindow : Window
    {
        public ClientInfoWindow()
        {
            InitializeComponent();
            tb_FIO.Text = ClientService.FIO;
            tb_Address.Text = ClientService.Address;
            var clientData = DBConnection.connection.Client.Where(x => x.FIO == ClientService.FIO).FirstOrDefault();
            var debt_Client = DBConnection.connection.Debt_Client.Where(x => x.Client_ID == clientData.ID_Client).FirstOrDefault();
            var debtData = DBConnection.connection.Debt.Where(x => x.ID_Debt == debt_Client.Debt_ID).FirstOrDefault();
            tb_Sum.Text = debtData.Sum.ToString();
            tb_Percent.Text = debtData.Percent.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var clientData = DBConnection.connection.Client.Where(x => x.FIO == tb_FIO.Text).FirstOrDefault();
            var debt_client = DBConnection.connection.Debt_Client.Where(x => x.Client_ID == clientData.ID_Client).FirstOrDefault();
            var debtData = DBConnection.connection.Debt.Where(x => x.ID_Debt == debt_client.Debt_ID).FirstOrDefault();
            DBConnection.connection.Debt.Remove(debtData);
            DBConnection.connection.Debt_Client.Remove(debt_client);
            DBConnection.connection.Client.Remove(clientData);
            DBConnection.connection.SaveChanges();
            MessageBox.Show("Должник удален!");
            CollectorOffice win = new CollectorOffice();
            win.Show();
            this.Close();  
        }
    }
}
