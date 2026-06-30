using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Conexion;
using negocio;

namespace Mainpage
{
    //TENEMOS QUE YA AGREGAR EL MODO OSCURO
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public string user { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!(Page is Login))
            {

                
                if (Seguridad.sesionActiva(Session["usuario"]) == false)
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
            user = Session["usuario"] != null ? Session["usuario"].ToString() : "Logueate";
            lblTitulo.Text = user;
            
        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}