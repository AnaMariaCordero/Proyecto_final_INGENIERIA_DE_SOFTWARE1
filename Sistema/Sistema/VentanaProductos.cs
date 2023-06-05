using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class VentanaProductos : Form
    {

        SqlConnection instanciaConexion = new SqlConnection();

        //Variables para estructurar la cadena de conexion
        string servidor = "localhost";
        string bd = "proyecto";
        string usuario = "java";
        string password = "";
        string puerto = "1433";

        public VentanaProductos()
        {
            InitializeComponent();
        }

        private void VentanaProductos_Load(object sender, EventArgs e)
        {
            try
            {
                //Varaiable para guardar la cadena de conexion
                string cadenaDeConexion = "Data Source=" + servidor + "," + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "Initial Catalog=" + bd + ";" + "Persist Security Info=true";
                instanciaConexion.ConnectionString = cadenaDeConexion;

                string transaccion = "SELECT * FROM Productos;";
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
            instanciaConexion.ejecutarTransaccion("Productos","INSERT INTO Productos VALUES("+textBox1.Text+",'"+textBox2.Text+"','"+textBox3.Text+"',"+textBox4.Text+","+textBox5.Text+");",Form1.usuarioInstanciado,"Insertar");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            instanciaConexion.ejecutarTransaccion("Productos","DELETE FROM Productos WHERE(CodigoProducto="+textBox1.Text+");",Form1.usuarioInstanciado,"Eliminar");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            instanciaConexion.ejecutarTransaccion("Productos","UPDATE Productos SET CodigoProducto="+textBox1.Text+",Nombre='"+textBox2.Text+"',Descripcion='"+textBox3.Text+"',Precio="+textBox4.Text+",Cantidad="+textBox4.Text+" WHERE CodigoProducto="+textBox1.Text+";",Form1.usuarioInstanciado,"Modificar");
        }
    }
}
