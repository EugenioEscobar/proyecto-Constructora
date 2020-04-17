using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosProyecto
/// </summary>
public class DatosProyecto
{
    public static bool AgregarProyecto(Proyecto obj)
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
                    CommandText = "P_REGISTRAR_PROYECTO"
                }
                )
                {
                    cmd.Parameters.AddWithValue("@PIN_SIGLA", SqlDbType.VarChar).Value = obj.Sigla;
                    cmd.Parameters.AddWithValue("@PIN_NOMBRE", SqlDbType.VarChar).Value = obj.NombreProyecto;
                    cmd.Parameters.AddWithValue("@PIN_DIRECCION", SqlDbType.VarChar).Value = obj.Direccion;
                    cmd.Parameters.AddWithValue("@PIN_CORREO", SqlDbType.VarChar).Value = obj.Correo;
                    cmd.Parameters.AddWithValue("@PIN_TELEFONO", SqlDbType.VarChar).Value = obj.Telefono;
                    cmd.Parameters.AddWithValue("@PIN_INMOBILIARIA", SqlDbType.Int).Value = obj.Inmobiliaria.Id;

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
    public static Proyecto BuscarProyecto(int codigo)
    {
        try
        {
            Proyecto obj = new Proyecto();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_PROYECTO"
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
            obj.Sigla = dt.Rows[0][1].ToString();
            obj.NombreProyecto = dt.Rows[0][2].ToString();
            obj.Direccion = dt.Rows[0][3].ToString();
            obj.Correo = dt.Rows[0][4].ToString();
            obj.Telefono = dt.Rows[0][5].ToString();
            obj.Inmobiliaria = DatosInmobiliaria.BuscarInmobiliaria(int.Parse(dt.Rows[0][6].ToString()));


            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public static Proyecto BuscarProyecto(string codigo)
    {
        try
        {
            Proyecto obj = new Proyecto();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_PROYECTO_POR_NOMBRE"
            };

            SqlParameter parametro = new SqlParameter
            {
                ParameterName = "@PIN_CODIGO",
                SqlDbType = SqlDbType.VarChar,
                Value = codigo
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
                obj.Sigla = dt.Rows[0][1].ToString();
                obj.NombreProyecto = dt.Rows[0][2].ToString();
                obj.Direccion = dt.Rows[0][3].ToString();
                obj.Correo = dt.Rows[0][4].ToString();
                obj.Telefono = dt.Rows[0][5].ToString();
                obj.Inmobiliaria = DatosInmobiliaria.BuscarInmobiliaria(int.Parse(dt.Rows[0][6].ToString()));
            }

            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public static DataTable CargarProyectoMantencion(int inmobiliaria)
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
                CommandText = "P_CARGAR_PROYECTO_MANTENCION"
            };
            comando.Parameters.AddWithValue("@PIN_INMOBILIARIA", SqlDbType.Int).Value = inmobiliaria;

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