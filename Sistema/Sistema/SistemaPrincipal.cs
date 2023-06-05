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
    public partial class SistemaPrincipal : Form
    {
        
        public SistemaPrincipal()
        {
            InitializeComponent();
        }

        private void insertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaUsuarios forma = new VentanaUsuarios();
            forma.MdiParent = this;
            forma.Show();
        }

        private void administrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaRoles forma = new VentanaRoles();
            forma.MdiParent = this;
            forma.Show();
        }

        private void administrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VentanaProductos forma = new VentanaProductos();
            forma.MdiParent = this;
            forma.Show();
        }

        private void administrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            VentanaClientes forma = new VentanaClientes();
            forma.MdiParent = this;
            forma.Show();
        }

        private void administrarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            VentanaFacturar forma = new VentanaFacturar();
            forma.MdiParent = this;
            forma.Show();
        }

        private void administrarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            VentanaAdministrarFacturas forma = new VentanaAdministrarFacturas();
            forma.MdiParent = this;
            forma.Show();
        }
    }
}
