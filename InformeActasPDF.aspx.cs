using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InformeActasPDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["CodigoObs"]
        if (Request.QueryString["CodigoObs"] != null)
        {
            int idObs = Convert.ToInt32(Request.QueryString["CodigoObs"].ToString());
            Coordinacion obs = DatosCoordinacion.BuscarCoordinacion(idObs);
            txtInmobiliaria.Text = obs.Observacion.Inmueble.Proyecto.Inmobiliaria.Nombre;
            txtNumActa.Text = "";
            txtProyecto.Text = obs.Observacion.Inmueble.Proyecto.NombreProyecto;
            txtInmueble.Text = obs.Observacion.Inmueble.NumInmueble;
            txtFechaCoordinacion.Text = DateTime.Parse(obs.Fecha).ToString("yyyy-MM-dd");
            txtHora.Text = obs.HoraInicio.Descripcion + " a " + obs.HoraTermino.Descripcion;
            txtSupervisor.Text = obs.Observacion.SupervisorConstructora.Nombre;

            DataTable dt = DatosObservacion.ListarMantienconObs(obs.Observacion.Inmueble.Id, obs.Observacion.SupervisorConstructora.Id, obs.Observacion.Inmueble.Proyecto.Id, txtFechaCoordinacion.Text, txtFechaCoordinacion.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            int filas = GridView1.Rows.Count;
            for (int i = 35; i > filas; i--)
            {
                div.Controls.Add(new Literal() { ID = "row" + i, Text = "<br/>" });
            }
        }
    }
}