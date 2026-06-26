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
        incidencia seleccionada = new incidencia(); 


        public List<ComentarioIncidencia> ListaComentarios { get; set; } = new List<ComentarioIncidencia>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //if (Session["ID"] == null)
                    //{
                    //    Response.Redirect("Incidencias.aspx");
                    //    return;


                    int id = -1;
                    if (Session["ID"] != null && int.TryParse(Session["ID"].ToString(), out int parsedId))
                    {
                        id = parsedId;
                    }
                    else
                    {
                        TBComentarioResolucion.Enabled = false;
                        BTNEnviarComentario.Enabled = false;
                        TXTComentario.Enabled = false;
                    }

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
                    

                    if (id > 0)
                    {
                        var lista = conexion3.Listar(id);
                        if (lista != null && lista.Count > 0)
                        {
                            seleccionada = lista[0];

                            ListaComentarios = conexion4.Listar(id) ?? new List<ComentarioIncidencia>();

                            DDLEmpleado.Enabled = false;

                            Titulo.Text = seleccionada.titulo;
                            Descripcion.Text = seleccionada.descripcion;
                            TBComentarioResolucion.Text = seleccionada.comentarioCierre;

                            DDLCliente.SelectedValue = seleccionada.IDCliente.ToString();
                            DDLEmpleado.SelectedValue = seleccionada.IDEmpleado.ToString();
                            DDLCategoria.SelectedValue = seleccionada.IDCategoria.ToString();
                            DDLPrioridad.SelectedValue = seleccionada.IDPrioridad.ToString();

                            LBEstado.Text = "Estado: " + seleccionada.Estado;
                        }
                    }
                    else
                    {
                        // Modo agregar: limpiar lista de comentarios y dejar controles habilitados por defecto
                        ListaComentarios = new List<ComentarioIncidencia>();
                        DDLEmpleado.Enabled = true;
                        btnAceptar.Text = "Agregar";
                        btnAceptar.Visible = true;
                        btnCancelar.Visible = true;
                    }

                    if (Session["Accion"] != null && Session["Accion"].ToString() == "")
                    {
                        Titulo.Enabled = false;
                        Descripcion.Enabled = false;
                        DDLCliente.Enabled = false;
                        DDLCategoria.Enabled = false;
                        DDLPrioridad.Enabled = false;
                        DDLEmpleado.Enabled = false;
                        TBComentarioResolucion.Enabled = false;


                    }

                    if (Session["Accion"] != null && Session["Accion"].ToString() == "Modificar")
                    {
//                        id = int.Parse(Session["ID"].ToString());
                        seleccionada = conexion3.Listar(id)[0];


                        DDLEmpleado.Enabled = false;
                        TBComentarioResolucion.Enabled = false;
                        Titulo.Text = seleccionada.titulo;
                        Descripcion.Text = seleccionada.descripcion;

                        DDLCliente.SelectedValue = seleccionada.IDCliente.ToString();
                        DDLEmpleado.SelectedValue = seleccionada.IDEmpleado.ToString();
                        DDLCategoria.SelectedValue = seleccionada.IDCategoria.ToString();
                        DDLPrioridad.SelectedValue = seleccionada.IDPrioridad.ToString();
                        LBEstado.Text = "Estado: " + seleccionada.Estado;

                        btnAceptar.Text = "Modificar";
                        btnAceptar.Visible = true;
                        btnCancelar.Visible = true;


                    }

                    if (Session["Accion"] != null && Session["Accion"].ToString() == "Reasignar")
                    {
                        Titulo.Enabled = false;
                        Descripcion.Enabled = false;
                        DDLCliente.Enabled = false;
                        DDLCategoria.Enabled = false;
                        DDLPrioridad.Enabled = false;
                        TBComentarioResolucion.Enabled = false;

                        DDLEmpleado.Enabled = true;

                        btnAceptar.Text = "Reasignar";
                        btnAceptar.Visible = true;
                        btnCancelar.Visible = true;
                    }

                    if (Session["Accion"] != null && Session["Accion"].ToString() == "Resolver")
                    {
                        Titulo.Enabled = false;
                        Descripcion.Enabled = false;
                        DDLCliente.Enabled = false;
                        DDLEmpleado.Enabled = false;
                        DDLCategoria.Enabled = false;
                        DDLPrioridad.Enabled = false;

                        
                        

                        btnAceptar.Text = "Resolver";
                        btnAceptar.Visible = true;
                        btnCancelar.Visible = true;
                    }

                    //if (Session["Accion"] != null && Session["Accion"].ToString() == "Cerrar")
                    //{
                    //    //Titulo.Enabled = false;
                    //    //Descripcion.Enabled = false;
                    //    //DDLCliente.Enabled = false;
                    //    //DDLEmpleado.Enabled = false;
                    //    //DDLCategoria.Enabled = false;
                    //    //DDLPrioridad.Enabled = false;
                    //    //TBComentarioResolucion.Enabled = false;

                    //    btnAceptar.Text = "Cerrar";
                    //}
                }
            }
            catch (Exception)
            {
                throw;
            }
            }
        


        protected void cerrar_onclick(object sender, EventArgs e)
        {
            int id = int.Parse(Session["ID"].ToString());
            Session["Accion"] = "";
            conexion3.Cerrar(id);

            Response.Redirect("vistaIncidencia.aspx");
        }
        protected void Modificar_onclick(object sender, EventArgs e)
        {
            int id = int.Parse(Session["ID"].ToString());
            Session["Accion"] = "Modificar";
            Response.Redirect("vistaIncidencia.aspx");
        }
        protected void Reasignar_onclick(object sender, EventArgs e)
        {
            int id = int.Parse(Session["ID"].ToString());
            Session["Accion"] = "Reasignar";
            Response.Redirect("vistaIncidencia.aspx");
        }
        protected void Resolver_onclick(object sender, EventArgs e)
        {
            int id = int.Parse(Session["ID"].ToString());
            Session["Accion"] = "Resolver";
            Response.Redirect("vistaIncidencia.aspx");
        }
        protected void Reabrir_onclick(object sender, EventArgs e)
        {
            int id = int.Parse(Session["ID"].ToString());
            Session["Accion"] = "Re-abrir";
            Response.Redirect("vistaIncidencia.aspx");
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

                    
                    TBComentarioResolucion.Enabled = true;

                    conexion3.Resolver(idIncidencia, TBComentarioResolucion.Text);

                    btnAceptar.Text = "Resolver";
                    Session.Clear();
                    Response.Redirect("vistaIncidencia.aspx", false);
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
                    Response.Redirect("vistaIncidencia.aspx", false);
                    return;

                }

                if (Session["Accion"] != null && Session["Accion"].ToString() == "Reasignar")
                {
                    conexion3.Reasignar(idIncidencia, idEmpleado);

                    //Session.Clear();
                    Response.Redirect("vistaIncidencia.aspx", false);
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
                    //Session.Clear();
                    Response.Redirect("vistaIncidencia.aspx", false);
                    return;
                }
                else
                {
                    conexion3.agregar(incidencia);
                    //Session.Clear();
                    //Session["ID"] = int.Parse(Session["ID"].ToString());
                    //Session["Accion"] = "";
                    //Response.Redirect("vistaIncidencia.aspx", false);
                    Response.Redirect("incidencias.aspx", false);
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
            
            if (Session["ID"] != null)
            {
                int id = int.Parse(Session["ID"].ToString());
                // Resto del código
                Session["Accion"] = "";
                Response.Redirect("vistaIncidencia.aspx");
            }
            Session.Clear();
            Response.Redirect("Incidencias.aspx");
        }

        protected void Salir_onClick(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Incidencias.aspx");
        }

    }
}
