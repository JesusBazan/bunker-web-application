using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLogicaNegociosPagos;

namespace WebAppProducto3
{
    public partial class Registro : System.Web.UI.Page
    {

        LogicaNeg logi = new LogicaNeg();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void mimensaje(string Mensaje)
        {
            //Response.Write("<script type='text/javascript'> alert('" + Mensaje + "'); </script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Mensaje, "alert('Record Inserted Successfully')", true);
        }

        protected void btnRegistrarAlumno_Click(object sender, EventArgs e)
        {
            string s = "";//variable para mensaje
            int activo = 1;//activo por default
            int rol = 1;//Rol Usuario por default

            //Si todos los campos son validos (no estan vacios)
            if (txtRegnom.Text == "" || txtRegapp.Text == ""
                || txtRegapm.Text == "" || txtRegtel.Text == "" || txtRegemail.Text == ""
                || txtRegpass.Text == "")
            {
                s = "Inserta Todos Los Datos";
            }
            else if (txtRegpass.Text.Length <= 8) { //contraseña menor de 8 caracteres
                s = "Su contraseña debe tener mas de 8 caracteres";
            }
            else if (txtRegtel.Text.Length < 10 || txtRegtel.Text.Length > 10) //menor o mayor a diez digitos
            {
                s = "Su número teléfonico debe tener diez dígitos.";
            }
            else
            {
                bool conf;
                conf = logi.ContrasenaSegura(txtRegpass.Text);//validacion de la contraseña
                if (conf == false)//contenido de la contraseña incorrecto
                {
                    s = "Su contraseña debe tener al menos 8 caracteres con un número " +
                        "(0 - 9) y un carácter especial ([!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]) y un alfabeto (a - z o A - Z)";
                }
                else {
                    string PASS = encrypt.Encriptar(txtRegpass.Text);//Encriptacion de la contraseña
                    logi.InsertarUsuario(txtRegnom.Text, txtRegapp.Text, txtRegapm.Text, txtRegtel.Text, activo, txtRegemail.Text, PASS, rol, ref s);
                }
            }
            mimensaje(s);
        }

    }
}