using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosUsuario
/// </summary>
public class DatosUsuario
{
    public static bool VerificarUsuario(Usuario user)
    {
        try
        {
            bool verificado=false;
            Usuario usuario = new Usuario();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_USUARIO"
            };

            SqlParameter parametro = new SqlParameter
            {
                ParameterName = "@PIN_USUARIO",
                SqlDbType = SqlDbType.VarChar,
                Value = user.User
            };

            comando.Parameters.Add(parametro);
            SqlDataAdapter myDA = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            myDA.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                usuario.User = dt.Rows[0][3].ToString();
                usuario.Password = dt.Rows[0][4].ToString();
                usuario.Estado = Convert.ToInt32(dt.Rows[0][7].ToString());
                if (usuario.Password.Equals(user.Password))
                {
                    if (usuario.Estado == 1)
                    {
                        verificado = true;
                    }
                    else
                    {
                        throw new Exception("Ud. no tiene acceso al sistema");
                    }
                }
                else
                {
                    throw new Exception("Contraseña Incorrecta");
                }
            }
            else
            {
                throw new Exception("Usuario Incorrecto");
            }

            return verificado;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static Usuario BuscarUsuario(string user)
    {
        try
        {
            Usuario usuario = new Usuario();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_USUARIO"
            };

            SqlParameter parametro = new SqlParameter
            {
                ParameterName = "@PIN_CODIGO",
                SqlDbType = SqlDbType.Int,
                Value = user
            };

            comando.Parameters.Add(parametro);
            SqlDataAdapter myDA = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            myDA.Fill(dt);
            usuario.Id = Convert.ToInt32(dt.Rows[0][0].ToString());
            usuario.Rut = dt.Rows[0][1].ToString();
            usuario.Nombre = dt.Rows[0][2].ToString();
            usuario.User = dt.Rows[0][3].ToString();
            usuario.Password = dt.Rows[0][4].ToString();
            usuario.Area = Convert.ToInt32(dt.Rows[0][5].ToString());
            usuario.Comuna = Convert.ToInt32(dt.Rows[0][6].ToString());
            usuario.Estado = Convert.ToInt32(dt.Rows[0][7].ToString());
            return usuario;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}