using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuPrincipal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //btnMenu1.Attributes.Add("onclick", "javascript:return funcion1();");
                //btnMenu2.Attributes.Add("onclick", "javascript:return funcion2();");
                //btnMenu3.Attributes.Add("onclick", "javascript:return funcion3();");
                //btnMenu4.Attributes.Add("onclick", "javascript:return funcion4();");
            }

            if (Session["Usuario"] == null)
            {
                //lblUsuario.Text = "Sesión expirada";
            }
            else {
                //lblUsuario.Text = Session["Usuario"].ToString();
            }
        }
        catch (Exception)
        {

        }
    }

    protected void btnMenu2_Click(object sender, EventArgs e)
    {
        //lblUsuario.Text = "It's Working :D";
    }
}