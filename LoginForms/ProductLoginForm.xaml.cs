using System;
using System.Data.SqlClient;
using System.Windows;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for ProductLoginForm.xaml
    /// </summary>
    public partial class ProductLoginForm : Window
    {
        string ConString = @"Data Source=LAPTOP-K6388OC0\SQLEXPRESS; database=M3/LumberOne; Integrated Security=true;";

        public ProductLoginForm()
        {
            InitializeComponent();
            Fill_EmailBox("");
        }

        public void Fill_EmailBox(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Sales_Rep WHERE (email like '%' + @Search + '%')", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string city = rdr.GetString(3);



                    CB_emailbox.Items.Add(city);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed", ex.Message);
            }
        }

        private void loginBTN_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Sales_Rep where email='" + this.CB_emailbox.Text + "' and Password='" + this.Txt_password.Password + "' ", con);

                cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();

                int count = 0;
                while (rdr.Read())
                {
                    count++;
                }
                if (count == 1)
                {

                    NewProduct newProduct = new NewProduct();
                    newProduct.Show();
                    this.Close();
                }

                if (count < 1)
                {
                    MessageBox.Show("email and password is not correct");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error", ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
