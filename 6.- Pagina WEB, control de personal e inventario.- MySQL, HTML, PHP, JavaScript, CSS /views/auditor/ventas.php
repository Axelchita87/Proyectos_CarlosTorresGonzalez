
<?php
require_once 'class/class.altas.php';
//session_start();
if(isset($_SESSION['user']) && $_SESSION['permiso']=='auditor'){

?>

  <body class="skin-blue sidebar-mini">
    

  <style>

  #reporte {position:relative;}
  #reporte .header{color:#333;font-weight: bolder; text-align: center;}
  #reporte .label{color:#333;}
  #reporte .campo{color:#333;}
  #reporte #foto{border:1px solid #ccc; width:120px;height:150px;position:absolute; right:20px;}
  #reporte img{max-width: 100%; max-height: 100%; top:0; bottom: 0; right:0; left:0;position:absolute; margin: auto;}
  #detalles, #cuotas{clear: both;}

  #cont-detalles table {width:100%;}

  /*.cont-graficas{min-height: 300px; border:#FFF solid 1px; transition:border 1s;}
  .cont-graficas:hover{border:#F11111 solid 1px;}*/
  .menu-edit{position:absolute;top:5px; right:5px; list-style: none; cursor:pointer; text-align: right;z-index:100;}
  .menu-edit li img{border:solid #fff .5px;padding:3px;}
  .menu-edit li img:hover{border:solid #ccc .5px;transition:border .5s}
  .menu-edit li .submenu-edit{list-style: none;}
  .menu-edit li .submenu-edit li{cursor:pointer;display:block;text-align: left; padding:3px 20px; background-color: #eee; border-bottom:#aaa solid 1px;font-weight:bold;}
  .menu-edit li .submenu-edit li:hover{background-color:#999; color:#FFF;transition:background-color .5s, color .5s;}


.modalmask, .modalmask2{
    position: fixed;
    font-family: Arial, sans-serif;
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    background: rgba(0,0,0,0.8);
    z-index: 99999;
    opacity:1;
    -webkit-transition: opacity 400ms ease-in;
    -moz-transition: opacity 400ms ease-in;
    transition: opacity 400ms ease-in;
    pointer-events: none;
    display:none;
}
.modalmask, .modalmask2{
    pointer-events: auto;
}

.modalbox{
    /*width: 400px;*/
    position: relative;
    padding: 5px 20px 13px 20px;
    background: #fff;
    border-radius:3px;
    -webkit-transition: all 500ms ease-in;
    -moz-transition: all 500ms ease-in;
    transition: all 500ms ease-in;
     text-align: center
}

.modalmask2 .modalbox{padding: 5px 35px 13px 35px;}

.modalbox img{width:45%; border: 1px solid #999; margin:3px;}
.btn-grafica{cursor:pointer;}

.modalmask .movedown, .modalmask2 .movedown{       
    margin:10% auto;
    float:none;
}


.close {
    background: #606061;
    color: #FFFFFF;
    line-height: 25px;
    position: absolute;
    right: 1px;
    text-align: center;
    top: 1px;
    width: 24px;
    text-decoration: none;
    font-weight: bold;
    border-radius:3px;
 
}
 
.close:hover {
    background: #FAAC58;
    color:#222;
}


</style> 

<script>
  $(function(){
    $('#export-excel').click(function(){
        vars = "?fecha_i="+$('#fecha_i').val()+"&fecha_f="+$('#fecha_f').val()+"&promotor="+$('#promotor').val()+"&estado="+$('#estados').val()+"&cac="+$('#cac_menu').val();
        document.location.href="reporteexcel.php"+vars;
    })
  })

</script>


<div class="wrapper">
      
      

      <?php require "views/auditor/menu_vertical.php" ?>      
      <?php require "views/auditor/header_auditor.php" ?>

      
      <div class="content-wrapper">

      
       <!-- Main content -->
        <section class="content">  
      <div id="contenedor" class="row">
        
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
                    <select class="form-control" name="promotor" id="promotor" style="width:95%">
                      <option value="0">Todos</option>
                        <?php
                          global $obj_db;
                          $consulta = "SELECT id_usuario, user_name, id_right FROM usuario WHERE id_right=3 ORDER BY user_name ASC";
                          $result = $obj_db->consulta($consulta);
                          if($result!=false){
                            foreach($result as $fila){
                            echo "<option value ='".$fila['id_usuario']."'>".$fila['user_name']."</option>";
                            }
                          }
                        ?>
                    </select> 
                  </div>
                </div>
              </div>

              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label>Región</label>
                  <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-map-marker"></i></span>
                    <select class="form-control" name="estados" id="estados" style="width:95%">
                      <option value="0">Todos</option>
                        <?php
                          global $obj_db;
                          $consulta = "SELECT id_estado, nombre FROM estados ORDER BY nombre ASC";
                          $result = $obj_db->consulta($consulta);
                          if($result!=false){
                            foreach($result as $fila){
                            echo "<option class='' value ='".$fila['id_estado']."'>".utf8_encode($fila['nombre'])."</option>";
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
                    <select class="form-control" name="cac_menu" id="cac_menu" style="width:95%">
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

        <div id="reporte" class="col-md-6 col-sm-6 col-xs-12">

          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">Reporte General</h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
            </div>

            <div class="box-body">
              <div class="col-md-8 col-sm-8 col-xs-6 panel-izq"> 
                <div class="form-group row">
                  <label class="col-md-6 col-sm-6 col-xs-12">Periodo:</label>
                  <div  id="campo-periodo">2014/10/16 al 2014/10/20</div>
                </div>
                <div class="form-group row">  
                  <label class="col-md-6 col-sm-6 col-xs-12">Promedio Inicial:</label>
                  <div  id="campo-inventarioi">0</div>
                </div>
                <div class="form-group row">
                  <label class="col-md-6 col-sm-6 col-xs-12">Total de ventas:</label>
                  <div id="campo-ventas">0</div>
                </div>
                <div class="form-group row">
                  <label class="col-md-6 col-sm-6 col-xs-12">Promedio en stock:</label>
                  <div id="campo-stock">0</div>
                </div>
              <!--<div class="label">Número de promotores:</div><div class="campo" id="campo-periodo">15</div>-->
              </div>

              <div class="col-md-4 col-sm-4 col-xs-6 panel-der">  
                <div class="" id="foto"><img id="img-foto" src="images/no-image.jpg" /></div>
              </div>
            </div>
            
              <div class="box-footer clearfix">
                <form action="imprimir.php?command=directivos_imprimir_ventas" method="POST" enctype="multipart/form-data" id="f_imprimir" name="f_imprimir" target="_blank">
                  <input type="button" class="btn btn-primary" style="margin:5px;" value="Imprimir" id="imprimir" name="imprimir">
                  <input type="hidden" name="dg" id="dg" value="">
                  <input type="hidden" name="g1" id="g1" value="">
                  <input type="hidden" name="g2" id="g2" value="">
                  <input type="hidden" name="g3" id="g3" value="">
                  <input type="hidden" name="g4" id="g4" value="">
                  <input type="hidden" name="g5" id="g5" value="">
                  <input type="hidden" name="tg" id="tg" value="">
                  <div id="i_grafica1" style="display:none"></div>
                  <div id="i_grafica2" style="display:none"></div>
                  <div id="i_grafica3" style="display:none"></div>
                  <div id="i_grafica4" style="display:none"></div>
                  <div id="i_grafica5" style="display:none"></div>
                  <div id="i_grafica6" style="display:none"></div>
                  <div id="i_cont-cuotas" style="display:none"></div>
                  <div id="i_cont-detalles" style="display:none"></div>
                </form>
              </div>
            
          </div>

        </div>

        <div class="col-md-6 col-sm-6 col-xs-12">

          <div id="cont-grafica1" class="cont-graficas box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">Ventas totales de productos al día</h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
            </div>

            <div class="box-body">
              <div id="grafica1"></div>
            </div>          

          </div>

        </div>

        <div class="col-md-6 col-sm-6 col-xs-12">
          <div id="cont-grafica2" class="cont-graficas box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">Ventas totales por usuario al día</h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
            </div>

            <div class="box-body">
              <div id="grafica2"></div>
            </div>

          </div>
        </div>

        <div class="col-md-6 col-sm-6 col-xs-12">
          <div id="cont-grafica3" class="cont-graficas box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">Ventas por estado</h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
            </div>
            
            <div class="box-body">
              <div id="grafica3"></div>
            </div>
          </div>
        </div>

        <div class="col-md-6 col-sm-6 col-xs-12">
          <div id="cont-grafica4" class="cont-graficas box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">Promedio de inventario</h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
            </div>

            <div class="box-body">
              <div id="grafica4" class="col-md-12 col-sm-12 col-xs-12"></div>
            </div>

          </div>
        </div>

        <div class="col-md-6 col-sm-6 col-xs-12">
          <div id="cont-grafica5" class="cont-graficas box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">Total de ventas</h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
            </div>
            
            <div class="box-body">
              <div id="grafica5" class="col-md-12 col-sm-12 col-xs-12"></div>
            </div>
          </div>
        </div>
	 
        <div class="col-md-12 col-sm-12 col-xs-12" style="display:none;">
    	    <div id="cuotas" class="cont-graficas box box-primary collapsed-box">
            <div class="box-header with-border">
              <h3 class="box-title">Cuotas</h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus"></i></button>
                <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>
            </div>

            <div class="box-body">
              <div id="cont-cuotas"></div>
            </div>
          </div>
        </div>
        
        <div class="col-md-12 col-sm-12 col-xs-12">
          <div id="detalles" class="cont-graficas box box-primary collapsed-box">
            <div class="box-header with-border">
              <h3 class="box-title">Detalles</h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus"></i></button>
                <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                <button class="btn btn-box-tool" data-widget="export" id="export-excel"><img  title="Exportar tabla a Excel" data-toggle="tooltip" data-placement="left" src="images/hoja-de-calculo-excel-icono.png" style="width:15px;" /></button>
              </div>
            </div>

            <div class="box-body">
              <div id="cont-detalles"></div>
            </div>
          </div>
        </div>

        <div>&nbsp;</div>
      

      </div>
      
      </div>
    <?php require "views/auditor/footer_auditor.php"; ?>
</div>
</section>


<div id="modal1" class="modalmask">
    <div class="modalbox movedown  col-md-4 col-sm-6 col-xs-12">
        <a href="#close" title="Close" class="close">X</a>
        <h2>Gráficas</h2>
        <img id="btn-grafica-column" class="btn-grafica" src="images/graficas/column_chart.jpg">
        <img id="btn-grafica-pie" class="btn-grafica" src="images/graficas/pie_chart.jpg">
        <img id="btn-grafica-geo" class="btn-grafica" src="images/graficas/geo_chart.jpg">
        <!--<img id="btn-grafica-table" class="btn-grafica" src="images/graficas/table_chart.jpg">-->
    </div>
</div>

<div id="modal2" class="modalmask2">
    <div class="modalbox movedown col-md-4 col-sm-6 col-xs-12">
        <a href="#close" title="Close" class="close">X</a>
        <h2>Configuración de datos</h2>
        <div class="row grid">
          <label class="label col-md-4 col-sm-2 col-xs-2" style="">Titulo de Gráficas</label>
          <input class="campo col-md-8 col-sm-8 col-xs-12" name="titulo-grafica" id="titulo-grafica" type="text" placeholder="Título">
        </div>

        <div class="row grid">
          <label class="label col-md-4 col-sm-2 col-xs-2" style="">Título Label X</label>
          <input class="campo col-md-8 col-sm-8 col-xs-12" name="titulo-label-x" id="titulo-label-x" type="text" placeholder="Valores X">
        </div>

        <div class="row grid">
          <label class="label col-md-4 col-sm-2 col-xs-2" style="">Título Label Y</label>
          <input class="campo col-md-8 col-sm-8 col-xs-12" name="titulo-label-y" id="titulo-label-y" type="text" placeholder="Título Y">
        </div>

        <div class="row grid">
          <label class="label col-md-4 col-sm-2 col-xs-2" style="">Agrupar por:</label>
          <select class="campo col-md-8 col-sm-8 col-xs-12" name="categorias-x" id="categorias-x" placeholder="Categorías">
            <option value="0" selected="selected">Selecciona una opción</option>
            <option value="v_0">Usuario</option>
            <option value="v_1">Estado</option>
            <option value="v_2">Municipio</option>
            <option value="v_3">CAC</option>
            <option value="v_4">Categoría</option>
            <option value="v_5">Producto</option>
            <option value="v_8">Canal</option>
            <option value="v_9">Fecha</option>
            <option value="v_10">Servicio</option>
            <?php
              global $obj_db;
              $consulta3 = "SELECT id_form, f_alias FROM form_extra ORDER BY id_seccion ASC";
              $result3 = $obj_db->consulta($consulta3);
              if($result3!=false){
                foreach($result3 as $fila3){
            ?>
                  <option value="f_<?php echo $fila3['id_form']?>"><?php echo $fila3['f_alias']?></option>                  
            <?php
                }   
              }
            ?>            
          </select>
        </div>

        <div class="row grid">

          <label class="label col-md-12 col-sm-12 col-xs-12" style="">Valores:</label>
          <select class="campo col-md-4 col-sm-8 col-xs-12" name="operadores_grafica" id="operadores_grafica">
            <option value="o_0" selected="selected">SUMATORIA</option>
            <option value="o_1">PROMEDIO</option>
            <option value="o_2">SUMA</option>
            <option value="o_3">RESTA</option>
            <option value="o_4">MULT</option>
            <option value="o_5">DIV</option>
          </select>
          <select class="campo col-md-8 col-sm-8 col-xs-12" name="valores_grafica" id="valores_grafica" placeholder="Categorías">
            <option value="0" selected="selected">Selecciona una opción</option>
            <option value="v_0">Usuario</option>
            <option value="v_1">Estado</option>
            <option value="v_2">Municipio</option>
            <option value="v_3">CAC</option>
            <option value="v_4">Categoría</option>
            <option value="v_5">Producto</option>
            <option value="v_6">Inventario Inicial</option>
            <option value="v_7">Numero de Ventas</option>
            <option value="v_8">Canal</option>
            <option value="v_9">Fecha</option>
            <option value="v_10">Servicio</option>
            <option value="v_11">Total</option>
            <?php
              global $obj_db;
              $consulta3 = "SELECT id_form, f_alias FROM form_extra ORDER BY id_seccion ASC";
              $result3 = $obj_db->consulta($consulta3);
              if($result3!=false){
                foreach($result3 as $fila3){
            ?>
                  <option value="f_<?php echo $fila3['id_form']?>"><?php echo $fila3['f_alias']?></option>                  
            <?php
                }   
              }
            ?>
          </select>
        </div>


                <br />
        <div class="">
            <button value="Guardar configuración" name="btn_datos_grafica" id="btn_datos_grafica" class="btn btn-block btn-sm btn-info ">Guardar configuración</button>
        </div>

    </div>
    
</div>
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