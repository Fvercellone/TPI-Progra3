using Conexion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mainpage
{
    public partial class vistaIncidencia : System.Web.UI.Page
    {
        ManejadorIncidencias conexion3 = new ManejadorIncidencias();

        public List<ComentarioIncidencia> ListaComentarios { get; set; } = new List<ComentarioIncidencia>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["ID"] == null)
                    {
                        Response.Redirect("Incidencias.aspx");
                        return;
                    }

                    int id = int.Parse(Session["ID"].ToString());

                    ManejadorDDL conexion = new ManejadorDDL();
                    ManejadorUsuarios conexion2 = new ManejadorUsuarios();
                    ManejadorComentarios conexion4 = new ManejadorComentarios();

                    DDLPrioridad.DataSource = conexion.ListarPrioridades();
                    DDLPrioridad.DataTextField = "Nombre";
                    DDLPrioridad.DataValueField = "ID";
                    DDLPrioridad.DataBind();

                    DDLCategoria.DataSource = conexion.ListarCategorias();
                    DDLCategoria.DataTextField = "Nombre";
                    DDLCategoria.DataValueField = "ID";
                    DDLCategoria.DataBind();

                    DDLCliente.DataSource = conexion2.ListarCliente();
                    DDLCliente.DataValueField = "ID";
                    DDLCliente.DataTextField = "Usuario";
                    DDLCliente.DataBind();

                    DDLEmpleado.DataSource = conexion2.ListarEmpleados();
                    DDLEmpleado.DataValueField = "ID";
                    DDLEmpleado.DataTextField = "Usuario";
                    DDLEmpleado.DataBind();

                    incidencia seleccionada = conexion3.Listar(id)[0];

                    ListaComentarios = conexion4.Listar(id);

                    if (ListaComentarios == null)
                    {
                        ListaComentarios = new List<ComentarioIncidencia>();
                    }

                    DDLEmpleado.Enabled = false;

                    Titulo.Text = seleccionada.titulo;
                    Descripcion.Text = seleccionada.descripcion;

                    DDLCliente.SelectedValue = seleccionada.IDCliente.ToString();
                    DDLEmpleado.SelectedValue = seleccionada.IDEmpleado.ToString();
                    DDLCategoria.SelectedValue = seleccionada.IDCategoria.ToString();
                    DDLPrioridad.SelectedValue = seleccionada.IDPrioridad.ToString();

                    LBEstado.Text = "Estado: " + seleccionada.Estado;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
