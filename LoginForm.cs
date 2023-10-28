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
    public partial class LoginForm : MaterialForm
    {
        private MySqlConnection connection;

        public LoginForm(MySqlConnection connection)
        {
            InitializeComponent();
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

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Aquí puedes agregar la lógica para validar las credenciales
            if (username == "admin" && password == "Tln3tw0rk")
            {
                // Cerrar el formulario de inicio de sesión
                this.Hide();
                Form1 form1 = new Form1(connection);
                form1.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales inválidas. Inténtalo de nuevo.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
