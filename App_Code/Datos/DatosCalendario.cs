using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosCalendario
/// </summary>
public class DatosCalendario
{
    public static DataTable ListarCalendario(string fecha,int supervisor)
    {
        try
        {
            DateTime fechaParse = DateTime.Parse(fecha);
            Conexion c = new Conexion();
            DataTable dt = new DataTable();
            SqlConnection dataConnection = new SqlConnection(c.cadena());

            SqlCommand comando = new SqlCommand
            {
                Connection = dataConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_MOSTRAR_CALENDARIO"
            };
            dataConnection.Open();
            comando.Parameters.AddWithValue("@PIN_FECHA", SqlDbType.Date).Value = fechaParse.ToString("yyyy-MM-dd");
            fechaParse = fechaParse.AddDays(4);
            comando.Parameters.AddWithValue("@PIN_FECHA_TERMINO", SqlDbType.Date).Value = fechaParse.ToString("yyyy-MM-dd");
            comando.Parameters.AddWithValue("@PIN_SUPERVISOR", SqlDbType.Int).Value = supervisor;

            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            dataConnection.Close();

            return dt;
        } catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}