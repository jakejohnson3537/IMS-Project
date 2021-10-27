using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for SalesReps.xaml
    /// shows data from sales rep table in database
    /// </summary>
    public partial class SalesReps : Window
    {
        public SalesReps()
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
                CmdString = "SELECT * FROM Sales_Rep";

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("SalesRep");

                sda.Fill(dt);

                salesRep_dg.ItemsSource = dt.DefaultView;




            }
        }
    }
}
