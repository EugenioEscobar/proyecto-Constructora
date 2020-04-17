using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosGENERAL
/// </summary>
public class DatosGENERAL
{
    public static DataTable ListarAgenda(int supervisor, string fechaInicio, string fechaTermino)
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
                CommandText = "P_MOSTRAR_AGENDA"
            };
            comando.Parameters.AddWithValue("@PIN_SUPERVISOR", SqlDbType.Int).Value = supervisor;
            comando.Parameters.AddWithValue("@PIN_FECHA_INICIO", SqlDbType.Date).Value = fechaInicio;
            comando.Parameters.AddWithValue("@PIN_FECHA_TERMINO", SqlDbType.Date).Value = fechaTermino;

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