<%@ Page Title="Listado Personas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoPersonas.aspx.cs" Inherits="Web.Paginas.ListaPersonas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Universidad Tecnológica Nacional Facultad Regional Rosario</h1>
                <h2></h2>
            </hgroup>
            <p>
<%--                Bienvenidos al Sysacad--%>
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Listado de Alumnos</h2>
    <br /> 
    <asp:Label runat="server" ID="Label8" Font-Bold="true">Comisión: </asp:Label>
    <asp:DropDownList runat="server" ID="comisiones" AutoPostBack="True"  Font-Names="Arial" Height="29px" Width="285px" OnSelectedIndexChanged="comisiones_SelectedIndexChanged"></asp:DropDownList>
    <br />
    <table>
        <tr><td>
        <asp:GridView ID="grdPersonas" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" 
            OnRowCancelingEdit="grdPersonas_RowCancelingEdit" 
            OnRowEditing="grdPersonas_RowEditing" 
            OnRowUpdating="grdPersonas_RowUpdating" 
            OnRowCommand="grdPersonas_RowCommand" 
            ShowFooter="True" 
            OnRowDeleting="grdPersonas_RowDeleting" Font-Size="Small"> 
        <Columns> 
            <asp:TemplateField HeaderText="ID" Visible="false"  HeaderStyle-HorizontalAlign="Center"> 
                <EditItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label> 
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Legajo" HeaderStyle-HorizontalAlign="Center"> 
                <EditItemTemplate> 
                    <asp:Label ID="lblLegajo" runat="server" Text='<%# Bind("Legajo") %>' Width="70"></asp:Label> 
                </EditItemTemplate> 
                <FooterTemplate>
                    <asp:TextBox ID="lblLegajo" runat="server" Width="70" ></asp:TextBox> 
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblLegajo" runat="server" Width="70" Text='<%# Bind("Legajo") %>'></asp:Label> 
                </ItemTemplate> 
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre" HeaderStyle-HorizontalAlign="Center"> 
                <EditItemTemplate> 
                    <asp:Label ID="lblNombre" Width="70" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox Width="70" ID="lblNombre" runat="server" ></asp:TextBox> 
                </FooterTemplate>
                <ItemTemplate> 
                    <asp:Label ID="lblNombre" Width="70" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label> 
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Apellido" HeaderStyle-HorizontalAlign="Center"> 
                <EditItemTemplate> 
                    <asp:Label ID="lblApellido" Width="70" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox ID="lblApellido" Width="70" runat="server" ></asp:TextBox> 
                </FooterTemplate>
                <ItemTemplate> 
                    <asp:Label ID="lblApellido" Width="70" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label> 
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField>  </asp:TemplateField>
            <asp:TemplateField HeaderText="Parcial 1" HeaderStyle-HorizontalAlign="Center"> 
                <EditItemTemplate> 
                    <asp:TextBox ID="txtNotaP1" runat="server" Text='<%# Bind("NotaP1") %>' Width="50"></asp:TextBox><asp:RegularExpressionValidator ID="validarP1" runat="server" ControlToValidate="txtNotaP1" Font-Bold="true" ForeColor="Red" ErrorMessage="*"
                            ValidationExpression="(?:\d*(\,|\.))?\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox ID="txtNotaP1" runat="server" Width="50" ></asp:TextBox><asp:RegularExpressionValidator ID="validarP11" runat="server" ControlToValidate="txtNotaP1" Font-Bold="true" ForeColor="Red" ErrorMessage="*"
                            ValidationExpression="(?:\d*(\,|\.))?\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblNotaP1" runat="server" Width="50" Text='<%# Bind("NotaP1") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField>  </asp:TemplateField>
            <asp:TemplateField HeaderText="Parcial 2" HeaderStyle-HorizontalAlign="Center"> 
                <EditItemTemplate> 
                    <asp:TextBox ID="txtNotaP2" runat="server" Width="50" Text='<%# Bind("NotaP2") %>'></asp:TextBox><asp:RegularExpressionValidator ID="validarP2" runat="server" ControlToValidate="txtNotaP2" Font-Bold="true" ForeColor="Red" ErrorMessage="*"
                            ValidationExpression="(?:\d*(\,|\.))?\d+" Display="Dynamic"></asp:RegularExpressionValidator> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox ID="txtNotaP2" runat="server" Width="50" ></asp:TextBox><asp:RegularExpressionValidator ID="validarP22" runat="server" ControlToValidate="txtNotaP2" Font-Bold="true" ForeColor="Red" ErrorMessage="*"
                            ValidationExpression="(?:\d*(\,|\.))?\d+" Display="Dynamic"></asp:RegularExpressionValidator>  
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblNotaP2" runat="server" Text='<%# Bind("NotaP2") %>' Width="50"></asp:Label> 
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField>  </asp:TemplateField>
            <asp:TemplateField HeaderText="Recup P1" HeaderStyle-HorizontalAlign="Center"> 
                <EditItemTemplate> 
                    <asp:TextBox ID="txtNotaR1" runat="server" Width="50" Text='<%# Bind("NotaR1") %>'></asp:TextBox><asp:RegularExpressionValidator ID="validarR1" runat="server" ControlToValidate="txtNotaR1" Font-Bold="true" ForeColor="Red" ErrorMessage="*"
                            ValidationExpression="(?:\d*(\,|\.))?\d+" Display="Dynamic"></asp:RegularExpressionValidator>  
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox ID="txtNotaR1" runat="server" Width="50"></asp:TextBox><asp:RegularExpressionValidator ID="validarR12" runat="server" ControlToValidate="txtNotaR1" Font-Bold="true" ForeColor="Red" ErrorMessage="*"
                            ValidationExpression="(?:\d*(\,|\.))?\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblNotaR1" runat="server" Width="50" Text='<%# Bind("NotaR1") %>'></asp:Label> 
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField>  </asp:TemplateField>
            <asp:TemplateField HeaderText="Recup P2" HeaderStyle-HorizontalAlign="Center"> 
                <EditItemTemplate> 
                    <asp:TextBox ID="txtNotaR2" runat="server" Width="50" Text='<%# Bind("NotaR2") %>'></asp:TextBox><asp:RegularExpressionValidator ID="validarR2" runat="server" ControlToValidate="txtNotaR2" Font-Bold="true" ForeColor="Red" ErrorMessage="*"
                            ValidationExpression="(?:\d*(\,|\.))?\d+" Display="Dynamic"></asp:RegularExpressionValidator> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:TextBox ID="txtNotaR2" runat="server" Width="50"></asp:TextBox><asp:RegularExpressionValidator ID="validarR22" runat="server" ControlToValidate="txtNotaR2" Font-Bold="true" ForeColor="Red" ErrorMessage="*"
                            ValidationExpression="(?:\d*(\,|\.))?\d+" Display="Dynamic"></asp:RegularExpressionValidator>
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:Label ID="lblNotaR2" runat="server" Width="50" Text='<%# Bind("NotaR2") %>'></asp:Label> 
                </ItemTemplate> 
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>  
            <asp:TemplateField>  </asp:TemplateField>          
            <asp:TemplateField HeaderText="Opciones" ShowHeader="False" HeaderStyle-HorizontalAlign="Center"> 
                <EditItemTemplate> 
                    <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Guardar"></asp:LinkButton> 
                    <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="False" CommandName="Insert" Text="Agregar"></asp:LinkButton> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                </ItemTemplate>                
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:TemplateField>
            <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" ShowHeader="True" />
        </Columns> 
            <FooterStyle Font-Size="Small" />
        </asp:GridView> 
        </td></tr>
    </table> 


</asp:Content>
