using Conexion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mainpage
{
    public partial class personas : System.Web.UI.Page
    {

        public List<Personas> ListaDePersonas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ManejadorPersonas conexionlista = new ManejadorPersonas();
            ListaDePersonas = conexionlista.Listar();
            
            if(!IsPostBack)
            {
                //Session.Clear();
                DGVPersonas.DataSource = ListaDePersonas;
                DGVPersonas.DataBind();

                if (Session["Mensaje"] != null)
                {
                    LBMensaje.Text = Session["Mensaje"].ToString();
                    LBMensaje.CssClass = Session["ClaseMensaje"].ToString();

                    Session.Remove("Mensaje");
                    Session.Remove("ClaseMensaje");
                }

            }

        }

        private void ocultarColumnas()
        {
            DGVPersonas.Columns[0].Visible = false; // ID
        }

        protected void DGVPersonas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            
            try
            {
                string dni = e.CommandArgument.ToString();

                ManejadorPersonas conexion = new ManejadorPersonas();

                if (e.CommandName == "Eliminar")
                {
                    conexion.Eliminar(dni);

                    Session["Mensaje"] = "Usuario dado de baja correctamente.";
                    Session["ClaseMensaje"] = "alert alert-success d-block";

                    Response.Redirect("Personas.aspx");
                }
                else if (e.CommandName == "Activar")
                {
                    conexion.Activar(dni);

                    Session["Mensaje"] = "Usuario activado correctamente.";
                    Session["ClaseMensaje"] = "alert alert-success d-block";

                    Response.Redirect("Personas.aspx");
                }
                else if (e.CommandName == "Modificar")
                {
                    Session.Add("DNI",dni);
                    Response.Redirect("formularioPersonas.aspx");
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