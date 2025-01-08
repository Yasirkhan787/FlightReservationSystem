using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace FlightReservationSystem.DAL
{
    public class AirplaneDAL
    {
        private string connectionString = "Server=localhost;Port=3306;Database=flight_reservation;User Id=root;Password=rootpassword;"; // Update with your connection string

        // Get All Airplanes
        public DataTable GetAllAirplanes()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM Airplane", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Add New Airplane
        public bool AddAirplane(string model, int capacity, string manufacturer)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Airplane (Model, Capacity, Manufacturer) VALUES (@Model, @Capacity, @Manufacturer)", conn);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@Capacity", capacity);
                cmd.Parameters.AddWithValue("@Manufacturer", manufacturer);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Update Airplane Details
        public bool UpdateAirplane(int airplaneId, string model, int capacity, string manufacturer)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE Airplane SET Model = @Model, Capacity = @Capacity, Manufacturer = @Manufacturer WHERE AirplaneID = @AirplaneID", conn);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@Capacity", capacity);
                cmd.Parameters.AddWithValue("@Manufacturer", manufacturer);
                cmd.Parameters.AddWithValue("@AirplaneID", airplaneId);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Delete Airplane
        public bool DeleteAirplane(int airplaneId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Airplane WHERE AirplaneID = @AirplaneID", conn);
                cmd.Parameters.AddWithValue("@AirplaneID", airplaneId);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}
