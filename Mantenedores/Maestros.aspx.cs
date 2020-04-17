using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class context_Maestros : System.Web.UI.Page
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

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            validarCampos();
            Maestro obj = new Maestro();

            obj.Rut = txtRut.Text;
            obj.Nombre = txtNombre.Text;
            //obj.ApellidoPaterno = txtApellidoP.Text;
            //obj.ApellidoMaterno = txtApellidoM.Text;
            obj.Direccion = txtDireccion.Text;
            obj.Comuna= Convert.ToInt32(cboComuna.SelectedValue);
            obj.Telefono = txtTelefono.Text;

            if (DatosMaestro.AgregarMaestro(obj))
            {
                lblMensaje.Text = "Maestro agregado";
                lblMensaje.CssClass = "correcto";
            }
            else
            {
                lblMensaje.Text = "Error al Agregar";
                lblMensaje.CssClass = "error";
            }
            llenarGrid();
            btnLimpiar_Click(new object(), new EventArgs());
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
            Maestro obj = new Maestro();
            obj.Id = Convert.ToInt32(ViewState["id"]);
            obj.Rut = txtRut.Text;
            obj.Nombre = txtNombre.Text;
            //obj.ApellidoPaterno = txtApellidoP.Text;
            //obj.ApellidoMaterno = txtApellidoM.Text;
            obj.Direccion = txtDireccion.Text;
            obj.Comuna= Convert.ToInt32(cboComuna.SelectedValue);
            obj.Telefono = txtTelefono.Text;
            obj.Estado = chkEstado.Checked ? 1 : 0;
            if (DatosMaestro.ModificarMaestro(obj))
            {
                lblMensaje.Text = "Maestro Modificado";
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
            DataTable dt = DatosMaestro.ListarMaestro();
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
                Maestro maestro = DatosMaestro.BuscarMaestro(id);
                ViewState["id"] = id;
                txtRut.Text = maestro.Rut;
                txtNombre.Text = maestro.Nombre;
                //txtApellidoP.Text = maestro.ApellidoPaterno;
                //txtApellidoM.Text = maestro.ApellidoMaterno;
                txtDireccion.Text = maestro.Direccion;

                if (maestro.Comuna != 0)
                {
                    Comuna comuna = DatosComuna.BuscarComuna(maestro.Comuna);
                    cboRegion.SelectedValue = comuna.Provincia.Region.Id + "";

                    cboProvincia.DataSource = DatosProvincia.ListarProvincia(comuna.Provincia.Region.Id);
                    cboProvincia.DataBind();
                    cboProvincia.SelectedValue = comuna.Provincia.Id + "";

                    cboComuna.DataSource = DatosComuna.ListarComunas(comuna.Provincia.Id);
                    cboComuna.DataBind();
                    cboComuna.SelectedValue = comuna.Id + "";
                }

                txtTelefono.Text = maestro.Telefono;
                chkEstado.Enabled = true;
                chkEstado.Checked = maestro.Estado == 1 ? true : false;
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
        //if (txtApellidoP.Text.Trim().Equals(""))
        //{
        //    txtApellidoP.Focus();
        //    throw new Exception("Apellido Paterno no puede estar Vacío");
        //}
        //if (txtApellidoM.Text.Trim().Equals(""))
        //{
        //    txtApellidoM.Focus();
        //    throw new Exception("Apellido Materno no puede estar Vacío");
        //}
        if (txtDireccion.Text.Trim().Equals(""))
        {
            txtDireccion.Focus();
            throw new Exception("Direccion no puede estar Vacío");
        }
        if (txtTelefono.Text.Trim().Equals(""))
        {
            txtTelefono.Focus();
            throw new Exception("Teléfono no puede estar Vacío");
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
        //txtApellidoP.Text = "";
        //txtApellidoM.Text = "";
        txtDireccion.Text = "";
        txtTelefono.Text = "";
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