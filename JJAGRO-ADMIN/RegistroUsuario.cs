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
    public partial class RegistroUsuario : Form
    {
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void btnregistrousuario_Click(object sender, EventArgs e)
        {

            //validamos los campos
            if (!string.IsNullOrEmpty(txtpaterno.Text) && !string.IsNullOrEmpty(txtmaterno.Text) && !string.IsNullOrEmpty(txtnombres.Text) && !string.IsNullOrEmpty(txtcoreoregistro.Text) && !string.IsNullOrEmpty(txtpass.Text))
            {
                MessageBox.Show("Todo OK");
            }
            else
            {
                MessageBox.Show("Los campos son Obligatorios");
            }
        }
    }
}
