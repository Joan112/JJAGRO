using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJAGRO_ADMIN
{
    class CConeccion
    {
        
        public static OdbcConnection conexionAG()
        {
            string sIpAG = "127.0.0.1";
            string sCadenaConexion = string.Empty;
            string sMensaje = string.Empty;
            OdbcConnection conexion;

            if (sIpAG.Length > 0)
            {
                sCadenaConexion = "DRIVER={PostgreSQL};"
                    + "Server=" + sIpAG + ";"
                    + "DATABASE=jjagro;"
                    + "Trusted_connection=yes;"
                    + "UID=;"
                    + "PWD=;";

                conexion = new OdbcConnection(sCadenaConexion);

                try
                {
                    conexion.Open();
                }
                catch (Exception ex)
                {
                    sMensaje = ex.ToString();
                    //MessageBox.Show(sMensaje);
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
