<?php
require_once 'class/class.db.php';

//session_start();
if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){

$mes=['','Enero','Febrero','Marzo','Abril','Mayo','Junio','Julio','Agosto','Septiembre','Octubre','Noviembre','Diciembre'];
$mes_corto=['','Ene','Feb','Mar','Abr','May','Jun','Jul','Ago','Sep','Oct','Nov','Dic'];
$dia=['Lunes', 'Martes','Miércoles','Jueves','Viernes','Sábado','Domingo'];
$dia_corto=['Lun', 'Mar','Mie','Jue','Vie','Sab','Dom']

?>
  <body class="skin-blue sidebar-mini">
    <div class="wrapper">
        <style>

            .porcentaje_principal{
                text-align: center;
                color: #666;
                font-size: 70px;
                font-weight: bolder;
            }


            #aprobadas_chart3 .box-body{
                text-align: center;
                border:1px solid #666;
            }
            #aprobadas_chart3 .box-body img{
                max-width:  150px;
                max-height: 150px;
            }

        </style>

      <script>

      function r_datos(options){
          
            params=(options==typeof(undefined))?'':$.extend( {}, options);
                var datos = $.ajax({
                    url:'class/class.cuestionario1.php',
                    type:'post',
                    dataType:'json',
                    data:params,
                    async:false       
                }).responseText;
            //console.log(datos)
            return datos
        }

        var datos_chart = [];




        $(function(){

        
        



        });

      </script>
      
      <?php require "views/directivos/header_directivo.php"; ?>

      <?php require "views/directivos/menu_vertical.php"; ?>

      <!-- Content Wrapper. Contains page content -->
      <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Dashboard
            <small>Version 3.0</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li class="active">Dashboard</li>
          </ol>
        </section>

        
        <!-- Main content -->
        <section class="content">

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
                                        <!-- <select name="tipo_seleccion" id="tipo_seleccion" class="form-control">
                                            <option value="0">Selecciona...</option>
                                            <option value="1">Campaña</option>
                                            <option value="2">Evaluador</option>
                                            <option value="3">Encargado</option>

                                        </select> -->
                                        <div class="form-control">Encargado</div>
                                        <input type="hidden" name="tipo_seleccion" id="tipo_seleccion" value="3">
                                    </div>
                                </div>

                                <div class="form-group row">  
                                    <label class="col-md-2 col-sm-2 col-xs-12">&nbsp;</label> 
                                    <div class="col-md-5 col-sm-8 col-xs-12">
                                        <select name="opciones_seleccion" id="opciones_seleccion" class="form-control">
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
                        </div>

                    </div>
                </div>
            </div>


            <!-- Row boxes -->
            <div class="row">
                <div class="col-md-6 col-sm-6 col-xs-12">

                    <div class="box box-success">
                        <div class="box-header width-border">
                            <h3 class="box-title">Porcentaje de Activaciones</h3>
                            <div class="box-tool pull-right">
                                <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                            </div>
                        </div>
                        <div class="box-body">
                            <div class="col-md-12 col-sm-12 col-xs-12" id="contChart1">
                              <canvas id="chart1" height="250"></canvas> 
                              <div class="legend" id="pieChartLegend1"></div>
                            </div>
                        </div>

                        <div class="box-footer">

                        </div>
                    </div>
                  
                </div><!-- /.col -->

                <div class="col-md-6 col-sm-6 col-xs-12" >

                    <div class="box box-success">
                        <div class="box-header width-border">
                            <h3 class="box-title">Cuantitativa</h3>
                            <div class="box-tool pull-right">
                                <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                            </div>
                        </div>
                        <div class="box-body">
                            <div class="col-md-12 col-sm-12 col-xs-12" id="contChart2">
                              <!-- <canvas id="chart2" height="250"></canvas> -->
                            <div id="porcentaje_chart2" class="col-md-12 col-sm-12 col-xs-12 porcentaje_principal"></div>

                                <div id="aprobadas_chart2" class="col-md-6 col-sm-6 col-xs-12">
                                    <div class="box-header">
                                        <h4>Aprobados</h4>
                                    </div>
                                    <div class="box-body">
                                    </div>
                                </div>
                                <div id="noAprobadas_chart2" class="col-md-6 col-sm-6 col-xs-12">
                                    <div class="box-header">
                                        <h4>No aprobados</h4>
                                    </div>
                                    <div class="box-body">
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="box-footer">

                        </div>
                    </div>
                  
                </div><!-- /.col -->
            </div><!-- /.row -->

            <!-- Row boxes -->
            <div class="row">
               
                <div class="col-md-6 col-sm-6 col-xs-12">

                    <div class="box box-success">
                        <div class="box-header width-border">
                            <h3 class="box-title">Cualitativa</h3>
                            <div class="box-tool pull-right">
                                <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                            </div>
                        </div>
                        <div class="box-body">
                            <div class="col-md-12 col-sm-12 col-xs-12" id="contChart4">

                                <div id="porcentaje_chart4" class="col-md-12 col-sm-12 col-xs-12 porcentaje_principal"></div>

                                <div id="aprobadas_chart4" class="col-md-6 col-sm-6 col-xs-12">
                                    <div class="box-header">
                                        <h4>Aprobados</h4>
                                    </div>
                                    <div class="box-body">
                                    </div>
                                </div>
                                <div id="noAprobadas_chart4" class="col-md-6 col-sm-6 col-xs-12">
                                    <div class="box-header">
                                        <h4>No aprobados</h4>
                                    </div>
                                    <div class="box-body">
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="box-footer">

                        </div>
                    </div>
                  
                </div><!-- /.col -->

                 <div class="col-md-6 col-sm-6 col-xs-12">

                    <div class="box box-success">
                        <div class="box-header width-border">
                            <h3 class="box-title">General</h3>
                            <div class="box-tool pull-right">
                                <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                            </div>
                        </div>
                        <div class="box-body">
                            <div class="col-md-12 col-sm-12 col-xs-12" id="contChart3">

                                <div id="porcentaje_chart3" class="col-md-12 col-sm-12 col-xs-12 porcentaje_principal"></div>

                                <div id="aprobadas_chart3" class="col-md-6 col-sm-6 col-xs-12">
                                    <div class="box-header">
                                        <h4>Foto: </h4>
                                    </div>
                                    <div class="box-body">
                                        <img src="">
                                    </div>
                                </div>
                                <div id="noAprobadas_chart3" class="col-md-6 col-sm-6 col-xs-12">
                                    <div class="box-header">
                                        <h4>Información: </h4>
                                    </div>
                                    <div class="box-body">
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="box-footer">

                        </div>
                    </div>
                  
                </div><!-- /.col -->
            </div><!-- /.row -->
        </section><!-- /.content -->
      </div><!-- /.content-wrapper -->

      <?php require "views/directivos/footer_directivo.php" ?>

    </div><!-- ./wrapper -->

    <script>
        $(function(){

            $('#range').daterangepicker("option", "dateFormat", "yy-mm-dd");

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

            function invertir_valor_fecha_mes(f1){

                var r;
                var srt_split = [];
                var re = /\d{2}\/\d{2}\/\d{4}/;
                var rei = /\d{2}\/\d{2}\/\d{4}/;

                  var date = new Date();
                  var day = date.getDate();
                  var month = date.getMonth()+1;
                  var year = date.getFullYear();

                  var f='';

                  if (month<10){
                    month += "0"+month;
                  }

                  if (day<10){
                    day += "0"+day;
                  }

                  fechaActual = day+"/"+month+"/"+year;

                  if ( (f1.trim()).match(re) ){
                    str_fecha = f1||"/"            

                      //Ordena el mes y el día de la fecha inicial
                      var arr_f = str_fecha.split("/");

                      if (arr_f.length>1){
                        var f_aux = arr_f[1].trim();
                        arr_f[1] = arr_f[0].trim();
                        arr_f[0] = f_aux;

                        str_fecha = arr_f.join("/");
                      }

                        arr_f = undefined;
                
                  }

                    r = (str_fecha.trim()).match(rei) ? str_fecha.trim():fechaActual;

                return r
            }

            function get_random_color() {
                function c() {
                    return Math.floor(Math.random()*256).toString(10)
                }
                return c()+","+c()+","+c();
            }

            var color_grafica = get_random_color();


            //-------------
            //- CHART 1 -
            //-------------

            var chartData1 = [
              {
                value: 1,
                color: "#f56954",
                highlight: "#f56954",
                label: "Activadas"
              },
              {
                value: 1,
                color: "#00a65a",
                highlight: "#00a65a",
                label: "No Activadas"
              }
            ];

            
            var chartCanvas1 = $("#chart1").get(0).getContext("2d");
            var chart1 = new Chart(chartCanvas1);
            var chartOptions1 = {
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

            chartOptions1.datasetFill = false;
            window.chartLegend1 = chart1.Doughnut(chartData1, chartOptions1);



            //-------------
            //- CHART 2 -
            //-------------

            /*
            var chartData2 = {
                labels: ["Usuario1", "Usuario2", "Usuario3", "Usuario4", "..."],
                datasets: [
                    {
                      label: ["Todo"],
                      pointStrokeColor: "#c1c7d1",
                      pointHighlightFill: "#fff",
                      pointHighlightStroke: "rgba(220,220,220,1)",
                      data: [30,13,22,27,7]
                    }
                ]
            };

            
            var chartCanvas2 = $("#chart2").get(0).getContext("2d");
            var chart2 = new Chart(chartCanvas2);
            
            chartData2.datasets[0].fillColor = "rgba("+color_grafica+", 1)";
            chartData2.datasets[0].strokeColor = "rgba("+color_grafica+", 1)";
            chartData2.datasets[0].pointColor = "rgba("+color_grafica+", 1)";
            var chartOptions2 = {
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
                barStrokeWidth: 1,
                //Number - Spacing between each of the X value sets
                barValueSpacing: 5,
                //Number - Spacing between data sets within X values
                barDatasetSpacing: 1,
                //String - A legend template
                legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].fillColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>",
                //Boolean - whether to make the chart responsive
                responsive: true,
                maintainAspectRatio: false,
                scaleFontSize : 6
            };

            chartOptions2.datasetFill = false;
            window.chartLegend2 = chart2.Bar(chartData2, chartOptions2);

            $("#chartLegend2").html(chartLegend2.generateLegend());

            */

            //-------------
            //- CHART 3 -
            //-------------

            /*
            var chartData3 = {
                labels: ["Usuario1", "Usuario2", "Usuario3", "Usuario4", "..."],
                datasets: [
                    {
                      label: ["Todo"],
                      pointStrokeColor: "#c1c7d1",
                      pointHighlightFill: "#fff",
                      pointHighlightStroke: "rgba(220,220,220,1)",
                      data: [0,0,0,0,0]
                    }
                ]
            };

            
            var chartCanvas3 = $("#chart3").get(0).getContext("2d");
            var chart3 = new Chart(chartCanvas3);
            
            chartData3.datasets[0].fillColor = "rgba("+color_grafica+", 1)";
            chartData3.datasets[0].strokeColor = "rgba("+color_grafica+", 1)";
            chartData3.datasets[0].pointColor = "rgba("+color_grafica+", 1)";
            var chartOptions3 = {
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

            chartOptions3.datasetFill = false;
            window.chartLegend3 = chart3.Bar(chartData3, chartOptions3);

            $("#chartLegend3").html(chartLegend3.generateLegend());
            */


            /***********************************************************   

            CREADOR DE CHART

            ***********************************************************/


            function parse_chart1(jsonChart){



                var nombre_campana = [];

                    nombre_campana['tienda_activada'] = 0;
                    nombre_campana['tienda_no_activada'] = 0;
                    nombre_campana['total_tiendas'] = 0;

                    var tiendas_no_activadas = 0;
                    var tiendas_activas = 0;


                if (jsonChart['campana'].length>0){

                    for (i=0; i<jsonChart['campana'].length; i++){ 

                        (jsonChart['campana'][i]['respuestas']) = (jsonChart['campana'][i]['respuestas']).replace(/\r?\n/g," "); 

                        var json_campana =  JSON.parse(jsonChart['campana'][i]['respuestas']);
                        if (typeof json_campana == 'object'){
                            nombre_campana['tienda_activada']              += json_campana['tienda_activada']            =='on'?1:0; 
                            nombre_campana['tienda_no_activada']           += json_campana['tienda_activada']            =='on'?0:1;    
                            nombre_campana['total_tiendas']++;           
                       }
                    }

                    //tiendas_no_activadas = nombre_campana['tienda_no_activada'];
                    //tiendas_activas      = nombre_campana['tienda_activada'];
                
                    tiendas_no_activadas = nombre_campana['total_tiendas']>0   ? (+nombre_campana['tienda_no_activada']*(100/+nombre_campana['total_tiendas'])).toFixed(0) :   0;
                    tiendas_activas      = nombre_campana['total_tiendas']>0   ? (+nombre_campana['tienda_activada']*(100/+nombre_campana['total_tiendas'])).toFixed(0)    :   0;

                    var chartData1 = [
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
                    $('#chart1').remove();
                    $('#contChart1').append('<canvas id="chart1" height="230"></canvas>');

                    chartCanvas1 = $("#chart1").get(0).getContext("2d");
                    chart1 = new Chart(chartCanvas1);
                    //chartData1 = chartData1;

                    window.chartLegend1 = chart1.Doughnut(chartData1,chartOptions1);
                    //$("#chartLegend1").html(chartLegend1.generateLegend());
                }    
             
            }

            function parse_chart2(jsonChart){
                /*
                var nombre_campana = [];

                var persona_campana = [];

                //contenedor = contenedor || $('#campana');
                nombre_usuarios = JSON.parse(r_datos({funcion:'get_all_usuario_nombre'}));
                  
                arr_nombres = {};
                arr_nombres['nombres'] = [];
                arr_nombres['ids'] = [];
                arr_nombres['vals'] = [];
                arr_nombres['total_usuario'] = [];

                arr_resultado = {};
                arr_resultado['nombres'] = [];
                arr_resultado['vals'] = [];
                arr_resultado['total_usuario'] = [];

                (nombre_usuarios.usuario_id).forEach(function(e,i){
                    arr_nombres['nombres'].push(nombre_usuarios.usuario_name[i]);
                    arr_nombres['ids'].push(nombre_usuarios.usuario_id[i]);
                    //Inicializa todos los valores en cero
                    arr_nombres['vals'].push(0);
                    arr_nombres['total_usuario'].push(0);
                })


                if (jsonChart['campana'].length>0){

                    for (i=0; i<jsonChart['campana'].length; i++){ 
                        var json_campana =  JSON.parse(jsonChart['campana'][i]['respuestas']);
                        if (typeof json_campana == 'object'){
                            
                            //Comprobar si no esiste el usuario en el arrego
                            if (json_campana['persona_evento']!='' && json_campana['persona_evento']!=0 && typeof json_campana['persona_evento']!='undefined'){

                                if(indice = arr_nombres['ids'].indexOf(json_campana['persona_evento'])){  
                                    if(json_campana['logro_objetivo']=='on'){                                 
                                        arr_nombres['vals'][indice]++;
                                    }
                                    arr_nombres['total_usuario'][indice]++;
                                }
                            }
           
                        }
                    }


                    (nombre_usuarios.usuario_id).forEach(function(e,i){
                        if(arr_nombres['vals'][i]!=0){
                            arr_resultado['nombres'].push(arr_nombres['nombres'][i]);
                            arr_resultado['vals'].push( arr_nombres['vals'][i]>0 ? ( ( ( 100/arr_nombres['total_usuario'][i] ) * arr_nombres['vals'][i]).toFixed(1) )  : 0 );

                        }
                        
                    })

                    $('#chart2').remove();
                    $('#contChart2').append('<canvas id="chart2" height="230"></canvas>');

                    chartCanvas2 = $("#chart2").get(0).getContext("2d");
                    chart2 = new Chart(chartCanvas2);

                    chartData2 = {
                        labels: arr_resultado['nombres'],
                        datasets: [
                            {
                              label: ["Todo"],
                              pointStrokeColor: "#c1c7d1",
                              pointHighlightFill: "#fff",
                              pointHighlightStroke: "rgba(220,220,220,1)",
                              data: arr_resultado['vals']
                            }
                        ]
                    };

                    window.chartLegend2 = chart2.Bar(chartData2,chartOptions2);
                    $("#chartLegend2").html(chartLegend2.generateLegend());

                }   
                */ 

                var nombre_campana = [];

                nombre_campana['logro_objetivo']           =   0;
                nombre_campana['total_objetivo']           =   0;



                if (jsonChart['campana'].length>0){

                    for (i=0; i<jsonChart['campana'].length; i++){ 

                        (jsonChart['campana'][i]['respuestas']) = (jsonChart['campana'][i]['respuestas']).replace(/\r?\n/g," "); 

                        var json_campana =  JSON.parse(jsonChart['campana'][i]['respuestas']);
                        if (typeof json_campana == 'object'){
                            nombre_campana['logro_objetivo'] += json_campana['logro_objetivo'] == 'on' ? 1 : 0;
                            nombre_campana['total_objetivo']++;  
                        }
                    }    

                    var small_logro_objetivo = ((100/nombre_campana['total_objetivo'])*nombre_campana['logro_objetivo']).toFixed(1);
               
                    $('#porcentaje_chart2').html(   nombre_campana['logro_objetivo'] > 0 && 
                                                    nombre_campana['total_objetivo'] > 0 && 
                                                    small_logro_objetivo > 50 
                                                        ? "<span style='color:#0F0;'>"+small_logro_objetivo+"%</span>"    
                                                        : "<span style='color:#F00;'>"+small_logro_objetivo+"%</span>" 
                                                     );

                    //Colocar aprobadas
                    $('#aprobadas_chart2 .box-body').html('');
                    
                    $('#aprobadas_chart2 .box-body').html("Se logró <small style='color:#0F0;'>"+nombre_campana['logro_objetivo']+"</small> veces el objetivo" );
                    
                    //Colocar no aprobadas
                    $('#noAprobadas_chart2 .box-body').html('');
                    $('#noAprobadas_chart2 .box-body').html("No se logró <small style='color:#F00;'>"+(nombre_campana['total_objetivo']-nombre_campana['logro_objetivo'])+"</small> veces el objetivo" );
                    
                } 
                return small_logro_objetivo;
            }

            function parse_chart4(jsonChart){

                var nombre_campana = [];

                nombre_campana['puntualidad']           =   0;   
                nombre_campana['abordaje']              =   0;
                nombre_campana['objetivo']              =   0;
                nombre_campana['frase']                 =   0;
                nombre_campana['argumentos']            =   0;
                nombre_campana['precio']                =   0;
                nombre_campana['imagen_persona']        =   0;
                nombre_campana['congruencia']           =   0;
                nombre_campana['presentacion_producto'] =   0;
                nombre_campana['manejo_limpieza']       =   0;
                nombre_campana['total_tiendas']         =   0;



                if (jsonChart['campana'].length>0){

                    for (i=0; i<jsonChart['campana'].length; i++){ 

                        (jsonChart['campana'][i]['respuestas']) = (jsonChart['campana'][i]['respuestas']).replace(/\r?\n/g," "); 

                        var json_campana =  JSON.parse(jsonChart['campana'][i]['respuestas']);
                        if (typeof json_campana == 'object'){
                            nombre_campana['puntualidad']           += json_campana['puntualidad']              =='on'?1:0;
                            nombre_campana['abordaje']              += json_campana['abordaje']                 =='on'?1:0;
                            nombre_campana['objetivo']              += json_campana['objetivo']                 =='on'?1:0;
                            nombre_campana['frase']                 += json_campana['frase']                    =='on'?1:0;
                            nombre_campana['argumentos']            += json_campana['argumentos']               =='on'?1:0;
                            nombre_campana['precio']                += json_campana['precio']                   =='on'?1:0;
                            nombre_campana['imagen_persona']        += json_campana['imagen_persona']           =='on'?1:0;
                            nombre_campana['congruencia']           += json_campana['congruencia']              =='on'?1:0;
                            nombre_campana['presentacion_producto'] += json_campana['presentacion_producto']    =='on'?1:0;
                            nombre_campana['manejo_limpieza']       += json_campana['manejo_limpieza']          =='on'?1:0;

                            nombre_campana['porcentaje'] = nombre_campana['puntualidad'] + nombre_campana['abordaje'] + nombre_campana['objetivo'] +
                                                           nombre_campana['frase'] + nombre_campana['argumentos'] + nombre_campana['precio'] +
                                                           nombre_campana['imagen_persona'] + nombre_campana['congruencia'] + nombre_campana['presentacion_producto'] +
                                                           nombre_campana['manejo_limpieza'];

                            nombre_campana['porcentaje'] += nombre_campana['porcentaje']>0   ?   (nombre_campana['porcentaje']*10):0;

                            nombre_campana['total_tiendas']++;    

                       }
                    }    
           
                    var porcentaje_general = (nombre_campana['porcentaje']/nombre_campana['total_tiendas']).toFixed(1);
                
                    $('#porcentaje_chart4').html(porcentaje_general+"%");
                    
                    //Colocar aprobadas
                    $('#aprobadas_chart4 .box-body').html('');
                    var small_puntualidad = ((100/nombre_campana['total_tiendas'])*nombre_campana['puntualidad']).toFixed(1);
                    $('#aprobadas_chart4 .box-body').append(nombre_campana['puntualidad']               >   0 && nombre_campana['total_tiendas'] > 0 && small_puntualidad > 50 ? "Puntualidad <small style='color:#0F0;'>"+small_puntualidad+"%</small><br>"                                   :   "" );
                    
                    var small_abordaje = ((100/nombre_campana['total_tiendas'])*nombre_campana['abordaje']).toFixed(1);
                    $('#aprobadas_chart4 .box-body').append(nombre_campana['abordaje']                  >   0 && nombre_campana['total_tiendas'] > 0 && small_abordaje > 50    ? "Abordaje <small style='color:#0F0;'>"+small_abordaje+"%</small><br>"                                         :   "" );
                    
                    var small_objetivo = ((100/nombre_campana['total_tiendas'])*nombre_campana['objetivo']).toFixed(1);
                    $('#aprobadas_chart4 .box-body').append(nombre_campana['objetivo']                  >   0 && nombre_campana['total_tiendas'] > 0 && small_objetivo > 50? "Conoce el objetivo <small style='color:#0F0;'>"+small_objetivo+"%</small><br>"                                   :   "" );
                    
                    var small_frase = ((100/nombre_campana['total_tiendas'])*nombre_campana['frase']).toFixed(1);
                    $('#aprobadas_chart4 .box-body').append(nombre_campana['frase']                     >   0 && nombre_campana['total_tiendas'] > 0 && small_frase > 50? "Menciona la frase <small style='color:#0F0;'>"+small_frase+"%</small><br>"                                          :   "" );
                    
                    var small_argumentos = ((100/nombre_campana['total_tiendas'])*nombre_campana['argumentos']).toFixed(1);
                    $('#aprobadas_chart4 .box-body').append(nombre_campana['argumentos']                >   0 && nombre_campana['total_tiendas'] > 0 && small_argumentos > 50? "Cominica los argumentos de venta <small style='color:#0F0;'>"+small_argumentos+"%</small><br>"                 :   "" );
                    
                    var small_precio = ((100/nombre_campana['total_tiendas'])*nombre_campana['precio']).toFixed(1);
                    $('#aprobadas_chart4 .box-body').append(nombre_campana['precio']                    >   0 && nombre_campana['total_tiendas'] > 0 && small_precio > 50? "Comunica el precio <small style='color:#0F0;'>"+small_precio+"%</small><br>"                                       :   "" );
                    
                    var small_imagen_persona = ((100/nombre_campana['total_tiendas'])*nombre_campana['imagen_persona']).toFixed(1);
                    $('#aprobadas_chart4 .box-body').append(nombre_campana['imagen_persona']            >   0 && nombre_campana['total_tiendas'] > 0 && small_imagen_persona > 50? "Imagen de la persona <small style='color:#0F0;'>"+small_imagen_persona+"%</small><br>"                     :   "" );
                    
                    var small_congruencia = ((100/nombre_campana['total_tiendas'])*nombre_campana['congruencia']).toFixed(1);
                    $('#aprobadas_chart4 .box-body').append(nombre_campana['congruencia']               >   0 && nombre_campana['total_tiendas'] > 0 && small_congruencia > 50? "Congruencia de la marca <small style='color:#0F0;'>"+small_congruencia+"%</small><br>"                        :   "" );
                    
                    var small_presentacion_producto = ((100/nombre_campana['total_tiendas'])*nombre_campana['presentacion_producto']).toFixed(1);
                    $('#aprobadas_chart4 .box-body').append(nombre_campana['presentacion_producto']     >   0 && nombre_campana['total_tiendas'] > 0 && small_presentacion_producto > 50? "Presentación del producto <small style='color:#0F0;'>"+small_presentacion_producto+"%</small><br>"  :   "" );
                    
                    var small_manejo_limpieza = ((100/nombre_campana['total_tiendas'])*nombre_campana['manejo_limpieza']).toFixed(1);
                    $('#aprobadas_chart4 .box-body').append(nombre_campana['manejo_limpieza']           >   0 && nombre_campana['total_tiendas'] > 0 && small_manejo_limpieza > 50? "Manejo y limpieza de materiales y equipo <small style='color:#0F0;'>"+small_manejo_limpieza+"%</small><br>"  :   "" );


                    //Colocar no aprobadas
                    $('#noAprobadas_chart4 .box-body').html('');

                    $('#noAprobadas_chart4 .box-body').append(nombre_campana['puntualidad']               >   0 && nombre_campana['total_tiendas'] > 0 && small_puntualidad <= 50  ? "Puntualidad <small style='color:#F00;'>"+small_puntualidad+"%</small><br>"                                   :   "" );
                    $('#noAprobadas_chart4 .box-body').append(nombre_campana['abordaje']                  >   0 && nombre_campana['total_tiendas'] > 0 && small_abordaje <= 50  ? "Abordaje <small style='color:#F00;'>"+small_abordaje+"%</small><br>"                                            :   "" );
                    $('#noAprobadas_chart4 .box-body').append(nombre_campana['objetivo']                  >   0 && nombre_campana['total_tiendas'] > 0 && small_objetivo <= 50 ? "Conoce el objetivo <small style='color:#F00;'>"+small_objetivo+"%</small><br>"                                   :   "" );
                    $('#noAprobadas_chart4 .box-body').append(nombre_campana['frase']                     >   0 && nombre_campana['total_tiendas'] > 0 && small_frase <= 50 ? "Menciona la frase <small style='color:#F00;'>"+small_frase+"%</small><br>"                                          :   "" );
                    $('#noAprobadas_chart4 .box-body').append(nombre_campana['argumentos']                >   0 && nombre_campana['total_tiendas'] > 0 && small_argumentos <= 50 ? "Cominica los argumentos de venta <small style='color:#F00;'>"+small_argumentos+"%</small><br>"                 :   "" );
                    $('#noAprobadas_chart4 .box-body').append(nombre_campana['precio']                    >   0 && nombre_campana['total_tiendas'] > 0 && small_precio <= 50 ? "Comunica el precio <small style='color:#F00;'>"+small_precio+"%</small><br>"                                       :   "" );
                    $('#noAprobadas_chart4 .box-body').append(nombre_campana['imagen_persona']            >   0 && nombre_campana['total_tiendas'] > 0 && small_imagen_persona <= 50 ? "Imagen de la persona <small style='color:#F00;'>"+small_imagen_persona+"%</small><br>"                     :   "" );
                    $('#noAprobadas_chart4 .box-body').append(nombre_campana['congruencia']               >   0 && nombre_campana['total_tiendas'] > 0 && small_congruencia <= 50 ? "Congruencia de la marca <small style='color:#F00;'>"+small_congruencia+"%</small><br>"                        :   "" );
                    $('#noAprobadas_chart4 .box-body').append(nombre_campana['presentacion_producto']     >   0 && nombre_campana['total_tiendas'] > 0 && small_presentacion_producto <= 50 ? "Presentación del producto <small style='color:#F00;'>"+small_presentacion_producto+"%</small><br>"  :   "" );
                    $('#noAprobadas_chart4 .box-body').append(nombre_campana['manejo_limpieza']           >   0 && nombre_campana['total_tiendas'] > 0 && small_manejo_limpieza <= 50 ? "Manejo y limpieza de materiales y equipo <small style='color:#F00;'>"+small_manejo_limpieza+"%</small><br>"  :   "" );

                }   

                return porcentaje_general;
             
            }

            function parse_chart3(value_chart2, value_chart4){

                ids = $('#opciones_seleccion')
                
                var image_usuario = get_image_user();

                var valor_general = ( (( parseInt(value_chart2,10)+parseInt(value_chart4,10) )/2).toFixed(1)  );


                $('#porcentaje_chart3').html("");
                $('#porcentaje_chart3').html( valor_general );

                $('#noAprobadas_chart3 .box-body').html('');
                $('#noAprobadas_chart3 .box-body').html("0.0%");

                $('#aprobadas_chart3 .box-body img').attr("src","uploads/usuarios/"+image_usuario);

            }



            function get_image_user(id_usuario){

                id_usuario = id_usuario || 0;

                var img = JSON.parse(r_datos({funcion:'get_imagen_persona', id:id_usuario}));

                return img['foto']
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

                        (obj_campana['campana'][i]['respuestas']) = (obj_campana['campana'][i]['respuestas']).replace(/\r?\n/g," "); 

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


            function parse_buscar(obj_buscar, id_campana, evaluador, encargado, fecha){
          
                var nombre_campana  = [];
                var ids = $( "#opciones_seleccion" ).val() || 0;
                var fecha_sep_i = separar_fechas(fecha)[0];
                var fecha_sep_f = separar_fechas(fecha)[1];

    
                id_persona_evento = 0;



                var fecha_inicio    = Date.parse(fecha_sep_i);
                var fecha_fin       = Date.parse(fecha_sep_f);

                var fecha_inicio_invertida = Date.parse(invertir_valor_fecha_mes(fecha_sep_i));
                var fecha_fin_invertida = Date.parse(invertir_valor_fecha_mes(fecha_sep_f));

                var nombre = '';

                // Variables para chart 1
                nombre_campana['tienda_activada']       = 0;
                nombre_campana['tienda_no_activada']    = 0; 
                nombre_campana['total_tiendas']         = 0;

                // Variables para chart 2

                /*
                nombre_usuarios = JSON.parse(r_datos({funcion:'get_all_usuario_nombre'}));

                arr_nombres = {};
                arr_nombres['nombres'] = [];
                arr_nombres['ids'] = [];
                arr_nombres['vals'] = [];
                arr_nombres['total_usuario'] = [];

                arr_resultado = {};
                arr_resultado['nombres'] = [];
                arr_resultado['vals'] = [];
                arr_resultado['total_usuario'] = [];

                (nombre_usuarios.usuario_id).forEach(function(e,i){
                    arr_nombres['nombres'].push(nombre_usuarios.usuario_name[i]);
                    arr_nombres['ids'].push(nombre_usuarios.usuario_id[i]);
                    //Inicializa todos los valores en cero
                    arr_nombres['vals'].push(0);
                    arr_nombres['total_usuario'].push(0);
                })

                */

                nombre_campana['logro_objetivo']           =   0;   
                nombre_campana['total_objetivo']           =   0;

                // Variables para chart 4
                nombre_campana['puntualidad']           =   0;   
                nombre_campana['abordaje']              =   0;
                nombre_campana['objetivo']              =   0;
                nombre_campana['frase']                 =   0;
                nombre_campana['argumentos']            =   0;
                nombre_campana['precio']                =   0;
                nombre_campana['imagen_persona']        =   0;
                nombre_campana['congruencia']           =   0;
                nombre_campana['presentacion_producto'] =   0;
                nombre_campana['manejo_limpieza']       =   0;
                nombre_campana['total_tiendas']         =   0;

                var tiendas_no_activadas = 0;
                var tiendas_activas = 0;

    //console.log("ids");
    //console.log(ids);

                //for (j=0; j<ids.length; j++){
                    //chart1
                    if (obj_buscar['campana'].length>0){
                        for (i=0; i<obj_buscar['campana'].length; i++){ 

                            (obj_buscar['campana'][i]['respuestas']) = (obj_buscar['campana'][i]['respuestas']).replace(/\r?\n/g," "); 
                            
                            var json_campana =  JSON.parse(obj_buscar['campana'][i]['respuestas']);
                            var json_id      =  JSON.parse(obj_buscar['campana'][i]['id_respuesta']);

                            if (typeof json_campana == 'object'){
    //console.log("if(("+json_id+"=="+id_campana+"||"+id_campana+"==0) && ("+json_campana['nombre_evaluador']+"=="+evaluador+"||"+evaluador+"==0) && ("+json_campana['persona_evento']+"=="+encargado+"||"+encargado+"==0) && ("+Date.parse(json_campana['fecha'])+">="+fecha_inicio+"&&"+Date.parse(json_campana['fecha'])+"<="+fecha_fin+")){");
                                //if((json_id==id_campana||id_campana==0) && (json_campana['nombre_evaluador']==evaluador||evaluador==0) && (json_campana['persona_evento']==encargado||encargado==0) && (Date.parse(json_campana['fecha'])>=fecha_inicio&&Date.parse(json_campana['fecha'])<=fecha_fin)){
                                var json_fecha_invertida = typeof json_campana['fecha'] != 'undefined' ? Date.parse(invertir_valor_fecha_mes(json_campana['fecha'])) : '';
    console.log("if(("+json_campana['persona_evento']+"== "+ids+" || "+ ids+"==0) && ("+json_fecha_invertida+">="+fecha_inicio_invertida+"&&"+json_fecha_invertida+"<="+fecha_fin_invertida+")){   ") 
                                if((json_campana['persona_evento']==ids || ids==0) && (json_fecha_invertida>=fecha_inicio_invertida&&json_fecha_invertida<=fecha_fin_invertida)){   
                                    
                                    //CHART1
                                    nombre_campana['tienda_activada']              += json_campana['tienda_activada']            =='on'?1:0; 
                                    nombre_campana['tienda_no_activada']           += json_campana['tienda_activada']            =='on'?0:1;    
                                    //nombre_campana['total_tiendas']++; 

//console.log(json_campana);
//console.log("if ("+json_campana['persona_evento']+"!='' && "+json_campana['persona_evento']+"!=0 && "+typeof json_campana['persona_evento']+"!='undefined'){")
                                    //Chart 2
                                    //Comprobar si no esiste el usuario en el arrego
                                    /*
                                    if (json_campana['persona_evento']!='' && json_campana['persona_evento']!=0 && typeof json_campana['persona_evento']!='undefined'){

                                        if(indice = arr_nombres['ids'].indexOf(json_campana['persona_evento'])){  
                                            if(json_campana['logro_objetivo']=='on'){                                 
                                                arr_nombres['vals'][indice]++;
                                            }
                                            arr_nombres['total_usuario'][indice]++;
                                        }
                                    }
                                    */

                                    nombre_campana['logro_objetivo']           += json_campana['logro_objetivo']              =='on'?1:0;
                                    nombre_campana['total_objetivo']++;


                                    //Chart4
                                    nombre_campana['puntualidad']           += json_campana['puntualidad']              =='on'?1:0;
                                    nombre_campana['abordaje']              += json_campana['abordaje']                 =='on'?1:0;
                                    nombre_campana['objetivo']              += json_campana['objetivo']                 =='on'?1:0;
                                    nombre_campana['frase']                 += json_campana['frase']                    =='on'?1:0;
                                    nombre_campana['argumentos']            += json_campana['argumentos']               =='on'?1:0;
                                    nombre_campana['precio']                += json_campana['precio']                   =='on'?1:0;
                                    nombre_campana['imagen_persona']        += json_campana['imagen_persona']           =='on'?1:0;
                                    nombre_campana['congruencia']           += json_campana['congruencia']              =='on'?1:0;
                                    nombre_campana['presentacion_producto'] += json_campana['presentacion_producto']    =='on'?1:0;
                                    nombre_campana['manejo_limpieza']       += json_campana['manejo_limpieza']          =='on'?1:0;

                                    nombre_campana['porcentaje'] = nombre_campana['puntualidad'] + nombre_campana['abordaje'] + nombre_campana['objetivo'] +
                                                                   nombre_campana['frase'] + nombre_campana['argumentos'] + nombre_campana['precio'] +
                                                                   nombre_campana['imagen_persona'] + nombre_campana['congruencia'] + nombre_campana['presentacion_producto'] +
                                                                   nombre_campana['manejo_limpieza'];

                                    nombre_campana['porcentaje'] += nombre_campana['porcentaje']>0   ?   (nombre_campana['porcentaje']*10):0;

                                    nombre_campana['total_tiendas']++;  

                                    //Chart 3

                                }


                                


                            }
                        }

                        ////////CHART 1
                        
                    //tiendas_no_activadas = nombre_campana['tienda_no_activada'];
                    //tiendas_activas      = nombre_campana['tienda_activada'];
                
                    tiendas_no_activadas = nombre_campana['total_tiendas']>0   ? (+nombre_campana['tienda_no_activada']*(100/+nombre_campana['total_tiendas'])).toFixed(0) :   0;
                    tiendas_activas      = nombre_campana['total_tiendas']>0   ? (+nombre_campana['tienda_activada']*(100/+nombre_campana['total_tiendas'])).toFixed(0)    :   0;


//      console.log(tiendas_no_activadas); 
//      console.log(tiendas_activas); 

                        var chartData1 = [
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
                        $('#chart1').remove();
                        $('#contChart1').append('<canvas id="chart1" height="230"></canvas>');

                        chartCanvas1 = $("#chart1").get(0).getContext("2d");
                        chart1 = new Chart(chartCanvas1);
                        chartData1 = chartData1;

                        window.chartLegend1 = chart1.Doughnut(chartData1,chartOptions1);
                        //$("#chartLegend1").html(chartLegend1.generateLegend());

                        //////FIN DE CHART1


                        //CHART2

                        /*
                        (nombre_usuarios.usuario_id).forEach(function(e,i){
                            if(arr_nombres['vals'][i]!=0){
                                arr_resultado['nombres'].push(arr_nombres['nombres'][i]);
                                arr_resultado['vals'].push( arr_nombres['vals'][i]>0 ? ( ( ( 100/arr_nombres['total_usuario'][i] ) * arr_nombres['vals'][i]).toFixed(1) )  : 0 );
                            }
                            
                        })

                        $('#chart2').remove();
                        $('#contChart2').append('<canvas id="chart2" height="230"></canvas>');

                        chartCanvas2 = $("#chart2").get(0).getContext("2d");
                        chart2 = new Chart(chartCanvas2);

                        chartData2 = {
                            labels: arr_resultado['nombres'],
                            datasets: [
                                {
                                  label: ["Todo"],
                                  pointStrokeColor: "#c1c7d1",
                                  pointHighlightFill: "#fff",
                                  pointHighlightStroke: "rgba(220,220,220,1)",
                                  data: arr_resultado['vals']
                                }
                            ]
                        };

                        window.chartLegend2 = chart2.Bar(chartData2,chartOptions2);
                        $("#chartLegend2").html(chartLegend2.generateLegend());
                        */


                        //Colocar aprobadas
                        $('#aprobadas_chart2 .box-body').html('');

                           
                        var small_logro_objetivo = ( (100/+nombre_campana['total_objetivo'])*+nombre_campana['logro_objetivo'] ).toFixed(1);
               
                        $('#porcentaje_chart2').html(   nombre_campana['logro_objetivo'] > 0 && 
                                                        nombre_campana['total_objetivo'] > 0 && 
                                                        small_logro_objetivo > 50 
                                                            ? "<span style='color:#0F0;'>"+small_logro_objetivo+"%</span>"    
                                                            : "<span style='color:#F00;'>"+small_logro_objetivo+"%</span>" 
                                                         );

                        //Colocar aprobadas
                        $('#aprobadas_chart2 .box-body').html('');
                        
                        $('#aprobadas_chart2 .box-body').html("Se logró <small style='color:#0F0;'>"+nombre_campana['logro_objetivo']+"</small> veces el objetivo" );
                        
                        //Colocar no aprobadas
                        $('#noAprobadas_chart2 .box-body').html('');
                        $('#noAprobadas_chart2 .box-body').html("No se logró <small style='color:#F00;'>"+(nombre_campana['total_objetivo']-nombre_campana['logro_objetivo'])+"</small> veces el objetivo" );
                        

                        //FIN DE CHART 2

                        /////CHART4
                        
                        //Colocar aprobadas
                        $('#aprobadas_chart4 .box-body').html('');

                           
                        var small_puntualidad   = (
                                                    (Math.floor(100/nombre_campana['total_tiendas']))*nombre_campana['puntualidad']
                                                ).toFixed(1);
                        var small_abordaje      = (
                                                    (Math.floor(100/nombre_campana['total_tiendas'])*nombre_campana['abordaje'])
                                                ).toFixed(1);
                        var small_objetivo      = (
                                                    (Math.floor(100/nombre_campana['total_tiendas'])*nombre_campana['objetivo'])
                                                ).toFixed(1);
                        var small_frase         = (
                                                    (Math.floor(100/nombre_campana['total_tiendas'])*nombre_campana['frase'])
                                                ).toFixed(1);
                        var small_argumentos    = (
                                                    (Math.floor(100/nombre_campana['total_tiendas'])*nombre_campana['argumentos'])
                                                ).toFixed(1);
                        var small_precio        = (
                                                    (Math.floor(100/nombre_campana['total_tiendas'])*nombre_campana['precio'])
                                                ).toFixed(1);
                        var small_imagen_persona = (
                                                    (Math.floor(100/nombre_campana['total_tiendas'])*nombre_campana['imagen_persona'])
                                                ).toFixed(1);
                        var small_congruencia   = (
                                                    (Math.floor(100/nombre_campana['total_tiendas'])*nombre_campana['congruencia'])
                                                ).toFixed(1);
                        var small_presentacion_producto   = (
                                                    (Math.floor(100/nombre_campana['total_tiendas'])*nombre_campana['presentacion_producto'])
                                                ).toFixed(1);
                        var small_manejo_limpieza = (
                                                    (Math.floor(100/nombre_campana['total_tiendas'])*nombre_campana['manejo_limpieza'])
                                                ).toFixed(1);

                        var small_porcentaje    = (
                                                        ((
                                                            +small_abordaje +
                                                            +small_objetivo +
                                                            +small_frase +
                                                            +small_argumentos +
                                                            +small_precio +
                                                            +small_imagen_persona +
                                                            +small_congruencia +
                                                            +small_presentacion_producto +
                                                            +small_manejo_limpieza
                                                        ) / 10)
                                                ).toFixed(1);
console.log("small");
console.log(small_porcentaje);                        

                        small_porcentaje        = !isNaN(small_porcentaje) && isFinite(small_porcentaje)    ?  small_porcentaje      : 0;
                        small_puntualidad       = !isNaN(small_puntualidad)      ?  small_puntualidad     : 0;
                        small_abordaje          = !isNaN(small_abordaje)         ?  small_abordaje        : 0;
                        small_objetivo          = !isNaN(small_objetivo)         ?  small_objetivo        : 0;
                        small_frase             = !isNaN(small_frase)            ?  small_frase           : 0;
                        small_argumentos        = !isNaN(small_argumentos)       ?  small_argumentos      : 0;
                        small_precio            = !isNaN(small_precio)           ?  small_precio          : 0;
                        small_imagen_persona    = !isNaN(small_imagen_persona)   ?  small_imagen_persona  : 0;
                        small_congruencia       = !isNaN(small_congruencia)      ?  small_congruencia     : 0;
                        small_presentacion_producto       = !isNaN(small_presentacion_producto)      ?  small_presentacion_producto     : 0;
                        small_manejo_limpieza   = !isNaN(small_manejo_limpieza)  ?  small_manejo_limpieza : 0;

                         



                        $('#porcentaje_chart4').html(small_porcentaje+"%");

                        $('#aprobadas_chart4 .box-body').html('');

                        $('#aprobadas_chart4 .box-body').append(nombre_campana['puntualidad']               >   0 && nombre_campana['total_tiendas'] > 0 && small_puntualidad > 50 ? "Puntualidad <small style='color:#0F0;'>"+small_puntualidad+"%</small><br>"                                   :   "" );
                        $('#aprobadas_chart4 .box-body').append(nombre_campana['abordaje']                  >   0 && nombre_campana['total_tiendas'] > 0 && small_abordaje > 50    ? "Abordaje <small style='color:#0F0;'>"+small_abordaje+"%</small><br>"                                         :   "" );
                        $('#aprobadas_chart4 .box-body').append(nombre_campana['objetivo']                  >   0 && nombre_campana['total_tiendas'] > 0 && small_objetivo > 50? "Conoce el objetivo <small style='color:#0F0;'>"+small_objetivo+"%</small><br>"                                   :   "" );
                        $('#aprobadas_chart4 .box-body').append(nombre_campana['frase']                     >   0 && nombre_campana['total_tiendas'] > 0 && small_frase > 50? "Menciona la frase <small style='color:#0F0;'>"+small_frase+"%</small><br>"                                          :   "" );
                        $('#aprobadas_chart4 .box-body').append(nombre_campana['argumentos']                >   0 && nombre_campana['total_tiendas'] > 0 && small_argumentos > 50? "Cominica los argumentos de venta <small style='color:#0F0;'>"+small_argumentos+"%</small><br>"                 :   "" );
                        $('#aprobadas_chart4 .box-body').append(nombre_campana['precio']                    >   0 && nombre_campana['total_tiendas'] > 0 && small_precio > 50? "Comunica el precio <small style='color:#0F0;'>"+small_precio+"%</small><br>"                                       :   "" );
                        $('#aprobadas_chart4 .box-body').append(nombre_campana['imagen_persona']            >   0 && nombre_campana['total_tiendas'] > 0 && small_imagen_persona > 50? "Imagen de la persona <small style='color:#0F0;'>"+small_imagen_persona+"%</small><br>"                     :   "" );
                        $('#aprobadas_chart4 .box-body').append(nombre_campana['congruencia']               >   0 && nombre_campana['total_tiendas'] > 0 && small_congruencia > 50? "Congruencia de la marca <small style='color:#0F0;'>"+small_congruencia+"%</small><br>"                        :   "" );
                        $('#aprobadas_chart4 .box-body').append(nombre_campana['presentacion_producto']     >   0 && nombre_campana['total_tiendas'] > 0 && small_presentacion_producto > 50? "Presentación del producto <small style='color:#0F0;'>"+small_presentacion_producto+"%</small><br>"  :   "" );
                        $('#aprobadas_chart4 .box-body').append(nombre_campana['manejo_limpieza']           >   0 && nombre_campana['total_tiendas'] > 0 && small_manejo_limpieza > 50? "Manejo y limpieza de materiales y equipo <small style='color:#0F0;'>"+small_manejo_limpieza+"%</small><br>"  :   "" );


                        //Colocar no aprobadas
                        $('#noAprobadas_chart4 .box-body').html('');

                        $('#noAprobadas_chart4 .box-body').append(small_puntualidad <= 50  ? "Puntualidad <small style='color:#F00;'>"+small_puntualidad+"%</small><br>"                                   :   "" );
                        $('#noAprobadas_chart4 .box-body').append(small_abordaje <= 50  ? "Abordaje <small style='color:#F00;'>"+small_abordaje+"%</small><br>"                                            :   "" );
                        $('#noAprobadas_chart4 .box-body').append(small_objetivo <= 50 ? "Conoce el objetivo <small style='color:#F00;'>"+small_objetivo+"%</small><br>"                                   :   "" );
                        $('#noAprobadas_chart4 .box-body').append(small_frase <= 50 ? "Menciona la frase <small style='color:#F00;'>"+small_frase+"%</small><br>"                                          :   "" );
                        $('#noAprobadas_chart4 .box-body').append(small_argumentos <= 50 ? "Cominica los argumentos de venta <small style='color:#F00;'>"+small_argumentos+"%</small><br>"                 :   "" );
                        $('#noAprobadas_chart4 .box-body').append(small_precio <= 50 ? "Comunica el precio <small style='color:#F00;'>"+small_precio+"%</small><br>"                                       :   "" );
                        $('#noAprobadas_chart4 .box-body').append(small_imagen_persona <= 50 ? "Imagen de la persona <small style='color:#F00;'>"+small_imagen_persona+"%</small><br>"                     :   "" );
                        $('#noAprobadas_chart4 .box-body').append(small_congruencia <= 50 ? "Congruencia de la marca <small style='color:#F00;'>"+small_congruencia+"%</small><br>"                        :   "" );
                        $('#noAprobadas_chart4 .box-body').append(small_presentacion_producto <= 50 ? "Presentación del producto <small style='color:#F00;'>"+small_presentacion_producto+"%</small><br>"  :   "" );
                        $('#noAprobadas_chart4 .box-body').append(small_manejo_limpieza <= 50 ? "Manejo y limpieza de materiales y equipo <small style='color:#F00;'>"+small_manejo_limpieza+"%</small><br>"  :   "" );

                        /////FIN DE CHART 4


                        // CHART 3

                        var image_usuario = get_image_user(ids);

                        $('#porcentaje_chart3').html("");
                        $('#porcentaje_chart3').html( ((parseInt(small_logro_objetivo,10)+parseInt(small_porcentaje))/2).toFixed(1) );

                        $('#noAprobadas_chart3 .box-body').html('');
                        $('#noAprobadas_chart3 .box-body').html("0.0%");

                        $('#aprobadas_chart3 .box-body img').attr("src","");
                        $('#aprobadas_chart3 .box-body img').attr("src","uploads/usuarios/"+image_usuario);

                        // FIN CHART 3
                    }

                //}
                //functionChart4();
            }

            function buscar(){
                var campana   = $('#campana').val();
                var evaluador = $('#evaluador').val();
                var encargado = $('#encargado').val();
                var fecha     = $('#range').val();

                nombre_campana = [];

                 

                buscar_c = JSON.parse(r_datos({funcion:'get_buscar'}));
                parse_buscar(buscar_c,campana,evaluador,encargado,fecha);

                 
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

            $('#tipo_seleccion').on('change',function(){
                console.log("Buscando");
                change_opciones_seleccion();
            })

            function functionChart1(){
                jsonChart1 = JSON.parse(r_datos({funcion:'get_campana'}));
                parse_chart1(jsonChart1);
            }

            function functionChart2(){
                jsonChart2 = JSON.parse(r_datos({funcion:'get_campana'}));
                return parse_chart2(jsonChart2);
            }

            function functionChart4(){
                jsonChart4 = JSON.parse(r_datos({funcion:'get_campana'}));
                return parse_chart4(jsonChart4);
            }

            function functionChart3(value_chart2, value_chart4){
                parse_chart3(value_chart2, value_chart4);
            }

            function inic(){
                functionChart1();
                var value_chart2 = functionChart2();
                var value_chart4 = functionChart4();
                functionChart3(value_chart2, value_chart4);
                change_opciones_seleccion();
            }

                inic();

            
            
        
        })
        
    </script>
    <script type="text/javascript">


      $(function () {
        //Fechas
        $("[data-mask]").inputmask("yyyy/mm/dd");
      })
    </script>


  </body>

<?php

}
else{
?>
<script>
alert("tu no tienes permiso para ver este contenido");
document.location.href="index.php?command=home";
</script>
<?php
}
?>