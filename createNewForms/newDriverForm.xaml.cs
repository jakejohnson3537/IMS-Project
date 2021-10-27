using System;
using System.Data.SqlClient;
using System.Windows;
using Syncfusion.UI.Xaml.Scheduler;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for newDriverForm.xaml
    /// </summary>
    public partial class newDriverForm : Window
    {
        public newDriverForm()
        {
            InitializeComponent();
            Fill_NameComboBox("");
            Fill_LocationComboBox("");
            Fill_TruckNumComboBox("");
        }
        //connection string 
        string ConString = @"Data Source=LAPTOP-K6388OC0\SQLEXPRESS; database=M3/LumberOne; Integrated Security=true;";


        public void Fill_NameComboBox(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Company_Drivers WHERE (DriverName like @Search + '%')", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string companyName = rdr.GetString(1);
                    driversName.Items.Add(companyName);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }

        public void Fill_LocationComboBox(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Company_Drivers WHERE (Driver_BaseLoc like @Search + '%')", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.VarChar);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string location = rdr.GetString(2);
                    locationTxt.Items.Add(location);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }

        public void Fill_TruckNumComboBox(string search)
        {
            SqlConnection con = new SqlConnection(ConString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Company_Drivers WHERE (Truck_Number like @Search + '%')", con);
                cmd.Parameters.Add("@Search", System.Data.SqlDbType.Int);

                cmd.Parameters["@Search"].Value = search ?? "";

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string truckNum = rdr.GetString(3);
                    truckNumTxt.Items.Add(truckNum);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addDriver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            // Creating an instance for schedule appointment collection
            var scheduleAppointmentCollection = new ScheduleAppointmentCollection();
            //Adding schedule appointment in the schedule appointment collection 
            scheduleAppointmentCollection.Add(new ScheduleAppointment()
            {
                StartTime = DateTime.Today,
                EndTime = DateTime.Today.AddDays(1),
                Subject = driversName.Text,
                Location = locationTxt.Text,
            }) ;

            //Adding schedule appointment collection to the ItemSource of SfScheduler
            mainWindow.Scheduler.ItemsSource = scheduleAppointmentCollection;
        }
    }
}
