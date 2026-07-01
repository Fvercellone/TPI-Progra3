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

        public bool FiltroAvanzado { get; set; }

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
                    Session["IDincidencia"] = id;
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

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<incidencia> lista = (List<incidencia>)Session["listaIncidencias"];
            List<incidencia> listaFiltradaIncidencias = lista.FindAll(x => x.titulo.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            RptIncidencias.DataSource = listaFiltradaIncidencias;
            RptIncidencias.DataBind();
        }

        protected void filtroAvanzado_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltroAvanzado.Text == "")
            {
                btnBuscar.Enabled = false;
            }
            else
            {
                btnBuscar.Enabled = true;
            }
        }


        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
            if (chkAvanzado.Checked)
            {

                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");

                btnBuscar.Enabled = false;
            }
            else
            {
                ddlCriterio.Items.Clear();
                CargarIncidencias();

            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {


            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() != "ID" )
            {

                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                txtFiltroAvanzado.TextMode = TextBoxMode.SingleLine;
            }
            else
            {
                txtFiltroAvanzado.Text = "";
                btnBuscar.Enabled = false;
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                txtFiltroAvanzado.TextMode = TextBoxMode.Number;

            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                ListaDeIncidencias = conexion.ListarFiltrada(
                    ddlCampo.SelectedValue,
                    ddlCriterio.SelectedValue,
                    txtFiltro.Text,
                    ddlEstado.SelectedValue
                );
                RptIncidencias.DataSource = ListaDeIncidencias;
                RptIncidencias.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

    }
}