using System;
using System.Data;
using FlightReservationSystem.DAL;

namespace FlightReservationSystem.BLL
{
    public class AirplaneBLL
    {
        private AirplaneDAL airplaneDAL = new AirplaneDAL();

        // Get All Airplanes
        public DataTable GetAllAirplanes()
        {
            return airplaneDAL.GetAllAirplanes();
        }

        // Add New Airplane
        public bool AddAirplane(string model, int capacity, string manufacturer)
        {
            return airplaneDAL.AddAirplane(model, capacity, manufacturer);
        }

        // Update Airplane Details
        public bool UpdateAirplane(int airplaneId, string model, int capacity, string manufacturer)
        {
            return airplaneDAL.UpdateAirplane(airplaneId, model, capacity, manufacturer);
        }

        // Delete Airplane
        public bool DeleteAirplane(int airplaneId)
        {
            return airplaneDAL.DeleteAirplane(airplaneId);
        }
    }
}
