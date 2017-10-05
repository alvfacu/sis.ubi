<%@ Page Title="Inscripcion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagInscribirse.aspx.cs" Inherits="Web.Paginas.PagInscribirse" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
     <section class="featured">
        <div class="content-wrapper">
        <hgroup class="title">
            <h1>Universidad Tecnológica Nacional - Facultad Regional Rosario</h1>
            <h2></h2>
        </hgroup>
        <p>
<!--            Bienvenidos al Sysacad-->
        </p>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <table border="0" cellspacing="0" cellpadding="1"> 
        <tr bgcolor="#990033" align="center"> 
        <td></td> 
        </tr> 
        <tr bgcolor="#990033"> 
        <td> 
        <table width="100%" border="0" cellspacing="0" cellpadding="4"> 
        <tr bgcolor="#FFFFFF"> 
        <td>
            <asp:Label ID="LblTitulo" runat="server" Text="Usted se ha inscripto a: " Font-Bold="True" Font-Size="Medium" Font-Underline="True"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="LblComision" runat="server" Text="Comisión:"></asp:Label>
&nbsp;<asp:Label ID="LblCom" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="LblMateria" runat="server" Text="Materia:"></asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="LblMat" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Codigo de inscripcion:"></asp:Label>
&nbsp;<asp:Label ID="LblCodInsc" runat="server"></asp:Label>
            <br />
            </td> 
        </tr> 
        </table> 
        </td> 
        </tr> 
</table> 
    <br />
    <br />
    <br />
</asp:Content>
