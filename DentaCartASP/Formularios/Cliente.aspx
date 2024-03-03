<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/InicioCuenta.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="DentaCartASP.Formularios.Cliente" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row border-bottom p-2">
        <div class="col-md-12">
            <h1>Estadisticas del Sistema</h1>
        </div>
    </div>
    <div class="row row-cols-1 row-cols-md-3 g-4 border-bottom p-2">
        <div class="col">
            <div class="card text-bg-primary mb-3" style="max-width: 18rem;">
                <div class="card-header">Clientes</div>
                <div class="card-body">
                    <h5 class="card-title">Total Ingresados</h5>
                    <p class="card-text">1900</p>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="card text-bg-secondary mb-3" style="max-width: 18rem;">
                <div class="card-header">Proveedores</div>
                <div class="card-body">
                    <h5 class="card-title">Total Ingresados</h5>
                    <p class="card-text">1900</p>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="card text-bg-success mb-3" style="max-width: 18rem;">
                <div class="card-header">Productos</div>
                <div class="card-body">
                    <h5 class="card-title">Total Ingresados</h5>
                    <p class="card-text">50</p>
                </div>
            </div>
        </div>
    </div>
    <div class="row align-items-center">
        <div class="col">
            <div class="card text-bg-warning mb-3" style="max-width: 18rem;">
                <div class="card-header">Ventas</div>
                <div class="card-body">
                    <h5 class="card-title">Total Ventas</h5>
                    <p class="card-text">3000</p>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="card">
                <div class="card-body">
                    <div>
                        <canvas id="myChart"></canvas>
                    </div>
                </div>
            </div>
        </div>
    </div>
       <script>
       const ctx = document.getElementById('myChart');

       new Chart(ctx, {
           type: 'bar',
           data: {
               labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
               datasets: [{
                   label: '# of Votes',
                   data: [12, 19, 3, 5, 2, 3],
                   borderWidth: 1
               }]
           },
           options: {
               scales: {
                   y: {
                       beginAtZero: true
                   }
               }
           }
       });
       </script>
</asp:Content>
