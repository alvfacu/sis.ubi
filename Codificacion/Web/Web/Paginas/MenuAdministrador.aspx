<%@ Page Title="Menu Administrador" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuAdministrador.aspx.cs" Inherits="Web.Paginas.MenuAdministrador" %>

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
    <br />
    <br />    
    <asp:Button ID="btnMaterias" runat="server" Font-Bold="True" Font-Size="Large" Text="Materias" OnClick="btnMaterias_Click"/>
    <asp:Button ID="btnComisiones" runat="server" Font-Bold="True" Font-Size="Large" Text="Comisiones" OnClick="btnComisiones_Click"/>
    <asp:Button ID="lbAgregarPersona" runat="server" Font-Bold="True" Font-Size="Large" Text="Alumnos" OnClick="lbAgregarPersona_Click" />
    <asp:Button ID="btnArchivos" runat="server" Font-Bold="True" Font-Size="Large" Text="Archivos" OnClick="btnArchivos_Click"/>
    <%--<asp:Button ID="lbListadoAlumnos" runat="server" Font-Bold="True" Font-Size="Large" Text="Listado de Alumnos por Comision" OnClick="lbListadoAlumnos_Click"/>--%>
</asp:Content>
