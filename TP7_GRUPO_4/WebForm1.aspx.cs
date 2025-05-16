using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP7_GRUPO_4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
          SucursalManager manager = new SucursalManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {

           
                if (!IsPostBack)
                {
                
                List<Sucursal> sucursales = manager.ListarSucursales();
                lvSucursales.DataSource = sucursales;
                lvSucursales.DataBind();
           
            }

            

        }



        protected void btnProvincias_Command(object sender, CommandEventArgs e)
        {

            int idProvincia;
            if (int.TryParse(e.CommandArgument.ToString(), out idProvincia))
            {
               
                var sucursales = manager.BuscarPorProvincia(idProvincia);
                lvSucursales.DataSource = sucursales;
                lvSucursales.DataBind();
            }
            else
            {
                
               
                var sucursales = manager.ListarSucursales();
                lvSucursales.DataSource = sucursales;
                lvSucursales.DataBind();
            }

        }

        protected void lvSucursales_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager pager = (DataPager)lvSucursales.FindControl("DataPager1");
            pager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
          
            var sucursales = manager.ListarSucursales();
            lvSucursales.DataSource = sucursales;
            lvSucursales.DataBind();
        }




    }
}