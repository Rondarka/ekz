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
using System.Data.SqlClient;
using System.Data;

namespace examAVT
{
    /// <summary>
    /// Логика взаимодействия для ClientsOrders.xaml
    /// </summary>
    public partial class ClientsOrders : Window
    {
        SqlConnection con;
        public ClientsOrders()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data source = DESKTOP-A87A485\SQLEXPRESS01; initial catalog = СалонКрасоты; integrated security = SSPI");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT LastName+' '+ MiddleName+' '+FirstName,[Name], Price,[Date]" +
                " from [Order] Left join Client on Client.ID = [Order].ClientID " +
                "left join OrderService on OrderService.OrderID = [Order].ID " +
                "left join[Service] on[Service].ID = OrderService.ServiceID", con);
            DataTable table = new DataTable();
            SqlDataReader r = com.ExecuteReader();
            table.Load(r);
            dtClients.ItemsSource = table.DefaultView;
            con.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Orders newFonm = new Orders();
            newFonm.Show();
            this.Hide();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
