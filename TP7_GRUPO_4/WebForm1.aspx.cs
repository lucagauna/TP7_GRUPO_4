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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) {
                BddSucursales.SelectParameters["IdProvincia"].DefaultValue = "-1";
                lvSucursales.DataBind();
               
            }

        }







        protected void btnProvincias_Command(object sender, CommandEventArgs e)
        {
            
            int idProvincia;
            if (int.TryParse(e.CommandArgument.ToString(), out idProvincia))
            {
                BddSucursales.SelectParameters["IdProvincia"].DefaultValue = idProvincia.ToString();
            }
            else
            {
                
                BddSucursales.SelectParameters["IdProvincia"].DefaultValue = "-1";
            }
            lvSucursales.DataBind();
        }
    }
}