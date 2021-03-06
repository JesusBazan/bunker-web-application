﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebAppProducto3.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="newCssStyles/RegisterScreen.css"/>

    <script src="JS/jquery-3.3.1.slim.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            //alert("Ejecución en JQuery");
            var caja1 = $('#txtRegnom');
            var caja2 = $('#txtRegapp');
            var caja3 = $('#txtRegapm');
            var caja4 = $('#txtRegtel');
            var caja5 = $('#txtRegemail');
            var caja6 = $('#txtRegpass');


            //C A J A  1
            //Implementar evento focus del TextBox1
            caja1.focus(function () {
                //this se refiere al objeto actual
                //title es como lo traduce el IIS la propiedad tooltip del servidor
                if (caja1.val() == this.title) {
                    //El usuario no ha dado nada
                    caja1.removeClass("DefaultText");
                    caja1.val("");
                }
            });
            caja1.blur(function () {
                if (caja1.val() == "") {
                    caja1.addClass("DefaultText");
                    caja1.val(this.title);
                }
                else {
                    caja.removeClass("DefaultText");
                }
            });//fin blur
            caja1.val("");
            caja1.blur();
            //Otras cajas 1
            caja2.focus(function () {
                if (caja2.val() == this.title) {
                    caja2.removeClass("DefaultText");
                    caja2.val("");
                }
            });
            caja2.blur(function () {
                if (caja2.val() == "") {
                    caja2.addClass("DefaultText");
                    caja2.val(this.title);
                }
                else {
                    caja.removeClass("DefaultText");
                }
            });
            caja2.val("");
            caja2.blur();
            //Otras cajas 3
            caja3.focus(function () {
                if (caja3.val() == this.title) {
                    caja3.removeClass("DefaultText");
                    caja3.val("");
                }
            });
            caja3.blur(function () {
                if (caja3.val() == "") {
                    caja3.addClass("DefaultText");
                    caja3.val(this.title);
                }
                else {
                    caja.removeClass("DefaultText");
                }
            });
            caja3.val("");
            caja3.blur();
            //Otras cajas 4
            caja4.focus(function () {
                if (caja4.val() == this.title) {
                    caja4.removeClass("DefaultText");
                    caja4.val("");
                }
            });
            caja4.blur(function () {
                if (caja4.val() == "") {
                    caja4.addClass("DefaultText");
                    caja4.val(this.title);
                }
                else {
                    caja.removeClass("DefaultText");
                }
            });
            caja4.val("");
            caja4.blur();
            //Otras cajas 5
            caja5.focus(function () {
                if (caja5.val() == this.title) {
                    caja5.removeClass("DefaultText");
                    caja5.val("");
                }
            });
            caja5.blur(function () {
                if (caja5.val() == "") {
                    caja5.addClass("DefaultText");
                    caja5.val(this.title);
                }
                else {
                    caja.removeClass("DefaultText");
                }
            });
            caja5.val("");
            caja5.blur();
            //Otras cajas 6
            caja6.focus(function () {
                if (caja6.val() == this.title) {
                    caja6.removeClass("DefaultText");
                    caja6.val("");
                }
            });
            caja6.blur(function () {
                if (caja6.val() == "") {
                    caja6.addClass("DefaultText");
                    caja6.val(this.title);
                }
                else {
                    caja.removeClass("DefaultText");
                }
            });
            caja6.val("");
            caja6.blur();

        });//fin del ready
    </script>

    <%--<style type="text/css">
        .DefaultText {}
    </style>--%>

</head>
    <body>
            <div class="container">
                <form id="form1" runat="server" class="formulario">
                    <div class="formRegister">

                        <h1 class="title">Registrate</h1>

                        
                        <asp:Label ID="Label1" runat="server" Text="Nombre(s)" class="tager"></asp:Label>
                        <asp:TextBox ID="txtRegnom" runat="server"  CssClass="inputText"></asp:TextBox>
                        <asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator3" 
                            runat="server" 
                            ControlToValidate="txtRegnom" 
                            ErrorMessage="solo caracteres alfabeticos" 
                            ForeColor="Red" 
                            ValidationGroup="validateRegister"
                            ValidationExpression="^[a-zA-Z ]*$"
                        ></asp:RegularExpressionValidator>

                        <asp:Label ID="Label2" runat="server" Text="Apellido paterno" class="tager"></asp:Label>
                        <asp:TextBox ID="txtRegapp" runat="server"  CssClass="inputText"></asp:TextBox>
                        <asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator4" 
                            runat="server" 
                            ControlToValidate="txtRegapp" 
                            ErrorMessage="solo caracteres alfabeticos" 
                            ForeColor="Red" 
                            ValidationGroup="validateRegister"
                            ValidationExpression="^[a-zA-Z\s]{1,}$"
                        ></asp:RegularExpressionValidator>

                        <asp:Label ID="Label3" runat="server" Text="Apellido materno" class="tager"></asp:Label>
                        <asp:TextBox ID="txtRegapm" runat="server" CssClass="inputText"></asp:TextBox>
                        <asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator5" 
                            runat="server" 
                            ControlToValidate="txtRegapm" 
                            ErrorMessage="solo caracteres alfabeticos" 
                            ForeColor="Red" 
                            ValidationGroup="validateRegister"
                            ValidationExpression="^[a-zA-Z\s]{1,}$"
                        ></asp:RegularExpressionValidator>

                        <asp:Label ID="Label4" runat="server" Text="Telefono" class="tager"></asp:Label>
                        <asp:TextBox ID="txtRegtel" runat="server" CssClass="inputText"></asp:TextBox>
                         <asp:RegularExpressionValidator 
                             ID="RegularExpressionValidator1" 
                             runat="server" 
                             ControlToValidate="txtRegtel" 
                             ErrorMessage="10 caracteres numericos necesarios" 
                             ForeColor="Red" 
                             ValidationGroup="validateRegister"
                             ValidationExpression="\d{10}"
                         ></asp:RegularExpressionValidator>

                        <asp:Label ID="Label5" runat="server" Text="Correo" class="tager"></asp:Label>
                        <asp:TextBox ID="txtRegemail" runat="server" CssClass="inputText"></asp:TextBox>
                         <asp:RegularExpressionValidator 
                             ID="RegularExpressionValidator2" 
                             runat="server" 
                             ControlToValidate="txtRegemail" 
                             ErrorMessage="Correo Invalido" 
                             ForeColor="Red" 
                             ValidationGroup="validateRegister"
                             ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                         ></asp:RegularExpressionValidator>

                        <asp:Label ID="Label6" runat="server" Text="Contrasenia" class="tager"></asp:Label>
                        <asp:TextBox ID="txtRegpass" runat="server" CssClass="inputText"></asp:TextBox>
                        <asp:RegularExpressionValidator 
                         ID="RegularExpressionValidator6" 
                         runat="server" 
                         ControlToValidate="txtRegpass" 
                         ErrorMessage="8 - 16 catacteres, 1 numero, 1 caracter especial" 
                         ForeColor="Red" 
                         ValidationExpression="^(?=.*\d)(?=.*[\u0021-\u002b\u003c-\u0040])(?=.*[a-z])\S{8,16}$"
                         causesvalidation="true"
                         ValidationGroup="validateRegister"
                        ></asp:RegularExpressionValidator>

                        <p class="parrafo">Al registrarte, aceptas nuestras Condiciones de uso y Política de privacidad.</p>
                        <p class="parrafo">¿Ya tienes una cuenta? <a class="link" href="Login.aspx">Iniciar Sesion</a></p>
                    </div>
                    <div class="boxButton">
                        <asp:Button 
                            ID="btnRegistrarAlumno" 
                            runat="server" 
                            Text="Registrar"  
                            OnClick="btnRegistrarAlumno_Click" 
                            class="buttonSend"
                            ValidationGroup="validateRegister"
                            causesvalidation="true"
                        />
                    </div>
                </form>
            </div>
</body>
       <footer>
       <script src="https://www.gstatic.com/dialogflow-console/fast/messenger/bootstrap.js?v=1"></script>
<df-messenger
  chat-icon="https:&#x2F;&#x2F;storage.googleapis.com&#x2F;cloudprod-apiai&#x2F;c0f7cf96-2322-4dc6-a57d-1a64860035d7_x.png"
  intent="WELCOME"
  chat-title="Bunkersito"
  agent-id="c7c60dbc-8842-47a5-bb4f-ae225338b8df"
  language-code="es"
></df-messenger>
   </footer>
</html>
