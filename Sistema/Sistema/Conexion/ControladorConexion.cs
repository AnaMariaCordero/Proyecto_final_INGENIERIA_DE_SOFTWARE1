using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sistema.Conexion
{
    internal class ControladorConexion
    {

        //Variable para crear la instancia de conexion
        SqlConnection instanciaConexion = new SqlConnection();

        //Variables para estructurar la cadena de conexion
        static string servidor = "localhost";
        static string bd = "proyecto";
        static string usuario = "admin";
        static string password = "";
        static string puerto = "1433";

        //Varaiable para guardar la cadena de conexion
        string cadenaDeConexion = "Data Source=" + servidor + "," + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "Initial Catalog=" + bd + ";" + "Persist Security Info=true";

        //Metodo para realizar prueba de conexion
        public SqlConnection pruebaDeConexion()
        {
            try
            {
                instanciaConexion.ConnectionString = cadenaDeConexion;
                instanciaConexion.Open();
                MessageBox.Show("Se conectó correctamente a la Base de Datos");
            }
            catch (SqlException e)
            {

                MessageBox.Show("No se logró conectar a la Base de Datos" + e.ToString());
            }
            return instanciaConexion;
        }

        //Metodo para validar usuario
        public bool validarUsuario(string usuario, string clave)
        {
            instanciaConexion.ConnectionString = cadenaDeConexion;
            instanciaConexion.Open();
            SqlCommand comando = new SqlCommand("SELECT * FROM Usuarios WHERE(Usuario='" + usuario + "' and Clave='" + clave + "')", instanciaConexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Metodo para validad el privilegio que tiene el usuario para realizar transacciones
        public bool validarPrivilegio(string usuario, string tabla, string transaccion)
        {
            instanciaConexion.ConnectionString = cadenaDeConexion;
            instanciaConexion.Open();
            SqlCommand comando = new SqlCommand("SELECT * FROM Roles WHERE(Usuario='" + usuario + "' and Tabla='" + tabla + "' and TipoDePrivilegio='" + transaccion + "')", instanciaConexion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Metodo para la ejecucion de transacciones
        public void ejecutarTransaccion(string parametroTabla, string parametroValores, string parametroUsuario, string parametroTransaccion)
        {
            bool resultadoDePrivilegio = false;
            resultadoDePrivilegio = validarPrivilegio(parametroUsuario, parametroTabla, parametroTransaccion);
            if (resultadoDePrivilegio == true)
            {
                instanciaConexion.ConnectionString = cadenaDeConexion;
                instanciaConexion.Open();
                SqlCommand comando = new SqlCommand(parametroValores, instanciaConexion);
                comando.ExecuteNonQuery();
                instanciaConexion.Close();
            }
            if (resultadoDePrivilegio == true)
            {
                MessageBox.Show("No tienes privilegios para la transaccion.");
            }
        }

        //metodo para prueba de instancia
        public void pruebaDeInstancia()
        {
            MessageBox.Show("hola");
        }

    }//Fin class controlador conexion
}
