using Conexion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Mainpage
{
    public partial class formularioIncidencias : System.Web.UI.Page
    {

        incidencia N_incidencia = new incidencia();
        ManejadorIncidencias conexion3 = new ManejadorIncidencias();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ManejadorDDL conexion = new ManejadorDDL();
                    ManejadorUsuarios Conexion2 = new ManejadorUsuarios();
                    List<estado> lista = conexion.ListarEstados();

                    //DDLEstado.DataSource = lista;
                    //DDLEstado.DataTextField = "Nombre";
                    //DDLEstado.DataValueField = "ID";
                    //DDLEstado.DataBind();

                   

                    List<Prioridad> lista2 = conexion.ListarPrioridades();

                    DDLPrioridad.DataSource = lista2;
                    DDLPrioridad.DataTextField = "Nombre";
                    DDLPrioridad.DataValueField = "ID";
                    DDLPrioridad.DataBind();

                    List<categoria> lista3 = conexion.ListarCategorias();

                    DDLCategoria.DataSource = lista3;
                    DDLCategoria.DataTextField = "Nombre";
                    DDLCategoria.DataValueField = "ID";
                    DDLCategoria.DataBind();

                    List<Usuarios> lista4 = Conexion2.ListarCliente();

                    DDLCliente.DataSource = lista4;
                    DDLCliente.DataValueField = "ID";
                    DDLCliente.DataTextField = "Usuario";
                    DDLCliente.DataBind();

                    List<Usuarios> lista5 = Conexion2.ListarEmpleados();

                    DDLEmpleado.DataSource = lista5;
                    DDLEmpleado.DataValueField = "ID";
                    DDLEmpleado.DataTextField = "Usuario";
                    DDLEmpleado.DataBind();

                    if (Session["Accion"] != null && Session["Accion"].ToString() == "Modificar")
                    {
                        int id = int.Parse(Session["ID"].ToString());
                        incidencia seleccionada = conexion3.Listar(id)[0];


                        DDLEmpleado.Enabled = false;
                        Titulo.Text = seleccionada.titulo;
                        Descripcion.Text = seleccionada.descripcion;

                        DDLCliente.SelectedValue = seleccionada.IDCliente.ToString();
                        DDLEmpleado.SelectedValue = seleccionada.IDEmpleado.ToString();
                        DDLCategoria.SelectedValue = seleccionada.IDCategoria.ToString();
                        DDLPrioridad.SelectedValue = seleccionada.IDPrioridad.ToString();

                        LBEstado.Text = "Estado: " + seleccionada.Estado;

                    }

                    if (Session["Accion"] != null && Session["Accion"].ToString() == "Reasignar")
                    {
                        Titulo.Enabled = false;
                        Descripcion.Enabled = false;
                        DDLCliente.Enabled = false;
                        DDLCategoria.Enabled = false;
                        DDLPrioridad.Enabled = false;

                        DDLEmpleado.Enabled = true;

                        btnAceptar.Text = "Reasignar";
                    }

                    if (Session["Accion"] != null && Session["Accion"].ToString() == "Resolver")
                    {
                        Titulo.Enabled = false;
                        Descripcion.Enabled = false;
                        DDLCliente.Enabled = false;
                        DDLEmpleado.Enabled = false;
                        DDLCategoria.Enabled = false;
                        DDLPrioridad.Enabled = false;

                        LBComentarioResolucion.Visible = true;
                        TBComentarioResolucion.Visible = true;

                        btnAceptar.Text = "Resolver";
                    }

                    if (Session["Accion"] != null && Session["Accion"].ToString() == "Cerrar")
                    {
                        Titulo.Enabled = false;
                        Descripcion.Enabled = false;
                        DDLCliente.Enabled = false;
                        DDLEmpleado.Enabled = false;
                        DDLCategoria.Enabled = false;
                        DDLPrioridad.Enabled = false;

                        btnAceptar.Text = "Cerrar";
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }

        }



        protected void Agregar_onClick(object sender, EventArgs e)
        {
            int idIncidencia = 0;
            if (Session["ID"] != null)
            {
                idIncidencia = int.Parse(Session["ID"].ToString());
            }
            int idEmpleado = int.Parse(DDLEmpleado.SelectedValue);
            try
            {
                if (Session["Accion"] != null && Session["Accion"].ToString() == "Resolver")
                {
                    Titulo.Enabled = false;
                    Descripcion.Enabled = false;
                    DDLCliente.Enabled = false;
                    DDLEmpleado.Enabled = false;
                    DDLCategoria.Enabled = false;
                    DDLPrioridad.Enabled = false;

                    LBComentarioResolucion.Visible = true;
                    TBComentarioResolucion.Visible = true;

                     conexion3.Resolver(idIncidencia, TBComentarioResolucion.Text);

                    btnAceptar.Text = "Resolver";
                    Session.Clear();
                    Response.Redirect("Incidencias.aspx", false);
                    return;

                }

                if (Session["Accion"] != null && Session["Accion"].ToString() == "Cerrar")
                {
                    Titulo.Enabled = false;
                    Descripcion.Enabled = false;
                    DDLCliente.Enabled = false;
                    DDLEmpleado.Enabled = false;
                    DDLCategoria.Enabled = false;
                    DDLPrioridad.Enabled = false;

                    conexion3.Cerrar(idIncidencia);

                    btnAceptar.Text = "Cerrar";
                    Session.Clear();
                    Response.Redirect("Incidencias.aspx", false);
                    return;

                }

                if (Session["Accion"] != null && Session["Accion"].ToString() == "Reasignar")
                {
                    conexion3.Reasignar(idIncidencia, idEmpleado);

                    //Session.Clear();
                    Response.Redirect("Incidencias.aspx", false);
                    return;
                }

                incidencia incidencia = new incidencia();

                incidencia.titulo = Titulo.Text;
                incidencia.descripcion = Descripcion.Text;
                incidencia.IDCliente = int.Parse(DDLCliente.SelectedValue);
                incidencia.IDEmpleado = int.Parse(DDLEmpleado.SelectedValue);
                incidencia.IDCategoria = int.Parse(DDLCategoria.SelectedValue);
                incidencia.IDPrioridad = int.Parse(DDLPrioridad.SelectedValue);

                if (Session["Accion"] != null && Session["Accion"].ToString() == "Modificar")
                {

                    incidencia.id = int.Parse(Session["ID"].ToString());
                    conexion3.Modificar(incidencia);
                    Session.Clear();
                    Response.Redirect("Incidencias.aspx", false);
                    return;
                }
                else
                {
                    conexion3.agregar(incidencia);
                    Session.Clear();
                    Response.Redirect("Incidencias.aspx", false);
                    return;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void Cancelar_onClick(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Incidencia.aspx");
        }
    }
}