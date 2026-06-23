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
    public partial class formularioUsuarios : System.Web.UI.Page 
    {
       
        Usuarios usuario = new Usuarios();
        ManejadorUsuarios Conexion = new ManejadorUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            string ID = Session["ID"] != null ? Session["ID"].ToString() : "";
            if (ID != "" && !IsPostBack)
            {

              ManejadorUsuarios conexion = new ManejadorUsuarios();

              Usuarios seleccionada = (conexion.Listar(ID)[0]);

                Session.Add("IDSeleccionado", seleccionada.ID);

                Usuario_.Text = seleccionada.Usuario;
                Contraseña_.Text = seleccionada.Contrasenia;
                Rol_.Text = seleccionada.IDRol.ToString();
                DNIPersona.Text = seleccionada.DNI.ToString();

            }
        }

        protected void Agregar_onClick(object sender, EventArgs e)
        {
            try
            {
                
                Usuarios nuevo = new Usuarios()

                {
                    ID = Session["IDSeleccionado"] != null ? Convert.ToInt32(Session["IDSeleccionado"]) : 0,
                    Usuario = Usuario_.Text,
                    Contrasenia = Contraseña_.Text,
                    IDRol = Convert.ToInt32(Rol_.Text),
                    DNI = DNIPersona.Text,
                    IDPersona = Convert.ToInt32(DNIPersona.Text),
                    Activo = true
                };

                if (Session["ID"] == null)
                    Conexion.agregar(nuevo);
                else
                    Conexion.Modificar(nuevo);

                Response.Redirect("Usuario.aspx");


            }
            catch (Exception)
            {

                throw;
            }
        }
}
}