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

namespace Inventario_Tlntwrk
{
    public partial class EquiposInstalados : MaterialForm
    {
        private MySqlConnection connection;
        private DataTable dataTable;

        public EquiposInstalados(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            dataTable = new DataTable();
        }

        private void EquiposInstalados_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT * FROM VistaSalidaRouter";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                dataTable.Clear();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay columnas en el DataTable
                if (dataTable.Columns.Count == 0)
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
                    Table table = new Table(dataTable.Columns.Count);

                    // Agregar encabezados de columna
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        table.AddCell(new Cell().Add(new Paragraph(column.ColumnName)));
                    }

                    // Agregar datos de la vista
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (object item in row.ItemArray)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(item.ToString())));
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
