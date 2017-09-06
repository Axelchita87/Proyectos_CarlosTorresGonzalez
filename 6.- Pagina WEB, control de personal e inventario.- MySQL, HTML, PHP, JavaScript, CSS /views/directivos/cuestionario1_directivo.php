<?php
require_once 'class/class.cuestionario1.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){

  ?>

  <body class="skin-blue">

    <script>
      $(function(){//Funciones para Cuestionario1

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



        function parse_evaluador(obj_evaluador){
          var nombre_evaluador = [];
          //console.log(obj_evaluador);
          if (obj_evaluador['evaluador'].length>0){
            $('#nombre_evaluador').html('<option value="0">Selecciona...</option>');
            for (i=0; i<obj_evaluador['evaluador'].length; i++){ 
              var nombre = obj_evaluador['evaluador'][i]['User_name'];
              var id     = obj_evaluador['evaluador'][i]['id_usuario'];
              $('#nombre_evaluador').append("<option value='"+id+"'>"+nombre+"</option>");
            }
            console.log(nombre_evaluador);
          }
          //console.log(r);
        }

        function parse_encargado(obj_encargado){
          var nombre_evaluador = [];
          //console.log(obj_encargado);
          if (obj_encargado['usuarios'].length>0){
            $('#persona_evento').html('<option value="0">Selecciona...</option>');
            for (i=0; i<obj_encargado['usuarios'].length; i++){ 
              var nombre = obj_encargado['usuarios'][i]['User_name'];
              var id     = obj_encargado['usuarios'][i]['id_usuario'];
              $('#persona_evento').append("<option value='"+id+"'>"+nombre+"</option>");
            }
            console.log(nombre_evaluador);
          }
          //console.log(r);
        }

        function get_campana_nombre_lista(id_campana){
          id_campana = id_campana || 0;
          nombre = JSON.parse(r_datos({funcion:'get_campana_nombre_lista',id:id_campana}));          
          return nombre['campana'][0]['nombre_campana'];
        }

        function parse_campanas_list(obj_campana){
          var nombre_campana = [];
          console.log(obj_campana);
          if (obj_campana['campana'].length>0){
            $('#nombre_campana').html('<option value="0">Selecciona...</option>');
            for (i=0; i<obj_campana['campana'].length; i++){ 
              var nombre = obj_campana['campana'][i]['nombre_campana'];
              var id     = obj_campana['campana'][i]['id_campana'];

              nombre = isNaN(nombre)?nombre:get_campana_nombre_lista(nombre);


              $('#nombre_campana').append("<option value='"+id+"'>"+nombre+"</option>");
            }
            console.log(nombre_campana);
          }
          //console.log(r);
        }

        function parse_tiendas_list(obj_campana){
          var nombre_campana = [];
          console.log(obj_campana);
          if (obj_campana['campana'].length>0){
            $('#nombre_tiendas').html('<option value="0">Selecciona...</option>');
            for (i=0; i<obj_campana['campana'].length; i++){ 
              var nombre = obj_campana['campana'][i]['cac_name'];
              var id     = obj_campana['campana'][i]['id_cac'];

              nombre = isNaN(nombre)?nombre:get_campana_nombre_lista(nombre);


              $('#nombre_tiendas').append("<option value='"+id+"'>"+nombre+"</option>");
            }
            console.log(nombre_campana);
          }
          //console.log(r);
        }


        function inic_evaluador(){
          evaluador = JSON.parse(r_datos({funcion:'get_evaluador'}));
          parse_evaluador(evaluador);
        }

        function inic_encargado(){
          encargado = JSON.parse(r_datos({funcion:'get_encargado'}));
          parse_encargado(encargado);
        }

        function inic_campanas_list(){
          campanas = JSON.parse(r_datos({funcion:'get_campanas_list'}));
          parse_campanas_list(campanas);
        }

        function inic_tiendas_list(){
          tiendas = JSON.parse(r_datos({funcion:'get_tiendas_list'}));
          parse_tiendas_list(tiendas);
        }

        
        //Validar los campos obligatorios
        $("#form-alta").submit(function() {
          var x = 0;
          $('#form-alta input.form-control').each(function(){
            if($(this).val()==''){
              x += 1; 
            }
          });

          $('#form-alta input.minimal').each(function(){

            if(!$(this).is(':checked')){
              x += 1; 
            }
          });
          console.log(x);

          var x2 = $("#contrasena").val();
          var x3 = $("#permiso").val();
          if (x>0) {
            if(confirm("No has llenado todos los campos, \nestas segur@ de querer enviar el formulario?")){
              return true;
            }else{
              return false;
            }
          } else
          return true;
        });


        function inic(){
          inic_evaluador();
          inic_encargado();
          inic_campanas_list();
          inic_tiendas_list();
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

      <!-- Default box -->
      <form action="index.php?command=cuestionario1_directivo" method="POST" enctype="multipart/form-data"  role="form" id="form-alta" >
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
                    <label class="col-md-4 col-sm-6 col-xs-12">Nombre del lugar: </label>
                    <div class="col-md-8 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                        <select name="nombre_tiendas" id="nombre_tiendas"  class="form-control">
                          <option>Selecciona...</option>
                        </select>
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-4 col-sm-6 col-xs-12">Nombre del evaluador: </label>
                    <div class="col-md-8 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                        <select name="nombre_evaluador" id="nombre_evaluador"  class="form-control">
                          <option>Selecciona...</option>
                        </select>
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-4 col-sm-6 col-xs-12">Nombre del servicio </label>
                    <div class="col-md-8 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-binoculars"></i></span>
                        <select name="nombre_campana" id="nombre_campana"  class="form-control">
                          <option>Selecciona...</option>
                        </select>
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-4 col-sm-6 col-xs-12">Fecha: </label>
                    <div class="col-md-8 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                        <input type="text" name="fecha" id="fecha"  class="form-control" readonly>
                      </div>
                    </div>
                  </div>
                  
                </div>

                <div class="col-md-6 col-sm-6 col-xs-12">  

                  <div class="form-group row"style="display:none;">
                    <label class="col-md-4 col-sm-6 col-xs-12">Tienda Activada: </label>
                    <div class="col-md-8 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="tienda_activada" id="tienda_activada"  class="minimal">
                      </div>
                    </div>                        
                  </div> 
                  <div class="form-group row">
                    <label class="col-md-4 col-sm-6 col-xs-12">Personal de limpieza cuenta con el uniforme correspondiente: </label>
                    <div class="col-md-8 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="personal_uniforme" id="personal_uniforme"  class="minimal">
                      </div>
                    </div>                        
                  </div>   
                  <div class="form-group row">
                    <label class="col-md-4 col-sm-6 col-xs-12">Personal de limpieza utiliza señalamientos de seguridad: </label>
                    <div class="col-md-8 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="personal_seguridad" id="personal_seguridad"  class="minimal">
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
                <h3 class="box-title">LOBBY DEL PH AL LOBBY 2</h3>
                <div class="box-tools pull-right">
                  <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                  <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                </div>
              </div>
              <div class="box-body">
                <div class="col-md-12 col-sm-12 col-xs-12">  
                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Piso marmol se encuentra libre de polvo, hojas de las plantas, tierra de maceta, agua: </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="marmol_ibre_s" id="marmol_libre_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Piso marmol se encuentra quemado, fracturado: </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="marmol_quemado_s" id="marmol_quemado_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Vidrios principales limpios y sin manchas de manos: </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="vidrio_limpios_s" id="vidrio_limpios_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Marquesina libre de polvo e incestos: </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="marquesina_libre_s" id="marquesina_libre_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Socio libre de polvo: </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="socio_libre_s" id="socio_libre_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Paredes de lobby libre de polvos y/o manchas: </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="paredes_libres_s" id="paredes_libres_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Madera libre de polvo y encerada </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="madera_libre_s" id="madera_libre_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Mesas limpias y libres de polvo </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="mesas_libres_s" id="mesas_libres_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Sillones libres de polvo, limpio </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="silones_libres_s" id="silones_libres_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Cuadros y espejos libres de polvo y grasa: </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="cuadros_libres_s" id="cuadros_libres_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Macetas se encuentran en buen estado </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="macetas_buenas_s" id="macetas_buenas_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Puertas, botoneras de elvadores limpios sin manchas </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="puertas_limpias_s" id="puertas_limpias_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Marco de los elevadores libre de polvo, rieles limpios </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="elevadores_limpios_s" id="elevadores_limpios_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Lampas laterales en elevadores libres de polvo </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="lampas_libres_s" id="lampas_libres_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Botoneras condominios libre de polvo limpias </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="botoneras_libres_s" id="botoneras_libres_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Puertas para accesar areas de servicio y marco, libres de polvo </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="puertasServicio_libres_s" id="puertasServicio_libres_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Ceniceros limpios y sin comillas de cigarro </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="ceniceros_limpios_s" id="ceniceros_limpios_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Plantas artificiales libres de polvo </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="plantasArtificiales_limpias_s" id="plantasArtificiales_limpias_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Pisos de marmol de lobby desde el 18 al piso 2 se encuentran sin </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="pisosMarmol_s" id="pisosMarmol_S"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Terraza barridas limpias y libre de polvo </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="terraza_limpia_s" id="terraza_limpia_s"  class="minimal">
                      </div>
                    </div>
                  </div>



                </div>
              </div><!-- /.box-body -->
            </div><!-- /.box -->
          </div>
          


          
          <div class="col-md-6 col-sm-6 col-xs-12">
            <div class="box box-primary">
              <div class="box-header with-border">
                <h3 class="box-title">AREA DE SERVICIO DE PH AL PISO</h3>
                <div class="box-tools pull-right">
                  <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                </div>
              </div>
              <div class="box-body">
                <div class="col-md-12 col-sm-12 col-xs-12">  
                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Piso y escaleras de PH al piso 2 de limpios sin materia (papel, tierra, hilos, plásticos, colillas): </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="piso_limpios_s" id="piso_limpios_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Botoneras libre de polvo: </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="botonera_libre_s" id="botonera_libre_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Contenedor de hidrante libre de polvo, vidrio limpio: </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="contenedor_libre_s" id="contenedor_libre_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Verticales libre de polvo limpio: </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="verticales_libre_s" id="verticales_libre_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Puertas internas y externas de elevador limpio sin manchas de manos: </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="puestas_ele_s" id="puestas_ele_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Piso de elevador, paredes, botonera y riel limpio sin manchas de manos: </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="piso_ele_s" id="piso_ele_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Pared y socio libre de polvo </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="pared_libre_s" id="pared_libre_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Barandal de escaleras en sus tres niveles libre polvo y limpios</label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="barandal_libres_s" id="barandal_libres_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Pared manchado de lado de lado descando de escaleras </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="pared_manchado_s" id="pared_manchado_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Pollos limpios, barandal y base libre de polvo y limpio, ventanal libre de manchas: </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="pollos_limpios_s" id="pollos_limpios_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Puertas de ductos interna y externa limpias </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="puertas_ductos_s" id="puertas_ductos_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Botes de basura limpios sin residuos de basura o liquidos </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="botes_limpios_s" id="botes_limpios_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Se bajo basura en tiempo y forma </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="bajo_basura_s" id="bajo_basura_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Ducto de basura se encuentra tapado </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="ducto_basura_s" id="ducto_basura_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Escaleras de emergencia limpias </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="escaleras_limpias_s" id="escaleras_limpias_s"  class="minimal">
                      </div>
                    </div>
                  </div>

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Azotea barrida, domos limpios libre de hongos </label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="azotea_barrida_s" id="azotea_barrida_s"  class="minimal">
                      </div>
                    </div>
                  </div>               

                </div>
              </div><!-- /.box-body -->
            </div><!-- /.box -->
          </div>
        </div>
        
        <div class="row">

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
                  <div class="form-group row" >
                    <label class="col-md-8 col-sm-8 col-xs-12">Imagen de la persona</label>
                    <div class="col-md-4 col-sm-4 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="imagen_persona" id="imagen_persona"  class="minimal">
                      </div>
                    </div>
                  </div>
                  <div class="form-group row">
                    <label class="col-md-8 col-sm-8 col-xs-12">Congruencia de la marca</label>
                    <div class="col-md-4 col-sm-4 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="congruencia" id="congruencia"  class="minimal">
                      </div>
                    </div>
                  </div>
                  <div class="form-group row">
                    <label class="col-md-8 col-sm-8 col-xs-12">Presentación del degustación</label>
                    <div class="col-md-4 col-sm-4 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="presentacion_producto" id="presentacion_producto"  class="minimal">
                      </div>
                    </div>
                  </div>
                  <div class="form-group row">
                    <label class="col-md-8 col-sm-8 col-xs-12">Presentación Producto vta</label>
                    <div class="col-md-4 col-sm-4 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="manejo_limpieza" id="manejo_limpieza"  class="minimal">
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
                <h3 class="box-title">Servicio</h3>
                <div class="box-tools pull-right">
                  <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                  <button class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove"><i class="fa fa-times"></i></button>
                </div>
              </div>
              <div class="box-body">
                <div class="col-md-12 col-sm-12 col-xs-12">  

                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Lavado de piso en sotanos</label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="lavado_piso" id="lavado_piso"  class="minimal">
                      </div>
                    </div>
                  </div>  
                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Lavado de vidrios</label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="lavado_vidrios" id="lavado_vidrios"  class="minimal">
                      </div>
                    </div>
                  </div>  
                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Frente</label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="frente" id="frente"  class="minimal">
                      </div>
                    </div>
                  </div>     
                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Derecho</label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="derecho" id="derecho"  class="minimal">
                      </div>
                    </div>
                  </div>    
                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Izquierdo</label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="izquierdo" id="izquierdo"  class="minimal">
                      </div>
                    </div>
                  </div>    
                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Posteriores</label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="posteriores" id="posteriores"  class="minimal">
                      </div>
                    </div>
                  </div>    
                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Lavado interior vidrios alberca</label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="lavado_alberca" id="lavado_alberca"  class="minimal">
                      </div>
                    </div>
                  </div>         
                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Lobbys sotanos limpieaza profunda</label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="lobbys_limpieza" id="lobbys_limpieza"  class="minimal">
                      </div>
                    </div>
                  </div> 
                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Escaleras de emergencia</label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="escaleras" id="escaleras"  class="minimal">
                      </div>
                    </div>
                  </div> 
                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Lavado de alfombras</label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="alfombras" id="alfombras"  class="minimal">
                      </div>
                    </div>
                  </div> 
                  <div class="form-group row">
                    <label class="col-md-8 col-sm-6 col-xs-12">Cine</label>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                      <div class="input-group">
                        <input type="checkbox" name="cine" id="cine"  class="minimal">
                      </div>
                    </div>
                  </div> 

                </div>
              </div><!-- /.box-body -->
            </div><!-- /.box -->
          </div>
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

                  <div class="form-group row" >
                    <label class="col-md-4 col-sm-4 col-xs-12">Observaciones</label>
                    <div class="col-md-8 col-sm-8 col-xs-12">
                      <div class="input-group">
                        <textarea  name="cuestionario_observaciones" id="cuestionario_observaciones"  class="form-control"></textarea>
                      </div>
                    </div>
                  </div>
                </div>
              </div>                  
            </div><!-- /.box -->
          </div>
        </div>

        <input type="submit" value="Guardar" name="btn_guardar_cuestionario1" id="btn_guardar_cuestionario1" class="btn btn-primary">
        <button class="btn btn-primary" type="cancel" onclick="javascript:location='index.php?command=respuestas_cuestionario1_directivo'">Cancelar</button>
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

      var fecha   = new Date();
      var Year    = fecha.getFullYear();
      var Month   = fecha.getMonth()+1;
      var Day     = fecha.getDate();

      Month       =  Month < 10 ? "0" + Month : Month;

      $("#fecha").inputmask("dd/mm/yyyy", {"placeholder": "dd/mm/yyyy"});
      $("#fecha").val(Day+"/"+Month+"/"+Year);
      
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