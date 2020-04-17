using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModificarDatos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarCbo();
            txtFecha.Enabled = false;
            txtFecha.CssClass = "form-control";
        }
        else
        {
            divMensaje.Attributes.Add("class", "");
            lblMensaje.Text = "";
            divMensajePopUp.Attributes.Add("class", "");
            lblMensajePopUp.Text = "";
        }
    }

    private void cargarCbo()
    {
        DataTable dt = DatosInmobiliaria.CargarInmobiliariaMantencion();
        cboInmobiliaria.DataSource = dt;
        cboInmobiliaria.DataBind();

        //dt = DatosPartida.ListarPartida();
        //cboPartida.DataSource = dt;
        //cboPartida.DataBind();

        dt = DatosEstadoReparacion.ListarEstadoReparacion();
        cboEstadoReparacion.DataSource = dt;
        cboEstadoReparacion.DataBind();

        dt = DatosTipoObservacion.ListarTipoObservacion();
        cboTipoObservacion.DataSource = dt;
        cboTipoObservacion.DataBind();
    }

    protected void cboInmobiliaria_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int inmobiliaria = Convert.ToInt32(cboInmobiliaria.SelectedValue);
            cboProyecto.Items.Clear();
            cboProyecto.Items.Add(new ListItem("Todos los proyectos", "0"));
            DataTable dt = DatosProyecto.CargarProyectoMantencion(inmobiliaria);
            cboProyecto.DataSource = dt;
            cboProyecto.DataBind();
        }catch(Exception ex)
        {
            divMensaje.Attributes.Add("class", "alert alert-danger  col-md-8");
            lblMensaje.Text = ex.Message;
        }
    }

    protected void cboProyecto_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int codigo = Convert.ToInt32(cboProyecto.SelectedValue);
            cboSupervisor.Items.Clear();
            cboSupervisor.Items.Add(new ListItem("Todos los supervisores", "0"));
            cboSupervisor.DataSource = DatosSupervisor.CargarSupervisorObservacion(codigo);
            cboSupervisor.DataBind();

            cboInmueble.Items.Clear();
            cboInmueble.Items.Add(new ListItem("Todos los Departamento", "0"));
            cboInmueble.DataSource = DatosInmueble.CargarInmuebleMantencion(codigo);
            cboInmueble.DataBind();
        }
        catch (Exception ex)
        {
            divMensaje.Attributes.Add("class", "alert alert-danger col-md-8");
            lblMensaje.Text = ex.Message;
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["inmueble"] = Convert.ToInt32(cboInmueble.SelectedValue);
            ViewState["supervisor"] = Convert.ToInt32(cboSupervisor.SelectedValue);
            ViewState["proyecto"] = Convert.ToInt32(cboProyecto.SelectedValue);
            ViewState["fechaInicio"] = txtFechaInicio.Text;
            ViewState["fechaTermino"] = txtFechaTermino.Text;
            ViewState["estatus"] = Convert.ToInt32(cboEstatus.SelectedValue);

            llenarGrid();
            HyperLink3.Visible = true;
        }
        catch (Exception ex)
        {
            divMensaje.Attributes.Add("class", "alert alert-danger col-md-8");
            lblMensaje.Text = ex.Message;
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            // e es el evento que contiene el comando
            // obtiene los valores entregado por el gridview para analizarlos dependiendo el boton presionado
            if (e.CommandArgument.Equals("Vacio"))
            {

            }
            else
            {

                int index = Convert.ToInt32(e.CommandArgument);
                //Convierte el index obtenido en una row (rl registro completo), con todos los valores que muestra en el grid view

                GridViewRow row = GridView1.Rows[index];
                //Obtiene el valor del index con el Argumento "((GridViewRow) Container).RowIndex" enviado a travez del boton desde el gridview

                Label codigo = (Label)row.FindControl("Codigo");


                switch (e.CommandName)
                {
                    case "Modificar":
                        Observacion obj = DatosObservacion.BuscarObservacion(Convert.ToInt32(codigo.Text));
                        if (DateTime.Parse(obj.FechaCierre).Year < 2000)
                        {
                            txtCodigo.Text = codigo.Text;
                            DateTime fecha = DateTime.Parse(obj.FechaCierre);
                            txtFecha.Text = fecha.ToString("yyyy-MM-dd");
                            if (txtFecha.Text == "1900-01-01")
                            {
                                txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                            }
                            txtDescripcion.Text = obj.DescObservacion;
                            //cboPartida.SelectedValue = obj.Partida.Id + "";
                            cboEstadoReparacion.SelectedValue = obj.EstadoReparacion.Id + "";
                            cboTipoObservacion.SelectedValue = obj.TipoObservacion.Id + "";
                            cboTipoObservacion.SelectedValue = obj.TipoObservacion.Id + "";
                            txtComentario.Text = obj.Reparacion;
                        }else
                        {
                            divMensaje.Attributes.Add("class", "alert alert-danger col-md-8");
                            lblMensaje.Text = "No se puede modificar una Observación CERRADA";
                        }
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            divMensaje.Attributes.Add("class", "alert alert-danger col-md-8");
            lblMensaje.Text = ex.Message;
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DateTime fechaParse = new DateTime();
            Label fechaCoordinacion = (Label)e.Row.FindControl("FechaCoordinacion");
            Label fechaCierre = (Label)e.Row.FindControl("FechaCierre");
            Label status = (Label)e.Row.FindControl("Status");
            Label tiempoCerrar = (Label)e.Row.FindControl("tiempoCerrar");
            Label tiempoObservacion = (Label)e.Row.FindControl("tiempoObservacion");

            fechaParse = DateTime.Parse(fechaCoordinacion.Text);
            fechaCoordinacion.Text = fechaParse.ToString("dd-MM-yyyy");
            bool diferente = true;
            int dias = 0;
            int comparacion = fechaParse.CompareTo(DateTime.Today);
            // si fechaParse es menor que fecha actual devuelve -1
            if (comparacion < 0)
            {
                while (diferente)
                {
                    if (fechaParse.AddDays(dias).ToString("dd-MM-yyyy") == DateTime.Today.ToString("dd-MM-yyyy"))
                    {
                        diferente = false;
                    }
                    else
                    {
                        dias++;
                    }
                }
            }
            else
            {
                dias = 0;
            }
            tiempoObservacion.Text = dias + "";
            #region Fecha cierre
            fechaParse = DateTime.Parse(fechaCierre.Text);
            if (fechaParse.Year < 2000)
            {
                fechaCierre.Text = "-------------";
                status.Text = "ABIERTO";
                tiempoCerrar.Text = "0";
            }
            else
            {
                diferente = true;
                dias = 0;
                fechaCierre.Text = fechaParse.ToString("dd-MM-yyyy");
                status.Text = "CERRADO";
                while(diferente)
                {
                    if(fechaParse.AddDays(dias).ToString("dd-MM-yyyy") == DateTime.Today.ToString("dd-MM-yyyy"))
                    {
                        diferente = false;
                    }
                    else
                    {
                        dias++;
                    }
                }
                tiempoCerrar.Text = dias + "";
            }
            #endregion

            
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            if ((cboTipoObservacion.SelectedValue == "0" || cboTipoObservacion.SelectedValue == "10") && (cboEstadoReparacion.SelectedValue == "7" || cboEstadoReparacion.SelectedValue == "8" || cboEstadoReparacion.SelectedValue == "10"))
            {
                lblMensajePopUp.Text = "Debe seleccionar un Tipo de observacion";
                divMensajePopUp.Attributes.Add("class", "alert alert-danger");
            }
            else
            {
                lblMensajePopUp.Text = "";
                Observacion obj = DatosObservacion.BuscarObservacion(Convert.ToInt32(txtCodigo.Text));
                if ((cboEstadoReparacion.SelectedValue == "7" || cboEstadoReparacion.SelectedValue == "8" || cboEstadoReparacion.SelectedValue == "10"))
                {
                    obj.FechaCierre = txtFecha.Text;
                    obj.Estatus = 1;
                }
                obj.DescObservacion = txtDescripcion.Text;
                //obj.Partida = DatosPartida.BuscarPartida(Convert.ToInt32(cboPartida.SelectedValue));
                obj.EstadoReparacion = DatosEstadoReparacion.BuscarEstadoReparacion(Convert.ToInt32(cboEstadoReparacion.SelectedValue));
                obj.TipoObservacion = DatosTipoObservacion.BuscarTipoObservacion(Convert.ToInt32(cboTipoObservacion.SelectedValue));
                obj.Reparacion = txtComentario.Text;
                DatosObservacion.ModificarObservacion(obj);
                limpiar();

                llenarGrid();
                divMensaje.Attributes.Add("class", "alert alert-success  col-md-8");
                lblMensaje.Text = "Observacion Modificada con éxito";
            }
            
        } catch (Exception ex)
        {
            divMensaje.Attributes.Add("class", "alert alert-danger col-md-8");
            lblMensaje.Text = ex.Message;
        }
    }

    protected void btnCerrarPop_Click(object sender, EventArgs e)
    {
        limpiar();
    }

    private void limpiar()
    {
        txtCodigo.Text = "";
        txtDescripcion.Text = "";
        txtComentario.Text = "";
        //cboPartida.SelectedValue = "0";
        cboEstadoReparacion.SelectedValue = "0";
        cboTipoObservacion.SelectedValue = "0";
        btnModificar.CssClass = "btn btn-success";
        txtFecha.Enabled = false; 
    }

    private void llenarGrid()
    {
        try
        {
            int inmueble = (int)ViewState["inmueble"];
            int proyecto = (int)ViewState["proyecto"];
            int supervisor = (int)ViewState["supervisor"];
            string fechaInicio = (string)ViewState["fechaInicio"];
            string fechaTermino = (string)ViewState["fechaTermino"];
            int estatus = (int)ViewState["estatus"];

            DataTable dt = DatosObservacion.ListarMantienconObs(inmueble,supervisor,proyecto,fechaInicio,fechaTermino,estatus);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }



    protected void cboInmueble_SelectedIndexChanged(object sender, EventArgs e)
    {
        string inmueble = cboInmueble.SelectedValue;
        string supervisor = cboSupervisor.SelectedValue;
        if (inmueble != "0" && supervisor == "0")
        {
            cboSupervisor.Enabled = false;
        }
        else
        {
            cboSupervisor.Enabled = true;
        }
    }

    protected void cboEstadoReparacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        int estadoReparacion = Convert.ToInt32(cboEstadoReparacion.SelectedValue);
        EstadoReparacion estado = DatosEstadoReparacion.BuscarEstadoReparacion(estadoReparacion);
        if (estado.Estado == 0)
        {
            cboEstadoReparacion.SelectedValue = "0";
            lblMensajePopUp.Text = "Este estado de reparación no es accesible";
            divMensajePopUp.Attributes.Add("class", "alert alert-danger");
        }
        else
        {
            if (estadoReparacion == 7 || estadoReparacion == 8 || estadoReparacion == 10)
            {
                if (cboTipoObservacion.SelectedValue != "1" && cboTipoObservacion.SelectedValue != "2")
                {
                    btnModificar.CssClass = "btn btn-danger";
                    cboTipoObservacion.Focus();
                    lblMensajePopUp.Text = "Debe seleccionar un Tipo de observacion";
                    divMensajePopUp.Attributes.Add("class", "alert alert-danger");
                }
                txtFecha.Enabled = true;
            }
        }
    }

    protected void cboTipoObservacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboTipoObservacion.SelectedValue == "1" || cboTipoObservacion.SelectedValue == "2")
        {
            btnModificar.CssClass = "btn btn-success";
        }else
        {
            int estadoReparacion = Convert.ToInt32(cboEstadoReparacion.SelectedValue);
            if (estadoReparacion == 7 || estadoReparacion == 8 || estadoReparacion == 10)
            {
                btnModificar.CssClass = "btn btn-danger";
                lblMensajePopUp.Text = "Debe seleccionar un Tipo de observacion";
                divMensajePopUp.Attributes.Add("class", "alert alert-danger");
            }
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        llenarGrid();
    }
}