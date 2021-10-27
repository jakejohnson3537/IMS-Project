using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// shows Customers table 
    /// filled with database vaules
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
