using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            CLog.XLog("-------------------------------------------------------------");
            CLog.XLog("Entramos a validar el usuario");

           

            if (!string.IsNullOrWhiteSpace(txtcorreo.Text) && !string.IsNullOrWhiteSpace(txtpass.Text))
            {
                //capturamos el correo y procedemos a valiarlo
                string correo = txtcorreo.Text;
                string pass = txtpass.Text;

                CLog.XLog("Correo Electronico: " + correo);
                //validamos el correo
                bool isOk = ValidateEmail(correo);
                 
                if (isOk)
                {
                    OdbcConnection Con;
                    OdbcCommand Cmd;
                    OdbcDataReader reader;
 
                    Con = CConeccion.conexionAG();

                    string sMensaje;
                    try
                    {
                        if ((Con != null) && (Con.State == ConnectionState.Open))
                        {
                            string sCadenaSql = String.Format(" select correoelectronico, contraseña from usuariosjjagro where correoelectronico = '{0}' and contraseña = '{1}'"
                                ,correo
                                ,pass);

                            Cmd = Con.CreateCommand();
                            Cmd.CommandType = CommandType.Text;
                            Cmd.CommandText = sCadenaSql;
                            CLog.XLog("VALIDANDO: " + sCadenaSql);

                            try
                            {
                                reader = Cmd.ExecuteReader();
  
                                if (reader.Read())
                                {
                                    CLog.XLog("Correo validado sera redireccionado al formulario principal");
                                    this.Hide();
                                    admin_jjagro admin = new admin_jjagro();
                                    admin.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Usuario no autorizado el email no corresponde o no se encuentra en nuestros registros");
                                    Thread.Sleep(2000);
                                    txtcorreo.Text = "";
                                    txtpass.Text = "";
                                    txtcorreo.Focus();
                                }
                            }
                            catch (Exception ex)
                            {
                                sMensaje = ex.Message.ToString();
                                CLog.XLog("Problema al ejecutar la consulta: " + sMensaje);
                            }
                            finally
                            {
                                Con.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        sMensaje = ex.Message.ToString();
                        CLog.XLog("Problema de conexion: " + sMensaje);
                    }

                }
                else
                {
                    MessageBox.Show("Favor de ingresar un correo valido...!!!  (elemplo@ejemplo.com)");
                }
                
            }
            else
            {
                MessageBox.Show("El Correo o la Contraseña son requeridos obligatoriamente");
            }
            CLog.XLog("-------------------------------------------------------------");
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
