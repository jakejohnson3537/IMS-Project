using System;
using System.Collections.Generic;
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
using DevExpress.XtraPrinting;


namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for BarcodePage.xaml
    /// </summary>
    public partial class BarcodePage : Window
    {

        string ConString = @"Data Source=LAPTOP-K6388OC0\SQLEXPRESS; database=M3/LumberOne; Integrated Security=true;";
        public BarcodePage()
        {
            InitializeComponent();
            Fill_Product_ComboBox("");
        }

        public void Fill_Product_ComboBox(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE (Product_Name like @Search + '%')", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string product = rdr.GetString(1);

                    ProductLookUp.Items.Add(product);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed", ex.Message);
            }
        }

        public int RandomNum()
        {
            Random rand = new Random();
            int locNum = rand.Next(2, 104);
            return locNum;
        }

        private void ShowBarcode_Click(object sender, RoutedEventArgs e)
        {


            barcodeBorder.Visibility = Visibility.Visible;
            ProductBox.Text += ProductLookUp.Text.ToString();
            LocationBox.Text += (RandomNum() + "-P").ToString();
            DateBox.Text += DateTime.Today;
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(barcodeBorder, "User Control Printing.");
        }
    }
}
