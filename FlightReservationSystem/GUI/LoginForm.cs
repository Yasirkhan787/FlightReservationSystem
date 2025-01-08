using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightReservationSystem.BLL;

namespace FlightReservationSystem.GUI
{
    public partial class LoginForm : Form
    {

        private UserBLL userBLL = new UserBLL();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            Console.WriteLine($"Username: {username}, Password: {password}"); // Debugging output

            if (userBLL.ValidateUser(username, password))
            {

                MessageBox.Show("Login Successful");
                // Redirect to next form (e.g., MainForm)
                AirplaneForm airplaneForm = new AirplaneForm(); 
                airplaneForm.Show();
                //MainForm mainForm = new MainForm();
                //mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid credentials, please try again.");
            }
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            // Open Register Form 
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();

        }

        
    }
}
