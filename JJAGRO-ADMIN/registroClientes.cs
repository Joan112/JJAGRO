using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JJAGRO_ADMIN
{
    public partial class registroClientes : Form
    {
        public registroClientes()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtcultivocliente.Text = "";
            txthascleinte.Text = "";
            txtmaternocliente.Text = "";
            txtnombreempresacliente.Text = "";
            txtnombrescliente.Text = "";
            txtpaternocliente.Text = "";
            txtrazoncliente.Text = "";
            txtpaternocliente.Focus();
        }
    }
}
