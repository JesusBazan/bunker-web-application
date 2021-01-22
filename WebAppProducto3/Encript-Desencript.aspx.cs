using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassAccesoDatosSQL;
using System.Data.SqlClient;
using ClassLogicaNegociosPagos;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace WebAppProducto3
{
    public partial class agregaAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        byte[] RSAEncript;

        public void redemarer()
        {
            txtIV.Text = "";
            txtKey.Text = "";
            txtResultado.Text = "";
            txtTexto.Text = "";
            lbStatus.Text = "";
        }

        public void llenarSimetricos() {
            listaMetodo.Items.Clear();
            listaMetodo.Items.Add("AES");
            listaMetodo.Items.Add("DES");
            //listaMetodo.Items.Add("3DES");
        }

        public void llenarAsimetricos()
        {
            listaMetodo.Items.Clear();
            listaMetodo.Items.Add("RSA");
            //listaMetodo.Items.Add("RSA2");
            //listaMetodo.Items.Add("SM2");
        }

       public void llenarHash()
        {
            listaMetodo.Items.Clear();
            listaMetodo.Items.Add("MD5");
            listaMetodo.Items.Add("SHA1");
            listaMetodo.Items.Add("SHA256");
            listaMetodo.Items.Add("SHA512");
        }

        protected void btnEncriptar_Click(object sender, EventArgs e)
        {
            string texto = txtTexto.Text;
            if (listaMetodo.SelectedValue == "AES")
            {
                encrypt.Key_IV(txtKey.Text, txtIV.Text);
                txtResultado.Text = encrypt.CifradoTextoAES(texto);
            }
            else if (listaMetodo.SelectedValue == "DES")
            {
                txtResultado.Text = encrypt.CifradoTextoDES(texto);
            }
            else if (listaMetodo.SelectedValue == "3DES")
            {

            }
            else if (listaMetodo.SelectedValue == "RSA")
            {
                // Si no existe el fichero de claves
                if (File.Exists(encrypt.ficPruebas) == false)
                {
                    encrypt.crearXMLclaves(encrypt.ficPruebas);
                }

                string xmlKeys = encrypt.clavesXML(encrypt.ficPruebas);

                byte[] datos = encrypt.CifrarRSA(texto, xmlKeys);
                RSAEncript = datos;

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < datos.Length; i++)
                {
                    builder.Append(datos[i].ToString("x2"));
                }
                txtResultado.Text = builder.ToString();
            }
        }

        protected void btnDesencrip_Click(object sender, EventArgs e)
        {
            string encrip = txtResultado.Text;

            if (listaMetodo.SelectedValue == "AES") {
                encrypt.Key_IV(txtKey.Text, txtIV.Text);//toma los valores de la llave y el vector
                txtTexto.Text = encrypt.DescifradoTextoAES(encrip);
            }
            else if (listaMetodo.SelectedValue == "DES")
            {
                txtTexto.Text = encrypt.DescifradoTextoDES(encrip);
            }
            else if (listaMetodo.SelectedValue == "RSA")
             {
                string xmlKeys = encrypt.clavesXML(encrypt.ficPruebas);//toma el valor de las llaves
                byte[] rsaEncrypt = UTF8Encoding.UTF8.GetBytes(encrip);//lo convierte a byte[]
                txtTexto.Text = encrypt.DescifrarRSA(rsaEncrypt, xmlKeys);
             }
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            switch (listaMetodo.SelectedValue)
            {
                case "SHA256":
                    txtResultado.Text = encrypt.ComputeHash(txtTexto.Text, encrypt.Supported_HA.SHA256, null);
                    break;
                case "SHA512":
                    txtResultado.Text = encrypt.ComputeHash(txtTexto.Text, encrypt.Supported_HA.SHA512, null);
                    break;
                case "SHA1":
                    txtResultado.Text = encrypt.ComputeHash(txtTexto.Text, encrypt.Supported_HA.SHA1, null);
                    break;
                case "MD5":
                    txtResultado.Text = encrypt.ComputeHash(txtTexto.Text, encrypt.Supported_HA.MD5, null);
                    break;
            }
        }

        protected void btnVerif_Click(object sender, EventArgs e)
        {
            switch (listaMetodo.SelectedValue)
            {
                case "SHA256":
                    lbStatus.Text = encrypt.Confirm(txtTexto.Text, txtResultado.Text, encrypt.Supported_HA.SHA256) ? "Estado correcto" : "Estado incorrecto";
                    break;
                case "SHA512":
                    lbStatus.Text = encrypt.Confirm(txtTexto.Text, txtResultado.Text, encrypt.Supported_HA.SHA512) ? "Estado correcto" : "Estado incorrecto";
                    break;
                case "SHA1":
                    lbStatus.Text = encrypt.Confirm(txtTexto.Text, txtResultado.Text, encrypt.Supported_HA.SHA1) ? "Estado correcto" : "Estado incorrecto";
                    break;
                case "MD5":
                    lbStatus.Text = encrypt.Confirm(txtTexto.Text, txtResultado.Text, encrypt.Supported_HA.MD5) ? "Estado correcto" : "Estado incorrecto";
                    break;
            }
        }

        protected void listaTipoMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaTipoMetodo.SelectedItem != null)
            {
                listaMetodo.Items.Clear();
                if (listaTipoMetodo.SelectedValue == "Cifrado simétrico")
                {
                    llenarSimetricos();
                }
                else if (listaTipoMetodo.SelectedValue == "Cifrado hash")
                {
                    llenarHash();
                }
                else if (listaTipoMetodo.SelectedValue == "Cifrado asimétrico")
                {
                    llenarAsimetricos();
                }
            }
        }
        protected void listaMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaMetodo.SelectedValue == "AES") {
                redemarer();
                btnCalcular.Enabled = false;
                btnVerif.Enabled = false;
            }
            else if (listaMetodo.SelectedValue == "DES") {
                redemarer();
                btnCalcular.Enabled = false;
                btnVerif.Enabled = false;
                txtIV.Enabled = false;
                txtKey.Enabled = false;
            }
            else if (listaMetodo.SelectedValue == "3DES") {
                redemarer();
                btnCalcular.Enabled = false;
                btnVerif.Enabled = false;
            }
            else if (listaMetodo.SelectedValue == "RSA") {
                redemarer();
            }
            else if (listaMetodo.SelectedValue == "RSA2") {
                redemarer();
            }
            else if (listaMetodo.SelectedValue == "SM2") {
                redemarer();
            }
            else if (listaMetodo.SelectedValue == "MD5") {
                redemarer();
                btnEncriptar.Enabled = false;
                btnDesencrip.Enabled = false;
                txtIV.Enabled = false;
                txtKey.Enabled = false;
            }
            else if (listaMetodo.SelectedValue == "SHA1") {
                redemarer();
                btnEncriptar.Enabled = false;
                btnDesencrip.Enabled = false;
                txtIV.Enabled = false;
                txtKey.Enabled = false;
            }
            else if (listaMetodo.SelectedValue == "SHA256") {
                redemarer();
                btnEncriptar.Enabled = false;
                btnDesencrip.Enabled = false;
                txtIV.Enabled = false;
                txtKey.Enabled = false;
            }
            else if (listaMetodo.SelectedValue == "SHA512") {
                redemarer();
                btnEncriptar.Enabled = false;
                btnDesencrip.Enabled = false;
                txtIV.Enabled = false;
                txtKey.Enabled = false;
            }
        }

        protected void btnReiniciar_Click(object sender, EventArgs e)
        {
            redemarer();
            listaTipoMetodo.SelectedIndex = 0;
            llenarSimetricos();
            btnEncriptar.Enabled = true;
            btnDesencrip.Enabled = true;
            btnCalcular.Enabled = true;
            btnVerif.Enabled = true;
            txtIV.Enabled = true;
            txtKey.Enabled = true;
        }

        public void mimensaje(string Mensaje)
        {
            Response.Write("<script type='text/javascript'> alert('" + Mensaje + "'); </script>");
        }
    }
}