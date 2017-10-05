<%@ Page Title="Notas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaNotas.aspx.cs" Inherits="Web.Paginas.ListaNotas" %>

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
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black" Text="Listado de Notas"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="GrillaNotas" runat="server" AutoGenerateColumns="False" CellPadding="3" HorizontalAlign="Center" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="524px" GridLines="Vertical">
    <Columns>            
        <asp:BoundField DataField="Descripcion" HeaderText="Comisión" HeaderStyle-Width="400" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
            <FooterStyle HorizontalAlign="Center"></FooterStyle>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="NotaP1" HeaderText="P1" HeaderStyle-Width="100" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
            <FooterStyle HorizontalAlign="Center"></FooterStyle>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="NotaP2" HeaderText="P2" HeaderStyle-Width="100" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
            <FooterStyle HorizontalAlign="Center"></FooterStyle>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="NotaR1" HeaderText="R1" HeaderStyle-Width="100" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
            <FooterStyle HorizontalAlign="Center"></FooterStyle>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="NotaR2" HeaderText="R2" HeaderStyle-Width="100" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
            <FooterStyle HorizontalAlign="Center"></FooterStyle>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:BoundField>
    </Columns>
    <AlternatingRowStyle BorderColor="Black" BackColor="#DCDCDC" />
    <EditRowStyle BorderColor="#FF66FF" BorderStyle="Ridge" HorizontalAlign="Center"/>
    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center" />
    <HeaderStyle BorderColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#000084" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    <RowStyle BorderColor="Blue" HorizontalAlign="Center" ForeColor="Black" BackColor="#EEEEEE" />
    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F1F1F1" />
    <SortedAscendingHeaderStyle BackColor="#0000A9" />
    <SortedDescendingCellStyle BackColor="#CAC9C9" />
    <SortedDescendingHeaderStyle BackColor="#000065" />
</asp:GridView>
</asp:Content>
