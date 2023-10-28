using Inventario_Tlntwrk;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        string connectionString = "Server=bnipdg3qz0lx73ey1yen-mysql.services.clever-cloud.com;Database=bnipdg3qz0lx73ey1yen;Uid=ujddlpairhk7dots;Password=oM9mvUuocvN6fIxDLmnr;";
        MySqlConnection connection = new MySqlConnection(connectionString);

        // Crear e iniciar el formulario de inicio de sesión
        LoginForm loginForm = new LoginForm(connection);
        if (loginForm.ShowDialog() == DialogResult.OK)
        {
            // Si el inicio de sesión fue exitoso, mostrar el formulario principal
            Application.Run(new Form1(connection));
        }
    }

}
