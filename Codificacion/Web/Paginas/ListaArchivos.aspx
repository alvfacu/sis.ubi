<%@ Page Title="Lista Archivos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaArchivos.aspx.cs" Inherits="Web.Paginas.ListaArchivos" %>

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
        var radio;
        var map;
        var myCenter = new google.maps.LatLng(-32.9545095, -60.6437689);
        var gmarkers = [];
        var circles = [];

        function initialize() {
            var mapProp = new google.maps.Marker({});
            map = new google.maps.Map(document.getElementById("googleMap"), {
                zoom: 13,
                center: myCenter
            });

            if (document.getElementById("Latitud").value != "") {
                document.getElementById("btnMostrar").click();
            }

            google.maps.event.addListener(map, 'click', function (event) {
                placeMarker(event.latLng);
            });

        }

        google.maps.event.addDomListener(window, 'load', initialize);
        function ubicar() {

            var latitud = parseFloat(document.getElementById("Latitud").value);
            var longitud = parseFloat(document.getElementById("Longitud").value);
            var ra = parseFloat(document.getElementById("Radio").value);
            radio = ra;

            var myLatLng = { lat: latitud, lng: longitud };

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
                            radius: ra,
                            fillColor: '#23ee11'
                        });
                        circle.bindTo('center', marker, 'position');
                        circles.push(circle);
                        infowindow.setContent("<b>" + results[0].formatted_address);
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

        }

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
                        infowindow.setContent("<b>" + results[0].formatted_address);
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


        function cambiarRadio() {
            radio = parseInt(document.getElementById('<%= rad.ClientID %>').value);
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

        function obtenerIPExterna()
        {
            document.getElementById('<%= ip.ClientID %>').value = "";
            document.getElementById('<%= ip.ClientID %>').value = myip;
        }
        
    </script>
    </header>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black" Text="Listado de Archivos"></asp:Label>
    <asp:GridView ID="GrillaArchivos" runat="server" AutoGenerateColumns="False" CellPadding="3" OnSelectedIndexChanged="GrillaArchivos_SelectedIndexChanged" HorizontalAlign="Center" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" GridLines="Vertical">
        <Columns>            
            <asp:BoundField DataField="DescripcionTipo" HeaderText="Tipo" />
            <asp:BoundField DataField="NombreArchivo" HeaderText="Archivo" />
            <asp:BoundField DataField="FechaHoraInicio" HeaderText="Fecha" DataFormatString="{0:d}" />
            <asp:BoundField DataField="FechaHoraInicio" HeaderText="Hora Inicio" DataFormatString="{0:t}"/>
            <asp:BoundField DataField="FechaHoraFin" HeaderText="Hora Fin" DataFormatString="{0:t}" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"/>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Ver mas" />
        </Columns>
        <AlternatingRowStyle BackColor="#DCDCDC" BorderColor="Black" />
        <EditRowStyle BorderColor="#FF66FF" BorderStyle="Ridge" />
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BorderColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BorderColor="Blue" HorizontalAlign="Center" BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>

    <asp:Panel runat="server" HorizontalAlign="Center"> <asp:Button ID="btnNuevo" runat="server" Text="Cargar nuevo" Width="163px" OnClick="btnNuevo_Click"/> </asp:Panel>
    
    <asp:Panel runat="server" ID="panelEdicion" HorizontalAlign="Center" Visible="false">
        <br />
        <br />
        <asp:Label runat="server" ID="Label7" Font-Bold="true"> Comisión: </asp:Label>
        <asp:DropDownList runat="server" ID="comisiones" AutoPostBack="False" Font-Names="Arial" Height="25px" Width="250px"></asp:DropDownList>
        <br />
        <asp:Label runat="server" ID="LabelMateria" Font-Bold="true">Descripción: </asp:Label>
        <asp:TextBox ID="descripcion" runat="server" Font-Names="Arial" type="text" Width="350px" ToolTip="Ej.: Materia / Lugar referencia"></asp:TextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="descripcion" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label3" runat="server" Font-Bold="true">Fecha: </asp:Label>
        <asp:TextBox ID="fecha" name="ingreso" placeholder="Fecha Examen" type="date" runat="server" Width="170px" Font-Names="Arial"/>
        <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="fecha" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator> 
        <br />
        <asp:Label runat="server" ID="Label2" Font-Bold="true">Hora Inicio: </asp:Label>
        <asp:TextBox ID="inicio" runat="server" name="ingreso" placeholder="Hora Inicio Examen" type="time" Width="130px" TextMode="Time" Font-Names="Arial" />
        <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="inicio" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator> 
        <asp:Label runat="server" ID="Label5" Font-Bold="true">Hora Fin: </asp:Label> 
        <asp:TextBox ID="fin" runat="server" name="ingreso" placeholder="Hora Fin Examen" type="time" Width="130px" TextMode="Time" Font-Names="Arial" />
        <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="fin" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator> 
        <br />
        <asp:Label ID="Label6" runat="server" Font-Bold="true">IP: </asp:Label>
        <asp:TextBox ID="ip" runat="server" name="ingre" placeholder="Ingrese un número de IP" type="text" Width="160px" Font-Names="Arial"/>
        <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ControlToValidate="ip" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator> 
        <button id="IPExt" onclick="obtenerIPExterna();return false;" type="button">Obtener IP de la red</button>
        <br />
        
        <div align="center">
           <!--<button id="btnMostrar" onclick="ubicar();return false;" style="display:none"></button>
           <br />
           <div id="googleMap" style="width:500px;height:380px;"></div>
           <asp:Label ID="Label4" runat="server" Font-Bold="true">Radio: </asp:Label> <asp:TextBox ID="rad" runat="server" type="text" Width="50px" Font-Names="Arial"/>metros.&nbsp;&nbsp;&nbsp;&nbsp;<button type="button" ID="cambiar" OnClick="cambiarRadio();return false;">Cambiar</button>
           <asp:TextBox ID="Latitud" type="text" runat="server" ClientIDMode="Static" style="display:none;" />
           <asp:TextBox ID="Longitud" type="text" runat="server" ClientIDMode="Static" style="display:none;" />
           <asp:TextBox ID="Radio" type="text" runat="server" ClientIDMode="Static" style="display:none;" />
           <br />
           <br />-->
           <asp:Button ID="btnEditar" runat="server" Text="Guardar" Width="100px" CausesValidation="true" OnClick="btnEditar_Click" /> &nbsp; <asp:Button ID="btnElminar" runat="server" Text="Eliminar" Width="100px" OnClick="btnElminar_Click" CausesValidation="false" /> &nbsp; <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="false" OnClick="btnCancelar_Click" Width="100px" />  
           <br />
           <br />
         </div>
        
    </asp:Panel>
</asp:Content>
