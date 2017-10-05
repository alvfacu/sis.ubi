<%@ Page Title="Importar Personas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImportarPersonas.aspx.cs" Inherits="Web.Paginas.ImportarPersonas" %>

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
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black" Text="Carga de Archivos"></asp:Label>
    <br />
    <br />
    <div id="contenedor-form">
        <asp:Panel runat="server" GroupingText="Examen" Width="892px" Height="272px" HorizontalAlign="Center">
            <asp:Label runat="server" ID="subtitulo"><p style="font-size: small; font-weight: bold">Formatos aceptados: .xls o .xlsx<br />
            Las columnas deben seguir el siguiente orden: Nombre | Apellido | Legajo | Email </p></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" Width="484px" />&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Cargar" />
            <p><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="* Archivo requerido" Font-Bold="true" ForeColor="Red"/></p>
            
            <div align="center">
                <asp:GridView ID="gvExcelFile" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" ForeColor="Black">
                    <AlternatingRowStyle />
                    <EditRowStyle />
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                    <AlternatingRowStyle BackColor="#CCCCCC" BorderColor="Black" />
                    <EditRowStyle BorderColor="#FF66FF" BorderStyle="Ridge" />
                    <HeaderStyle BorderColor="Black" />
                    <RowStyle BorderColor="Blue" />
                </asp:GridView>
                <br />
                <p>
                    <asp:Label runat="server" ID="lblElija" Font-Bold="true" Visible="false"> Elija comisión: </asp:Label>
                    <asp:DropDownList runat="server" ID="comisiones" AutoPostBack="False" Font-Names="Arial" Height="25px" Width="250px" Visible="false"></asp:DropDownList>
                </p>
                <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" Visible="false" />&nbsp;&nbsp; <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Visible="false" OnClick="btnCancelar_Click" />
                <br />
                <br />
                
            </div>
        </asp:Panel>
    </div>
</asp:Content>
