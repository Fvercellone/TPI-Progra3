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

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
               String Nombre = NombreUsuario.Text;
               String Contraseña = ContraseñaUsuario.Text;

                Session.Add("usuario", Nombre);
                Session.Add("Constraseña", Contraseña);

                //Response.Redirect("Default.aspx?Nombre=" + Nombre);

                
                usuario.Usuario = Nombre;
                usuario.Contrasenia = Contraseña;

                if (!Conexion.Login(usuario))
                {
                    // Manejar el caso de inicio de sesión fallido
                    Response.Redirect("Login.aspx", false);
                }
                else {
                    Session.Add("usuario", usuario);
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