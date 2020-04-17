 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="TipoObservacion.aspx.cs" Inherits="Mantenedores_TipoObservacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="context/bootstrap-4.3.1-dist/css/bootstrap.min.css" />
    <link href="../context/style/EstiloMantenedor.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3 runat="server">Registrar Tipo de observación</h3>
            <div class="divDetalle">
                <div class="divTextos txtDescripcion">
                    <asp:Label ID="Label1" runat="server" Text="Descripcion"></asp:Label>
                    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                </div>
                <div class="divBotones">
                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                </div>
                <div class="divTextos chkVigencia">
                    <asp:Label ID="Label2" runat="server" Text="Vigencia"></asp:Label>
                    <asp:CheckBox ID="chkEstado" runat="server" Enabled="false"/>
                </div>
                <div class="divLabel">
                    <asp:Label ID="lblMensaje" CssClass="LabelMensaje" runat="server" Text="" ></asp:Label>
                </div>
            </div>
            <div class="Listado">
                <h3>Listado</h3>
                <asp:GridView ID="GridView" runat="server" CellPadding="4" class="GridView" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="CODIGO" OnRowCommand="GridView_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblHeader" runat="server" Text="Edit" ToolTip="Modificar Causa"></asp:Label>
                            </HeaderTemplate>

                            <ItemTemplate>
                                <asp:ImageButton runat="server" ImageUrl="~/context/Imagenes/Edit.svg" 
                                    ID="NuevoReclamo" Width="20px" Height="20px"
                                    CommandName="Editar"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField InsertVisible="False" SortExpression="CODIGO" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="Codigo" runat="server" Text='<%# Bind("CODIGO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="CODIGO" HeaderText="CODIGO" InsertVisible="False" ReadOnly="True" SortExpression="CODIGO" />
                        <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" ReadOnly="True" SortExpression="DESCRIPCION" />
                        <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" ReadOnly="True" SortExpression="ESTADO" />
                    </Columns>
                    <EmptyDataTemplate>
                        No existe ningún tipo de observación
                    </EmptyDataTemplate>
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
                <asp:Label ID="lblGrid" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/MenuPrincipal.aspx" runat="server">Volver</asp:HyperLink>
        </div>
    </form>
</body>
</html>
