<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Supervisores.aspx.cs" Inherits="Mantenedores_Supervisores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../context/bootstrap-4.3.1-dist/css/bootstrap.min.css" />
    <link href="../context/style/EstiloMantenedor.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align:center;" runat="server">Registrar Supervisor</h1>
            <div class="divDetalle">
                <div class="form-row">
                    <div class="divTextos txtRut form-group col-md-6">
                        <asp:Label ID="Label1" runat="server" Text="Rut" required></asp:Label>
                        <asp:TextBox ID="txtRut" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="divTextos txtNombre form-group col-md-6">
                        <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="divTextos txtApellidoP form-group col-md-6">
                        <asp:Label ID="Label3" runat="server" Text="Apellido Paterno"></asp:Label>
                        <asp:TextBox ID="txtApellidoP" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="divTextos txtApellidoM form-group col-md-6">
                        <asp:Label ID="Label4" runat="server" Text="Apellido Materno"></asp:Label>
                        <asp:TextBox ID="txtApellidoM" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="divTextos txtDireccion form-group col-md-6">
                        <asp:Label ID="Label11" runat="server" Text="Direccion"></asp:Label>
                        <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="divTextos txtTipoSupervisor form-group col-md-6">
                        <asp:Label ID="Label6" runat="server" Text="Tipo Supervisor" ></asp:Label>
                        <asp:DropDownList ID="cboTipoSupervisor" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0">Seleccione un tipo de supervisor</asp:ListItem>
                            <asp:ListItem Value="1">Supervisor Constructora</asp:ListItem>
                            <asp:ListItem Value="2">Supervisor Inmobiliaria</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-row">
                    <div class="divTextos txtTelefono form-group col-md-6">
                        <asp:Label ID="Label13" runat="server" Text="Telefono"></asp:Label>
                        <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="divTextos txtCorreo form-group col-md-6">
                        <asp:Label ID="Label5" runat="server" Text="Correo"></asp:Label>
                        <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server" ></asp:TextBox>
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
                        <asp:Label ID="Label7" runat="server" Text="Provincia"></asp:Label>
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

                <div class="form-group">
                    <div class="divTextos chkVigencia form-check">
                        <asp:CheckBox ID="chkEstado" CssClass="form-check-input" runat="server" Enabled="false"/>
                        <asp:Label ID="Label9" CssClass="form-check-label" runat="server" Text="Vigencia"></asp:Label>
                    </div>
                </div>
                <div class="divBotones">
                    <asp:Button ID="btnIngresar" CssClass="btn btn-success" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                    <asp:Button ID="btnModificar" CssClass="btn btn-success" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnLimpiar" CssClass="btn btn-primary" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                </div>
                <div class="divLabel">
                    <asp:Label ID="lblMensaje" CssClass="LabelMensaje" runat="server" Text="" ></asp:Label>
                </div>
                <div class="Listado">
                    <h3>Listado</h3>
                    <asp:GridView ID="GridView" runat="server" CellPadding="4" class="GridView" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="GridView_RowCommand" Width="100%">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                        
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblHeader" runat="server" Text="Edit" ToolTip="Modificar Causa"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ImageUrl="~/context/Imagenes/Edit.svg" 
                                        ID="Editar" Width="20px" Height="20px"
                                        CommandName="Editar"
                                        CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" SortExpression="ESTADO" />

                            <asp:TemplateField InsertVisible="False" SortExpression="CODIGO" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="Codigo" runat="server" Text='<%# Bind("CODIGO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="RUT" HeaderText="RUT" SortExpression="RUT" />
                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" SortExpression="NOMBRE" />
                            <asp:BoundField DataField="APELLIDOP" HeaderText="APELLIDOP" SortExpression="APELLIDOP" />
                            <asp:BoundField DataField="APELLIDOM" HeaderText="APELLIDOM" SortExpression="APELLIDOM" />
                            <asp:BoundField DataField="COMUNA" HeaderText="COMUNA" SortExpression="COMUNAD" />
                            <asp:BoundField DataField="TELEFONO" HeaderText="TELEFONO" SortExpression="TELEFONO" />
                            <asp:BoundField DataField="CORREO" HeaderText="CORREO" SortExpression="CORREO" />
                        
                        </Columns>
                        <EmptyDataTemplate>
                            No existe ningún Supervisor
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
                    <br />
                    <asp:HyperLink ID="HyperLink" runat="server" NavigateUrl="~/MenuPrincipal.aspx">Volver</asp:HyperLink>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
