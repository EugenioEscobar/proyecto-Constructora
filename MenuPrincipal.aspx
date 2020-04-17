<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuPrincipal.aspx.cs" Inherits="MenuPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <!-- Required meta tags -->
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="context/bootstrap-4.3.1-dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="context/style/Principal2.css" />

    <title>Menú Principal</title>
</head>
<body>
    <div class="fondo1">
        <div class="fondo">
            <div class="wrapper">
                <nav id="sidebar">
                    <div class="sidebar-header">
                        <h3>Sistema<br />
                            UPC</h3>
                    </div>
                    <ul class="list-unstyled components">
                        <p>Menú Principal</p>
                        <li class="active">
                            <a href="#homeSubmenu" data-toggle="collapse" aria-expanded="false" class="dropdown-toggle">Mantenedores de<br />
                                sistema</a>
                            <ul class="collapse list-unstyled" id="homeSubmenu">
                                <li>
                                    <a href="Mantenedores/Inmobiliaria.aspx">Inmobiliaria</a>
                                </li>
                                <li>
                                    <a href="Mantenedores/Condominios.aspx">Condominios</a>
                                </li>
                                <li>
                                    <a href="Mantenedores/Supervisores.aspx">Supervisores</a>
                                </li>
                                <li>
                                    <a href="Mantenedores/PropietariosYResidentes.aspx">Propietarios y residentes</a>
                                </li>
                                <li>
                                    <a href="Mantenedores/Maestros.aspx">Maestros</a>
                                </li>
                                <li>
                                    <a href="Mantenedores/Partida.aspx">Partida</a>
                                </li>
                                <li>
                                    <a href="Mantenedores/Causa.aspx">Causa</a>
                                </li>
                                <li>
                                    <a href="Mantenedores/Recinto.aspx">Recinto</a>
                                </li>
                                <li>
                                    <a href="Mantenedores/EstadoReparación.aspx">Estado reparación</a>
                                </li>
                                <li>
                                    <a href="Mantenedores/TipoObservacion.aspx">Tipo de observación</a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#pageSubmenu" data-toggle="collapse" aria-expanded="false" class="dropdown-toggle">Ingreso de datos</a>
                            <ul class="collapse list-unstyled" id="pageSubmenu">
                                <li>
                                    <a href="CargarExcel.aspx">Carga de Excel</a>
                                </li>
                                <li>
                                    <a href="ModificarDatos.aspx">Modificar observaciones</a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#pageSubmenu2" data-toggle="collapse" aria-expanded="false" class="dropdown-toggle">Calendarización</a>
                            <ul class="collapse list-unstyled" id="pageSubmenu2">
                                <li>
                                    <a href="Informes/Calendario_Sem1.aspx">Agenda</a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#pageSubmenu3" data-toggle="collapse" aria-expanded="false" class="dropdown-toggle">Actas</a>
                            <ul class="collapse list-unstyled" id="pageSubmenu3">
                                <li>
                                    <a href="Informes/Actas.aspx">Actas</a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#pageSubmenu4" data-toggle="collapse" aria-expanded="false" class="dropdown-toggle">Reportes Semanales</a>
                            <ul class="collapse list-unstyled" id="pageSubmenu4">
                                <li>
                                    <a href="Informes/EstadisticasObservacionesEP.aspx">Informe Semanal de Post Venta</a>
                                </li>
                                <li>
                                    <a href="Informes/EstadisticasObservacionesAP.aspx">Observaciones por Semana</a>
                                </li>
                                <li>
                                    <a href="Informes/InformeObservaciones.aspx">Informe de Observaciones Por Semana</a>
                                </li>
                                <li>
                                    <a href="Informes/EstadoReparacionObservaciones.aspx">Detalle de Observaciones Atendidas</a>
                                </li>
                                <li>
                                    <a href="Informes/PorRecintosObservacionesDeptos.aspx">Observaciones Deptos-EECC por semana</a>
                                </li>
                                <li>
                            </ul>
                        </li>

                        <li>
                            <a href="#pageSubmenu5" data-toggle="collapse" aria-expanded="false" class="dropdown-toggle">Reportes Mensuales</a>
                            <ul class="collapse list-unstyled" id="pageSubmenu5">
                                <li>
                                    <a href="Informes/EstadisticasObservacionesEPII.aspx">Informe Mensual de Post Venta</a>
                                </li>
                                <li>
                                    <a href="Informes/EstadisticasObservacionesAPII.aspx">Observaciones Mesuales</a>
                                </li>
                                <li>
                                    <a href="Informes/EstadoReparacionObservacionesII.aspx">Detalle de Observaciones Atendidas</a>
                                </li>
                                <%--<li>
						            <a href="Informes/PorRecintosObservacionesDeptos.aspx">Observaciones Deptos-EECC por Mensual</a>
					            </li>--%>
                                <li>
                                    <a href="Informes/ObservacionesIngresadasvsAtendidas.aspx">Observaciones Ingresadas vs Atendidas Mensuales</a>
                                </li>
                            </ul>
                        </li>

                        <li>
                            <a href="#pageSubmenu6" data-toggle="collapse" aria-expanded="false" class="dropdown-toggle">Otros Reportes</a>
                            <ul class="collapse list-unstyled" id="pageSubmenu6">
                                <%--	<li>
						<a href="Informes/PorRecintosObservacionesCasas.aspx">Informes Por Recinto (Casas)</a>
					</li>--%>

                                <li>
                                    <a href="Informes/TiemposAtendidasObservaciones.aspx">Estados De Observaciones En Tramos</a>
                                </li>
                                <li>
                                    <a href="Informes/DistribucionObservaciones.aspx">Distribución de Observaciones Atendidas y Pendientes</a>
                                </li>
                                <li>
                                    <a href="Informes/DistribucionObservacionesentregapostventa.aspx">Distribucion de Observaciones</a>
                                </li>
                                <li>
                                    <a href="Informes/DistribucionObservacionesProyecto.aspx">Distribución de Observaciones por Proyecto</a>
                                </li>
                                <li>
                                    <a href="Informes/AtendidasObservaciones.aspx">Observaciones Atenciones Realizadas</a>
                                </li>
                                <li>
                                    <a href="Informes/PendientesObservaciones.aspx">Observaciones Pendientes Por Edificio</a>
                                </li>
                                <li>
                                    <a href="Informes/TotalObservaciones.aspx">Observaciones Totales por Edificio</a>
                                </li>
                            </ul>
                        </li>

                        <li>
                            <a href="#pageSubmenu7" data-toggle="collapse" aria-expanded="false" class="dropdown-toggle">Informacion a Excel</a>
                            <ul class="collapse list-unstyled" id="pageSubmenu7">
                                <li>
                                    <a href="Informes/Informe_a_Excel.aspx">A excel</a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </nav>
                <div class="titulo">
                    <h2 style="margin: 40px auto; width: 100%;">Menú Principal</h2>
                </div>

            </div>


            <!-- Optional JavaScript -->
            <!-- jQuery first, then Popper.js, then Bootstrap JS -->
            <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
            <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
            <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"> </script>

            <script>
                $(document).ready(function () {
                    $('#sidebarCollapse').on('click', function () {
                        $('#sidebar').toggleClass('active');
                    });
                });
            </script>



        </div>
    </div>

</body>
</html>
