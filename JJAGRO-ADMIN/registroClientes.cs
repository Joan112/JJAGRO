using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        private void btnregistrousuario_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtpaternocliente.Text) &&
                !string.IsNullOrEmpty(txtmaternocliente.Text) &&
                !string.IsNullOrEmpty(txtnombrescliente.Text) &&
                !string.IsNullOrEmpty(txtnombreempresacliente.Text) &&
                !string.IsNullOrEmpty(txtrazoncliente.Text) &&
                !string.IsNullOrEmpty(txtcultivocliente.Text) &&
                !string.IsNullOrEmpty(txthascleinte.Text))
            {

                //sender asignan las variables
                string  maternocli = txtpaternocliente.Text.ToUpper(),
                        paternocli = txtmaternocliente.Text.ToUpper(),
                        nombrescli = txtnombrescliente.Text.ToUpper(),
                        empresacli = txtnombreempresacliente.Text.ToUpper(),
                        razoncli   = txtrazoncliente.Text.ToUpper(),
                        cultivocli = txtcultivocliente.Text.ToUpper(),
                        hascli     = txthascleinte.Text.ToUpper();

                if (Funciones_publicas.RegistrarCliente(maternocli,
                                                    paternocli,
                                                    nombrescli,
                                                    empresacli,
                                                    razoncli,
                                                    cultivocli,
                                                    hascli))
                {
                    MessageBox.Show("Cliente guardado con exito");
                    Thread.Sleep(2000);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error el guardar al cliente...");
                }

            }
            else
            {
                MessageBox.Show("Los campos son Obligatorios");
            }
        }
    }
}
