using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;

namespace Inventario_Tlntwrk
{
    public partial class Marca : MaterialForm
    {
        private MySqlConnection connection;

        public Marca(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreMarca = txtNombreMarca.Text;

                string query = "INSERT INTO Marca (Nombre_Marca) VALUES (@Nombre_Marca)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre_Marca", nombreMarca);

                connection.Open();
                command.ExecuteNonQuery();

                MessageBox.Show("Marca agregada correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la marca: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
