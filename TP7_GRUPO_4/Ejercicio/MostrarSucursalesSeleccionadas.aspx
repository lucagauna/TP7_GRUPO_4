<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarSucursalesSeleccionadas.aspx.cs" Inherits="TP7_GRUPO_4.MostrarSucursalesSeleccionadas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 63px;
        }
        .auto-style3 {
            height: 136px;
        }
        .auto-style4 {
            width: 436px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style4">
            <asp:HyperLink ID="hlListadoSucursales" runat="server" NavigateUrl="~/Ejercicio/WebForm1.aspx">Listado de Sucursales</asp:HyperLink>
                </td>
                <td>
            <asp:HyperLink ID="hlMostrarSucursalesSeleccionadas" runat="server" NavigateUrl="~/Ejercicio/MostrarSucursalesSeleccionadas.aspx">Mostrar Sucursales Seleccionadas</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2" colspan="2">
                    <asp:Label ID="lbl1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Mostrar Sucursales seleccionadas"></asp:Label>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style3" colspan="2">
        <asp:GridView ID="gvSeleccionados" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvSeleccionados_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="IdSucursal" HeaderText="ID_SUCURSAL"/>
                <asp:BoundField DataField="NombreSucursal" HeaderText="NOMBRE"/>
                <asp:BoundField DataField="DescripcionSucursal" HeaderText="DESCRIPCION"/>
            </Columns>
        </asp:GridView>
                </td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style4">
        <asp:Button ID="btnLimpiarSeleccion" runat="server" OnClick="btnLimpiarSeleccion_Click" Text="Limpiar Seleccion" Visible="False" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <p style="margin-left: 40px">
        <asp:Label ID="lblMensaje" runat="server" ForeColor="#33CC33"></asp:Label>
        </p>
    </form>
</body>
</html>
