<%@ Page Title="Alumnos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alumnos.aspx.cs" Inherits="Web.Paginas.AgregarPersonas" %>

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
    <asp:Button ID="lbListadoPersonas" runat="server" OnClick="lbListadoPersonas_Click" Font-Bold="True" Font-Size="Large" Text="Inscripciones"/>
    <asp:Button ID="lbAgregarPersona" runat="server" OnClick="lbAgregarPersona_Click" Font-Bold="True" Font-Size="Large" Text="Agregar Un Alumno"/>
    <asp:Button ID="lbAlumnosComision" runat="server" OnClick="lbAlumnosComision_Click" Font-Bold="true" Font-Size="Large" Text="Listado Alumnos por Comisión" />
    <asp:Button ID="lbImportarPersonas" runat="server" OnClick="lbImportarPersonas_Click" Font-Bold="True" Font-Size="Large" Text="Importar Alumnos"/>
    
</asp:Content>
