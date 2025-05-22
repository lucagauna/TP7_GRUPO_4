using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
            if (int.TryParse(e.CommandArgument.ToString(), out int idProvincia))
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

            Button btn = (Button)sender;
            lblFilter.Text = btn.Text;
        }

        protected void lvSucursales_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager pager = (DataPager)lvSucursales.FindControl("DataPager1");
            pager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            var sucursales = manager.ListarSucursales();
            lvSucursales.DataSource = sucursales;
            lvSucursales.DataBind();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string sucToSearch = SearchTextBox.Text.Trim();
            var sucursales = manager.BuscarPorNombre(sucToSearch);
            Debug.Print("sucursales: " + sucursales.Count.ToString());

            if (SearchTextBox.Text.Trim() == "" && sucursales.Count > 0)
            {
                lblErrorToSearch.Visible = true;
                lblErrorToSearch.Text = "Ingrese el nombre de la sucursal que desea buscar";
                SearchTextBox.Text = "";
                lblFilter.Text = "Ninguno";
            }
            else if (sucursales.Count <= 0)
            {
              lblErrorToSearch.Visible = true;
              lblErrorToSearch.Text = "No se encontraron resultados";
                SearchTextBox.Text = "";
                lblFilter.Text = "Nombre sucursal";
            }
            else if (sucursales.Count > 0)
            {
                lblErrorToSearch.Visible = false;
                lblErrorToSearch.Text.ToString().Equals("");
                SearchTextBox.Text = "";
                lblFilter.Text = "Nombre sucursal";
            }
            lvSucursales.DataSource = sucursales;
            lvSucursales.DataBind();
        }

        protected void btnSelected_Command(object sender, CommandEventArgs e)
        {
            int IDSuc = Convert.ToInt32(e.CommandArgument);
            var sucursales = manager.BuscarPorID(IDSuc);
            if (sucursales != null)
            {
                List<Sucursal> seleccionadas = Session["SucursalesSeleccionadas"] as List<Sucursal> ?? new List<Sucursal>();
                bool existe = false;
                foreach (var item in seleccionadas)
                {
                    if (item.IdSucursal == IDSuc)
                    {
                        existe = true;
                        break;
                    }
                }
                if (!existe)
                {
                    seleccionadas.Add(sucursales);
                    Session["SucursalesSeleccionadas"] = seleccionadas;
                }
            }

        }

        protected void btnProvincias_Click(object sender, EventArgs e)
        {
            SearchTextBox.Text = string.Empty;
        }
    }
}