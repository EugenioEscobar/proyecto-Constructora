using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosInmobiliaria
/// </summary>
public class DatosInmobiliaria
{
    public static bool AgregarInmobiliaria(Inmobiliaria obj)
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
                    CommandText = "P_REGISTRAR_INMOBILIARIA"
                }
                )
                {
                    cmd.Parameters.AddWithValue("@PIN_RUT", SqlDbType.VarChar).Value = obj.Rut;
                    cmd.Parameters.AddWithValue("@PIN_NOMBRE", SqlDbType.VarChar).Value = obj.Nombre;
                    cmd.Parameters.AddWithValue("@PIN_RAZON_SOCIAL", SqlDbType.VarChar).Value = obj.RazonSocial;
                    cmd.Parameters.AddWithValue("@PIN_DIRECCION", SqlDbType.VarChar).Value = obj.Direccion;
                    cmd.Parameters.AddWithValue("@PIN_CORREO", SqlDbType.VarChar).Value = obj.Correo;
                    cmd.Parameters.AddWithValue("@PIN_PAGINA_WEB", SqlDbType.VarChar).Value = obj.PaginaWeb;
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

    public static bool ModificarInmobiliaria(Inmobiliaria obj)
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
                    CommandText = "P_MODIFICAR_INMOBILIARIA"
                }
                )
                {
                    cmd.Parameters.AddWithValue("@PIN_CODIGO", SqlDbType.VarChar).Value = obj.Id;
                    cmd.Parameters.AddWithValue("@PIN_RUT", SqlDbType.VarChar).Value = obj.Rut;
                    cmd.Parameters.AddWithValue("@PIN_NOMBRE", SqlDbType.VarChar).Value = obj.Nombre;
                    cmd.Parameters.AddWithValue("@PIN_RAZON_SOCIAL", SqlDbType.VarChar).Value = obj.RazonSocial;
                    cmd.Parameters.AddWithValue("@PIN_DIRECCION", SqlDbType.VarChar).Value = obj.Direccion;
                    cmd.Parameters.AddWithValue("@PIN_CORREO", SqlDbType.VarChar).Value = obj.Correo;
                    cmd.Parameters.AddWithValue("@PIN_PAGINA_WEB", SqlDbType.VarChar).Value = obj.PaginaWeb;
                    cmd.Parameters.AddWithValue("@PIN_COMUNA", SqlDbType.TinyInt).Value = obj.Comuna;
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

    public static Inmobiliaria BuscarInmobiliaria(int codigo)
    {
        try
        {
            Inmobiliaria obj = new Inmobiliaria();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_INMOBILIARIA"
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
            obj.Rut = dt.Rows[0][1].ToString();
            obj.Nombre = dt.Rows[0][2].ToString();
            obj.RazonSocial = dt.Rows[0][3].ToString();
            obj.Direccion = dt.Rows[0][4].ToString();
            obj.Correo = dt.Rows[0][5].ToString();
            obj.PaginaWeb = dt.Rows[0][6].ToString();
            obj.Comuna = int.Parse(dt.Rows[0][7].ToString());
            obj.Estado = int.Parse(dt.Rows[0][8].ToString());

            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static Inmobiliaria BuscarInmobiliaria(string nombre)
    {
        try
        {
            Inmobiliaria obj = new Inmobiliaria();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_INMOBILIARIA_POR_NOMBRE"
            };

            SqlParameter parametro = new SqlParameter
            {
                ParameterName = "@PIN_NOMBRE",
                SqlDbType = SqlDbType.VarChar,
                Value = nombre
            };

            comando.Parameters.Add(parametro);
            SqlDataAdapter myDA = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            myDA.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                obj.Id = 0;
            }
            else
            {
                obj.Id = int.Parse(dt.Rows[0][0].ToString());
                obj.Rut = dt.Rows[0][1].ToString();
                obj.Nombre = dt.Rows[0][2].ToString();
                obj.RazonSocial = dt.Rows[0][3].ToString();
                obj.Direccion = dt.Rows[0][4].ToString();
                obj.Correo = dt.Rows[0][5].ToString();
                obj.PaginaWeb = dt.Rows[0][6].ToString();
                obj.Comuna = int.Parse(dt.Rows[0][7].ToString());
                obj.Estado = int.Parse(dt.Rows[0][8].ToString());
            }
            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public static DataTable ListarInmobiliarias()
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
                CommandText = "P_LISTAR_INMOBILIARIA"
            };

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
    public static DataTable CargarInmobiliarias()
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
                CommandText = "P_CARGAR_INMOBILIARIA"
            };

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
    
    public static DataTable CargarInmobiliariaMantencion()
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
                CommandText = "P_CARGAR_INMOBILIARIA_MANTENCION"
            };

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