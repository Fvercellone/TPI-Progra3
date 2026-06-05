using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mainpage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
               String Nombre = NombreUsuario.Text;
               String Contraseña = ContraseñaUsuario.Text;


            Response.Redirect("Default.aspx?Nombre=" + Nombre);
            }
            catch (Exception ex)
            {

                throw(ex);
            }
            
        }
    }
}