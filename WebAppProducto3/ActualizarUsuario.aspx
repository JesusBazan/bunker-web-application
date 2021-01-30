<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizarUsuario.aspx.cs" Inherits="WebAppProducto3.Actualizar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <meta charset="UTF-8"/>
	<title>Agregar usuario</title>
    <link rel="shortcut icon" href="images/UTP.ico"/>
	<meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
   
	<script src="http://code.jquery.com/jquery-latest.js"></script>
    <script src="js/ResponsiveCrod.js"></script>
<%--    <link href="css/StyleCrod.css" rel="stylesheet" />--%>
   
    <link href="css/icons.css" rel="stylesheet" />
    <link href="CSS%20Steph/AdministracionStyle.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>


</head>
<body>
   <form id="form1" runat="server">

   <header>


    <div class="menu_bar">
        <a href="#" class="bt-menu"><span class="fa fa-home"></span>Menú ▾</a>
    </div>
<div style="width: 100%; background: #0019BD;" >
    <nav>
        
        <ul>
            <li class="submenu">
                <a href="#"><span class="fa fa-plus-square"></span>Encriptar / Desencriptar ▾</a>
                <ul class="children">
                    <li><a href="Encript-Desencript.aspx">Encriptar / Desencriptar<span class="fa fa-user-graduate"></span></a></li>
               
                </ul>
              </li>
           
              <li class="submenu">
                <a href="#"><span class="fa fa-plus-square"></span>Agregar ▾</a>
                <ul class="children">
                   <li><a href="agregauser.aspx">Nuevo Usuario<span class="fa fa-user"></span></a></li>
               
                </ul>
              </li>
            
            <li class="submenu">
                <a href="#"><span class="fa fa-eye"></span>Visualizar ▾<span class=""></span></a>
                <ul class="children">
                    <li><a href="Visualizar.aspx">Visualizar Usuarios<span class="icon-eye"></span></a></li>
                  
                </ul>
            </li>
            <li><a href="Login.aspx"><span class="fa fa-sign-out-alt"></span>Cerrar Sesión</a></li>
            </ul>
    </nav>
</div>
</header>

       <div id="divContenido">
           <h1>Actualizar Usuario</h1>
           <br />
           <div id="divContenido2">

               <asp:DropDownList ID="ListaUsers" runat="server"  CssClass="fontRol" OnSelectedIndexChanged="ListaUsers_SelectedIndexChanged"></asp:DropDownList>
               <br /><br />
               <asp:Button class="fontBoton" ID="btnSelect" runat="server" Text="Seleccionar"   OnClick="btnSelect_Click"/>

               
               <br />
               <br />
               <asp:Label ID="lblNom" runat="server" Text="Nombre:  "></asp:Label>
           <asp:TextBox ID="txtNombre" runat="server"    ></asp:TextBox>
           <br /><br />
           <asp:Label ID="lblApp" runat="server" Text="Apellido paterno:  "></asp:Label>
           <asp:TextBox ID="txtApp" runat="server" title="Sólo se permiten letras" ></asp:TextBox>
           <br /><br />
           <asp:Label ID="lblApm" runat="server" Text="Apellido materno:  "></asp:Label>
           <asp:TextBox ID="txtApm" runat="server"   title="Sólo se permiten letras" ></asp:TextBox>
           <br /><br />
           <asp:Label ID="lblTel" runat="server" Text="Teléfono:  "></asp:Label>
           <asp:TextBox ID="txtTel" runat="server"   title="Sólo se permiten números. 10 digitos" ></asp:TextBox>
           <br /><br />
           <asp:Label ID="lblCorreo" runat="server" Text="Correo electrónico:  "></asp:Label>
           <asp:TextBox ID="txtCorreo" runat="server"   title="Verifica que el formato sea correcto" ></asp:TextBox>
           <br /><br />
           <asp:Label ID="lblContra" runat="server" Text="Contraseña:  "></asp:Label>
           <asp:TextBox ID="txtContra" runat="server"   title="Verifica que el formato sea correcto"></asp:TextBox>
           <br /><br />
           <asp:Label ID="lblRol" runat="server" Text="Rol:  "></asp:Label>
           <asp:DropDownList ID="listaRol" runat="server"  CssClass="fontRol"></asp:DropDownList>
           </div> 
           <br /><br />
           <asp:Button class="fontBoton"  ID="Button1" runat="server" Text="Actualizar" OnClick="Button1_Click" />


            <br /><br /><br /><br /><br /><br /><br />


            </div>

    </form>


</body>
</html>

