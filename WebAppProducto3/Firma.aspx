<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Firma.aspx.cs" Inherits="WebAppProducto3.Firma" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <meta charset="UTF-8"/>
	<title>Agregar alumno</title>
    <link rel="shortcut icon" href="images/UTP.ico"/>
	<meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
   
	<script src="http://code.jquery.com/jquery-latest.js"></script>
    <script src="js/ResponsiveCrod.js"></script>
    <link href="css/StyleCrod.css" rel="stylesheet" />
   
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
<div style="width: 100%; background: rgb(105,28,50);" >
    <nav>
        
        <ul>
              <li class="submenu">
                <a href="#"><span class="fa fa-plus-square"></span>Agregar ▾</a>
                <ul class="children">
                   <li><a href="agregauser.aspx">Nuevo Usuario<span class="fa fa-user"></span></a></li>
               
                </ul>
              </li>
              <li class="submenu">
                <a href="#"><span class="fa fa-edit"></span>Actualizar ▾<span class=""></span></a>
                <ul class="children">
                    <li><a href="ActualizarUsuario.aspx">Actualizar Usuario<span class="icon-update"></span></a></li>
                   
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
           <h1>Firmar un mensaje</h1>
           <br />
           <br />
           <br />
           <br />
           Mensaje&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtmsj" runat="server" CssClass="classText" ToolTip="Texto a encriptar o desencriptar"></asp:TextBox>
           <br />
           Firma&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtfirma" runat="server" CssClass="classText" ToolTip="Texto a encriptar o desencriptar"></asp:TextBox>
           <br />
           <asp:Label ID="lbStatus" runat="server"></asp:Label>
           <br />
           <br />
           <br />
           <asp:Button class="fontBoton" ID="btnCalcular" runat="server" Text="Firmar" Width="205px" OnClick="btnCalcular_Click" autopostback="false"/>
           <asp:Button class="fontBoton" ID="btnVerif" runat="server" Text="Verificación" Width="205px" OnClick="btnVerif_Click" autopostback="false"/>
           <br />
           <br />
           <asp:Button class="fontBoton" ID="btnReiniciar" runat="server" Text="Reiniciar" Width="205px" OnClick="btnReiniciar_Click" />
       </div>

    </form>
</body>
</html>