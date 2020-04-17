using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mantenedores_TipoObservacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                btnModificar.Visible = false;
                llenarGrid();
                chkEstado.Checked = true;
                chkEstado.Enabled = false;
            }
            else
            {
                lblMensaje.Text = "";
            }
        }
        catch (Exception ex)
        {

            lblMensaje.Text = ex.Message;
        }
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            TipoObservacion obj = new TipoObservacion();
            if (txtDescripcion.Equals(""))
            {
                txtDescripcion.Focus();
            }
            obj.Descripcion = txtDescripcion.Text;
            if (DatosTipoObservacion.AgregarTipoObservacion(obj))
            {
                lblMensaje.Text = "Tipo de observacion agregado";
                lblMensaje.CssClass = "correcto";
            }
            else
            {
                lblMensaje.Text = "Error al Agregar";
                lblMensaje.CssClass = "error";
            }
            llenarGrid();
        }
        catch (Exception ex)
        {

            lblMensaje.Text = ex.Message;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            TipoObservacion partida = new TipoObservacion();
            partida.Id = Convert.ToInt32(ViewState["id"]);
            partida.Descripcion = txtDescripcion.Text;
            partida.Estado = chkEstado.Checked ? 1 : 0;
            if (DatosTipoObservacion.ModificarTipoObservacion(partida))
            {
                lblMensaje.Text = "Tipo de observacion Modificada";
                lblMensaje.CssClass = "correcto";
            }
            else
            {
                lblMensaje.Text = "Error al Modificar";
                lblMensaje.CssClass = "error";
            }
            llenarGrid();
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }

    protected void llenarGrid()
    {
        try
        {
            DataTable dt = DatosTipoObservacion.ListarTipoObservacion();
            GridView.DataSource = dt;
            GridView.DataBind();
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }



    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Editar"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView.Rows[index];
                Label codigo = (Label)row.FindControl("CODIGO");
                int id = Convert.ToInt32(codigo.Text);
                TipoObservacion partida = DatosTipoObservacion.BuscarTipoObservacion(id);
                ViewState["id"] = id;
                txtDescripcion.Text = partida.Descripcion;
                chkEstado.Enabled = true;
                chkEstado.Checked = partida.Estado == 1 ? true : false;
                btnIngresar.Visible = false;
                btnModificar.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }


    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtDescripcion.Text = "";
        chkEstado.Enabled = false;
        chkEstado.Checked = true;
        btnIngresar.Visible = true;
        btnModificar.Visible = false;
    }
}