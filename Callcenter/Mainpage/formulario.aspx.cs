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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Agregar_onClick(object sender, EventArgs e)
        {
            ManejadorPersonas Conexion = new ManejadorPersonas();
            Conexion.agregar(new Personas()
            {
                Nombre = Nombre.Text,
                Apellido = Apellido.Text,
                Mail = GMAIL.Text,
                Telefono = Telefono.Text,
                DNI = DNI.Text,
                Activo = true
            });
             Response.Redirect("personas.aspx");
        }
    }
}