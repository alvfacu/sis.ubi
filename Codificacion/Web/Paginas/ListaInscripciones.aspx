<%@ Page Title="Listado de Inscripciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaInscripciones.aspx.cs" Inherits="Web.Paginas.ListaAlumnos" %>

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
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black" Text="Listado de Inscripciones"></asp:Label>
    <br /> 
    <asp:Panel runat="server" HorizontalAlign="Center">
        <asp:Label runat="server" ID="Label8" Font-Bold="true">Comisión: </asp:Label>
        <asp:DropDownList runat="server" ID="comisiones" AutoPostBack="True"  Font-Names="Arial" Height="29px" Width="285px" OnSelectedIndexChanged="comisiones_SelectedIndexChanged"></asp:DropDownList>
    </asp:Panel>
    <br />
    <asp:Panel runat="server" HorizontalAlign="Center">
        <table>
            <tr><td>
            <asp:GridView ID="grdPersonas" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" 
                OnRowCancelingEdit="grdPersonas_RowCancelingEdit" 
                OnRowEditing="grdPersonas_RowEditing" 
                OnRowUpdating="grdPersonas_RowUpdating" 
                OnRowCommand="grdPersonas_RowCommand" 
                ShowFooter="True" 
                OnRowDeleting="grdPersonas_RowDeleting" Font-Size="Small" HorizontalAlign="Center" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical"> 
                <AlternatingRowStyle BackColor="#DCDCDC" />
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
                        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="lblLegajo" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator> 
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
                        <%-- <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="lblNombre" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator> --%>
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
                        <%-- <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="lblApellido" Display="Dynamic" Text="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator> --%>
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
                        <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="False" CommandName="Update" Text="Guardar"></asp:LinkButton> 
                        <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton> 
                    </EditItemTemplate> 
                    <FooterTemplate> 
                        <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="True" CommandName="Insert" Text="Agregar"></asp:LinkButton> 
                    </FooterTemplate> 
                    <ItemTemplate> 
                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                    </ItemTemplate>                
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
                <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" ShowHeader="True" />
            </Columns> 
                <FooterStyle Font-Size="Small" BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle HorizontalAlign="Center" BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView> 
            </td></tr>
        </table> 
    </asp:Panel>

</asp:Content>
