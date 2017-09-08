<?php

require_once 'class/class.cuestionario1.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='auditor'){

?>

  <body class="skin-blue">

    <style>
      .legend ul {
        list-style: none;
      }
      .legend ul li {
        display: block;
        padding-left: 30px;
        position: relative;
        margin-bottom: 4px;
        border-radius: 5px;
        padding: 2px 8px 2px 28px;
        font-size: 14px;
        cursor: default;
        -webkit-transition: background-color 200ms ease-in-out;
        -moz-transition: background-color 200ms ease-in-out;
        -o-transition: background-color 200ms ease-in-out;
        transition: background-color 200ms ease-in-out;
      }
      .legend li span {
        display: block;
        position: absolute;
        left: 0;
        top: 0;
        width: 20px;
        height: 100%;
        border-radius: 5px;
      }
      small.small_grafic{
        text-transform: initial;
        font-size: 10px;
      }
    </style>

    <script>
      $(function(){//Funciones para Cuestionario1

        

      })


    </script>

    <!-- Site wrapper -->
    <div class="wrapper">

      <?php require "views/auditor/header_auditor.php"; ?>

      <?php require "views/auditor/menu_vertical.php"; ?>
        <!-- Content Wrapper. Contains page content -->
      <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Resultados de Cuestionario Sigma
            <small>Reporte</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#">Inicio</a></li>
          </ol>

        </section>

        <!-- Main content -->
        <section class="content">
            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <button class="btn btn-primary pull-right" data-placement="bottom" onclick="javascript:location='index.php?command=cuestionario1_detalles_auditor'" data-toggle="tooltip" title="Detalles" data-original-title="Detalles">
                  <img style="max-width:10px" src="images/logo_ver.png">
                </button> &nbsp;
                <button class="btn btn-primary pull-right" onclick="javascript:location='index.php?command=cuestionario1_auditor'" data-widget="Añadir Cuestionario" data-toggle="tooltip" title="Añadir Cuestionario"  data-original-title="Añadir Cuestionario">
                  <i class="fa fa-plus"></i>
                </button>
                <br>
                &nbsp;
              </div>
            </div>
            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="box box-primary collapsed-box">
                  <div class="box-header with-border">
                    <h3 class="box-title">Opciones</h3>
                    <div class="box-tools pull-right">
                      <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                      <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                    </div>
                  </div>
                  <div class="box-body">
                    <div class="col-md-6 col-sm-6 col-xs-12"> 

                      <div class="form-group row">  
                        <label class="col-md-2 col-sm-2 col-xs-12">Campaña</label> 
                        <div class="col-md-5 col-sm-8 col-xs-12">
                          <select name="tipo_seleccion" id="tipo_seleccion" class="form-control">
                            <option value="0">Selecciona...</option>
                            <option value="1">Campaña</option>
                            <option value="2">Evaluador</option>
                            <option value="3">Encargado</option>
                          </select>
                        </div>
                      </div>

                      <div class="form-group row">  
                        <label class="col-md-2 col-sm-2 col-xs-12">&nbsp;</label> 
                        <div class="col-md-5 col-sm-8 col-xs-12">
                          <select name="opciones_seleccion" id="opciones_seleccion" class="form-control" multiple>
                            <option value="0">Selecciona...</option>
                          </select>
                        </div>
                      </div>

                      <div class="form-group row" style="display:none;">  
                        <label class="col-md-2 col-sm-2 col-xs-12">Campaña</label> 
                        <div class="col-md-5 col-sm-8 col-xs-12">
                          <select name="campana" id="campana" class="form-control">
                            <option value="0">Selecciona...</option>
                          </select>
                        </div>
                      </div>
                      
                      <div class="form-group row" style="display:none;">  
                        <label class="col-md-2 col-sm-2 col-xs-12">Evaluador</label> 
                        <div class="col-md-5 col-sm-8 col-xs-12">
                          <select name="evaluador" id="evaluador" class="form-control">
                            <option value="0">Selecciona...</option>
                          </select>
                        </div>
                      </div>
                      
                      <div class="form-group row" style="display:none;">  
                        <label class="col-md-2 col-sm-2 col-xs-12">Encargado</label> 
                        <div class="col-md-5 col-sm-8 col-xs-12">
                          <select name="encargado" id="encargado" class="form-control">
                            <option value="0">Selecciona...</option>
                          </select>
                        </div>
                      </div>
                                        
                    </div>

                    <div class="col-md-6 col-sm-6 col-xs-12">  

                      <div class="form-group">
                        <label>Rango de fecha:</label>
                        <div class="input-group">
                          <div class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                          </div>
                          <input type="text" class="form-control pull-right" id="range" />
                        </div><!-- /.input group -->
                      </div><!-- /.form group -->                      
                      
                    </div>
                  </div><!-- /.box-body -->

                  <div class="box-footer">
                    <button id="btn_buscar" name="btn_buscar" class="btn btn-primary">Buscar</button>
                    <button id="btn_comparar" name="btn_comparar" class="btn btn-primary">Comparar</button>
                  </div>

                </div>
              </div>
            </div>

          <!-- Default box -->
            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="box box-primary">
                  <div class="box-header with-border">
                    <h3 class="box-title">Campaña <small>(% de respuestas)</small></h3>
                    <div class="box-tools pull-right">
                      <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                      <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                    </div>
                  </div>
                  <div class="box-body chart-responsive">
                    <div class="col-md-12 col-sm-12 col-xs-12" id="contChart"> 
                      <canvas id="barChart" height="230"></canvas>
                      <div class="legend" id="barChartLegend"></div>
                    </div>

                  </div><!-- /.box-body -->

                </div>
              </div>
            </div>

            <div class="row">

              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="box box-primary">
                  <div class="box-header with-border">
                    <h3 class="box-title">Encargados</h3>
                    <div class="box-tools pull-right">
                      <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                      <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                    </div>
                  </div>
                  <div class="box-body" >
                    <div class="col-md-12 col-sm-12 col-xs-12" id="contChartPie">
                      <canvas id="pieChart" height="250"></canvas> 
                      <div class="legend" id="pieChartLegend"></div>
                    </div>
                  </div><!-- /.box-body -->
                </div>
              </div>

              <div class="col-md-6 col-sm-6 col-xs-12" style="display:none">
                <div class="box box-primary">
                  <div class="box-header with-border">
                    <h3 class="box-title">Encargado</h3>
                    <div class="box-tools pull-right">
                      <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                      <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                    </div>
                  </div>
                  <div class="box-body">
                    <div class="col-md-12 col-sm-12 col-xs-12" id="contChart4">  
                      <canvas id="barChart4" height="230"></canvas>
                      <div class="legend" id="barChart4Legend"></div>
                    </div>
                  </div><!-- /.box-body -->
                </div><!-- /.box -->
              </div>


              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="info-box bg-yellow">
                  <div class="info-box-content">
                    <span class="info-box-text">Puntualidad 
                      <small id="small_puntualidad" class="small_grafic"></small>
                    </span>
                    <span class="info-box-number" id="num-puntualidad">0</span>

                    <div class="progress">
                      <div style="width: 0%" class="progress-bar" id="progress-puntualidad"></div>
                    </div>
                        <span class="progress-description" id="progress-num-puntualidad">
                          0% 
                        </span>
                  </div>
                  <!-- /.info-box-content -->
                </div>

                <div class="info-box bg-green">
                  <div class="info-box-content">
                    <span class="info-box-text">Abordaje <small id="small_abordaje" class="small_grafic"></small></span>
                    <span class="info-box-number" id="num-abordaje">0</span>

                    <div class="progress">
                      <div style="width: 0%" class="progress-bar" id="progress-abordaje"></div>
                    </div>
                        <span class="progress-description" id="progress-num-abordaje">
                          0% 
                        </span>
                  </div>
                  <!-- /.info-box-content -->
                </div>

                <div class="info-box bg-red">
                  <div class="info-box-content">
                    <span class="info-box-text">Ubicación <small id="small_ubicacion" class="small_grafic"></small></span>
                    <span class="info-box-number" id="num-ubicacion">0</span>

                    <div class="progress">
                      <div style="width: 0%" class="progress-bar" id="progress-ubicacion"></div>
                    </div>
                        <span class="progress-description" id="progress-num-ubicacion">
                          0% 
                        </span>
                  </div>
                  <!-- /.info-box-content -->
                </div>

                <div class="info-box bg-aqua">
                  <div class="info-box-content">
                    <span class="info-box-text">Objetivo de venta <small id="small_objetivo" class="small_grafic"></small></span>
                    <span class="info-box-number" id="num-objetivo">0</span>

                    <div class="progress">
                      <div style="width: 0%" class="progress-bar" id="progress-objetivo"></div>
                    </div>
                        <span class="progress-description" id="progress-num-objetivo">
                          0% 
                        </span>
                  </div>
                  <!-- /.info-box-content -->
                </div>
              </div>

              <div class="col-md-6 col-sm-6 col-xs-12" style="display:none">
                <div class="box box-primary" >
                  <div class="box-header with-border">
                    <h3 class="box-title">Comunicación</h3>
                    <div class="box-tools pull-right">
                      <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                      <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                    </div>
                  </div>
                  <div class="box-body">
                    <div class="col-md-12 col-sm-12 col-xs-12" id="contChart2">  
                      <canvas id="barChart2" height="230"></canvas>
                      <div class="legend" id="barChart2Legend"></div>
                    </div>
                  </div><!-- /.box-body -->
                </div><!-- /.box -->
              </div>

              <div class="col-md-6 col-sm-6 col-xs-12">

                <div class="info-box bg-yellow">
                  <div class="info-box-content">
                    <span class="info-box-text">¿Menciona la frase rectora? <small id="small_frase" class="small_grafic"></small></span>
                    <span class="info-box-number" id="num-frase">0</span>

                    <div class="progress">
                      <div style="width: 0%" class="progress-bar" id="progress-frase"></div>
                    </div>
                        <span class="progress-description" id="progress-num-frase">
                          0% 
                        </span>
                  </div>
                  <!-- /.info-box-content -->
                </div>

                <div class="info-box bg-green">
                  <div class="info-box-content">
                    <span class="info-box-text">¿Comunica el precio? <small id="small_precio" class="small_grafic"></small></span>
                    <span class="info-box-number" id="num-precio">0</span>

                    <div class="progress">
                      <div style="width: 0%" class="progress-bar" id="progress-precio"></div>
                    </div>
                        <span class="progress-description" id="progress-num-precio">
                          0% 
                        </span>
                  </div>
                  <!-- /.info-box-content -->
                </div>

                <div class="info-box bg-red">
                  <div class="info-box-content">
                    <span class="info-box-text">¿Comunica los argumentos de venta? <small id="small_argumentos" class="small_grafic"></small></span>
                    <span class="info-box-number" id="num-argumentos">0</span>

                    <div class="progress">
                      <div style="width: 0%" class="progress-bar" id="progress-argumentos"></div>
                    </div>
                        <span class="progress-description" id="progress-num-argumentos">
                          0% 
                        </span>
                  </div>
                  <!-- /.info-box-content -->
                </div>


              </div>

              <div class="col-md-6 col-sm-6 col-xs-12" style="display:none;">
                <div class="box box-primary">
                  <div class="box-header with-border">
                    <h3 class="box-title">Imagen del evento</h3>
                    <div class="box-tools pull-right">
                      <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                      <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                    </div>
                  </div>
                  <div class="box-body">
                    <div class="col-md-12 col-sm-12 col-xs-12" id="contChart3">  
                      <canvas id="barChart3" height="230"></canvas>
                      <div class="legend" id="barChart3Legend"></div>
                    </div>
                  </div><!-- /.box-body -->
                </div>
              </div>

              <div class="col-md-6 col-sm-6 col-xs-12">

                <div class="info-box bg-yellow">
                  <div class="info-box-content">
                    <span class="info-box-text">Imagen de la persona 
                      <small id="small_imagen_persona" class="small_grafic"></small>
                    </span>
                    <span class="info-box-number" id="num-imagen-persona">0</span>

                    <div class="progress">
                      <div style="width: 0%" class="progress-bar" id="progress-imagen-persona"></div>
                    </div>
                    <span class="progress-description" id="progress-num-imagen-persona">
                      0% 
                    </span>
                  </div>
                  <!-- /.info-box-content -->
                </div>

                <div class="info-box bg-green">
                  <div class="info-box-content">
                    <span class="info-box-text">Presentación producto vta. <small id="small_producto_vta" class="small_grafic"></small></span>
                    <span class="info-box-number" id="num-producto-vta">0</span>

                    <div class="progress">
                      <div style="width: 0%" class="progress-bar" id="progress-producto-vta"></div>
                    </div>
                        <span class="progress-description" id="progress-num-producto-vta">
                          0% 
                        </span>
                  </div>
                  <!-- /.info-box-content -->
                </div>

                <div class="info-box bg-red">
                  <div class="info-box-content">
                    <span class="info-box-text">Congruencia de la marca <small id="small_marca" class="small_grafic"></small></span>
                    <span class="info-box-number" id="num-marca">0</span>

                    <div class="progress">
                      <div style="width: 0%" class="progress-bar" id="progress-marca"></div>
                    </div>
                        <span class="progress-description" id="progress-num-marca">
                          0% 
                        </span>
                  </div>
                  <!-- /.info-box-content -->
                </div>

                <div class="info-box bg-aqua">
                  <div class="info-box-content">
                    <span class="info-box-text">Presentación del producto <small id="small_presentacion_producto" class="small_grafic"></small></span>
                    <span class="info-box-number" id="num-presentacion-producto">0</span>

                    <div class="progress">
                      <div style="width: 0%" class="progress-bar" id="progress-presentacion-producto"></div>
                    </div>
                        <span class="progress-description" id="progress-num-presentacion-producto">
                          0% 
                        </span>
                  </div>
                  <!-- /.info-box-content -->
                </div>


              </div>


              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="box box-primary">
                  <div class="box-header with-border">
                    <h3 class="box-title">Tiendas activadas</h3>
                    <div class="box-tools pull-right">
                      <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                      <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                    </div>
                  </div>
                  <div class="box-body">
                    <div class="col-md-12 col-sm-12 col-xs-12" id="contChart5">  
                      <canvas id="pieChart5" height="230"></canvas>
                      <div class="legend" id="pieChart5Legend"></div>
                    </div>
                  </div><!-- /.box-body -->
                </div>
              </div>

              
            </div>

            

        </section><!-- /.content -->
      </div><!-- /.content-wrapper -->


      <?php require "views/directivos/footer_directivo.php" ?>
    </div>

  <script>

   $(function () {     


     //**********************************************************************************************
     // ******************************INICIO GRAFICAS************************************************
     //********************************************************************************************** 

     

      function get_random_color() {
        function c() {
          return Math.floor(Math.random()*256).toString(10)
        }
        return c()+","+c()+","+c();
      }

      console.log("COLOR: "+ get_random_color());

      $('#range').daterangepicker("option", "dateFormat", "yy-mm-dd");

        var areaChartData = {
          labels: ["Modulo", "Charola", "Sarteneta", "POP", "Licencia", "Sonido", "Adicional", "Produco Suficiente", "Degustación", "Uniforme"],
          datasets: [
            {
              label: ["Todo"],
              pointStrokeColor: "#c1c7d1",
              pointHighlightFill: "#fff",
              pointHighlightStroke: "rgba(220,220,220,1)",
              data: [0,0,0,0,0,0,0,0,0]
            }
          ]
        };

        var areaChartData2 = {
          labels: ["¿Menciona la frase rectora?", "Comunica los argumentos de venta","Comunica el precio"],
          datasets: [
            {
              label: "Todo",
              pointStrokeColor: "#c1c7d1",
              pointHighlightFill: "#fff",
              pointHighlightStroke: "rgba(220,220,220,1)",
              data: [0, 0, 0]
            }  
          ]
        };

        var areaChartData3 = {
          labels: ["Imagen de la persona", "Congruencia de la marca","Presentación del producto", "Presentación Producto Vta."],
          datasets: [
            {
              label: "Todo",
              pointStrokeColor: "#c1c7d1",
              pointHighlightFill: "#fff",
              pointHighlightStroke: "rgba(220,220,220,1)",
              data: [0, 0, 0, 0]
            }  
          ]
        };

        var areaChartData4 = {
          labels: ["Puntualidad", "Abordaje","Ubicación", "Objetivo de venta"],
          datasets: [
            {
              label: "Todo",
              pointStrokeColor: "#c1c7d1",
              pointHighlightFill: "#fff",
              pointHighlightStroke: "rgba(220,220,220,1)",
              data: [0, 0, 0, 0]
            }  
          ]
        };

        var areaChartData5 = {
          labels: ["Puntualidad", "Abordaje","Ubicación", "Objetivo de venta"],
          datasets: [
            {
              label: "Todo",
              pointStrokeColor: "#c1c7d1",
              pointHighlightFill: "#fff",
              pointHighlightStroke: "rgba(220,220,220,1)",
              data: [0, 0, 0, 0]
            }  
          ]
        };


        var areaChartDataPie = [
          {
            value: 3,
            color: "#f56954",
            highlight: "#f56954",
            label: "Encargado1"
          },
          {
            value: 3,
            color: "#00a65a",
            highlight: "#00a65a",
            label: "Encargado2"
          },
          {
            value: 3,
            color: "#f39c12",
            highlight: "#f39c12",
            label: "Encargado3"
          },
          {
            value: 4,
            color: "#00c0ef",
            highlight: "#00c0ef",
            label: "Encargado4"
          },
          {
            value: 2,
            color: "#3c8dbc",
            highlight: "#3c8dbc",
            label: "Encargado5"
          },
          {
            value: 1,
            color: "#d2d6de",
            highlight: "#d2d6de",
            label: "Encargado6"
          }
        ];

        var pieChartDataPie5 = [
          {
            value: 0,
            color: "#f56954",
            highlight: "#f56954",
            label: "Activadas"
          },
          {
            value: 0,
            color: "#00a65a",
            highlight: "#00a65a",
            label: "No Activadas"
          }
        ];


        var color_grafica = get_random_color();
        //-------------
        //- BAR CHART -
        //-------------
        var barChartCanvas = $("#barChart").get(0).getContext("2d");
        var barChart = new Chart(barChartCanvas);
        var barChartData = areaChartData;
        
        barChartData.datasets[0].fillColor = "rgba("+color_grafica+", 1)";
        barChartData.datasets[0].strokeColor = "rgba("+color_grafica+", 1)";
        barChartData.datasets[0].pointColor = "rgba("+color_grafica+", 1)";
        var barChartOptions = {
          //Boolean - Whether the scale should start at zero, or an order of magnitude down from the lowest value
          scaleBeginAtZero: true,
          //Boolean - Whether grid lines are shown across the chart
          scaleShowGridLines: true,
          //String - Colour of the grid lines
          scaleGridLineColor: "rgba(0,0,0,.05)",
          //Number - Width of the grid lines
          scaleGridLineWidth: 1,
          //Boolean - Whether to show horizontal lines (except X axis)
          scaleShowHorizontalLines: true,
          //Boolean - Whether to show vertical lines (except Y axis)
          scaleShowVerticalLines: true,
          //Boolean - If there is a stroke on each bar
          barShowStroke: true,
          //Number - Pixel width of the bar stroke
          barStrokeWidth: 2,
          //Number - Spacing between each of the X value sets
          barValueSpacing: 5,
          //Number - Spacing between data sets within X values
          barDatasetSpacing: 1,
          //String - A legend template
          legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].fillColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>",
          //Boolean - whether to make the chart responsive
          responsive: true,
          maintainAspectRatio: false
        };

        barChartOptions.datasetFill = false;
        window.barChartLegend = barChart.Bar(barChartData, barChartOptions);

        $("#barChartLegend").html(barChartLegend.generateLegend());



        //-------------
        //- BAR CHART -
        //-------------
        var barChartCanvas2 = $("#barChart2").get(0).getContext("2d");
        var barChart2 = new Chart(barChartCanvas2);
        var barChartData2 = areaChartData2;
        barChartData2.datasets[0].fillColor = "rgba("+color_grafica+", 1)";
        barChartData2.datasets[0].strokeColor = "rgba("+color_grafica+", 1)";
        barChartData2.datasets[0].pointColor = "rgba("+color_grafica+", 1)";
        var barChartOptions2 = {
          //Boolean - Whether the scale should start at zero, or an order of magnitude down from the lowest value
          scaleBeginAtZero: true,
          //Boolean - Whether grid lines are shown across the chart
          scaleShowGridLines: true,
          //String - Colour of the grid lines
          scaleGridLineColor: "rgba(0,0,0,.05)",
          //Number - Width of the grid lines
          scaleGridLineWidth: 1,
          //Boolean - Whether to show horizontal lines (except X axis)
          scaleShowHorizontalLines: true,
          //Boolean - Whether to show vertical lines (except Y axis)
          scaleShowVerticalLines: true,
          //Boolean - If there is a stroke on each bar
          barShowStroke: true,
          //Number - Pixel width of the bar stroke
          barStrokeWidth: 2,
          //Number - Spacing between each of the X value sets
          barValueSpacing: 5,
          //Number - Spacing between data sets within X values
          barDatasetSpacing: 1,
          //String - A legend template
          legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].fillColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>",
          //Boolean - whether to make the chart responsive
          responsive: true,
          maintainAspectRatio: false
        };

        barChartOptions2.datasetFill = false;
        window.barChart2Legend = barChart2.Radar(barChartData2, barChartOptions2);
        
        $("#barChart2Legend").html(barChart2Legend.generateLegend());


        //-------------
        //- BAR CHART -
        //-------------
        var barChartCanvas3 = $("#barChart3").get(0).getContext("2d");
        var barChart3 = new Chart(barChartCanvas3);
        var barChartData3 = areaChartData3;
        barChartData3.datasets[0].fillColor = "rgba("+color_grafica+", 1)";
        barChartData3.datasets[0].strokeColor = "rgba("+color_grafica+", 1)";
        barChartData3.datasets[0].pointColor = "rgba("+color_grafica+", 1)";
        var barChartOptions3 = {
          //Boolean - Whether the scale should start at zero, or an order of magnitude down from the lowest value
          scaleBeginAtZero: true,
          //Boolean - Whether grid lines are shown across the chart
          scaleShowGridLines: true,
          //String - Colour of the grid lines
          scaleGridLineColor: "rgba(0,0,0,.05)",
          //Number - Width of the grid lines
          scaleGridLineWidth: 1,
          //Boolean - Whether to show horizontal lines (except X axis)
          scaleShowHorizontalLines: true,
          //Boolean - Whether to show vertical lines (except Y axis)
          scaleShowVerticalLines: true,
          //Boolean - If there is a stroke on each bar
          barShowStroke: true,
          //Number - Pixel width of the bar stroke
          barStrokeWidth: 2,
          //Number - Spacing between each of the X value sets
          barValueSpacing: 5,
          //Number - Spacing between data sets within X values
          barDatasetSpacing: 1,
          //String - A legend template
          legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].fillColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>",
          //Boolean - whether to make the chart responsive
          responsive: true,
          maintainAspectRatio: false
        };

        barChartOptions3.datasetFill = false;
        window.barChart3Legend = barChart3.Radar(barChartData3, barChartOptions3);

        $("#barChart3Legend").html(barChart3Legend.generateLegend());



        //-------------
        //- BAR CHART -
        //-------------
        var barChartCanvas4 = $("#barChart4").get(0).getContext("2d");
        var barChart4 = new Chart(barChartCanvas4);
        var barChartData4 = areaChartData4;
        barChartData4.datasets[0].fillColor = "rgba("+color_grafica+", 1)";
        barChartData4.datasets[0].strokeColor = "rgba("+color_grafica+", 1)";
        barChartData4.datasets[0].pointColor = "rgba("+color_grafica+", 1)";
        var barChartOptions4 = {
          //Boolean - Whether the scale should start at zero, or an order of magnitude down from the lowest value
          scaleBeginAtZero: true,
          //Boolean - Whether grid lines are shown across the chart
          scaleShowGridLines: true,
          //String - Colour of the grid lines
          scaleGridLineColor: "rgba(0,0,0,.05)",
          //Number - Width of the grid lines
          scaleGridLineWidth: 1,
          //Boolean - Whether to show horizontal lines (except X axis)
          scaleShowHorizontalLines: true,
          //Boolean - Whether to show vertical lines (except Y axis)
          scaleShowVerticalLines: true,
          //Boolean - If there is a stroke on each bar
          barShowStroke: true,
          //Number - Pixel width of the bar stroke
          barStrokeWidth: 2,
          //Number - Spacing between each of the X value sets
          barValueSpacing: 5,
          //Number - Spacing between data sets within X values
          barDatasetSpacing: 1,
          //String - A legend template
          legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].fillColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>",
          //Boolean - whether to make the chart responsive
          responsive: true,
          maintainAspectRatio: false
        };

        barChartOptions4.datasetFill = false;
        window.barChart4Legend = barChart4.Radar(barChartData4, barChartOptions4);

        $("#barChart4Legend").html(barChart4Legend.generateLegend());


       //-------------
        //- DOMUT CHART -
        //-------------
        var pieChartCanvas = $("#pieChart").get(0).getContext("2d");
        var pieChart = new Chart(pieChartCanvas);
        var pieChartData = areaChartDataPie;
        //pieChartData.datasets[0].fillColor = "rgba("+color_grafica+", 1)";
        //pieChartData.datasets[0].strokeColor = "rgba("+color_grafica+", 1)";
        //pieChartData.datasets[0].pointColor = "rgba("+color_grafica+", 1)";
        var pieChartOptions = {
          //Boolean - Whether the scale should start at zero, or an order of magnitude down from the lowest value
          scaleBeginAtZero: true,
          //Boolean - Whether grid lines are shown across the chart
          scaleShowGridLines: true,
          //String - Colour of the grid lines
          scaleGridLineColor: "rgba(0,0,0,.05)",
          //Number - Width of the grid lines
          scaleGridLineWidth: 1,
          //Boolean - Whether to show horizontal lines (except X axis)
          scaleShowHorizontalLines: true,
          //Boolean - Whether to show vertical lines (except Y axis)
          scaleShowVerticalLines: true,
          //Boolean - If there is a stroke on each bar
          barShowStroke: true,
          //Number - Pixel width of the bar stroke
          barStrokeWidth: 2,
          //Number - Spacing between each of the X value sets
          barValueSpacing: 5,
          //Number - Spacing between data sets within X values
          barDatasetSpacing: 1,
          //String - A legend template
          //legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].fillColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>",
          //Boolean - whether to make the chart responsive
          responsive: true,
          maintainAspectRatio: false
        };

        pieChartOptions.datasetFill = false;
        window.pieChartLegend = pieChart.Doughnut(pieChartData, pieChartOptions);

        //$("#pieChartLegend").html(pieChartLegend.generateLegend());


        //-------------
        //- BAR CHART -
        //-------------
        var pieChartCanvas5 = $("#pieChart5").get(0).getContext("2d");
        var pieChart5 = new Chart(pieChartCanvas5);
        var pieChartData5 = pieChartDataPie5;
        var pieChartOptions5 = {
          //Boolean - Whether the scale should start at zero, or an order of magnitude down from the lowest value
          scaleBeginAtZero: true,
          //Boolean - Whether grid lines are shown across the chart
          scaleShowGridLines: true,
          //String - Colour of the grid lines
          scaleGridLineColor: "rgba(0,0,0,.05)",
          //Number - Width of the grid lines
          scaleGridLineWidth: 1,
          //Boolean - Whether to show horizontal lines (except X axis)
          scaleShowHorizontalLines: true,
          //Boolean - Whether to show vertical lines (except Y axis)
          scaleShowVerticalLines: true,
          //Boolean - If there is a stroke on each bar
          barShowStroke: true,
          //Number - Pixel width of the bar stroke
          barStrokeWidth: 2,
          //Number - Spacing between each of the X value sets
          barValueSpacing: 5,
          //Number - Spacing between data sets within X values
          barDatasetSpacing: 1,
          //String - A legend template
          legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].fillColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>",
          //Boolean - whether to make the chart responsive
          responsive: true,
          maintainAspectRatio: false
        };

        pieChartOptions5.datasetFill = false;
        window.pieChart5Legend = pieChart5.Doughnut(pieChartData5, pieChartOptions5);
        
        //$("#pieChart5Legend").html(pieChart5Legend.generateLegend());


     //**********************************************************************************************
     // ******************************INICIO GRAFICAS************************************************
     //********************************************************************************************** 


    //recuperar datos 
        r_datos = function(options){

          options=(options==typeof(undefined))?'':options;
          params=options;
          var datos = $.ajax({
            url:'class/class.cuestionario1.php',
            type:'post',
            dataType:'json',
            data:params,
            async:false       
          }).responseText;
          return datos
        }

        function get_usuario_nombres(arr_nombres, id_usuario){

          id_usuario = id_usuario || 0;
          var i = (arr_nombres.ids).indexOf(id_usuario);
          //nombre = JSON.parse(r_datos({funcion:'get_campana_nombre_lista',id:id_campana})); 
          
          if (i!==-1){ 
            return arr_nombres.nombres[i];
          }else{
            return "";
          }

          //id_usuario = id_usuario || 0;
          //nombre = JSON.parse(r_datos({funcion:'get_all_usuario_nombre',id:id_usuario}));          
          //return nombre['usuario_name']
        }

        function get_campana_nombre_lista(arr_nombres,id_campana){
          id_campana = id_campana || 0;
          var i = (arr_nombres.ids).indexOf(id_campana);
          //nombre = JSON.parse(r_datos({funcion:'get_campana_nombre_lista',id:id_campana})); 
          
          if (i!==-1){ 
            return arr_nombres.nombres[i];
          }else{
            return "";
          }

        }

        function parse_campana(obj_campana,contenedor){
          contenedor = contenedor || $('#campana');
          nombre_campanas = JSON.parse(r_datos({funcion:'get_all_campana_nombre_lista'})); 
          var nombre_campana = [];


          arr_nombres = {};
          arr_nombres['nombres'] = [];
          arr_nombres['ids'] = [];

          (nombre_campanas.campana).forEach(function(e,i){
            arr_nombres['nombres'].push(nombre_campanas.campana[i].nombre_campana);
            arr_nombres['ids'].push(nombre_campanas.campana[i].id_campana);
          })


          if (obj_campana['campana'].length>0){
            contenedor.html('<option value="0">Selecciona...</option>');
            for (i=0; i<obj_campana['campana'].length; i++){ 
              var json_campana =  JSON.parse(obj_campana['campana'][i]['respuestas']);
              var json_id      =  JSON.parse(obj_campana['campana'][i]['id_respuesta']);
              if (typeof json_campana == 'object'){
                var nombre  = json_campana['nombre_campana'];
                var id      = json_campana['nombre_campana'];

                nombre = isNaN(nombre)?nombre:get_campana_nombre_lista(arr_nombres, nombre);

                contenedor.append("<option value='"+json_id+"''>"+nombre+"</option>");
              }              
            }           
          }
          //console.log(r);
        }

        function parse_evaluador(obj_evaluador,contenedor){
          contenedor = contenedor || $('#evaluador');
          var nombre_evaluador = [];
          //console.log(obj_evaluador);
          if (obj_evaluador['evaluador'].length>0){
            contenedor.html('<option value="0">Selecciona...</option>');
            for (i=0; i<obj_evaluador['evaluador'].length; i++){ 
              var nombre = obj_evaluador['evaluador'][i]['User_name'];
              var id     = obj_evaluador['evaluador'][i]['id_usuario'];
              contenedor.append("<option value='"+id+"'>"+nombre+"</option>");
            }
            console.log(nombre_evaluador);
          }
          //console.log(r);
        }

        function parse_encargado(obj_encargado,contenedor){
          contenedor = contenedor || $('#encargado');
          var nombre_evaluador = [];
          //console.log(obj_encargado);
          if (obj_encargado['usuarios'].length>0){
            contenedor.html('<option value="0">Selecciona...</option>');
            for (i=0; i<obj_encargado['usuarios'].length; i++){ 
              var nombre = obj_encargado['usuarios'][i]['User_name'];
              var id     = obj_encargado['usuarios'][i]['id_usuario'];
              contenedor.append("<option value='"+id+"'>"+nombre+"</option>");
            }
            console.log(nombre_evaluador);
          }
          //console.log(r);
        }

        function parse_grafica_campana(obj_grafica_campana){
          var nombre_campana = [];

                nombre_campana['modulo'] = 0;
                nombre_campana['charola'] = 0;
                nombre_campana['sarteneta'] = 0;
                nombre_campana['arco'] = 0;
                nombre_campana['licencia'] = 0;
                nombre_campana['sonido'] = 0;
                nombre_campana['adicional'] = 0;
                nombre_campana['producto_suficiente'] = 0;
                nombre_campana['degustacion'] = 0;
                nombre_campana['adicional_campana'] = 0;
                nombre_campana['total_campana'] = 0;



          if (obj_grafica_campana['campana'].length>0){
            for (i=0; i<obj_grafica_campana['campana'].length; i++){ 
              var json_campana =  JSON.parse(obj_grafica_campana['campana'][i]['respuestas']);
              if (typeof json_campana == 'object'){
                nombre_campana['modulo']              += json_campana['modulo']               =='on'?1:0;
                nombre_campana['charola']             += json_campana['charola']              =='on'?1:0;
                nombre_campana['sarteneta']           += json_campana['sarteneta']            =='on'?1:0;
                nombre_campana['pop']                 += json_campana['pop']                  =='on'?1:0;
                nombre_campana['licencia']            += json_campana['licencia']             =='on'?1:0;
                nombre_campana['sonido']              += json_campana['sonido']               =='on'?1:0;
                nombre_campana['adicional']           += json_campana['adicional']            =='on'?1:0;
                nombre_campana['producto_suficiente'] += json_campana['producto_suficiente']  =='on'?1:0;
                nombre_campana['degustacion']         += json_campana['degustacion']          =='on'?1:0;
                nombre_campana['adicional_campana']   += json_campana['adicional_campana']    =='on'?1:0;   
                nombre_campana['total_campana']++;             
              }
            }

              

              //Remover las gráficas anteriores e insertar las nuevas
              $('#barChart').remove();
              $('#contChart').append('<canvas id="barChart" height="230"></canvas>');

                  barChartCanvas = $("#barChart").get(0).getContext("2d");
                  barChart = new Chart(barChartCanvas);
                  barChartData = areaChartData;
                  barChartData.datasets[0].fillColor = "#00a65a";
                  barChartData.datasets[0].strokeColor = "#00a65a";
                  barChartData.datasets[0].pointColor = "#00a65a";

              color_grafica_comparar= get_random_color();

              var modulo              =   nombre_campana['modulo'] > 0               && nombre_campana['total_campana'] > 0 ? (100 / nombre_campana['total_campana']) * nombre_campana['modulo']              :   0;
              var charola             =   nombre_campana['charola'] > 0              && nombre_campana['total_campana'] > 0 ? (100 / nombre_campana['total_campana']) * nombre_campana['charola']             :   0;
              var sarteneta           =   nombre_campana['sarteneta'] > 0            && nombre_campana['total_campana'] > 0 ? (100 / nombre_campana['total_campana']) * nombre_campana['sarteneta']           :   0;
              var arco                =   nombre_campana['arco'] > 0                 && nombre_campana['total_campana'] > 0 ? (100 / nombre_campana['total_campana']) * nombre_campana['arco']                :   0;
              var sonido              =   nombre_campana['sonido'] > 0               && nombre_campana['total_campana'] > 0 ? (100 / nombre_campana['total_campana']) * nombre_campana['sonido']              :   0;
              var adicional           =   nombre_campana['adicional'] > 0            && nombre_campana['total_campana'] > 0 ? (100 / nombre_campana['total_campana']) * nombre_campana['adicional']           :   0;
              var producto_suficiente =   nombre_campana['producto_suficiente'] > 0  && nombre_campana['total_campana'] > 0 ? (100 / nombre_campana['total_campana']) * nombre_campana['producto_suficiente'] :   0;
              var degustacion         =   nombre_campana['degustacion'] > 0          && nombre_campana['total_campana'] > 0 ? (100 / nombre_campana['total_campana']) * nombre_campana['degustacion']         :   0;
              var adicional_campana   =   nombre_campana['adicional_campana'] > 0    && nombre_campana['total_campana'] > 0 ? (100 / nombre_campana['total_campana']) * nombre_campana['adicional_campana']   :   0;


              barChartData.datasets[0]={
                  label: ["Todo"],
                  fillColor: "rgba("+color_grafica_comparar+", .6)",
                  strokeColor: "rgba("+color_grafica_comparar+", .6)",
                  pointColor: "rgba("+color_grafica_comparar+", .6)",
                  pointStrokeColor: "#c1c7d1",
                  pointHighlightFill: "#fff",
                  pointHighlightStroke: "rgba("+color_grafica_comparar+", .6)",
                  data: [
                          modulo.toFixed(1),
                          charola.toFixed(1),
                          sarteneta.toFixed(1),
                          arco.toFixed(1),
                          sonido.toFixed(1),
                          adicional.toFixed(1),
                          producto_suficiente.toFixed(1),
                          degustacion.toFixed(1),
                          adicional_campana.toFixed(1)]
              }

              //barChartData.datasets[j].data = [];
              window.barChartLegend = barChart.Bar(barChartData,barChartOptions);
              $("#barChartLegend").html(barChartLegend.generateLegend());
          }
          //console.log(r);
        }

        function parse_comunicacion(obj_comunicacion){
          var nombre_campana = [];

                nombre_campana['frase'] = 0;
                nombre_campana['argumentos'] = 0;
                nombre_campana['precio'] = 0;
                nombre_campana['total_campana'] = 0;


          if (obj_comunicacion['campana'].length>0){
            for (i=0; i<obj_comunicacion['campana'].length; i++){ 
              var json_campana =  JSON.parse(obj_comunicacion['campana'][i]['respuestas']);
              if (typeof json_campana == 'object'){
                nombre_campana['frase']       += json_campana['frase']      =='on'?1:0;
                nombre_campana['argumentos']  += json_campana['argumentos'] =='on'?1:0;
                nombre_campana['precio']      += json_campana['precio']     =='on'?1:0;
                nombre_campana['total_campana']++;
              }
            }
              
              //Remover gráfica
              $('#barChart2').remove();
              $('#contChart2').append('<canvas id="barChart2" height="230"></canvas>');

                  barChartCanvas2 = $("#barChart2").get(0).getContext("2d");
                  barChart2 = new Chart(barChartCanvas2);
                  barChartData2 = areaChartData2;
              
              color_grafica_comparar= get_random_color();

              barChartData2.datasets[0]={
                  label: ["Todo"],
                  fillColor: "rgba("+color_grafica_comparar+", .6)",
                  strokeColor: "rgba("+color_grafica_comparar+", .6)",
                  pointColor: "rgba("+color_grafica_comparar+", .6)",
                  pointStrokeColor: "#c1c7d1",
                  pointHighlightFill: "#fff",
                  pointHighlightStroke: "rgba("+color_grafica_comparar+", .6)",
                  data: [nombre_campana['frase'],nombre_campana['argumentos'],nombre_campana['precio']]
              }
              
              //barChartData2.datasets[j].data = [];
              window.barChart2Legend = barChart2.Radar(barChartData2,barChartOptions2);
              $("#barChart2Legend").html(barChart2Legend.generateLegend()); 



              $("#num-frase").html(nombre_campana['frase']);
              $("#num-precio").html(nombre_campana['precio']);
              $("#num-argumentos").html(nombre_campana['argumentos']);

              var valor_porcentaje = (100/nombre_campana['total_campana'])

              $("#small_frase").html("Total: "+nombre_campana['total_campana']);
              $("#progress-frase").css('width',(nombre_campana['frase']*valor_porcentaje).toFixed(1)+"%");
              $("#progress-num-frase").html((nombre_campana['frase']*valor_porcentaje).toFixed(1)+"%");

              $("#small_precio").html("Total: "+nombre_campana['total_campana']);
              $("#progress-precio").css('width',(nombre_campana['precio']*valor_porcentaje).toFixed(1)+"%");
              $("#progress-num-precio").html((nombre_campana['precio']*valor_porcentaje).toFixed(1)+"%");

              $("#small_argumentos").html("Total: "+nombre_campana['total_campana']);
              $("#progress-argumentos").css('width',(nombre_campana['argumentos']*valor_porcentaje).toFixed(1)+"%");
              $("#progress-num-argumentos").html((nombre_campana['argumentos']*valor_porcentaje).toFixed(1)+"%");
              
          }
          //console.log(r);



        }

        
        function separar_fechas(str_fecha){
          var r = [];
          var srt_split = [];

          var date = new Date();
          var day = date.getDate();
          var month = date.getMonth()+1;
          var year = date.getFullYear();

          var f='';

          if (month<10){
            month += "0"+month;
          }

          fechaActual = day+"/"+month+"/"+year;
          
          
          str_fecha = str_fecha||"-"
          
            var str_split = str_fecha.split("-");
            if (str_split.length>1){

              //Ordena el mes y el día de la fecha inicial
              var arr_f = str_split[0].split("/");

              if (arr_f.length>1){
                var f_aux = arr_f[1].trim();
                arr_f[1] = arr_f[0].trim();
                arr_f[0] = f_aux;

                str_split[0] = arr_f.join("/");
              }

                arr_f = null;


              //Ordena el mes y el día de la fecha final
              arr_f = str_split[1].split("/");
              
              if (arr_f.length>1){                
                f_aux = arr_f[1].trim();
                arr_f[1] = arr_f[0].trim();
                arr_f[0] = f_aux;

                str_split[1] = arr_f.join("/");
              }

              var re = /\d{2}\/\d{2}\/\d{4}/


              r[0] = (str_split[0].trim()).match(re) ? str_split[0].trim():fechaActual;
              r[1] = (str_split[1].trim()).match(re) ? str_split[1].trim():fechaActual;
            }else{
              r[0] = fechaActual;
              r[1] = fechaActual;
            }          


            console.log("Match: "+r[0].match(re));

            console.log("Fecha: "+r)
            return r
        }

        

        function parse_imagen(obj_imagen){
          var nombre_campana = [];

                nombre_campana['imagen_persona'] = 0;
                nombre_campana['congruencia'] = 0;
                nombre_campana['presentacion_producto'] = 0;
                nombre_campana['manejo_limpieza'] = 0;
                nombre_campana['total_campana'] = 0;


          if (obj_imagen['campana'].length>0){
            for (i=0; i<obj_imagen['campana'].length; i++){ 
              var json_campana =  JSON.parse(obj_imagen['campana'][i]['respuestas']);
              if (typeof json_campana == 'object'){
                nombre_campana['imagen_persona']        += json_campana['imagen_persona']         =='on'?1:0;
                nombre_campana['congruencia']           += json_campana['congruencia']            =='on'?1:0;
                nombre_campana['presentacion_producto'] += json_campana['presentacion_producto']  =='on'?1:0;
                nombre_campana['manejo_limpieza']       += json_campana['manejo_limpieza']        =='on'?1:0;
                nombre_campana['total_campana']++;
              }
            }
              

              //Remover las gráficas anteriores e insertar las nuevas
              $('#barChart3').remove();
              $('#contChart3').append('<canvas id="barChart3" height="230"></canvas>');

                  barChartCanvas3 = $("#barChart3").get(0).getContext("2d");
                  barChart3 = new Chart(barChartCanvas3);
                  barChartData3 = areaChartData3;


              color_grafica_comparar= get_random_color();

              barChartData3.datasets[0]={
                  label: ["Todo"],
                  fillColor: "rgba("+color_grafica_comparar+", .6)",
                  strokeColor: "rgba("+color_grafica_comparar+", .6)",
                  pointColor: "rgba("+color_grafica_comparar+", .6)",
                  pointStrokeColor: "#c1c7d1",
                  pointHighlightFill: "#fff",
                  pointHighlightStroke: "rgba("+color_grafica_comparar+", .6)",
                  data: [nombre_campana['imagen_persona'],nombre_campana['congruencia'],nombre_campana['presentacion_producto'],nombre_campana['manejo_limpieza']]
              }

            
              //barChartData3.datasets[j].data = [];
              window.barChart3Legend = barChart3.Radar(barChartData3,barChartOptions3);
              $("#barChart3Legend").html(barChart3Legend.generateLegend()); 


              $("#num-imagen-persona").html(nombre_campana['imagen_persona']);
              $("#num-producto-vta").html(nombre_campana['congruencia']);
              $("#num-marca").html(nombre_campana['manejo_limpieza']);
              $("#num-presentacion-producto").html(nombre_campana['presentacion_producto']);

              var valor_porcentaje = (100/nombre_campana['total_campana'])

              $("#small_imagen_persona").html("Total: "+nombre_campana['total_campana']);
              $("#progress-imagen-persona").css('width',(nombre_campana['imagen_persona']*valor_porcentaje).toFixed(1)+"%");
              $("#progress-num-imagen-persona").html((nombre_campana['imagen_persona']*valor_porcentaje).toFixed(1)+"%");

              $("#small_producto_vta").html("Total: "+nombre_campana['total_campana']);
              $("#progress-producto-vta").css('width',(nombre_campana['congruencia']*valor_porcentaje).toFixed(1)+"%");
              $("#progress-num-producto-vta").html((nombre_campana['congruencia']*valor_porcentaje).toFixed(1)+"%");

              $("#small_marca").html("Total: "+nombre_campana['total_campana']);
              $("#progress-marca").css('width',(nombre_campana['manejo_limpieza']*valor_porcentaje).toFixed(1)+"%");
              $("#progress-num-marca").html((nombre_campana['manejo_limpieza']*valor_porcentaje).toFixed(1)+"%");

              $("#small_presentacion_producto").html("Total: "+nombre_campana['total_campana']);
              $("#progress-presentacion-producto").css('width',(nombre_campana['presentacion_producto']*valor_porcentaje).toFixed(1)+"%");
              $("#progress-num-presentacion-producto").html((nombre_campana['presentacion_producto']*valor_porcentaje).toFixed(1)+"%");

            
          }
          //console.log(r);
        }


        function parse_encargado_grafica(obj_encargado_grafica){
          var nombre_campana = [];

                nombre_campana['puntualidad'] = 0;
                nombre_campana['abordaje']    = 0;
                nombre_campana['ubicacion']   = 0;
                nombre_campana['objetivo']    = 0;
                nombre_campana['total_campana'] = 0;


          if (obj_encargado_grafica['campana'].length>0){
            for (i=0; i<obj_encargado_grafica['campana'].length; i++){ 
              var json_campana =  JSON.parse(obj_encargado_grafica['campana'][i]['respuestas']);
              if (typeof json_campana == 'object'){
                nombre_campana['puntualidad']       += json_campana['puntualidad']  =='on'?1:0;
                nombre_campana['abordaje']          += json_campana['abordaje']     =='on'?1:0;
                nombre_campana['ubicacion']         += json_campana['ubicacion']    =='on'?1:0;
                nombre_campana['objetivo']          += json_campana['objetivo']     =='on'?1:0;
                nombre_campana['total_campana']++;
              }
            }
              

              //Remover las gráficas anteriores e insertar las nuevas
              $('#barChart4').remove();
              $('#contChart4').append('<canvas id="barChart4" height="230"></canvas>');

                  barChartCanvas4 = $("#barChart4").get(0).getContext("2d");
                  barChart4 = new Chart(barChartCanvas4);
                  barChartData4 = areaChartData4;


              color_grafica_comparar= get_random_color();

              barChartData4.datasets[0]={
                  label: ["Todo"],
                  fillColor: "rgba("+color_grafica_comparar+", .6)",
                  strokeColor: "rgba("+color_grafica_comparar+", .6)",
                  pointColor: "rgba("+color_grafica_comparar+", .6)",
                  pointStrokeColor: "#c1c7d1",
                  pointHighlightFill: "#fff",
                  pointHighlightStroke: "rgba("+color_grafica_comparar+", .6)",
                  data: [nombre_campana['puntualidad'],nombre_campana['abordaje'],nombre_campana['ubicacion'],nombre_campana['objetivo']]
              }

            
              //barChartData4.datasets[j].data = [];
              window.barChart4Legend = barChart4.Radar(barChartData4,barChartOptions4);
              $("#barChart4Legend").html(barChart4Legend.generateLegend()); 

              //Modificar valores de Info encargados
              $("#num-puntualidad").html(nombre_campana['puntualidad']);
              $("#num-abordaje").html(nombre_campana['abordaje']);
              $("#num-ubicacion").html(nombre_campana['ubicacion']);
              $("#num-objetivo").html(nombre_campana['objetivo']);

              var valor_porcentaje = (100/nombre_campana['total_campana'])

              $("#small_puntualidad").html("Total: "+nombre_campana['total_campana']);
              $("#progress-puntualidad").css('width',(nombre_campana['puntualidad']*valor_porcentaje).toFixed(1)+"%");
              $("#progress-num-puntualidad").html((nombre_campana['puntualidad']*valor_porcentaje).toFixed(1)+"%");

              $("#small_abordaje").html("Total: "+nombre_campana['total_campana']);
              $("#progress-abordaje").css('width',(nombre_campana['abordaje']*valor_porcentaje).toFixed(1)+"%");
              $("#progress-num-abordaje").html((nombre_campana['abordaje']*valor_porcentaje).toFixed(1)+"%"); 

              $("#small_ubicacion").html("Total: "+nombre_campana['total_campana']);
              $("#progress-ubicacion").css('width',(nombre_campana['ubicacion']*valor_porcentaje).toFixed(1)+"%");
              $("#progress-num-ubicacion").html((nombre_campana['ubicacion']*valor_porcentaje).toFixed(1)+"%");

              $("#small_objetivo").html("Total: "+nombre_campana['total_campana']);
              $("#progress-objetivo").css('width',(nombre_campana['objetivo']*valor_porcentaje).toFixed(1)+"%");
              $("#progress-num-objetivo").html((nombre_campana['objetivo']*valor_porcentaje).toFixed(1)+"%");
            
          }
          
        }


        function parse_encargados_grafica(obj_encargado_grafica){
          var nombre_campana = [];
          var persona_campana = [];

          //contenedor = contenedor || $('#campana');
          nombre_usuarios = JSON.parse(r_datos({funcion:'get_all_usuario_nombre'}));
          
          arr_nombres = {};
          arr_nombres['nombres'] = [];
          arr_nombres['ids'] = [];

          (nombre_usuarios.usuario_id).forEach(function(e,i){
            arr_nombres['nombres'].push(nombre_usuarios.usuario_name[i]);
            arr_nombres['ids'].push(nombre_usuarios.usuario_id[i]);
          })

                
//console.log(obj_encargado_grafica);
          if (obj_encargado_grafica['campana'].length>0){

            for (i=0; i<obj_encargado_grafica['campana'].length; i++){ 
              var json_campana =  JSON.parse(obj_encargado_grafica['campana'][i]['respuestas']);
              if (typeof json_campana == 'object'){

                //Comprobar si no esiste el usuario en el arrego
                if (json_campana['persona_evento']!='' && json_campana['persona_evento']!=0 && typeof json_campana['persona_evento']!='undefined'){

                    persona_evento = json_campana['persona_evento']     != '' ? get_usuario_nombres(arr_nombres,json_campana['persona_evento']) : ''; 
                    persona_evento[0] = typeof persona_evento[0] != 'undefined'? persona_evento[0] : 'otros';
                    
                  if(persona_campana.indexOf(persona_evento[0]) == -1){
                    persona_campana[nombre_campana.length]=persona_evento[0];

                    var color = get_random_color();
//console.log(color);
                    nombre_campana[nombre_campana.length]={value:1,color: "rgba("+color+", 1)",highlight: "rgba("+color+", 1)",label:persona_evento};
                  }else{                   
                    //Si existe el usuario sumar los valores a los ya existentes
//console.log(persona_evento[0]);
                    nombre_campana[persona_campana.indexOf(persona_evento[0])].value++;

                     
                  }
                }             

              }
            }

//console.log(persona_campana);              
//console.log(nombre_campana);

              //Remover las gráficas anteriores e insertar las nuevas
              $('#pieChart').remove();
              $('#contChartPie').append('<canvas id="pieChart" height="230"></canvas>');

                  pieChartCanvas = $("#pieChart").get(0).getContext("2d");
                  pieChart = new Chart(pieChartCanvas);
                  //pieChartData = areaChartDataPie;
                  pieChartData = nombre_campana;

//console.log(areaChartDataPie);


              //color_grafica_comparar= get_random_color();

              /*pieChartData.datasets[0]={
                  label: ["Todo"],
                  fillColor: "rgba("+color_grafica_comparar+", .6)",
                  strokeColor: "rgba("+color_grafica_comparar+", .6)",
                  pointColor: "rgba("+color_grafica_comparar+", .6)",
                  pointStrokeColor: "#c1c7d1",
                  pointHighlightFill: "#fff",
                  pointHighlightStroke: "rgba("+color_grafica_comparar+", .6)",
                  data: [nombre_campana['puntualidad'],nombre_campana['abordaje'],nombre_campana['ubicacion'],nombre_campana['objetivo']]
              }*/

            
              //pieChartData.datasets[j].data = [];
              window.pieChartLegend = pieChart.Doughnut(pieChartData,pieChartOptions);
              $("#pieChartLegend").html(pieChartLegend.generateLegend()); 

            
          }
          //console.log(r);
        }


        function parse_tiendas_activas(obj_tiendas_activas){

          var nombre_campana = [];

                nombre_campana['tienda_activada'] = 0;
                nombre_campana['tienda_no_activada'] = 0;
                nombre_campana['total_tiendas'] = 0;

          



          if (obj_tiendas_activas['campana'].length>0){

            for (i=0; i<obj_tiendas_activas['campana'].length; i++){ 
              var json_campana =  JSON.parse(obj_tiendas_activas['campana'][i]['respuestas']);
              if (typeof json_campana == 'object'){
                nombre_campana['tienda_activada']              += json_campana['tienda_activada']            =='on'?1:0; 
                nombre_campana['tienda_no_activada']           += json_campana['tienda_activada']            =='on'?0:1;    
                nombre_campana['total_tiendas']++;           
              }
            }


            var tiendas_no_activadas = nombre_campana['total_tiendas']>0   ? (+nombre_campana['tienda_no_activada']*(100/+nombre_campana['total_tiendas'])).toFixed(0) :   0;
            var tiendas_activas      = nombre_campana['total_tiendas']>0   ? (+nombre_campana['tienda_activada']*(100/+nombre_campana['total_tiendas'])).toFixed(0)    :   0;
            
            

            var pieChartDataPie5 = [
              {
                value: (+tiendas_activas),
                color: "#f56954",
                highlight: "#f56954",
                label: "Activadas"
              },
              {
                value: (+tiendas_no_activadas),
                color: "#00a65a",
                highlight: "#00a65a",
                label: "No Activadas"
              }
            ];

              

              //Remover las gráficas anteriores e insertar las nuevas
              $('#pieChart5').remove();
              $('#contChart5').append('<canvas id="pieChart5" height="230"></canvas>');

                  pieChartCanvas5 = $("#pieChart5").get(0).getContext("2d");
                  pieChart5 = new Chart(pieChartCanvas5);
                  pieChartData5 = pieChartDataPie5;
                  console.log(pieChartDataPie5);

              //color_grafica_comparar= get_random_color();


              //pieChartData.datasets[j].data = [];
              window.pieChart5Legend = pieChart5.Doughnut(pieChartData5,pieChartOptions5);
              $("#pieChart5Legend").html(pieChart5Legend.generateLegend());
          }
         
        }


        function parse_buscar(obj_buscar, id_campana, evaluador, encargado, fecha){
          
          var nombre_campana  = [];
          var fecha_inicio    = Date.parse(separar_fechas(fecha)[0]);
          var fecha_fin       = Date.parse(separar_fechas(fecha)[1]);
          var nombre = '';

          console.log("Fecha inicio: " + fecha_inicio);

                nombre_campana['modulo']              = 0;
                nombre_campana['charola']             = 0;
                nombre_campana['sarteneta']           = 0;
                nombre_campana['arco']                = 0;
                nombre_campana['licencia']            = 0;
                nombre_campana['sonido']              = 0;
                nombre_campana['adicional']           = 0;
                nombre_campana['producto_suficiente'] = 0;
                nombre_campana['degustacion']         = 0;
                nombre_campana['adicional_campana']   = 0;


                nombre_campana['frase']               = 0;
                nombre_campana['argumentos']          = 0;
                nombre_campana['precio']              = 0;


                nombre_campana['imagen_persona']        = 0;
                nombre_campana['congruencia']           = 0;
                nombre_campana['presentacion_producto'] = 0;
                nombre_campana['manejo_limpieza']       = 0;

                nombre_campana['puntualidad']         = 0;
                nombre_campana['abordaje']            = 0;
                nombre_campana['ubicacion']           = 0;
                nombre_campana['objetivo']            = 0;



          if (obj_buscar['campana'].length>0){
            for (i=0; i<obj_buscar['campana'].length; i++){ 
              var json_campana =  JSON.parse(obj_buscar['campana'][i]['respuestas']);
              var json_id      =  JSON.parse(obj_buscar['campana'][i]['id_respuesta']);


              //Campaña

              if (typeof json_campana == 'object'){
                if((json_id==id_campana||id_campana==0) && (json_campana['nombre_evaluador']==evaluador||evaluador==0) && (json_campana['persona_evento']==encargado||encargado==0) && (Date.parse(json_campana['fecha'])>=fecha_inicio&&Date.parse(json_campana['fecha'])<=fecha_fin)){
                  nombre_campana['modulo']              += json_campana['modulo']               =='on'?1:0;
                  nombre_campana['charola']             += json_campana['charola']              =='on'?1:0;
                  nombre_campana['sarteneta']           += json_campana['sarteneta']            =='on'?1:0;
                  nombre_campana['pop']                 += json_campana['pop']                  =='on'?1:0;
                  nombre_campana['licencia']            += json_campana['licencia']             =='on'?1:0;
                  nombre_campana['sonido']              += json_campana['sonido']               =='on'?1:0;
                  nombre_campana['adicional']           += json_campana['adicional']            =='on'?1:0;
                  nombre_campana['producto_suficiente'] += json_campana['producto_suficiente']  =='on'?1:0;
                  nombre_campana['degustacion']         += json_campana['degustacion']          =='on'?1:0;
                  nombre_campana['adicional_campana']   += json_campana['adicional_campana']    =='on'?1:0;


                  nombre_campana['frase']       += json_campana['frase']      !='on'?1:0;
                  nombre_campana['argumentos']  += json_campana['argumentos'] !='on'?1:0;
                  nombre_campana['precio']      += json_campana['precio']     !='on'?1:0;


                  nombre_campana['imagen_persona']        += json_campana['imagen_persona']         =='on'?1:0;
                  nombre_campana['congruencia']           += json_campana['congruencia']            =='on'?1:0;
                  nombre_campana['presentacion_producto'] += json_campana['presentacion_producto']  =='on'?1:0;
                  nombre_campana['manejo_limpieza']       += json_campana['manejo_limpieza']        =='on'?1:0;


                  nombre_campana['puntualidad']       += json_campana['puntualidad']  =='on'?1:0;
                  nombre_campana['abordaje']          += json_campana['abordaje']     =='on'?1:0;
                  nombre_campana['ubicacion']         += json_campana['ubicacion']    =='on'?1:0;
                  nombre_campana['objetivo']          += json_campana['objetivo']     =='on'?1:0;
                }               
              }
            }
              
              nombre  = "Encontrado";
              j=0;

              //Remover las gráficas anteriores e insertar las nuevas
              $('#barChart').remove();
              $('#contChart').append('<canvas id="barChart" height="230"></canvas>');

                  barChartCanvas = $("#barChart").get(0).getContext("2d");
                  barChart = new Chart(barChartCanvas);
                  barChartData = areaChartData;
                  barChartData.datasets[0].fillColor = "#00a65a";
                  barChartData.datasets[0].strokeColor = "#00a65a";
                  barChartData.datasets[0].pointColor = "#00a65a";

              $('#barChart2').remove();
              $('#contChart2').append('<canvas id="barChart2" height="230"></canvas>');

                  barChartCanvas2 = $("#barChart2").get(0).getContext("2d");
                  barChart2 = new Chart(barChartCanvas2);
                  barChartData2 = areaChartData2;
                  
              $('#barChart3').remove();
              $('#contChart3').append('<canvas id="barChart3" height="230"></canvas>');

                  barChartCanvas3 = $("#barChart3").get(0).getContext("2d");
                  barChart3 = new Chart(barChartCanvas3);
                  barChartData3 = areaChartData3;

              //Remover las gráficas anteriores e insertar las nuevas
              $('#barChart4').remove();
              $('#contChart4').append('<canvas id="barChart4" height="230"></canvas>');

                  barChartCanvas4 = $("#barChart4").get(0).getContext("2d");
                  barChart4 = new Chart(barChartCanvas4);
                  barChartData4 = areaChartData4;


              color_grafica_comparar= get_random_color();

              barChartData.datasets[j]={
                  label: [nombre],
                  fillColor: "rgba("+color_grafica_comparar+", .6)",
                  strokeColor: "rgba("+color_grafica_comparar+", .6)",
                  pointColor: "rgba("+color_grafica_comparar+", .6)",
                  pointStrokeColor: "#c1c7d1",
                  pointHighlightFill: "#fff",
                  pointHighlightStroke: "rgba("+color_grafica_comparar+", .6)",
                  data: [nombre_campana['modulo'],nombre_campana['charola'],nombre_campana['sarteneta'],nombre_campana['arco'],nombre_campana['sonido'],nombre_campana['adicional'],nombre_campana['producto_suficiente'],nombre_campana['degustacion'],nombre_campana['adicional_campana']]
              }

              barChartData2.datasets[j]={
                  label: [nombre],
                  fillColor: "rgba("+color_grafica_comparar+", .6)",
                  strokeColor: "rgba("+color_grafica_comparar+", .6)",
                  pointColor: "rgba("+color_grafica_comparar+", .6)",
                  pointStrokeColor: "#c1c7d1",
                  pointHighlightFill: "#fff",
                  pointHighlightStroke: "rgba("+color_grafica_comparar+", .6)",
                  data: [nombre_campana['frase'],nombre_campana['argumentos'],nombre_campana['precio']]
              }

              barChartData3.datasets[j]={
                  label: [nombre],
                  fillColor: "rgba("+color_grafica_comparar+", .6)",
                  strokeColor: "rgba("+color_grafica_comparar+", .6)",
                  pointColor: "rgba("+color_grafica_comparar+", .6)",
                  pointStrokeColor: "#c1c7d1",
                  pointHighlightFill: "#fff",
                  pointHighlightStroke: "rgba("+color_grafica_comparar+", .6)",
                  data: [nombre_campana['imagen_persona'],nombre_campana['congruencia'],nombre_campana['presentacion_producto'],nombre_campana['manejo_limpieza']]
              }

              barChartData4.datasets[j]={
                  label: ["Todo"],
                  fillColor: "rgba("+color_grafica_comparar+", .6)",
                  strokeColor: "rgba("+color_grafica_comparar+", .6)",
                  pointColor: "rgba("+color_grafica_comparar+", .6)",
                  pointStrokeColor: "#c1c7d1",
                  pointHighlightFill: "#fff",
                  pointHighlightStroke: "rgba("+color_grafica_comparar+", .6)",
                  data: [nombre_campana['puntualidad'],nombre_campana['abordaje'],nombre_campana['ubicacion'],nombre_campana['objetivo']]
              }

              
              
              //barChartData.datasets[j].data = [];
              window.barChartLegend = barChart.Bar(barChartData,barChartOptions);
              $("#barChartLegend").html(barChartLegend.generateLegend()); 
            
              //barChartData2.datasets[j].data = [];
              window.barChart2Legend = barChart2.Radar(barChartData2,barChartOptions2);
              $("#barChart2Legend").html(barChart2Legend.generateLegend()); 
              
            
              //barChartData3.datasets[j].data = [];
              window.barChart3Legend = barChart3.Radar(barChartData3,barChartOptions3);
              $("#barChart3Legend").html(barChart3Legend.generateLegend());

              //barChartData4.datasets[j].data = [];
              window.barChart4Legend = barChart4.Radar(barChartData4,barChartOptions4);
              $("#barChart4Legend").html(barChart4Legend.generateLegend()); 
            
          }
          //console.log(r);
        }

        function get_usuario_nombre(id_usuario){
          id_usuario = id_usuario || 0;
          nombre = JSON.parse(r_datos({funcion:'get_usuario_nombre',id:id_usuario}));          
          return nombre['usuario_name']
        }

        

        function parse_comparar(obj_comparar, id_campana, evaluador, encargado, fecha, ids){
          
          var nombre_campana  = [];
          var fecha_inicio    = Date.parse(separar_fechas(fecha)[0]);
          var fecha_fin       = Date.parse(separar_fechas(fecha)[1]);

          console.log("length: "+ids.length);
          console.log("Fecha inicio: " + fecha_inicio);


                


          //Por cada seleccion analiza cada campaña
          for (j=0; j<ids.length; j++){

               


                //Inicializar las variables en 0
                nombre_campana['nombre']              = '';
                nombre_campana['modulo']              = 0;
                nombre_campana['charola']             = 0;
                nombre_campana['sarteneta']           = 0;
                nombre_campana['arco']                = 0;
                nombre_campana['licencia']            = 0;
                nombre_campana['sonido']              = 0;
                nombre_campana['adicional']           = 0;
                nombre_campana['producto_suficiente'] = 0;
                nombre_campana['degustacion']         = 0;
                nombre_campana['adicional_campana']   = 0;


                nombre_campana['frase']               = 0;
                nombre_campana['argumentos']          = 0;
                nombre_campana['precio']              = 0;


                nombre_campana['imagen_persona']        = 0;
                nombre_campana['congruencia']           = 0;
                nombre_campana['presentacion_producto'] = 0;
                nombre_campana['manejo_limpieza']       = 0;


                nombre_campana['puntualidad']         = 0;
                nombre_campana['abordaje']            = 0;
                nombre_campana['ubicacion']           = 0;
                nombre_campana['objetivo']            = 0;
                

                  //Por cada campaña recoge un valor
            if (obj_comparar['campana'].length>0){
              for (i=0; i<obj_comparar['campana'].length; i++){ 
                var json_campana =  JSON.parse(obj_comparar['campana'][i]['respuestas']);

                var json_id;


                //Si el campo de tipo es igual a cero, json_id=0, si no camptura el 'id' del usuario
                if ($('#tipo_seleccion').val()=='0'){
                  json_id = 0;
                }else if($('#tipo_seleccion').val()=='1'){
                  json_id = JSON.parse(obj_comparar['campana'][i]['id_respuesta']);
                }else if($('#tipo_seleccion').val()=='2'){
                  json_id = json_campana['nombre_evaluador'];                  
                }else if($('#tipo_seleccion').val()=='3'){                  
                  json_id  = json_campana['persona_evento'];
                }

                      


                //Campaña

                if (typeof json_campana == 'object'){

                  console.log( "("+Date.parse(json_campana['fecha'])+">="+fecha_inicio+"&&"+Date.parse(json_campana['fecha'])+"<="+fecha_fin);

                  
                  if((json_id==ids[j]) && (Date.parse(json_campana['fecha'])>=fecha_inicio&&Date.parse(json_campana['fecha'])<=fecha_fin)){

                    nombre_campana['nombre_campana']      =  json_campana['modulo']                !='' ?json_campana['nombre_campana'] :'';

                    nombre_campana['modulo']              += json_campana['modulo']               =='on'?1:0;
                    nombre_campana['charola']             += json_campana['charola']              =='on'?1:0;
                    nombre_campana['sarteneta']           += json_campana['sarteneta']            =='on'?1:0;
                    nombre_campana['arco']                += json_campana['arco']                 =='on'?1:0;
                    nombre_campana['sonido']              += json_campana['sonido']               =='on'?1:0;
                    nombre_campana['adicional']           += json_campana['adicional']            =='on'?1:0;
                    nombre_campana['producto_suficiente'] += json_campana['producto_suficiente']  =='on'?1:0;
                    nombre_campana['degustacion']         += json_campana['degustacion']          =='on'?1:0;
                    nombre_campana['adicional_campana']   += json_campana['adicional_campana']    =='on'?1:0;


                    nombre_campana['frase']       += json_campana['frase']      !='on'?1:0;
                    nombre_campana['argumentos']  += json_campana['argumentos'] !='on'?1:0;
                    nombre_campana['precio']      += json_campana['precio']     !='on'?1:0;


                    nombre_campana['imagen_persona']        += json_campana['imagen_persona']         =='on'?1:0;
                    nombre_campana['congruencia']           += json_campana['congruencia']            =='on'?1:0;
                    nombre_campana['presentacion_producto'] += json_campana['presentacion_producto']  =='on'?1:0;
                    nombre_campana['manejo_limpieza']       += json_campana['manejo_limpieza']        =='on'?1:0;


                    nombre_campana['puntualidad']       += json_campana['puntualidad']  =='on'?1:0;
                    nombre_campana['abordaje']          += json_campana['abordaje']     =='on'?1:0;
                    nombre_campana['ubicacion']         += json_campana['ubicacion']    =='on'?1:0;
                    nombre_campana['objetivo']          += json_campana['objetivo']     =='on'?1:0;

                    
                  }               
                }

              }

               //Si el campo de tipo es igual a cero, json_id=0, si no camptura el 'id' del usuario
                    if ($('#tipo_seleccion').val()=='0'){
                      nombre = '';
                    }else if($('#tipo_seleccion').val()=='1'){
                      nombre  = nombre_campana['nombre_campana'];
                    }else if($('#tipo_seleccion').val()=='2'){
                      nombre  = get_usuario_nombre(ids[j])||''
                    }else if($('#tipo_seleccion').val()=='3'){
                      nombre = get_usuario_nombre(ids[j])||''
                    }

              
              

              //Remover las gráficas anteriores e insertar las nuevas
              $('#barChart').remove();
              $('#contChart').append('<canvas id="barChart" height="230"></canvas>');

                  barChartCanvas = $("#barChart").get(0).getContext("2d");
                  barChart = new Chart(barChartCanvas);
                  barChartData = areaChartData;
                  barChartData.datasets[0].fillColor = "#00a65a";
                  barChartData.datasets[0].strokeColor = "#00a65a";
                  barChartData.datasets[0].pointColor = "#00a65a";

              $('#barChart2').remove();
              $('#contChart2').append('<canvas id="barChart2" height="230"></canvas>');

                  barChartCanvas2 = $("#barChart2").get(0).getContext("2d");
                  barChart2 = new Chart(barChartCanvas2);
                  barChartData2 = areaChartData2;
                  
              $('#barChart3').remove();
              $('#contChart3').append('<canvas id="barChart3" height="230"></canvas>');

                  barChartCanvas3 = $("#barChart3").get(0).getContext("2d");
                  barChart3 = new Chart(barChartCanvas3);
                  barChartData3 = areaChartData3;

              //Remover las gráficas anteriores e insertar las nuevas
              $('#barChart4').remove();
              $('#contChart4').append('<canvas id="barChart4" height="230"></canvas>');

                  barChartCanvas4 = $("#barChart4").get(0).getContext("2d");
                  barChart4 = new Chart(barChartCanvas4);
                  barChartData4 = areaChartData4;


              color_grafica_comparar= get_random_color();

              barChartData.datasets[j]={
                  label: [nombre],
                  fillColor: "rgba("+color_grafica_comparar+", .6)",
                  strokeColor: "rgba("+color_grafica_comparar+", .6)",
                  pointColor: "rgba("+color_grafica_comparar+", .6)",
                  pointStrokeColor: "#c1c7d1",
                  pointHighlightFill: "#fff",
                  pointHighlightStroke: "rgba("+color_grafica_comparar+", .6)",
                  data: [nombre_campana['modulo'],nombre_campana['charola'],nombre_campana['sarteneta'],nombre_campana['arco'],nombre_campana['sonido'],nombre_campana['adicional'],nombre_campana['producto_suficiente'],nombre_campana['degustacion'],nombre_campana['adicional_campana']]
              }

              barChartData2.datasets[j]={
                  label: [nombre],
                  fillColor: "rgba("+color_grafica_comparar+", .6)",
                  strokeColor: "rgba("+color_grafica_comparar+", .6)",
                  pointColor: "rgba("+color_grafica_comparar+", .6)",
                  pointStrokeColor: "#c1c7d1",
                  pointHighlightFill: "#fff",
                  pointHighlightStroke: "rgba("+color_grafica_comparar+", .6)",
                  data: [nombre_campana['frase'],nombre_campana['argumentos'],nombre_campana['precio']]
              }

              barChartData3.datasets[j]={
                  label: [nombre],
                  fillColor: "rgba("+color_grafica_comparar+", .6)",
                  strokeColor: "rgba("+color_grafica_comparar+", .6)",
                  pointColor: "rgba("+color_grafica_comparar+", .6)",
                  pointStrokeColor: "#c1c7d1",
                  pointHighlightFill: "#fff",
                  pointHighlightStroke: "rgba("+color_grafica_comparar+", .6)",
                  data: [nombre_campana['imagen_persona'],nombre_campana['congruencia'],nombre_campana['presentacion_producto'],nombre_campana['manejo_limpieza']]
              }

              barChartData4.datasets[j]={
                  label: ["Todo"],
                  fillColor: "rgba("+color_grafica_comparar+", .6)",
                  strokeColor: "rgba("+color_grafica_comparar+", .6)",
                  pointColor: "rgba("+color_grafica_comparar+", .6)",
                  pointStrokeColor: "#c1c7d1",
                  pointHighlightFill: "#fff",
                  pointHighlightStroke: "rgba("+color_grafica_comparar+", .6)",
                  data: [nombre_campana['puntualidad'],nombre_campana['abordaje'],nombre_campana['ubicacion'],nombre_campana['objetivo']]
              }


              
              
              //barChartData.datasets[j].data = [];
              window.barChartLegend = barChart.Bar(barChartData,barChartOptions);
              $("#barChartLegend").html(barChartLegend.generateLegend()); 
            
              //barChartData2.datasets[j].data = [];
              window.barChart2Legend = barChart2.Radar(barChartData2,barChartOptions2);
              $("#barChart2Legend").html(barChart2Legend.generateLegend()); 
              
            
              //barChartData3.datasets[j].data = [];
              window.barChart3Legend = barChart3.Radar(barChartData3,barChartOptions3);
              $("#barChart3Legend").html(barChart3Legend.generateLegend()); 

              //barChartData4.datasets[j].data = [];
              window.barChart4Legend = barChart4.Radar(barChartData4,barChartOptions4);
              $("#barChart4Legend").html(barChart4Legend.generateLegend()); 
              
            }

            
          }

          

        }

        function buscar(){
          var campana   = $('#campana').val();
          var evaluador = $('#evaluador').val();
          var encargado = $('#encargado').val();
          var fecha     = $('#range').val();

          buscar_c = JSON.parse(r_datos({funcion:'get_buscar'}));
          parse_buscar(buscar_c,campana,evaluador,encargado,fecha);
        }

        function comparar(){
          var campana   = $('#campana').val();
          var evaluador = $('#evaluador').val();
          var encargado = $('#encargado').val();
          var fecha     = $('#range').val();
          //var ids       = $('#tipo_seleccion').val([]);
          var ids = $( "#opciones_seleccion" ).val() || [];

          
          comparar_c = JSON.parse(r_datos({funcion:'get_comparar'}));
          parse_comparar(comparar_c,campana,evaluador,encargado,fecha,ids);

          return false;
        }

        function parse_change_opciones_seleccion(opciones){
          var opciones = opciones || [];
          if (obj_campana['campana'].length>0){
            $('#opciones_seleccion').html('<option value="0">Selecciona...</option>');
            for (i=0; i<obj_campana['campana'].length; i++){

              var json_campana =  JSON.parse(obj_campana['campana'][i]['nombre']);
              var json_id      =  JSON.parse(obj_campana['campana'][i]['id']);
              
              if (typeof json_campana == 'object'){
                var nombre  = json_campana['opciones_nombre'];
                var id      = json_campana['opciones_id'];
                $('#opciones_seleccion').append("<option value='"+id+"''>"+nombre+"</option>");
              }              
            }

          }
        }

        function change_opciones_seleccion(){

          var id_tipo = $("#tipo_seleccion").val();

          if(id_tipo == 1){
            campana = JSON.parse(r_datos({funcion:'get_campana'}));
            parse_campana(campana, $('#opciones_seleccion'));
          }
          if(id_tipo == 2){
            evaluador = JSON.parse(r_datos({funcion:'get_evaluador'}));
            parse_evaluador(evaluador, $('#opciones_seleccion'));
          }
          if(id_tipo == 3){
            encargado = JSON.parse(r_datos({funcion:'get_encargado'}));
            parse_encargado(encargado, $('#opciones_seleccion'));
          }

        }

        $('#btn_buscar').on('click',function(){
          console.log("Buscando");
          buscar();
        })

        $('#btn_comparar').on('click',function(){
          console.log("Buscando");

          comparar();
          return false;
        })

        $('#tipo_seleccion').on('change',function(){
          console.log("Buscando");
          change_opciones_seleccion();
        })

        function inic_campana(){
          campana = JSON.parse(r_datos({funcion:'get_campana'}));
          parse_campana(campana);
        }

        function inic_evaluador(){
          evaluador = JSON.parse(r_datos({funcion:'get_evaluador'}));
          parse_evaluador(evaluador);
        }

        function inic_encargado(){
          encargado = JSON.parse(r_datos({funcion:'get_encargado'}));
          parse_encargado(encargado);
        }

        function inic_grafica_campana(){
          grafica_campana = JSON.parse(r_datos({funcion:'get_grafica_campana'}));
          parse_grafica_campana(grafica_campana);
        }

        function inic_encargado_grafica(){
          encargado_grafica = JSON.parse(r_datos({funcion:'get_encargado_grafica'}));
          parse_encargado_grafica(encargado_grafica);
        }

        function inic_encargados_grafica(){
          encargados_grafica = JSON.parse(r_datos({funcion:'get_encargados_grafica'}));
          parse_encargados_grafica(encargados_grafica);
        }

        function inic_tiendas_activas(){
          tiendas_activas = JSON.parse(r_datos({funcion:'get_tiendas_activas'}));
          parse_tiendas_activas(tiendas_activas);
        }

        function inic_comunicacion(){
          comunicacion = JSON.parse(r_datos({funcion:'get_comunicacion'}));
          parse_comunicacion(comunicacion);
        }

        function inic_imagen(){
          imagen = JSON.parse(r_datos({funcion:'get_imagen'}));
          parse_imagen(imagen);
        }

        

        function inic(){
          inic_campana();
          inic_evaluador();
          inic_encargado();
          inic_grafica_campana();
          inic_comunicacion();
          inic_imagen()
          inic_encargado_grafica();
          inic_encargados_grafica();
          inic_tiendas_activas();
        }

        inic();


    })
  </script>

</body>
<?php
}
else if($_SESSION['permiso']!='auditor'){
?>
<script>
alert("tu no tienes permiso para ver este contenido");
document.location.href="index.php?command=home";
</script>
<?php
}
?>