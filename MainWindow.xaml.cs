using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System;
using System.ComponentModel;
using Chilkat;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Navigation;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            FillDataTable();

           
        }

        private void FillDataTable()
        {
            string ConString = @"Data Source=LAPTOP-K6388OC0\SQLEXPRESS; database=M3/LumberOne; Integrated Security=true;";

            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT ofm.OrderNum, ofm.[Status], ofm.OrderDate, p.SKU, p.Product_Name, od.Quantity, od.Discount, ofm.Total_Cost, ofm.Sales_Tax, p.Units_InStock, p.Units_OnOrder, ofm.Is_Paid, ofm.Date_Paid, " +
                    "c.First_Name as 'Customer fName', c.Last_Name as 'Customer lName', " +
                    "c.Company_Name, c.Phone, c.Email_Address, sr.First_Name as 'SalesRep fName', sr.Last_Name as 'SalesRep lName', sr.email, sr.Phone, sr.Home_Branch, sr.Commission_Amount,  od.ShipDate " +
                    "FROM Order_Form ofm JOIN Order_Detail od " +
                    "ON ofm.OrderID = od.OrderID JOIN Product p " +
                    "ON od.ProductID = p.ProductID Join Customers c " +
                    "ON ofm.CustomerID = c.CustomerID JOIN Sales_Rep sr " +
                    "ON ofm.SalesID = sr.Sales_RepID; ";

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Order_Form");

                sda.Fill(dt);

                DB_Table.ItemsSource = dt.DefaultView;


                

            }
        }

        private void SalesOrders_Btn_Click(object sender, RoutedEventArgs e)
        {
            SalesOrder sales = new SalesOrder();
            sales.Show();
        }

        private void Product_Btn_Click(object sender, RoutedEventArgs e)
        {
            Products products = new Products();
            products.Show();
        }

        private void PurchaseOrders_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Messages_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Drivers_Btn_Click(object sender, RoutedEventArgs e)
        {
            Drivers drivers = new Drivers();
            drivers.Show();
        }

        private void Sales_Rep_Btn_Click(object sender, RoutedEventArgs e)
        {
            SalesReps reps = new SalesReps();
            reps.Show();
        }

        private void Price_Btn_Click(object sender, RoutedEventArgs e)
        {
            Price price = new Price();
            price.Show();
        }

        private void Customers_Btn_Click(object sender, RoutedEventArgs e)
        {
            Customers customers = new Customers();
            customers.Show();
        }

        private void Suppliers_Btn_Click(object sender, RoutedEventArgs e)
        {
            Suppliers suppliers = new Suppliers();
            suppliers.Show();
        }

        

        private void YTDgraph_Click(object sender, RoutedEventArgs e)
        {
            YTDsales graph = new YTDsales();
            graph.Show();
        }

        //TopMost AdvMenu Tabs
        private void Menu_oTbl_Click(object sender, RoutedEventArgs e)
        {
            SalesOrder order = new SalesOrder();
            order.Show();
        }

        private void Menu_srTbl_Click(object sender, RoutedEventArgs e)
        {
            SalesReps reps = new SalesReps();
            reps.Show();
        }

        private void Menu_pTbl_Click(object sender, RoutedEventArgs e)
        {
            Products products = new Products();
            products.Show();
        }

        private void chromeTheme_themes_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void darkTheme_themes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lightTheme_themes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void edit_undo_Click(object sender, RoutedEventArgs e)
        {
            edit_undo.Command = ApplicationCommands.Undo;
            edit_undo.Command.CanExecute(sender);
        }

        private void edit_redo_Click(object sender, RoutedEventArgs e)
        {
            edit_redo.Command = ApplicationCommands.Redo;
        }

        private void edit_delete_Click(object sender, RoutedEventArgs e)
        {
            edit_delete.Command = ApplicationCommands.Delete;
        }

        private void newProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void newOrderForm_Click(object sender, RoutedEventArgs e)
        {

        }

        private void newSuppliers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void openMail_tab_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void sentMail_tab_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductLoginForm productLogin = new ProductLoginForm();
            productLogin.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
