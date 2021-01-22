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
    
    public partial class agregauser : System.Web.UI.Page
    {
        Maneja capa1;
        LogicaNeg logi = new LogicaNeg();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(encrypt.tipo == 3)
            {
                capa1 = new Maneja();
                capa1.CadCone = @"Data Source=VENUS;Initial Catalog=Producto2;Integrated Security=True";

                if (!IsPostBack)
                {
                    llenarcomboRol();
                }
            } else
            {
                mimensaje("Usted no cuenta con lo permisos necesarios para poder ver este apartado");
                Response.Redirect("Encript-Desencript.aspx");
            }
        }
        List<int> idRol = new List<int>();

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

        public void mimensaje(string Mensaje)
        {
            Response.Write("<script type='text/javascript'> alert('" + Mensaje + "'); </script>");
        }

        protected void btnRegistraUsuario_Click(object sender, EventArgs e)
        {
            string k = "";
            int activo;

            List<string> usuarios = new List<string>();

            usuarios = logi.IdRol(ref idRol, ref k);

            if (txtNombre.Text == "" || txtApp.Text == "" || txtApm.Text == "" || txtContra.Text == "" || txtTel.Text == "" 
                || txtCorreo.Text == "")
            {
                k = "Inserta Todos Los Datos";
            }
            else if (txtContra.Text.Length <= 8)
            {
                k = "Su contraseña debe tener mas de 8 caracteres";
            }
            else
            {
                bool conf;
                conf = logi.ContrasenaSegura(txtContra.Text);//validacion de la contraseña
                if (conf == false)//contenido de la contraseña incorrecto
                {
                    k = "Su contraseña debe tener al menos 8 caracteres con un número " +
                        "(0 - 9) y un carácter especial ([!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]) y un alfabeto (a - z o A - Z)";
                }
                else
                {
                    string PASS = encrypt.Encriptar(txtContra.Text);
                    activo = 1;
                    logi.InsertarUsuario(txtNombre.Text, txtApp.Text, txtApm.Text, txtTel.Text,
                    activo, txtCorreo.Text, PASS, idRol[listaRol.SelectedIndex], ref k);
                }

                mimensaje(k);
                Response.Redirect("agregauser.aspx");
            }
        }
    }
}