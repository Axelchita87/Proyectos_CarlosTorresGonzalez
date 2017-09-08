<?php
require_once 'class/class.camposExtras.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){
?>

  <body class="skin-blue sidebar-mini">

<style>
.controls.form_extra{
	text-align: right;
}

.row{
	margin-left:5px;
	margin-right:5px;
}

.i_alias, .i_label, .i_tipo, .i_default{width:100%;}

</style>

<script>

$(function(){

      function ajaxFormularios(options){
          options=(options==typeof(undefined))?'':options;
          params=options;
        var datos = $.ajax({
              url:'class/class.formulariosPersonalizados.php',
              type:'post',
              async: false,
              data:params,
              success:function(data){
                    if(data==false){
                        getFormulario('4');
                        return data;
                    }
              }          
         }).responseText;
        return datos
      }




    function construir_formulario(){

        <?php

        ?>

         var s= '<div class="form-group row pre_campo">'+
                    '<div class="t_d_value col-md-9 col-sm-9 col-xs-9"><input type="text" name="p_label" id="p_label" class="form-control" placeholder="Label"></div>'+
                    '<div class="t_d_value col-md-1 col-sm-1 col-xs-1" style="text-align:center"><button class="btn btn-primary btn-xs-add-ask">+</button></div>'+
                    '<div class="t_d_value col-md-1 col-sm-1 col-xs-1" style="text-align:center"><button class="btn btn-primary btn-xs-nuevo">O</button></div>'+
                    '<div class="t_d_value col-md-1 col-sm-1 col-xs-1" style="text-align:center"><button class="btn btn-primary btn-xs-cancel">x</button></div>'+
                '</div>';                
        return (s);
    }   

    //Nuevo

    function handler(cadena,seccion){
        $('.btn-xs-nuevo').click(function(){
            if(confirm("Estas a punto de cargar un nuevo formulario,\nrealmente deseas agregar un formulario?")){
                var opciones={};
                opciones.f=cadena;
                opciones.alias=$('#p_alias').val();
                opciones.label=$('#p_label').val();
                opciones.tipo=$('#p_tipo').val();
                opciones.default=$('#p_default').val();
                opciones.seccion=seccion
                ajaxFormularios(opciones);
                
            }else{
                
            };
        });

        $('.btn-xs-change').unbind();
        $('.btn-xs-saveChange').unbind();
        $('.btn-xs-cancel').unbind();
        $('.btn-xs-delete').unbind();
        $('.btn-xs-add-ask').unbind();

        $('.btn-xs-change').click(function(){
            cambiar($(this));
        })

        $('.btn-xs-saveChange').click(function(){
            salvarcambios($(this));
        })

        $('.btn-xs-cancel').click(function(){
            cancelar($(this));
        });

        $('.btn-xs-delete').click(function(){
            borrar($(this));
        });

        $('.i_tipo').on('change',function(){
            cambiarInputDefault($(this));
        });

        $('.btn-xs-add-ask').click(function(){
            agregarPreguntas($(this));
        });
    }

    //Recupera formularios

    function getFormulario(seccion){
        var opciones={};
        opciones.f="getFormulario";
        opciones.seccion=seccion;
        formularios=ajaxFormularios(opciones);
        if (seccion==4&&formularios!=1){
            $('#cont_formularios_extras').html('');
            $('#cont_formularios_extras').html(formularios);
            handler('altaFormulario','4');
        }
    }

    //Definimos variables auxiliares para almacenar los campos
    var aux_alias, aux_label, aux_tipo, aux_default

    function cambiar(element){
            
        //Elimina las clases para los elementos que no se modificaron
            $('btn-xs-saveChange').removeClass('btn-xs-saveChange').addClass('btn-xs-change');
            $('.btn-xs-delete').removeClass('btn-xs-delete').addClass('btn-xs-cancel');
            //Cambia la clase de los elementos a modificar
            $(element).removeClass('btn-xs-change').addClass('btn-xs-saveChange');
            $(element).parent().parent().children().children('.i_alias, .i_label, .i_tipo, .i_default').replaceWith(function() {
                //return ('<input value="' + $(this).html + '">');
                if($(this).hasClass('i_label')){aux_label=$(this).html()}
                
                return '<input type="text" class="'+$(this).attr('class')+'" name="'+$(this).attr('name')+'" id="'+$(this).attr('id')+'" placeholder="'+$(this).attr('placeholder')+'" value="'+$(this).html()+'">'
            });            
        handler('','');
    }

    function salvarcambios(element){
        var nomAlias=''
        var nomLabel=$(element).parent().parent().children().children('.i_label').val()
        var nomTipo=''
        var nomDefault=''
        var attrID=$(element).parent().next().children().attr('id');

         if(confirm("Estas a punto de cambiar el formulario '"+nomAlias+"',\nrealmente deseas cambiarlo?")){
                var opciones={};
                opciones.f='cambiarFormulario';
                opciones.id_form=attrID;
                opciones.alias=nomAlias
                opciones.label=nomLabel;
                opciones.tipo=nomTipo;
                opciones.default=nomDefault;
                ajaxFormularios(opciones);                
          }  
    }

    function cancelar(element){
        if(confirm("Si cancelas ahora no se guardarán los cambios,\nrealmente deseas cancelar?")){
               //Remueve los formularios no guardados
                $('.pre_campo').remove();
                //Devuelve las clases a la normalidad
                //$(element).parent().prev().children('.btn-xs-saveChange').removeClass('btn-xs-saveChange').addClass('btn-xs-change');
                $('input.i_alias, input.i_label, select.i_tipo, input.i_default').replaceWith(function() {
                    //return ('<input value="' + $(this).html + '">');
                var valor_control_inicial='';

                if($(this).hasClass('i_alias')){valor_control_inicial=aux_alias}
                if($(this).hasClass('i_label')){valor_control_inicial=aux_label}
                if($(this).hasClass('i_default')){valor_control_inicial=aux_default}
                if($(this).hasClass('i_tipo')){valor_control_inicial=aux_tipo}
                
                    return '<div class="'+$(this).attr('class')+'" name="'+$(this).attr('name')+'" id="'+$(this).attr('id')+'" placeholder="'+$(this).attr('placeholder')+'" >'+valor_control_inicial+'</div>'
                });
                $('.btn-xs-saveChange').removeClass('btn-xs-saveChange').addClass('btn-xs-change');
                $(element).removeClass('btn-xs-cancel').addClass('btn-xs-delete');
        };
        handler('','');
    }

    function borrar(element){
        var attrID=$(element).attr('id');
        if(confirm("Realmente deseas eliminar el elemento "+$(element).attr('id')+"?")){
            var opciones={};
            opciones.f='borrarFormulario';
            opciones.id_form=attrID;
            ajaxFormularios(opciones);
               // borrarCampo($(element).attr('id'));
        };
        handler('','');
    }

    function cambiarInputDefault(element){

        elementDefault=$(element).parent().next().children();
        if($(element).val()=='1'){
            elementDefault.replaceWith(function() {
                //alert("Texto");
                return '<input type="text" class="'+$(elementDefault).attr('class')+'" name="'+$(elementDefault).attr('name')+'" id="'+$(elementDefault).attr('id')+'" placeholder="'+$(elementDefault).attr('placeholder')+'" value="'+$(elementDefault).val()+'">'
            })
        }
        if($(element).val()=='2'){
            elementDefault.replaceWith(function() {
                //alert("Multiselección");
                return '<textarea type="text" class="'+$(elementDefault).attr('class')+'" name="'+$(elementDefault).attr('name')+'" id="'+$(elementDefault).attr('id')+'" placeholder="'+$(elementDefault).attr('placeholder')+'">'+$(elementDefault).val()+'</textarea>'
            })
        }
    }

    function agregarPreguntas(element){
            document.location.href="?command=editar_formulario&formulario="+$(element).attr('id')
    }


    
    //Crea un campo para usuarios
  $('#btn_form_f_add').click(function(){
    var formulario = construir_formulario();
    $('.pre_campo').remove();
    $('#cont_formularios_extras').append(formulario);
    handler('altaFormulario','4');
  });






    function inic(){
        getFormulario(4);
    }

    inic();
    
})

    $(function () {
      $('[data-toggle="tooltip"]').tooltip();
    })

</script>

<div class="wrapper">
      
      <?php require "views/directivos/menu_vertical.php" ?>      
      <?php require "views/directivos/header_directivo.php" ?>


        <div class="content-wrapper">

          
           <!-- Main content -->
            <section class="content"> 

                <section class="content-header">
                    <h1>
                        Informacion extra para formularios 
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li><a href="#">Formularios personalizados</a></li>
                    </ol>
                </section>

                <div id="" class="">

                    
                        <div class="box box-primary">
                            <div class="box-header">
                                <h4>Formularios personalizados</h4>
                                <span class="pull-right">
                                    <a href="index.php?command=respuestas_cuestionarios"><button class="btn btn-primary" title="Ver respuesta de formularios" data-toggle="tooltip" data-placement="bottom"  id="btn_form_f_"><img  src="images/logo_ver.png" style="max-width:10px" /></button></a>
                                    <button class="btn btn-primary" title="Agregar un nuevo formulario" data-toggle="tooltip" data-placement="bottom"  id="btn_form_f_add">+</button>
                                </span>
                            </div>                    

                            <div class="box-body">
                            	<div class="box-header with-border bg-light-blue">
                                    <div class="box-title col-md-9 col-sm-9 col-xs-9"><h5>Nombre del Formulario</h5></div>
                                    <div class="box-title col-md-1 col-sm-1 col-xs-1"><h5>Añadir<br>Preguntas</h5></div>
                                    <div class="box-title col-md-1 col-sm-1 col-xs-1"><h5>Editar/<br>Guardar</h5></div>
                                    <div class="box-title col-md-1 col-sm-1 col-xs-1"><h5>Eliminar/<br>Cancelar</h5></div>
                        	   </div>
                                <div id="cont_formularios_extras">                            
                                </div>
                            </div>	
                        </div>

                        <br />
                    

                </div>
            </section>
            
        </div>

    <?php require "views/directivos/footer_directivo.php" ?>

    </div>


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