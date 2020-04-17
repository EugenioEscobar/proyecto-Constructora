<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cargos.aspx.cs" Inherits="Mantenedores_Cargo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style4"><h1>Sistema SPCI</h1></td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style4">
                        <h3>Registrar Cargo</h3>
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
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style4">
                        <h3>Listado</h3>
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" class="GridView" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="CODIGO" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" HeaderText="Modificar" HeaderStyle-Width="30px" SelectImageUrl="~/context/imagenes/GridViewUpdate.png" ShowSelectButton="True" ControlStyle-Width="20px"/>

                                <asp:TemplateField InsertVisible="False" SortExpression="CODIGO" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="Codigo" runat="server" Text='<%# Bind("CODIGO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                        
                                <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" SortExpression="DESCRIPCION" />
                                <asp:BoundField DataField="VIGENCIA" HeaderText="VIGENCIA" SortExpression="VIGENCIA" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="EXECUTE P_LISTAR_CAUSAS"></asp:SqlDataSource>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <div class="divVolver">
                            <asp:HyperLink ID="HyperLink1" class="LinkVolver" runat="server" NavigateUrl="~/MenuPrincipal.aspx">Volver</asp:HyperLink>
                        </div>
                    </td>
                    <td class="auto-style6"></td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
