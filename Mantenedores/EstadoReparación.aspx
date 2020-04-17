<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EstadoReparación.aspx.cs" Inherits="Mantenedores_EstadoReparación" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../context/bootstrap-4.3.1-dist/css/bootstrap.min.css" />
    <link href="../context/style/EstiloMantenedor.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h3 runat="server">Registrar estado de reparacion</h3>
            <div class="divDetalle">
                <div class="divTextos txtDescripcion form-group">
                    <asp:Label ID="Label1" runat="server" Text="Descripcion"></asp:Label>
                    <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <div class="divTextos chkVigencia form-check">
                        <asp:CheckBox ID="chkEstado" CssClass="form-check-input" runat="server" Enabled="false"/>
                        <asp:Label ID="Label2" CssClass="form-check-label" runat="server" Text="Vigencia"></asp:Label>
                    </div>
                </div>
                <div class="divBotones">
                    <asp:Button ID="btnIngresar" CssClass="btn btn-success" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                    <asp:Button ID="btnModificar" CssClass="btn btn-success" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnLimpiar" CssClass="btn btn-primary" runat="server" Text="Limpiar" />
                </div>
                <div class="divLabel">
                    <asp:Label ID="lblMensaje" CssClass="LabelMensaje" runat="server" Text="" ></asp:Label>
                </div>
                <div class="divListado">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" Width="90%" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblHeader" runat="server" Text="Edit" ToolTip="Modificar Estado de reparacion"></asp:Label>
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

                            <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" SortExpression="DESCRIPCION" />
                            <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" SortExpression="ESTADO" />
                        </Columns>
                        <EmptyDataTemplate>
                            No existen Estados de Reparacion
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
                </div>
            </div>
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/MenuPrincipal.aspx" runat="server">Volver</asp:HyperLink>
        </div>
    </form>
</body>
</html>
