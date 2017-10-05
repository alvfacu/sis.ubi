<%@ Page Title="SIS.UBI - Sistema Ubicuo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2></h2>
            </hgroup>
            <p>
                <%--Bienvenidos al Sysacad--%>
                <%--Para obtener más información sobre ASP.NET, visite <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                La página incluye <mark>vídeos, cursos y ejemplos</mark> para ayudarle a sacar el máximo partido a ASP.NET.
                Si tiene alguna pregunta relacionada con ASP.NET, visite
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">nuestros foros</a>.--%>
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>SIS.UBI - Sistema Ubicuo</h1>
        <h2></h2>
    </hgroup>

    <article>
        <p>
            Integrantes:
        </p>

        <p>
            <t>
            - Alvarez, Facundo 
            </t>
            <br />
            - Ranalli, Gonzalo
        </p>
    </article>

</asp:Content>
<%--<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3><img alt="" src="Images/logoUTN_grande.png" style="height: 108px; width: 190px" /></h3>
    <ol class="round">
       < <li class="one">
            <h5>Introducción</h5>
            Los formularios Web Forms de ASP.NET permiten crear sitios web dinámicos mediante modelos basados en eventos y de arrastrar y colocar.
            La superficie de diseño y los cientos de controles y componentes permiten crear rápidamente sitios sofisticados y controlados mediante UI con acceso de datos.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245146">Más información…</a>
        </li>
        
       
    </ol>
</asp:Content>--%>
