using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class CargarExcel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            btnGrabar.Enabled = true;
            btnGrabar.CssClass = "btn btn-primary";
            lblMensaje.Text = "";
            divMensaje.Attributes.Add("class", " ");
        }
    }

    protected void btnCargar_Click(object sender, EventArgs e)
    {
        try
        {
            HttpFileCollection uploads = HttpContext.Current.Request.Files;
            for (int i = 0; i < uploads.Count; i++)
            {
                HttpPostedFile upload = uploads[i];
                if (upload.ContentLength == 0)
                    continue;
                string c = System.IO.Path.GetFileName(upload.FileName);
                try
                {
                    string ruta = Server.MapPath("context/Archivos/") + c;
                    upload.SaveAs(ruta);
                }
                catch (Exception Exp)
                {
                    throw (Exp);
                }
            }
            if (FileUpload1.PostedFile != null)
            {
                HttpPostedFile attFile = FileUpload1.PostedFile;
                int attachFileLength = attFile.ContentLength;
                if (attachFileLength > 0)
                {
                    if (FileUpload1.PostedFile.ContentLength > 0)
                    {
                        string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                        string inFileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        string pathDataSource = Server.MapPath("context/Archivos/") + inFileName;

                        //string conStr = "";
                        if (Extension == ".xls" || Extension == ".xlsx" || Extension == ".xlsm")
                        {


                            string CadenaConexion = @"driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};
                                    driverid=1046;dbq=" + pathDataSource;
                            DataTable ds = null;
                            try
                            {
                                using (OdbcConnection conn = new OdbcConnection(CadenaConexion))
                                {
                                    conn.Open();
                                    using (OdbcCommand command = conn.CreateCommand())
                                    {
                                        //consulta para mostrar en hoja de excel
                                        command.CommandText = "SELECT * FROM [CargaDatos$]";
                                        OdbcDataAdapter ad = new OdbcDataAdapter(command);
                                        ds = new DataTable();
                                        ad.Fill(ds);
                                        conn.Close();

                                        int i = 0;

                                        foreach(DataRow fila in ds.Rows)
                                        {
                                            i++;
                                            if (fila[0].ToString().Trim() == "0" || fila[0].ToString().Trim() == "")
                                            {
                                                fila.Delete();
                                            }
                                        }
                                        ViewState["dataSource"] = ds;
                                        ViewState["plantillaCargada"] = "true";
                                        gridExcel.DataSource = ds;
                                        gridExcel.DataBind();
                                        if (ViewState["plantillaCargada"].ToString() == "true")
                                        {
                                            btnGrabar.Enabled = false;
                                            btnGrabar.CssClass = "btn btn-danger";
                                            lblMensaje.Text = "Esta plantilla ya ha sido cargada en la base de datos";
                                            divMensaje.Attributes.Add("class", "alert alert-success  col-md-8");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Response.Write(ex.Message.ToString());
                            }
                        }
                        else
                        {
                            //Show your error in any error controls
                        }
                    }
                    else
                    {
                        FileUpload1.Focus();
                        gridExcel.DataSource = null;
                        gridExcel.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //throw ex;
            lblMensaje.Text = ex.Message;
        }


        //la conexion donde se encuentra el archivo para ser mostrado en el gridview

    }


    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        try
        {
            lblMensaje.Text = "";
            Observacion observacion = new Observacion();

            observacion.HoraInicio2 = new Hora()
            {
                Id = 0
            };
            observacion.HoraTermino2 = new Hora()
            {
                Id = 0
            };
            observacion.EstadoReparacion = new EstadoReparacion()
            {
                Id = 1
            };
            observacion.Maestro = new Maestro()
            {
                Id = 1
            };
            observacion.Partida = new Partida()
            {
                Id = 1
            };
            observacion.Causa = new Causa()
            {
                Id = 1
            };
            observacion.Recinto = new Recinto()
            {
                Id = 1
            };
            observacion.TipoObservacion = new TipoObservacion()
            {
                Id = 10
            };

            DataTable dt = ViewState["dataSource"] as DataTable;
            
            foreach(DataRow row in dt.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    #region variables DataTable
                    string rowInmobiliaria = row["Inmobiliaria"].ToString().Trim();
                    string rowProyecto = row["Proyecto"].ToString().Trim();
                    string rowSupervisorConstructora = row["Supervisor Constructora"].ToString();
                    string rowSupervisorInmobiliaria = row["Solicitante Supervisor Inmob#"].ToString();
                    string rowFechaObservacion = row["Fecha"].ToString();
                    string rowInmueble = row["DEPTO"].ToString();
                    string rowDescripcion = row["Observación"].ToString().Trim();
                    string rowPropietario = row["Propietario"].ToString();
                    string rowRutPropietario = row["Rut"].ToString();
                    string rowFechaEntrega = row["Fecha Entrega"].ToString();
                    string rowNombreResidente = row["Residente"].ToString();
                    string rowTeléfonoResidente = row["Teléfono"].ToString();
                    string rowFechaCoordinación = row["Fecha Coordinación"].ToString();
                    int rowTipoHorario = Convert.ToInt32(row["Tipo Horario"].ToString());
                    string rowHoraInicio = row["Hora Inicio"].ToString();
                    string rowHoraTermino = row["Hora Termino"].ToString();
                    string rowTipoObservacion = row["Tipo Observacion"].ToString();
                    string rowTipoInmueble = row["Tipo de Inmueble"].ToString();
                    #endregion

                    if (rowInmobiliaria != "")
                    {
                        observacion.SupervisorConstructora = DatosSupervisor.BuscarSupervisor(rowSupervisorConstructora);

                        observacion.SupervisorInmobiliaria = DatosSupervisor.BuscarSupervisor(rowSupervisorInmobiliaria);

                        observacion.FechaObservacion = DateTime.Parse(rowFechaObservacion).ToString("yyyy-MM-dd");

                        if (DatosProyecto.BuscarProyecto(rowProyecto).Id == 0)
                        {
                            //No Existe el proyecto ingresado desde el Excel
                            if (DatosInmobiliaria.BuscarInmobiliaria(rowInmobiliaria).Id == 0)
                            {
                                //Tampoco existe la inmobiliria...
                                //Se realiza el ingreso de ambos
                                Inmobiliaria inmo = new Inmobiliaria()
                                {
                                    Nombre = rowInmobiliaria
                                };
                                DatosInmobiliaria.AgregarInmobiliaria(inmo);
                                Proyecto obj = new Proyecto()
                                {
                                    Inmobiliaria = DatosInmobiliaria.BuscarInmobiliaria(rowInmobiliaria),
                                    NombreProyecto = rowProyecto
                                };
                                DatosProyecto.AgregarProyecto(obj);
                            }else
                            {
                                //Ya existe la inmobiliaria, por lo que solo se busca y se realiza el ingreso del proyecto
                                Proyecto obj = new Proyecto()
                                {
                                    Inmobiliaria = DatosInmobiliaria.BuscarInmobiliaria(rowInmobiliaria),
                                    NombreProyecto = rowProyecto
                                };
                                DatosProyecto.AgregarProyecto(obj);
                            }
                        }

                        Proyecto proyecto = DatosProyecto.BuscarProyecto(rowProyecto);
                        Inmueble inmueble = DatosInmueble.BuscarInmueble(rowInmueble, proyecto.Id);

                        if (inmueble.Id != 0)
                        {
                            //Existe el inmueble
                            observacion.Inmueble = inmueble;
                        }
                        else
                        {
                            //No existe y se genera con los datos provenientes del excel
                            Inmueble obj = new Inmueble();
                            obj.Condominio = new Condominio()
                            {
                                //SIN CONDOMINIO
                                Id = 30
                            };
                            obj.Etapa = new Etapa()
                            {
                                //ETAPA 1
                                Id = 14
                            };
                            obj.Proyecto = proyecto;
                            obj.NumInmueble = rowInmueble;
                            obj.TipoInmueble = DatosTipoInmueble.BuscarTipoInmueble(rowTipoInmueble);
                            DatosInmueble.AgregarInmueble(obj);
                        }


                        observacion.DescObservacion = rowDescripcion;

                        //-----------------------------------------Datos del propietario---------------------------------------------------------------
                        observacion.RutPropietario = rowRutPropietario;

                        observacion.Propietario = DatosPropietario.BuscarPropietario(rowPropietario);
                        if (observacion.Propietario.Id == 0)
                        {
                            if (observacion.RutPropietario.Trim() != "")
                            {
                                observacion.Propietario.Rut = observacion.RutPropietario.Trim();
                            }
                            observacion.Propietario.Nombre = rowPropietario;
                            DatosPropietario.AgregarPropietario(observacion.Propietario);
                        }

                        if (rowFechaEntrega.Trim() != "")
                        {
                            observacion.FechaEntrega = DateTime.Parse(rowFechaEntrega).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            observacion.FechaEntrega = "";
                        }

                        observacion.NombreResidente = rowNombreResidente;

                        observacion.TelefonoResidente = rowTeléfonoResidente;

                        observacion.FechaCoordinacion = DateTime.Parse(rowFechaCoordinación).ToString("yyyy-MM-dd");

                        if (rowTipoHorario == 0)
                        {
                            observacion.HoraInicio = DatosHoras.BuscarHoraPorDescripcion(DateTime.Parse(rowHoraInicio).ToString("HH:mm"));

                            observacion.HoraTermino = DatosHoras.BuscarHoraPorDescripcion(DateTime.Parse(rowHoraTermino).ToString("HH:mm"));

                            observacion.TipoHorario = 0;
                        }
                        else
                        {
                            observacion.HoraInicio = DatosHoras.BuscarHoraPorDescripcion("9:00");

                            observacion.HoraTermino = DatosHoras.BuscarHoraPorDescripcion("18:30");

                            observacion.TipoHorario = 1;
                        }

                        observacion.TipoObservacion = DatosTipoObservacion.BuscarTipoObservacion(rowTipoObservacion);
                        
                        int id = DatosObservacion.CompararObservacion(observacion.Inmueble.Id, observacion.DescObservacion);
                        if (id != 0)
                        {
                            Coordinacion obj = new Coordinacion()
                            {
                                Observacion = new Observacion()
                                {
                                    Id = id
                                },
                                Fecha = observacion.FechaCoordinacion,
                                HoraInicio = observacion.HoraInicio,
                                HoraTermino = observacion.HoraTermino
                            };
                            DatosCoordinacion.AgregarCoordinacion(obj);
                        }
                        else
                        {
                            DatosObservacion.AgregarObservacion(observacion);
                        }

                    }

                }

            }
            divMensaje.Attributes.Add("class", "alert alert-success  col-md-8");
            lblMensaje.Text = "Planilla agregada Correctamente";
        }
        catch (Exception Ex)
        {
            lblMensaje.Text = Ex.Message;
        }
    }


    protected void gridExcel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string mensaje = "";
        string fechaCoordinacion = "";
        string descripcion = "";
        string inmueble = "";
        DataTable dt = ViewState["dataSource"] as DataTable;
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            TableRow row = e.Row;
            int index = 0;
            index = Convert.ToInt32(((Label)row.FindControl("Index")).Text);

            #region fecha Observacion
            Label label = (Label)row.FindControl("Fecha");
            if (label.Text.Trim() != "")
            {
                try
                {
                    label.Text = DateTime.Parse(label.Text).ToString("dd-MM-yyyy");
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                    mensaje = "Error en la fecha de observación en la fila: " + index + ".";
                }
            }
            #endregion
            #region Fecha Entrega
            label = (Label)row.FindControl("FechaEntrega");
            if (label.Text.Trim() != "")
            {
                try
                {
                    label.Text = DateTime.Parse(label.Text).ToString("dd-MM-yyyy");
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                    mensaje = "Error en la fecha de Entrega en la fila: " + index + ".";
                }
            }
            #endregion
            #region Fecha Coordinacion
            label = (Label)row.FindControl("FechaCoordinacion");
            if (label.Text.Trim() != "")
            {
                try
                {
                    label.Text = DateTime.Parse(label.Text).ToString("dd-MM-yyyy");
                    fechaCoordinacion = label.Text;
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                    mensaje = "Error en la fecha de Coordinación en la fila: " + index + ".";
                }
            }
            #endregion
            #region Hora Inicio
            label = (Label)row.FindControl("HoraInicio");
            if (label.Text.Trim() != "")
            {
                try
                {
                    label.Text = DateTime.Parse(label.Text).ToString("HH:mm");
                    Hora hora = DatosHoras.BuscarHoraPorDescripcion(label.Text);
                    if (hora.Id == 0)
                    {
                        throw new Exception("Error de formato en hora de Inicio en la fila: "+ index +".");
                    }
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                    mensaje = "Error en la Hora de Inicio en la fila: " + index + ".";
                }
            }
            #endregion
            #region Hora Término
            label = (Label)row.FindControl("HoraTermino");
            if (label.Text.Trim() != "")
            {
                try
                {
                    label.Text = DateTime.Parse(label.Text).ToString("HH:mm");
                    Hora hora = DatosHoras.BuscarHoraPorDescripcion(label.Text);
                    if (hora.Id == 0)
                    {
                        throw new Exception("Error de formato en hora de Termino en la fila: " + index + ".");
                    }
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                    mensaje = "Error en la Hora de término en la fila: " + index + ".";
                }
            }
            #endregion
            #region Descripcion
            label = (Label)row.FindControl("Observación");
            string obs = label.Text;
            if (obs.Trim() == "")
            {
                mensaje = "La descripcion en la fila "+ index +" está vacía.";
            }
            else
            {
                string flag = obs.ElementAt(0) + "" + obs.ElementAt(1) + "" + obs.ElementAt(2) + "";
                if (flag.Trim() == "-")
                {
                    flag = "";
                    for (int i = 2; i < obs.Length; i++)
                    {
                        flag += obs.ElementAt(i) + "";
                    }
                    label.Text = flag;
                    dt.Rows[index - 1].BeginEdit();
                    dt.Rows[index - 1]["Observación"] = flag;
                    dt.Rows[index - 1].EndEdit();
                }
                descripcion = obs;
            }
            #endregion
            #region Inmueble
            label = (Label)row.FindControl("Inmueble");
            if(label.Text.Trim() == "")
            {
                mensaje = "No existe departamento en la fila: " + index + ".";
            }
            inmueble = label.Text;
            #endregion

            if (DatosObservacion.CompararObservacionPlantilla(inmueble,descripcion,fechaCoordinacion))
            {
                
            }else
            {
                ViewState["plantillaCargada"] = "false";
            }
            ViewState["dataSource"] = dt;
            if (mensaje != "")
            {
                btnGrabar.Enabled = false;
                btnGrabar.CssClass = "btn btn-danger";
                divMensaje.Attributes.Add("class", "alert alert-success  col-md-8");
                lblMensaje.Text = mensaje;
            }
        }

    }
}