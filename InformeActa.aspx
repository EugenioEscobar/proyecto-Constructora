<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InformeActa.aspx.cs" Inherits="InformeActa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="context/bootstrap-4.3.1-dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="context/fontawesome-free-5.11.2-web/css/all.min.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <br />
            <div class="form-row">
                <div class="form-group col-md-2">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/context/Imagenes/UPC_Logo.jpeg" />
                </div>
                <div class="form-group col-md-8">
                    <h1 style="text-align:center;">Acta de conformidad</h1>
                </div>
                <div class="form-group col-md-2">
                    <asp:LinkButton runat="server" CssClass="btn btn-dark" OnClientClick="window.print();">Imprimir <i class="fas fa-print fa-lg"></i></asp:LinkButton>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label1" runat="server" Text="Inmobiliaria"></asp:Label>
                    <asp:Label ID="txtInmobiliaria" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-6">
                    <asp:Label ID="Label2" runat="server" Text="N° de Acta"></asp:Label>
                    <asp:Label ID="txtNumActa" runat="server" CssClass="form-control"></asp:Label>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label3" runat="server" Text="Proyecto"></asp:Label>
                    <asp:Label ID="txtProyecto" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-6">
                    <asp:Label ID="Label4" runat="server" Text="Departamento"></asp:Label>
                    <asp:Label ID="txtInmueble" runat="server" CssClass="form-control"></asp:Label>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-4">
                    <asp:Label ID="Label5" runat="server" Text="Fecha Coordinación"></asp:Label>
                    <asp:Label ID="txtFechaCoordinacion" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <asp:Label ID="Label6" runat="server" Text="Hora"></asp:Label>
                    <asp:Label ID="txtHora" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="form-group col-md-4">
                    <asp:Label ID="Label7" runat="server" Text="Supervisor"></asp:Label>
                    <asp:Label ID="txtSupervisor" runat="server" CssClass="form-control"></asp:Label>
                </div>
            </div>

            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" AutoGenerateColumns="false" style="width:100%">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Observacion" HeaderText="Observacion" HeaderStyle-Width="70%" ItemStyle-Width="70%" />
                    <asp:TemplateField HeaderText="Comentario">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelGrid" Text=""></asp:Label>
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

            <div runat="server" id="div"></div>

            <div class="form-row" style="margin: 100px 0;">
                <div class="form-group col-sm-4">
                    <div class="box-firma">
                        <asp:TextBox runat="server" ID="TextBox" TextMode="MultiLine" CssClass="form-control" Rows="3"></asp:TextBox>
                    </div>
                    <div class="box-titulo-firma text-center">
                        <asp:Label ID="Label8" runat="server" Text="Recepción propietario firma"></asp:Label>
                    </div>
                </div>
                <div class="form-group col-sm-4">
                    <div class="box-firma">
                        <asp:TextBox runat="server" ID="TextBox1" TextMode="MultiLine" CssClass="form-control" Rows="3"></asp:TextBox>
                    </div>
                    <div class="box-titulo-firma text-center">
                        <asp:Label ID="Label9" runat="server" Text="Supervisor Post-Venta UPC"></asp:Label>
                    </div>
                </div>
                <div class="form-group col-sm-4">
                    <div class="box-firma">
                        <asp:TextBox runat="server" ID="TextBox2" TextMode="MultiLine" CssClass="form-control" Rows="3"></asp:TextBox>
                    </div>
                    <div class="box-titulo-firma text-center">
                        <asp:Label ID="Label10" runat="server" Text="Recepción Inmobiliaria"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
