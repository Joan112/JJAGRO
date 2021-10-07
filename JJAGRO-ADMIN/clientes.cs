using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JJAGRO_ADMIN
{
    public partial class clientes : Form
    {
        public clientes()
        {
            InitializeComponent();
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            registroClientes form = new registroClientes();
            form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string cliente = txtBuscarCliente.Text.ToUpper();
            dgClientes.Columns.Clear();

            if (!string.IsNullOrEmpty(cliente))
            {
                CLog.XLog("-------------------------------------------------------------");
                CLog.XLog("Entramos a consultar cliente ");
                OdbcConnection Con;
                OdbcCommand Cmd;
                OdbcDataReader reader;

                Con = CConeccion.conexionAG();

                string sMensaje;
                try
                {

                    if ((Con != null) && (Con.State == ConnectionState.Open))
                    {


                        string sCadenaSql = string.Format("select maternocli,paternocli,nombrescli,empresacli,razoncli,cultivocli,hascli from clientesjjagro where nombrescli ilike '%{0}%';"
                                            , cliente);

                        //String sCadenaSql2 = "select maternocli,paternocli,nombrescli,empresacli,razoncli,cultivocli,hascli from clientesjjagro where nombrescli ilike '%" +cliente + "%';";


                        Cmd = Con.CreateCommand();
                        Cmd.CommandType = CommandType.Text;
                        Cmd.CommandText = sCadenaSql;
                        CLog.XLog("Ciente: " + sCadenaSql);



                        try
                        {

                            reader = Cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                        
                                    dgClientes.ColumnCount = 7;
                                    dgClientes.Columns[0].HeaderText = "Apellido Materno";
                                    dgClientes.Columns[1].HeaderText = "Apellido Paterno";
                                    dgClientes.Columns[2].HeaderText = "Nombres";
                                    dgClientes.Columns[3].HeaderText = "Empresa";
                                    dgClientes.Columns[4].HeaderText = "Razon Social";
                                    dgClientes.Columns[5].HeaderText = "Cultivo";
                                    dgClientes.Columns[6].HeaderText = "HAS";
                                    int n = dgClientes.Rows.Add();
                                    dgClientes.Rows[n].Cells[0].Value = reader["maternocli"];
                                    dgClientes.Rows[n].Cells[1].Value = reader["paternocli"];
                                    dgClientes.Rows[n].Cells[2].Value = reader["nombrescli"];
                                    dgClientes.Rows[n].Cells[3].Value = reader["empresacli"];
                                    dgClientes.Rows[n].Cells[4].Value = reader["razoncli"];
                                    dgClientes.Rows[n].Cells[5].Value = reader["cultivocli"];
                                    dgClientes.Rows[n].Cells[6].Value = reader["hascli"];

                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron registros para ese nombre...!!!");
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
                MessageBox.Show("El campo es obligatorio...!!!");

            }

        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            dgClientes.Columns.Clear();
            txtBuscarCliente.Text = "";
            txtBuscarCliente.Focus();
        }
    }
}
