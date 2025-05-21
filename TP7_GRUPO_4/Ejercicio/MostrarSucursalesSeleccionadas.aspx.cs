using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP7_GRUPO_4
{
    public partial class MostrarSucursalesSeleccionadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var seleccionadas = (List<Sucursal>)Session["SucursalesSeleccionadas"];
                if (seleccionadas != null)
                {
                    gvSeleccionados.DataSource = seleccionadas;
                    gvSeleccionados.DataBind();

                    btnLimpiarSeleccion.Visible = true; // Mostrar el botón si hay datos
                }
                else
                {
                    btnLimpiarSeleccion.Visible = false; // Ocultar si no hay datos
                }
            }
        }

        protected void btnLimpiarSeleccion_Click(object sender, EventArgs e)
        {
            Session["SucursalesSeleccionadas"] = null;
            gvSeleccionados.DataSource = null;
            gvSeleccionados.DataBind();

            btnLimpiarSeleccion.Visible = false;
            lblMensaje.Text = "Sucursales seleccionadas eliminadas.";
        }

        protected void gvSeleccionados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}