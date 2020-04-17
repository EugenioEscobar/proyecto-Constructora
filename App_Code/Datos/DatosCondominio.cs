using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosCondominio
/// </summary>
public class DatosCondominio
{
    public static bool AgregarCondominio(Condominio obj)
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
                    CommandText = "P_REGISTRAR_CONDOMINIO"
                }
                )
                {
                    cmd.Parameters.AddWithValue("@PIN_RUT", SqlDbType.VarChar).Value = obj.Rut;
                    cmd.Parameters.AddWithValue("@PIN_NOMBRE", SqlDbType.VarChar).Value = obj.Nombre;
                    cmd.Parameters.AddWithValue("@PIN_RAZONSOCIAL", SqlDbType.VarChar).Value = obj.RazonSocial;
                    cmd.Parameters.AddWithValue("@PIN_DIRECCION", SqlDbType.VarChar).Value = obj.Direccion;
                    cmd.Parameters.AddWithValue("@PIN_CORREO", SqlDbType.VarChar).Value = obj.Correo;
                    cmd.Parameters.AddWithValue("@PIN_PAGWEB", SqlDbType.VarChar).Value = obj.PaginaWeb;
                    cmd.Parameters.AddWithValue("@PIN_COMUNA", SqlDbType.Int).Value = obj.Comuna;

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

    public static bool ModificarCondominio(Condominio obj)
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
                    CommandText = "P_MODIFICAR_CONDOMINIO"
                }
                )
                {
                    cmd.Parameters.AddWithValue("@PIN_CODIGO", SqlDbType.VarChar).Value = obj.Id;
                    cmd.Parameters.AddWithValue("@PIN_RUT", SqlDbType.VarChar).Value = obj.Rut;
                    cmd.Parameters.AddWithValue("@PIN_NOMBRE", SqlDbType.VarChar).Value = obj.Nombre;
                    cmd.Parameters.AddWithValue("@PIN_RAZONSOCIAL", SqlDbType.VarChar).Value = obj.RazonSocial;
                    cmd.Parameters.AddWithValue("@PIN_DIRECCION", SqlDbType.VarChar).Value = obj.Direccion;
                    cmd.Parameters.AddWithValue("@PIN_CORREO", SqlDbType.VarChar).Value = obj.Correo;
                    cmd.Parameters.AddWithValue("@PIN_PAGWEB", SqlDbType.VarChar).Value = obj.PaginaWeb;
                    cmd.Parameters.AddWithValue("@PIN_COMUNA", SqlDbType.Int).Value = obj.Comuna;
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

    public static Condominio BuscarCondominio(int codigo)
    {
        try
        {
            Condominio obj = new Condominio();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_CONDOMINIO"
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
            obj.Id = Convert.ToInt32(dt.Rows[0][0].ToString());
            obj.Rut = dt.Rows[0][1].ToString();
            obj.Nombre = dt.Rows[0][2].ToString();
            obj.RazonSocial = dt.Rows[0][3].ToString();
            obj.Direccion = dt.Rows[0][4].ToString();
            obj.Correo = dt.Rows[0][5].ToString();
            obj.PaginaWeb = dt.Rows[0][6].ToString();
            obj.Comuna = Convert.ToInt16(dt.Rows[0][7].ToString());
            obj.Estado = Convert.ToInt32(dt.Rows[0][8].ToString());
            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static DataTable ListarCondominio()
    {
        try
        {
            Conexion c = new Conexion();
            DataTable dt = new DataTable();
            SqlConnection dataConnection = new SqlConnection(c.cadena());
            SqlDataAdapter da = new SqlDataAdapter("P_LISTAR_CONDOMINIO", dataConnection);
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