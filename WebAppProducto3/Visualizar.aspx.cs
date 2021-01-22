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
    public partial class Visualizar : System.Web.UI.Page
    {
        List<int> ids = new List<int>();
        Maneja capa1;
        LogicaNeg logi = new LogicaNeg();
        string g = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(encrypt.tipo == 3)
            {
                capa1 = new Maneja();
                capa1.CadCone = @"Data Source=VENUS;Initial Catalog=Producto2;Integrated Security=True";

                //LLenar tabla
                List<string> NColumnas = new List<string>();
                string[] NC;

                System.Data.DataTable T1 = null;
                T1 = logi.usuarios(ref g);//Obtener todos los usuarios aue se enceuntren activos
                System.Data.DataColumn Columna = null; //Para recorrer columnas.

                int a = 0;
                NC = new string[T1.Columns.Count]; //Inicializar arreglo de forma dinámica.

                for (a = 0; a < T1.Columns.Count; a++) //Recorrer columnas de DataTable.
                {
                    Columna = T1.Columns[a];
                    NC[a] = Columna.ColumnName; //Guardar nombres de columnas en arreglo.
                    NColumnas.Add(Columna.ColumnName);
                }
                GridView1.DataKeyNames = NC;

                GridView1.DataSource = T1; //Mostrar consulta.
                GridView1.DataBind();

                //Llenar combo eliminar
                llenarcomboEliminar();
            }
            else
            {
                Response.Redirect("Encript-Desencript.aspx");
                mimensaje("Usted no cuenta con lo permisos necesarios para poder ver este apartado");
            }
        }

        public void llenarcomboEliminar()
        {
            List<string> nombres = logi.IdUser(ref ids, ref g);
            foreach (string n in nombres){
                ListaTipoUser.Items.Add(n);
            }
        }

        public void mimensaje(string Mensaje)
        {
            Response.Write("<script type='text/javascript'> alert('" + Mensaje + "'); </script>");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string g = "";
            //Eliminacion de usuario
            logi.EliminarUser(ids[ListaTipoUser.SelectedIndex], ref g);
            mimensaje(g);
            Response.Redirect("Visualizar.aspx");
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {

        }
    }
}