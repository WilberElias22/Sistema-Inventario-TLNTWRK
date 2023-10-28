using System;
using System.Data;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;

namespace Inventario_Tlntwrk
{
    public partial class Proveedor : MaterialForm
    {
        private MySqlConnection connection;

        public Proveedor(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreProveedor = txtNombreProveedor.Text;

                string query = "INSERT INTO Proveedor (Nombre_Proveedor) VALUES (@Nombre_Proveedor)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre_Proveedor", nombreProveedor);

                connection.Open();
                command.ExecuteNonQuery();

                MessageBox.Show("Proveedor agregado correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el proveedor: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
