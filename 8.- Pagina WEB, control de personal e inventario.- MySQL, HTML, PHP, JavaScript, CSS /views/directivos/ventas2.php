
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
  #detalles{clear: both;}

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
     text-align: left;
}

.modalmask2 .modalbox{padding: 5px 35px 13px 35px;}

.modalbox img{width:100%}
.btn-grafica{cursor:pointer;}
.modalbox .cont-img-chart{float:left; width:20%; border: 1px solid #999; margin:3px;min-width: 80px;}
.modalbox .cont-img-chart:hover{box-shadow: 10px 10px 5px #ccc;}
.modalbox .cont-img-chart.cont-chart-active{border: 3px solid #999;}

.modalmask .movedown, .modalmask2 .movedown{       
    margin:10% auto;
    float:none;
    height:70%;
    overflow: auto
}

.modalbox .ctrl-opciones-panel{border-bottom: 1px solid #ccc}
.modalbox ul{text-align: left;}
.modalbox ul li{display: inline-block; padding: 5px; cursor: pointer}
.modalbox ul li:hover{background-color: #eee;}
.modalbox ul li.tab-active{border-right:1px solid #ccc;border-top:1px solid #ccc;border-left:1px solid #ccc; font-weight: bold;}
.modalbox #panel-graficas,.modalbox #panel-datos{}
.modalbox #paneles{position:relative;min-height: 100%;clear:both;}
.modalbox .panel-guardar-grafica{position:relative;clear:both;margin-bottom: 10px;}
.modalbox .row {margin-left: 0px;margin-right: 0px;}


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


.chart_extra{clear:both;  text-align: right; margin-bottom: 5px;}
.btn-xs{
  cursor:pointer;
  display: inline-block;
  background-color: #F11111;
  border:1px solid #FFF;
  padding:3px;
  width: 25px;
  text-align: center;
  font-weight: bold;
  color:#FFF;
  font-size: 14px;
}

.btn-xs:hover{
    background-color: #C00;
}

</style> 

<script>
$(function(){

    objGraficas=[]; //En esta variable se almacenan los datos necesarios para crear cada gráfica


    function crearChart(opciones){

      if ($('#btn_datos_grafica').attr('value')=='guardar'){

        var array_valores=[$('#operadores_grafica').val()+":"+$('#valores_grafica').val()];
        var opciones = $.extend( {}, opciones ) || {};

        var chart_id = $('.cont-graficas').length+1;
        var tipo_id = obtenerChartSeleccionado();
        var titulo_chart = $('#titulo-grafica').val()
        var titulo_label_x = $('#titulo-label-x').val();
        var titulo_label_y = $('#titulo-label-y').val();
        
        dataGraficas['grafica-'+chart_id] = {};
        abr_opciones = dataGraficas['grafica-'+chart_id]['opciones'] = {
          id:chart_id,
          tipo:tipo_id,
          titulo:titulo_chart,
          titulo_label_x:titulo_label_x,
          titulo_label_y:titulo_label_y,
          input:'g'+chart_id,
          i_div:'i_grafica'+chart_id,
          contenedor:'grafica'+ chart_id
        };

        objGraficas.push(opciones);

        abr_var_opc = dataGraficas['grafica-'+chart_id]['var_opc'] = {
          promotor :  $('#promotor').val(),
          estado   :  $('#estados').val(),
          fecha_i  :  $('#fecha_i').val(),
          fecha_f  :  $('#fecha_f').val(),
          categoria:  $('#categorias-x').val(),
          valores  :  [$('#operadores_grafica').val()+":"+$('#valores_grafica').val()],
          n_serie  :  $('#names_textarea').val(),
          v_series :  $('#value_textarea').val(),
          c_series :  $('#categoria_textarea').val(),
          funcion  :  tipo_id+'_personal'
        };

        if (tipo_id!=''){abr_var_opc.tipo_tabla=tipo_id;}

        abr_var_opc2 = dataGraficas['grafica-'+chart_id]['var_opc2'] = {        
          title: abr_opciones.titulo||'Titulo de Gráfica',
          hAxis: {title: titulo_label_x||'Día', titleTextStyle: {color: 'blue'}},
          vAxis: {title: titulo_label_y||'Cantidad de productos', titleTextStyle: {color: 'blue'}},
          backgroundColor:'#ffffff',
          legend:{position: 'right', textStyle: {color: 'blue', fontSize: 13}},
          height:300        
        };

      


        var c='<div id="cont-grafica'+chart_id+'" class="cont-graficas col-md-6 col-sm-6 col-xs-12">'+
              '<div class="ctrl-grafica">'+
                '<ul class="menu-edit">'+
                  '<li>'+
                    '<img class="icono-edit" id="edit-'+chart_id+'" src="images/editar2.png">'+
                  '</li>'+                  
                  '<li>'+
                    '<img class="icono-eliminar" id="eliminar-'+chart_id+'"   src="images/eliminar2.png">'+
                  '</li>'+                
                '</ul>'+
              '</div>'+
              '<div id="grafica'+chart_id+'" class="col-md-12 col-sm-12 col-xs-12"></div>'+
            '</div>';
        var c2= '<input type="hidden" name="'+abr_opciones.input+'" id="g'+chart_id+'" value="">'+
                '<div id="'+abr_opciones.i_div+'" style="display:none"></div>'

        $('#detalles').before(c);
        $('#f_imprimir').append(c2);

        dibujarGrafico(tipo_id,abr_opciones.contenedor,abr_var_opc,abr_var_opc2,abr_opciones.i_div);
      }else if($('#btn_datos_grafica').attr('value').indexOf('edit-')!==false){
        
        var array_valores=[$('#operadores_grafica').val()+":"+$('#valores_grafica').val()];
        var opciones = $.extend( {}, opciones ) || {};

        var chart_id = $('#btn_datos_grafica').attr('value').replace('edit-','');
        var tipo_id = obtenerChartSeleccionado();
        var titulo_chart = $('#titulo-grafica').val()
        var titulo_label_x = $('#titulo-label-x').val();
        var titulo_label_y = $('#titulo-label-y').val();
        
        dataGraficas['grafica-'+chart_id] = {};

        abr_opciones = dataGraficas['grafica-'+chart_id]['opciones'] = {
          id:chart_id,
          tipo:tipo_id,
          titulo:titulo_chart,
          titulo_label_x:titulo_label_x,
          titulo_label_y:titulo_label_y,
          input:'g'+chart_id,
          i_div:'i_grafica'+chart_id,
          contenedor:'grafica'+ chart_id
        };

        objGraficas.push(opciones);

        abr_var_opc = dataGraficas['grafica-'+chart_id]['var_opc'] = {
          promotor :  $('#promotor').val(),
          estado   :  $('#estados').val(),
          fecha_i  :  $('#fecha_i').val(),
          fecha_f  :  $('#fecha_f').val(),
          categoria:  $('#categorias-x').val(),
          valores  :  [$('#operadores_grafica').val()+":"+$('#valores_grafica').val()],
          n_serie  :  $('#names_textarea').val(),
          v_series :  $('#value_textarea').val(),
          c_series :  $('#categoria_textarea').val(),
          funcion  :  tipo_id+'_personal'
        };

        if (tipo_id!=''){abr_var_opc.tipo_tabla=tipo_id;}

        abr_var_opc2 = dataGraficas['grafica-'+chart_id]['var_opc2'] = {        
          title: abr_opciones.titulo||'Titulo de Gráfica',
          hAxis: {title: titulo_label_x||'Día', titleTextStyle: {color: 'blue'}},
          vAxis: {title: titulo_label_y||'Cantidad de productos', titleTextStyle: {color: 'blue'}},
          backgroundColor:'#ffffff',
          legend:{position: 'right', textStyle: {color: 'blue', fontSize: 13}},
          height:300        
        };

      


        dibujarGrafico(tipo_id,abr_opciones.contenedor,abr_var_opc,abr_var_opc2,abr_opciones.i_div);
        alert("Editar grafica:"+$('#btn_datos_grafica').attr('value').replace('edit-',''))
      }
    
    }

    function rellenarFormDatos(){
        $('#titulo-grafica').val('');
        $('#titulo-label-x').val('');
        $('#titulo-label-y').val('');

        var chart_id = $('#btn_datos_grafica').attr('value').replace('edit-','');
        var tipo_id = dataGraficas['grafica-'+chart_id]['opciones'].tipo;
        var titulo_chart = $('#titulo-grafica').val(dataGraficas['grafica-'+chart_id]['opciones'].titulo);
        var titulo_label_x = $('#titulo-label-x').val(dataGraficas['grafica-'+chart_id]['opciones'].titulo_label_x);
        var titulo_label_y = $('#titulo-label-y').val(dataGraficas['grafica-'+chart_id]['opciones'].titulo_label_y);
    }

    function obtenerChartSeleccionado(){
      var id= $('.cont-chart-active').children().attr('id');
      switch(id){
               case 'btn-grafica-column':
                      return 'barra';
                      break;
               case 'btn-grafica-pie':
                      return 'pastel';
                      break;
               case 'btn-grafica-geo':
                      return 'geo';
                      break;
               case 'btn-grafica-table':
                      return 'tabla';;
                      break;
               default: 
                      console.log(id)
                      break;
          }
      console.log(id);
    }

    function mostrar_panel_conf_graficas(){
      $('.modalmask').toggle('slow');
    }

    function validar_contenedor(cont){
      if(cont.length == 0){
        return false;
      }else{
        return true;
      }
    }


    function cerrar(){
      console.log("grafica");
      $('.modalmask').removeAttr('style');
      $('.modalmask2').removeAttr('style');
    }




    $('.menu-edit').on('click',function(){
      mostrar_panel_conf_graficas();
    })

    $('#contenido').on('click', '.icono-edit', function(){
      $('#btn_datos_grafica').attr('value',$(this).attr('id'));
      rellenarFormDatos($(this).attr('id').replace('edit-',''))
      mostrar_panel_conf_graficas($(this).attr('id'));
    })

    $('#contenido').on('click', '.icono-eliminar', function(){
      if(confirm("Seguro que deseas eliminar esta gráfica")){
        alert("Gráfica "+$(this).attr('id')+". eliminada")
      }
    })

    $('#btn_datos_grafica').on('click',function(){
      crearChart()      
      $('.modalmask').toggle('slow');
    })

    $('.btn-grafica').on('click',function(){
      console.log("imprime");
    })

    $('#btn_chart_add').on('click',function(){
      $('#btn_datos_grafica').attr('value','guardar');
      mostrar_panel_conf_graficas();
    })

    $('#tab-grafica').on('click',function(){
      $('.tab-active').removeClass('tab-active')
      $('#panel-datos').css('display', 'none')
      $('#tab-grafica').addClass('tab-active')
      $('#panel-graficas').css('display', 'inline')

    })    

    $('#tab-datos').on('click',function(){
      $('.tab-active').removeClass('tab-active');
      $('#panel-graficas').css('display', 'none');
      $('#tab-datos').addClass('tab-active');
      $('#panel-datos').css('display', 'inline')
    })

    $('.cont-img-chart').on('click',function(){
      $('.cont-chart-active').removeClass('cont-chart-active');
      $(this).addClass('cont-chart-active');
    })

    $('.name_list_value').on('dblclick',function(){
      var var_aux = $('textarea#names_textarea').val()
      var separador = $('textarea#names_textarea').val()==''?'':','

      var_aux = var_aux+separador+"{"+$(this).html()+"}";
      $('textarea#names_textarea').val(var_aux);
    })

    $('.value_list_value').on('dblclick',function(){
      var var_aux = $('textarea#value_textarea').val()
      var separador = $('textarea#value_textarea').val()==''?'':','

      var_aux = var_aux+separador+"{"+$(this).html()+"}";
      $('textarea#value_textarea').val(var_aux);
    })

    $('.cat_list_value').on('dblclick',function(){
      var var_aux = $('textarea#categoria_textarea').val()
      var separador = $('textarea#categoria_textarea').val()==''?'':','

      var_aux = var_aux+separador+"{"+$(this).html()+"}";
      $('textarea#categoria_textarea').val(var_aux);
    })

    $('.close').on('click',function(){
      cerrar()
    })

    

    



})

$(function () {
  $('[data-toggle="tooltip"]').tooltip()
})



</script> 


<div border="0" class="table-responsive">
      
      

      <?php require "views/directivos/menu_vertical.php" ?>

      <div id="contenido">

      <?php require "views/directivos/header_directivo.php" ?>
      <div id="contenedor">
        
      <div class="row grid controls chart_extra">
        <div class="btn-xs" id="btn_chart_add" title="Agegar gráfica" data-toggle="tooltip" data-placement="left">+</div>
      </div> 

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
              <input type="hidden" name="tg" id="tg" value="">
              <div id="i_cont-detalles" style="display:none"></div>
            </form>
          </div>

        </div>

        
        <div id="detalles" >
          <div id="btn-detalles" class="btn btn-sm btn-block btn-success">Ver detalles</div>
          <div id="cont-detalles" style="padding:10px;"></div>
        </div>
      
      

      </div>
      
      </div>
    <?php require "views/directivos/footer_directivo.php" ?>
</div>

<div id="modal1" class="modalmask">
    <div class="modalbox movedown  col-md-8 col-sm-8 col-xs-12">
        <a href="#close" title="Close" class="close">X</a>
        <div class="ctrl-opciones-panel"><ul><li class="tab-active" id="tab-grafica">Gráficas</li><li id="tab-datos">Datos</li></ul></div>
        <div id="paneles">
        <div id="panel-graficas" style="display:inline;">
          <h2>Gráficas</h2><!-- Inicia panel graficas -->
          <div class="cont-img-chart cont-chart-active" title="Nunguna" data-toggle="tooltip"><img id="btn-grafica-nunguno" class="btn-grafica" src="images/graficas/column_chart.jpg" style="opacity:0;"></div>
          <div class="cont-img-chart" title="Columnas" data-toggle="tooltip"><img id="btn-grafica-column" class="btn-grafica" src="images/graficas/column_chart.jpg"></div>
          <div class="cont-img-chart" title="Pastel" data-toggle="tooltip"><img id="btn-grafica-pie" class="btn-grafica" src="images/graficas/pie_chart.jpg"></div>
          <div class="cont-img-chart" title="Geo" data-toggle="tooltip"><img id="btn-grafica-geo" class="btn-grafica" src="images/graficas/geo_chart.jpg"></div>
          <div class="cont-img-chart" title="Tabla" data-toggle="tooltip"><img id="btn-grafica-table" class="btn-grafica" src="images/graficas/table_chart.jpg"></div>
        </div><!-- Termina panel graficas -->

        <div id="panel-datos" style="display:none;"><!-- Inicia panel datos -->
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
          <label class="label col-md-4 col-sm-2 col-xs-12" style="">Nombre de serie:</label>
          <textarea id="names_textarea" class="campo col-md-4 col-sm-4 col-xs-6"  title='Agrega cada campo entre llaves o crea nuevos usando comillas, ejemplo:{usuario} ó "Grupo personalizado"' data-toggle="tooltip"></textarea>
          <select class="campo col-md-4 col-sm-4 col-xs-6" name="categorias-x" id="categorias-x" placeholder="Categorías" multiple="multiple" title='Haz doble click para agregar un campo a los nombres' data-toggle="tooltip">
            <option class="name_list_value" value="v_0">Usuario</option>
            <option class="name_list_value" value="v_1">Estado</option>
            <option class="name_list_value" value="v_2">Municipio</option>
            <option class="name_list_value" value="v_3">CAC</option>
            <option class="name_list_value" value="v_4">Categoría</option>
            <option class="name_list_value" value="v_5">Producto</option>
            <option class="name_list_value" value="v_8">Canal</option>
            <option class="name_list_value" value="v_9">Fecha</option>
            <option class="name_list_value" value="v_10">Servicio</option>
            <?php
              global $obj_db;
              $consulta3 = "SELECT id_form, f_alias FROM form_extra ORDER BY id_seccion ASC";
              $result3 = $obj_db->consulta($consulta3);
              if($result3!=false){
                foreach($result3 as $fila3){
            ?>
                  <option class="name_list_value" value="f_<?php echo $fila3['id_form']?>"><?php echo $fila3['f_alias']?></option>                  
            <?php
                }   
              }
            ?>            
          </select>
        </div>

        <div class="row grid">

          <label class="label col-md-4 col-sm-2 col-xs-12" style="">Valores:</label>
          <textarea id="value_textarea" class="campo col-md-4 col-sm-4 col-xs-6"  title='Agrega cada campo entre llaves o crea nuevos usando comillas, ejemplo:{usuario} ó "Grupo personalizado"' data-toggle="tooltip"></textarea>
          <!--<select class="campo col-md-4 col-sm-8 col-xs-12" name="operadores_grafica" id="operadores_grafica">
            <option value="o_0" selected="selected">SUMATORIA</option>
            <option value="o_1">PROMEDIO</option>
            <option value="o_2">SUMA</option>
            <option value="o_3">RESTA</option>
            <option value="o_4">MULT</option>
            <option value="o_5">DIV</option>
          </select>-->
          <select class="campo col-md-4 col-sm-4 col-xs-6" name="valores_grafica" id="valores_grafica" placeholder="Categorías" title='Haz doble click para agregar un campo a los valores' data-toggle="tooltip" multiple="multiple">
            <option class="value_list_value" value="v_0">Usuario</option>
            <option class="value_list_value" value="v_1">Estado</option>
            <option class="value_list_value" value="v_2">Municipio</option>
            <option class="value_list_value" value="v_3">CAC</option>
            <option class="value_list_value" value="v_4">Categoría</option>
            <option class="value_list_value" value="v_5">Producto</option>
            <option class="value_list_value" value="v_6">Inventario Inicial</option>
            <option class="value_list_value" value="v_7">Numero de Ventas</option>
            <option class="value_list_value" value="v_8">Canal</option>
            <option class="value_list_value" value="v_9">Fecha</option>
            <option class="value_list_value" value="v_10">Servicio</option>
            <option class="value_list_value" value="v_11">Total</option>
            <?php
              global $obj_db;
              $consulta3 = "SELECT id_form, f_alias FROM form_extra ORDER BY id_seccion ASC";
              $result3 = $obj_db->consulta($consulta3);
              if($result3!=false){
                foreach($result3 as $fila3){
            ?>
                  <option class="value_list_value" value="f_<?php echo $fila3['id_form']?>"><?php echo $fila3['f_alias']?></option>                  
            <?php
                }   
              }
            ?>
          </select>
        </div>

        <div class="row grid">

          <label class="label col-md-4 col-sm-2 col-xs-12" style="">Categorías horizontales:</label>
          <textarea id="categoria_textarea" class="campo col-md-4 col-sm-4 col-xs-6"  title='Agrega cada campo entre llaves o crea nuevos usando comillas, ejemplo:{usuario} ó "Grupo personalizado"' data-toggle="tooltip">{Fecha}</textarea>
          <select class="campo col-md-4 col-sm-4 col-xs-6" name="categoria_grafica" id="valores_grafica" placeholder="Categorías" title='Haz doble click para agregar un campo a los valores' data-toggle="tooltip" multiple="multiple">
            <option class="cat_list_value" value="v_0">Usuario</option>
            <option class="cat_list_value" value="v_1">Estado</option>
            <option class="cat_list_value" value="v_2">Municipio</option>
            <option class="cat_list_value" value="v_3">CAC</option>
            <option class="cat_list_value" value="v_4">Categoría</option>
            <option class="cat_list_value" value="v_5">Producto</option>
            <option class="cat_list_value" value="v_6">Inventario Inicial</option>
            <option class="cat_list_value" value="v_7">Numero de Ventas</option>
            <option class="cat_list_value" value="v_8">Canal</option>
            <option class="cat_list_value" value="v_9">Fecha</option>
            <option class="cat_list_value" value="v_10">Servicio</option>
            <option class="cat_list_value" value="v_11">Total</option>
            <?php
              global $obj_db;
              $consulta3 = "SELECT id_form, f_alias FROM form_extra ORDER BY id_seccion ASC";
              $result3 = $obj_db->consulta($consulta3);
              if($result3!=false){
                foreach($result3 as $fila3){
            ?>
                  <option class="value_list_value" value="f_<?php echo $fila3['id_form']?>"><?php echo $fila3['f_alias']?></option>                  
            <?php
                }   
              }
            ?>
          </select>
        </div>


                <br />

        </div> <!-- Fin de panel datos-->
        </div>

        <div class="panel-guardar-grafica">
            <button value="guardar" name="btn_datos_grafica" id="btn_datos_grafica" class="btn btn-block btn-sm btn-info ">Guardar configuración</button>
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