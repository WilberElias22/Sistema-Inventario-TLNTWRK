using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;

namespace Inventario_Tlntwrk
{
    public partial class Modelo : MaterialForm
    {
        private MySqlConnection connection;

        public Modelo(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreModelo = txtNombreModelo.Text;

                string query = "INSERT INTO Modelo (Nombre_Modelo) VALUES (@Nombre_Modelo)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre_Modelo", nombreModelo);

                connection.Open();
                command.ExecuteNonQuery();

                MessageBox.Show("Modelo agregado correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el modelo: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}