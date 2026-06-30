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

            public List<Usuarios> ListaDeUsuarios { get; set; } = new List<Usuarios>();

            ManejadorUsuarios conexion = new ManejadorUsuarios();


            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    CargarUsuarios();
                }
            }

            private void CargarUsuarios()
            {
                try
                {
                    ListaDeUsuarios = conexion.Listar();

                    RptUsuarios.DataSource = ListaDeUsuarios;
                    RptUsuarios.DataBind();


                }
                catch (Exception ex)
                {

                    LBMensaje.Text = ex.Message;
                    LBMensaje.CssClass = "alert alert-danger d-block";
                }



            }

            protected void RptUsuarios_ItemCommand(object source, RepeaterCommandEventArgs e)
            {
                string dni = e.CommandArgument.ToString();

                if (e.CommandName == "Modificar")
                {
                    Session["ID"] = dni;
                    Response.Redirect("formularioUsuarios.aspx");
                }
                else if (e.CommandName == "Ver")
                {
                    Session["ID"] = dni;
                    Response.Redirect("formularioUsuarios.aspx");
                }
                else if (e.CommandName == "Eliminar")
                {
                    ManejadorPersonas conexion = new ManejadorPersonas();
                    conexion.Eliminar(dni);
                    Response.Redirect("Usuarios.aspx");
                }
                else if (e.CommandName == "Activar")
                {
                    ManejadorPersonas conexion = new ManejadorPersonas();
                    conexion.Activar(dni);
                    Response.Redirect("Usuarios.aspx");
                }
            }

            protected void Agregar_onclick(object sender, EventArgs e)
            {

                Session.Remove("ID");

                Response.Redirect("formularioUsuarios.aspx");
            }



        }
    }






