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
    public partial class usuarios : System.Web.UI.Page
    {

        public List<Usuarios> ListaUsuarios { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ManejadorUsuarios conexionlista = new ManejadorUsuarios();
            ListaUsuarios = conexionlista.Listar();
            
            if(!IsPostBack)
            {
                DGVUsuarios.DataSource = ListaUsuarios;
                DGVUsuarios.DataBind();

                if (Session["Mensaje"] != null)
                {
                    LBMensaje.Text = Session["Mensaje"].ToString();
                    LBMensaje.CssClass = Session["ClaseMensaje"].ToString();

                    Session.Remove("Mensaje");
                    Session.Remove("ClaseMensaje");
                }
               // ocultarColumnas();

            }

        }

        private void ocultarColumnas()
        {
            DGVUsuarios.Columns[4].Visible = false; // ID
        }

        protected void DGVUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            
            try
            {
                string dni = e.CommandArgument.ToString();

                ManejadorUsuarios conexion = new ManejadorUsuarios();

                if (e.CommandName == "Eliminar")
                {
                    conexion.Eliminar(Convert.ToInt32(e.CommandArgument));

                    Session["Mensaje"] = "Usuario dado de baja correctamente.";
                    Session["ClaseMensaje"] = "alert alert-success d-block";

                    Response.Redirect("Usuario.aspx");
                }
                else if (e.CommandName == "Activar")
                {
                    conexion.Activar(Convert.ToInt32(e.CommandArgument));

                    Session["Mensaje"] = "Usuario activado correctamente.";
                    Session["ClaseMensaje"] = "alert alert-success d-block";

                    Response.Redirect("Usuario.aspx");
                }
                else if (e.CommandName == "Modificar")
                {
                    Session.Add("ID", Convert.ToInt32(e.CommandArgument));
                    Response.Redirect("formularioUsuarios.aspx");
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