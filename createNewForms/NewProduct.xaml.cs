using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        public NewProduct()
        {

            InitializeComponent();

            Fill_UnitCost_ComboBox("");
            DateTextBox();
            Fill_Sizes_ComboBox("");
            Fill_Suppliers_ComboBox("");
            Fill_Address_ComboBox("");
            Fill_City_ComboBox("");
            Fill_ZipCode_ComboBox("");
            FillDataTable();
        }

        string ConString = @"Data Source=LAPTOP-K6388OC0\SQLEXPRESS; database=M3/LumberOne; Integrated Security=true;";


        public void Fill_UnitCost_ComboBox(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE (Unit_Cost like @Search + '%')", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string Cost = rdr.GetString(7);

                    UnitCost.Items.Add(Cost);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }

        public void DateTextBox()
        {
            int incNum = 2;

            int numAdd = 100;
            int SKUnum = numAdd++ + 3000;
            int productnum = (numAdd++) + (incNum++);
            Date.AppendText(DateTime.Now.ToString());
            Product_Num.AppendText(productnum.ToString());
            SKU_Num.AppendText(SKUnum + "M3MILL");

        }

        public void Fill_Sizes_ComboBox(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE (Available_Sizes like @Search + '%')", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string Cost = rdr.GetString(8);

                    SizeTxt.Items.Add(Cost);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }

        public void Fill_Suppliers_ComboBox(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Suppliers WHERE (CompanyName like @Search + '%')", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string Cost = rdr.GetString(1);

                    CompanyName.Items.Add(Cost);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }

        public void Fill_Address_ComboBox(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Suppliers WHERE (Address like @Search + '%')", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string Cost = rdr.GetString(5);

                    SupplierAddress.Items.Add(Cost);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }

        public void Fill_City_ComboBox(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Suppliers WHERE (City like @Search + '%')", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string Cost = rdr.GetString(6);

                    SupplierCity.Items.Add(Cost);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }

        public void Fill_ZipCode_ComboBox(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Suppliers WHERE (Postal_Code like @Search + '%')", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string Cost = rdr.GetString(8);

                    SupplierZip.Items.Add(Cost);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }

        public void FillDataTable()
        {


            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT TOP (3) p.SKU_id, p.SKU, Product_Name, s.CompanyName as [Supplier], s.Address, " +
                    "p.Unit_Cost, p.Available_Sizes, p.SupplierID FROM Product p " +
                    "JOIN Suppliers s " +
                    "ON p.SupplierID = s.SupplierID ORDER BY p.SKU_id desc";

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Customers");

                sda.Fill(dt);

                NewProductDG.ItemsSource = dt.DefaultView;




            }
        }

        private void Update_Btn_Click(object sender, RoutedEventArgs e)
        {
            int repNum = 10 + 1;


            int newNum = 100;


            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT TOP (10) p.SKU_id, p.SKU, Product_Name, s.CompanyName as [Supplier], s.Address, " +
                    "p.Unit_Cost, p.Available_Sizes, p.SupplierID FROM Product p " +
                    "JOIN Suppliers s " +
                    "ON p.SupplierID = s.SupplierID ORDER BY p.SKU_id desc";

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Customers");

                sda.Fill(dt);

                NewProductDG.ItemsSource = dt.DefaultView;

                try
                {
                    //con.Open();
                    //SqlCommand cmd = new SqlCommand("INSERT INTO Product (ProductID, Product_Name, Unit_Cost, Available_Sizes, SKU_id, SKU, SupplierID) " +
                    //    "VALUES ('" + newNum++ + "', '" + this.ProductTxt.Text + "', '" + this.UnitCost.Text + "', '" + this.SizeTxt.Text + "', '" + Product_Num.Text + "', '"+ SKU_Num.Text + "', '"+ repNum +"')", con);
                    //cmd.ExecuteNonQuery();

                    //cmd = new SqlCommand("INSERT INTO Suppliers (SupplierID, CompanyName, Address, , City, Postal_Code, CustomerID) " +
                    //    "VALUES ('" + newNum++ + "', '" + this.CompanyName.Text + "', '" + this.SupplierAddress.Text + "', '" + this.SupplierCity.Text + "', '" + SupplierZip.Text + "', '" + repNum + "')", con);
                    //cmd.ExecuteNonQuery();

                    //MessageBox.Show("Sales Order Created");

                    //string CmdString = string.Empty;

                    //using (con = new SqlConnection(ConString))
                    //{
                    //    CmdString = "SELECT TOP (10) p.SKU_id, p.SKU, Product_Name, s.CompanyName as [Supplier], s.Address, " +
                    //        "p.Unit_Cost, p.Available_Sizes, p.SupplierID FROM Product p " +
                    //        "JOIN Suppliers s " +
                    //        "ON p.SupplierID = s.SupplierID ORDER BY p.SKU_id desc";

                    //    cmd = new SqlCommand(CmdString, con);

                    //    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    //    DataTable dt = new DataTable("Customers");

                    //    sda.Fill(dt);

                    //    NewProductDG.ItemsSource = dt.DefaultView;




                    //}

                }
                catch (Exception ex)
                {
                    MessageBox.Show("failed");
                }
            }
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            int repNum = 10 + 1;


            int newNum = 100;

            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Product (ProductID, Product_Name, Unit_Cost, Available_Sizes, SKU_id, SKU, SupplierID) " +
                        "VALUES ('" + newNum++ + "', '" + this.ProductTxt.Text + "', '" + this.UnitCost.Text + "', '" + this.SizeTxt.Text + "', '" + Product_Num.Text + "', '" + SKU_Num.Text + "', '" + repNum + "')", con);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("INSERT INTO Suppliers (SupplierID, CompanyName, Address, , City, Postal_Code, CustomerID) " +
                        "VALUES ('" + newNum++ + "', '" + this.CompanyName.Text + "', '" + this.SupplierAddress.Text + "', '" + this.SupplierCity.Text + "', '" + SupplierZip.Text + "', '" + repNum + "')", con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sales Order Created");

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }
    }
}
