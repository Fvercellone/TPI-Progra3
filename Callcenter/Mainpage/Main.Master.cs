using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mainpage
{
    //TENEMOS QUE YA AGREGAR EL MODO OSCURO
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public string user { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Session["Usuario"] != null ? Session["Usuario"].ToString() : "Logueate";
            lblTitulo.Text = user;
        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}