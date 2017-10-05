<%@ Page Title="Alta Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioPersona.aspx.cs" Inherits="Web.Paginas.FormularioPersona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured" style="border-color: 7ac0da; background-color: #7ac0da;">
        <div class="content-wrapper" style="border-color: 7ac0da; background-color: #7ac0da;">
            <hgroup class="title">
                <h1>SIS.UBI - Sistema Ubicuo</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <style>
            /* --- Formulario de Contacto --- */
            #contenedor-form {
                width: 55%;
                margin: 0 auto;
            }

            /*** Campos de texto del Formulario de Contacto ***/
            #MainContent_apellido, #MainContent_nombre, #MainContent_numdoc, #MainContent_legajo, #MainContent_telefono, #MainContent_direccion, #MainContent_email, #MainContent_titulo, #MainContent_usr, #MainContent_pass, #MainContent_repite, #MainContent_fechanacimiento, #MainContent_ingreso, #MainContent_tipopersona, #MainContent_idplan, #MainContent_tipodocumento {
                font-family: 'signika';
                font-size: 17px;
                padding: 10px 5px 7px 5px;
                background: #F1F1F1;
                margin: 1% auto;
                border: 1px solid #dcdcdc;
                border-radius: 5px;
                height: 21.1px;
                outline: none;
                -webkit-transition: background 0.6s ease-in;
                -moz-transition: background 0.6s ease-in;
                -ms-transition: background 0.6s ease-in;
                -o-transition: background 0.6s ease-in;
                -webkit-transition: border 0.3s ease-in;
                -moz-transition: border 0.3s ease-in;
                -ms-transition: border 0.3s ease-in;
                -o-transition: border 0.3s ease-in;
            }

            #MainContent_apellido, #MainContent_nombre, #MainContent_legajo, #MainContent_telefono, #MainContent_direccion, #MainContent_email, #MainContent_titulo, #MainContent_usr, #MainContent_pass, #MainContent_repite {
                width: 90%;
            }

            #MainContent_fechanacimiento, #MainContent_ingreso {
                width: 40%;
            }

            #MainContent_tipopersona, #MainContent_idplan {
                width: 46%;
                height: 40px;
            }

            #MainContent_tipodocumento {
                width: 19.4%;
                height: 40px;
            }

            #MainContent_activo {
                margin: 10px auto;
                line-height: 50px;
            }

            #MainContent_numdoc {
                width: 70%;
            }

                #MainContent_apellido:focus, #MainContent_nombre:focus, #MainContent_numdoc:focus, #MainContent_legajo:focus, #MainContent_telefono:focus, #MainContent_direccion:focus, #MainContent_email:focus, #MainContent_titulo:focus, #MainContent_usuario:focus, #MainContent_contraseña:focus, #MainContent_fechanacimiento:focus, #MainContent_ingreso:focus, #MainContent_activo:focus, #MainContent_tipodocumento:focus, #MainContent_tipopersona:focus, #MainContent_idplan:focus, #MainContent_usr:focus, #MainContent_pass:focus {
                    background: #FFF;
                    border: 1px solid #0095FF;
                }
            /*** Botón "Enviar Mensaje" ***/
            #contact-btn {
                position: relative;
                clear: both;
                width: 150px;
                margin: 0 auto;
            }

            #MainContent_BtnAgregar {
                font-family: 'signika';
                font-size: 18px;
                height: 50px;
                width: 150px;
                padding: 10px;
                border-radius: 5px;
                outline: none;
                opacity: 0.4;
                background: #0095FF;
                margin: 5% auto 100px auto;
                border: none;
                color: #FFF;
                cursor: pointer;
                overflow: hidden;
                text-decoration: none;
                line-height: 5px;
                text-align: center;
            }

            #MainContent_BtnCambiarPass {
                font-family: 'signika';
                font-size: 18px;
                height: 50px;
                width: 200px;
                padding: 10px;
                border-radius: 5px;
                outline: none;
                opacity: 0.4;
                background: #0095FF;
                margin: 5% auto 100px auto;
                border: none;
                color: #FFF;
                cursor: pointer;
                overflow: hidden;
                text-decoration: none;
                line-height: 5px;
                text-align: center;
            }

                #MainContent_BtnAgregar:hover, #MainContent_BtnAgregar:focus, #MainContent_BtnCambiarPass:hover, #MainContent_BtnCambiarPass:focus {
                    text-decoration: none;
                    opacity: 0.7;
                    -webkit-transition: all 0.5s ease-in;
                    -moz-transition: all 0.5s ease-in;
                    -ms-transition: all 0.5s ease-in;
                    -o-transition: all 0.5s ease-in;
                }
     </style>

    </header>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black" Text="Formulario Persona"></asp:Label>
    <div id="contenedor-form">
        <%--            <div id="txtIzq" runat="server">--%>
        <table width="400">
            <tr align="center">
                <td colspan="1" width="200" align="center">
                    <input id="nombre" name="nombre" placeholder="Nombre" type="text" runat="server" />
                    <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="nombre" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td colspan="1" width="200" align="center">
                    <input id="apellido" name="apellido" placeholder="Apellido" type="text" runat="server" />
                    <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="apellido" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr align="center">
                <td colspan="1" width="200">
                    <input id="legajo" name="legajo" placeholder="Legajo" type="text" runat="server" />
                    <asp:RegularExpressionValidator ID="REV1" Text="* Solo se admiten números" ForeColor="Red" Font-Bold="true" ControlToValidate="legajo" Runat="server" Display="Dynamic" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                </td>
                <td colspan="1" width="200">
                    <asp:DropDownList ID="tipopersona" runat="server" DataSourceID="TiposPersona" DataTextField="descripcion_persona" DataValueField="id_tipo_persona" AppendDataBoundItems="True" AutoPostBack="false" Width="180" required="required" Enabled="False"></asp:DropDownList>
                    <asp:SqlDataSource ID="TiposPersona" runat="server" ConnectionString="<%$ ConnectionStrings:SGAConnectionString %>" SelectCommand="SELECT * FROM [tipos_persona] WHERE id_tipo_persona != 1"></asp:SqlDataSource>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" Font-Bold="true" ControlToValidate="tipopersona" InitialValue="Seleccione un Tipo"/>
                </td>
            </tr>
            <tr align="center">
                <td colspan="2" width="400">
                    <input id="email" name="email" placeholder="ejemplo@correo.com" type="text" runat="server" size="40"/>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="email" Display="Dynamic" Text="* Email inválido" ForeColor="Red" Font-Bold="true" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr align="center">
                <td colspan="2" width="400">
                    <input id="usr" name="usr" placeholder="Usuario" type="text" runat="server" />
                    <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="usr" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr align="center">
                <td colspan="1" width="200">
                    <input id="pass" name="pass" placeholder="Contraseña" type="password" runat="server" />
                    <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ControlToValidate="pass" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td colspan="1" width="200">
                    <input id="repite" name="repite" placeholder="Repita contraseña" type="password" runat="server" />
                    <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ControlToValidate="repite" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr align="center">
                <td colspan="2"  width="400">
                    <input id="reiniciar" name="reiniciar" type="checkbox" runat="server" style="display:none"/>&nbsp; <asp:Label ID="msjreiniciar" runat="server" Text="Reiniciar contraseña (1234)" Font-Bold="true" Font-Size="Medium" Visible="false"></asp:Label>
                    <p><asp:CompareValidator id="compararpass" ControlToValidate="repite" ControlToCompare="pass" runat="server" Type="String" Text="* Contraseñas no coinciden" ForeColor="Red" Font-Bold="true" ></asp:CompareValidator></p>                   
                </td>
            </tr>
            <tr align="center">
                <td colspan="1" width="200">
                    <asp:Button ID="BtnCambiarPass" runat="server" Text="Cambiar contraseña" Visible="false" CausesValidation="false" OnClick="BtnCambiarPass_Click" />                    
                </td>
                <td colspan="1" width="200">
                    <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" /> 
                </td>                
            </tr>            
        </table>
    </div>
    <script>
        $(document).ready(function () {
            $("#txtboxToFilter").keydown(function (e) {
                // Allow: backspace, delete, tab, escape, enter and .
                if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                    // Allow: Ctrl+A
                    (e.keyCode == 65 && e.ctrlKey === true) ||
                    // Allow: Ctrl+C
                    (e.keyCode == 67 && e.ctrlKey === true) ||
                    // Allow: Ctrl+X
                    (e.keyCode == 88 && e.ctrlKey === true) ||
                    // Allow: home, end, left, right
                    (e.keyCode >= 35 && e.keyCode <= 39)) {
                    // let it happen, don't do anything
                    return;
                }
                // Ensure that it is a number and stop the keypress
                if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                    e.preventDefault();
                }
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $('.legajo').mask('08-00000');
        })
    </script>
    <%--     <script>
         $(document).ready(function () {
             $("#numdoc").keydown(function (e) {
                 // Allow: backspace, delete, tab, escape, enter and .
                 if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                     // Allow: Ctrl+A
                     (e.keyCode == 65 && e.ctrlKey === true) ||
                     // Allow: Ctrl+C
                     (e.keyCode == 67 && e.ctrlKey === true) ||
                     // Allow: Ctrl+X
                     (e.keyCode == 88 && e.ctrlKey === true) ||
                     // Allow: home, end, left, right
                     (e.keyCode >= 35 && e.keyCode <= 39)) {
                     // let it happen, don't do anything
                     return;
                 }
                 // Ensure that it is a number and stop the keypress
                 if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                     e.preventDefault();
                 }
             });
         });
    </script>--%>
</asp:Content>
