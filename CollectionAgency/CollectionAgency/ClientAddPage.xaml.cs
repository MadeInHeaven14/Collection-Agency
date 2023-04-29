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
    /// Логика взаимодействия для ClientAddPage.xaml
    /// </summary>
    public partial class ClientAddPage : Window
    {
        public ClientAddPage()
        {
            InitializeComponent();
        }

        private void btn_ClientAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tb_FIO != null && tb_Sum != null && tb_Percent != null && tb_Address != null)
            {
                var client = DBConnection.connection.Client.Where(x => x.FIO == tb_FIO.Text).FirstOrDefault(); 
                if (client == null)
                {
                    var collector1 = DBConnection.connection.Collector.Where(x => x.FIO == CollectorService.FIO).FirstOrDefault();
                    Client newClient = new Client()
                    {
                        FIO = tb_FIO.Text,
                        Address = tb_Address.Text,
                        Collector_ID = collector1.ID_Collector,
                    };
                    Debt newDebt = new Debt()
                    {
                        Sum = Convert.ToInt32(tb_Sum.Text),
                        Percent = Convert.ToInt32(tb_Percent.Text),
                    };
                    Debt_Client debt_Client = new Debt_Client()
                    {
                        Client_ID = newClient.ID_Client,
                        Debt_ID = newDebt.ID_Debt,
                        Debt_Finish_ID = 2,
                    };
                    DBConnection.connection.Client.Add(newClient);
                    DBConnection.connection.Debt.Add(newDebt);
                    DBConnection.connection.Debt_Client.Add(debt_Client);
                    DBConnection.connection.SaveChanges();
                    MessageBox.Show("Клиент добавлен!");
                    CollectorOffice win = new CollectorOffice();
                    win.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Такой клиент уже есть!");
                }
            }
        }
    }
}
