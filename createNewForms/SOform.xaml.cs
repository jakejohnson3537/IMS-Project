using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for SOform.xaml
    /// </summary>
    public partial class SOform : Window
    {
        //Sales Order Form
        public SOform()
        {
            InitializeComponent();

            Fill_CompanyComboBox("");
            Fill_CustNameComboBox("");
            Fill_AddressComboBox("");
            Fill_PhoneNumComboBox("");
            Fill_EmailComboBox("");
            DateTextBox();
            Fill_ShippingStreet("");
            Fill_ShippingCity("");
            Fill_ShippingState("");
            FillDataTable();

        }

        string ConString = @"Data Source=LAPTOP-K6388OC0\SQLEXPRESS; database=M3/LumberOne; Integrated Security=true;";

        //creating a dropdown for combobox with vaules from database
        public void Fill_CompanyComboBox(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE (Company_Name like @Search + '%')", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string companyName = rdr.GetString(3);
                    CompaniesTxt.Items.Add(companyName);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }

        public void Fill_CustNameComboBox(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE (First_Name like @Search + '%')", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string firstName = rdr.GetString(1);
                    string lastName = rdr.GetString(2);

                    CustNameTxt.Items.Add(firstName + " " + lastName);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }

        public void Fill_AddressComboBox(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE (Billing_Address like '%' + @Search + '%')", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string streetNum = rdr.GetString(4);
                    string city = rdr.GetString(5);
                    string state = rdr.GetString(6);
                    string zipcode = rdr.GetString(7);

                    CustAddressTxt.Items.Add(streetNum + " " + city + "," + state + " " + zipcode);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }

        public void Fill_PhoneNumComboBox(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE (Phone like '%' + @Search + '%')", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string phoneNum = rdr.GetString(8);

                    CustPhoneTxt.Items.Add(phoneNum);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }

        public void Fill_EmailComboBox(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE (Email_Address like @Search + '%')", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string email = rdr.GetString(9);

                    CustEmailTxt.Items.Add(email);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }



        public void Fill_ShippingStreet(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE (Delivery_Address like @Search + '%')", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string streetNum = rdr.GetString(14);


                    ShippingStreet.Items.Add(streetNum);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }

        public void Fill_ShippingCity(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE (Delivery_City like @Search + '%')", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string city = rdr.GetString(15);


                    ShippingCity.Items.Add(city);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }

        public void Fill_ShippingState(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE (Delivery_ZipCode like @Search + '%')", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string zip = rdr.GetString(16);


                    ShippingState.Items.Add("AR " + zip);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }
        //insert database table into wpf table
        public void FillDataTable()
        {


            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT TOP (3) p.SKU_id, p.SKU, Product_Name, s.CompanyName as [Supplier], s.Address, s.State, s.Phone, " +
                    "p.Unit_Cost, p.Available_Sizes, p.SupplierID FROM Product p " +
                    "JOIN Suppliers s " +
                    "ON p.SupplierID = s.SupplierID ORDER BY p.SKU_id desc";

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Customers");

                sda.Fill(dt);

                SO_DataTable.ItemsSource = dt.DefaultView;




            }
        }
        //code to implement datetime
        public void DateTextBox()
        {
            int incNum = 2;

            int numAdd = 100;
            int SKUnum = numAdd++ + 3000;
            int productnum = (numAdd++) + (incNum++);
            Date.AppendText(DateTime.Now.ToString());
            SalesNum.AppendText(productnum.ToString());
            CustNum.AppendText(SKUnum.ToString());

        }
        //used to save Sales order to Database
        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int repNum = rnd.Next(1, 6);



            int newNum = 100;
            //SqlConnection con = new SqlConnection(ConString);

            try
            {



                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT into Customers VALUES (CustomerID, First_Name, Last_Name, Company_Name, Billing_Address, Billing_City, Billing_State, Billing_ZipCode, Phone, Email_Address, Delivery_Address, Delivery_City, Delivery_ZipCode, Date_Recorded, Sales_RepID)", con);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO Customers VALUES ('" + newNum++ + "', '" + this.CompaniesTxt.Text + "', '" + this.CustNameTxt.Text + "', '" + this.CustAddressTxt.Text + "', '" + this.CustPhoneTxt.Text + "', '" + this.CustEmailTxt.Text + "', '" + this.ShippingStreet.Text + "', '" + this.ShippingCity.Text + "', '" + this.ShippingState.Text + "', '" + repNum + "')", con);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = newNum;
                    cmd.Parameters.AddWithValue("@First_Name" + "@Last_Name", SqlDbType.VarChar).Value = CustNameTxt.Text;
                    cmd.Parameters.AddWithValue("@Company_Name", SqlDbType.VarChar).Value = CompaniesTxt.Text;
                    cmd.Parameters.AddWithValue("@Billing_Address" + "@Billing_City" + "@Billing_State" + "@Billing_ZipCode", SqlDbType.VarChar).Value = CustAddressTxt.Text;
                    cmd.Parameters.AddWithValue("@Phone", SqlDbType.VarChar).Value = CustPhoneTxt.Text;
                    cmd.Parameters.AddWithValue("@Email_Address", SqlDbType.VarChar).Value = CustEmailTxt.Text;
                    cmd.Parameters.AddWithValue("@Delivery_Address", SqlDbType.VarChar).Value = ShippingStreet.Text;
                    cmd.Parameters.AddWithValue("@Delivery_City", SqlDbType.VarChar).Value = ShippingCity.Text;
                    cmd.Parameters.AddWithValue("@Delivery_State", SqlDbType.VarChar).Value = ShippingState.Text;
                    cmd.Parameters.AddWithValue("@Date_Recorded", SqlDbType.Date).Value = Date.Text;
                    cmd.Parameters.AddWithValue("@Sales_RepID", SqlDbType.Int).Value = repNum;


                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sales Order Created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
