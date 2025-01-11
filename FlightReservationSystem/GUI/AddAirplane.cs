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

namespace FlightReservationSystem.GUI
{
    public partial class AddAirplane : Form
    {

        private AirplaneBLL airplaneBLL;

        public AddAirplane()
        {
            InitializeComponent();
            airplaneBLL = new AirplaneBLL();
        }

        private void AddAirplane_Load(object sender, EventArgs e)
        {

        }

        // View All Airplanes 
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Redirect To AirplaneForm
            AirplaneForm airplane = new AirplaneForm();
            airplane.Show();
            this.Hide();
        }

        // Add Airplane
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            string model = txtModel.Text;
            int capacity = 0;
            string manufacturer = txtCapacity.Text;

            // Validate input
            if (string.IsNullOrWhiteSpace(model) || !int.TryParse(txtCapacity.Text, out capacity) || capacity <= 0 || string.IsNullOrWhiteSpace(manufacturer))
            {
                MessageBox.Show("Please enter valid details for the airplane.");
                return;
            }

            // Call the BLL method to add the airplane
            if (airplaneBLL.AddAirplane(model, capacity, manufacturer))
            {
                MessageBox.Show("Airplane added successfully.");

                // Redirect To AirplaneForm
                AirplaneForm airplane = new AirplaneForm();
                airplane.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed to add airplane.");
            }
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
