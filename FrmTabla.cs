using System;
using System.Data;
using System.Windows.Forms;
using MaterialSkin;
using MySql.Data.MySqlClient;
using Inventario_Tlntwrk;

namespace Inventario_Tlntwrk
{
    public partial class FrmTabla : MaterialSkin.Controls.MaterialForm
    {
        private MySqlConnection connection;
        private ModoEdicion modoEdicion;
        private int idRouter;

        public FrmTabla(MySqlConnection connection, ModoEdicion modoEdicion, int idRouter = 0)
        {
            InitializeComponent();
            this.connection = connection;
            this.modoEdicion = modoEdicion;
            this.idRouter = idRouter;
        }


        private void FrmTabla_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Purple800, Primary.Purple800, Primary.Blue900, Accent.Green700, TextShade.WHITE);

            CargarListBox();

            if (modoEdicion == ModoEdicion.Actualizar)
            {
                CargarDatosRouter();
            }
        }

        private void CargarListBox()
        {
            try
            {
                // Consultas SQL para obtener los datos de las tablas Marca, Modelo y Proveedor
                string queryMarca = "SELECT * FROM Marca";
                string queryModelo = "SELECT * FROM Modelo";
                string queryProveedor = "SELECT * FROM Proveedor";

                MySqlCommand commandMarca = new MySqlCommand(queryMarca, connection);
                MySqlCommand commandModelo = new MySqlCommand(queryModelo, connection);
                MySqlCommand commandProveedor = new MySqlCommand(queryProveedor, connection);

                MySqlDataAdapter adapterMarca = new MySqlDataAdapter(commandMarca);
                MySqlDataAdapter adapterModelo = new MySqlDataAdapter(commandModelo);
                MySqlDataAdapter adapterProveedor = new MySqlDataAdapter(commandProveedor);

                DataTable dataTableMarca = new DataTable();
                DataTable dataTableModelo = new DataTable();
                DataTable dataTableProveedor = new DataTable();

                adapterMarca.Fill(dataTableMarca);
                adapterModelo.Fill(dataTableModelo);
                adapterProveedor.Fill(dataTableProveedor);

                // Asignar los DataTable como origen de datos de los ListBox
                lstMarca.DataSource = dataTableMarca;
                lstMarca.DisplayMember = "Nombre_Marca";
                lstMarca.ValueMember = "ID_Marca";

                lstModelo.DataSource = dataTableModelo;
                lstModelo.DisplayMember = "Nombre_Modelo";
                lstModelo.ValueMember = "ID_Modelo";

                lstProveedor.DataSource = dataTableProveedor;
                lstProveedor.DisplayMember = "Nombre_Proveedor";
                lstProveedor.ValueMember = "ID_Proveedor";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de las listas: " + ex.Message);
            }
        }

        private void CargarDatosRouter()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                // Consulta SQL para obtener los datos del router con los nombres de las claves foráneas
                string query = @"SELECT Router.ID_Router, Router.Serial, Router.Lote, Router.Fecha_Ingreso, 
                        Marca.ID_Marca, Modelo.ID_Modelo, Proveedor.ID_Proveedor
                        FROM Router
                        INNER JOIN Marca ON Router.ID_Marca = Marca.ID_Marca
                        INNER JOIN Modelo ON Router.ID_Modelo = Modelo.ID_Modelo
                        INNER JOIN Proveedor ON Router.ID_Proveedor = Proveedor.ID_Proveedor
                        WHERE Router.ID_Router = @ID_Router";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_Router", idRouter);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtSerial.Text = reader["Serial"].ToString();

                        DateTime lote;
                        if (DateTime.TryParse(reader["Lote"].ToString(), out lote))
                        {
                            dtpLote.Value = lote;
                        }
                        else
                        {
                            // Si no se puede convertir, mostrar un mensaje de error o tomar una acción apropiada
                            MessageBox.Show("Error al convertir el valor de Lote a tipo DateTime.");
                        }

                        // Seleccionar los elementos correspondientes en los ListBox
                        lstMarca.SelectedValue = Convert.ToInt32(reader["ID_Marca"]);
                        lstModelo.SelectedValue = Convert.ToInt32(reader["ID_Modelo"]);
                        lstProveedor.SelectedValue = Convert.ToInt32(reader["ID_Proveedor"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del router: " + ex.Message);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modoEdicion == ModoEdicion.Insertar)
                {
                    // Insertar un nuevo router en la base de datos
                    string query = @"INSERT INTO Router (Serial, Lote, ID_Marca, ID_Modelo, ID_Proveedor) 
                             VALUES (@Serial, @Lote, @ID_Marca, @ID_Modelo, @ID_Proveedor)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Serial", txtSerial.Text);
                        command.Parameters.AddWithValue("@Lote", dtpLote.Value);
                        command.Parameters.AddWithValue("@ID_Marca", lstMarca.SelectedValue);
                        command.Parameters.AddWithValue("@ID_Modelo", lstModelo.SelectedValue);
                        command.Parameters.AddWithValue("@ID_Proveedor", lstProveedor.SelectedValue);

                        connection.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Nuevo router insertado correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (modoEdicion == ModoEdicion.Actualizar)
                {
                    // Actualizar los datos del router en la base de datos
                    string query = $@"UPDATE Router 
                            SET Serial = @Serial, Lote = @Lote, ID_Marca = @ID_Marca, ID_Modelo = @ID_Modelo, ID_Proveedor = @ID_Proveedor
                            WHERE ID_Router = {idRouter}";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Serial", txtSerial.Text);
                        command.Parameters.AddWithValue("@Lote", dtpLote.Value);
                        command.Parameters.AddWithValue("@ID_Marca", lstMarca.SelectedValue);
                        command.Parameters.AddWithValue("@ID_Modelo", lstModelo.SelectedValue);
                        command.Parameters.AddWithValue("@ID_Proveedor", lstProveedor.SelectedValue);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Datos del router actualizados correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos del router: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }


        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            Marca marcaForm = new Marca(connection);
            if (marcaForm.ShowDialog() == DialogResult.OK)
            {
                // Aquí puedes realizar alguna acción después de agregar una marca, si es necesario
                // Por ejemplo, puedes recargar la lista de marcas en FrmTabla.
                CargarListBox();
            }
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {
            Modelo modeloForm = new Modelo(connection);
            if (modeloForm.ShowDialog() == DialogResult.OK)
            {
                // Aquí puedes realizar alguna acción después de agregar un modelo, si es necesario
                // Por ejemplo, puedes recargar la lista de modelos en FrmTabla.
                CargarListBox();
            }
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            Proveedor modeloForm = new Proveedor(connection);
            if (modeloForm.ShowDialog() == DialogResult.OK)
            {
                // Aquí puedes realizar alguna acción después de agregar un modelo, si es necesario
                // Por ejemplo, puedes recargar la lista de modelos en FrmTabla.
                CargarListBox();
            }
        }
    }

    // Enumeración para definir los modos de edición en FrmTabla
}
