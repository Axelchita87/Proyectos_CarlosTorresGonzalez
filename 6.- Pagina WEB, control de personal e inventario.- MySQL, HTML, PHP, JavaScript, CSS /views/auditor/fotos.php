<?php
require_once 'class/class.db.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='auditor'){
?>

<body class="skin-blue sidebar-mini">

   <style>

        .fancybox-thumbs{
            width: 40px;
            height:40px;
            text-align: center;
            display:inline-block;
        }
        .fancybox-thumbs img{
            max-width: 100%;
            max-height: 100%;
        }

        .contImgPrimcipal{
            width: 150px;
            height:150px;
            margin:10px auto;
            text-align: center;

        }

        .contImgPrimcipal img{
            max-width: 100%;
            max-height: 100%;
        }

        .bottom-thumbs{
            left: 0;
            overflow: hidden;
            width: 100%;
        }

        .bottom-thumbs ul{
            padding: 0;
        }

        .bottom-thumbs ul li {
            float: left;
            opacity: 0.75;
            padding: 0;
            list-style: outside none none;
            margin: 1px;
        }

        #fancybox-thumbs ul li a{
          width:50px;
          height:50px;
        }
        

    </style>

<!-- Add jQuery library -->
  <script type="text/javascript" src="js/lib/jquery-1.10.1.min.js"></script>

  <!-- Add mousewheel plugin (this is optional) -->
  <script type="text/javascript" src="js/lib/jquery.mousewheel-3.0.6.pack.js"></script>

  <!-- Add fancyBox main JS and CSS files -->
  <script type="text/javascript" src="js/source/jquery.fancybox.js?v=2.1.5"></script>
  <link rel="stylesheet" type="text/css" href="js/source/jquery.fancybox.css?v=2.1.5" media="screen" />

  <!-- Add Button helper (this is optional) -->
  <link rel="stylesheet" type="text/css" href="js/source/helpers/jquery.fancybox-buttons.css?v=1.0.5" />
  <script type="text/javascript" src="js/source/helpers/jquery.fancybox-buttons.js?v=1.0.5"></script>

  <!-- Add Thumbnail helper (this is optional) -->
  <link rel="stylesheet" type="text/css" href="js/source/helpers/jquery.fancybox-thumbs.css?v=1.0.7" />
  <script type="text/javascript" src="js/source/helpers/jquery.fancybox-thumbs.js?v=1.0.7"></script>

  <!-- Add Media helper (this is optional) -->
  <script type="text/javascript" src="js/source/helpers/jquery.fancybox-media.js?v=1.0.6"></script>

  <script type="text/javascript">
    $(document).ready(function() {
      
      

      $('.fancybox-thumbs').fancybox({
        prevEffect : 'none',
        nextEffect : 'none',

        closeBtn  : false,
        arrows    : false,
        nextClick : true,

        helpers : {
          thumbs : {
            //width  : 50,
            //height : 50
          }
        }
      });
      

      //recuperar datos 
        r_datos = function(options){

          options=(options==typeof(undefined))?'':options;
          params=options;
          var datos = $.ajax({
                url:'class/funcionesFotos.php',
              type:'post',
              dataType:'json',
                data:params,
              async:false       
          }).responseText;
          return datos
          }

      $('#fecha_i').val(function(){
        fecha = new Date().getFullYear()+"/"+("0" + (new Date().getMonth()+1)).slice(-2)+"/"+("0" + new Date().getDate()).slice(-2);

        $('#campo-periodo').html(fecha);
        return(fecha)
      });

      $('#btn_buscar_filtrar').on("click",function(){
        var a=$('#promotor_fotos').val();
        var b=$('#cac_fotos').val();
        var c=$('#fotos_clasificacion').val();
        var fi= $('#fecha_i').val();
        var ff= $('#fecha_f').val();
        var valores = r_datos({'get_foto_usuario':a,'get_foto_cac':b,'get_foto_clasificacion':c, 'fecha_i':fi, 'fecha_f':ff});

        v_valores = JSON.parse(valores)
        $('#contenedor-galeria').html(v_valores[0]);
      })

      function ini(){
        var fi= $('#fecha_i').val();
        var ff= $('#fecha_f').val();
        var valores = r_datos({'get_foto_usuario':'0','get_foto_cac':'0','get_foto_clasificacion':'0','fecha_i':fi, 'fecha_f':ff});

        v_valores = JSON.parse(valores)
        $('#contenedor-galeria').html(v_valores[0]);  
      }


      ini();

      
    });
  </script>


    
<div class="wrapper">      

      <?php require "views/auditor/menu_vertical.php" ?>      
      <?php require "views/auditor/header_auditor.php" ?>


      <div class="content-wrapper">

      
       <!-- Main content -->
        <section class="content"> 

      <section class="content-header">
        <h1>
          Fotografías
        </h1>
        <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                <li><a href="#">Fotografías</a></li>
              </ol>
      </section>

        <div id="" class="">

          <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="box box-primary collapsed-box">
          <div class="box-header">
            <h4>Organizar por: </h4>
            <div class="box-tools pull-right">
              <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>             
            </div>
          </div>
          <div class="box-body">

            <div class="col-md-8 col-sm-8 col-xs-12">
              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label>Promotor</label>
                  <div class="input-group">
                    <span class="input-group-addon">@</span>
                    <select class="form-control" name="promotor_fotos" id="promotor_fotos" style="width:95%">
                      <option value="0">Todos</option>
                        <?php
                          global $obj_db;
                          $consulta = "SELECT id_usuario, CONCAT(user_nombre,' ',apellido_paterno) AS nombrec, id_right FROM usuario WHERE id_right=3 ORDER BY user_nombre ASC";
                          $result = $obj_db->consulta($consulta);
                          if($result!=false){
                            foreach($result as $fila){
                            echo "<option value ='".$fila['id_usuario']."'>".$fila['nombrec']."</option>";
                            }
                          }
                        ?>
                    </select> 
                  </div>
                </div>
              </div>

              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label>Clasificación</label>
                  <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-map-marker"></i></span>
                    <select class="form-control" name="fotos_clasificacion" id="fotos_clasificacion" style="width:95%">
                      <option value="0">Todos</option>
                        <?php
                          global $obj_db;
                          $consulta = "SELECT id_fotos_clasificacion, fotos_clasificacion_name FROM fotos_clasificacion ORDER BY fotos_clasificacion_name ASC";
                          $result = $obj_db->consulta($consulta);
                          if($result!=false){
                            foreach($result as $fila){
                            echo "<option class='' value ='".$fila['id_fotos_clasificacion']."'>".utf8_encode($fila['fotos_clasificacion_name'])."</option>";
                            }
                          }
                        ?>
                    </select> 
                  </div>
                </div>
              </div>


              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label>Tiendas</label>
                  <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-dot-circle-o"></i></span>
                    <select class="form-control" name="cac_fotos" id="cac_fotos" style="width:95%">
                      <option value="0">Todas</option>
                        <?php
                          global $obj_db;
                          $consulta = "SELECT id_cac, cac_name FROM cac ORDER BY cac_name ASC";
                          $result = $obj_db->consulta($consulta);
                          if($result!=false){
                            foreach($result as $fila){
                            echo "<option class='' value ='".$fila['id_cac']."'>".utf8_encode($fila['cac_name'])."</option>";
                            }
                          }
                        ?>
                    </select> 
                  </div>
                </div>
              </div>
            </div>

            <div class="col-md-4 col-sm-4 col-xs-12">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="form-group">
                  <label>Fecha Inicial:</label>
                  <div class="input-group">
                    <div class="input-group-addon">
                      <i class="fa fa-calendar"></i>
                    </div>
                    <input type="text" id="fecha_i" class="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask/>
                  </div><!-- /.input group -->
                </div><!-- /.form group -->
              </div>

              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="form-group">
                  <label>Fecha Final:</label>
                  <div class="input-group">
                    <div class="input-group-addon">
                      <i class="fa fa-calendar"></i>
                    </div>
                    <input type="text" id="fecha_f" class="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask/>
                  </div><!-- /.input group -->
                </div><!-- /.form group -->
              </div>

            </div>

            <div class="col-md-12 col-sm-12 col-xs-12">
              <div class="" style="text-align:right;">
                <div id="btn_buscar_filtrar" class="btn btn-primary">Buscar</div>
              </div>
            </div>
          </div>
        </div>
        </div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">

            <div id="contenedor-galeria">
          
            </div>
          </div>

        </div>

        </div>


    </section>
  </div>
    <?php require "views/auditor/footer_auditor.php"; ?>
</div>

<script>

  $(function () {

    

        //Fechas
        $("[data-mask]").inputmask("yyyy/mm/dd");
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