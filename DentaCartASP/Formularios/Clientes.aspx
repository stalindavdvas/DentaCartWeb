<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/InicioCuenta.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="DentaCartASP.Formularios.Clientes1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
        <div>
            <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="false" OnRowCommand="gvClientes_RowCommand" CssClass="table table-striped table-responsive">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" ReadOnly="True" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                    <asp:BoundField DataField="dni" HeaderText="DNI" SortExpression="dni" />
                    <asp:BoundField DataField="dir" HeaderText="Dirección" SortExpression="dir" />
                    <asp:BoundField DataField="correo" HeaderText="Correo" SortExpression="correo" />
                    <asp:BoundField DataField="telefono" HeaderText="Teléfono" SortExpression="telefono" />
                    <asp:TemplateField HeaderText="Acciones" ItemStyle-Wrap="false">
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-sm btn-warning" OnClick="btnEditar_Click"/>
                            <asp:Button ID="btnEliminar" runat="server" Text="Borrar" CssClass="btn btn-sm btn-danger"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                </Columns>
            </asp:GridView>
        </div>
    
</asp:Content>
