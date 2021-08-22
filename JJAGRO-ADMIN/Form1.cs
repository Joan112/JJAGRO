using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JJAGRO_ADMIN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegistroUsuario registro = new RegistroUsuario();
            registro.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
          

            if (!string.IsNullOrWhiteSpace(txtcorreo.Text) && !string.IsNullOrWhiteSpace(txtpass.Text))
            {
                //capturamos el correo y procedemos a valiarlo
                string correo = txtcorreo.Text;
                bool isOk = ValidateEmail(correo);
                 
                if (isOk)
                {
                    MessageBox.Show("Todo OK");
                }
                else
                {
                    MessageBox.Show("Favor de ingresa un correo valido");
                }
                
            }
            else
            {
                MessageBox.Show("El Correo o la Contraseña son requeridos obligatoriamente");
            }
        }






        //funciones de usuairo
        static bool ValidateEmail(string email)
        {
            if (email == null)
            {
                return false;
            }
            if (new EmailAddressAttribute().IsValid(email))
            {
                return true;
            }
            else
            {

                return false;
            }
        }

    }
}
