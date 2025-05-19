<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarSucursalesSeleccionadas.aspx.cs" Inherits="TP7_GRUPO_4.MostrarSucursalesSeleccionadas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="hlListadoSucursales" runat="server" NavigateUrl="~/Ejercicio/WebForm1.aspx">Listado de Sucursales</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hlMostrarSucursalesSeleccionadas" runat="server" NavigateUrl="~/MostrarSucursalesSeleccionadas.aspx">Mostrar Sucursales Seleccionadas</asp:HyperLink>
        </div>
        <asp:GridView ID="gvSeleccionados" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="IdSucursal" HeaderText="ID_SUCURSAL"/>
                <asp:BoundField DataField="NombreSucursal" HeaderText="NOMBRE"/>
                <asp:BoundField DataField="DescripcionSucursal" HeaderText="DESCRIPCION"/>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
