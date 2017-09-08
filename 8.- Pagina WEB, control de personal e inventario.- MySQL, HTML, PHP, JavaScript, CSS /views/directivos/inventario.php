
<?php
require_once 'class/class.inventario.php';
//session_start();
if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){

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

.codigo_inventario{
  min-width: 300px;
}


</style> 

    <script type="text/javascript">
       //recuperar datos  
      r_datos = function(options){

          options=(options==typeof(undefined))?'':options;
          params=options;
        var datos = $.ajax({
          url:'class/class.inventario.php',
          type:'post',
          dataType:'json',
          data:params,
          async:false       
       }).responseText;
        return datos
      }

      function limpiar_tabla(contenedor){
        $(contenedor).html("");
      }

      function constuctor_header_tabla(array_value,contenedor){
        var s="";
        s+= "<thead>";
        s+= " <tr>";
        array_value.forEach(function(value){
          s+= " <th>"+ value +"</th>";          
        });
        s+= "<th>Opciones</th>"
        s+= " </tr>";
        s+= "</thead>";
        $(contenedor).append(s);
      }

      function validarSiNumero(numero){
        if (!/^([0-9])*$/.test(numero))
          return false;
        else
          return true;
      }

      function constuctor_body_tabla(filas,contenedor,obj_value){
        var s="";
        var codigo = "";
        var id_div = "";
        var onclick_script;

        s+= "<tbody>";
        for(i=0;i<filas;i++){

          onclick_script = "";

          /*if (validarSiNumero(obj_value['codigo'][i])){
            codigo = obj_value['codigo'][i];
            onclick_script= '$("#tr_'+obj_value["id"][i]+' .codigo_inventario").barcode("'+codigo+'", "ean13",{barWidth:2, barHeight:30});'
            //alert(codigo);
          }*/

          s+= " <tr id='tr_"+obj_value['id'][i]+"'>";
          s+= "   <td class='nombre_inventario'>"+obj_value['nombre'][i]+"</td>";          
          s+= "   <td class='cantidad_inventario'>"+obj_value['cantidad'][i]+"</td>";          
          s+= "   <td class='codigo_inventario'>"+obj_value['codigo'][i]+"</td>";          
          s+= "   <td class='fecha_inventario'>"+obj_value['fecha'][i]+"</td>";          
          s+= "   <td>\n"+
              "     <a class='btn btn-primary' href='' class='btn_editar_inventario' onclick='target_editar_inventario(\""+obj_value['cantidad'][i]+"\","+obj_value['id'][i]+",\""+obj_value['nombre'][i]+"\")' data-toggle='modal' data-target='#editar'>EI</a>\n"+
              "     <a class='btn btn-primary' href='' class='btn_editar_codigo' onclick='target_editar_codigo(\""+obj_value['codigo'][i]+"\","+obj_value['id'][i]+",\""+obj_value['nombre'][i]+"\")' data-toggle='modal' data-target='#editar'>EC</a>\n"+
              "     <a class='btn btn-primary' onclick='"+onclick_script+"'>IC</a>\n"+
              "   </td>";
          s+= " </tr>";
        };
        s+= "</tbody>";
        //Agregamos todos los productos
        $(contenedor).append(s);

        for(i=0;i<filas;i++){
          codigo = obj_value['codigo'][i];//'2147483647284';
          id_div = obj_value['id'][i];//'2147483647284';

          (function(codigo, id_div){          
            window.setTimeout(
              function(){
              //if (validarSiNumero(""+codigo+"")){
                console.log(id_div);
                $("#tr_"+id_div+" .codigo_inventario").barcode(""+codigo+"", "code128",{barWidth:2, barHeight:25,bgColor:'none'});
              //}
            },
            100*i);
          })(codigo,id_div);
          //console.log(i);
        }
      }

      function errores(n){
        var msj;
        switch(arr_json['error']){
            case 1:
                      msj = "No se encontraron los productos";
                      break;
            case 2:   
                      msj = "El código ya existe";
                      break;
            case 3:   
                      msj = "El producto no existe";
                      break; 
            case 4:   
                      msj = "El producto no existe en inventario";
                      break;      
            default: 
                      msj = "Error desconocido";
                      break;
          }

        return msj;
      }

      function update_codigo(codigo, id_producto){
        var debugg_update_codigo = r_datos({funcion:'actualizar_codigo',old_value:$('#old_value').val(),id_producto:$('#update_id_producto').val(),new_value:$('#new_value').val()});
        var msj;
        
        console.log(debugg_update_codigo);

        if (debugg_update_codigo){
          arr_json = JSON.parse(debugg_update_codigo);
          if (arr_json['error']){
            msj = errores(arr_json['error']);  
          }else{
            $("#tr_"+$('#update_id_producto').val()+" .codigo_inventario").barcode($('#new_value').val(), "code128",{barWidth:1, barHeight:25,bgColor:'none'});
            msj="Tu código fué actualizado exitosamente"
          }
        }else{
          arr_json = debugg_update_codigo['error'] = -1;
          msj = errores(arr_json['error']);
        }

        $('#mensaje_editar').html(msj);
      }

      function update_inventario(cantidad, id_producto){
        var debugg_update_codigo = r_datos({funcion:'actualizar_inventario',id_producto:$('#update_id_producto').val(),new_value:$('#new_value').val()});
        var msj;
        
        console.log(debugg_update_codigo);

        if (debugg_update_codigo){
          arr_json = JSON.parse(debugg_update_codigo);
          if (arr_json['error']){
            msj = errores(arr_json['error']);  
          }else{
            $("#tr_"+$('#update_id_producto').val()+" .cantidad_inventario").html($('#new_value').val());
            msj="Tu código fué actualizado exitosamente"
          }
        }else{
          arr_json = debugg_update_codigo['error'] = -1;
          msj = errores(arr_json['error']);
        }

        $('#mensaje_editar').html(msj);
      }

      function target_editar_codigo(codigo,id,producto_name){
        //Limpia los valores
        $('#old').html('');
        $('#old_value').val('');
        $('#update_id_producto').val('');
        $('#new_value').val('');

        //Asigna valores
        $('.type_edit').html('Código');// Type edit {Codigo/Inventario}
        $('#old').html(codigo);
        $('#old_value').val(id);
        $('#update_id_producto').val(id);
        $('.span_producto').html(producto_name);
        $('#botonAction').attr('onclick','update_codigo()');
      }

      function target_editar_inventario(inventario,id,producto_name){
        //Limpia los valores
        $('#old').html('');
        $('#old_value').val('');
        $('#update_id_producto').val('');
        $('#new_value').val('');

        //Asigna valores
        $('.type_edit').html('Inventario');// Type edit {Codigo/Inventario}
        $('#old').html(inventario);
        $('#old_value').val(id);
        $('#update_id_producto').val(id);
        $('.span_producto').html(producto_name);
        $('#botonAction').attr('onclick','update_inventario()')
      }

      function tabla_productos(){
        var s;
        var tabla = {};
        var datos = JSON.parse(r_datos({funcion:'lista_de_productos'}));
        var n_prod=datos.id.length;        

        tabla.headers = Array("Producto","Cantidad","Código","Fecha de Último Inventario");
        
        limpiar_tabla("#inventario");
        constuctor_header_tabla(tabla.headers,"#inventario");
        constuctor_body_tabla(n_prod,"#inventario",datos);     
        
      }
      
      $(function () {
        tabla_productos();
        $("#inventario").dataTable();

        $(".pagination").on("click",function(){
          setTimeout(function(){
            var tr_array = $("#inventario tbody").children("tr");
            tr_array.each(function(index){
              codigo = $(this).children(".codigo_inventario").text();
              if (codigo != "n/d"){
                $(this).children(".codigo_inventario").barcode(""+codigo+"", "code128",{barWidth:1, barHeight:25,bgColor:'none'});
              }
                console.log($(this).children(".codigo_inventario").text())
            });
          },500)
        })
      });
    </script>


<div class="wrapper">
      
      

      <?php require "views/directivos/menu_vertical.php" ?>      
      <?php require "views/directivos/header_directivo.php" ?>

      
      <div class="content-wrapper">

        
      
       <!-- Main content -->
        <section class="content"> 

          <!-- Main content -->
          <section class="content-header">
            <h1>
              Inventario
              <small>Version 3.0</small>            
            </h1>
            <ol class="breadcrumb">
              <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
              <li class="active">Inventario</li>
            </ol>
          </section>

          <br>
          <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12"> <!-- Inicia contenedor de tabla -->
                <div class="box box-primary">
                  <div class="box-header">
                    <h3 class="box-title">Tabla de productos</h3>
                  </div><!-- /.box-header -->
                  <div class="box-body">
                    <table id="inventario" class="table table-bordered table-hover">
                      <thead>
                        
                      </thead>
                      <tbody>
                        
                      </tbody>
                    </table>                        
                  </div>
                </div>

            </div> <!-- Termina contenedor de tabla -->
          </div>
        </section>
      
      </div>

      <?php require "views/directivos/footer_directivo.php"; ?>

</div>

<!-- Modal Escenario-->
<div class="modal fade" id="editar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Cerrar</span></button>
        <h4 class="modal-title" id="myModalLabel">Editar <span class="type_edit"></span> de <span class="span_producto"></span></h4>
      </div>
      <div id="nuevaAventura" class="modal-body">
            <form role="form">
              <div class="form-group">
                <label for="old"><span class="type_edit"></span> anterior:</label>
                <div class="form-control" id="old"></div>
                <input type="hidden" id="old_value" value="">
                <input type="hidden" id="update_id_producto" value="">
              </div>
              <div class="form-group">
                <label for="new">Nuevo <span class="type_edit"></span></label>
                <input type="text" class="form-control" id="new_value" placeholder="" required>
              </div>
              <div id="mensaje_editar"></div>                         
           </form>      
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
        <button type="button" class="btn btn-primary" id="botonAction" onClick="">Editar</button>        
      </div>
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