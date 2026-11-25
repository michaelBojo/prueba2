using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GameZoneStore
{
    public partial class Form1 : Form
    {
        //CADENA DE CONEXION SQL 
        string cadena = @"Data Source=(localdb)\MSSQLLocalDB;" +
                        @"Initial Catalog=GameZoneStoreBD;" +
                        @"Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtContraseña.Text == "")
            {
                MessageBox.Show("Ingrese usuario y contraseña"); 
                return;
            }
            try
            {
                //Intancia de la conexion y apertura
                SqlConnection conexion = new SqlConnection(cadena);
                conexion.Open();

                string sql = "SELECT COUNT(*) FROM Usuarios " +
                             "WHERE Usuario = @u AND Contraseña = @c";

                //Instancia de comandos de SQL
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@u", txtUsuario.Text);
                comando.Parameters.AddWithValue("@c", txtContraseña.Text);

                int coincidencias = (int)comando.ExecuteScalar();

                if(coincidencias == 1)
                {
                    FrmCatalogo principal = new FrmCatalogo();
                    this.Hide();//Ocultar login 
                    principal.ShowDialog();//Abre la tienda y espera
                    this.Close();//Al cerrar, termina la app
                }
                else
                {
                    MessageBox.Show("Usuario y contraseña incorrectos.");
                    txtContraseña.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
