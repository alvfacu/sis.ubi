<%@ Page Title="ABM Comisiones" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="ABMComisiones.aspx.cs" Inherits="Web.Paginas.ABMComisiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured" style="border-color: 7ac0da; background-color: #7ac0da;">
        <div class="content-wrapper" style="border-color: 7ac0da; background-color: #7ac0da;">
            <hgroup class="title">
                <h1>SIS.UBI - Sistema Ubicuo</h1>
                <h2></h2>
            </hgroup>
            <p>
<%--                Bienvenidos al Sysacad--%>
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black" Text="Comisiones"></asp:Label>
    <br />    
    <br />
    <asp:Panel runat="server" HorizontalAlign="Center">
        <asp:Label runat="server" ID="Label2" Font-Bold="true">Seleccione una materia: </asp:Label>
        <asp:DropDownList runat="server" ID="materias" AutoPostBack="True"  Font-Names="Arial" Height="25px" Width="180px" OnSelectedIndexChanged="materias_SelectedIndexChanged"></asp:DropDownList>
    </asp:Panel>    
    <br /> 
    <asp:Panel runat="server" ID="panelListado" HorizontalAlign="Center">
    <asp:GridView ID="GrillaComisiones" runat="server" AutoGenerateColumns="False" CellPadding="3" HorizontalAlign="Center" OnRowCommand="GrillaComisiones_RowCommand" OnRowDeleting="GrillaComisiones_RowDeleting" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" GridLines="Vertical">
        <Columns>            
            <asp:BoundField DataField="DescripcionComision" HeaderText="Comisiones" />
            <asp:CommandField ButtonType="Button" SelectText="Editar" ShowSelectButton="True" />
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
    <asp:Button ID="btnNuevaComision" runat="server" Text="Agregar Comisión" Width="163px" OnClick="btnNuevaComision_Click"/>
    </asp:Panel>  
    <asp:Panel runat="server" HorizontalAlign="Center" ID="panelNuevaComision" Visible="false">
        <br />
            <asp:Label runat="server" ID="Label3" Font-Bold="true">Comisión: </asp:Label>
            <asp:TextBox runat="server" ID="nombreComisionNueva" Font-Names="Arial" placeholder="Comisión" Width="250px"></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="nombreComisionNueva" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;

            <asp:Label runat="server" ID="Label4" Font-Bold="true">Año: </asp:Label>
            <asp:TextBox runat="server" ID="txtAnio" Font-Names="Arial" placeholder="Año Lectivo" Width="92px"></asp:TextBox>
            <asp:RequiredFieldValidator id="RFV1" runat="server" ControlToValidate="txtAnio" Display="Dynamic" Text="*" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="REV1" Text="* Solo se admiten números " ForeColor="Red" Font-Bold="true" ControlToValidate="txtAnio" Runat="server" Display="Dynamic" ValidationExpression="\d+"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtAnio" ID="LongitudMinima" ValidationExpression ="^[\s\S]{4,8}$" runat="server" ErrorMessage="* Entre 4 a 8 digitos" Font-Bold="true" ForeColor="Red"></asp:RegularExpressionValidator>
        <br />
        <br />
            <asp:Button ID="btnAgregarComision" runat="server" Text="Agregar" Width="163px" OnClick="btnAgregarComision_Click"/>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="163px" OnClick="btnCancelar_Click" CausesValidation="false" />
    </asp:Panel>
</asp:Content>