<?php
require_once 'class/class.cuestionario1.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='promotor'){

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
      });
    </script>

    <!-- Site wrapper -->
    <div class="wrapper">

      <?php require "views/promotor/header_promotor.php"; ?>

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
                        <label class="col-md-4 col-sm-6 col-xs-12">Nombre del evaluador: </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-user"></i></span>
                            <input type="text" name="nombre_evaluador" id="nombre_evaluador"  class="form-control">
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Nombre de la campaña </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-binoculars"></i></span>
                            <input type="text" name="nombre_campana" id="nombre_campana" class="form-control">
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Fecha: </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                            <input type="text" name="fecha" id="fecha"  class="form-control">
                          </div>
                        </div>
                      </div>
                                        
                    </div>

                    <div class="col-md-6 col-sm-6 col-xs-12">  

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12"># SAP (CTE): </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <span class="input-group-addon"><i class="fa  fa-tag"></i></span>
                            <input type="text" name="sap" id="sap"  class="form-control">
                          </div>
                        </div>
                      </div>  
                      
                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Tipo evento competencia: </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                            <input type="text" name="tipo_evento" id="tipo_evento"  class="form-control">
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Marca Competencia: </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                            <input type="text" name="marca_competencia" id="marca_competencia"  class="form-control">
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
                            <input type="checkbox" name="modulo" id="modulo"  class="minimal">
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Hay charola: </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="charola" id="charola"  class="minimal">
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Hay Sarteneta(si aplica): </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="sarteneta" id="sarteneta"  class="minimal">
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Hay Arco inflable (si aplica): </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="arco" id="arco"  class="minimal">
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Hay sonido: </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="sonido" id="sonido"  class="minimal">
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Hay adicional? (Botarga, brincolin, carrito HD o carpa) </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="adicional" id="adicional"  class="minimal">
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Producto suficiente para venta? </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="producto_sufucuente" id="producto_suficiente"  class="minimal">
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Hay degustación? </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="degustacion" id="degustacion"  class="minimal">
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-6 col-xs-12">Adicional de campaña (Folleto de bolsillo): </label>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                          <div class="input-group">
                            <input type="checkbox" name="adicional_campana" id="adicional_campana"  class="minimal">
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
                            <input type="text" name="persona_evento" id="persona_evento"  class="form-control">
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Puntualidad </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          
                            <input type="checkbox" name="puntualidad" id="puntualidad"  class="minimal">
                         
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Abordaje: </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          
                            <input type="checkbox" name="abordaje" id="abordaje"  class="minimal">
                          
                        </div>
                      </div>
                                        
                    </div>

                    <div class="col-md-6 col-sm-6 col-xs-12">  
                      
                      <div class="form-group row">
                        <label class="col-md-4 col-sm-6 col-xs-12">Conoce el objetivo de venta: </label>
                        <div class="col-md-8 col-sm-6 col-xs-12">
                          
                            <input type="checkbox" name="objetivo" id="objetivo"  class="minimal">
                          
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

                            <input type="checkbox" name="frase" id="frase"  class="minimal">
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-8 col-xs-12">¿Comunica los argumentos de venta? </label>
                        <div class="col-md-4 col-sm-4 col-xs-12">
                          <div class="input-group">

                            <input type="checkbox" name="argumentos" id="argumentos"  class="minimal">
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-8 col-xs-12">¿Comunica el precio? </label>
                        <div class="col-md-4 col-sm-4 col-xs-12">
                          <div class="input-group">

                            <input type="checkbox" name="precio" id="precio"  class="minimal">
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
                        <label class="col-md-8 col-sm-8 col-xs-12">Presentación del producto</label>
                        <div class="col-md-4 col-sm-4 col-xs-12">
                          <div class="input-group">

                            <input type="checkbox" name="presentacion_producto" id="presentacion_producto"  class="minimal">
                          </div>
                        </div>
                      </div>

                      <div class="form-group row">
                        <label class="col-md-8 col-sm-8 col-xs-12">Manejo y limpieza de materiales y equipo</label>
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
                            <textarea  name="cuestionario_observaciones" id="cuestionario_observaciones"  class="form-control"></textarea>
                          </div>
                        </div>
                      </div>

                    </div>
                  </div><!-- /.box-body -->
                </div><!-- /.box -->
              </div>
            </div>

            <div class="box-footer">
              <input type="submit" value="Guardar" name="btn_guardar_cuestionario1" id="btn_guardar_cuestionario1" class="btn btn-primary">
              <button class="btn btn-primary" type="cancel" onclick="javascript:location='index.php?command=respuestas_cuestionario1_directivo'">Cancelar</button>
            </div>
          </form>
        </section><!-- /.content -->
      </div><!-- /.content-wrapper -->


		  <?php require "views/promotor/footer_promotor.php" ?>
	  </div>

  <script>

   $(function () {
      //iCheck for checkbox and radio inputs
        $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
          checkboxClass: 'icheckbox_minimal-blue',
        });

        $("#fecha").inputmask("dd/mm/yyyy", {"placeholder": "dd/mm/yyyy"});
        
    })

  </script>

</body>
<?php
}
else if($_SESSION['permiso']!='promotor'){
?>
<script>
alert("tu no tienes permiso para ver este contenido");
document.location.href="index.php?command=home";
</script>
<?php
}
?>