<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModificarDatos.aspx.cs" Inherits="ModificarDatos" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="context/bootstrap-4.3.1-dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="context/fontawesome-free-5.11.2-web/css/all.min.css" />
    <title>
        Modificar Observación
    </title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:90%;margin:0 auto;">
            <h1 style="text-align:center;">Modificar Observación</h1>
            <div class="form-row justify-content-center">
                <div class="form-group col-md-2">
                    <asp:DropDownList ID="cboInmobiliaria" runat="server" AutoPostBack="true" DataTextField="NOMBRE" DataValueField="CODIGO" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="cboInmobiliaria_SelectedIndexChanged">
                        <asp:ListItem Value="0">Todas las Inmobiliarias</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-2">
                    <asp:DropDownList ID="cboProyecto" runat="server" AutoPostBack="True" DataTextField="NOMBRE" DataValueField="CODIGO" OnSelectedIndexChanged="cboProyecto_SelectedIndexChanged" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Value="0">Todos los proyectos</asp:ListItem>
                        <asp:ListItem Value="Inmobiliaria">Debe seleccionar una Inmobiliaria</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-2">
                    <asp:DropDownList ID="cboSupervisor" runat="server" AutoPostBack="True" DataTextField="NOMBRE" DataValueField="CODIGO" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Value="0">Todos los supervisores</asp:ListItem>
                        <asp:ListItem Value="Proyecto">Debe seleccionar un Proyecto</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-2">
                    <asp:DropDownList ID="cboInmueble" runat="server" AutoPostBack="True" DataTextField="NOMBRE" DataValueField="CODIGO" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="cboInmueble_SelectedIndexChanged">
                        <asp:ListItem Value="0">Todos los departamentos</asp:ListItem>
                        <asp:ListItem Value="Proyecto">Debe seleccionar un Proyecto</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-row justify-content-center">
                <div class="form-group col-md-1 center">
                    <asp:HyperLink Visible="false" ID="HyperLink2" runat="server" NavigateUrl="~/MenuPrincipal.aspx">Volver</asp:HyperLink>
                </div>
                <div class="form-group col-md-3">
                    <asp:TextBox ID="txtFechaInicio" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <asp:TextBox ID="txtFechaTermino" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                </div>
                <div class="form-group col-md-2">
                    <asp:DropDownList ID="cboEstatus" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Value="0">Seleccionar Estado</asp:ListItem>
                        <asp:ListItem Value="1">Abierto</asp:ListItem>
                        <asp:ListItem Value="2">Cerrado</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group col-md-1 text-lg-center">
                    <asp:HyperLink ID="HyperLink3" Visible="false" runat="server" NavigateUrl="~/MenuPrincipal.aspx">Volver</asp:HyperLink>
                </div>

            </div>
            <div class="form-row justify-content-center">
                <asp:Button ID="btnBuscar" CssClass="btn btn-success col-md-8 btn-block btn-lg" runat="server" Text="Buscar" OnClick="btnBuscar_Click" style="left: 0px; top: 0px" />
            </div>
            <div class="form-row justify-content-center">
                <div runat="server" id="divMensaje" style="margin:10px auto" role="alert">
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <br />
            <asp:GridView ID="GridView1" style="text-size:10px;width:100%;" runat="server" AutoGenerateColumns="False" CellPadding="5" DataKeyNames="IdObs" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label runat="server" ToolTip="Modificar Observación">Modificar</asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="Editar" runat="server"  Width="25px" CommandName="Modificar"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  >
                                <i class="fas fa-edit" style="font-size:28px;text-align:center;"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField InsertVisible="False" SortExpression="CODIGO" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="Codigo" runat="server" Text='<%# Bind("IdObs") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:BoundField DataField="NombreInmobiliaria" HeaderText="Inmobiliaria" SortExpression="NombreInmobiliaria" />
                    <asp:BoundField DataField="NombreProy" HeaderText="Proyecto" SortExpression="NombreProy" />
                    <asp:BoundField DataField="NumInmueble" HeaderText="Num Inmueble" SortExpression="NumInmueble" />
                    
                    <asp:TemplateField HeaderText="Observación">
                        <ItemTemplate >
                            <asp:Label ID="Observación" runat="server" Width="400px" Text='<%# Eval("Observacion") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Font-Size="Small" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Fecha Coordinacion">
                        <ItemTemplate>
                            <asp:Label ID="FechaCoordinacion" runat="server" Width="100px" Text='<%# Bind("FechaCoordinacion") %>'></asp:Label>
                        </ItemTemplate>
                    
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="SupervisorConstructora" HeaderText="Supervisor Constructora" SortExpression="SupervisorConstructora" />
                    <asp:BoundField DataField="SupervisorInmobiliaria" HeaderText="Supervisor Inmobiliaria" SortExpression="SupervisorInmobiliaria" />
                    <asp:BoundField DataField="TipoObservacion" HeaderText="Tipo Observación" SortExpression="TipoObservacion" />
                    
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate >
                            <asp:Label ID="Status" runat="server" Width="100px" Text=""></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha Cierre">
                        <ItemTemplate >
                            <asp:Label ID="FechaCierre" runat="server" Width="100px" Text='<%# Bind("FechaCierre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Tiempo en cerrar">
                        <ItemTemplate >
                            <asp:Label ID="tiempoCerrar" runat="server" Width="100px" Text=""></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Tiempo Observación">
                        <ItemTemplate >
                            <asp:Label ID="tiempoObservacion" runat="server" Width="100px" Text=""></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="EstadoReparacion" HeaderText="Estado de Reparación" HeaderStyle-Width="120px" ItemStyle-Width="120px" SortExpression="EstadoReparacion" />
                    <asp:BoundField DataField="Reparacion" HeaderText="Comentario" SortExpression="Reparacion" ControlStyle-Font-Size="Small" HeaderStyle-Width="200px" ItemStyle-Width="200px"/>
                </Columns>
                <EmptyDataTemplate>
                    <div class="form-row justify-content-center">
                        <div runat="server" id="divMensaje" class="alert alert-danger col-md-8" style="margin:10px auto" role="alert">
                            No existen registros con estas fechas
                        </div>
                    </div>
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
            <div class="modal fade" id="ventana1">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5>Pop Up Modificar</h5>
                            <asp:LinkButton runat="server" CssClass="close" OnClick="btnCerrarPop_Click" aria-hidden="true" Text="&times;" />
                        </div>
                        <div class="modal-body">
                            <h4>Modificar Observación</h4>
                            <div class="form-row">
                                <%--<div class="form-group col-md-6">
                                    <asp:Label ID="Label1" runat="server" Text="Codigo"></asp:Label>
                                </div>--%>
                                <div class="form-group col-md-6">
                                    <asp:Label ID="Label5" runat="server" Text="Estado de Reparación"></asp:Label>
                                    <asp:DropDownList ID="cboEstadoReparacion" AutoPostBack="true" class="form-control" runat="server" AppendDataBoundItems="true" DataTextField="DESCRIPCION" DataValueField="CODIGO" OnSelectedIndexChanged="cboEstadoReparacion_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Seleccione un Estado de Reparación</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group col-md-6">
                                    <asp:Label ID="Label2" runat="server" Text="Fecha Cierre"></asp:Label>
                                    <asp:TextBox ID="txtFecha" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" Text="Observación" cols="50"></asp:Label>
                                <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>

                            <div class="form-row">
<%--                                <div class="form-group col-md-6">
                                    <asp:Label ID="Label4" runat="server" Text="Partida"></asp:Label>
                                    <asp:DropDownList ID="cboPartida" class="form-control" runat="server" AppendDataBoundItems="true" DataTextField="DESCRIPCION" DataValueField="CODIGO">
                                        <asp:ListItem Value="0">Seleccione una Partida</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>--%>

                                <div class="form-group col-md-6">
                                    <asp:Label ID="Label6" runat="server" Text="Tipo de Observación"></asp:Label>
                                    <asp:DropDownList ID="cboTipoObservacion" AutoPostBack="true"  runat="server" CssClass="form-control" AppendDataBoundItems="true" DataTextField="DESCRIPCION" DataValueField="CODIGO" OnSelectedIndexChanged="cboTipoObservacion_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Seleccione un Tipo de Observación</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group col-md-6">
                                    <asp:Label ID="Label1" runat="server" Text="Comentario"></asp:Label>
                                    <asp:TextBox ID="txtComentario" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                            <div runat="server" id="divMensajePopUp" role="alert">
                                <asp:Label ID="lblMensajePopUp" runat="server" Text=""></asp:Label>
                            </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-success" Text="Guardar cambios" OnClick="btnModificar_Click" />
                            <asp:Button ID="btnCerrarPop" runat="server" CssClass="btn btn-primary" Text="Cerrar" OnClick="btnCerrarPop_Click" />
                        </div>
                                <asp:Label ID="txtCodigo" runat="server" ForeColor="Transparent"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        </div>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MenuPrincipal.aspx">Volver</asp:HyperLink>
        <script src="context/js/jquery-3.1.1.min.js"></script>
        <script src="context/bootstrap-4.3.1-dist/js/bootstrap.min.js"></script>
        <script src="context/js/ModificarDatos.js"></script>
    </form>
</body>
</html>
