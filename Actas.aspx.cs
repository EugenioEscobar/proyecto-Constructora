using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSupergoo.ABCpdf11;



public partial class Informes_Actas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void txtFechaInicio_TextChanged(object sender, EventArgs e)
    {
        if (txtFechaTermino.Text != "")
        {
            string fechaInicio = txtFechaInicio.Text;
            string fechaTermino = txtFechaTermino.Text;
            DataTable dt = DatosSupervisor.CargarSupervisorPorFecha(fechaInicio, fechaTermino);
            cboSupervisor.DataSource = dt;
            cboSupervisor.DataBind();
        }
    }

    protected void txtFechaTermino_TextChanged(object sender, EventArgs e)
    {
        if (txtFechaInicio.Text != "")
        {
            string fechaInicio = txtFechaInicio.Text;
            string fechaTermino = txtFechaTermino.Text;
            DataTable dt = DatosSupervisor.CargarSupervisorPorFecha(fechaInicio, fechaTermino);
            cboSupervisor.DataSource = dt;
            cboSupervisor.DataBind();
        }
    }

    protected void cboSupervisor_SelectedIndexChanged(object sender, EventArgs e)
    {
        string fechaInicio = txtFechaInicio.Text;
        string fechaTermino = txtFechaTermino.Text;
        int supervisor = Convert.ToInt32(cboSupervisor.SelectedValue);
        DataTable dt = DatosObservacion.ListarObservacionActa(supervisor, fechaInicio, fechaTermino);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            Label fechaCoordinacion = (Label)e.Row.FindControl("fechaCoordinacion");
            fechaCoordinacion.Text = DateTime.Parse(fechaCoordinacion.Text).ToString("dd-MM-yyyy");
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "Imprimir")
        {
            string codigo = e.CommandArgument.ToString();
            int index = int.Parse(codigo);
            GridViewRow row = GridView1.Rows[index];
            //int codigoObservacion = Convert.ToInt32(((Label)row.FindControl("IdObservacion")).Text);
            int codigoCoordinacion = Convert.ToInt32(((Label)row.FindControl("IdCoordinacion")).Text);
            //Session["CodigoObs"] = codigoObservacion;
            Response.Redirect("InformeActa.aspx?CodigoObs="+ codigoCoordinacion);
        }
    }

    protected void btnGenerarActas_Click(object sender, EventArgs e)
    {
        try
        {

            foreach (GridViewRow row in GridView1.Rows)
            {

                string codigo = ((Label)row.FindControl("IdCoordinacion")).Text;
                Coordinacion obj = DatosCoordinacion.BuscarCoordinacion(Convert.ToInt32(codigo));
                //Session["CodigoObs"] = codigo;

                Doc documento = new Doc();

                //documento.Page = documento.AddPage();

                int id = 0;

                string url = "http://localhost:15674/InformeActasPDF.aspx" + "?CodigoObs=" + codigo+"-"+obj.Fecha;

                //string url = "http://localhost:15674/Constructora/InformeActa.aspx";

                documento.HtmlOptions.PageCacheClear();
                documento.HtmlOptions.PageCachePurge();

                documento.HtmlOptions.Paged = true;
                documento.Page = documento.AddPage();

                id = documento.AddImageUrl(url);


                while (true)
                {
                    documento.FrameRect();
                    if (!documento.Chainable(id))
                    {
                        break;
                    }
                    documento.Page = documento.AddPage();
                    id = documento.AddImageToChain(id);

                }

                for (int i = 1; i < documento.PageCount; i++)
                {
                    documento.PageNumber = i;
                    documento.Flatten();
                }

                documento.Save("C:/GeneracionActas/" + codigo + ".pdf");
                documento.Clear();
            }
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }
}