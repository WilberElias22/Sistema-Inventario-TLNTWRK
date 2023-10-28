using System;
using System.Data;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using MaterialSkin.Controls;
using iText.Kernel;
using MaterialSkin;

namespace Inventario_Tlntwrk
{
    public partial class Form1 : MaterialForm
    {
        private MySqlConnection connection;

        public Form1(MySqlConnection connection)
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

        private void Form1_Load(object sender, EventArgs e)
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
                string query = @"SELECT Router.ID_Router, Router.Serial, Router.Lote, Marca.Nombre_Marca, Modelo.Nombre_Modelo, Proveedor.Nombre_Proveedor
                 FROM Router
                 INNER JOIN Marca ON Router.ID_Marca = Marca.ID_Marca
                 INNER JOIN Modelo ON Router.ID_Modelo = Modelo.ID_Modelo
                 INNER JOIN Proveedor ON Router.ID_Proveedor = Proveedor.ID_Proveedor";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Renombrar las columnas para mostrar los nombres de las claves foráneas en lugar de los números INT
                dataTable.Columns["ID_Router"].ColumnName = "ID Router";
                dataTable.Columns["Serial"].ColumnName = "Serial";
                dataTable.Columns["Lote"].ColumnName = "Lote";
                dataTable.Columns["Nombre_Marca"].ColumnName = "Marca";
                dataTable.Columns["Nombre_Modelo"].ColumnName = "Modelo";
                dataTable.Columns["Nombre_Proveedor"].ColumnName = "Proveedor";

                DgvDatos.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de los routers: " + ex.Message);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmTabla frmTabla = new FrmTabla(connection, ModoEdicion.Insertar);
            frmTabla.ShowDialog();

            // Volver a cargar los datos después de realizar la inserción
            CargarDatos();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (DgvDatos.SelectedRows.Count > 0)
            {
                // Obtener el ID del router seleccionado
                int idRouter = Convert.ToInt32(DgvDatos.SelectedRows[0].Cells["ID Router"].Value);

                try
                {
                    connection.Open();

                    // Eliminar el router de la base de datos
                    string query = $"DELETE FROM Router WHERE ID_Router = {idRouter}";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Router eliminado correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el router: " + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();

                    // Volver a cargar los datos después de eliminar
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (DgvDatos.SelectedRows.Count > 0)
            {
                // Obtener el ID del router seleccionado
                int idRouter = Convert.ToInt32(DgvDatos.SelectedRows[0].Cells["ID Router"].Value);

                FrmTabla frmTabla = new FrmTabla(connection, ModoEdicion.Actualizar, idRouter);
                frmTabla.ShowDialog();

                // Volver a cargar los datos después de realizar la actualización
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            Salida salidaForm = new Salida(connection);
            salidaForm.ShowDialog();
        }

        private void btnGeneraInforme_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay columnas en el DataGridView
                if (DgvDatos.Columns.Count == 0)
                {
                    MessageBox.Show("No hay datos para generar el informe.", "Generar Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Obtener la ubicación del archivo
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Crear el documento PDF
                    PdfWriter writer = new PdfWriter(filePath);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);

                    // Crear una tabla en el documento y agregar los datos
                    Table table = new Table(DgvDatos.Columns.Count);

                    // Agregar encabezados de columna
                    foreach (DataGridViewColumn column in DgvDatos.Columns)
                    {
                        table.AddCell(new Cell().Add(new Paragraph(column.HeaderText)));
                    }

                    // Agregar datos del DataGridView
                    foreach (DataGridViewRow row in DgvDatos.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(cell.Value.ToString())));
                        }
                    }

                    // Agregar la tabla al documento
                    document.Add(table);

                    // Cerrar el documento
                    document.Close();

                    MessageBox.Show("Informe generado correctamente.", "Generar Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el informe: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
