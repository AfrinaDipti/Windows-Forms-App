using System.Data.SqlClient;
using System.Xml.Linq;

namespace task2
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=LAPTOP-R55ABQP9\\SQLEXPRESS;Initial Catalog=Information;User ID=LAPTOP-R55ABQP9\\SQLEXPRESS\\User;Password=null;TrustServerCertificate=True; Integrated Security=True;Connect Timeout=30;MultiSubnetFailover=False";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textName.Text;
            string email = textEmail.Text;
            string phone_number = textPhoneNum.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO UserData (Name, Email, Phone_Number) VALUES (@Name, @Email, @Phone_Number)";
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone_Number", phone_number);

                    // Execute the command
                    command.ExecuteNonQuery();
                }
            }

            // Clear the textboxes after saving
            textName.Text = string.Empty;
            textEmail.Text = string.Empty;
            textPhoneNum.Text = string.Empty;

            // Show a message to indicate successful saving
            MessageBox.Show("Data saved successfully!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}