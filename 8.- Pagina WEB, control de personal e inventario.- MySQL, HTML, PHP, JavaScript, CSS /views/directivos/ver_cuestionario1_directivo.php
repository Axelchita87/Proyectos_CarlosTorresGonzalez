<?php
require_once 'class/class.cuestionario1.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){

?>

  <body class="skin-blue">

    <script>
      $(function(){//Funciones para Ver Cuestionario1

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

        function get_usuario_nombre(id_usuario){
          id_usuario = id_usuario || 0;
          nombre = JSON.parse(r_datos({funcion:'get_usuario_nombre',id:id_usuario}));          
          return nombre['usuario_name']
        }
        

        function parse_cuestionario(obj_cuestionario){

          var nombre_campana  = [];
          var nombre = '';


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

          if (obj_cuestionario['campana'].length>0){
            for (i=0; i<obj_cuestionario['campana'].length; i++){ 
              var json_campana =  JSON.parse(obj_cuestionario['campana'][i]['respuestas']);
              var json_campana =  JSON.parse(obj_cuestionario['campana'][i]['respuestas']);
              var json_id      =  JSON.parse(obj_cuestionario['campana'][i]['id_respuesta']);


              //Campaña

              if (typeof json_campana == 'object'){

                  $('#nombre_tiendas').val(  json_campana['nombre_tiendas']                 != '' ? json_campana['nombre_tiendas'] : "" ); 
                  $('#nombre_evaluador').val(  json_campana['nombre_evaluador']             != '' ? get_usuario_nombre(json_campana['nombre_evaluador']) : '' ); 
                  $('#nombre_campana').val(    json_campana['nombre_campana']               != '' ? json_campana['nombre_campana'] : '' ); 
                  $('#fecha').val(    json_campana['fecha']                                 != '' ? json_campana['fecha'] : '' ); 
                  $('#tienda_activada').prop( 'checked',  json_campana['tienda_activada']   == 'on' ? true : false ); 
                  $('#sap').val(    json_campana['sap']                                     != '' ? json_campana['sap'] : '' ); 
                  $('#tipo_evento').val(    json_campana['tipo_evento']                     != '' ? json_campana['tipo_evento'] : '' ); 
                  $('#marca_competencia').val(    json_campana['marca_competencia']         != '' ? json_campana['marca_competencia'] : '' );

                  $('#modulo').prop( 'checked',  json_campana['modulo']                             == 'on' ? true : false ); 
                  $('#charola').prop( 'checked',   json_campana['charola']                          == 'on' ? true : false ); 
                  $('#sarteneta').prop( 'checked',   json_campana['sarteneta']                      == 'on' ? true : false ); 
                  $('#arco').prop( 'checked',   json_campana['arco']                                == 'on' ? true : false ); 
                  $('#sonido').prop(  'checked',  json_campana['sonido']                            == 'on' ? true : false ); 
                  $('#adicional').prop( 'checked',   json_campana['adicional']                      == 'on' ? true : false );
                  $('#producto_suficiente').prop( 'checked',   json_campana['producto_suficiente']  == 'on' ? true : false ); 
                  $('#degustacion').prop(  'checked',  json_campana['degustacion']                  == 'on' ? true : false ); 
                  $('#adicional_campana').prop( 'checked',   json_campana['adicional']              == 'on' ? true : false );

                  $('#persona_evento').val(  json_campana['persona_evento']     != '' ? get_usuario_nombre(json_campana['persona_evento']) : '' ); 

                  $('#frase').prop( 'checked',  json_campana['frase']                         == 'on' ? true : false ); 
                  $('#argumentos').prop( 'checked',   json_campana['argumentos']              == 'on' ? true : false ); 
                  $('#precio').prop( 'checked',   json_campana['precio']                      == 'on' ? true : false );

                  $('#imagen_persona').prop( 'checked',  json_campana['imagen_persona']                 == 'on' ? true : false ); 
                  $('#congruencia').prop( 'checked',   json_campana['congruencia']                      == 'on' ? true : false ); 
                  $('#presentacion_producto').prop( 'checked',   json_campana['presentacion_producto']  == 'on' ? true : false ); 
                  $('#manejo_limpieza').prop( 'checked',   json_campana['arco']                         == 'on' ? true : false ); 

                  $('#cuestionario_observaciones').val(    json_campana['cuestionario_observaciones'] != '' ? json_campana['cuestionario_observaciones'] : '' );
                  $('#logro_objetivo').prop( 'checked',   json_campana['logro_objetivo']               == 'on' ? true : false );
                  $('#porcentaje_objetivo').val(    json_campana['porcentaje_objetivo'] != '' ? json_campana['porcentaje_objetivo'] : '' );
             
              }
            }
          }

          //console.log(r);
        }

        function inic_cuestionario(id_cuestionario){
          id_cuestionario = id_cuestionario || 0
          cuestionario = JSON.parse(r_datos({funcion:'get_cuestionario',id:id_cuestionario}));
          console.log(cuestionario)
          parse_cuestionario(cuestionario);
        }

        function inic(){
          inic_cuestionario("'"+<?php echo isset($_GET['id_cuestionario'])?$_GET['id_cuestionario']:0; ?>+"'");
        }

        inic();

      });
    </script>

    <!-- Site wrapper -->
    <div class="wrapper">

      <?php require "views/directivos/header_directivo.php"; ?>

      <?php require "views/directivos/menu_vertical.php"; ?>
        <!-- Content Wrapper. Contains page content -->
      <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Cuestionario Sigma
            <small>Reporte</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#">Inicio</a></li>
          </ol>
        </section>

        <!-- Main content -->
        <section class="content">

          <form action="" method="POST" enctype="multipart/form-data"  role="form" id="form-modificar">

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="box box-primary">
                  <div class="box-header with-border">
                    <h3 class="box-title">Campaña</h3>
                    <div class="box-tools pull-right">
                      <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                      <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                    </div>
                  </div>
                  <div class="box-body">
                    <div class="col-md-6 col-sm-6 col-xs-12"> 

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Nombre Tienda: </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-user"></i></span>
                            <input type="text" name="nombre_tiendas" id="nombre_tiendas"  class="form-control" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Nombre del evaluador: </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-user"></i></span>
                            <input type="text" name="nombre_evaluador" id="nombre_evaluador"  class="form-control" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Nombre de la campaña </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-binoculars"></i></span>
                            <input type="text" name="nombre_campana" id="nombre_campana" class="form-control" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Fecha: </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                            <input type="text" name="fecha" id="fecha"  class="form-control" disabled>
                          </div>
                        </div>
                      </div>
                                        
                    </div>

                    <div class="col-md-6 col-sm-6 col-xs-12">  

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Tienda Activada: </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="radio" name="tienda_activada" id="tienda_activada"  class="minimal" disabled>
                          </div>
                        </div>
                        
                      </div>

                      <div class="form-group row" id="modulo_comentarios_no_activada">
                        <label class="col-md-4 col-sm-6 col-xs-12">¿Razón por la que no se activó la tienda?</label>

                        <div class="input-group col-md-4 col-sm-6 col-xs-12">
                          <label class="col-md-8 col-sm-8 col-xs-8">Sigma</label>
                          <input type="checkbox" name="no_activada_sigma" id="no_activada_sigma"  class="minimal" disabled>
                        </div>
                        <div class="input-group col-md-4 col-sm-6 col-xs-12">
                          <label class="col-md-8 col-sm-8 col-xs-8">Evolución</label>
                          <input type="checkbox" name="no_activada_evolucion" id="no_activada_evolucion"  class="minimal" disabled>
                        </div>
                        <div class="input-group col-md-7 col-sm-7 col-xs-7 col-md-offset-4 col-sm-offset-4 col-xs-offset-4"> 
                          <label class="col-md-8 col-sm-8 col-xs-8">¿Por qué?</label>
                          <textarea  name="comentarios_no_activada" id="comentarios_no_activada"  class="form-control" disabled></textarea>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12"># SAP (CTE): </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <span class="input-group-addon"><i class="fa  fa-tag"></i></span>
                            <input type="text" name="sap" id="sap"  class="form-control" disabled>
                          </div>
                        </div>
                      </div>  
                      
                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Tipo evento competencia: </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                            <input type="text" name="tipo_evento" id="tipo_evento"  class="form-control" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Marca Competencia: </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                            <input type="text" name="marca_competencia" id="marca_competencia"  class="form-control" disabled>
                          </div>
                        </div>
                      </div>
                      
                    </div>
                  </div><!-- /.box-body -->
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="box box-primary">
                  <div class="box-header with-border">
                    <h3 class="box-title">Competencia</h3>
                    <div class="box-tools pull-right">
                      <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                      <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                    </div>
                  </div>
                  <div class="box-body">
                    <div class="col-md-12 col-sm-12 col-xs-12">  
                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Hay módulo: </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="modulo" id="modulo"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Hay charola: </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="charola" id="charola"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Hay Sarteneta(si aplica): </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="sarteneta" id="sarteneta"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Hay Arco inflable (si aplica): </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="arco" id="arco"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Hay sonido: </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="sonido" id="sonido"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Hay adicional? (Botarga, brincolin, carrito HD o carpa) </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="adicional" id="adicional"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Producto suficiente para venta? </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="producto_sufucuente" id="producto_suficiente"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Hay degustación? </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="degustacion" id="degustacion"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Adicional de campaña (Folleto de bolsillo): </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="adicional_campana" id="adicional_campana"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div><!-- /.box-body -->
                </div><!-- /.box -->
              </div>
            </div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="box box-primary">
                  <div class="box-header with-border">
                    <h3 class="box-title">Evento</h3>
                    <div class="box-tools pull-right">
                      <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                      <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                    </div>
                  </div>
                  <div class="box-body">
                    <div class="col-md-6 col-sm-6 col-xs-12"> 

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Nombre de la persona que ejecuta el evento: </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-user"></i></span>
                            <input type="text" name="persona_evento" id="persona_evento"  class="form-control" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Azotea: </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          
                            <input type="checkbox" name="azotea" id="azotea"  class="minimal" disabled>
                          
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Puntualidad </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          
                            <input type="checkbox" name="puntualidad" id="puntualidad"  class="minimal" disabled>
                         
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Abordaje: </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          
                            <input type="checkbox" name="abordaje" id="abordaje"  class="minimal" disabled>
                          
                        </div>
                      </div>
                                        
                    </div>

                    <div class="col-md-6 col-sm-6 col-xs-12">  
                      
                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Conoce el objetivo de venta: </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          
                            <input type="checkbox" name="objetivo" id="objetivo"  class="minimal" disabled>
                          
                        </div>
                      </div>

                    </div>
                  </div><!-- /.box-body -->
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="box box-primary">
                  <div class="box-header with-border">
                    <h3 class="box-title">Comuniación</h3>
                    <div class="box-tools pull-right">
                      <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                      <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                    </div>
                  </div>
                  <div class="box-body">
                    <div class="col-md-12 col-sm-12 col-xs-12">  
                      
                      <div class="form-group row">
                        <label class="col-md-8 col-sm-8 col-xs-12">¿Menciona la frase rectora? </label>
                        <div class="col-md-4 col-sm-4 col-xs-12">
                          <div class="input-group">

                            <input type="checkbox" name="frase" id="frase"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-8 col-xs-12">¿Comunica los argumentos de venta? </label>
                        <div class="col-md-4 col-sm-4 col-xs-12">
                          <div class="input-group">

                            <input type="checkbox" name="argumentos" id="argumentos"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-8 col-xs-12">¿Comunica el precio? </label>
                        <div class="col-md-4 col-sm-4 col-xs-12">
                          <div class="input-group">

                            <input type="checkbox" name="precio" id="precio"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>

                    </div>
                  </div><!-- /.box-body -->
                </div><!-- /.box -->
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
                    <div class="col-md-12 col-sm-12 col-xs-12">  
                      
                      <div class="form-group row">
                        <label class="col-md-8 col-sm-8 col-xs-12">Imagen de la persona</label>
                        <div class="col-md-4 col-sm-4 col-xs-12">
                          <div class="input-group">

                            <input type="checkbox" name="imagen_persona" id="imagen_persona"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-8 col-xs-12">Congruencia de la marca</label>
                        <div class="col-md-4 col-sm-4 col-xs-12">
                          <div class="input-group">

                            <input type="checkbox" name="congruencia" id="congruencia"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-8 col-xs-12">Presentación del producto</label>
                        <div class="col-md-4 col-sm-4 col-xs-12">
                          <div class="input-group">

                            <input type="checkbox" name="presentacion_producto" id="presentacion_producto"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-8 col-xs-12">Manejo y limpieza de materiales y equipo</label>
                        <div class="col-md-4 col-sm-4 col-xs-12">
                          <div class="input-group">

                            <input type="checkbox" name="manejo_limpieza" id="manejo_limpieza"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>

                    </div>

                  </div><!-- /.box-body -->
                </div><!-- /.box -->
              </div>
            </div>

            <div class="row">
              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="box box-primary">
                  <div class="box-header with-border">
                    <h3 class="box-title">Comentarios</h3>
                    <div class="box-tools pull-right">
                      <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                      <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                    </div>
                  </div>
                  <div class="box-body">
                    <div class="col-md-12 col-sm-12 col-xs-12">  
                      
                      <div class="form-group row">
                        <label class="col-md-4 col-sm-4 col-xs-12">Observaciones</label>
                        <div class="col-md-8 col-sm-8 col-xs-12">
                          <div class="input-group">
                            <textarea  name="cuestionario_observaciones" id="cuestionario_observaciones"  class="form-control" disabled></textarea>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-8 col-xs-12">Logró objetivo de venta</label>
                        <div class="col-md-4 col-sm-4 col-xs-12">
                          <div class="input-group">

                            <input type="checkbox" name="logro_objetivo" id="logro_objetivo"  class="minimal" disabled>
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Porcentaje de Objetivo logrado</label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <span class="input-group-addon"><i class="fa"></i></span>
                            <input type="text" name="porcentaje_objetivo" id="porcentaje_objetivo"  class="form-control" disabled>
                          </div>
                        </div>
                      </div>

                    </div>
                  </div><!-- /.box-body -->
                </div><!-- /.box -->
              </div>
            </div>

            <div class="box-footer">
              <button name="btn_editar_cuestionario1" id="btn_editar_cuestionario1" class="btn btn-primary">Editar</button>
              <input type="hidden" id="click_modificar_cuestionario1" name="click_modificar_cuestionario1" value="Guardar"/>
              <button name="btn_volver_cuestionario1" id="btn_volver_cuestionario1" class="btn btn-primary">Volver</button>
            </div>

          </form>
          

        </section><!-- /.content -->
      </div><!-- /.content-wrapper -->


		  <?php require "views/directivos/footer_directivo.php" ?>
	  </div>

  <script>

   $(function () {
      //iCheck for checkbox and radio inputs
        $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
          checkboxClass: 'icheckbox_minimal-blue',
        });

        $("#fecha").inputmask("dd/mm/yyyy", {"placeholder": "dd/mm/yyyy"});

        //Funciones boton editar
        $(document).on("click","#btn_editar_cuestionario1",function(event){

          event.preventDefault();
          event.stopPropagation();

          if ( $("div.icheckbox_minimal-blue").hasClass('disabled') ){
            $("input[type='checkbox'], #porcentaje_objetivo, #cuestionario_observaciones, #comentarios_no_activada").prop("disabled",false);
            $("div.icheckbox_minimal-blue").removeClass('disabled');
            
            $("#btn_volver_cuestionario1").attr("id","btn_cancelar_cuestionario1");
            $("#btn_cancelar_cuestionario1").attr("name","btn_cancelar_cuestionario1");            
            $("#btn_cancelar_cuestionario1").html("Cancelar");

            $("#btn_editar_cuestionario1").attr("id","btn_modificar_cuestionario1");
            $("#btn_modificar_cuestionario1").attr("name","btn_modificar_cuestionario1");
            $("#btn_modificar_cuestionario1").html("Guardar");

          }
        })

        $(document).on("click","#btn_volver_cuestionario1",function(event){

          event.preventDefault();
          event.stopPropagation();

          location.href="index.php?command=cuestionario1_detalles_directivo";

        })

        $(document).on("click","#btn_cancelar_cuestionario1",function(event){

          event.preventDefault();
          event.stopPropagation();

          if ( !$("div.icheckbox_minimal-blue").hasClass('disabled') ){
            $("input[type='checkbox'], #porcentaje_objetivo, #cuestionario_observaciones, #comentarios_no_activada").prop("disabled",true);
            $("div.icheckbox_minimal-blue").addClass('disabled');

            $("#btn_cancelar_cuestionario1").attr("id","btn_volver_cuestionario1");
            $("#btn_volver_cuestionario1").attr("name","btn_volver_cuestionario1");
            $("#btn_volver_cuestionario1").html("Volver");

            $("#btn_modificar_cuestionario1").attr("id","btn_editar_cuestionario1");
            $("#btn_editar_cuestionario1").attr("name","btn_editar_cuestionario1");
            $("#btn_editar_cuestionario1").html("Editar");
          }

        })

        $('#tienda_activada').on("ifChecked ifUnchecked",function(e){
          if(e.type ==="ifChecked"){
            $('tienda_activada').iCheck('update');
            $('#modulo_comentarios_no_activada').hide();
          }else{
            $('#modulo_comentarios_no_activada').show();
          }
        })
        
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