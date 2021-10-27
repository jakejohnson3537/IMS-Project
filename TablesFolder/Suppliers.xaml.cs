using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for Suppliers.xaml
    /// shows who the sales reps are and other info about them
    /// from database
    /// </summary>
    public partial class Suppliers : Window
    {
        public Suppliers()
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
                CmdString = "SELECT  * FROM Suppliers;";


                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Customers");

                sda.Fill(dt);

                Suppliers_dg.ItemsSource = dt.DefaultView;




            }
        }
    }
}
