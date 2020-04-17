using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mantenedores_Cargo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Conexion c = new Conexion();
        SqlDataSource1.ConnectionString = c.cadena();
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            Conexion c = new Conexion();
            if (txtDescripcion.Text.Trim().Equals(""))
            {
                throw new Exception("Debe escribir una descripcion para agregarla");
            }
            Causa causa = new Causa
            {
                Descripcion = txtDescripcion.Text
            };

            string servidor = c.cadena();

            SqlConnection conexion = new SqlConnection(servidor);
            SqlCommand comando = new SqlCommand
            {
                Connection = conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = "P_REGISTRAR_CARGO"
            };

            SqlParameter parametro = new SqlParameter
            {
                ParameterName = "@PIN_DESCRIPCION",
                SqlDbType = SqlDbType.VarChar,
                Value = causa.Descripcion
            };

            comando.Parameters.Add(parametro);
            SqlDataAdapter myDA = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            myDA.Fill(dt);


            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
            lblMensaje.Visible = true;
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = GridView1.SelectedRow.RowIndex;
        string id = GridView1.SelectedValue.ToString();
        //Codigo Para buscar en la pagina modificar
        Session["Codigo"] = id;
        //Título para la pagina modificar
        Session["Nombre"] = "Cargo";
        //Nombre del aspx para el boton volver
        Session["Pagina"] = "Cargos";
        //Nombre del procedimiento almacenado
        Session["Procedimiento"] = "CARGOS";
        //Nombre del procedimiento para buscar
        Session["Buscar"] = "CARGO";
        Response.Redirect("../Modificar.aspx");
    }
}