using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace InfraVision2
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void NewUserButton_Click(object sender, EventArgs e)
        {
            NewUserForm newUserForm = new NewUserForm();
            newUserForm.Show();
        }
        private void Forgot_PasswordButton_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassForm = new ForgotPassword();
            forgotPassForm.Show();
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UserNameTextBox.Text.Trim();
            string password = passwordTextBox1.Text;

            // Validate inputs
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password", "Login Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Authenticate user
            
                // Create dashboard
             DashBoard dashboard = new DashBoard();

                // Set username in dashboard (assuming you have a property for this)
                //dashboard.CurrentUsername = username;

                // Hide login form
             this.Hide();

                // Show dashboard as dialog (blocks until dashboard is closed)
             dashboard.ShowDialog();

                // After dashboard is closed, exit the application
             Application.Exit();
            
           
        }

        private string HashPassword(string password, string salt)
        {
            // Convert the salt from hex string to byte array
            byte[] saltBytes = HexStringToByteArray(salt);

            // Create a new instance of the hashing algorithm (SHA-256)
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert password to bytes
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Combine password and salt
                byte[] combinedBytes = new byte[passwordBytes.Length + saltBytes.Length];
                Buffer.BlockCopy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
                Buffer.BlockCopy(saltBytes, 0, combinedBytes, passwordBytes.Length, saltBytes.Length);

                // Compute the hash
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);

                // Convert the hash to a hex string
                return ByteArrayToHexString(hashBytes);
            }
        }

        private byte[] HexStringToByteArray(string hex)
        {
            // Remove any spaces
            hex = hex.Replace(" ", "");

            // Create byte array
            byte[] bytes = new byte[hex.Length / 2];

            // Convert hex to bytes
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return bytes;
        }

        private string ByteArrayToHexString(byte[] bytes)
        {
            // Convert byte array to hex string
            StringBuilder sb = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }

        private bool AuthenticateUser(string username, string password)
        {
            string connString = "User Id=deepam;Password=190244;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));"; ; // Replace with your DB connection string

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT passwordhash, salt FROM users WHERE username = @username";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // If user exists
                        {
                            string storedHash = reader["passwordhash"].ToString();
                            string storedSalt = reader["salt"].ToString();

                            // Hash the entered password with the stored salt
                            string hashedInputPassword = HashPassword(password, storedSalt);

                            // Compare the hashes
                            return hashedInputPassword.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
                        }
                    }
                }
            }
            return false; // User not found or password incorrect
        }

        private void passwordTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
