using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mantenedores_EstadoReparación : System.Web.UI.Page
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
            EstadoReparacion obj = new EstadoReparacion();
            if (txtDescripcion.Equals(""))
                txtDescripcion.Focus();

            obj.Descripcion = txtDescripcion.Text;

            if (DatosEstadoReparacion.AgregarEstadoReparacion(obj))
            {
                lblMensaje.Text = "Estado de reparacion agregado";
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
            EstadoReparacion obj = new EstadoReparacion();
            if (txtDescripcion.Equals(""))
                txtDescripcion.Focus();

            obj.Id = Convert.ToInt32(ViewState["id"]);
            obj.Descripcion = txtDescripcion.Text;
            obj.Estado = chkEstado.Checked ? 1 : 0;
            if (DatosEstadoReparacion.ModificarEstadoReparacion(obj))
            {
                lblMensaje.Text = "Estado de reparacion Modificado";
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
            DataTable dt = DatosEstadoReparacion.ListarEstadoReparacion();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Editar"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                Label codigo = (Label)row.FindControl("CODIGO");
                int id = Convert.ToInt32(codigo.Text);
                EstadoReparacion obj = DatosEstadoReparacion.BuscarEstadoReparacion(id);
                ViewState["id"] = id;
                txtDescripcion.Text = obj.Descripcion;
                chkEstado.Enabled = true;
                chkEstado.Checked = obj.Estado == 1 ? true : false;
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