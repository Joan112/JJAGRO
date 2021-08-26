using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JJAGRO_ADMIN
{
    class CConeccion
    {
        
        public static OdbcConnection conexionAG()
        {
            string sIpAG = "127.0.0.1";
            OdbcConnection conexion;

            if (sIpAG.Length > 0)
            {
                string sCadenaConexion = "DRIVER={PostgreSQL UNICODE};"
                                        + "Server=" + sIpAG + ";"
                                        + "DATABASE=jjagro;"
                                        + "Trusted_connection=yes;"
                                        + "UID=postgres;"
                                        + "PWD=;";

                
                conexion = new OdbcConnection(sCadenaConexion);

                try
                {
                    conexion.Open();
                }
                catch (Exception ex)
                {
                    string sMensaje = ex.ToString();
                    MessageBox.Show(sMensaje);
                    CLog.XLog(sMensaje);
                    conexion = null;
                }
            }
            else
            {
                conexion = null;
            }

            return conexion;
        }
    }
}
