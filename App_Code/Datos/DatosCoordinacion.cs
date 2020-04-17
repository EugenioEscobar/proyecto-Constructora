using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosCoordinacion
/// </summary>
public class DatosCoordinacion
{
    public static bool AgregarCoordinacion(Coordinacion obj)
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
                    CommandText = "P_REGISTRAR_COORDINACION"
                }
                )
                {
                    cmd.Parameters.AddWithValue("@PIN_OBSERVACION", SqlDbType.Int).Value = obj.Observacion.Id;
                    cmd.Parameters.AddWithValue("@PIN_FECHA", SqlDbType.Int).Value = obj.Fecha;
                    cmd.Parameters.AddWithValue("@PIN_HORA_INICIO", SqlDbType.Int).Value = obj.HoraInicio.Id;
                    cmd.Parameters.AddWithValue("@PIN_HORA_TERMINO", SqlDbType.Int).Value = obj.HoraTermino.Id;

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

    //public static bool ModificarCoordinacion(Coordinacion obj)
    //{
    //    try
    //    {
    //        bool agregado = false;
    //        Conexion c = new Conexion();
    //        string servidor = c.cadena();

    //        using (SqlConnection conn = new SqlConnection(servidor))
    //        {
    //            using (SqlCommand cmd = new SqlCommand
    //            {
    //                Connection = conn,
    //                CommandType = CommandType.StoredProcedure,
    //                CommandText = "P_MODIFICAR_COORDINACION"
    //            }
    //            )
    //            {
    //                cmd.Parameters.AddWithValue("@PIN_CODIGO", SqlDbType.VarChar).Value = obj.Id;
    //                cmd.Parameters.AddWithValue("@PIN_DESCRIPCION", SqlDbType.VarChar).Value = obj.Descripcion;
    //                cmd.Parameters.AddWithValue("@PIN_DESCRIPCION", SqlDbType.VarChar).Value = obj.Descripcion;
    //                cmd.Parameters.AddWithValue("@PIN_DESCRIPCION", SqlDbType.VarChar).Value = obj.Descripcion;
    //                cmd.Parameters.AddWithValue("@PIN_ESTADO", SqlDbType.TinyInt).Value = obj.Estado;

    //                conn.Open();
    //                cmd.ExecuteNonQuery();
    //                agregado = true;
    //            }
    //        }
    //        return agregado;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //}

    public static Coordinacion BuscarCoordinacion(int codigo)
    {
        try
        {
            Coordinacion obj = new Coordinacion();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_COORDINACION"
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
            obj.Id = Convert.ToInt32(dt.Rows[0]["CODIGO"].ToString());
            obj.Observacion = DatosObservacion.BuscarObservacion(Convert.ToInt32(dt.Rows[0]["OBSERVACION"].ToString()));
            obj.Fecha = dt.Rows[0]["FECHA"].ToString();
            obj.HoraInicio = DatosHoras.BuscarHora(Convert.ToInt32(dt.Rows[0]["HORA_INICIO"].ToString()));
            obj.HoraTermino = DatosHoras.BuscarHora(Convert.ToInt32(dt.Rows[0]["HORA_TERMINO"].ToString()));
            obj.Estado = Convert.ToInt32(dt.Rows[0]["ESTADO"].ToString());
            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}