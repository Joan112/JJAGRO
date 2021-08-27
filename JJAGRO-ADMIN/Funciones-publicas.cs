using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJAGRO_ADMIN
{
    class Funciones_publicas
    {
        //Funciones para validar el email en BD
        public static bool ValidarEmailBD(string email)
        {
            CLog.XLog("-------------------------------------------------------------");
            CLog.XLog("Validando EMAIL en BD");
            OdbcConnection Con;
            OdbcCommand Cmd;
            OdbcDataReader reader;

            Con = CConeccion.conexionAG();

            string sMensaje, correoisOK;
            try
            {

                if ((Con != null) && (Con.State == ConnectionState.Open))
                {
                    //validamos el correo que no se encuentre en la bD

                    string sCadenaSql = String.Format("select correoelectronico as correoelectronico from usuariosjjagro where correoelectronico = '{0}'"
                        , email);

                    Cmd = Con.CreateCommand();
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = sCadenaSql;
                    CLog.XLog("Correo: " + sCadenaSql);

                    try
                    {

                        reader = Cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            CLog.XLog("El correo si existe en BD");
                            return false;
                        }
                        else
                        {
                            CLog.XLog("El correo no existe en BD");
                            return true;
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

            CLog.XLog("-------------------------------------------------------------");

            return true;
        }  // fin 

        //Funciones que registra el usuario 
        public static bool RegistraUsuario(string paterno, string materno, string nombre, string correo, string pass, string admin)
        {
            CLog.XLog("-------------------------------------------------------------");
            OdbcConnection Con;
            OdbcCommand Cmd;
            OdbcDataReader reader;

            Con = CConeccion.conexionAG();

            string sMensaje;
            try
            {

                if ((Con != null) && (Con.State == ConnectionState.Open))
                {
                    //validamos el correo que no se encuentre en la bD

                    string sCadenaSql = String.Format("INSERT INTO usuariosjjagro (paterno,materno,nombres,correoelectronico,contraseña,administrador) VALUES ('{0}','{1}','{2}','{3}','{4}',{5})"
                        , paterno
                        , materno
                        , nombre
                        , correo
                        , pass
                        , admin);

                    Cmd = Con.CreateCommand();
                    Cmd.CommandType = CommandType.Text;
                    Cmd.CommandText = sCadenaSql;
                    CLog.XLog("Usuario: " + sCadenaSql);

                    try
                    {

                        reader = Cmd.ExecuteReader();
                        CLog.XLog("Datos guardados correctamente");

                        return true;


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
           
            CLog.XLog("-------------------------------------------------------------");
            return true;
        }



    }
}
