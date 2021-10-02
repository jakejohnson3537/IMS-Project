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
    /// Interaction logic for SalesOrder.xaml
    /// </summary>
    public partial class SalesOrder : Window
    {
        public SalesOrder()
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
                CmdString = "SELECT ofm.OrderNum, ofm.[Status], ofm.OrderDate, p.Product_Name, od.Quantity, od.Discount, ofm.Total_Cost, ofm.Sales_Tax, ofm.Is_Paid, ofm.Date_Paid, " +
                    "c.First_Name as 'Customer fName', c.Last_Name as 'Customer lName', " +
                    "c.Company_Name, c.Phone, c.Email_Address, sr.First_Name as 'SalesRep fName', sr.Last_Name as 'SalesRep lName', sr.Phone, od.ShipDate " +
                    "FROM Order_Form ofm JOIN Order_Detail od " +
                    "ON ofm.OrderID = od.OrderID JOIN Product p " +
                    "ON od.ProductID = p.ProductID Join Customers c " +
                    "ON ofm.CustomerID = c.CustomerID JOIN Sales_Rep sr " +
                    "ON ofm.SalesID = sr.Sales_RepID; ";

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Order_Detail");

                sda.Fill(dt);

                salesOrder_dg.ItemsSource = dt.DefaultView;




            }
        }
    }
}
