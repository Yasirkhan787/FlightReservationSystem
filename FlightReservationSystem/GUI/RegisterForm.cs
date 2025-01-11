using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightReservationSystem.BLL;
using FlightReservationSystem.DAL;

namespace FlightReservationSystem.GUI
{
    public partial class RegisterForm : Form
    {

        private UserBLL userBLL; // Business Logic Layer object

        public RegisterForm()
        {
            InitializeComponent();
            userBLL = new UserBLL();  // Initialize the BLL
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        // Register Button 
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string name = txtName.Text;
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem.ToString(); // Assuming Role is selected from a ComboBox

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            bool isRegistered = userBLL.RegisterUser(username, email, name, role, password);

            if (isRegistered)
            {
                MessageBox.Show("User registered successfully.");
                this.Close(); // Close the Register Form, or you can redirect to LoginForm
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
        }

        // Login Button
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            // Open Login Form
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            // Close the current form
            this.Close();
        }

        

        
    }
}
