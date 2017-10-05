<%@ Page Title="Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Web.Paginas.Error" %>
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
    <asp:Label ID="LblError" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Red"></asp:Label>
</asp:Content>
