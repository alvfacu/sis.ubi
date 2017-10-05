<%@ Page Title="Cargar Archivo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargaArchivos.aspx.cs" Inherits="Web.Paginas.CargaArchivos" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

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
    <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCBy52O248NVTAreNPSQnH_Khbt7pYI-go"></script>
    <script type="text/javascript" src="http://l2.io/ip.js?var=myip"></script> 
    <script>
        var map;
        var gmarkers = [];
        var circles = [];
        var myCenter = new google.maps.LatLng(-32.9545095, -60.6437689);
        var radio;
        var infowindow = new google.maps.InfoWindow;
        var geocoder = new google.maps.Geocoder;        

        function initialize() {
            radio = 30;
            document.getElementById("radio").value = radio;
            var mapProp = new google.maps.Marker({});
            map = new google.maps.Map(document.getElementById("googleMap"), {
                zoom: 13,
                center: myCenter
            });
            google.maps.event.addListener(map, 'click', function (event) {
                placeMarker(event.latLng);
            });
            addYourLocationButton(map, mapProp);

        }

        google.maps.event.addDomListener(window, 'load', initialize);

        function placeMarker(location) {

            for (i = 0; i < gmarkers.length; i++) {
                gmarkers[i].setMap(null);
                circles[i].setMap(null);
            }
            var myLatLng = { lat: location.lat(), lng: location.lng() };

            var geocoder = new google.maps.Geocoder;
            var infowindow = new google.maps.InfoWindow;

            map.setCenter(myLatLng);

            geocoder.geocode({ 'location': myLatLng }, function (results, status) {
                if (status === google.maps.GeocoderStatus.OK) {
                    if (results[1]) {
                        map.setZoom(17);
                        var marker = new google.maps.Marker({
                            position: myLatLng,
                            map: map,
                            id: 2
                        });
                        gmarkers.push(marker);
                        var circle = new google.maps.Circle({
                            map: map,
                            radius: radio,
                            fillColor: '#23ee11'
                        });

                        circle.bindTo('center', marker, 'position');
                        circles.push(circle);
                        infowindow.setContent("<b>"+results[0].formatted_address);
                        infowindow.open(map, marker);
                    }
                    else {
                        window.alert('No results found');
                    }
                }
                else {
                    window.alert('Geocoder failed due to: ' + status);
                }
            });

            document.getElementById("Latitud").value = location.lat();
            document.getElementById("Longitud").value = location.lng();
            document.getElementById("Radio").value = radio;
        }

        function removeMarkers() {
            for (i = 0; i < gmarkers.length; i++) {
                gmarkers[i].setMap(null);
            }
        }

        function cambiarRadio() {
            radio = parseInt(document.getElementById("radio").value);
            for (i = 0; i < gmarkers.length; i++) {
                if (gmarkers[i].get('id') == 2) {
                    circles[i].setRadius(radio);
                }
            }
            document.getElementById("Radio").value = radio;
        }

        function habilitar() {
            if (document.getElementById("modificar").checked == false) {
                document.getElementById("radio").disabled = true;
                document.getElementById("cambiar").disabled = true;
                document.getElementById("modificar").checked = false;
            }
            else {
                document.getElementById("radio").disabled = false;
                document.getElementById("cambiar").disabled = false;
                document.getElementById("modificar").checked = true;
            }
        }

        function subeArchivo() {
            if (document.getElementById("archivo").checked == false) {
                document.getElementById('<%= FileUpload1.ClientID %>').disabled = true;
                document.getElementById("archivo").checked = false;
                document.getElementById("Sube").value = "";
                document.getElementById('<%= btnSubir.ClientID %>').disabled = true;
            }
            else {
                document.getElementById('<%= FileUpload1.ClientID %>').disabled = false;
                document.getElementById("archivo").checked = true;
                document.getElementById("Sube").value = "A";
                document.getElementById("pag").checked = false;
                document.getElementById("examen").checked = false;
                document.getElementById('<%= btnSubir.ClientID %>').disabled = false;
            }
        }

        function subePagina(){
            if (document.getElementById("pag").checked == false) {
                document.getElementById('<%= pagina.ClientID %>').disabled = true;
                document.getElementById("pag").checked = false;
                document.getElementById("Sube").value = "";
                document.getElementById('<%= btnSubir.ClientID %>').disabled = true;
            }
            else {
                document.getElementById('<%= pagina.ClientID %>').disabled = false;
                document.getElementById('<%= pagina.ClientID %>').focus;
                document.getElementById("pag").checked = true;                
                document.getElementById("archivo").checked = false;
                document.getElementById("examen").checked = false;
                document.getElementById("Sube").value = "P";
                document.getElementById('<%= btnSubir.ClientID %>').disabled = false;
            }
        }

        function subeExamen(){
            if (document.getElementById("examen").checked == false) {
                document.getElementById('<%= FileUpload2.ClientID %>').disabled = true;
                document.getElementById("examen").checked = false;
                document.getElementById("Sube").value = "";
                document.getElementById('<%= btnSubir.ClientID %>').disabled = true;
            }
            else {
                document.getElementById('<%= FileUpload2.ClientID %>').disabled = false;
                document.getElementById('<%= FileUpload2.ClientID %>').focus;
                document.getElementById("examen").checked = true;
                document.getElementById("Sube").value = "E";
                document.getElementById("pag").checked = false;
                document.getElementById("archivo").checked = false;
                document.getElementById('<%= btnSubir.ClientID %>').disabled = false;
            }
        }


        function addYourLocationButton(map, marker) {
            var controlDiv = document.createElement('div');

            var firstChild = document.createElement('button');
            firstChild.style.backgroundColor = '#fff';
            firstChild.style.border = 'none';
            firstChild.style.outline = 'none';
            firstChild.style.width = '28px';
            firstChild.style.height = '28px';
            firstChild.style.borderRadius = '2px';
            firstChild.style.boxShadow = '0 1px 4px rgba(0,0,0,0.3)';
            firstChild.style.cursor = 'pointer';
            firstChild.style.marginRight = '10px';
            firstChild.style.padding = '0';
            firstChild.title = 'Your Location';
            controlDiv.appendChild(firstChild);

            var secondChild = document.createElement('div');
            secondChild.style.margin = '5px';
            secondChild.style.width = '18px';
            secondChild.style.height = '18px';
            secondChild.style.backgroundImage = 'url(https://maps.gstatic.com/tactile/mylocation/mylocation-sprite-2x.png)';
            secondChild.style.backgroundSize = '180px 18px';
            secondChild.style.backgroundPosition = '0 0';
            secondChild.style.backgroundRepeat = 'no-repeat';
            firstChild.appendChild(secondChild);

            google.maps.event.addListener(map, 'center_changed', function () {
                secondChild.style['background-position'] = '0 0';
            });
            firstChild.addEventListener('click', function () {
                var imgX = '0',
                    animationInterval = setInterval(function () {
                        imgX = imgX === '-18' ? '0' : '-18';
                        secondChild.style['background-position'] = imgX + 'px 0';
                    }, 500);

                if (navigator.geolocation) {
                    navigator.geolocation.getCurrentPosition(function (position) {
                        for (i = 0; i < gmarkers.length; i++) {
                            gmarkers[i].setMap(null);
                            circles[i].setMap(null);
                        }
                        var latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
                        map.setCenter(latlng);
                        clearInterval(animationInterval);
                        secondChild.style['background-position'] = '-144px 0';
                        geocoder.geocode({ 'location': latlng }, function (results, status) {
                            if (status === google.maps.GeocoderStatus.OK) {
                                if (results[1]) {
                                    map.setZoom(17);
                                    var myMarker = new google.maps.Marker({
                                        map: map,
                                        position: latlng,
                                        animation: google.maps.Animation.DROP,
                                        id: 1
                                    });
                                    var circle = new google.maps.Circle({
                                        map: map,
                                        radius: 20,
                                        fillColor: '#99dee9'
                                    });
                                    circle.bindTo('center', myMarker, 'position');
                                    circles.push(circle);
                                    myMarker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png');
                                    gmarkers.push(myMarker);
                                    infowindow.setContent("Usted se encuentra aquí:<br\> <b>" + results[0].formatted_address);
                                    infowindow.open(map, myMarker);
                                }
                                else {
                                    window.alert('No results found');
                                }
                            }
                            else {
                                window.alert('Geocoder failed due to: ' + status);
                            }
                        });
                    });
                }
                else {
                    clearInterval(animationInterval);
                    secondChild.style['background-position'] = '0 0';
                }
            });

            controlDiv.index = 1;
            map.controls[google.maps.ControlPosition.RIGHT_BOTTOM].push(controlDiv);

        }

        function obtenerIPExterna()
        {
            document.getElementById('<%= ip.ClientID %>').value = "";
            document.getElementById('<%= ip.ClientID %>').value = myip;
        }

        $(function() { $('#basicExample').timepicker(); });

        $(function () { $(".datepicker").datepicker({ dateFormat: 'yy-mm-dd' }); });
    </script>
    </header>

    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black" Text="Carga de Archivo"></asp:Label>
    <br />
    <br />
    <asp:Panel runat="server" ID="panel" HorizontalAlign="Center">
        <br />
        <br />
        <asp:Label runat="server" ID="Label2" Font-Bold="true"> Comisión: </asp:Label>
        <asp:DropDownList runat="server" ID="comisiones" AutoPostBack="False" Font-Names="Arial" Height="25px" Width="250px"></asp:DropDownList>
        <br />
        <br />        
        <table align="center">
            <tr>
                <td style="text-align: center"><input type="checkbox" ID="archivo" OnClick="subeArchivo()"/><asp:Label runat="server" ID="Label8" Font-Bold="true">Archivo:</asp:Label></td>
                <td><asp:FileUpload ID="FileUpload1" runat="server" Width="480px" Font-Names="Arial" Height="30px" Enabled="false" /></td>
            </tr>
            <tr>
                <td colspan="2" style="font-style: italic; font-size: small; font-weight: bold">Formatos aceptados: .doc, .docx, .xls, .xlsx, .pdf, .txt, .ppt, .pptx</td>
            </tr>
            <tr>
                <td style="text-align: center"><input type="checkbox" ID="pag" OnClick="subePagina()"/><asp:Label runat="server" ID="Label9" Font-Bold="true">Página:</asp:Label></td>
                <td><asp:TextBox ID="pagina" runat="server" name="ingre" placeholder="Ingrese una página" type="text" Width="480px" Font-Names="Arial" Height="20px" Enabled="false" /></td>
            </tr>
            <tr>
                <td style="text-align: center"><input type="checkbox" ID="examen" OnClick="subeExamen()"/><asp:Label runat="server" ID="Label5" Font-Bold="true">Examen:</asp:Label></td>
                <td><asp:FileUpload ID="FileUpload2" runat="server" Width="480px" Font-Names="Arial" Height="30px" Enabled="false"/></td>
            </tr>
        </table>        
        <br />     
        <asp:Label runat="server" ID="LabelMateria" Font-Bold="true">Descripción: </asp:Label>
        <asp:TextBox ID="descripcion" runat="server" Font-Names="Arial" type="text" Width="350px" placeholder="Ej.: Materia / Lugar referencia" Height="20px"></asp:TextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="descripcion" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Font-Bold="true">Fecha: </asp:Label>
        <!--<input type="text" class="datepicker" name="fecha" style="width:174px;font-name:arial;height:20px" />-->
        <asp:TextBox ID="fecha" name="ingreso" placeholder="Fecha" type="date" runat="server" Width="174px" Font-Names="Arial" Height="20px" />
        <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="fecha" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Font-Bold="true">Hora Inicio: </asp:Label>
        &nbsp;<!--<input type="text" class="timestart" name="inicio" />--><asp:TextBox ID="inicio" runat="server" Font-Names="Arial" Height="20px" name="ingreso" placeholder="Hora Inicio" type="time" Width="130px" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="inicio" Display="Dynamic" Font-Bold="true" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" Font-Bold="true">Hora Fin: </asp:Label>
        <!--<input type="text" class="timeend" name="fin"  />-->
        <asp:TextBox ID="fin" runat="server" Font-Names="Arial" Height="20px" name="ingreso" placeholder="Hora Fin" type="time" Width="130px" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="fin" Display="Dynamic" Font-Bold="true" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Font-Bold="true">IP: </asp:Label>
        <asp:TextBox ID="ip" runat="server" Font-Names="Arial" Height="20px" name="ingre" placeholder="Dirreción IP" type="text" Width="208px" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ip" Display="Dynamic" Font-Bold="true" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
        <button id="IPExt" onclick="obtenerIPExterna();return false;" type="button">
            Obtener IP de la red
        </button>
        <br />
        <br />
        <!--
        <asp:Panel ID="mapa" runat="server" Enabled="False">
            <div align="center">
                <div id="googleMap" onclick="return false;" style="width:620px; height:340px;"></div>
            </div>
        </asp:Panel>
            <br />
        <input type="checkbox" ID="modificar" OnClick="habilitar()"  /> Cambiar radio: <input id="radio" disabled="disabled" style="width:50px" type="text" value=""> metros.
            &nbsp;&nbsp;<button id="cambiar" disabled="disabled" onclick="cambiarRadio();return false;" type="button">Cambiar</button>
            <br />
            <br />
        <br />
        <asp:TextBox ID="Latitud" runat="server" ClientIDMode="Static" style="display:none;" type="text" />
        <asp:TextBox ID="Longitud" runat="server" ClientIDMode="Static" style="display:none;" type="text" />
        <asp:TextBox ID="Radio" runat="server" ClientIDMode="Static" style="display:none;" type="text" />-->
        <asp:TextBox ID="Sube" runat="server" ClientIDMode="Static" style="display:none;" type="text" />
</asp:Panel>
        <asp:Panel runat="server" HorizontalAlign="Center">
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Enabled="True" CausesValidation="False" OnClick="btnCancelar_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubir" runat="server" OnClick="btnSubir_Click"  Text="Subir Archivo" Enabled="true" CausesValidation="true" />
        </asp:Panel>
    &nbsp;
</asp:Content>

