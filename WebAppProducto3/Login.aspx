<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppProducto3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>L O G G I N</title>
    <link rel="stylesheet" href="estiloLogin.css"/>
    <script src="JS/jquery-3.3.1.slim.js"></script>
    <script type="text/javascript">

        function validar(form1) {

            if (document.form1.TextBox1.value == "") {
                alert("Ingresa todos los datos");
                return false;
                document.form1.TextBox1.focus();
            } else {
                return true;
            }

        }

        $(document).ready(function()
        {
            //alert("Ejecución en JQuery");
            var caja1 = $('#TextBox1');
            var caja2 = $('#TextBox2');

            //C A J A  1

            //Implementar evento focus del TextBox1
            caja1.focus(function ()
            {
                //this se refiere al objeto actual
                //title es como lo traduce el IIS la propiedad tooltip del servidor
                if (caja1.val() == this.title)
                {
                    //El usuario no ha dado nada
                    caja1.removeClass("DefaultText");
                    caja1.val("");
                }
            });

            caja1.blur(function ()
            {
                if (caja1.val() == "") {
                    caja1.addClass("DefaultText");
                    caja1.val(this.title);
                }
                else
                {
                    caja.removeClass("DefaultText");
                }
            });//fin blur
            caja1.val("");
            caja1.blur();

            //C A J A  2

            caja2.focus(function ()
            {
                //this se refiere al objeto actual
                //title es como lo traduce el IIS la propiedad tooltip del servidor
                if (caja2.val() == this.title)
                {
                    //El usuario no ha dado nada
                    caja2.removeClass("DefaultText");
                    caja2.attr('type','password');
                    caja2.val("");
                }
            });

            caja2.blur(function ()
            {
                if (caja2.val() == "")
                {
                    caja2.addClass("DefaultText");
                    caja2.attr('type','text');
                    caja2.val(this.title);
                }
            });//fin blur

            caja2.blur();
        });//fin del ready


    </script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return validar()">
     
            <div id="area1">
               <br/><h1>Login</h1>
                <br /><br />
                <asp:TextBox ID="TextBox1" runat="server" ToolTip="Correo electronico"  CssClass="DefaultText" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Ingresa un correo" ForeColor="Red"></asp:RequiredFieldValidator>
                <br /><br />
                
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"  ToolTip="Contraseña"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Ingresa una contraseña" ForeColor="Red"></asp:RequiredFieldValidator>

                <br /><br /><asp:Button ID="Button1" runat="server" Font-Names="Bahnschrift SemiBold" Text="Iniciar"  OnClick="Button1_Click" class="buton"/>
                <br /><p>Al registrarte, aceptas nuestras Condiciones de uso y Política de privacidad.</p>
                <br /><p>¿No tienes una cuenta? <a class="link" href="Registro.aspx">Registrate</a></p>
                   
            
            </div>
       
    </form>
</body>
</html>
