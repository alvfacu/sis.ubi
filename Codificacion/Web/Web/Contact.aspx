<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Web.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
        <h2></h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Teléfono:</h3>
        </header>
        <p>
            <span class="label">Principal:</span>
            <span>0341-4480158</span>
        </p>
       <%-- <p>
            <span class="label">Fuera del horario laboral:</span>
            <span>425.555.0199</span>
        </p>--%>
    </section>

    <section class="contact">
        <header>
            <h3>Correo electrónico:</h3>
        </header>
       <%-- <p>
            <span class="label">Soporte técnico:</span>
            <span><a href="mailto:Support@example.com">Support@example.com</a></span>
        </p>
        <p>
            <span class="label">Marketing:</span>
            <span><a href="mailto:Marketing@example.com">Marketing@example.com</a></span>
        </p>--%>
        <p>
            <span class="label">General:</span>
            <span><a href="mailto:utnfrro@edu.com">utnfrro@edu.com</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Web:</h3>
        </header>
        <p>
            <span><a href="http://www.frro.utn.edu.ar">www.frro.utn.edu.ar</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Dirección:</h3>
        </header>
        <p>
            E. Zeballos 1341<br />
            Rosario, Santa Fe
        </p>
    </section>
</asp:Content>