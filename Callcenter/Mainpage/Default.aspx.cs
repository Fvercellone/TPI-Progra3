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
        protected void Page_Load(object sender, EventArgs e)
        {

            if(Request.QueryString["Nombre"] != null)
            {
            string user = Request.QueryString["Nombre"].ToString();
            lblTitulo.Text = user;
            }
        }

        protected void test_Click(object sender, EventArgs e)
        {
            
        }
    }
}