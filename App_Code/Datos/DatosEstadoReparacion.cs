using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosEstadoReparacion
/// </summary>
public class DatosEstadoReparacion
{
    public static bool AgregarEstadoReparacion(EstadoReparacion obj)
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
                    CommandText = "P_REGISTRAR_ESTADOREPARACION"
                }
                )
                {
                    cmd.Parameters.AddWithValue("@PIN_DESCRIPCION", SqlDbType.VarChar).Value = obj.Descripcion;

                    conn.Open();
                    cmd.ExecuteNonQuery();
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

    public static bool ModificarEstadoReparacion(EstadoReparacion obj)
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
                    CommandText = "P_MODIFICAR_ESTADOREPARACION"
                }
                )
                {
                    cmd.Parameters.AddWithValue("@PIN_CODIGO", SqlDbType.VarChar).Value = obj.Id;
                    cmd.Parameters.AddWithValue("@PIN_DESCRIPCION", SqlDbType.VarChar).Value = obj.Descripcion;
                    cmd.Parameters.AddWithValue("@PIN_ESTADO", SqlDbType.TinyInt).Value = obj.Estado;

                    conn.Open();
                    cmd.ExecuteNonQuery();
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

    public static EstadoReparacion BuscarEstadoReparacion(int codigo)
    {
        try
        {
            EstadoReparacion obj = new EstadoReparacion();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_ESTADOREPARACION"
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
            obj.Id = int.Parse(dt.Rows[0][0].ToString());
            obj.Descripcion = dt.Rows[0][1].ToString();
            obj.Estado = int.Parse(dt.Rows[0][2].ToString());
            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static DataTable ListarEstadoReparacion()
    {
        try
        {
            Conexion c = new Conexion();
            DataTable dt = new DataTable();
            SqlConnection dataConnection = new SqlConnection(c.cadena());
            SqlDataAdapter da = new SqlDataAdapter("P_LISTAR_ESTADOREPARACION", dataConnection);
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