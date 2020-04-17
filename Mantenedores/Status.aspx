<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Status.aspx.cs" Inherits="Mantenedores_Status" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3 runat="server">Registrar Status</h3>
            <div class="divDetalle">
                <div class="divTextos txtDescripcion">
                    <asp:Label ID="Label1" runat="server" Text="Descripcion"></asp:Label>
                    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                </div>
                <div class="divBotones">
                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" />
                </div>
                <div class="divTextos chkVigencia">
                    <asp:Label ID="Label2" runat="server" Text="Vigencia"></asp:Label>
                    <asp:CheckBox ID="CheckBox1" runat="server" Enabled="false"/>
                </div>
                <div class="divLabel">
                    <asp:Label ID="lblMensaje" CssClass="LabelMensaje" runat="server" Text="" ></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
