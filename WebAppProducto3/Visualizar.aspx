<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Visualizar.aspx.cs" Inherits="WebAppProducto3.Visualizar" %>

<!DOCTYPE html>


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
                <a href="#"><span class="fa fa-edit"></span>Actualizar ▾<span class=""></span></a>
                <ul class="children">
                    <li><a href="ActualizarUsuario.aspx">Actualizar Usuario<span class="icon-update"></span></a></li>
                   
                </ul>
            </li>

            <li><a href="Login.aspx"><span class="fa fa-sign-out-alt"></span>Cerrar Sesión</a></li>
            </ul>

           
    </nav>
</div>
</header>
       <div id="divContenidovisu">
           <h1>Visualizar Usuarios</h1>
           <br />
           <div id="divContevisu">
               
               

               <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                   <AlternatingRowStyle BackColor="White" />
                   <FooterStyle BackColor="#CCCC99" />
                   <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                   <RowStyle BackColor="#F7F7DE" />
                   <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#FBFBF2" />
                   <SortedAscendingHeaderStyle BackColor="#848384" />
                   <SortedDescendingCellStyle BackColor="#EAEAD3" />
                   <SortedDescendingHeaderStyle BackColor="#575357" />
               </asp:GridView>
               
               <br />
               <br />
               <asp:DropDownList ID="ListaTipoUser" runat="server" CssClass="fontRol">
               </asp:DropDownList>
&nbsp;
               <asp:Button class="fontBoton" ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Elminar" />
               <br />
               <br />
               <br />
               
               


           </div>  
           <br />

       </div>

    </form>
</body>
</html>