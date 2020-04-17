using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosMaestros
/// </summary>
public class DatosMaestro
{
    public static bool AgregarMaestro(Maestro obj)
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
                    CommandText = "P_REGISTRAR_MAESTRO"
                })
                {
                    cmd.Parameters.AddWithValue("@PIN_RUT", SqlDbType.NChar).Value = obj.Rut;
                    cmd.Parameters.AddWithValue("@PIN_NOMBRE", SqlDbType.NChar).Value = obj.Nombre;
                    cmd.Parameters.AddWithValue("@PIN_APEPAT", SqlDbType.NChar).Value = obj.ApellidoPaterno;
                    cmd.Parameters.AddWithValue("@PIN_APEMAT", SqlDbType.NChar).Value = obj.ApellidoMaterno;
                    cmd.Parameters.AddWithValue("@PIN_DIRECCION", SqlDbType.NChar).Value = obj.Direccion;
                    cmd.Parameters.AddWithValue("@PIN_TELEFONO", SqlDbType.NChar).Value = obj.Telefono;
                    cmd.Parameters.AddWithValue("@PIN_COMUNA", SqlDbType.NChar).Value = obj.Comuna;
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        agregado = true;
                    }
                    else
                    {
                        throw new Exception("Error al agregar Maestro");
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
    public static bool ModificarMaestro(Maestro obj)
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
                    CommandText = "P_MODIFICAR_MAESTRO"
                }
                )
                {
                    cmd.Parameters.AddWithValue("@PIN_CODIGO", SqlDbType.Int).Value = obj.Id;
                    cmd.Parameters.AddWithValue("@PIN_RUT", SqlDbType.NChar).Value = obj.Rut;
                    cmd.Parameters.AddWithValue("@PIN_NOMBRE", SqlDbType.NChar).Value = obj.Nombre;
                    cmd.Parameters.AddWithValue("@PIN_APEPAT", SqlDbType.NChar).Value = obj.ApellidoPaterno;
                    cmd.Parameters.AddWithValue("@PIN_APEMAT", SqlDbType.NChar).Value = obj.ApellidoMaterno;
                    cmd.Parameters.AddWithValue("@PIN_DIRECCION", SqlDbType.NChar).Value = obj.Direccion;
                    cmd.Parameters.AddWithValue("@PIN_TELEFONO", SqlDbType.NChar).Value = obj.Telefono;
                    cmd.Parameters.AddWithValue("@PIN_COMUNA", SqlDbType.NChar).Value = obj.Comuna;
                    cmd.Parameters.AddWithValue("@PIN_ESTADO", SqlDbType.TinyInt).Value = obj.Estado;

                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        agregado = true;
                    }
                    else
                    {
                        throw new Exception("Error al modificar Maestro");
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

    public static Maestro BuscarMaestro(int codigo)
    {
        try
        {
            Maestro obj = new Maestro();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_MAESTRO"
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
            obj.Rut = dt.Rows[0][1].ToString();
            obj.Nombre = dt.Rows[0][2].ToString();
            obj.ApellidoPaterno = dt.Rows[0][3].ToString();
            obj.ApellidoMaterno = dt.Rows[0][4].ToString();
            obj.Direccion = dt.Rows[0][5].ToString();
            obj.Telefono = dt.Rows[0][6].ToString();
            obj.Comuna = dt.Rows[0][7].ToString() != "" ? Convert.ToInt16(dt.Rows[0][7].ToString()) : 0;
            obj.Estado = dt.Rows[0][7].ToString() != "" ? Convert.ToInt16(dt.Rows[0][8].ToString()) : 0;

            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static DataTable ListarMaestro()
    {
        try
        {
            Conexion c = new Conexion();
            DataTable dt = new DataTable();
            SqlConnection dataConnection = new SqlConnection(c.cadena());
            SqlDataAdapter da = new SqlDataAdapter("P_LISTAR_MAESTRO", dataConnection);
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