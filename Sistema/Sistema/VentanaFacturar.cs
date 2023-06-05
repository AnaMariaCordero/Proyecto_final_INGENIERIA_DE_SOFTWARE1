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
    public partial class VentanaFacturar : Form
    {
        
        SqlConnection instanciaConexion = new SqlConnection();

        //Variables para estructurar la cadena de conexion
        string servidor = "localhost";
        string bd = "proyecto";
        string usuario = "java";
        string password = "";
        string puerto = "1433";

        public VentanaFacturar()
        {
            InitializeComponent();
        }

        private void VentanaFacturar_Load(object sender, EventArgs e)
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
            instanciaConexion.ejecutarTransaccion("Facturas","INSERT INTO Facturas VALUES("+textBox1.Text+","+textBox2.Text+");",Form1.usuarioInstanciado,"Insertar");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            instanciaConexion.ejecutarTransaccion("DetalleDeFactura","INSERT INTO DetalleDeFactura VALUES("+textBox1.Text+","+textBox2.Text+");",Form1.usuarioInstanciado,"Insertar");
        }
    }
}
