<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Condominios.aspx.cs" Inherits="Mantenedores_Condominios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../context/bootstrap-4.3.1-dist/css/bootstrap.min.css" />
    <link href="../context/style/EstiloMantenedor.css" rel="stylesheet" />
    <link href="../context/fontawesome-free-5.11.2-web/css/all.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 runat="server" id="titulo" style="text-align:center;" >Registrar Condominio</h1>
            <div class="divDetalle">
                <div class="form-row" >

                    <div class="divTextos txtRut form-group col-md-6">
                        <asp:Label ID="Label1" runat="server" Text="Rut"></asp:Label>
                        <asp:TextBox ID="txtRut" CssClass="form-control"  runat="server"></asp:TextBox>
                    </div>
                
                    <div class="divTextos txtNombre form-group col-md-6">
                        <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                </div>      
                
                <div class="form-row" >
                    <div class="divTextos txtRazonSocial form-group col-md-6">
                        <asp:Label ID="Label4" runat="server" Text="RazonSocial"></asp:Label>
                        <asp:TextBox ID="txtRazonSocial" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                
                    <div class="divTextos txtDireccion form-group col-md-6">
                        <asp:Label ID="Label5" runat="server" Text="Direccion"></asp:Label>
                        <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                
                <div class="form-row">
                    <div class="divTextos txtCorreo form-group col-md-6">
                        <asp:Label ID="Label6" runat="server" Text="Correo"></asp:Label>
                        <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                
                    <div class="divTextos txtPaginaWeb form-group col-md-6">
                        <asp:Label ID="Label7" runat="server" Text="Pagina Web"></asp:Label>
                        <asp:TextBox ID="txtPaginaWeb" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                
                
                <div class="form-row">
                    <div class="divTextos txtRegion form-group col-md-4">
                        <asp:Label ID="Label8" runat="server" Text="Región"></asp:Label>
                        <asp:DropDownList ID="cboRegion" CssClass="form-control" runat="server" DataValueField="CODIGO" DataTextField="DESCRIPCION" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="cboRegion_SelectedIndexChanged">
                            <asp:ListItem Value="0">Seleccionar Región</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="divTextos txtProvincia form-group col-md-4">
                        <asp:Label ID="Label9" runat="server" Text="Provincia"></asp:Label>
                        <asp:DropDownList ID="cboProvincia" CssClass="form-control" runat="server" DataValueField="CODIGO" DataTextField="DESCRIPCION" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="cboProvincia_SelectedIndexChanged">
                            <asp:ListItem Value="0">Seleccionar Provincia</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="divTextos txtComuna form-group col-md-4">
                        <asp:Label ID="Label10" runat="server" Text="Comuna"></asp:Label>
                        <asp:DropDownList ID="cboComuna" CssClass="form-control" runat="server" DataValueField="CODIGO" DataTextField="DESCRIPCION" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">Seleccionar Comuna</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                
                <div class="divBotones" runat="server" id="divBoton">
                    <asp:Button ID="btnIngresar" CssClass="btn btn-success" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                    <asp:Button ID="btnModificar" CssClass="btn btn-success" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnLimpiar" CssClass="btn btn-primary" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                </div>

                <div class="divTextos chkVigencia">
                    <asp:Label ID="Label2" runat="server" Text="Vigencia"></asp:Label>
                    <asp:CheckBox ID="chkEstado" runat="server" Enabled="false"/>
                </div>
                <div class="divLabel">
                    <asp:Label ID="lblMensaje" CssClass="LabelMensaje" runat="server" Text="" ></asp:Label>
                </div>
                <div class="divListado">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15" Width="100%">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            
                            <%----------------------------BOTON---------------------%>
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

                            <%-------------------IMAGEN ESTADO-----------------------------------%>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblHeader2" runat="server" Text="Estado" ToolTip="Estado del condominio"></asp:Label>
                                </HeaderTemplate>

                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButtonSi" Visible="false" runat="server"><i class="fas fa-check"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonNo" Visible="false" runat="server"><i class="fas fa-times"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField InsertVisible="False" SortExpression="ESTADO" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="Estado" runat="server" Text='<%# Bind("ESTADO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            

                            <asp:TemplateField InsertVisible="False" SortExpression="CODIGO" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="Codigo" runat="server" Text='<%# Bind("CODIGO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="RUT" HeaderText="RUT" SortExpression="RUT" />
                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" SortExpression="NOMBRE" />
                            <asp:BoundField DataField="RAZONSOCIAL" HeaderText="RAZONSOCIAL" SortExpression="RAZONSOCIAL" />
                            <asp:BoundField DataField="DIRECCION" HeaderText="DIRECCION" SortExpression="DIRECCION" />
                            <asp:BoundField DataField="CORREO" HeaderText="CORREO" SortExpression="CORREO" />
                            <asp:BoundField DataField="PAGWEB" HeaderText="PAGWEB" SortExpression="PAGWEB" />
                            <asp:BoundField DataField="COMUNA" HeaderText="COMUNA" SortExpression="COMUNA" />
                            <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" SortExpression="ESTADO" />
                        </Columns>
                        <EmptyDataTemplate>
                            No existen Condominios
                        </EmptyDataTemplate>
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
                    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/MenuPrincipal.aspx" runat="server">Volver</asp:HyperLink>
                    <br />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
