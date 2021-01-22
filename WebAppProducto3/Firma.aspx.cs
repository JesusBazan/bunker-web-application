using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppProducto3
{
    public partial class Firma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtfirma.Enabled = false;
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            //Pasar de string a byte[] 
            encrypt.mensaje = Encoding.Default.GetBytes(txtmsj.Text);
            //Obtener la firma
            encrypt.firma = encrypt.firmar(encrypt.mensaje);
            txtfirma.Enabled = true;

            //Proceso para convertir de byte[] a string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < encrypt.firma.Length; i++)
            {
                builder.Append(encrypt.firma[i].ToString("x2"));
            }
            //Se muestra la firma
            txtfirma.Text = (builder.ToString());
        }

        protected void btnVerif_Click(object sender, EventArgs e)
        {
            //Metodo para verificar la firma que regresa un bool
            bool resul = encrypt.verificarFirma(encrypt.mensaje, encrypt.firma);
            if (resul)
                lbStatus.Text = "Confirmación correcta";
            else
                lbStatus.Text = "No hay concordancia en los datos";
        }

        protected void btnReiniciar_Click(object sender, EventArgs e)
        {
            txtfirma.Text = "";
            txtmsj.Text = "";
            lbStatus.Text = "";
        }
    }
}