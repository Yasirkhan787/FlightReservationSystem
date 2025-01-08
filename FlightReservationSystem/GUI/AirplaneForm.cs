using System;
using System.Windows.Forms;
using FlightReservationSystem.BLL;

namespace FlightReservationSystem.GUI
{
    public partial class AirplaneForm : Form
    {
        private AirplaneBLL airplaneBLL = new AirplaneBLL();

        public AirplaneForm()
        {
            InitializeComponent();
        }

        // Load all airplanes on form load
        private void AirplaneForm_Load(object sender, EventArgs e)
        {
            LoadAirplanes();
        }

        // Method to load all airplanes into the DataGridView
        private void LoadAirplanes()
        {
            dataGridViewAirplanes.DataSource = airplaneBLL.GetAllAirplanes();
        }

        // Add new airplane
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            string model = txtModel.Text;
            int capacity = 0;
            string manufacturer = txtManufacturer.Text;

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
                LoadAirplanes(); // Refresh the DataGridView
                ClearFields(); // Clear the input fields
            }
            else
            {
                MessageBox.Show("Failed to add airplane.");
            }
        }

        // Update airplane details
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAirplaneID.Text))
            {
                MessageBox.Show("Please enter a valid Airplane ID.");
                return;
            }

            int airplaneId = int.Parse(txtAirplaneID.Text);
            string model = txtModel.Text;
            int capacity = 0;
            string manufacturer = txtManufacturer.Text;

            // Validate input
            if (string.IsNullOrWhiteSpace(model) || !int.TryParse(txtCapacity.Text, out capacity) || capacity <= 0 || string.IsNullOrWhiteSpace(manufacturer))
            {
                MessageBox.Show("Please enter valid details for the airplane.");
                return;
            }

            // Call the BLL method to update the airplane
            if (airplaneBLL.UpdateAirplane(airplaneId, model, capacity, manufacturer))
            {
                MessageBox.Show("Airplane updated successfully.");
                LoadAirplanes(); // Refresh the DataGridView
                ClearFields(); // Clear the input fields
            }
            else
            {
                MessageBox.Show("Failed to update airplane.");
            }
        }

        // Delete airplane
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAirplaneID.Text))
            {
                MessageBox.Show("Please enter a valid Airplane ID.");
                return;
            }

            int airplaneId = int.Parse(txtAirplaneID.Text);

            // Call the BLL method to delete the airplane
            if (airplaneBLL.DeleteAirplane(airplaneId))
            {
                MessageBox.Show("Airplane deleted successfully.");
                LoadAirplanes(); // Refresh the DataGridView
                ClearFields(); // Clear the input fields
            }
            else
            {
                MessageBox.Show("Failed to delete airplane.");
            }
        }

        // Handle DataGridView row selection for update or delete
        private void dataGridViewAirplanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check for valid row click
            if (e.RowIndex >= 0)
            {
                txtAirplaneID.Text = dataGridViewAirplanes.Rows[e.RowIndex].Cells["AirplaneID"].Value.ToString();
                txtModel.Text = dataGridViewAirplanes.Rows[e.RowIndex].Cells["Model"].Value.ToString();
                txtCapacity.Text = dataGridViewAirplanes.Rows[e.RowIndex].Cells["Capacity"].Value.ToString();
                txtManufacturer.Text = dataGridViewAirplanes.Rows[e.RowIndex].Cells["Manufacturer"].Value.ToString();
            }
        }

        // Clear input fields
        private void ClearFields()
        {
            txtAirplaneID.Clear();
            txtModel.Clear();
            txtCapacity.Clear();
            txtManufacturer.Clear();
        }

        // Optional: Cancel button functionality to clear fields
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

      
    }
}
