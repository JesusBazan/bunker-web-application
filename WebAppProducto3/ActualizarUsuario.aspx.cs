using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassAccesoDatosSQL;
using System.Data.SqlClient;
using ClassLogicaNegociosPagos;



namespace WebAppProducto3
{
    public partial class Actualizar : System.Web.UI.Page
    {

        Maneja capa1;
        LogicaNeg logi = new LogicaNeg();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(encrypt.tipo == 3)//Usuario tipo Admin
            {
                capa1 = new Maneja();
                capa1.CadCone = @"Data Source=VENUS;Initial Catalog=Producto2;Integrated Security=True";

                if (!IsPostBack)
                {
                    llenarcombousuario();
                    llenarcomboRol();
                }
            } else //Usuario sin permisos
            {
                mimensaje("Usted no cuenta con lo permisos necesarios para poder ver este apartado");
                Response.Redirect("Encript-Desencript.aspx");
            }
        }
        //Se llenan los combobox con los usuarios existentes y con los roles
        List<int> idUsuario = new List<int>();
        List<int> idRol = new List<int>();
        public void llenarcombousuario()
        {
            string k = "";
            List<string> usuarios = new List<string>();

            usuarios = logi.IdUser(ref idUsuario, ref k);
           ListaUsers.Items.Clear();

            foreach (string r in usuarios)
            {
                ListaUsers.Items.Add(Convert.ToString(r));
            }
        }

        public void llenarcomboRol()
        {
            string k = "";
            List<string> usuarios = new List<string>();

            usuarios = logi.IdRol(ref idRol, ref k);
            listaRol.Items.Clear();

            foreach (string r in usuarios)
            {
                listaRol.Items.Add(Convert.ToString(r));
            }
        }


        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string k = "";
            
            int id = 0;
            string nombre = " ";
            string app = " ";
            string apm = " ";
            string tel = " ";
            string correo = " "; 
            string pass = " ";
            
            List<string> usuarios = new List<string>();
            usuarios = logi.IdUser(ref idUsuario, ref k);
            int IDUSer = idUsuario[ListaUsers.SelectedIndex];
            //Consulta que regresa los datos de un usuario determinado
            logi.Consultausuarios(ref id,ref nombre,ref app,ref apm,
                ref tel,   ref correo, ref pass,  ref IDUSer ,ref k);
            //Pone los datos en los textbox
            txtNombre.Text = nombre;
            txtApp.Text = app;
            txtApm.Text = apm;
            txtTel.Text = tel;
            txtCorreo.Text = correo;
            txtContra.Text = pass;
        }

        public void mimensaje(string Mensaje)
        {
            Response.Write("<script type='text/javascript'> alert('" + Mensaje + "'); </script>");
        }

        protected void ListaUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string k = " ";
            List<string> usuarios = new List<string>();
            usuarios = logi.IdUser(ref idUsuario, ref k);
            //Obtener el id del usuario a modificar
            int IDUSer = idUsuario[ListaUsers.SelectedIndex];

            List<string> usuari = new List<string>();

            usuari = logi.IdRol(ref idRol, ref k);
            //Actualizar usuario
            logi.Actualizaruser(txtNombre.Text, txtApp.Text, 
                txtApm.Text,txtTel.Text,txtCorreo.Text, txtContra.Text, 
                idRol[listaRol.SelectedIndex],IDUSer, ref k);

            mimensaje(k);
            Response.Redirect("ActualizarUsuario.aspx");
        }
    }
}