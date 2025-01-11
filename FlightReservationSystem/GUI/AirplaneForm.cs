using System;
using System.Data;
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
            try
            {
                // Fetch data from BLL, which calls DAL to get data from DB
                DataTable data = airplaneBLL.GetAllAirplanes();

                // Bind the data to DataGridView
                dataGridViewAirplanes.DataSource = data;

                // Add Action Buttons (Edit and Delete) after binding the data
                AddActionButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void AddActionButtons()
        {
            // Add Edit Button if not already added
            if (!dataGridViewAirplanes.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
                editButtonColumn.Name = "Edit";
                editButtonColumn.Text = "Edit";
                editButtonColumn.UseColumnTextForButtonValue = true;
                dataGridViewAirplanes.Columns.Add(editButtonColumn);
            }

            // Add Delete Button if not already added
            if (!dataGridViewAirplanes.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.Name = "Delete";
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                dataGridViewAirplanes.Columns.Add(deleteButtonColumn);
            }
        }


        // Handle DataGridView row selection for update or delete
        private void dataGridViewAirplanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is a button cell
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dataGridViewAirplanes.Columns[e.ColumnIndex].HeaderText;

                if (columnName == "Edit")
                {
                    // Handle Edit logic

                    // Retrieve row data
                    int AirplaneID = Convert.ToInt32(dataGridViewAirplanes.Rows[e.RowIndex].Cells["AirplaneID"].Value);
                    string Model = dataGridViewAirplanes.Rows[e.RowIndex].Cells["Model"].Value.ToString();
                    int Capacity = Convert.ToInt32(dataGridViewAirplanes.Rows[e.RowIndex].Cells["Capacity"].Value);
                    string Manufacturer = dataGridViewAirplanes.Rows[e.RowIndex].Cells["Manufacturer"].Value.ToString();

                    // Open the Update Form and pass the data
                    UpdateAirplane updateForm = new UpdateAirplane(AirplaneID, Model, Capacity, Manufacturer);
                    this.Close();
                    updateForm.ShowDialog();
                    // Refresh the DataGridView after updating (if needed)
                    LoadAirplanes();

                }
                else if (columnName == "Delete")
                {
                    // Handle Delete logic
                    int AirplaneID = (int)dataGridViewAirplanes.Rows[e.RowIndex].Cells["AirplaneID"].Value;

                    // Call the BLL method to delete the airplane
                    if (airplaneBLL.DeleteAirplane(AirplaneID))
                    {
                        MessageBox.Show("Airplane deleted successfully.");
                        LoadAirplanes(); // Refresh the DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete airplane.");
                    }
                }
            }
        }
        // Add Button
        private void button1_Click_1(object sender, EventArgs e)
        {
            AddAirplane airplane = new AddAirplane();
            airplane.Show();
            this.Close();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }


       
    }
}
