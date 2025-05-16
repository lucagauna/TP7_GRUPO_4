using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TP7_GRUPO_4
{
    public class SucursalManager
    {
        DataBaseManager db = new DataBaseManager();
        public  DataTable ObtenerSucursalesPorProvincia(string provincia)
        {
            
            string consulta = "SELECT NombreSucursal, URL_Imagen_Sucursal, DescripcionSucursal FROM Sucursal WHERE Provincia = @provincia";

            using (SqlConnection conn = db.RecibirConexion())
            {
                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@provincia", provincia);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }

        public  DataTable ObtenerTodasLasSucursales()
        {
            DataBaseManager db = new DataBaseManager();
            string consulta = "SELECT NombreSucursal, URL_Imagen_Sucursal, DescripcionSucursal, Id_ProvinciaSucursal FROM Sucursal";

            using (SqlConnection conn = db.RecibirConexion())
            {
                SqlCommand cmd = new SqlCommand(consulta, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }


    }
}