<%@ Page Title="Menu Alumno" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuAlumno.aspx.cs" Inherits="Web.Paginas.Menu" %>

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
    <asp:Button ID="lblModificarDatos" runat="server" Font-Bold="True" Font-Size="Large" Text="Datos de usuario" OnClick="lblModificarDatos_Click"/>
    <asp:Button ID="lblVerArchivos" runat="server" Font-Bold="True" Font-Size="Large" Text="Archivos asignados" OnClick="lblVerArchivos_Click"/>
    <asp:Button ID="lblNotas" runat="server" Font-Bold="True" Font-Size="Large" Text="Notas parciales" OnClick="lblNotas_Click"/>   
</asp:Content>
