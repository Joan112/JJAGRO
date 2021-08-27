using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Odbc;
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
                string paterno = txtpaterno.Text,
                        materno = txtmaterno.Text,
                        nombre = txtnombres.Text,
                        correo = txtcoreoregistro.Text,
                        admin,
                        pass = txtpass.Text;

                bool addmin;

                if (Rbadmin.Checked == true)
                {
                    admin = "1";
                }
                else
                {
                    admin = "0";
                }


                bool isOk = ValidateEmail(correo);

                if (!isOk)
                {
                    MessageBox.Show("Favor de ingresar un correo valido...!!!  (elemplo@ejemplo.com)");
                }
                else
                {

                    if(Funciones_publicas.ValidarEmailBD(correo))
                    {

                        if (Funciones_publicas.RegistraUsuario(paterno,materno,nombre,correo,pass,admin))
                        {
                            this.Hide();
                            Form1 form = new Form1();
                            form.Show();
                        }

                    }
                    else
                    {
                        MessageBox.Show("El correo ya se encuentra registrado en nuestra Base de Datos, favor de ingresar un corro diferente...!!!");
                        CLog.XLog("El correo ya se encuentra registrado en nuestra Base de Datos, favor de ingresar un corro diferente...!!!");
                    }


                }
            }
            else
            {
                MessageBox.Show("Los campos son Obligatorios");
            }
            
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtcoreoregistro.Text = "";
            this.txtmaterno.Text = "";
            this.txtnombres.Text = "";
            this.txtpass.Text = "";
            this.txtpaterno.Text = "";

            this.txtpaterno.Focus();
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
