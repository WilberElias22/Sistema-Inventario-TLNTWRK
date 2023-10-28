using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;

namespace Inventario_Tlntwrk
{
    public partial class Salida : MaterialForm
    {
        private MySqlConnection connection;

        public Salida(MySqlConnection connection)
        {
            InitializeComponent();
            InitializeMaterialSkin();

            this.connection = connection;
        }

        private void InitializeMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Purple800, Primary.Purple800, Primary.Blue900,
                Accent.Green700, TextShade.WHITE);
        }

        private void Salida_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión a la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void CargarDatos()
        {
            try
            {
                string query = @"SELECT * FROM Salida";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la tabla Salida: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarSalida agregarSalidaForm = new AgregarSalida(connection, ModoEdicion.Insertar);
            agregarSalidaForm.ShowDialog();

            // Volver a cargar los datos después de agregar una salida
            CargarDatos();
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el ID de salida seleccionado
                int idSalida = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Salida"].Value);

                AgregarSalida agregarSalidaForm = new AgregarSalida(connection, ModoEdicion.Actualizar, idSalida);
                agregarSalidaForm.ShowDialog();

                // Volver a cargar los datos después de realizar la actualización
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el ID de salida seleccionado
                int idSalida = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Salida"].Value);

                if (MessageBox.Show("¿Está seguro de que desea eliminar esta salida?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();

                        // Eliminar la salida de la base de datos
                        string query = $"DELETE FROM Salida WHERE ID_Salida = {idSalida}";

                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Salida eliminada correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la salida: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();

                        // Volver a cargar los datos después de eliminar
                        CargarDatos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVista_Click(object sender, EventArgs e)
        {
            EquiposInstalados ventanaEquiposInstalados = new EquiposInstalados(connection);
            ventanaEquiposInstalados.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
