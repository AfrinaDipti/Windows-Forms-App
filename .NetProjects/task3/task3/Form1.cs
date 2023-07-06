using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace task3
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=LAPTOP-R55ABQP9\\SQLEXPRESS;Initial Catalog=UserInfo;User ID=LAPTOP-R55ABQP9\\SQLEXPRESS\\User;Password=null;TrustServerCertificate=True; Integrated Security=True;Connect Timeout=30;MultiSubnetFailover=False";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string name = textName.Text;
            string email = textEmail.Text;
            string phone_number = textPhoneNum.Text;

            // Validate the email format
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format. Please enter a valid email address.");
                return;
            }


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO task3 (Name, Email, Phone_Number) VALUES (@Name, @Email, @Phone_Number)";
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
        private bool IsValidEmail(string email)
        {
            // Email format validation regex pattern
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Perform the regex match
            return Regex.IsMatch(email, pattern);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchEmail = textSearchEmail.Text;

            // Create a SQL connection and command
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SQL command
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT COUNT(*) FROM task3 WHERE Email = @SearchEmail";
                    command.Parameters.AddWithValue("@SearchEmail", searchEmail);

                    int count = (int)command.ExecuteScalar();

                    // Check if the email exists or not
                    if (count > 0)
                    {
                        // Email exists
                        MessageBox.Show("Email exists in the database.");
                    }
                    else
                    {
                        // Email does not exist
                        MessageBox.Show("Email does not exist in the database.");
                    }
                }
            }
        }

    }
}