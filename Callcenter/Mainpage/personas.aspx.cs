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

        public List<Personas> ListaDePersonas { get; set; } = new List<Personas>();

        ManejadorPersonas conexion = new ManejadorPersonas();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Pagina"] = "Personas";
                CargarPersonas();
            }
        }

        private void CargarPersonas()
        {
            try
            {
            ListaDePersonas = conexion.Listar();

            RptPersonas.DataSource = ListaDePersonas;
            RptPersonas.DataBind();


            }
            catch (Exception ex)
            {

                LBMensaje.Text = ex.Message;
                LBMensaje.CssClass = "alert alert-danger d-block";
            }

           

        }

        protected void RptPersonas_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string dni = e.CommandArgument.ToString();

            if (e.CommandName == "Modificar")
            {
                Session["DNI"] = dni;
                Response.Redirect("formularioPersonas.aspx");
            }
            else if (e.CommandName == "Ver")
            {
                Session["DNI"] = dni;
                Response.Redirect("formularioPersonas.aspx");
            }
            else if (e.CommandName == "Eliminar")
            {
                ManejadorPersonas conexion = new ManejadorPersonas();
                conexion.Eliminar(dni);
                Response.Redirect("personas.aspx");
            }
            else if (e.CommandName == "Activar")
            {
                ManejadorPersonas conexion = new ManejadorPersonas();
                conexion.Activar(dni);
                Response.Redirect("personas.aspx");
            }
        }

        protected void Agregar_onclick(object sender, EventArgs e)
        {
            
            Session.Remove("IDPersona");
            

            Response.Redirect("formularioPersonas.aspx");
        }



    }
}