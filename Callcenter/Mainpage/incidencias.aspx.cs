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
        ManejadorIncidencias conexion = new ManejadorIncidencias();

        protected void Page_Load(object sender, EventArgs e)
        {
            ListaDeIncidencias = conexion.Listar();

            if (!IsPostBack)
            {
                Session.Clear();
                RptIncidencias.DataSource = ListaDeIncidencias;
                RptIncidencias.DataBind();

            }
        }

        //protected void DGVIncidencias_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        int id = int.Parse(e.CommandArgument.ToString());

        //        if (e.CommandName == "Modificar")
        //        {
        //            Session["ID"] = id;
        //            Session["Accion"] = "Modificar";
        //            //Response.Redirect("formularioIncidencias.aspx");
        //            Response.Redirect("vistaIncidencia.aspx");
        //        }
        //        else if (e.CommandName == "Reasignar")
        //        {
        //            Session["ID"] = id;
        //            Session["Accion"] = "Reasignar";
        //            Response.Redirect("formularioIncidencias.aspx");
        //        }
        //        else if (e.CommandName == "Resolver")
        //        {
        //            Session["ID"] = id;
        //            Session["Accion"] = "Resolver";
        //            Response.Redirect("formularioIncidencias.aspx");
        //        }
        //        else if (e.CommandName == "Cerrar")
        //        {
        //            ManejadorIncidencias conexion = new ManejadorIncidencias();
        //            conexion.Cerrar(id);

        //            Response.Redirect("Incidencias.aspx");
        //        }
        //        else if (e.CommandName == "Re-abrir")
        //        {
        //            ManejadorIncidencias conexion = new ManejadorIncidencias();
        //            conexion.Reabrir(id);
        //            Response.Redirect("Incidencias.aspx");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LBMensaje.Text = ex.Message;
        //        LBMensaje.CssClass = "alert alert-danger d-block";
        //    }
        //}


        protected void RptIncidencias_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                    int id = int.Parse(e.CommandArgument.ToString());

                    if (e.CommandName == "AbrirIncidencia")
                    {
                        Session["ID"] = e.CommandArgument.ToString();
                        Session["Accion"] = "";
                        Response.Redirect("vistaIncidencia.aspx");
                    }


            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
    }
}