using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosProvincia
/// </summary>
public class DatosProvincia
{

    public static Provincia BuscarProvincia(int codigo)
    {
        try
        {
            Provincia obj = new Provincia();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_PROVINCIA"
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
            obj.Region = DatosRegion.BuscarRegion(Convert.ToInt32(dt.Rows[0][2].ToString()));
            obj.Estado = dt.Rows[0][3].ToString();

            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public static DataTable ListarProvincia(int region)
    {
        try
        {
            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_CARGAR_PROVINCIAS"
            };

            comando.Parameters.AddWithValue("@PIN_REGION", SqlDbType.Int).Value = region;

            SqlDataAdapter myDA = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            myDA.Fill(dt);

            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}