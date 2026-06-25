using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Conexion;

namespace Mainpage
{
    public partial class incidencias : System.Web.UI.Page
    {
        public List<incidencia> ListaDeIncidencias { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ManejadorIncidencias conexionlista = new ManejadorIncidencias();
            ListaDeIncidencias = conexionlista.Listar();

            if (!IsPostBack)
            {
                //Session.Clear();
                DGVIncidencias.DataSource = ListaDeIncidencias;
                DGVIncidencias.DataBind();

                //if (Session["Mensaje"] != null)
                //{
                //    LBMensaje.Text = Session["Mensaje"].ToString();
                //    LBMensaje.CssClass = Session["ClaseMensaje"].ToString();

                //    Session.Remove("Mensaje");
                //    Session.Remove("ClaseMensaje");
                //}

            }
        }
    }
}