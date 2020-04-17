using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosPropietario
/// </summary>
public class DatosPropietario
{
    public static bool AgregarPropietario(Propietario obj)
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
                    CommandText = "P_REGISTRAR_PROPIETARIO"
                })
                {
                    cmd.Parameters.AddWithValue("@PIN_RUT", SqlDbType.NChar).Value = obj.Rut;
                    cmd.Parameters.AddWithValue("@PIN_NOMBRE", SqlDbType.NChar).Value = obj.Nombre;
                    cmd.Parameters.AddWithValue("@PIN_APEPAT", SqlDbType.NChar).Value = obj.ApellidoPaterno;
                    cmd.Parameters.AddWithValue("@PIN_APEMAT", SqlDbType.NChar).Value = obj.ApellidoMaterno;
                    cmd.Parameters.AddWithValue("@PIN_DIRECCION", SqlDbType.NChar).Value = obj.Direccion;
                    cmd.Parameters.AddWithValue("@PIN_COMUNA", SqlDbType.NChar).Value = obj.Comuna;
                    cmd.Parameters.AddWithValue("@PIN_TELEFONO", SqlDbType.NChar).Value = obj.Telefono;
                    cmd.Parameters.AddWithValue("@PIN_CORREO", SqlDbType.NChar).Value = obj.Correo;

                    //cmd.Parameters[0].IsNullable = true;
                    //cmd.Parameters[2].IsNullable = true;
                    //cmd.Parameters[3].IsNullable = true;
                    //cmd.Parameters[4].IsNullable = true;
                    //cmd.Parameters[5].IsNullable = true;
                    //cmd.Parameters[6].IsNullable = true;
                    //cmd.Parameters[7].IsNullable = true;
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        agregado = true;
                    }
                    else
                    {
                        throw new Exception("Error al agregar Propietario");
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
    public static bool ModificarPropietario(Propietario obj)
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
                    CommandText = "P_MODIFICAR_PROPIETARIO"
                }
                )
                {
                    cmd.Parameters.AddWithValue("@PIN_CODIGO", SqlDbType.Int).Value = obj.Id;
                    cmd.Parameters.AddWithValue("@PIN_RUT", SqlDbType.NChar).Value = obj.Rut;
                    cmd.Parameters.AddWithValue("@PIN_NOMBRE", SqlDbType.NChar).Value = obj.Nombre;
                    cmd.Parameters.AddWithValue("@PIN_APEPAT", SqlDbType.NChar).Value = obj.ApellidoPaterno;
                    cmd.Parameters.AddWithValue("@PIN_APEMAT", SqlDbType.NChar).Value = obj.ApellidoMaterno;
                    cmd.Parameters.AddWithValue("@PIN_DIRECCION", SqlDbType.NChar).Value = obj.Direccion;
                    cmd.Parameters.AddWithValue("@PIN_COMUNA", SqlDbType.NChar).Value = obj.Comuna;
                    cmd.Parameters.AddWithValue("@PIN_TELEFONO", SqlDbType.NChar).Value = obj.Telefono;
                    cmd.Parameters.AddWithValue("@PIN_CORREO", SqlDbType.NChar).Value = obj.Correo;
                    cmd.Parameters.AddWithValue("@PIN_ESTADO", SqlDbType.TinyInt).Value = obj.Estado;

                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        agregado = true;
                    }
                    else
                    {
                        throw new Exception("Error al modificar Propietario");
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

    public static Propietario BuscarPropietario(int codigo)
    {
        try
        {
            Propietario obj = new Propietario();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_PROPIETARIO"
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
            obj.Comuna = Convert.ToInt16(dt.Rows[0][6].ToString());
            obj.Telefono = dt.Rows[0][7].ToString();
            obj.Correo = dt.Rows[0][8].ToString();
            obj.Estado = Convert.ToInt16(dt.Rows[0][9].ToString());

            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
    
    public static Propietario BuscarPropietario(string nombre)
    {
        try
        {
            Propietario obj = new Propietario();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_PROPIETARIO_POR_NOMBRE"
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
            if (dt.Rows.Count > 0)
            {
                obj.Id = Convert.ToInt16(dt.Rows[0][0].ToString());

                obj.Rut = dt.Rows[0][1].ToString();

                obj.Nombre = dt.Rows[0][2].ToString();

                obj.ApellidoPaterno = dt.Rows[0][3].ToString();

                obj.ApellidoMaterno = dt.Rows[0][4].ToString();

                obj.Direccion = dt.Rows[0][5].ToString();

                obj.Comuna = dt.Rows[0][6].ToString() != "" ? Convert.ToInt16(dt.Rows[0][6].ToString()) : 0;

                obj.Telefono = dt.Rows[0][7].ToString();

                obj.Correo = dt.Rows[0][8].ToString();

                obj.Estado = Convert.ToInt16(dt.Rows[0][9].ToString());
            }
            else
            {
                obj = new Propietario()
                {
                    Id = 0
                };
            }
            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static DataTable ListarPropietario()
    {
        try
        {
            Conexion c = new Conexion();
            DataTable dt = new DataTable();
            SqlConnection dataConnection = new SqlConnection(c.cadena());
            SqlDataAdapter da = new SqlDataAdapter("P_LISTAR_PROPIETARIO", dataConnection);
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