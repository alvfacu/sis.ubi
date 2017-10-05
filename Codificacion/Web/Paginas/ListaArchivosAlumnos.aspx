<%@ Page Title="Lista Archivos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaArchivosAlumnos.aspx.cs" Inherits="Web.Paginas.ListaArchivosAlumnos" %>

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
    </header>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black" Text="Listado de Archivos asignados"></asp:Label>
    <br />
    <br />
    <asp:Panel runat="server" HorizontalAlign="Center">
        <asp:Label runat="server" ID="Label8" Font-Bold="true">Ver: </asp:Label>
        <asp:DropDownList runat="server" ID="opciones" AutoPostBack="True"  Font-Names="Arial" Height="25px" Width="180px" OnSelectedIndexChanged="opciones_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <asp:GridView ID="GrillaArchivos" runat="server" AutoGenerateColumns="False" CellPadding="3" HorizontalAlign="Center" Visible="False" OnRowCommand="GrillaArchivos_RowCommand" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" GridLines="Vertical" >
        <Columns>            
            <asp:BoundField DataField="DescripcionTipo" HeaderText="Tipo" />
            <asp:BoundField DataField="NombreArchivo" HeaderText="Nombre Archivo" />
            <asp:BoundField DataField="FechaArchivo" HeaderText="Fecha" DataFormatString="{0:d}" />
            <asp:BoundField DataField="FechaHoraInicio" HeaderText="Hora Inicio" DataFormatString="{0:t}"/>
            <asp:BoundField DataField="FechaHoraFin" HeaderText="Hora Fin" DataFormatString="{0:t}" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"/>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Ver/Descargar" />
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
    </asp:Panel>   
    <asp:Panel runat="server" HorizontalAlign="Center" ID="listado" Visible="false">
        
    </asp:Panel>

</asp:Content>
