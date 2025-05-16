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
        private DataBaseManager db = new DataBaseManager();



        public List<Sucursal> ListarSucursales()
        {
            var sucursales = new List<Sucursal>();
            string query = @"SELECT S.NombreSucursal, S.URL_Imagen_Sucursal, S.DescripcionSucursal, 
                            P.DescripcionProvincia AS Provincia, S.Id_ProvinciaSucursal
                     FROM Sucursal S
                     INNER JOIN Provincia P ON S.Id_ProvinciaSucursal = P.Id_Provincia";

            using (var reader = db.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    sucursales.Add(new Sucursal
                    {
                        NombreSucursal = reader["NombreSucursal"].ToString(),
                        URL_Imagen_Sucursal = reader["URL_Imagen_Sucursal"].ToString(),
                        DescripcionSucursal = reader["DescripcionSucursal"].ToString(),
                        Provincia = reader["Provincia"].ToString(),
                        idProvinciaSucursal = Convert.ToInt32(reader["Id_ProvinciaSucursal"])
                    });
                }
            }
            return sucursales;
        }
        public List<Sucursal> BuscarPorProvincia(int idProvincia)
        {
            var sucursales = new List<Sucursal>();
            string query = @"SELECT S.NombreSucursal, S.URL_Imagen_Sucursal, S.DescripcionSucursal, 
                            P.DescripcionProvincia AS Provincia, S.Id_ProvinciaSucursal
                     FROM Sucursal S
                     INNER JOIN Provincia P ON S.Id_ProvinciaSucursal = P.Id_Provincia
                     WHERE S.Id_ProvinciaSucursal = @IdProvincia";
            var parametros = new SqlParameter[] {
            new SqlParameter("@IdProvincia", idProvincia)
        };

            using (var reader = db.ExecuteReader(query, parametros))
            {
                while (reader.Read())
                {
                    sucursales.Add(new Sucursal
                    {
                        NombreSucursal = reader["NombreSucursal"].ToString(),
                        URL_Imagen_Sucursal = reader["URL_Imagen_Sucursal"].ToString(),
                        DescripcionSucursal = reader["DescripcionSucursal"].ToString(),
                        Provincia = reader["Provincia"].ToString(),
                        idProvinciaSucursal = Convert.ToInt32(reader["Id_ProvinciaSucursal"])
                    });
                }
            }
            return sucursales;
        }

        public List<Sucursal> BuscarPorNombre(string nombre)
        {
            var sucursales = new List<Sucursal>();
            string query = @"SELECT S.NombreSucursal, S.URL_Imagen_Sucursal, S.DescripcionSucursal, 
                            P.DescripcionProvincia AS Provincia, S.Id_ProvinciaSucursal
                     FROM Sucursal S
                     INNER JOIN Provincia P ON S.Id_ProvinciaSucursal = P.Id_Provincia
                     WHERE S.NombreSucursal LIKE '%' + @Nombre + '%'";
            var parametros = new SqlParameter[] {
            new SqlParameter("@Nombre", nombre ?? "")
        };

            using (var reader = db.ExecuteReader(query, parametros))
            {
                while (reader.Read())
                {
                    sucursales.Add(new Sucursal
                    {
                        NombreSucursal = reader["NombreSucursal"].ToString(),
                        URL_Imagen_Sucursal = reader["URL_Imagen_Sucursal"].ToString(),
                        DescripcionSucursal = reader["DescripcionSucursal"].ToString(),
                        Provincia = reader["Provincia"].ToString(),
                        idProvinciaSucursal = Convert.ToInt32(reader["Id_ProvinciaSucursal"])
                    });
                }
            }
            return sucursales;
        }
    }

}