using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for Price.xaml
    /// shows Product table 
    /// filled with database vaules to show prices
    /// </summary>
    public partial class Price : Window
    {
        public Price()
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
                CmdString = "SELECT  od.OrderNum, p.SKU, p.Product_Name, p.Unit_Cost, od.Quantity, od.Total, od.[Weight] " +
                    "FROM Product p " +
                    "JOIN Order_Detail od on " +
                    "p.ProductID = od.ProductID;";


                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Price");

                sda.Fill(dt);

                Price_dg.ItemsSource = dt.DefaultView;




            }
        }
    }
}
