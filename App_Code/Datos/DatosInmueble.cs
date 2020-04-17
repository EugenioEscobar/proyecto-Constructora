using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosInmueble
/// </summary>
public class DatosInmueble
{
    public static bool AgregarInmueble(Inmueble obj)
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
                    CommandText = "P_REGISTRAR_INMUEBLE"
                }
                )
                {
                    cmd.Parameters.AddWithValue("@PIN_CONDOMINIO", SqlDbType.Int).Value = obj.Condominio.Id;
                    cmd.Parameters.AddWithValue("@PIN_NUM_INMUEBLE", SqlDbType.VarChar).Value = obj.NumInmueble;
                    cmd.Parameters.AddWithValue("@PIN_ETAPA", SqlDbType.Int).Value = obj.Etapa.Id;
                    cmd.Parameters.AddWithValue("@PIN_PROYECTO", SqlDbType.Int).Value = obj.Proyecto.Id;
                    cmd.Parameters.AddWithValue("@PIN_TIPO_INMUEBLE", SqlDbType.Int).Value = obj.TipoInmueble.Id;
                    

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

    public static Inmueble BuscarInmueble(int codigo)
    {
        try
        {
            Inmueble obj = new Inmueble();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_INMUEBLE"
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
            if (dt.Rows.Count > 0)
            {
                obj.Id = int.Parse(dt.Rows[0][0].ToString());
                obj.Condominio = DatosCondominio.BuscarCondominio(int.Parse(dt.Rows[0][1].ToString()));
                obj.NumInmueble = dt.Rows[0][2].ToString();
                obj.Etapa = DatosEtapa.BuscarEtapa(int.Parse(dt.Rows[0][3].ToString()));
                obj.Proyecto = DatosProyecto.BuscarProyecto(int.Parse(dt.Rows[0][4].ToString()));
                obj.TipoInmueble = DatosTipoInmueble.BuscarTipoInmueble(int.Parse(dt.Rows[0][5].ToString()));
                obj.Estado = dt.Rows[0][6].ToString().First();
            }
            else
            {
                obj = new Inmueble()
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

    public static Inmueble BuscarInmueble(string codigo, int proyecto)
    {
        try
        {
            Inmueble obj = new Inmueble();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_INMUEBLE_POR_NOMBRE"
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
            if (dt.Rows.Count > 0 && dt.Rows.Count < 2)
            {
                obj.Id = int.Parse(dt.Rows[0][0].ToString());
                obj.Condominio = DatosCondominio.BuscarCondominio(int.Parse(dt.Rows[0][1].ToString()));
                obj.NumInmueble = dt.Rows[0][2].ToString();
                obj.Etapa = DatosEtapa.BuscarEtapa(int.Parse(dt.Rows[0][3].ToString()));
                obj.Proyecto = DatosProyecto.BuscarProyecto(int.Parse(dt.Rows[0][4].ToString()));
                obj.TipoInmueble = DatosTipoInmueble.BuscarTipoInmueble(int.Parse(dt.Rows[0][5].ToString()));
                obj.Estado = dt.Rows[0][6].ToString().First();
            }
            else if (dt.Rows.Count > 1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][4].ToString() == proyecto.ToString())
                    {
                        obj.Id = int.Parse(dt.Rows[i][0].ToString());
                        obj.Condominio = DatosCondominio.BuscarCondominio(int.Parse(dt.Rows[i][1].ToString()));
                        obj.NumInmueble = dt.Rows[i][2].ToString();
                        obj.Etapa = DatosEtapa.BuscarEtapa(int.Parse(dt.Rows[i][3].ToString()));
                        obj.Proyecto = DatosProyecto.BuscarProyecto(int.Parse(dt.Rows[i][4].ToString()));
                        obj.TipoInmueble = DatosTipoInmueble.BuscarTipoInmueble(int.Parse(dt.Rows[i][5].ToString()));
                        obj.Estado = dt.Rows[i][6].ToString().First();
                    }
                }
            }
            else
            {
                obj = new Inmueble()
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

    public static DataTable CargarInmuebleMantencion(int proyecto)
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
                CommandText = "P_CARGAR_INMUEBLE_MANTENCION"
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
}