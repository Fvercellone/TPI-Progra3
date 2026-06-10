using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mainpage
{
    public partial class Default : System.Web.UI.Page
    {
        public string user { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            //if(Request.QueryString["Nombre"] != null)
            //{
            //string user = Request.QueryString["Nombre"].ToString();
            //lblTitulo.Text = user;
            //}

            //user = Request.QueryString["Nombre"] != null ? Request.QueryString["Nombre"] : "Logueate";
            user = Session["Usuario"] != null ? Session["Usuario"].ToString() : "Logueate";
            lblTitulo.Text = user;
        }

        protected void test_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}