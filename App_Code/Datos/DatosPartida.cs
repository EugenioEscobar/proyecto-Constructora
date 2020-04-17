using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosPartida
/// </summary>
public class DatosPartida
{
    public static bool AgregarPartida(Partida obj)
    {
        try
        {
            bool agregado;
            Conexion c = new Conexion();
            string servidor = c.cadena();
            using (SqlConnection conn = new SqlConnection(servidor))
            {
                using (SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "P_REGISTRAR_PARTIDA"
                })
                {
                    cmd.Parameters.AddWithValue("@PIN_DESCRIPCION", SqlDbType.NChar).Value = obj.Descripcion;
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        agregado = true;
                    }
                    else
                    {
                        throw new Exception("Error al agregar Partida");
                    }
                    conn.Close();
                }
            }

            return agregado;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }


    }
    public static bool ModificarPartida(Partida obj)
    {
        try
        {
            bool agregado = false;
            Conexion c = new Conexion();
            string servidor = c.cadena();

            using (SqlConnection conn = new SqlConnection(servidor))
            {
                using (SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "P_MODIFICAR_PARTIDA"
                }
                )
                {
                    cmd.Parameters.AddWithValue("@PIN_CODIGO", SqlDbType.Int).Value = obj.Id;
                    cmd.Parameters.AddWithValue("@PIN_DESCRIPCION", SqlDbType.NChar).Value = obj.Descripcion;
                    cmd.Parameters.AddWithValue("@PIN_ESTADO", SqlDbType.TinyInt).Value = obj.Estado;

                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        agregado = true;
                    }
                    else
                    {
                        throw new Exception("Error al modificar Partida");
                    }
                    agregado = true;
                }
            }
            return agregado;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static Partida BuscarPartida(int codigo)
    {
        try
        {
            Partida obj = new Partida();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_PARTIDA"
            };

            SqlParameter parametro = new SqlParameter
            {
                ParameterName = "@PIN_CODIGO",
                SqlDbType = SqlDbType.Int,
                Value = codigo
            };

            comando.Parameters.Add(parametro);
            SqlDataAdapter myDA = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            myDA.Fill(dt);
            obj.Id = Convert.ToInt16(dt.Rows[0][0].ToString());
            obj.Descripcion = dt.Rows[0][1].ToString();
            obj.Estado = Convert.ToInt16(dt.Rows[0][2].ToString());

            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static DataTable ListarPartida()
    {
        try
        {
            Conexion c = new Conexion();
            DataTable dt = new DataTable();
            SqlConnection dataConnection = new SqlConnection(c.cadena());
            SqlDataAdapter da = new SqlDataAdapter("P_LISTAR_PARTIDA", dataConnection);
            dataConnection.Open();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(dt);
            dataConnection.Close();

            return dt;
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }
}