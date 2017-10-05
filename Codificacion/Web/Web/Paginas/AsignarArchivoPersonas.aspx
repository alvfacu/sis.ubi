<%@ Page Title="Asignar Archivo" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AsignarArchivoPersonas.aspx.cs" Inherits="Web.Paginas.AsignarArchivoPersonas" %>
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
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black" Text="Carga de Archivos"></asp:Label>
    <br />
    <br />
<div id="contenedor-form">
     <asp:FileUpload ID="FileUpload1" runat="server" Width="484px" />
        <br /><br />
        <asp:Panel ID="Panel1" runat="server" GroupingText="Examen" Width="658px" Height="72px">
        <asp:Label ID="Label3" runat="server" Font-Bold="true">Fecha: </asp:Label>
        &nbsp;&nbsp;<asp:TextBox ID="TextBox1" name="ingreso" placeholder="Fecha Examen" required="" type="date" runat="server" Width="124px" />
            &nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="true">Inicio: </asp:Label>
            &nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server" name="ingreso" placeholder="Hora Inicio Examen" required="" type="time" Width="84px" />
            &nbsp;<asp:Label ID="Label5" runat="server" Font-Bold="true">Fin: </asp:Label>
            &nbsp;&nbsp;<asp:TextBox ID="TextBox3" runat="server" name="ingreso" placeholder="Hora Fin Examen" required="" type="time" Width="84px" />
            &nbsp;<br /><br />
        </asp:Panel>
        <br /><br />
        <asp:Button ID="btnSubir" runat="server" OnClick="btnSubir_Click" Text="Subir Archivo" /><br />
        <asp:Label ID="Label2" runat="server"></asp:Label></div>


    &nbsp;</div>
</asp:Content>
