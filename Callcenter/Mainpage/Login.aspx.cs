using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Conexion;
using Dominio;

namespace Mainpage
{
    public partial class Login : System.Web.UI.Page
    {
        ManejadorUsuarios Conexion = new ManejadorUsuarios();
        Usuarios usuario = new Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Comprobación segura de la sesión y del tipo antes de acceder a 'Rol'
            if (Session["usuario"] is Usuarios sesUsuario && sesUsuario.IDRol >= 2)
            {


                if (!IsPostBack)
            {

                if (Session["Mensaje"] != null)
                {
                    LBMensaje.Text = Session["Mensaje"].ToString();
                    LBMensaje.CssClass = Session["ClaseMensaje"].ToString();

                    Session.Remove("Mensaje");
                    Session.Remove("ClaseMensaje");
                }
            }
            }

        }


        protected void BTNIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                String Nombre = NombreUsuario.Text;
                String Contraseña = ContraseñaUsuario.Text;



                usuario.Usuario = Nombre;
                usuario.Contrasenia = Contraseña;

                if (!Conexion.Login(usuario))
                {
                    
                    Response.Redirect("Login.aspx", false);
                }
                else {
                    Session.Add("usuario", usuario);
                    Session.Add("IDUsuario", usuario.ID);
                    Response.Redirect("Default.aspx", false);
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