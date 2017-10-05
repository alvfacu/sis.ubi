<%@ Page Title="Archivos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Archivos.aspx.cs" Inherits="Web.Paginas.Archivos" %>

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
    <asp:Button ID="lbCargarArchivo" runat="server" Font-Bold="True" Font-Size="Large" Text="Cargar Archivo" OnClick="lbCargarArchivo_Click" />
    <%--<asp:Button ID="lbAsignarArchivo" runat="server" Font-Bold="True" Font-Size="Large" Text="Asignar Archivo a Alumnos" OnClick="lbAsignarArchivo_Click" />--%>
    <asp:Button ID="lbListadoArchivos" runat="server" Font-Bold="True" Font-Size="Large" Text="Listado de Archivos" OnClick="lbListadoArchivos_Click" />
</asp:Content>
