<%@ Page Title="SIS.UBI - Sistema Ubicuo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Account.Login" %>


<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <header>  
     <style>
      /*** Google Web Font ***/
      /*Fuente*/
                @font-face {
                    font-family: 'Signika';
                    font-style: normal;
                    font-weight: 400;
                    src: local('Signika'), local('Signika-Regular'), url(http://fonts.gstatic.com/s/signika/v6/AF4iYPZnDjGMiNsxxSXYQfY6323mHUZFJMgTvxaG2iE.woff2) format('woff2');
                    unicode-range: U+0100-024F, U+1E00-1EFF, U+20A0-20AB, U+20AD-20CF, U+2C60-2C7F, U+A720-A7FF;
                }
                /*Fuente*/
                @font-face {
                    font-family: 'Signika';
                    font-style: normal;
                    font-weight: 400;
                    src: local('Signika'), local('Signika-Regular'), url(http://fonts.gstatic.com/s/signika/v6/q41y_9MUP_N8ipOH4ORRvw.woff2) format('woff2');
                    unicode-range: U+0000-00FF, U+0131, U+0152-0153, U+02C6, U+02DA, U+02DC, U+2000-206F, U+2074, U+20AC, U+2212, U+2215, U+E0FF, U+EFFD, U+F000;
                }

                body, body[preview=public] {
                    overflow-x: auto;
                    overflow-y: scroll;
                    font-family: 'signika', sans-serif;
                }

                a {
                    outline: none;
                }
                /*** Botón Salir ***/
                .salir {
                    margin-left: 10px;
                }
                /* --- Formulario Login --- */
                /***Títulos Iniciar Sesion***/
                #tituloIniciarSesion hr {
                    margin: 1% auto 5% auto;
                    border: 0;
                    height: 1px;
                    background: -webkit-gradient(linear, 0 0, 100% 0, from(white), to(white), color-stop(50%, rgb(0, 149, 255)));
                }

                .titIni {
                    color: rgb(0, 149, 255);
                    margin: 0 auto;
                    font-size: 25px;
                    font-style: normal;
                    font-variant: normal;
                    font-weight: normal;
                    display: block;
                    position: relative;
                }

                #contenedorLogin {
                    width: 25%;
                    margin: 0 auto;
                    padding-top: 50px;
                }

                #contenedorTexto {
                    width: 40%;
                    margin: 30px auto;
                    color: rgb(0, 149, 255);
                    font-size: 19px;
                }
                /*** Campos de texto del Formulario Login ***/
                .usr, .pass {
                    width: 80%;
                    font-family: 'signika';
                    font-size: 17px;
                    padding: 10px 10px 10px 40px!important;
                    margin: 1% auto;
                    border: 1px solid #dcdcdc;
                    border-radius: 5px;
                    height: 30px;
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

                .usr {
                    background: #F1F1F1 url(../Images/usrlogin.png) no-repeat 10px;
                }

                .pass {
                    background: #F1F1F1 url(../Images/passlogin.png) no-repeat 10px;
                }

                .usr:focus {
                    background: #FFF url(../Images/usrlogin.png) no-repeat 10px;
                    border: 1px solid #0095FF;
                }

                .pass:focus {
                    background: #FFF url(../Images/passlogin.png) no-repeat 10px;
                    border: 1px solid #0095FF;
                }

                /*** Botón "Ingresar" ***/
                .submit {
                    font-family: 'signika';
                    font-size: 18px;
                    height: 50px;
                    width: 150px;
                    padding: 10px;
                    border-radius: 5px;
                    outline: none;
                    opacity: 0.4;
                    background: #FFF;
                    margin: 5% auto 100px auto;
                    border: none;
                    color: #FFF;
                    cursor: pointer;
                    overflow: hidden;
                    text-decoration: none;
                    line-height: 5px;
                    text-align: center;
                }

                    .submit:hover, .submit:focus {
                        text-decoration: none;
                        opacity: 0.7;
                        -webkit-transition: all 0.5s ease-in;
                        -moz-transition: all 0.5s ease-in;
                        -ms-transition: all 0.5s ease-in;
                        -o-transition: all 0.5s ease-in;
                    }                         
        </style>

        <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCBy52O248NVTAreNPSQnH_Khbt7pYI-go"></script>
        <script type="text/javascript" src="http://l2.io/ip.js?var=myip"></script> 
        <script>
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var latitude = position.coords.latitude;
                var longitude = position.coords.longitude;
                document.getElementById('<%= Latitud.ClientID %>').value = latitude;
                document.getElementById('<%= Longitud.ClientID %>').value = longitude;    
                alert(latitude+"-"+longitude);
            });
        } else {
            alert("Geolocation API is not supported in your browser.");
        }



        </script>

        </header>
        <%--        <h2>Utilice la cuenta de la facu para iniciar sesión.</h2>--%>
        <asp:Panel runat="server" ID="panel" HorizontalAlign="Center">
            <asp:Login runat="server" ID="LoginUser" OnAuthenticate="LoginUser_Authenticate" ViewStateMode="Disabled" RenderOuterTable="false">
                <LayoutTemplate>
                    <div style="width: 867px; margin: 0 auto;">
                        <div id="tituloIniciarSesion">
                            <p class="titIni" align="center">Iniciar Sesi&oacute;n</p>
                            <hr />
                        </div>
                        <div style="width: 500px; margin: 0 auto;">
                            <asp:TextBox CssClass="usr" placeholder="Usuario" runat="server" ID="UserName" required="" />
                            <asp:TextBox CssClass="pass" placeholder="Contrase&ntilde;a" runat="server" ID="Password" TextMode="Password" required="" />
                            <%--<asp:CheckBox runat="server" ID="RememberMe" />--%>
                            <%--<asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">¿Recordar cuenta?</asp:Label>--%>
                            <asp:Button CssClass="submit" runat="server" CommandName="Login" Text="Iniciar sesión" ValidationGroup="LoinUserValidationGroup" />
                            <asp:TextBox ID="Latitud" runat="server" ClientIDMode="Static" style="display:none;" type="text" />
                            <asp:TextBox ID="Longitud" runat="server" ClientIDMode="Static" style="display:none;" type="text" />
                        </div>
                    </div>
                </LayoutTemplate>
            </asp:Login>
        <asp:HiddenField ID="Latitud" runat="server" />
        <asp:HiddenField ID="Longitud" runat="server"/>
        </asp:Panel>
        <%-- <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Registrarse</asp:HyperLink>
            si no tiene una cuenta.
        </p>--%>

</asp:Content>

