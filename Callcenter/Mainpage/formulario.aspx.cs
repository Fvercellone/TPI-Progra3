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

        public string DNI_Mod { get; set; }
       
        Personas persona = new Personas();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (Session["DNI"] != null)
                {
                    
                    ManejadorPersonas conexion = new ManejadorPersonas();
                    DNI_Mod = Session["DNI"].ToString();

                    conexion.Listar(DNI_Mod);
                        //{
                    //    persona.DNI = DNI_Mod;
                    //    persona.Nombre = Nombre.Text;
                    //    persona.Apellido = Apellido.Text;
                    //    persona.Mail = GMAIL.Text;
                    //    persona.Telefono = Telefono.Text;
                    //};
                       
                    
                    


                }
            }
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

        protected void Modificar_onClick(object sender, EventArgs e)
        {
            ManejadorPersonas Conexion = new ManejadorPersonas();
            Conexion.Modificar(DNI_Mod);
            Response.Redirect("personas.aspx");
        }
}
}