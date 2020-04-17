using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario xx = new Usuario();
            string username = txtUsuario.Text;
            string password = txtContraseña.Text;
            xx.User = username;
            xx.Password = password;
            if (DatosUsuario.VerificarUsuario(xx))
            {
                Session["Usuario"] = xx.User;
                Response.Redirect("MenuPrincipal.aspx");
            }
        }
        catch(Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }
}