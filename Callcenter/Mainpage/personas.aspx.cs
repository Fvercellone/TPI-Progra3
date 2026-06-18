//using Conexion;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace Mainpage
//{
//    public partial class personas : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                ManejadorPersonas Conexion = new ManejadorPersonas();

//                DGVPersonas.DataSource = Conexion.Listar()/*.Where(Persona => Persona.Activo)*/.ToList();

//                DGVPersonas.DataBind();
//            }
//        }

//        private void ocultarColumnas()
//        {
//            DGVPersonas.Columns[0].Visible = false;
//            DGVPersonas.Columns[6].Visible = false;

//        }

//        protected void BTDelete_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                ManejadorPersonas Conexion = new ManejadorPersonas();
//                Conexion.Eliminar(TBDNI.Text);
//                DGVPersonas.DataSource = Conexion.Listar();
//                DGVPersonas.DataBind();
//                LBMensaje.Text = "Usuario dado de baja correctamente.";
//                LBMensaje.CssClass = "alert alert-success d-block";
//                //Response.Redirect("personas.aspx");
//            }
//            catch (Exception ex)
//            {
//                LBMensaje.Text = ex.Message;
//                LBMensaje.CssClass = "alert alert-danger d-block";
//            }

//        }
//        protected void BTADD_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                ManejadorPersonas Conexion = new ManejadorPersonas();
//                Conexion.Activar(TBDNIADD.Text);
//                DGVPersonas.DataSource = Conexion.Listar();
//                DGVPersonas.DataBind();
//                //Response.Redirect("personas.aspx");

//                LBMensaje.Text = "Usuario dado de Activado correctamente.";
//                LBMensaje.CssClass = "alert alert-success d-block";
//            }
//            catch (Exception ex)
//            {
//                LBMensaje.Text = ex.Message;
//                LBMensaje.CssClass = "alert alert-danger d-block";
//            }
//        }


//        protected void BTModificar_Click(object sender, EventArgs e)
//        {
//           try
//           {
//               ManejadorPersonas Conexion = new ManejadorPersonas();
//               Conexion.Modificar(TBDNIMODIFY.Text);
//               DGVPersonas.DataSource = Conexion.Listar();
//               DGVPersonas.DataBind();
//              Response.Redirect("personas.aspx");
//                LBMensaje.Text = "Usuario modificado correctamente.";
//              LBMensaje.CssClass = "alert alert-success d-block";
//           }
//           catch (Exception ex)
//           {
//               LBMensaje.Text = ex.Message;
//               LBMensaje.CssClass = "alert alert-danger d-block";
//           }




//        }
//    }
//}

using Conexion;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mainpage
{
    public partial class personas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();
            }
        }

        private void CargarGrilla()
        {
            ManejadorPersonas conexion = new ManejadorPersonas();

            DGVPersonas.DataSource = conexion.Listar().ToList();
            DGVPersonas.DataBind();

            ocultarColumnas();
        }

        private void ocultarColumnas()
        {
            DGVPersonas.Columns[0].Visible = false; // ID
        }

        protected void DGVPersonas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string dni = e.CommandArgument.ToString();

                ManejadorPersonas conexion = new ManejadorPersonas();

                if (e.CommandName == "Eliminar")
                {
                    conexion.Eliminar(dni);

                    LBMensaje.Text = "Usuario dado de baja correctamente.";
                    LBMensaje.CssClass = "alert alert-success d-block";
                }
                else if (e.CommandName == "Activar")
                {
                    conexion.Activar(dni);

                    LBMensaje.Text = "Usuario activado correctamente.";
                    LBMensaje.CssClass = "alert alert-success d-block";
                }
                else if (e.CommandName == "Modificar")
                {
                    Response.Redirect("ModificarPersona.aspx?dni=" + dni);
                }

                CargarGrilla();
            }
            catch (Exception ex)
            {
                LBMensaje.Text = ex.Message;
                LBMensaje.CssClass = "alert alert-danger d-block";
            }
        }
    }
}