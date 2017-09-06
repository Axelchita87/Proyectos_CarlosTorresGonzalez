
<?php
require_once 'class/class.altas.php';
//session_start();
if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){

?>

<body>

  <style>

  #reporte {position:relative;}
  #reporte .header{color:#333;font-weight: bolder; text-align: center;}
  #reporte .label{color:#333;}
  #reporte .campo{color:#333;}
  #reporte #foto{border:1px solid #ccc; width:120px;height:150px;position:absolute; right:20px;}
  #reporte img{max-width: 100%; max-height: 100%; top:0; bottom: 0; right:0; left:0;position:absolute; margin: auto;}
  #detalles, #cuotas{clear: both;}

  #cont-detalles table {width:100%;}

  .cont-graficas{min-height: 300px; border:#FFF solid 1px; transition:border 1s;}
  .cont-graficas:hover{border:#F11111 solid 1px;}
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

    var contenedorImprimirGrafica;


    function una_grafica(cont, categoria, funcion, tipo_tabla, tipo, var_opt, valores){

          var_opc = {'promotor':$('#promotor').val(), 'estado':$('#estados').val(), 'fecha_i':$('#fecha_i').val(), 'fecha_f':$('#fecha_f').val(),'categoria':'inventario','funcion':'datos_generales'}
          var_opc.categoria=categoria;
          var_opc.valores=$.extend( [], valores)
          if (tipo_tabla!=''){var_opc.tipo_tabla=tipo_tabla;}
          var_opc.funcion=funcion;

          var var_opt2={title: 'Ventas totales de productos al día',
                           hAxis: {title: 'Día', titleTextStyle: {color: 'blue'}},
                           vAxis: {title: 'Cantidad de productos', titleTextStyle: {color: 'blue'}},
                           backgroundColor:'#ffffff',
                           legend:{position: 'right', textStyle: {color: 'blue', fontSize: 13}},
                           height:300
                        }

          var_opt2 = (var_opt!='')?$.extend( {}, var_opt ):$.extend( {}, var_opt2 );

          //console.log(tipo);

          dibujarGrafico(tipo,cont,var_opc,var_opt2,
                          'i_'+cont
                        );

          console.log(var_opt)
    }

    function recuperar_valores(cont){

          switch(cont){
               case 'grafica1':
                      $('#titulo-grafica').val(dataGraficas[0][0].title)
                      $('#titulo-label-x').val(dataGraficas[0][0].vAxis.title);
                      $('#titulo-label-y').val(dataGraficas[0][0].hAxis.title);
                      $('#categorias-x option[value="0"]').attr('selected',true);
                      $('#valores_grafica option[value="0"]').attr('selected',true);
                      break;
               case 'grafica2':
                      $('#titulo-grafica').val(dataGraficas[1][0].title);
                      $('#titulo-label-x').val(dataGraficas[1][0].vAxis.title);
                      $('#titulo-label-y').val(dataGraficas[1][0].hAxis.title);
                      $('#categorias-x option[value="0"]').attr('selected',true);
                      $('#valores_grafica option[value="0"]').attr('selected',true);                      
                      break;
               case 'grafica3':
                      $('#titulo-grafica').val(dataGraficas[2][0].title);
                      $('#titulo-label-x').val(dataGraficas[2][0].vAxis.title);
                      $('#titulo-label-y').val(dataGraficas[2][0].hAxis.title);
                      $('#categorias-x option[value="0"]').attr('selected',true);
                      $('#valores_grafica option[value="0"]').attr('selected',true);
                      break;
               case 'grafica4':
                      $('#titulo-grafica').val(dataGraficas[3][0].title);
                      $('#titulo-label-x').val(dataGraficas[3][0].vAxis.title);
                      $('#titulo-label-y').val(dataGraficas[3][0].hAxis.title);
                      $('#categorias-x option[value="0"]').attr('selected',true);
                      $('#valores_grafica option[value="0"]').attr('selected',true);
                      break;
               case 'grafica5':
                      $('#titulo-grafica').val(dataGraficas[4][0].title);
                      $('#titulo-label-x').val(dataGraficas[4][0].vAxis.title);
                      $('#titulo-label-y').val(dataGraficas[4][0].hAxis.title);
                      $('#categorias-x option[value="0"]').attr('selected',true)
                      $('#valores_grafica option[value="0"]').attr('selected',true)
                      break; 
               case 'cont-detalles':
                      break;
               default: 
                      //console.log(cont)
                      break;
          }



    }

    function guardar_valores_cambio(cont){
      var funcion='barra_personal';
      var tipo = 'barra';
      var array_valores=[$('#operadores_grafica').val()+":"+$('#valores_grafica').val()];

      switch(cont){
               case 'grafica1':
                      dataGraficas[0][0].title=$('#titulo-grafica').val()
                      dataGraficas[0][0].vAxis.title=$('#titulo-label-x').val();
                      dataGraficas[0][0].hAxis.title=$('#titulo-label-y').val();

                      if(dataGraficas[0][0].tipo_tabla=='pastel'){funcion='pastel_personal', tipo='pastel'}
                      if(dataGraficas[0][0].tipo_tabla=='barra'){funcion='barra_personal', tipo='barra'}
                      if(dataGraficas[0][0].tipo_tabla=='geo'){funcion='geo_personal', tipo='geo'}
                      una_grafica(cont,$('#categorias-x').val(),funcion, '', tipo, dataGraficas[0][0], array_valores)
                      break;
               case 'grafica2':
                      dataGraficas[1][0].title=$('#titulo-grafica').val()
                      dataGraficas[1][0].vAxis.title=$('#titulo-label-x').val();
                      dataGraficas[1][0].hAxis.title=$('#titulo-label-y').val();

                      if(dataGraficas[1][0].tipo_tabla=='pastel'){funcion='pastel_personal', tipo='pastel'}
                      if(dataGraficas[1][0].tipo_tabla=='barra'){funcion='barra_personal', tipo='barra'}
                      if(dataGraficas[1][0].tipo_tabla=='geo'){funcion='geo_personal', tipo='geo'}
                      una_grafica(cont,$('#categorias-x').val(),funcion, '', tipo, dataGraficas[1][0], array_valores)
                      break;
               case 'grafica3':
                      dataGraficas[2][0].title=$('#titulo-grafica').val()
                      dataGraficas[2][0].vAxis.title=$('#titulo-label-x').val();
                      dataGraficas[2][0].hAxis.title=$('#titulo-label-y').val();

                      if(dataGraficas[2][0].tipo_tabla=='pastel'){funcion='pastel_personal', tipo='pastel'}
                      if(dataGraficas[2][0].tipo_tabla=='barra'){funcion='barra_personal', tipo='barra'}
                      if(dataGraficas[2][0].tipo_tabla=='geo'){funcion='geo_personal', tipo='geo'}
                      una_grafica(cont,$('#categorias-x').val(),funcion, '', tipo, dataGraficas[2][0], array_valores)
                      break;
               case 'grafica4':
                      dataGraficas[3][0].title=$('#titulo-grafica').val()
                      dataGraficas[3][0].vAxis.title=$('#titulo-label-x').val();
                      dataGraficas[3][0].hAxis.title=$('#titulo-label-y').val();

                      if(dataGraficas[3][0].tipo_tabla=='pastel'){funcion='pastel_personal', tipo='pastel'}
                      if(dataGraficas[3][0].tipo_tabla=='barra'){funcion='barra_personal', tipo='barra'}
                      if(dataGraficas[3][0].tipo_tabla=='geo'){funcion='geo_personal', tipo='geo'}
                      una_grafica(cont,$('#categorias-x').val(),funcion, '', tipo, dataGraficas[3][0], array_valores)
                      break;
               case 'grafica5':
                      dataGraficas[4][0].title=$('#titulo-grafica').val();
                      dataGraficas[4][0].vAxis.title=$('#titulo-label-x').val();
                      dataGraficas[4][0].hAxis.title=$('#titulo-label-y').val();

                      if(dataGraficas[4][0].tipo_tabla=='pastel'){funcion='pastel_personal', tipo='pastel'}
                      if(dataGraficas[4][0].tipo_tabla=='barra'){funcion='barra_personal', tipo='barra'}
                      if(dataGraficas[4][0].tipo_tabla=='geo'){funcion='geo_personal', tipo='geo'}
                        console.log(dataGraficas[4][0].tipo_tabla)
                      una_grafica(cont,$('#categorias-x').val(),funcion, '', tipo, dataGraficas[4][0], array_valores)
                      break; 
               case 'cont-detalles':
                      break;
               default: 
                      console.log(cont)
                      break;
          }
    }

    function limpiarUnaGrafica(cont){
      $('#'+cont).html('')
    }

    function eventosGraficas(cont){

      var array_valores=[$('#operadores_grafica').val()+":"+$('#valores_grafica').val()];

            switch(cont){
               case 'grafica1':
                      d=0;
                      break;
               case 'grafica2':
                      d=1;
                      break;
               case 'grafica3':
                      d=2;
                      break;
               case 'grafica4':
                      d=3;
                      break;
               case 'grafica5':
                      d=4;
                      break; 
               case 'cont-detalles':
                      break;
               default: 
                      console.log(cont)
                      break;
          }

      //Deshabilitar eventos
      $('#btn-grafica-column').unbind();
      $('#btn-grafica-pie').unbind();
      $('#btn-grafica-geo').unbind();
      $('#btn-grafica-table').unbind();

      //Reasignar eventos
      $('#btn-grafica-column').click(function(){
          una_grafica(cont, $('#categorias-x').val(), 'barra_personal', '','barra',dataGraficas[d][0], array_valores);
        cerrar();
      })

      $('#btn-grafica-pie').click(function(){
        console.log(array_valores)
        una_grafica(cont, $('#categorias-x').val(), 'pastel_personal', '', 'pastel',dataGraficas[d][0], array_valores);
        cerrar();
      })

      $('#btn-grafica-geo').click(function(){
        una_grafica(cont, $('#categorias-x').val(), 'geo_personal', '', 'geo',dataGraficas[d][0], array_valores);
        cerrar();
      })

      $('#btn-grafica-table').click(function(){
        una_grafica(cont, $('#categorias-x').val(), 'tabla_personal', '', 'tabla',dataGraficas[d][0], array_valores);
        cerrar();
      })
      
    }



    function cerrar(){
      console.log("grafica");
      $('.modalmask').removeAttr('style');
      $('.modalmask2').removeAttr('style');
    }




    $('.menu-edit').click(function(){
      $(this).children('li').children().next().toggle('slow');
    })

    $('.btn-edit-ninguno').click(function(){
      contenedorImprimirGrafica=$(this).parent().parent().parent().parent().next().attr('id');
      limpiarUnaGrafica(contenedorImprimirGrafica);
    })

    $('.btn-edit-grafica').click(function(){
      contenedorImprimirGrafica=$(this).parent().parent().parent().parent().next().attr('id');
      eventosGraficas(contenedorImprimirGrafica);
      $('.modalmask').toggle('slow')
    })

    $('.btn-edit-datos').click(function(){
      contenedorImprimirGrafica=$(this).parent().parent().parent().parent().next().attr('id');
      recuperar_valores(contenedorImprimirGrafica)
      $('.modalmask2').toggle('slow')
    })

    $('#btn_datos_grafica').click(function(){
      guardar_valores_cambio(contenedorImprimirGrafica)
      $('.modalmask2').toggle('slow');
    })

    $('.btn-grafica').click(function(){
      console.log("imprime");
    })

    $('#export-excel').click(function(){
        vars = "?fecha_i="+$('#fecha_i').val()+"&fecha_f="+$('#fecha_f').val()+"&promotor="+$('#promotor').val()+"&estado="+$('#estados').val()+"&cac="+$('#cac_menu').val();
        document.location.href="reporteexcel.php"+vars;
      })

    $('.close').click(function(){
      cerrar()
    })

   
})


    $(function () {
      $('[data-toggle="tooltip"]').tooltip();
    })
</script> 


<div border="0" class="table-responsive">
      
      

      <?php require "views/directivos/menu_vertical.php" ?>

      <div id="contenido">
      
      <?php require "views/directivos/header_directivo.php" ?>
      <div id="contenedor">
        
        

        <div id="reporte" style="min-height:270px;float:left;padding:5px;"  class="panel panel-default col-md-6 col-sm-6 col-xs-12">
          <div class="header panel-heading">Reporte General</div>

          <div class="panel-body">
            <div class="col-md-8 col-sm-8 col-xs-6 panel-izq"> 
              <div class="row grid">
              <label class="label col-md-6 col-sm-6 col-xs-12">Periodo:</label><div class="campo col-md-6 col-sm-6 col-xs-12" id="campo-periodo">2014/10/16 al 2014/10/20</div>
              </div>
              <div class="row grid">  
              <label class="label col-md-6 col-sm-6 col-xs-12">Promedio Inicial:</label><div class="campo col-md-6 col-sm-6 col-xs-12" id="campo-inventarioi">50</div>
              </div>
              <div class="row grid">
              <label class="label col-md-6 col-sm-6 col-xs-12">Total de ventas:</label><div class="campo col-md-6 col-sm-6 col-xs-12" id="campo-ventas">100</div>
              </div>
              <div class="row grid">
              <label class="label col-md-6 col-sm-6 col-xs-12">Promedio en stock:</label><div class="campo col-md-6 col-sm-6 col-xs-12" id="campo-stock">100</div>
              </div>
              <!--<div class="label">Número de promotores:</div><div class="campo" id="campo-periodo">15</div>-->
            </div>
          
            <div class="col-md-4 col-sm-4 col-xs-6 panel-der">  
              <div class="" id="foto"><img id="img-foto" src="images/no-image.jpg" /></div>
            </div>

          </div>

          <div  style="text-align:right;" class="col-md-12 col-sm-12 col-xs-12">
            <form action="imprimir.php?command=directivos_imprimir_ventas" method="POST" enctype="multipart/form-data" id="f_imprimir" name="f_imprimir" target="_blank">
              <input type="button" class="btn btn-sm btn-block btn-success" style="margin:5px;" value="Imprimir" id="imprimir" name="imprimir">
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


        <div id="cont-grafica1" class="cont-graficas col-md-6 col-sm-6 col-xs-12">
          <div class="ctrl-grafica">
              <ul class="menu-edit">
                <li>
                  <img class="icono-edit"  src="images/editar2.png">
                  <ul class="submenu-edit" style="display:none">
                    <li class="btn-edit-ninguno">Ninguno</li>
                    <li class="btn-edit-grafica">Gráfica</li>                    
                    <li class="btn-edit-datos">Datos</li>
                  </ul>
                </li>
              </ul>
          </div>
          <div id="grafica1" class="col-md-12 col-sm-12 col-xs-12"></div>
        </div>

        <div id="cont-grafica2" class="cont-graficas col-md-6 col-sm-6 col-xs-12">
          <div class="ctrl-grafica">
              <ul class="menu-edit">
                <li>
                  <img class="icono-edit"  src="images/editar2.png">
                  <ul class="submenu-edit" style="display:none">
                    <li class="btn-edit-ninguno">Ninguno</li>
                    <li class="btn-edit-grafica">Gráfica</li>                    
                    <li class="btn-edit-datos">Datos</li>
                  </ul>
                </li>
              </ul>
          </div>
          <div id="grafica2" class="col-md-12 col-sm-12 col-xs-12"></div>
        </div>

        <div id="cont-grafica3" class="cont-graficas col-md-6 col-sm-6 col-xs-12">
          <div class="ctrl-grafica">
              <ul class="menu-edit">
                <li>
                  <img class="icono-edit"  src="images/editar2.png">
                  <ul class="submenu-edit" style="display:none">
                    <li class="btn-edit-ninguno">Ninguno</li>
                    <li class="btn-edit-grafica">Gráfica</li>                    
                    <li class="btn-edit-datos">Datos</li>
                  </ul>
                </li>
              </ul>
          </div>
          <div id="grafica3" class="col-md-12 col-sm-12 col-xs-12"></div>
        </div>

        <div id="cont-grafica4" class="cont-graficas col-md-6 col-sm-6 col-xs-12">
          <div class="ctrl-grafica">
              <ul class="menu-edit">
                <li>
                  <img class="icono-edit"  src="images/editar2.png">
                  <ul class="submenu-edit" style="display:none">
                    <li class="btn-edit-ninguno">Ninguno</li>
                    <li class="btn-edit-grafica">Gráfica</li>                    
                    <li class="btn-edit-datos">Datos</li>
                  </ul>
                </li>
              </ul>
          </div>
          <div id="grafica4" class="col-md-12 col-sm-12 col-xs-12"></div>
        </div>

        <div id="cont-grafica5" class="cont-graficas col-md-6 col-sm-6 col-xs-12">
          <div class="ctrl-grafica">
              <ul class="menu-edit">
                <li>
                  <img class="icono-edit"  src="images/editar2.png">
                  <ul class="submenu-edit" style="display:none">
                    <li class="btn-edit-ninguno">Ninguno</li>
                    <li class="btn-edit-grafica">Gráfica</li>                    
                    <li class="btn-edit-datos">Datos</li>
                  </ul>
                </li>
              </ul>
          </div>
          <div id="grafica5" class="col-md-12 col-sm-12 col-xs-12"></div>
        </div>
	
    	<div id="cuotas" >
          <div id="btn-cuotas" class="btn btn-sm btn-block btn-success" style="position:relative;">Ver cuotas</div>
          <div  style="text-align:right;display:none;"><div class="btn-xs" id="export-excel-cuotas"><img  title="Exportar tabla a Excel" data-toggle="tooltip" data-placement="left" src="images/hoja-de-calculo-excel-icono.png" /></div></div>
          <div id="cont-cuotas" style="padding:10px;"></div>
        </div>
    
        
        <div id="detalles" >
          <div id="btn-detalles" class="btn btn-sm btn-block btn-success" style="position:relative;">Ver detalles</div>
          <div  style="text-align:right"><div class="btn-xs" id="export-excel"><img  title="Exportar tabla a Excel" data-toggle="tooltip" data-placement="left" src="images/hoja-de-calculo-excel-icono.png" /></div></div>
          <div id="cont-detalles" style="padding:10px;"></div>
        </div>
      
      

      </div>
      <?php require "views/directivos/footer_directivo.php" ?>
      </div>

</div>

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