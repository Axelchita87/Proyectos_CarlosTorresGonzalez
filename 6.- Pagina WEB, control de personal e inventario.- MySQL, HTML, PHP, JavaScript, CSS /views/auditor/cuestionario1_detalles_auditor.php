<?php
require_once 'class/class.cuestionario1.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='auditor'){

?>

  <body class="skin-blue">

    <script>


      function invertir_valor_fecha(f1){
        var r;
        var srt_split = [];
        var re = /\d{2}\/\d{2}\/\d{4}/;
        var rei = /\d{4}\/\d{2}\/\d{2}/;

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
                var f_aux = arr_f[2].trim();
                arr_f[2] = arr_f[0].trim();
                arr_f[0] = f_aux;

                str_fecha = arr_f.join("/");
              }

                arr_f = undefined;
        
          }

            r = (str_fecha.trim()).match(rei) ? str_fecha.trim():fechaActual;

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

      function separar_fechas(str_fecha){
          var r = [];
          var srt_split = [];

          var date = new Date();
          var day = date.getDate();
          var month = date.getMonth()+1;
          var year = date.getFullYear();

          var f='';

          if (month<10){
            month = "0"+month;
          }
          if (month<10){
            day = "0"+day;
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

                //arr_f[0] = arr_f[0]<10?"0"+arr_f[0]:arr_f[0];
                //arr_f[1] = arr_f[1]<10?"0"+arr_f[1]:arr_f[1];
                

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

            return r
        }

      $(function(){



        $('#export-excel').click(function(){

            var fecha     = $('#range').val(); 

          
            var fecha_inicio    = separar_fechas(fecha)[0];
            var fecha_fin       = separar_fechas(fecha)[1];

            vars = "?fecha_i="+invertir_valor_fecha(fecha_inicio)+"&fecha_f="+invertir_valor_fecha(fecha_fin)+"&evaluador="+$('#evaluador').val()+"&encargado="+$('#encargado').val()+"&campana="+$('#campana').val();
            document.location.href="reporteexcel_cuestionario_sigma.php"+vars;
        })
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
                <button class="btn btn-primary pull-right" data-placement="bottom" onclick="javascript:location='index.php?command=respuestas_cuestionario1_auditor'" data-toggle="tooltip" title="Cuestionarios" data-original-title="Cuestionarios">
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
                  </div>

                </div>
              </div>
            </div>

          <!-- Default box -->
            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="box box-primary">
                  <div class="box-header with-border">
                    <h3 class="box-title">Campaña</h3>
                    <div class="box-tools pull-right">
                      <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                      <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                      <button class="btn btn-box-tool" data-widget="export" id="export-excel"><img  title="Exportar tabla a Excel" data-toggle="tooltip" data-placement="left" src="images/hoja-de-calculo-excel-icono.png" style="width:15px;" /></button>
                    </div>
                    <div class="col-md-12 col-sm-12 col-xs-12"> 
                      <div class="row">
                        <label class="col-md-1 col-sm-1 col-xs-1">Seleccionar</label>
                        <label class="col-md-2 col-sm-2 col-xs-2">Nombre de campaña</label>
                        <label class="col-md-2 col-sm-2 col-xs-2">Evaluador</label>
                        <label class="col-md-2 col-sm-2 col-xs-2">Encargado</label>
                        <label class="col-md-2 col-sm-2 col-xs-2">Fecha</label>
                        <label class="col-md-1 col-sm-1 col-xs-1" style="display:none">Editar</label>
                        <label class="col-md-1 col-sm-1 col-xs-1">Ver</label>
                        <label class="col-md-1 col-sm-1 col-xs-1" style="display:none">Eliminar</label>
                      </div>
                    </div>
                  </div>
                  <div class="box-body detalle-list" id="listado_respuestas">
                    
                  </div><!-- /.box-body -->

                </div>
              </div>
            </div>

                     

        </section><!-- /.content -->
      </div><!-- /.content-wrapper -->


		  <?php require "views/auditor/footer_auditor.php" ?>
	  </div>

  <script>

   $(function () {


     //**********************************************************************************************
     // ******************************INICIO GRAFICAS************************************************
     //********************************************************************************************** 

      $('#range').daterangepicker("option", "dateFormat", "yy-mm-dd");

        



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

               
        function parse_detalles(){
          
        }

        
        
        function parse_buscar(obj_buscar, id_campana, evaluador, encargado, fecha){
          
          var nombre_campana  = ['modulo','charola','sarteneta','arco','sonido','adicional','producto_sufuciente','degustacion','adicional_camapana'];
          var fecha_inicio    = Date.parse(separar_fechas(fecha)[0]);
          var fecha_fin       = Date.parse(separar_fechas(fecha)[1]);

          console.log("Fecha inicio: " + fecha_inicio);

                nombre_campana['modulo']              = 0;
                nombre_campana['charola']             = 0;
                nombre_campana['sarteneta']           = 0;
                nombre_campana['arco']                = 0;
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
                }               
              }
            }
              barChartData.datasets[0].data = [nombre_campana['modulo'],nombre_campana['charola'],nombre_campana['sarteneta'],nombre_campana['arco'],nombre_campana['sonido'],nombre_campana['adicional'],nombre_campana['producto_suficiente'],nombre_campana['degustacion'],nombre_campana['adicional_campana']];
              barChart.Bar(barChartData);

            
              barChartData2.datasets[0].data = [nombre_campana['frase'],nombre_campana['argumentos'],nombre_campana['precio']];
              barChart2.Radar(barChartData2); 

            
              barChartData3.datasets[0].data = [nombre_campana['imagen_persona'],nombre_campana['congruencia'],nombre_campana['presentacion_producto'],nombre_campana['manejo_limpieza']];
              barChart3.Radar(barChartData3);
            
          }
          //console.log(r);
        }

        function get_campana_nombre_lista(id_campana){
          id_campana = id_campana || 0;
          nombre = JSON.parse(r_datos({funcion:'get_campana_nombre_lista',id:id_campana}));    
          //console.log();      
          return nombre['campana'][0]['nombre_campana'];
        }

        function parse_campana(obj_campana,contenedor){
          contenedor = contenedor || $('#campana');
          var nombre_campana = []


          if (obj_campana['campana'].length>0){
            contenedor.html('<option value="0">Selecciona...</option>');
            for (i=0; i<obj_campana['campana'].length; i++){ 
              var json_campana =  JSON.parse(obj_campana['campana'][i]['respuestas']);
              var json_id      =  JSON.parse(obj_campana['campana'][i]['id_respuesta']);
              if (typeof json_campana == 'object'){
                var nombre  = json_campana['nombre_campana'];
                var id      = json_campana['nombre_campana'];

                nombre = isNaN(nombre)?nombre:get_campana_nombre_lista(nombre);

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

        function agregar_fila(obj_campana){
          
          $("#listado_respuestas").append(
                      '<div class="col-md-12 col-sm-12 col-xs-12"> '+
                        '<div class="row">'+
                          '<label class="col-md-1 col-sm-1 col-xs-1"><input type="checkbox" name="c_'+obj_campana["id"]+'" style="display:none"></label>'+
                          '<label class="col-md-2 col-sm-2 col-xs-2">'+obj_campana["nombre"]+'</label>'+
                          '<label class="col-md-2 col-sm-2 col-xs-2">'+obj_campana["evaluador"]+'</label>'+
                          '<label class="col-md-2 col-sm-2 col-xs-2">'+obj_campana["encargado"]+'</label>'+
                          '<label class="col-md-2 col-sm-2 col-xs-2">'+obj_campana["tienda"]+'</label>'+
                          '<label class="col-md-2 col-sm-2 col-xs-2">'+obj_campana["fecha"]+'</label>'+
                          '<label class="col-md-1 col-sm-1 col-xs-1">'+
                            '<a href="index.php?command=ver_cuestionario1_auditor&id_cuestionario='+obj_campana["id"]+'">Ver</a>'+
                          '</label>'+
                        '</div>'+
                      '</div>'
                    );
        }

        function get_usuario_nombre(id_usuario){
          id_usuario = id_usuario || 0;
          nombre = JSON.parse(r_datos({funcion:'get_usuario_nombre',id:id_usuario}));          
          return nombre['usuario_name']
        }

        function get_campana_nombre_lista(id_campana){
          id_campana = id_campana || 0;
          nombre = JSON.parse(r_datos({funcion:'get_campana_nombre_lista',id:id_campana}));          
          return nombre['campana'][0]['nombre_campana'];
        }

        function parse_detalles_cuestionario(obj_detalles, obj_nombres){



          var campana = {'nombre':'','evaluador':'','encargado':'','fecha':'','tienda':'','editar':'','ver':'','eliminar':''}; 
          var fecha     = $("#range").val();               
          var ids = $( "#opciones_seleccion" ).val() || ["0"];



          var nombre_campana  = [];

          var fecha_sep_i = separar_fechas(fecha)[0];
          var fecha_sep_f = separar_fechas(fecha)[1];

          var fecha_inicio    = Date.parse(fecha_sep_i);
          var fecha_fin       = Date.parse(fecha_sep_f);

          var fecha_inicio_invertida = Date.parse(invertir_valor_fecha_mes(fecha_sep_i));
          var fecha_fin_invertida = Date.parse(invertir_valor_fecha_mes(fecha_sep_f));


          for (j=0; j<ids.length; j++){


            if (obj_detalles['campana'].length>0){
              for (i=0; i<obj_detalles['campana'].length; i++){ 
                var json_campana      =  JSON.parse(obj_detalles['campana'][i]['respuestas']);
                var json_id_respuesta =  JSON.parse(obj_detalles['campana'][i]['id_respuesta']);

                //Si el campo de tipo es igual a cero, json_id=0, si no camptura el 'id' del usuario
                  if ($('#tipo_seleccion').val()=='0'){
                    json_id = 0;
                  }else if($('#tipo_seleccion').val()=='1'){
                    json_id = JSON.parse(obj_detalles['campana'][i]['id_respuesta']);
                  }else if($('#tipo_seleccion').val()=='2'){
                    json_id = json_campana['nombre_evaluador'];                  
                  }else if($('#tipo_seleccion').val()=='3'){                  
                    json_id  = json_campana['persona_evento'];
                  }
                
                if (typeof json_campana == 'object'){

                  var json_fecha_invertida = typeof json_campana['fecha'] != 'undefined' ? Date.parse(invertir_valor_fecha_mes(json_campana['fecha'])) : '';
 
                  if((json_id==ids[j]) && (json_fecha_invertida>=fecha_inicio_invertida&&json_fecha_invertida<=fecha_fin_invertida)){

                    campana['id']         = json_id_respuesta                   !=''?json_id_respuesta:'';
                    campana['nombre']     = json_campana['nombre_campana']      !=''?json_campana['nombre_campana']:'';

                    campana['nombre'] = isNaN(campana['nombre'])?campana['nombre']:get_campana_nombre_lista(campana['nombre']);

                    var index_name        = obj_nombres['usuario_id'].indexOf(json_campana['nombre_evaluador']);
                    var index_evento      = obj_nombres['usuario_id'].indexOf(json_campana['persona_evento']);
                    

                    var nombre_evaluador  = index_name != -1 ? obj_nombres['usuario_name'][index_name] : '';
                    var nombre_evento     = index_evento != -1 ? obj_nombres['usuario_name'][index_evento] : '';

                    campana['evaluador']  = nombre_evaluador;
                    campana['encargado']  = nombre_evento;
                    campana['fecha']      = json_campana['fecha']               !=''?json_campana['fecha']:'';

console.log(campana);

                    agregar_fila(campana);
                  }
                                
                }
              }


              
            }
          }
          //console.log(r);
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

        

        function buscar(){
          /*var campana   = $('#campana').val();
          var evaluador = $('#evaluador').val();
          var encargado = $('#encargado').val();
          var fecha     = $('#range').val();

          buscar = JSON.parse(r_datos({funcion:'get_buscar'}));
          parse_buscar(buscar,campana,evaluador,encargado,fecha);*/

           $("#listado_respuestas").html("");

          var detalles = JSON.parse(r_datos({funcion:'get_detalles_cuestionario',id:"null"}));
          var users_name = JSON.parse(r_datos({funcion:'get_usuario_nombre',id:"null"}));
          
          parse_detalles_cuestionario(detalles, users_name);
        }

        $('#btn_buscar').on('click',function(){
          console.log("Buscando");
          buscar();
        })

        $('#tipo_seleccion').on('change',function(){
          console.log("Buscando");
          change_opciones_seleccion();
        })

        /*function inic_campana(){
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
        }*/

        function inic_detalles_cuestionario(){
          var detalles = JSON.parse(r_datos({funcion:'get_detalles_cuestionario',id:"null"}));
          var users_name = JSON.parse(r_datos({funcion:'get_usuario_nombre',id:"null"}));
          
          parse_detalles_cuestionario(detalles, users_name);
        }

        function inic_eliminar_cuestionario(id_cuestionario){
          eliminar_cuestionario = JSON.parse(r_datos({funcion:'eliminar_guestionario', id_cuestionario:id_cuestionario}));
          parse_evaluador(eliminar_cuestionario);
        }

        

        

        function inic(){
          //inic_campana();
          //inic_evaluador();
          //inic_encargado();
          inic_detalles_cuestionario();

        }

        inic();


    })
  </script>

</body>
<?php
}
else if($_SESSION['permiso']!='directivo'){
?>
<script>
alert("tu no tienes permiso para ver este contenido");
document.location.href="index.php?command=home";
</script>
<?php
}
?>