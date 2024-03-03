<%@ Page Title="Home Page" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DentaCartASP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main style="margin-top: 4%; width: 100%;">
        <div id="myCarousel" class="carousel slide mb-6" data-bs-ride="carousel">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="../img/insumo2.jpg" class="img-fluid" alt="insumos1" style="width: 100%;">
                    <div class="container">
                        <div class="carousel-caption text-start text-dark">
                            <h1>Tienda de insumos odontológicos</h1>
                            <p class="opacity-75">Ofrecemos dispositivos de uso odontológico.</p>
                            <p><a class="btn btn-lg btn-success" href="Default.aspx#prod">Ver más</a></p>
                        </div>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="../img/herramientas.jpg" class="img-fluid" alt="insumos2" style="width: 100%;">
                    <div class="container">
                        <div class="carousel-caption text-dark">
                            <h1>Insumos para Clínicas y Estudiantes</h1>
                            <p>Disponemos de Herramientas odontológicas tanto para Clínicas como para Estudiantes de la carrera de odontología..</p>
                            <p><a class="btn btn-lg btn-primary" href="Default.aspx#her">Ver más</a></p>
                        </div>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="../img/implantes.jpg" class="img-fluid" alt="insumos3" style="width: 100%;">
                    <div class="container">
                        <div class="carousel-caption text-end text-dark">
                            <h1>Compras Seguras</h1>
                            <p>Realiza tu compra de manera segura y con productos de calidad.</p>
                            <p><a class="btn btn-lg btn-primary" href="Default.aspx#segu">Ver Productos</a></p>
                        </div>
                    </div>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#myCarousel" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#myCarousel" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>


        <!-- Marketing messaging and featurettes
  ================================================== -->
        <!-- Wrap the rest of the page in another container to center all the content. -->

        <div class="container marketing">

            <!-- Three columns of text below the carousel -->
            <div class="row">
                <div class="col-lg-4">
                    <img src="../img/esterilizacion.jpg" width="140" height="140" class="object-fit-cover rounded-circle" alt="esterilizacion">
                    <h2 class="fw-normal">Esterilización</h2>
                    <p>Dispositivos para uso clínico en esterilización de materiales odontológicos</p>
                    <p><a class="btn btn-secondary" href="#">Ver Detalles &raquo;</a></p>
                </div>
                <!-- /.col-lg-4 -->
                <div class="col-lg-4">
                    <img src="../img/ortodoncia.jpeg" width="140" height="140" class="object-fit-cover rounded-circle" alt="ortodoncia">
                    <h2 class="fw-normal">Ortodoncia</h2>
                    <p>Materiales para uso de Ortodoncia</p>
                    <p><a class="btn btn-secondary" href="#">Ver Detalles &raquo;</a></p>
                </div>
                <!-- /.col-lg-4 -->
                <div class="col-lg-4">
                    <img src="../img/implantes.jpg" width="140" height="140" class="object-fit-cover rounded-circle" alt="implante">
                    <h2 class="fw-normal">Implantes</h2>
                    <p>Insumos de uso clínico para implantes dentales.</p>
                    <p><a class="btn btn-secondary" href="#">Ver Detalles &raquo;</a></p>
                </div>
                <!-- /.col-lg-4 -->
            </div>
            <!-- /.row -->
            <!-- Three columns of text below the carousel -->
            <div class="row">
                <div class="col-lg-4">
                    <img src="../img/silla.jpg" alt="silla" width="140" height="140" class="object-fit-cover rounded-circle">
                    <h2 class="fw-normal">Equipos Seminuevos</h2>
                    <p>Dispositivos para clinicas o estudiantes remanufacturados a menor costo</p>
                    <p><a class="btn btn-secondary" href="#">Ver Detalles &raquo;</a></p>
                </div>
                <!-- /.col-lg-4 -->
                <div class="col-lg-4">
                    <img src="../img/aplicaciones.jpg" width="140" height="140" class="object-fit-cover rounded-circle" alt="software">
                    <h2 class="fw-normal">Software Odotonlógico</h2>
                    <p>Aplicaciones informaticas para uso odontológico</p>
                    <p><a class="btn btn-secondary" href="#">Ver Detalles &raquo;</a></p>
                </div>
                <!-- /.col-lg-4 -->
                <div class="col-lg-4">
                    <img src="../img/herramientas.jpg" width="140" height="140" class="object-fit-cover rounded-circle" alt="tools">
                    <h2 class="fw-normal">Herramientas</h2>
                    <p>Herramientas para clínicas o profesionales de la salud bucal.</p>
                    <p><a class="btn btn-secondary" href="#">Ver Detalles &raquo;</a></p>
                </div>
                <!-- /.col-lg-4 -->
            </div>
            <!-- /.row -->

            <!-- START THE FEATURETTES -->

            <hr class="featurette-divider">

            <div class="row featurette" id="prod">
                <div class="col-md-7 text-center">
                    <h2 class="featurette-heading fw-normal lh-1">
                    Herramientas de Esterilización 
        <p class="lead">
            Disponemos de las mejores marcas de equipos de esterilización
            <br />
            de instrumentos para uso dental que te garantiza la salubridad de tus herramientas de trabajo.
        </p>
                </div>
                <div class="col-md-5">
                    <img src="../img/esterilizacion.jpg" class="img-fluid mx-auto" width="500" height="500" alt="ester" />
                </div>
            </div>

            <hr class="featurette-divider">

            <div class="row featurette" id="segu">
                <div class="col-md-7 order-md-2">
                    <h2 class="featurette-heading fw-normal lh-1">Seguridad en tus Compras. <span class="text-body-secondary">Con garantía de fábrica.</span></h2>
                    <p class="lead">Puedes adquirir tus productos con seguridad y respaldo de funcionamiento debido a que importamos equipos en las mejores marcas del mercado para la conformidad de todos nuestros clientes.</p>
                </div>
                <div class="col-md-5 order-md-1">
                    <img class="featurette-image img-fluid mx-auto" width="500" height="500" src="../img/carrito.jpeg" />
                </div>
            </div>

            <hr class="featurette-divider">

            <div class="row featurette" id="her">
                <div class="col-md-7">
                    <h2 class="featurette-heading fw-normal lh-1">Equipos Seminuevos/<span class="text-body-secondary">Refacturados</span></h2>
                    <p class="lead">Ofrecemos también un catálogo de productos que han sido remanufacturados como sillas, compresores que se encuentran funcionando de manera correcta y con garantía de 6 meses para que sientas seguridad en la adquisición de estos.</p>
                </div>
                <div class="col-md-5">
                    <img class="featurette-image img-fluid mx-auto" width="500" height="500" src="../img/remanu.jpeg" />
                </div>
            </div>

            <hr class="featurette-divider">

            <div class="row featurette text-center">
                <div class="col-md-12 text-center">
                    <h3>Contactos</h3>
                </div>
                <div class="col-md-4">
                    <img class="rounded-circle img-fluid mx-auto"  src="../img/ubic.png" /><br/>
                    Quito, Ecuador
                </div>
                <div class="col-md-4">
                    <img class="rounded-circle img-fluid mx-auto"  height="500" src="../img/wsp.png" /><br/>
                    0999999999
                </div>
                <div class="col-md-4">
                    <img class="rounded-circle img-fluid mx-auto"  height="500" src="../img/email.png" /><br/>
                    Correo: dentacart_servicios@gmail.com
                </div>
            </div>

            <!-- /END THE FEATURETTES -->

        </div>
        <!-- /.container -->
    </main>

</asp:Content>
