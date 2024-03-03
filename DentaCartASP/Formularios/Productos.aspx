<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/InicioCuenta.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="DentaCartASP.Formularios.Productos1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
      <div class="row">
          <div class="col">
              <h4>Formulario de Proveedores</h4><div id="alertaProveedores"> <asp:Literal ID="ltlAlertaProductos" runat="server"></asp:Literal></div>
              <div class="row">
                  <div class="row p-2">
                      <div class="col-md-12">
                          <label for="txtId" class="form-label">ID:</label>
                          <asp:TextBox ID="txtId" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                      </div>
                      <div class="col-md-6">
                          <label for="txtNombre" class="form-label">Nombre:</label>
                          <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"  required="true"></asp:TextBox>
                      </div>
                      <div class="col-md-6">
                          <label for="inputDni" class="form-label">Cantidad:</label>
                          <asp:TextBox ID="txtCant" CssClass="form-control" runat="server" MaxLength="13" onkeypress="return soloNumeros(event);" required="true"></asp:TextBox>
                      </div>
                      <div class="col-md-6">
                          <label for="txtTelefono" class="form-label">Precio</label>
                          <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" onkeypress="return soloNumerosDecimal(event);" MaxLength="10" required="true"></asp:TextBox>
                      </div>
                      <div class="col-md-6">
                          <label for="txtCodProv" class="form-label">Cod Prov</label>
                          <asp:TextBox ID="txtCodProv" CssClass="form-control" runat="server" ReadOnly="true" ></asp:TextBox>
                      </div>
                      <div class="col-md-12">
                           <label for="inputTipo" class="form-label">Tipo Usuario:</label>
                              <asp:DropDownList ID="cmbProveedor" runat="server" CssClass="form-select" required="true" UseSubmitBehavior="false">
                                  
                              </asp:DropDownList>
                      </div>
                  </div>
              </div>
          </div>
      </div>
      <div class="col-md-12">
          <div class="row" style="padding: 10px;">
              <div class="col border text-center">
                  <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary" UseSubmitBehavior="false" OnClick="btnNuevo_Click" />

              </div>
              <div class="col border text-center">
                  <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" UseSubmitBehavior="false" OnClick="btnGuardar_Click" />
              </div>
              <div class="col border text-center">
                  <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" UseSubmitBehavior="false" OnClick="btnCancelar_Click"/>
              </div>
              <div class="col border text-center">
                  <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-danger" UseSubmitBehavior="false" OnClick="btnActualizar_Click"/>
              </div>
          </div>
      </div>
      <div class="row p-2">
          <div class="col">
              <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-responsive" OnRowCommand="gvClientes_RowCommand1" DataKeyNames="id" OnRowDataBound="gvClientes_RowDataBound">
                  <Columns>
                      <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" ReadOnly="True" />
                      <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                      <asp:BoundField DataField="cant" HeaderText="Cantidad" SortExpression="can" />
                      <asp:BoundField DataField="precio" HeaderText="Precio" SortExpression="precio" />
                      <asp:BoundField DataField="idprov" HeaderText="CodProveedor" SortExpression="idprov" />
                      <asp:BoundField DataField="nombreprov" HeaderText="Proveedor" SortExpression="nombreprov" />
                      <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar">
                          <ControlStyle CssClass="btn btn-warning" />
                      </asp:ButtonField>
                      <asp:ButtonField ButtonType="Button" CommandName="Eliminar" Text="Eliminar">
                          <ControlStyle CssClass="btn btn-danger" />
                      </asp:ButtonField>
                  </Columns>
                   <HeaderStyle CssClass="thead-dark" />
              </asp:GridView>
          </div>
      </div>
  </div>
    <!-- Modal Borrar-->
<div class="modal fade" id="modalBorrar" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h1 class="modal-title fs-5" id="exampleModalLabel">Estas Seguro de Eliminar al Registro:</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="container">
                    <div class="row">
                        <div class="col">
                            <asp:Label ID="Label1" runat="server" Text="ID:"></asp:Label>
                        </div>
                        <div class="col">
                            <asp:TextBox ID="txtIdM" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:Label ID="Label9" runat="server" Text="Nombre:"></asp:Label>
                        </div>
                        <div class="col">
                            <asp:TextBox ID="txtNombreM" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:Label ID="Label10" runat="server" Text="Dni:"></asp:Label>
                        </div>
                        <div class="col">
                            <asp:TextBox ID="txtCanM" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:Label ID="Label11" runat="server" Text="Direccion:"></asp:Label>
                        </div>
                        <div class="col">
                            <asp:TextBox ID="txtPrecioM" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
               
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                <asp:Button ID="btnEliminar" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="btnEliminar_Click1" />
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function soloLetras(e) {
        var keyCode = e.which || e.keyCode;
        var tecla = String.fromCharCode(keyCode);

        // Solo permitir letras y espacios
        if (!/^[a-zA-Z\s]+$/.test(tecla)) {
            e.preventDefault();
            return false;
        }
        return true;
    }

    function soloNumeros(e) {
        var keyCode = e.which || e.keyCode;
        var tecla = String.fromCharCode(keyCode);

        // Solo permitir números
        if (!/^\d+$/.test(tecla)) {
            e.preventDefault();
            return false;
        }
        return true;
    }
    function soloNumerosDecimal(e) {
        var keyCode = e.which || e.keyCode;
        var tecla = String.fromCharCode(keyCode);

        // Permitir números enteros y decimales
        if (!/^\d*\,?\d*$/.test(tecla)) {
            e.preventDefault();
            return false;
        }
        return true;
    }

    function mostrarModalBorrar(id, nombre, cant, precio) {

        // Asignar los valores a los TextBox del modal
        document.getElementById('<%= txtIdM.ClientID %>').value = id;
        document.getElementById('<%= txtNombreM.ClientID %>').value = nombre;
        document.getElementById('<%= txtCanM.ClientID %>').value = cant;
        document.getElementById('<%= txtPrecioM.ClientID %>').value = precio;
       
       
        const myModal = new bootstrap.Modal(document.getElementById('modalBorrar'));
        myModal.show();
    }
</script>
<script type="text/javascript">
    function mostrarAlerta() {
        // Utiliza el código de Bootstrap para mostrar un alert
        alert('Datos guardados correctamente'); // Puedes personalizar esto según tu diseño Bootstrap
    }
    function mostrarAlertaEditar() {
        // Utiliza el código de Bootstrap para mostrar un alert
        alert('Datos actualizados correctamente'); // Puedes personalizar esto según tu diseño Bootstrap
    }
    function mostrarAlertaError() {
        // Utiliza el código de Bootstrap para mostrar un alert
        alert('Debe llenar todos los campos'); // Puedes personalizar esto según tu diseño Bootstrap
    }
    function mostrarAlertaBorrado() {
        // Utiliza el código de Bootstrap para mostrar un alert
        alert('Datos eliminados correctamente'); // Puedes personalizar esto según tu diseño Bootstrap
    }
</script>
</asp:Content>
