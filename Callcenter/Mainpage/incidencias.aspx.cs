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

        public List<estado> listaEstado { get; set; } = new List<estado>();
        public List<Prioridad> listaPrioridades { get; set; } = new List<Prioridad>();
        public List<categoria> listaCategorias { get; set; } = new List<categoria>();
        ManejadorIncidencias conexion = new ManejadorIncidencias();
        ManejadorDDL DLL = new ManejadorDDL();

        public bool FiltroAvanzado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            listaEstado = DLL.ListarEstados();
            listaPrioridades = DLL.ListarPrioridades();
            listaCategorias = DLL.ListarCategorias();


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



            if (chkAvanzado.Checked && ddlCampo.SelectedValue != "Categoria" && ddlCampo.SelectedValue != "Prioridad")
            {

                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");

                btnBuscar.Enabled = false;
                ddlEstado.DataSource = listaEstado;
                ddlEstado.DataTextField = "Nombre";
                ddlEstado.DataValueField = "id";
                ddlEstado.DataBind();
            }
            else
            {
                btnBuscar.Enabled = true;
                ddlCriterio.Items.Clear();
                CargarIncidencias();

            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {


            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "ID" )
            {
                txtFiltroAvanzado.Text = "";
                btnBuscar.Enabled = false;
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                txtFiltroAvanzado.TextMode = TextBoxMode.Number;

            }else if (ddlCampo.SelectedItem.ToString() == "Prioridad")
            {
                btnBuscar.Enabled = true;
                ddlFiltro.DataSource = listaPrioridades;
                ddlFiltro.DataTextField = "Nombre";
                ddlFiltro.DataValueField = "id";
                ddlFiltro.DataBind();
            }else if (ddlCampo.SelectedItem.ToString() == "Categoria")
            {
                btnBuscar.Enabled = true;
                ddlFiltro.DataSource = listaCategorias;
                ddlFiltro.DataTextField = "Nombre";
                ddlFiltro.DataValueField = "id";
                ddlFiltro.DataBind();
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                txtFiltroAvanzado.TextMode = TextBoxMode.SingleLine;
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios usuario = Session["usuario"] as Usuarios;
                string filtro = (ddlCampo.SelectedValue == "Prioridad" || ddlCampo.SelectedValue == "Categoria") ? ddlFiltro.SelectedValue : txtFiltroAvanzado.Text;
                ListaDeIncidencias = conexion.Listafiltrada(
                    ddlCampo.SelectedValue,
                    ddlCriterio.SelectedValue,
                    filtro,
                    ddlEstado.SelectedValue,
                    usuario.DNI,
                    usuario.IDRol
                );

                RptIncidencias.DataSource = ListaDeIncidencias;
                RptIncidencias.DataBind();

                if (ListaDeIncidencias.Count == 0)
                {
                    LBMensaje.Text = "No se encontraron incidencias con esos filtros.";
                    LBMensaje.CssClass = "alert alert-warning d-block";
                }
                else
                {
                    LBMensaje.Text = "";
                    LBMensaje.CssClass = "";
                }
            }
            catch (Exception ex)
            {
                LBMensaje.Text = ex.Message;
                LBMensaje.CssClass = "alert alert-danger d-block";
            }
        }

    }
}