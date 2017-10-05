<%@ Page Title="Cambiar Contraseña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarContrasenia.aspx.cs" Inherits="Web.Paginas.CambiarContrasenia" %>

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
            #MainContent_passvieja, #MainContent_passnueva, #MainContent_repite {
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

            #MainContent_passvieja, #MainContent_passnueva, #MainContent_repite {
                width: 90%;
            }
                      

            #MainContent_passvieja:focus, #MainContent_passnueva:focus, #MainContent_repite:focus {
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

            #MainContent_btnGuardarPassNueva {
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

            #MainContent_btnGuardarPassNueva:hover,#MainContent_btnGuardarPassNueva:focus {
                text-decoration: none;
                opacity: 0.7;
                -webkit-transition: all 0.5s ease-in;
                -moz-transition: all 0.5s ease-in;
                -ms-transition: all 0.5s ease-in;
                -o-transition: all 0.5s ease-in;
            }
        </style>

    </header>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black" Text="Cambiar Contraseña"></asp:Label>
    <div id="contenedor-form">
        <%--            <div id="txtIzq" runat="server">--%>
        <table width="400">
            <tr align="center">
                <td colspan="2" width="400" align="center">
                    <input id="passvieja" name="passvieja" placeholder="Contraseña vieja" required="required" type="password" runat="server" />
                </td>
            </tr>
            <tr align="center">
                <td colspan="1" width="200" align="center">
                    <input id="passnueva" name="passnueva" placeholder="Contraseña nueva" required="required" type="password" runat="server" />
                </td>
                <td colspan="1" width="200" align="center">
                    <input id="repite" name="repite" placeholder="Repita contraseña nueva" required="required" type="password" runat="server" />
                </td>
            </tr>
            <tr align="center">
                <td colspan="2"  width="400">
                    <p><asp:CompareValidator id="compararpassnuevas" ControlToValidate="repite" ControlToCompare="passnueva" runat="server" Type="String" Text="* Contraseñas no coinciden" ForeColor="Red" Font-Bold="true" ></asp:CompareValidator></p>
                    <asp:Button ID="btnGuardarPassNueva" runat="server" Text="Modificar" OnClick="btnGuardarPassNueva_Click" />                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
