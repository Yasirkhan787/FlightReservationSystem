using System;
using System.Windows.Forms;
using FlightReservationSystem.BLL;

namespace FlightReservationSystem.GUI
{
    public partial class UpdateAirplane : Form
    {
        private AirplaneBLL airplaneBLL;

        // Attributes
        private int AirplaneID;
        private string Model;
        private int Capacity;
        private string Manufacturer;

        public UpdateAirplane(int airplaneID, string model, int capacity, string manufacturer)
        {
            InitializeComponent();

            airplaneBLL = new AirplaneBLL();

            // Assign the parameters to class attributes
            this.AirplaneID = airplaneID;
            this.Model = model;
            this.Capacity = capacity;
            this.Manufacturer = manufacturer;

            // Populate the fields with existing data
            txtModel.Text = Model;
            txtCapacity.Text = Capacity.ToString();
            txtManufacturer.Text = Manufacturer;
        }

        // Update Airplane
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            // Retrieve updated values from text fields
            string updatedModel = txtModel.Text;
            int updatedCapacity;
            string updatedManufacturer = txtManufacturer.Text;

            // Validate input
            if (string.IsNullOrWhiteSpace(updatedModel) ||
                !int.TryParse(txtCapacity.Text, out updatedCapacity) ||
                updatedCapacity <= 0 ||
                string.IsNullOrWhiteSpace(updatedManufacturer))
            {
                MessageBox.Show("Please enter valid details for the airplane.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Call the BLL method to update the airplane
            if (airplaneBLL.UpdateAirplane(AirplaneID, updatedModel, updatedCapacity, updatedManufacturer))
            {
                MessageBox.Show("Airplane updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields(); // Clear the input fields

                // Redirect to AirplaneForm
                AirplaneForm airplaneForm = new AirplaneForm();
                airplaneForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update airplane.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtModel.Clear();
            txtCapacity.Clear();
            txtManufacturer.Clear();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            // Redirect To AirplaneForm
            AirplaneForm airplane = new AirplaneForm();
            airplane.Show();
            this.Hide();
        }

        private void UpdateAirplane_Load(object sender, EventArgs e)
        {

        }
    }
}
