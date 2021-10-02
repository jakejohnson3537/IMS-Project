using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Window
    {
        public Customers()
        {
            InitializeComponent();

            FillDataTable();
        }

        public void FillDataTable()
        {
            string ConString = @"Data Source=LAPTOP-K6388OC0\SQLEXPRESS; database=M3/LumberOne; Integrated Security=true;";

            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT  * FROM Customers;";


                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Customers");

                sda.Fill(dt);

                Cust_dg.ItemsSource = dt.DefaultView;




            }
        }
    }
}
