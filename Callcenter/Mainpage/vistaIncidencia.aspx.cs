using Conexion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Mainpage
{
    public partial class vistaIncidencia : System.Web.UI.Page
    {
        private readonly ManejadorIncidencias manejadorIncidencias = new ManejadorIncidencias();
        public List<incidencia> ListaIncidencias { get; set; } = new List<incidencia>();

        public List<ComentarioIncidencia> ListaComentarios { get; set; } = new List<ComentarioIncidencia>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (!IsPostBack)
            {
                if (Session["IDUsuario"] == null)
                {
                    LBMensaje.Visible = true;
                    LBMensaje.Text = "No hay IDUsuario en Session. Revisar login.";
                    return;
                }
                
                CargarDropDowns();
                CargarPantallaSegunModo();
            }
        }



        private void CargarDropDowns()
        {
            ManejadorDDL manejadorDDL = new ManejadorDDL();
            ManejadorUsuarios manejadorUsuarios = new ManejadorUsuarios();

            DDLPrioridad.DataSource = manejadorDDL.ListarPrioridades();
            DDLPrioridad.DataTextField = "Nombre";
            DDLPrioridad.DataValueField = "ID";
            DDLPrioridad.DataBind();

            DDLCategoria.DataSource = manejadorDDL.ListarCategorias();
            DDLCategoria.DataTextField = "Nombre";
            DDLCategoria.DataValueField = "ID";
            DDLCategoria.DataBind();

            DDLCliente.DataSource = manejadorUsuarios.ListarCliente();
            DDLCliente.DataTextField = "Usuario";
            DDLCliente.DataValueField = "ID";
            DDLCliente.DataBind();

            DDLEmpleado.DataSource = manejadorUsuarios.ListarEmpleados();
            DDLEmpleado.DataTextField = "Usuario";
            DDLEmpleado.DataValueField = "ID";
            DDLEmpleado.DataBind();
        }

        private void CargarPantallaSegunModo()
        {
            string accion = Session["Accion"] != null ? Session["Accion"].ToString() : "";
            int idIncidencia = ObtenerIDIncidencia();

            if (idIncidencia <= 0)
            {
                PrepararAlta();
                return;
            }

            CargarIncidencia(idIncidencia);

            switch (accion)
            {
                case "Modificar":
                    PrepararModificar();
                    break;

                case "Reasignar":
                    PrepararReasignar();
                    break;

                case "Resolver":
                    PrepararResolver();
                    break;

                default:
                    PrepararVista();
                    break;
            }
        }

        private int ObtenerIDIncidencia()
        {
            if (Session["ID"] != null && int.TryParse(Session["ID"].ToString(), out int id))
                return id;

            return -1;
        }

        private void CargarIncidencia(int id)
        {
            ManejadorComentarios manejadorComentarios = new ManejadorComentarios();

            List<incidencia> lista = manejadorIncidencias.Listar(id);

            if (lista == null || lista.Count == 0)
                throw new Exception("No se encontró la incidencia solicitada.");

            incidencia seleccionada = lista[0];

            ListaComentarios = manejadorComentarios.Listar(id) ?? new List<ComentarioIncidencia>();

            Titulo.Text = seleccionada.titulo;
            Descripcion.Text = seleccionada.descripcion;
            TBComentarioResolucion.Text = seleccionada.comentarioCierre;

            DDLCliente.SelectedValue = seleccionada.IDCliente.ToString();
            DDLEmpleado.SelectedValue = seleccionada.IDEmpleado.ToString();
            DDLCategoria.SelectedValue = seleccionada.IDCategoria.ToString();
            DDLPrioridad.SelectedValue = seleccionada.IDPrioridad.ToString();

            LBEstado.Text = "Estado: " + seleccionada.Estado;
            LBFechaAlta.Text = "Fecha Alta: " + seleccionada.alta;

        }

        private void PrepararAlta()
        {
            Titulo.Text = "";
            Descripcion.Text = "";
            TBComentarioResolucion.Text = "";

            TBComentarioResolucion.Enabled = false;
            TXTComentario.Enabled = false;
            BTNEnviarComentario.Enabled = false;

            DDLEmpleado.Enabled = true;

            btnAceptar.Text = "Agregar";
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;

            LBEstado.Text = "Estado: Nueva incidencia";
        }

        private void PrepararVista()
        {
            Titulo.Enabled = false;
            Descripcion.Enabled = false;
            DDLCliente.Enabled = false;
            DDLCategoria.Enabled = false;
            DDLPrioridad.Enabled = false;
            DDLEmpleado.Enabled = false;
            TBComentarioResolucion.Enabled = false;

            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
        }

        private void PrepararModificar()
        {
            Titulo.Enabled = true;
            Descripcion.Enabled = true;
            DDLCliente.Enabled = true;
            DDLCategoria.Enabled = true;
            DDLPrioridad.Enabled = true;

            DDLEmpleado.Enabled = false;
            TBComentarioResolucion.Enabled = false;

            btnAceptar.Text = "Modificar";
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;
        }

        private void PrepararReasignar()
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

        private void PrepararResolver()
        {
            Titulo.Enabled = false;
            Descripcion.Enabled = false;
            DDLCliente.Enabled = false;
            DDLEmpleado.Enabled = false;
            DDLCategoria.Enabled = false;
            DDLPrioridad.Enabled = false;

            TBComentarioResolucion.Enabled = true;

            btnAceptar.Text = "Resolver";
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;
        }

        protected void Modificar_onclick(object sender, EventArgs e)
        {
            Session["Accion"] = "Modificar";
            Response.Redirect("vistaIncidencia.aspx");
        }

        protected void Reasignar_onclick(object sender, EventArgs e)
        {
            Session["Accion"] = "Reasignar";
            Response.Redirect("vistaIncidencia.aspx");
        }

        protected void Resolver_onclick(object sender, EventArgs e)
        {
            Session["Accion"] = "Resolver";
            Response.Redirect("vistaIncidencia.aspx");
        }

        protected void cerrar_onclick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["ID"]);
            manejadorIncidencias.Cerrar(id);

            Session["Accion"] = "";
            Response.Redirect("vistaIncidencia.aspx");
        }

        protected void Reabrir_onclick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["ID"]);
            manejadorIncidencias.Reabrir(id);

            Session["Accion"] = "";
            Response.Redirect("vistaIncidencia.aspx");
        }

        protected void Agregar_onClick(object sender, EventArgs e)
        {
            string accion = Session["Accion"] != null ? Session["Accion"].ToString() : "";
            int idIncidencia = ObtenerIDIncidencia();

            if (accion == "Resolver")
            {
                manejadorIncidencias.Resolver(idIncidencia, TBComentarioResolucion.Text);
                Session["Accion"] = "";
                Response.Redirect("vistaIncidencia.aspx", false);
                return;
            }

            if (accion == "Reasignar")
            {
                int idEmpleado = Convert.ToInt32(DDLEmpleado.SelectedValue);
                manejadorIncidencias.Reasignar(idIncidencia, idEmpleado);

                Session["Accion"] = "";
                Response.Redirect("vistaIncidencia.aspx", false);
                return;
            }

            incidencia nueva = new incidencia
            {
                titulo = Titulo.Text,
                descripcion = Descripcion.Text,
                IDCliente = Convert.ToInt32(DDLCliente.SelectedValue),
                IDEmpleado = Convert.ToInt32(DDLEmpleado.SelectedValue),
                IDCategoria = Convert.ToInt32(DDLCategoria.SelectedValue),
                IDPrioridad = Convert.ToInt32(DDLPrioridad.SelectedValue)
            };

            if (accion == "Modificar")
            {
                nueva.id = idIncidencia;
                manejadorIncidencias.Modificar(nueva);

                Session["Accion"] = "";
                Response.Redirect("vistaIncidencia.aspx", false);
                return;
            }

            int nuevoID = manejadorIncidencias.agregar(nueva);

            Session["ID"] = nuevoID;
            Session["Accion"] = "";

            Response.Redirect("vistaIncidencia.aspx", false);
        }


        protected void EnviarComentario_onclick(object sender, EventArgs e)
        {
            try
            {
                if (Session["ID"] == null)
                    throw new Exception("Primero debe seleccionar una incidencia.");

                if (Session["IDUsuario"] == null)
                    throw new Exception("No se encontró el usuario logueado.");

                if (string.IsNullOrWhiteSpace(TXTComentario.Text))
                    throw new Exception("Debe ingresar un comentario.");

                ComentarioIncidencia comentario = new ComentarioIncidencia();

                comentario.IDIncidencia = Convert.ToInt32(Session["ID"]);
                comentario.IDUsuario = Convert.ToInt32(Session["IDUsuario"]);
                comentario.Comentario = TXTComentario.Text;

                ManejadorComentarios manejadorComentarios = new ManejadorComentarios();

                manejadorComentarios.Agregar(comentario);

                TXTComentario.Text = "";

                Response.Redirect("vistaIncidencia.aspx", false);
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
                Session["Accion"] = "";
                Response.Redirect("vistaIncidencia.aspx");
                return;
            }

            Session.Remove("ID");
            Session.Remove("Accion");
            Response.Redirect("Incidencias.aspx");
        }

        protected void Salir_onClick(object sender, EventArgs e)
        {
            Session.Remove("ID");
            Session.Remove("Accion");
            Response.Redirect("Incidencias.aspx");
        }
    }
}