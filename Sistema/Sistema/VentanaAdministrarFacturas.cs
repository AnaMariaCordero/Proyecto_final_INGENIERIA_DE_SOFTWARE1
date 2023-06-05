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
    public partial class VentanaAdministrarFacturas : Form
    {
        SqlConnection instanciaConexion = new SqlConnection();

        //Variables para estructurar la cadena de conexion
        string servidor = "localhost";
        string bd = "proyecto";
        string usuario = "java";
        string password = "";
        string puerto = "1433";

        public VentanaAdministrarFacturas()
        {
            InitializeComponent();
        }

        private void VentanaAdministrarFacturas_Load(object sender, EventArgs e)
        {
            try
            {
                //Varaiable para guardar la cadena de conexion
                string cadenaDeConexion = "Data Source=" + servidor + "," + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "Initial Catalog=" + bd + ";" + "Persist Security Info=true";
                instanciaConexion.ConnectionString = cadenaDeConexion;

                string transaccion = "SELECT * FROM Facturas;";
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

    }
}
