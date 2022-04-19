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
using System.Data.SqlClient;
using System.Data;

namespace examAVT
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection(@"Data source = DESKTOP-A87A485\SQLEXPRESS01; initial catalog = СалонКрасоты; integrated security = SSPI");
            con.Open();
            SqlCommand com = new SqlCommand("Select * from [Employee] Where Login = '" + txtLogin.Text + "' and Password = '" + txtPass.Password + "'", con);
            SqlDataReader r = com.ExecuteReader();
            string userlogin = "";
            string userpass = "";
            try
            {
                r.Read();
                userlogin = r["Login"].ToString();
                userpass = r["Password"].ToString();
            }
            catch { };
            if (txtLogin.Text == userlogin)
            {
                if(txtPass.Password == userpass)
                {
                    Orders order = new Orders();
                    order.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Неверный пароль!");
                }    
            }
            else
            {
                MessageBox.Show("Не удается найти пользователя!");
            }
        }
    }
}
