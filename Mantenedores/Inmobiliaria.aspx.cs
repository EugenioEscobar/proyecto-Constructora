using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mantenedores_Inmobiliaria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                btnModificar.Visible = false;
                llenarGrid();
                llenarCbo();
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

    protected void llenarCbo()
    {
        try
        {
            cboRegion.DataSource = DatosRegion.ListarRegion();
            cboRegion.DataBind();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    protected void llenarGrid()
    {
        try
        {
            DataTable dt = DatosInmobiliaria.ListarInmobiliarias();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {

        try
        {
            validarCampos();
            Inmobiliaria obj = new Inmobiliaria();
            obj.Rut = txtRut.Text;
            obj.Nombre = txtNombre.Text;
            obj.RazonSocial = txtRazonSocial.Text;
            obj.Direccion = txtDireccion.Text;
            obj.Correo= txtCorreo.Text;
            obj.PaginaWeb= txtPaginaWeb.Text;
            obj.Comuna= Convert.ToInt32(cboComuna.SelectedValue);
            if (DatosInmobiliaria.AgregarInmobiliaria(obj))
            {
                lblMensaje.Text = "Inmobiliaria agregada";
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
            validarCampos();
            Inmobiliaria obj = new Inmobiliaria();
            obj.Id = Convert.ToInt32(ViewState["id"]);
            obj.Rut = txtRut.Text;
            obj.Nombre = txtNombre.Text;
            obj.RazonSocial= txtRazonSocial.Text;
            obj.Direccion = txtDireccion.Text;
            obj.Correo = txtCorreo.Text;
            obj.PaginaWeb = txtPaginaWeb.Text;
            obj.Comuna = Convert.ToInt32(cboComuna.SelectedValue);
            obj.Estado = chkEstado.Checked ? 1 : 0;
            if (DatosInmobiliaria.ModificarInmobiliaria(obj))
            {
                lblMensaje.Text = "Inmobiliaria Modificada";
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
                Inmobiliaria obj = DatosInmobiliaria.BuscarInmobiliaria(id);
                ViewState["id"] = id;
                txtRut.Text = obj.Rut;
                txtNombre.Text = obj.Nombre;
                txtRazonSocial.Text = obj.RazonSocial;
                txtDireccion.Text = obj.Direccion;
                txtCorreo.Text = obj.Correo;
                txtPaginaWeb.Text = obj.PaginaWeb;

                Comuna comuna = DatosComuna.BuscarComuna(obj.Comuna);
                cboRegion.SelectedValue = comuna.Provincia.Region.Id + "";

                cboProvincia.DataSource = DatosProvincia.ListarProvincia(comuna.Provincia.Region.Id);
                cboProvincia.DataBind();
                cboProvincia.SelectedValue = comuna.Provincia.Id + "";

                cboComuna.DataSource = DatosComuna.ListarComunas(comuna.Provincia.Id);
                cboComuna.DataBind();
                cboComuna.SelectedValue = comuna.Id + "";
                
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

    protected void validarCampos()
    {
        if (txtRut.Text.Trim() == "")
        {
            txtRut.Focus();
            throw new Exception("Rut no puede estar Vacío");
        }
        if (txtNombre.Text.Trim().Equals(""))
        {
            txtNombre.Focus();
            throw new Exception("Nombre no puede estar Vacío");
        }
        if (txtRazonSocial.Text.Trim().Equals(""))
        {
            txtRazonSocial.Focus();
            throw new Exception("Razon Social no puede estar Vacío");
        }
        if (txtDireccion.Text.Trim().Equals(""))
        {
            txtDireccion.Focus();
            throw new Exception("Direccion no puede estar Vacío");
        }
        if (txtCorreo.Text.Trim().Equals(""))
        {
            txtCorreo.Focus();
            throw new Exception("Correo no puede estar Vacío");
        }
        if (txtPaginaWeb.Text.Trim().Equals(""))
        {
            txtPaginaWeb.Focus();
            throw new Exception("Pagina Web no puede estar Vacío");
        }
        if (cboComuna.SelectedValue == "0")
        {
            cboComuna.Focus();
            throw new Exception("Debe seleccionar una comuna");
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtRut.Text = "";
        txtNombre.Text = "";
        txtRazonSocial.Text = "";
        txtDireccion.Text = "";
        txtCorreo.Text = "";
        txtPaginaWeb.Text = "";
        cboRegion.SelectedValue = "0";
        chkEstado.Enabled = false;
        chkEstado.Checked = true;
        btnIngresar.Visible = true;
        btnModificar.Visible = false;
        cboComuna.Items.Clear();
        cboComuna.Items.Add(new ListItem("Seleccionar Comuna", "0"));
        cboProvincia.Items.Clear();
        cboProvincia.Items.Add(new ListItem("Seleccionar Provincia", "0"));
    }

    protected void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        cboProvincia.DataSource = DatosProvincia.ListarProvincia(Convert.ToInt32(cboRegion.SelectedValue));
        cboProvincia.DataBind();
    }

    protected void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        cboComuna.DataSource = DatosComuna.ListarComunas(Convert.ToInt32(cboProvincia.SelectedValue));
        cboComuna.DataBind();
    }
}