<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CargarExcel.aspx.cs" Inherits="CargarExcel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Carga de Excel</title>
    <link rel="stylesheet" href="context/bootstrap-4.3.1-dist/css/bootstrap.min.css" />
    <script src="context/bootstrap-4.3.1-dist/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:90%;margin:0 auto;">
            <h1 style="text-align:center;">Cargar Excel</h1>
            <div class="form-row">
                <%--<div class="custom-file col-md-4 form-group">
                    <asp:FileUpload ID="FileUpload1" CssClass="custom-file-input" runat="server" />
                    <label class="custom-file-label" for="FileUpload1">Seleccionar archivo</label>
                </div>--%>
                <div class="col-md-4 form-group">
                    <asp:FileUpload ID="FileUpload1" CssClass="" runat="server" />
                </div>
                <div class="form-group col-md-2">
                    <asp:Button ID="btnCargar" CssClass="btn btn-primary" runat="server" Text="Cargar" OnClick="btnCargar_Click" />
                </div>
                <div class="form-group col-md-6 justify-content-end">
                    <asp:HyperLink ID="HyperLink2" NavigateUrl="~/MenuPrincipal.aspx" runat="server">Volver a menú principal</asp:HyperLink>
                </div>
            </div>
            <br />
            <div class="form-row justify-content-center">
                <div runat="server" id="divMensaje" style="margin:10px auto" role="alert">
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <br />
            <asp:Button ID="btnGrabar" CssClass="btn btn-primary" runat="server" Text="Grabar Datos" OnClick="btnGrabar_Click" />
            <asp:GridView ID="gridExcel" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="false" PageSize="20" Width="100%" AutoGenerateColumns="false" OnRowDataBound="gridExcel_RowDataBound" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Index">
                        <ItemTemplate >
                            <asp:Label ID="Index" runat="server" Width="30px" Text='<%# Eval("Sec#") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Inmobiliaria" HeaderText="Inmobiliaria" SortExpression="Inmobiliaria" />
                    <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" SortExpression="Proyecto" />
                    <asp:BoundField DataField="Supervisor Constructora" HeaderText="Supervisor Constructora" SortExpression="Supervisor Constructora" />
                    <asp:BoundField DataField="Solicitante Supervisor Inmob#" HeaderText="Solicitante Supervisor Inmob." SortExpression="Solicitante Supervisor Inmob#" />
                    
                    <asp:TemplateField HeaderText="Fecha">
                        <ItemTemplate >
                            <asp:Label ID="Fecha" runat="server" Width="100px" Text='<%# Bind("Fecha") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Departamento">
                        <ItemTemplate >
                            <asp:Label ID="Inmueble" runat="server" Text='<%# Bind("DEPTO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Observación">
                        <ItemTemplate >
                            <asp:Label ID="Observación" runat="server" Width="400px" Text='<%# Eval("Observación") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="Propietario" HeaderText="Propietario" SortExpression="Propietario" />
                    <asp:BoundField DataField="Rut" HeaderText="Rut" SortExpression="Rut" />
                    
                    <asp:TemplateField HeaderText="Fecha Entrega">
                        <ItemTemplate >
                            <asp:Label ID="FechaEntrega" runat="server" Width="100px" Text='<%# Eval("Fecha Entrega") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="Residente" HeaderText="Residente" SortExpression="Residente" />
                    <asp:BoundField DataField="Teléfono" HeaderText="Teléfono" SortExpression="Teléfono" />
                    
                    <asp:TemplateField HeaderText="Fecha Coordinacion">
                        <ItemTemplate >
                            <asp:Label ID="FechaCoordinacion" runat="server" Width="100px" Text='<%# Eval("Fecha Coordinación") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Hora Inicio">
                        <ItemTemplate >
                            <asp:Label ID="HoraInicio" runat="server" Width="100px" Text='<%# Eval("Hora Inicio") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Hora Término">
                        <ItemTemplate >
                            <asp:Label ID="HoraTermino" runat="server" Width="100px" Text='<%# Eval("Hora Termino") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <%--<asp:BoundField DataField="Tipo Obs#" HeaderText="Tipo Obs#" SortExpression="TipoObs#" />--%>
                    <asp:BoundField DataField="Tipo de Inmueble" HeaderText="Tipo de Inmueble" SortExpression="Tipo de Inmueble" />
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
        </div>
        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/MenuPrincipal.aspx" runat="server">Volver</asp:HyperLink>
        <script src="context/bootstrap-4.3.1-dist/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
