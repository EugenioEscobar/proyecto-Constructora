using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosSupervisor
/// </summary>
public class DatosSupervisor
{
    public static bool AgregarSupervisor(Supervisor obj)
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
                    CommandText = "P_REGISTRAR_SUPERVISOR"
                })
                {
                    cmd.Parameters.AddWithValue("@PIN_RUT", SqlDbType.NVarChar).Value = obj.Rut;
                    cmd.Parameters.AddWithValue("@PIN_NOMBRE", SqlDbType.NVarChar).Value = obj.Nombre;
                    cmd.Parameters.AddWithValue("@PIN_APELLIDOP", SqlDbType.NVarChar).Value = obj.ApellidoPaterno;
                    cmd.Parameters.AddWithValue("@PIN_APELLIDOM", SqlDbType.NVarChar).Value = obj.ApellidoMaterno;
                    cmd.Parameters.AddWithValue("@PIN_CORREO", SqlDbType.NVarChar).Value = obj.Correo;
                    cmd.Parameters.AddWithValue("@PIN_DIRECCION", SqlDbType.NVarChar).Value = obj.Direccion;
                    cmd.Parameters.AddWithValue("@PIN_NUM_TELEFONO", SqlDbType.NVarChar).Value = obj.Telefono;
                    cmd.Parameters.AddWithValue("@PIN_COMUNA", SqlDbType.Int).Value = obj.Comuna;
                    cmd.Parameters.AddWithValue("@PIN_TIPO_SUPERVISOR", SqlDbType.TinyInt).Value = obj.TipoSuper;
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        agregado = true;
                    }
                    else
                    {
                        throw new Exception("Error al agregar Supervisor");
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
    public static bool ModificarSupervisor(Supervisor obj)
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
                    CommandText = "P_MODIFICAR_SUPERVISOR"
                }
                )
                {
                    cmd.Parameters.AddWithValue("@PIN_CODIGO", SqlDbType.Int).Value = obj.Id;
                    cmd.Parameters.AddWithValue("@PIN_RUT", SqlDbType.NVarChar).Value = obj.Rut;
                    cmd.Parameters.AddWithValue("@PIN_NOMBRE", SqlDbType.NVarChar).Value = obj.Nombre;
                    cmd.Parameters.AddWithValue("@PIN_APELLIDOP", SqlDbType.NVarChar).Value = obj.ApellidoPaterno;
                    cmd.Parameters.AddWithValue("@PIN_APELLIDOM", SqlDbType.NVarChar).Value = obj.ApellidoMaterno;
                    cmd.Parameters.AddWithValue("@PIN_CORREO", SqlDbType.NVarChar).Value = obj.Correo;
                    cmd.Parameters.AddWithValue("@PIN_DIRECCION", SqlDbType.NVarChar).Value = obj.Direccion;
                    cmd.Parameters.AddWithValue("@PIN_NUM_TELEFONO", SqlDbType.NVarChar).Value = obj.Telefono;
                    cmd.Parameters.AddWithValue("@PIN_COMUNA", SqlDbType.Int).Value = obj.Comuna;
                    cmd.Parameters.AddWithValue("@PIN_ESTADO", SqlDbType.TinyInt).Value = obj.Estado;
                    cmd.Parameters.AddWithValue("@PIN_TIPO_SUPERVISOR", SqlDbType.TinyInt).Value = obj.TipoSuper;

                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        agregado = true;
                    }
                    else
                    {
                        throw new Exception("Error al modificar Supervisor");
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

    public static Supervisor BuscarSupervisor(int codigo)
    {
        try
        {
            Supervisor obj = new Supervisor();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_SUPERVISOR"
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

            obj.Correo = dt.Rows[0][5].ToString();

            obj.Direccion = dt.Rows[0][6].ToString();

            obj.Telefono = dt.Rows[0][7].ToString();

            obj.Comuna = dt.Rows[0][8].ToString() != "" ? Convert.ToInt16(dt.Rows[0][8].ToString()) : 0;

            obj.Estado = Convert.ToInt16(dt.Rows[0][9].ToString());

            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static Supervisor BuscarSupervisor(string nombre)
    {
        try
        {
            Supervisor obj = new Supervisor();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_SUPERVISOR_POR_NOMBRE"
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
            obj.Id = Convert.ToInt16(dt.Rows[0][0].ToString());

            obj.Rut = dt.Rows[0][1].ToString();

            obj.Nombre = dt.Rows[0][2].ToString();

            obj.ApellidoPaterno = dt.Rows[0][3].ToString();

            obj.ApellidoMaterno = dt.Rows[0][4].ToString();

            obj.Correo = dt.Rows[0][5].ToString();

            obj.Direccion = dt.Rows[0][6].ToString();

            obj.Telefono = dt.Rows[0][7].ToString();

            obj.Comuna = dt.Rows[0][8].ToString() != "" ? Convert.ToInt16(dt.Rows[0][8].ToString()) : 0;

            obj.Estado = Convert.ToInt16(dt.Rows[0][9].ToString());

            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static DataTable ListarSupervisor()
    {
        try
        {
            Conexion c = new Conexion();
            DataTable dt = new DataTable();
            SqlConnection dataConnection = new SqlConnection(c.cadena());
            SqlDataAdapter da = new SqlDataAdapter("P_LISTAR_SUPERVISOR", dataConnection);
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

    public static DataTable CargarSupervisorObservacion(int proyecto)
    {
        try
        {
            Supervisor obj = new Supervisor();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_CARGAR_SUPERVISOR_MANTENCION"
            };
            comando.Parameters.AddWithValue("@PIN_PROYECTO", SqlDbType.Int).Value = proyecto;

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

    public static DataTable CargarSupervisorObservacion()
    {
        try
        {
            Supervisor obj = new Supervisor();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_CARGAR_SUPERVISOR_MANTENCION"
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

    public static DataTable CargarSupervisorPorFecha(string fechaInicio, string fechaTermino)
    {
        try
        {
            Supervisor obj = new Supervisor();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_CARGAR_SUPERVISOR_POR_FECHAS"
            };
            comando.Parameters.AddWithValue("@PIN_FECHA_INCIO", SqlDbType.Date).Value = fechaInicio;
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