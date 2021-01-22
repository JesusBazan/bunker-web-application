using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassAccesoDatosSQL;
using System.Data.SqlClient;

namespace WebAppProducto3
{

    public partial class Login : System.Web.UI.Page
    {

        Maneja capa1;

        protected void Page_Load(object sender, EventArgs e)
        {
            capa1 = new Maneja();
            capa1.CadCone = @"Data Source=LAPTOP-RSQ8PDS7;Initial Catalog=producto2;Integrated Security=True";
        }

        public void mimensaje(string Mensaje)
        {
            Response.Write("<script type='text/javascript'> alert('" + Mensaje + "'); </script>");
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cntemp = null;
            SqlDataReader caja = null;
            string h = "";
            string s = "";
            string email = TextBox1.Text;
            string clave = TextBox2.Text;
            string consul = "select CorreoElectronico, Contraseña, IdRole from Usuario " +
                "where CorreoElectronico = '"+email+"'";
                
            cntemp = capa1.AbrirConexion(ref h);
            if (cntemp != null)
            {
                caja = capa1.ConsultaDataReader(ref cntemp, consul, ref h);
                if (caja != null)
                {
                    if (caja.Read())
                    {
                        string PASS = encrypt.DesEncriptar(caja[1].ToString());
                        if ((email == caja[0].ToString()) && (clave == PASS))
                        {//si es valido
                            //Guardado del tipo de usuario para verificar permisos en otras acciones
                            encrypt.guardarRol(Convert.ToInt16(caja[2].ToString()));
                            Response.Redirect("Encript-Desencript.aspx");
                        }
                        else
                        {
                           //si la contraseña no es correcta
                            caja.Close();
                            cntemp.Close();
                            cntemp.Dispose();
                            s = "Contraseña incorrecta";
                        }
                    }
                    else
                    {
                        //No se pudo leer la info de la BD
                        Response.Redirect("Login.aspx");
                        caja.Close();
                        cntemp.Close();
                        cntemp.Dispose();
                        s = "Imposible de leer los datos obtenidos de la BD";
                    }
                }
                else
                {
                    //No se pudo leer la informacion de la BD
                    Response.Redirect("Login.aspx");
                    caja.Close();
                    cntemp.Close();
                    cntemp.Dispose();
                    s="No es posible obtener los datos de la BD";
                }
            }
            else
            {
                //No se pudo establecer una conexion
                Response.Redirect("Login.aspx");
                s="No se pudo establecer una conexion con la BD";
            }

            mimensaje(s);

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
    }
}