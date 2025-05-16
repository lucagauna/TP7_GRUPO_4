using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TP7_GRUPO_4
{
    public class DataBaseManager
    {
        string LinkConexion = @"Data Source=.\SQLEXPRESS;Initial Catalog=BDSucursales;Integrated Security=True;Encrypt=False";

        public DataBaseManager()
        {
            
        }

        public SqlConnection RecibirConexion()
        {
            SqlConnection connect = new SqlConnection(LinkConexion);
            try
            {
                connect.Open();
                return connect;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SqlDataAdapter RecibirAdapter(string consulta)
        {
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(consulta, RecibirConexion());
                return adapter;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int EjecutarProcedimientoAlmacenado(SqlCommand cmdSQL, string nameProcedure)
        {
            int FilasCambiadas;
            SqlConnection conect = RecibirConexion();
            SqlCommand cmdPA = new SqlCommand();
            cmdPA = cmdSQL;
            cmdPA.Connection = conect;
            cmdPA.CommandType = CommandType.StoredProcedure;    /// TIPO DE COMANDO (PROCEDIMIENTO ALMACENADO -- "PROCEDURE")
            cmdPA.CommandText = nameProcedure;                  /// NOMBRE DEL PROCEDIMIENTO ALMACENADO
            FilasCambiadas = cmdPA.ExecuteNonQuery();          /// EJECUTAR PROCEDIMIENTO ALMACENADO
            conect.Close();
            return FilasCambiadas;
        }
    }
}
