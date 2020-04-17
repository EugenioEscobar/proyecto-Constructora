using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DatosObservacion
/// </summary>
public class DatosObservacion
{
    public static bool AgregarObservacion(Observacion obj)
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
                    CommandText = "P_REGISTRAR_OBSERVACION"
                })
                {
                    cmd.Parameters.AddWithValue("@PIN_SUPERVISOR_CONSTR", SqlDbType.Int).Value = obj.SupervisorConstructora.Id;
                    cmd.Parameters.AddWithValue("@PIN_SUPERVISOR_INMOBI", SqlDbType.Int).Value = obj.SupervisorInmobiliaria.Id;
                    cmd.Parameters.AddWithValue("@PIN_MAESTRO", SqlDbType.Int).Value = obj.Maestro.Id;
                    cmd.Parameters.AddWithValue("@PIN_PARTIDA", SqlDbType.Int).Value = obj.Partida.Id;
                    cmd.Parameters.AddWithValue("@PIN_CAUSA", SqlDbType.Int).Value = obj.Causa.Id;
                    cmd.Parameters.AddWithValue("@PIN_RECINTO", SqlDbType.Int).Value = obj.Recinto.Id;
                    cmd.Parameters.AddWithValue("@PIN_PROPIETARIO", SqlDbType.Int).Value = obj.Propietario.Id;
                    //cmd.Parameters.AddWithValue("@PIN_ESTADO", SqlDbType.Int).Value = obj.Estado.Id;
                    cmd.Parameters.AddWithValue("@PIN_ESTADO_REPARACION", SqlDbType.Int).Value = obj.EstadoReparacion.Id;
                    cmd.Parameters.AddWithValue("@PIN_FECHA_OBSERVACION", SqlDbType.Date).Value = obj.FechaObservacion;
                    cmd.Parameters.AddWithValue("@PIN_SECUENCIA", SqlDbType.SmallInt).Value = obj.Secuencia;
                    cmd.Parameters.AddWithValue("@PIN_INMUEBLE", SqlDbType.Int).Value = obj.Inmueble.Id;
                    cmd.Parameters.AddWithValue("@PIN_OBSERVACION", SqlDbType.NChar).Value = obj.DescObservacion;
                    cmd.Parameters.AddWithValue("@PIN_RUT", SqlDbType.NVarChar).Value = obj.RutPropietario;
                    cmd.Parameters.AddWithValue("@PIN_FECHA_ENTREGA", SqlDbType.Date).Value = obj.FechaEntrega;
                    cmd.Parameters.AddWithValue("@PIN_RESIDENTE", SqlDbType.NChar).Value = obj.NombreResidente;
                    cmd.Parameters.AddWithValue("@PIN_TELEFONO", SqlDbType.NChar).Value = obj.TelefonoResidente;
                    cmd.Parameters.AddWithValue("@PIN_FECHA_COORDINACION", SqlDbType.Date).Value = obj.FechaCoordinacion;
                    cmd.Parameters.AddWithValue("@PIN_HORA_INICIO", SqlDbType.Int).Value = obj.HoraInicio.Id;
                    cmd.Parameters.AddWithValue("@PIN_CORR_ACTA", SqlDbType.SmallInt).Value = obj.CorrActa;
                    cmd.Parameters.AddWithValue("@PIN_REPARACION", SqlDbType.NVarChar).Value = obj.Reparacion;
                    cmd.Parameters.AddWithValue("@PIN_ESTATUS", SqlDbType.Int).Value = obj.Estatus;
                    cmd.Parameters.AddWithValue("@PIN_FECHA_CIERRE", SqlDbType.Date).Value = obj.FechaCierre;
                    cmd.Parameters.AddWithValue("@PIN_TIPO_OBSERVACION", SqlDbType.Int).Value = obj.TipoObservacion.Id;
                    cmd.Parameters.AddWithValue("@PIN_FECHA_COORDINACION2", SqlDbType.Date).Value = obj.FechaCoordinacion;
                    cmd.Parameters.AddWithValue("@PIN_HORA_INICIO2", SqlDbType.Int).Value = obj.HoraInicio2.Id;
                    //cmd.Parameters.AddWithValue("@PIN_FECHA_CREACION", SqlDbType.Date).Value = DateTime.Today.ToString();
                    cmd.Parameters.AddWithValue("@PIN_HORA_TERMINO", SqlDbType.Int).Value = obj.HoraTermino.Id;
                    cmd.Parameters.AddWithValue("@PIN_HORA_TERMINO2", SqlDbType.Int).Value = obj.HoraTermino2.Id;
                    cmd.Parameters.AddWithValue("@PIN_TIPO_HORARIO", SqlDbType.Int).Value = obj.TipoHorario;
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        agregado = true;
                    }
                    else
                    {
                        throw new Exception("Error al agregar Observacion");
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

    public static bool ModificarObservacion(Observacion obj)
    {
        try
        {
            DateTime fechaParse;
            bool agregado;
            Conexion c = new Conexion();
            string servidor = c.cadena();
            using (SqlConnection conn = new SqlConnection(servidor))
            {
                using (SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "P_MODIFICAR_OBSERVACION"
                })
                {
                    cmd.Parameters.AddWithValue("@PIN_CODIGO", SqlDbType.Int).Value = obj.Id;
                    cmd.Parameters.AddWithValue("@PIN_SUPERVISOR_CONSTR", SqlDbType.Int).Value = obj.SupervisorConstructora.Id;
                    cmd.Parameters.AddWithValue("@PIN_SUPERVISOR_INMOBI", SqlDbType.Int).Value = obj.SupervisorInmobiliaria.Id;
                    cmd.Parameters.AddWithValue("@PIN_MAESTRO", SqlDbType.Int).Value = obj.Maestro.Id;
                    cmd.Parameters.AddWithValue("@PIN_PARTIDA", SqlDbType.Int).Value = obj.Partida.Id;
                    cmd.Parameters.AddWithValue("@PIN_CAUSA", SqlDbType.Int).Value = obj.Causa.Id;
                    cmd.Parameters.AddWithValue("@PIN_RECINTO", SqlDbType.Int).Value = obj.Recinto.Id;
                    cmd.Parameters.AddWithValue("@PIN_PROPIETARIO", SqlDbType.Int).Value = obj.Propietario.Id;
                    cmd.Parameters.AddWithValue("@PIN_ESTADO", SqlDbType.Int).Value = obj.Estado;
                    cmd.Parameters.AddWithValue("@PIN_ESTADO_REPARACION", SqlDbType.Int).Value = obj.EstadoReparacion.Id;
                    fechaParse = DateTime.Parse(obj.FechaObservacion);
                    cmd.Parameters.AddWithValue("@PIN_FECHA_OBSERVACION", SqlDbType.Date).Value = fechaParse.ToString("yyyy-MM-dd");
                    cmd.Parameters.AddWithValue("@PIN_SECUENCIA", SqlDbType.SmallInt).Value = obj.Secuencia;
                    cmd.Parameters.AddWithValue("@PIN_INMUEBLE", SqlDbType.Int).Value = obj.Inmueble.Id;
                    cmd.Parameters.AddWithValue("@PIN_OBSERVACION", SqlDbType.NChar).Value = obj.DescObservacion;
                    cmd.Parameters.AddWithValue("@PIN_RUT", SqlDbType.NVarChar).Value = obj.RutPropietario;
                    fechaParse = DateTime.Parse(obj.FechaEntrega);
                    cmd.Parameters.AddWithValue("@PIN_FECHA_ENTREGA", SqlDbType.Date).Value = fechaParse.ToString("yyyy-MM-dd");
                    cmd.Parameters.AddWithValue("@PIN_RESIDENTE", SqlDbType.NChar).Value = obj.NombreResidente;
                    cmd.Parameters.AddWithValue("@PIN_TELEFONO", SqlDbType.NChar).Value = obj.TelefonoResidente;
                    fechaParse = DateTime.Parse(obj.FechaCoordinacion);
                    cmd.Parameters.AddWithValue("@PIN_FECHA_COORDINACION", SqlDbType.Date).Value = fechaParse.ToString("yyyy-MM-dd");
                    cmd.Parameters.AddWithValue("@PIN_HORA_INICIO", SqlDbType.Int).Value = obj.HoraInicio.Id;
                    cmd.Parameters.AddWithValue("@PIN_CORR_ACTA", SqlDbType.SmallInt).Value = obj.CorrActa;
                    cmd.Parameters.AddWithValue("@PIN_REPARACION", SqlDbType.NVarChar).Value = obj.Reparacion;
                    cmd.Parameters.AddWithValue("@PIN_ESTATUS", SqlDbType.Int).Value = obj.Estatus;
                    fechaParse = DateTime.Parse(obj.FechaCierre);
                    cmd.Parameters.AddWithValue("@PIN_FECHA_CIERRE", SqlDbType.Date).Value = fechaParse.ToString("yyyy-MM-dd");
                    cmd.Parameters.AddWithValue("@PIN_TIPO_OBSERVACION", SqlDbType.Int).Value = obj.TipoObservacion.Id;
                    fechaParse = DateTime.Parse(obj.FechaCoordinacion);
                    cmd.Parameters.AddWithValue("@PIN_FECHA_COORDINACION2", SqlDbType.Date).Value = fechaParse.ToString("yyyy-MM-dd");
                    cmd.Parameters.AddWithValue("@PIN_HORA_INICIO2", SqlDbType.Int).Value = obj.HoraInicio2.Id;
                    //cmd.Parameters.AddWithValue("@PIN_FECHA_CREACION", SqlDbType.Date).Value = DateTime.Today.ToString();
                    cmd.Parameters.AddWithValue("@PIN_HORA_TERMINO", SqlDbType.Int).Value = obj.HoraTermino.Id;
                    cmd.Parameters.AddWithValue("@PIN_HORA_TERMINO2", SqlDbType.Int).Value = obj.HoraTermino2.Id;
                    cmd.Parameters.AddWithValue("@PIN_TIPO_HORARIO", SqlDbType.Int).Value = obj.TipoHorario;
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        agregado = true;
                    }
                    else
                    {
                        throw new Exception("Error al modificar Observacion");
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


    public static Observacion BuscarObservacion(int codigo)
    {
        try
        {
            Observacion obj = new Observacion();

            Conexion c = new Conexion();

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_BUSCAR_OBSERVACION"
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
            obj.SupervisorConstructora = DatosSupervisor.BuscarSupervisor(int.Parse(dt.Rows[0][1].ToString()));
            obj.SupervisorInmobiliaria = DatosSupervisor.BuscarSupervisor(int.Parse(dt.Rows[0][2].ToString()));
            obj.Maestro = DatosMaestro.BuscarMaestro(int.Parse(dt.Rows[0][3].ToString()));
            obj.Partida = DatosPartida.BuscarPartida(int.Parse(dt.Rows[0][4].ToString()));
            obj.Causa = DatosCausa.BuscarCausa(int.Parse(dt.Rows[0][5].ToString()));
            obj.Recinto = DatosRecinto.BuscarRecinto(int.Parse(dt.Rows[0][6].ToString()));
            obj.Propietario = DatosPropietario.BuscarPropietario(int.Parse(dt.Rows[0][7].ToString()));
            obj.Estado = int.Parse(dt.Rows[0][8].ToString());
            obj.EstadoReparacion = DatosEstadoReparacion.BuscarEstadoReparacion(int.Parse(dt.Rows[0][9].ToString()));
            obj.FechaObservacion = dt.Rows[0][10].ToString();
            obj.Secuencia = int.Parse(dt.Rows[0][11].ToString());
            obj.Inmueble = DatosInmueble.BuscarInmueble(int.Parse(dt.Rows[0][12].ToString()));
            obj.DescObservacion = dt.Rows[0][13].ToString();
            obj.RutPropietario = dt.Rows[0][14].ToString();
            obj.FechaEntrega = dt.Rows[0][15].ToString();
            obj.NombreResidente = dt.Rows[0][16].ToString();
            obj.TelefonoResidente = dt.Rows[0][17].ToString();
            obj.FechaCoordinacion = dt.Rows[0][18].ToString();
            obj.HoraInicio = DatosHoras.BuscarHora(int.Parse(dt.Rows[0][19].ToString()));
            string asdasd = dt.Rows[0][20].ToString();
            obj.CorrActa = int.Parse(dt.Rows[0][20].ToString());
            obj.Reparacion = dt.Rows[0][21].ToString();
            obj.Estatus = dt.Rows[0][22].ToString() != "" ? int.Parse(dt.Rows[0][22].ToString()) : 0;
            obj.FechaCierre = dt.Rows[0][23].ToString();
            asdasd = dt.Rows[0][24].ToString();
            obj.TipoObservacion = DatosTipoObservacion.BuscarTipoObservacion(int.Parse(dt.Rows[0][24].ToString()));
            obj.FechaCoordinacion2 = dt.Rows[0][25].ToString();
            obj.HoraInicio2 = DatosHoras.BuscarHora(int.Parse(dt.Rows[0][26].ToString()));
            obj.FechaCreacion = dt.Rows[0][27].ToString();
            obj.HoraTermino = DatosHoras.BuscarHora(int.Parse(dt.Rows[0][28].ToString()));
            obj.HoraTermino2 = DatosHoras.BuscarHora(int.Parse(dt.Rows[0][29].ToString()));
            obj.TipoHorario = int.Parse(dt.Rows[0][30].ToString());
            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static DataTable ListarMantienconObs(int inmueble, int supervisor, int proyecto, string fechaInicio, string fechaTermino)
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
                CommandText = "P_LISTAR_MANTENCIONOBS"
            };
            comando.Parameters.AddWithValue("@PIN_PROYECTO", SqlDbType.Int).Value = proyecto;
            comando.Parameters.AddWithValue("@PIN_INMUEBLE", SqlDbType.Int).Value = inmueble;
            comando.Parameters.AddWithValue("@PIN_SUPERVISOR", SqlDbType.Int).Value = supervisor;
            //Fecha por definicion para comparar en la base de datos
            fechaInicio = fechaInicio == "" ? "1000-01-01" : fechaInicio;
            fechaTermino = fechaTermino == "" ? "1000-01-01" : fechaTermino;
            comando.Parameters.AddWithValue("@PIN_FECHA_INICIO", SqlDbType.Date).Value = fechaInicio;
            comando.Parameters.AddWithValue("@PIN_FECHA_TERMINO", SqlDbType.Date).Value = fechaTermino;
            comando.Parameters.AddWithValue("@PIN_STATUS", SqlDbType.Int).Value = DBNull.Value;

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

    public static DataTable ListarMantienconObs(int inmueble, int supervisor, int proyecto, string fechaInicio, string fechaTermino,int status)
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
                CommandText = "P_LISTAR_MANTENCIONOBS"
            };
            comando.Parameters.AddWithValue("@PIN_PROYECTO", SqlDbType.Int).Value = proyecto;
            comando.Parameters.AddWithValue("@PIN_INMUEBLE", SqlDbType.Int).Value = inmueble;
            comando.Parameters.AddWithValue("@PIN_SUPERVISOR", SqlDbType.Int).Value = supervisor;
            //Fecha por definicion para comparar en la base de datos
            fechaInicio = fechaInicio == "" ? "1000-01-01" : fechaInicio;
            fechaTermino = fechaTermino == "" ? "1000-01-01" : fechaTermino;
            comando.Parameters.AddWithValue("@PIN_FECHA_INICIO", SqlDbType.Date).Value = fechaInicio;
            comando.Parameters.AddWithValue("@PIN_FECHA_TERMINO", SqlDbType.Date).Value = fechaTermino;
            comando.Parameters.AddWithValue("@PIN_STATUS", SqlDbType.Int).Value = status;

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

    public static DataTable ListarObservacionActa(int supervisor,string fechaInicio, string fechaTermino)
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
                CommandText = "P_LISTAR_OBSERVACION_ACTA"
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

    public static int CompararObservacion(int inmueble, string descripcion)
    {
        try
        {
            Conexion c = new Conexion();

            int id = 0;
            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_COMPARAR_OBSERVACION"
            };
            comando.Parameters.AddWithValue("@PIN_INMUEBLE", SqlDbType.Int).Value = inmueble;
            comando.Parameters.AddWithValue("@PIN_DESCRIPCION", SqlDbType.NChar).Value = descripcion;

            SqlDataAdapter myDA = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            myDA.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                id = Convert.ToInt32(dt.Rows[0][0].ToString());
            }

            return id;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static bool CompararObservacionPlantilla(string inmueble, string descripcion, string fechaCoordinacion)
    {
        try
        {
            Conexion c = new Conexion();
            bool existe = false;
            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_COMPARAR_OBSERVACION_PLANILLA"
            };
            comando.Parameters.AddWithValue("@PIN_INMUEBLE", SqlDbType.VarChar).Value = inmueble;
            comando.Parameters.AddWithValue("@PIN_DESCRIPCION", SqlDbType.NChar).Value = descripcion;
            DateTime fecha = DateTime.Parse(fechaCoordinacion);
            comando.Parameters.AddWithValue("@PIN_FECHA_COORDINACION", SqlDbType.Date).Value = fecha.ToString("yyyy-MM-dd");

            SqlDataAdapter myDA = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            myDA.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                existe = true;
            }

            return existe;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static int CargarCodigo()
    {
        try
        {
            Conexion c = new Conexion();

            string servidor = c.cadena();
            int codigo;

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_CARGAR_CODIGO_OBSERVACION"
            };

            SqlDataAdapter myDA = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            myDA.Fill(dt);

            codigo = Convert.ToInt32(dt.Rows[0][0].ToString());
            return codigo;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}