using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class VentanaUsuarios : Form
    {
        SqlConnection instanciaConexion = new SqlConnection();

        //Variables para estructurar la cadena de conexion
        string servidor = "localhost";
        string bd = "proyecto";
        string usuario = "java";
        string password = "";
        string puerto = "1433";

        public VentanaUsuarios()
        {
            InitializeComponent();
        }

        private void VentanaUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                //Varaiable para guardar la cadena de conexion
                string cadenaDeConexion = "Data Source=" + servidor + "," + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "Initial Catalog=" + bd + ";" + "Persist Security Info=true";
                instanciaConexion.ConnectionString = cadenaDeConexion;

                string transaccion = "SELECT * FROM Usuarios;";
                SqlDataAdapter adaptador = new SqlDataAdapter(transaccion, instanciaConexion);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            instanciaConexion.ejecutarTransaccion("Usuarios","INSERT INTO Usuarios VALUES('"+textBox1.Text+"','"+textBox2.Text+"');",Form1.usuarioInstanciado,"Insertar");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            instanciaConexion.ejecutarTransaccion("Usuarios","DELETE FROM Usuarios WHERE(Usuario='"+textBox1.Text+"');",Form1.usuarioInstanciado,"Eliminar");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            instanciaConexion.ejecutarTransaccion("Usuarios","UPDATE Usuarios SET Usuario='"+textBox1.Text+"',Clave='"+textBox2.Text+"' WHERE Usuario='"+textBox1.Text+"';",Form1.usuarioInstanciado,"Modificar");
        }
    }
}
