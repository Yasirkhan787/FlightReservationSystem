using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightReservationSystem.DAL;

namespace FlightReservationSystem.BLL
{
    public class UserBLL
    {
        private UserDAL userDAL = new UserDAL();

        public bool RegisterUser(string username, string email, string name, string role, string password)
        {
            return userDAL.RegisterUser(username, email, name, role, password);
        }

        public bool ValidateUser(string username, string password)
        {
            return userDAL.ValidateUser(username, password);
        }
    }

}
