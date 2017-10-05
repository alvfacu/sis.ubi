<%@ Page Title="ABM Materias" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ABMMaterias.aspx.cs" Inherits="Web.Paginas.ABMMaterias" %>

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
    <asp:Panel runat="server" ID="panelListado" HorizontalAlign="Center">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black" Text="Listado de Materias"></asp:Label>
        <asp:GridView ID="GrillaMaterias" runat="server" AutoGenerateColumns="False" CellPadding="3" HorizontalAlign="Center" OnRowCommand="GrillaMaterias_RowCommand" OnRowEditing="GrillaMaterias_RowEditing" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" GridLines="Vertical">
            <Columns>            
                <asp:BoundField DataField="DescripcionMateria" HeaderText="Materias" />
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Comisiones" />
                <asp:CommandField ButtonType="Button" SelectText="Editar" ShowEditButton="true" />
                <asp:CommandField ButtonType="Button" SelectText="Eliminar" ShowDeleteButton="True" />
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
        <asp:Button ID="btnNuevo" runat="server" Text="Cargar nueva" Width="163px" OnClick="btnNuevo_Click"/>
    </asp:Panel>
    <asp:Panel runat="server" ID="panelNuevo" HorizontalAlign="Center" Visible="false">
        <br />
        <asp:Label runat="server" ID="Label7" Font-Bold="true">Nombre materia: </asp:Label>
        <asp:TextBox runat="server" ID="nombreMateria" Font-Names="Arial" placeholder="Ingrese nombre de la materia" Width="203px"></asp:TextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="nombreMateria" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btnGuardarNuevo" runat="server" Text="Agregar Materia" Width="163px" OnClick="btnGuardarNuevo_Click"/>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="163px" OnClick="btnCancelar_Click" CausesValidation="False" />
    </asp:Panel>
</asp:Content>
