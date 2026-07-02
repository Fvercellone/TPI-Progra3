using Conexion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Mainpage
    {
        public partial class usuarios : System.Web.UI.Page
        {

            public List<Usuarios> ListaDeUsuarios { get; set; } = new List<Usuarios>();

            ManejadorUsuarios conexion = new ManejadorUsuarios();
            
            public bool FiltroAvanzado { get; set; }


            protected void Page_Load(object sender, EventArgs e)
            {
                Session["Pagina"] = "Usuario";
                if (!IsPostBack)
                {
                    CargarUsuarios();

            }
            }

            private void CargarUsuarios()
            {
                try
                {
                    ListaDeUsuarios = conexion.Listar();

                    Session.Add("listaUsuarios", ListaDeUsuarios);
                    RptUsuarios.DataSource = Session["listaUsuarios"];
                    RptUsuarios.DataBind();


                }
                catch (Exception ex)
                {

                    LBMensaje.Text = ex.Message;
                    LBMensaje.CssClass = "alert alert-danger d-block";
                }



            }

            protected void RptUsuarios_ItemCommand(object source, RepeaterCommandEventArgs e)
            {
                string dni = e.CommandArgument.ToString();

                if (e.CommandName == "Modificar")
                {
                    Session["ID"] = dni;
                    Response.Redirect("formularioUsuarios.aspx");
                }
                else if (e.CommandName == "Ver")
                {
                    Session["ID"] = dni;
                    Response.Redirect("formularioUsuarios.aspx");
                }
                else if (e.CommandName == "Eliminar")
                {
                    ManejadorPersonas conexion = new ManejadorPersonas();
                    conexion.Eliminar(dni);
                    Response.Redirect("Usuarios.aspx");
                }
                else if (e.CommandName == "Activar")
                {
                    ManejadorPersonas conexion = new ManejadorPersonas();
                    conexion.Activar(dni);
                    Response.Redirect("Usuarios.aspx");
                }
            }

            protected void Agregar_onclick(object sender, EventArgs e)
            {

                Session.Remove("ID");

                Response.Redirect("formularioUsuarios.aspx");
            }



            protected void filtro_TextChanged(object sender, EventArgs e)
            {
                List<Usuarios> lista = (List<Usuarios>)Session["listaUsuarios"];
                List<Usuarios> listaFiltrada = lista.FindAll(x => x.Usuario.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                RptUsuarios.DataSource = listaFiltrada;
                RptUsuarios.DataBind(); 
            }

        protected void filtroAvanzado_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltroAvanzado.Text == "")
            {
                btnBuscar.Enabled = false;
            }
            else
            {
                btnBuscar.Enabled = true;
            }
        }


        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
            {
                    FiltroAvanzado = chkAvanzado.Checked;
                    txtFiltro.Enabled = !FiltroAvanzado;
                if (chkAvanzado.Checked)
                {

                        ddlCriterio.Items.Add("Contiene");
                        ddlCriterio.Items.Add("Comienza con");
                        ddlCriterio.Items.Add("Termina con");

                    btnBuscar.Enabled = false;
                }
                else
                {
                    ddlCriterio.Items.Clear();
                    CargarUsuarios();
                    
                }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
            {

                
                ddlCriterio.Items.Clear();
                if (ddlCampo.SelectedItem.ToString() == "Usuario" || ddlCampo.SelectedItem.ToString() == "Rol")
                {

                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Comienza con");
                    ddlCriterio.Items.Add("Termina con");
                    txtFiltroAvanzado.TextMode = TextBoxMode.SingleLine;
            }
                else
                {
                    txtFiltroAvanzado.Text = "";
                    btnBuscar.Enabled = false;
                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Comienza con");
                    ddlCriterio.Items.Add("Termina con");
                    txtFiltroAvanzado.TextMode = TextBoxMode.Number;

                }

            }

            protected void btnBuscar_Click(object sender, EventArgs e)
            {
                try
                {

                        RptUsuarios.DataSource = conexion.Listafiltrada(
                                ddlCampo.SelectedItem.ToString(),
                                ddlCriterio.SelectedItem.ToString(),
                                txtFiltroAvanzado.Text,
                                ddlEstado.SelectedItem.ToString());
                        RptUsuarios.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    throw;
                }
            }

    }
    }






