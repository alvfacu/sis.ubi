<%@ Page Title="Alumnos por Comisión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaAlumnos.aspx.cs" Inherits="Web.Paginas.AsignarComisionAlumnos" %>

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

    <h2>Listado de Alumnos</h2>
    <br />
    <asp:Panel runat="server" HorizontalAlign="Center">
        <asp:Label runat="server" ID="Label8" Font-Bold="true">Comisión: </asp:Label>
        <asp:DropDownList runat="server" ID="comisiones" AutoPostBack="True" Font-Names="Arial" Height="29px" Width="285px" OnSelectedIndexChanged="comisiones_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <asp:GridView ID="GrillaPersonas" runat="server" AutoGenerateColumns="False" CellPadding="3" OnSelectedIndexChanged="GrillaPersonas_OnSelectedIndexChanged" DataKeyNames="Id" HorizontalAlign="Center" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" GridLines="Vertical">
            <Columns>            
                <asp:BoundField DataField="Id" HeaderText="ID Persona" Visible="false" />
                <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />       
                <asp:CommandField DeleteText="" InsertText="" NewText="" SelectText="Editar" ShowSelectButton="True" /> 
            </Columns>
            <AlternatingRowStyle BackColor="#DCDCDC" BorderColor="Black" />
            <EditRowStyle BorderColor="#FF66FF" BorderStyle="Ridge" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BorderColor="Black" BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BorderColor="Blue" BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
    </asp:Panel>
</asp:Content>
