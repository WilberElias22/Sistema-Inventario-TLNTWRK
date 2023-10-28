using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MaterialSkin;
using MaterialSkin.Controls;
using Inventario_Tlntwrk;

namespace Inventario_Tlntwrk
{
    public partial class AgregarSalida : MaterialForm
    {
        private MySqlConnection connection;
        private ModoEdicion modoEdicion;
        private int idSalida;

        public AgregarSalida(MySqlConnection connection, ModoEdicion modoEdicion, int idSalida = 0)
        {
            InitializeComponent();
            this.connection = connection;
            this.modoEdicion = modoEdicion;
            this.idSalida = idSalida;
        }

        private void AgregarSalida_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Purple800, Primary.Purple800, Primary.Blue900, Accent.Green700, TextShade.WHITE);

            CargarComboBoxIDRouter();
            CargarComboBoxIDInstalacion();

            if (modoEdicion == ModoEdicion.Actualizar)
            {
                CargarDatosSalida();
            }
        }

        private void CargarComboBoxIDRouter()
        {
            try
            {
                string query = "SELECT ID_Router, Serial FROM Router";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                cmbIDRouter.DisplayMember = "Serial";
                cmbIDRouter.ValueMember = "ID_Router";
                cmbIDRouter.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de los routers: " + ex.Message);
            }
        }

        private void CargarComboBoxIDInstalacion()
        {
            try
            {
                string query = "SELECT ID_Instalacion, Proyecto FROM Instalacion";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                cmbIDInstalacion.DisplayMember = "Proyecto";
                cmbIDInstalacion.ValueMember = "ID_Instalacion";
                cmbIDInstalacion.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de las instalaciones: " + ex.Message);
            }
        }

        private void CargarDatosSalida()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                // Consulta SQL para obtener los datos de la salida
                string query = @"SELECT * FROM Salida WHERE ID_Salida = @ID_Salida";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_Salida", idSalida);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Asignar los valores a los controles
                        dtpFechaSalida.Value = Convert.ToDateTime(reader["Fecha_Salida"]);
                        txtUbicacion.Text = reader["Ubicacion"].ToString();
                        dtpFechaInstalacion.Value = Convert.ToDateTime(reader["Fecha_Instalacion"]);

                        // Seleccionar los elementos correspondientes en los ComboBox
                        cmbIDRouter.SelectedValue = Convert.ToInt32(reader["ID_Router"]);
                        cmbIDInstalacion.SelectedValue = Convert.ToInt32(reader["ID_Instalacion"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la salida: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = string.Empty;
                MySqlCommand command;

                if (modoEdicion == ModoEdicion.Insertar)
                {
                    // Insertar una nueva salida en la base de datos
                    query = @"INSERT INTO Salida (Fecha_Modificacion, Fecha_Salida, Ubicacion, Fecha_Instalacion, ID_Router, ID_Instalacion) 
                      VALUES (@FechaModificacion, @FechaSalida, @Ubicacion, @FechaInstalacion, @IDRouter, @IDInstalacion)";

                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FechaModificacion", DateTime.Now);
                }
                else if (modoEdicion == ModoEdicion.Actualizar)
                {
                    // Actualizar los datos de la salida en la base de datos
                    query = @"UPDATE Salida 
                      SET Fecha_Modificacion = @FechaModificacion, Fecha_Salida = @FechaSalida, Ubicacion = @Ubicacion, 
                          Fecha_Instalacion = @FechaInstalacion, ID_Router = @IDRouter, ID_Instalacion = @IDInstalacion
                      WHERE ID_Salida = @ID_Salida";

                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FechaModificacion", DateTime.Now);
                    command.Parameters.AddWithValue("@ID_Salida", idSalida);
                }
                else
                {
                    // Modo de edición inválido
                    MessageBox.Show("Modo de edición no válido.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Comunes a ambos modos de edición
                command.Parameters.AddWithValue("@FechaSalida", dtpFechaSalida.Value);
                command.Parameters.AddWithValue("@Ubicacion", txtUbicacion.Text);
                command.Parameters.AddWithValue("@FechaInstalacion", dtpFechaInstalacion.Value);
                command.Parameters.AddWithValue("@IDRouter", cmbIDRouter.SelectedValue);
                command.Parameters.AddWithValue("@IDInstalacion", cmbIDInstalacion.SelectedValue);

                command.ExecuteNonQuery();

                if (modoEdicion == ModoEdicion.Insertar)
                {
                    MessageBox.Show("Nueva salida registrada correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (modoEdicion == ModoEdicion.Actualizar)
                {
                    MessageBox.Show("Datos de la salida actualizados correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la salida: " + ex.Message, "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
