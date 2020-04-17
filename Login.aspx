<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link rel="stylesheet" href="context/style/EstiloIndex.css" />
        <title>Index Postventa</title>
        <style type="text/css">
            
            .auto-style3 {
                width: 100%;
            }
            .auto-style5 {
                width: 20%;
            }
            .auto-style6 {
            }
            .auto-style7 {
                width: 20%;
            }
            .auto-style8 {
                text-align: center;
            }
        </style>
        <link rel="stylesheet" href="context/styles/EstiloIndex.css" />
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style3">
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8"></td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style6">
                    <div class="box">
                        <div class="box2">
                            <h1>Login</h1>
                            <div class="inputBox">
                                <asp:TextBox ID="txtUsuario" CssClass="inputBox" runat="server" required BackColor="Transparent" AutoCompleteType="Disabled"></asp:TextBox>
                                <label>Usuario</label>
                            </div>
                            <div class="inputBox">
                                <asp:TextBox ID="txtContraseña" CssClass="inputBox" TextMode="Password" runat="server" required></asp:TextBox>
                                <label >Contraseña</label>
                            </div>
                            <div class="lblmensaje">
                                <asp:Label ID="lblMensaje" runat="server" Text=" "></asp:Label>
                            </div>
                            <div class="btn">
                                <asp:Button ID="btnIngresar" CssClass="button" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                                <asp:Button ID="btnLimpiar"  CssClass="button" runat="server" Text="Limpiar" />
                            </div>
                        </div>
                    </div>
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
