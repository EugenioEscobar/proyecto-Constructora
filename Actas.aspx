<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Actas.aspx.cs" Inherits="Informes_Actas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../context/bootstrap-4.3.1-dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../context/fontawesome-free-5.11.2-web/css/all.min.css" />
   
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  <asp:Image ID="Image1" runat="server" Height="40px" ImageUrl="~/context/Imagenes/UPC_Logo.jpeg" Width="77px" />
    <div class="container">
        <div class="form-row">
            <h1 style="text-align:center;">Generar Acta</h1>
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="Label2" runat="server" Text="Fecha Inicio :  "></asp:Label>
                <asp:TextBox ID="txtFechaInicio" CssClass="form-control" runat="server" AutoPostBack="true" TextMode="Date" OnTextChanged="txtFechaInicio_TextChanged"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="Label3" runat="server" Text="Fecha Término:  "></asp:Label>
                <asp:TextBox ID="txtFechaTermino" CssClass="form-control" runat="server" AutoPostBack="true" TextMode="Date" OnTextChanged="txtFechaTermino_TextChanged"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Supervisor Constructora :   "></asp:Label>
                <asp:DropDownList ID="cboSupervisor" CssClass="form-control" runat="server" AppendDataBoundItems="true" DataTextField="NOMBRE" DataValueField="CODIGO" AutoPostBack="True" OnSelectedIndexChanged="cboSupervisor_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Seleccione un supervisor</asp:ListItem>
                    <asp:ListItem Value="0">Todos los supervisores</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <br />
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnGenerarActas" runat="server" Text="Generar actas" OnClick="btnGenerarActas_Click" />
        <p>
            <asp:GridView ID="GridView1" runat="server" style="text-align:center;" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="NombreInmobiliaria" HeaderText="Inmobiliaria" SortExpression="NombreInmobiliaria" />
                    <asp:BoundField DataField="NombreProy" HeaderText="Proyecto" SortExpression="NombreProy" />
                    <asp:BoundField DataField="SupervisorConstructora" HeaderText="Supervisor Constructora" SortExpression="SupervisorConstructora" />
                    <asp:BoundField DataField="SupervisorInmobiliaria" HeaderText="Supervisor Inmobiliaria" SortExpression="SupervisorInmobiliaria" />
                    <asp:BoundField DataField="NumInmueble" HeaderText="Departamento" SortExpression="NumInmueble" />
                    
                    <asp:TemplateField HeaderText="IdObservacion" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="IdObservacion" runat="server" Text='<%# Bind("IDObs") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="IdCoordinacion" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="IdCoordinacion" runat="server" Text='<%# Bind("id_tabla") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Observacion" HeaderText="Observacion" SortExpression="Observación" />

                    <asp:TemplateField HeaderText="Fecha Coordinación">
                        <ItemTemplate>
                            <asp:Label ID="fechaCoordinacion" runat="server" Text='<%# Bind("FechaCoordinacion") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Imprimir">
                        <ItemTemplate>
                            <asp:LinkButton ID="ImageButton1" runat="server"  Text="<i class='far fa-file-alt' style='font-size:28px;'></i>"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                CommandName="Imprimir" />
                        </ItemTemplate>
                    </asp:TemplateField>
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
    <div>
           <%--<asp:Button ID="btnBuscar" CssClass="btn btn-success col-md-8 btn-block btn-lg" runat="server" Text="Buscar" OnClick="" />--%>
     </div>           
    </form>
</body>
</html>
