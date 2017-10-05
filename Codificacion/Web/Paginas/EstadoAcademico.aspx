<%@ Page Title="Estado Academico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoAcademico.aspx.cs" Inherits="Web.Paginas.EstadoAcademico" %>
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
<%--            Bienvenidos al Sysacad--%>
        </p>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <%--    <asp:GridView ID="GVEstado" runat="server">
        <EditRowStyle BackColor="#0066FF" BorderColor="#CC66FF" />
        <HeaderStyle BackColor="#6666FF" BorderColor="Black" />
        <RowStyle BackColor="#FFFF99" BorderColor="Black" />
    </asp:GridView>--%>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black" Text="Estado Academico"></asp:Label>
<%--          <asp:Label ID="Label2" runat="server" Text="Materias a las que esta inscripto:" Font-Bold="True" Font-Size="Large"></asp:Label>--%>
    <asp:GridView ID="GVEstado" runat="server" OnSelectedIndexChanged="Grilla_SelectedIndexChanged" Width="487px" AutoGenerateColumns="False" DataKeyNames="IdInscripcion">
        <Columns>
            <%--<asp:BoundField DataField="Curso.IdCurso" HeaderText="IdCurso" />--%>
            <%--<asp:BoundField DataField="Persona.Id" HeaderText="IdAlumno" />--%>
            <asp:BoundField DataField="IdInscripcion" HeaderText="IdInscripcion" />
            <asp:BoundField DataField="Curso.Materia.DescripcionMateria" HeaderText="Materia" />
            <asp:BoundField DataField="Curso.Comision.DescripcionComision" HeaderText="Comisión" />
            <asp:BoundField DataField="Condicion" HeaderText="Condición" />
            <asp:CommandField ShowSelectButton="True" SelectText="Eliminar" />
        </Columns>
        <EditRowStyle BackColor="#0066FF" BorderColor="#FF66FF" BorderStyle="Solid" />
        <FooterStyle BackColor="#1C5E55" ForeColor="#333333" />
        <AlternatingRowStyle BackColor="White" />
        <HeaderStyle BackColor="#0066FF" BorderColor="Black" />
        <RowStyle BackColor="#99CCFF" BorderColor="Blue" />
    </asp:GridView>
    <br />
    <br />
    <asp:Label ID="LblError" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Red" Text="No se puede eliminar. El curso ya esta cerrado!!" Visible="False"></asp:Label>
</asp:Content>
