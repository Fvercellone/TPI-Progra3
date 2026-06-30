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
        public List<incidencia> ListaDeIncidencias { get; set; } = new List<incidencia>();

        ManejadorIncidencias conexion = new ManejadorIncidencias();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarIncidencias();
            }
        }

        private void CargarIncidencias()
        {
            try
            {
            if (Session["IDUsuario"] == null)
            {
                LBMensaje.Text = "No se encontró el usuario logueado.";
                return;
            }

            }
            catch (Exception ex)
            {

                LBMensaje.Text = ex.Message;
                LBMensaje.CssClass = "alert alert-danger d-block";
            }

            int idUsuario = Convert.ToInt32(Session["IDUsuario"]);

            ListaDeIncidencias = conexion.FiltrarIncidenciasPorUsuario(idUsuario);

            RptIncidencias.DataSource = ListaDeIncidencias;
            RptIncidencias.DataBind();
        }

        protected void RptIncidencias_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                int id = int.Parse(e.CommandArgument.ToString());

                if (e.CommandName == "AbrirIncidencia")
                {
                    Session["ID"] = id;
                    Session["Accion"] = "";

                    Response.Redirect("vistaIncidencia.aspx");
                }
            }
            catch (Exception ex)
            {
                LBMensaje.Text = ex.Message;
                LBMensaje.CssClass = "alert alert-danger d-block";
            }
        }

        protected void BTNAgregarIncidencia_Click(object sender, EventArgs e)
        {
            Session.Remove("ID");
            Session["Accion"] = "";

            Response.Redirect("vistaIncidencia.aspx");
        }
    }
}