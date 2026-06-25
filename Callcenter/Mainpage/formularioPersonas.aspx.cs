using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Conexion;
using Dominio;

namespace Mainpage
{
    public partial class formulario : System.Web.UI.Page
    {

        Personas persona = new Personas();
        ManejadorPersonas Conexion = new ManejadorPersonas();

        protected void Page_Load(object sender, EventArgs e)
        {
            string DNI = Session["DNI"] != null ? Session["DNI"].ToString() : "";
            if (DNI != "" && !IsPostBack)
            {
               
                ManejadorPersonas conexion = new ManejadorPersonas();

                Personas seleccionada = (conexion.Listar(DNI)[0]);

                Session.Add("DNISeleccionado", seleccionada.DNI);

                Nombre.Text = seleccionada.Nombre;
                Apellido.Text = seleccionada.Apellido;
                GMAIL.Text = seleccionada.Mail;
                Telefono.Text = seleccionada.Telefono;
                DNI_.Text = seleccionada.DNI;

            }
        }



        protected void Agregar_onClick(object sender, EventArgs e)
        {
            try
            {


                Personas persona = new Personas()

                {
                    Nombre = Nombre.Text,
                    Apellido = Apellido.Text,
                    Mail = GMAIL.Text,
                    Telefono = Telefono.Text,
                    DNI = DNI_.Text,
                    Activo = true
                };

                    if (Session["DNI"] == null)
                {

                    Conexion.agregar(persona);

                }
                else
                {
                    Conexion.Modificar(persona);

                }

                Response.Redirect("personas.aspx");


            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void Cancelar_onClick(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("personas.aspx");
        }
    }
}