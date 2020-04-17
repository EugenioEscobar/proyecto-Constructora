using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosHoras
/// </summary>
public class DatosHoras
{
    public static Hora BuscarHora(int descripcion)
    {
        try
        {
            Hora obj = new Hora();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_HORA"
            };

            SqlParameter parametro = new SqlParameter
            {
                ParameterName = "@PIN_CODIGO",
                SqlDbType = SqlDbType.Int,
                Value = descripcion
            };

            comando.Parameters.Add(parametro);
            SqlDataAdapter myDA = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            myDA.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                obj.Id = Convert.ToInt16(dt.Rows[0][0].ToString());

                obj.Descripcion = dt.Rows[0][1].ToString();

                obj.Estado = Convert.ToInt16(dt.Rows[0][2].ToString());
            }
            else
            {
                obj = new Hora();
            }
            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public static Hora BuscarHoraPorDescripcion(string descripcion)
    {
        try
        {
            Hora obj = new Hora();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_HORA_POR_DESCRIPCION"
            };

            SqlParameter parametro = new SqlParameter
            {
                ParameterName = "@PIN_DESCRIPCION",
                SqlDbType = SqlDbType.VarChar,
                Value = descripcion
            };

            comando.Parameters.Add(parametro);
            SqlDataAdapter myDA = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            myDA.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                obj.Id = Convert.ToInt16(dt.Rows[0][0].ToString());

                obj.Descripcion = dt.Rows[0][1].ToString();

                obj.Estado = Convert.ToInt16(dt.Rows[0][2].ToString());
            }
            else
            {
                obj = new Hora();
            }
            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}