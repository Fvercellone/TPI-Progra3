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
                Session.Clear();
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

        protected void DGVIncidencias_RowCommand(object sender, GridViewCommandEventArgs e)
{
    try
    {
        int id = int.Parse(e.CommandArgument.ToString());

        if (e.CommandName == "Modificar")
        {
            Session["ID"] = id;
            Session["Accion"] = "Modificar";
            Response.Redirect("formularioIncidencias.aspx");
        }
        else if (e.CommandName == "Reasignar")
        {
            Session["ID"] = id;
            Session["Accion"] = "Reasignar";
            Response.Redirect("formularioIncidencias.aspx");
        }
        else if (e.CommandName == "Resolver")
        {
            Session["ID"] = id;
            Session["Accion"] = "Resolver";
            Response.Redirect("formularioIncidencias.aspx");
        }
        else if (e.CommandName == "Cerrar")
        {
            ManejadorIncidencias conexion = new ManejadorIncidencias();
            conexion.Cerrar(id);

            Response.Redirect("Incidencias.aspx");
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