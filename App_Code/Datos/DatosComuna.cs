using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosComuna
/// </summary>
public class DatosComuna
{


    public static Comuna BuscarComuna(int codigo)
    {
        try
        {
            Comuna obj = new Comuna();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_COMUNA"
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
            if (dt.Rows.Count == 0)
            {
                throw new Exception("Comuna icorrecta");
            }
            else
            {
                obj.Id = int.Parse(dt.Rows[0][0].ToString());
                obj.Descripcion = dt.Rows[0][1].ToString();
                obj.Provincia = DatosProvincia.BuscarProvincia(Convert.ToInt32(dt.Rows[0][2].ToString()));
                obj.Estado = int.Parse(dt.Rows[0][3].ToString());
            }

            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static DataTable ListarComunas(int provincia)
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
                CommandText = "P_CARGAR_COMUNAS"
            };

            comando.Parameters.AddWithValue("@PIN_PROVINCIA", SqlDbType.Int).Value = provincia;

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