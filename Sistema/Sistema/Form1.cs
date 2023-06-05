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
    public partial class Form1 : Form
    {
        public static string usuarioInstanciado;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SistemaPrincipal ventanaDelSistema = new SistemaPrincipal();
            
            Conexion.ControladorConexion instanciaconexion = new Conexion.ControladorConexion();
            if(instanciaconexion.validarUsuario(textBox1.Text, textBox2.Text)==true)
            {
                usuarioInstanciado = textBox1.Text;
                this.Hide();
                ventanaDelSistema.Show();
            }
        }
    }
}
