using System;
using MySql.Data.MySqlClient;

namespace FlightReservationSystem.DAL
{
    public class UserDAL
    {
        private string connectionString = "Server=localhost;Database=flight_reservation;User Id=root;Password=rootpassword;"; // Update with your connection string

        // Register User
        public bool RegisterUser(string username, string email, string name, string role, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO User (UserName, Email, Name, Role, Password) VALUES (@UserName, @Email, @Name, @Role, @Password)", conn);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Validate User
        public bool ValidateUser(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(1) FROM User WHERE UserName = @UserName AND Password = @Password", conn);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                var result = cmd.ExecuteScalar();
                Console.WriteLine($"SQL Result: {result}"); // Debugging output

                return Convert.ToInt32(result) > 0;
            }
        }
    }
}
