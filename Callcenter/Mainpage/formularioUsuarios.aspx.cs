using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Conexion;
using Dominio;

namespace Mainpage
{
    public partial class formularioUsuarios : System.Web.UI.Page 
    {
       
        Usuarios usuario = new Usuarios();
        ManejadorUsuarios Conexion = new ManejadorUsuarios();
        ManejadorDDL DLL = new ManejadorDDL();

        public List<Roles> listaRoles { get; set; } = new List<Roles>();
        public List<Personas> listaDNIPersonas { get; set; } = new List<Personas>();


        protected void Page_Load(object sender, EventArgs e)
        {
            string ID = Session["ID"] != null ? Session["ID"].ToString() : "";

            CargarRoles();
            CargarDNI();

            if (ID != "" && !IsPostBack)
            {
                Session.Remove("ID");
                ManejadorUsuarios conexion = new ManejadorUsuarios();

                Usuarios seleccionada = (conexion.Listar(ID)[0]);

                Session.Add("IDSeleccionado", seleccionada.ID);

                Usuario_.Text = seleccionada.Usuario;
                Contraseña_.Text = seleccionada.Contrasenia;
                DDLRol_.SelectedValue = seleccionada.Rol.ToString();
                DDLDNI.SelectedValue = seleccionada.DNI.ToString();

            }
        }

        protected void CargarRoles()
        {
            listaRoles = DLL.ListarRoles();
            DDLRol_.DataSource = listaRoles;
            DDLRol_.DataTextField = "Nombre";
            DDLRol_.DataValueField = "ID";
            DDLRol_.DataBind();
        }
        protected void CargarDNI()
        {
            listaDNIPersonas = DLL.ListarDNI();
            DDLDNI.DataSource = listaDNIPersonas;
            DDLDNI.DataTextField = "DNI";
            DDLDNI.DataValueField = "ID";
            DDLDNI.DataBind();
        }
        protected void Agregar_onClick(object sender, EventArgs e)
        {
            try
            {
                
                Usuarios nuevo = new Usuarios()

                {
                    ID = Session["IDSeleccionado"] != null ? Convert.ToInt32(Session["IDSeleccionado"]) : 0,
                    Usuario = Usuario_.Text,
                    Contrasenia = Contraseña_.Text,
                    IDRol = Convert.ToInt32(DDLRol_.SelectedValue),
                    DNI = DDLDNI.Text,  
                    Activo = true
                };

                if (Session["ID"] == null)
                    Conexion.agregar(nuevo);
                else
                    Conexion.Modificar(nuevo);

                Response.Redirect("Usuario.aspx");


            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void Cancelar_onClick(object sender, EventArgs e)
        {
            string pagina = Session["Pagina"] != null ? Session["Pagina"].ToString() : "";
            Session.Remove("ID");

            if (pagina == "Usuario")
            {
                Session.Remove("Pagina");
                Response.Redirect("usuario.aspx");
            }
            else if (pagina == "Cliente")
            {
                Session.Remove("Pagina");
                Response.Redirect("Clientes.aspx");
            }
            else if (pagina == "Empleado")
            {
                Session.Remove("Pagina");
                Response.Redirect("Empleado.aspx");
            }
        }
    }
}