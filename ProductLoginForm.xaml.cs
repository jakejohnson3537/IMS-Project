using System;
using System.Collections.Generic;
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
using System.Data;
using System.Data.SqlClient;

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



                    CB_email.Items.Add(city);
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Sales_Rep where email='" + this.CB_email.Text + "' and Password='" + this.Txt_password.Text + "' ", con);

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
