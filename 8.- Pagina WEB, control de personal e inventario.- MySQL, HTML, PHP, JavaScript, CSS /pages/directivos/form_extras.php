<?php
require_once 'class/class.camposExtras.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){
?>

<body>

<style>
.controls.form_extra{
	text-align: right;
}
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

.t_h_label{
	display: inline-block;
	background-color: #F11111;
	margin:0 1px;
	padding:3px auto;
	text-align: center;
	font-weight: bold;
	color:#FFF;
	font-size: 11px;	
}
.row{
	margin-left:5px;
	margin-right:5px;
}
#cont_campos_extras_usuarios .row:nth-child(2n+1), #cont_campos_extras_cacs .row:nth-child(2n+1), #cont_campos_extras_productos .row:nth-child(2n+1){background:#FFF;}
#cont_campos_extras_usuarios .row:nth-child(2n+1), #cont_campos_extras_cacs .row:nth-child(2n+1), #cont_campos_extras_productos .row:nth-child(2n){background:#eee;}

.i_alias, .i_label, .i_tipo, .i_default{width:100%;}

</style>

<script>

$(function(){

      function ajaxCampos(options){
          options=(options==typeof(undefined))?'':options;
          params=options;
        var datos = $.ajax({
              url:'class/class.camposExtras.php',
              type:'post',
              async: false,
              data:params,
              success:function(data){
                    if(data==false){
                        getCampos('1');
                        getCampos('2');
                        getCampos('3');
                        return data;
                    }
              }          
         }).responseText;
        return datos
      }




    function construir_campos(){

        <?php

        ?>

         var s= '<div class="row grid pre_campo">'+
                    '<div class="t_d_label col-md-2 col-sm-2 col-xs-2" id=""><input type="text" name="p_alias" id="p_alias" class="campo col-md-12 col-sm-12 col-xs-12" placeholder="Alias"></div>'+
                    '<div class="t_d_value col-md-3 col-sm-3 col-xs-3"><input type="text" name="p_label" id="p_label" class="campo col-md-12 col-sm-12 col-xs-12" placeholder="Label"></div>'+
                    '<div class="t_d_value col-md-2 col-sm-2 col-xs-2">'+
                       '<select type="text" name="p_tipo" id="p_tipo" class="campo col-md-12 col-sm-12 col-xs-12" placeholder="Tipo">'+
                            '<option value="0">Selecciona una opción</option>'+
                            '<option value="1">Texto</option>'+
                            '<option value="2">Multiselección</option>'+
                       '</select>'+
                    '</div>'+
                    '<div class="t_d_value col-md-2 col-sm-2 col-xs-2"><input type="text" name="p_default" id="p_default" class="campo col-md-12 col-sm-12 col-xs-12" placeholder="Valor por defecto"></div>'+
                    '<div class="t_d_value col-md-1 col-sm-1 col-xs-1" style="text-align:center"><div class="btn-xs btn-xs-nuevo">O</div></div>'+
                    '<div class="t_d_value col-md-1 col-sm-1 col-xs-1" style="text-align:center"><div class="btn-xs btn-xs-cancel">x</div></div>'+
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
                ajaxCampos(opciones);
                
            }else{
                
            };
        });

        $('.btn-xs-change').unbind();
        $('.btn-xs-saveChange').unbind();
        $('.btn-xs-cancel').unbind();
        $('.btn-xs-delete').unbind();

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
    }

    //Recupera formularios

    function getCampos(seccion){
        var opciones={};
        opciones.f="getCampos";
        opciones.seccion=seccion;
        campos=ajaxCampos(opciones);
        if (seccion==1&&campos!=1){
            $('#cont_campos_extras_usuarios').html('');
            $('#cont_campos_extras_usuarios').html(campos);
            handler('altaCampo','1');
        }
        if (seccion==2&&campos!=1){
            $('#cont_campos_extras_cacs').html('');
            $('#cont_campos_extras_cacs').html(campos);
            handler('altaCampo','2');
        }
        if (seccion==3&&campos!=1){
            $('#cont_campos_extras_productos').html('');
            $('#cont_campos_extras_productos').html(campos);
            handler('altaCampo','2');
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
                if($(this).hasClass('i_alias')){aux_alias=$(this).html()}
                if($(this).hasClass('i_label')){aux_label=$(this).html()}
                
                if($(this).hasClass('i_tipo')){
                    aux_tipo=$(this).html()

                    var a1, a2, a3;

                    a1 = $(this).html()=="Selecciona un Opción"?"selected":"";
                    a2 = $(this).html()=="Texto"?"selected":"";
                    a3 = $(this).html()=="Multiselección"?"selected":"";


                    return '<select type="text" class="'+$(this).attr('class')+'" name="'+$(this).attr('name')+'" id="'+$(this).attr('id')+'" placeholder="'+$(this).attr('placeholder')+'" >'+
                        '<option value="0" '+a1+'>Selecciona una Opción</option>'+
                        '<option value="1" '+a2+'>Texto</option>'+
                        '<option value="2" '+a3+'>Multiselección</option>'+
                    '</select>'
                }

                if($(this).hasClass('i_default')){
                    aux_default=$(this).html()
                    elementDefault=$(this);
                    if($(this).parent().prev().children().val()=='2'){
                        return '<textarea type="text" class="'+$(elementDefault).attr('class')+'" name="'+$(elementDefault).attr('name')+'" id="'+$(elementDefault).attr('id')+'" placeholder="'+$(elementDefault).attr('placeholder')+'">'+$(elementDefault).html()+'</textarea>';
                    }
                }


                return '<input type="text" class="'+$(this).attr('class')+'" name="'+$(this).attr('name')+'" id="'+$(this).attr('id')+'" placeholder="'+$(this).attr('placeholder')+'" value="'+$(this).html()+'">'
            });            
        handler('','');
    }

    function salvarcambios(element){
        var nomAlias=$(element).parent().parent().children().children('.i_alias').val()
        var nomLabel=$(element).parent().parent().children().children('.i_label').val()
        var nomTipo=$(element).parent().parent().children().children('.i_tipo').val()
        var nomDefault=$(element).parent().parent().children().children('.i_default').val()
        var attrID=$(element).parent().next().children().attr('id');

         if(confirm("Estas a punto de cambiar el formulario '"+nomAlias+"',\nrealmente deseas cambiarlo?")){
                var opciones={};
                opciones.f='cambiarCampo';
                opciones.id_form=attrID;
                opciones.alias=nomAlias
                opciones.label=nomLabel;
                opciones.tipo=nomTipo;
                opciones.default=nomDefault;
                ajaxCampos(opciones);                
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
            opciones.f='borrarCampo';
            opciones.id_form=attrID;
            ajaxCampos(opciones);
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


    
    //Crea un campo para usuarios
  $('#btn_user_f_add').click(function(){
    var campo = construir_campos();
    $('.pre_campo').remove();
    $('#cont_campos_extras_usuarios').append(campo);
    handler('altaCampo','1');
  });

  //Crea un campo para cacs
  $('#btn_cac_f_add').click(function(){
    var campo = construir_campos();
    $('.pre_campo').remove();
    $('#cont_campos_extras_cacs').append(campo);
    handler('altaCampo','2');
  });

  //Crea un campo para productos
  $('#btn_producto_f_add').click(function(){
    var campo = construir_campos();
    $('.pre_campo').remove();
    $('#cont_campos_extras_productos').append(campo);
    handler('altaCampo','3');
  });




    function inic(){
        getCampos(1);
        getCampos(2);
        getCampos(3);
    }

    inic()
    
})

</script>

<div border="0" class="table-responsive">
	<?php require "views/directivos/menu_vertical.php" ?>


        <?php require "views/directivos/header_directivo.php" ?>        
        <div id="contenedor">

            <h3> Informacion extra de campos </h3>

            <div id="" class="cont-form col-md-10">

                
                    <br />
                    <div class="" style="font-weight:bold; text-align:center; font-size:12px; margin-bottom:10px;">Agregar campos a:</div>
                    
                    <div class="label-h">Usuarios</div>
                    <div class="caja-campos row">
                    	<div class="row grid controls form_extra">
                    		<div class="btn-xs" id="btn_user_f_add">+</div>
                    	</div>
                    	<div class="row grid">
                            <div class="t_h_label col-md-2 col-sm-2 col-xs-2">Alias</div>
                            <div class="t_h_label col-md-3 col-sm-3 col-xs-3">Label</div>
                            <div class="t_h_label col-md-2 col-sm-2 col-xs-2">Tipo</div>
                            <div class="t_h_label col-md-2 col-sm-2 col-xs-2">Valor por Defecto</div>
                            <div class="t_h_label col-md-1 col-sm-1 col-xs-1">Editar/<br>Guardar</div>
                            <div class="t_h_label col-md-1 col-sm-1 col-xs-1">Eliminar/<br>Cancelar</div>
                    	</div>
                        <div id="cont_campos_extras_usuarios">                            
                        </div>
                    </div>	
                    <div class="label-h">CAC's</div>
                    <div class="caja-campos row">
                    	<div class="row grid controls form_extra">
                    		<div class="btn-xs" id="btn_cac_f_add">+</div>
                    	</div>
                        <div class="row grid">
                            <div class="t_h_label col-md-2 col-sm-2 col-xs-2">Alias</div>
                            <div class="t_h_label col-md-3 col-sm-3 col-xs-3">Label</div>
                            <div class="t_h_label col-md-2 col-sm-2 col-xs-2">Tipo</div>
                            <div class="t_h_label col-md-2 col-sm-2 col-xs-2">Valor por Defecto</div>
                            <div class="t_h_label col-md-1 col-sm-1 col-xs-1">Editar/<br>Guardar</div>
                            <div class="t_h_label col-md-1 col-sm-1 col-xs-1">Eliminar/<br>Cancelar</div>
                        </div>
                        <div id="cont_campos_extras_cacs">                            
                        </div>
                    </div>	
                    <div class="label-h">Productos</div>
                    <div class="caja-campos row">
                    	<div class="row grid controls form_extra">
                    		<div class="btn-xs" id="btn_producto_f_add">+</div>
                    	</div>
                        <div class="row grid">
                            <div class="t_h_label col-md-2 col-sm-2 col-xs-2">Alias</div>
                            <div class="t_h_label col-md-3 col-sm-3 col-xs-3">Label</div>
                            <div class="t_h_label col-md-2 col-sm-2 col-xs-2">Tipo</div>
                            <div class="t_h_label col-md-2 col-sm-2 col-xs-2">Valor por Defecto</div>
                            <div class="t_h_label col-md-1 col-sm-1 col-xs-1">Editar/<br>Guardar</div>
                            <div class="t_h_label col-md-1 col-sm-1 col-xs-1">Eliminar</div>
                        </div>
                        <div id="cont_campos_extras_productos">                            
                        </div>
                    </div>	

                    <div class="caja-campos row">
                        <input type="submit" value="Guardar" name="btn_alta" class="btn btn-block btn-sm btn-info ">
                    </div>

                    <br />
                

            </div>
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