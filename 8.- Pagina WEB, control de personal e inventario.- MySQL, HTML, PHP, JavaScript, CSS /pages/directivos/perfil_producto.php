<?php
require_once 'class/class.altaReporte.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){
?>

<body>


<style>
#image-file{
	display:none;
}
.campo{min-height:20px;background-color:#ccc;}


</style>	

<script>
$(function(){//Funciones para validar fotografía
	  
	  //recuperar datos	
	  r_datos = function(options){

          options=(options==typeof(undefined))?'':options;
          params=options;
        var datos = $.ajax({
          url:'class/class.altas.php',
    		  type:'post',
    		  dataType:'json',
          data:params,
    		  async:false    		
    	 }).responseText;
        return datos
      }	
		 


	  //Preview Imagen
	  function readURL(input) {
		contenedor = $('#foto_preview2');  
      	if (input.files && input.files[0]) {
        	var reader = new FileReader();
        	reader.onload = function (e) {
           		contenedor.attr('src', e.target.result);
				contenedor.show()
        	}
        	reader.readAsDataURL(input.files[0]);
    	}
	  }	
	  
	  

		//Validar los campos obligatorios
		 $("#form-alta").submit(function() {
			var x1 = $("#nombre-producto").val();
			if (x1=='0') {
				alert("Debes seleccionar un Producto");
				return false;
			} else
				return true;
		});	

		$("#nombre-producto").on('change',function(){
			var valores = r_datos({'get_perfil_producto':$("#nombre-producto").val()})

			v_valores = JSON.parse(valores)
			if ($("#nombre-producto").val()!='0'){
				$("#gama").html(v_valores[1]);
				$("#descripcion-producto").html(v_valores[2]);
				$("#precio-producto").html(v_valores[4]);

					if(v_valores[3]!=''){
						$("#foto_preview2").attr('src',"uploads/productos/"+v_valores[3]);
						$("#foto_preview2").show();
					}else{
						$("#foto_preview2").attr('src',"images/no-image.jpg");
						//$("#foto_preview2").hide();
					}
				//Anexo 2 Forms extras
				v_valores_f_ext = JSON.parse(v_valores[6])
				var z = v_valores_f_ext;
					for(var i in z) {
						console.log(i)
						f_cont='#'+i;
						$(f_cont).html(v_valores_f_ext[i]);
					}
			}else{
				$("#escripcion-producto").html('');
				$("#precio-producto").html('');
				$("#foto_preview2").hide();
				//Anexo 2 Forms extras
				v_valores_f_ext = JSON.parse(v_valores[6])
				var z = v_valores_f_ext;
					for(var i in z) {
						console.log(i)
						f_cont='#'+i;
						$(f_cont).html(v_valores_f_ext[i]);
					}
			}
		})

	})

</script>

<div border="0" class="table-responsive">
	<?php require "views/directivos/menu_vertical.php" ?>

	<div id="contenido">
		<?php require "views/directivos/header_directivo.php" ?>		
		<div id="contenedor">

			<h3>Perfíl de Productos</h3>

				<div id="" class="cont-form col-md-10">

			<form action="index.php?command=modificar_producto" method="POST" enctype="multipart/form-data" style="width:100%" id="form-alta">
				
					<br />
					<div class="label-h">Datos del Producto</div>
					<div class="caja-campos row">
						<div class="col-md-12 col-sm-12 col-xs-12">
							<div class="row grid">
	 							<label class="label col-md-2 col-sm-2 col-xs-2" style="">Producto*</label>
	 							<select name="nombre-producto" id="nombre-producto" class="col-md-5 col-sm-8 col-xs-12"> 
		 							<option value="0">Selecciona...</option>
									<?php
									//global $obj_db;
                        			$consulta2 = "SELECT id_producto, producto_name FROM producto ORDER BY producto_name ASC";
                        			$result2 = $obj_db->consulta($consulta2);
                        			if($result2!=false){
	                          			foreach($result2 as $fila2){
                          					echo "<option class='text-danger text-center' value ='".$fila2['id_producto']."'>".$fila2['producto_name']."</option>";
                          				}
                        			}
                        			?>
								</select>								
							</div>

							<div class="row grid">	
								<div class="label col-md-2 col-sm-2 col-xs-2">Gama</div>					
								<div name="gama" id="gama" class="campo col-md-5 col-sm-8 col-xs-12"></div>								
							</div>

							<div class="row grid">
								<label class="label col-md-2 col-sm-2 col-xs-2" style="">Descripción</label>
								<div name="descripcion-producto" id="descripcion-producto" class="campo col-md-5 col-sm-8 col-xs-12"></div>								
							</div>

							<div class="row grid">
								<label class="label col-md-2 col-sm-2 col-xs-2" style="">Precio</label>
								<div name="precio-producto" id="precio-producto" class="campo col-md-5 col-sm-8 col-xs-12"></div>								
							</div>
	 					</div>											
					</div>



					<?php
						global $obj_db;
                    	$consulta3 = "SELECT id_form, f_alias, f_label, f_default FROM form_extra WHERE id_seccion=3 ORDER BY f_alias ASC";
                        $result3 = $obj_db->consulta($consulta3);
                       	if($result3!=false){
                    ?>
                    <div class="label-h">Extras</div>
					<div class="caja-campos row">
						<div class="col-md-12 col-sm-12 col-xs-12">
							<input id="form_ext" name="form_ext" type="hidden" value="true">
					<?php
		                    foreach($result3 as $fila3){
		            ?>
                         	
                         		<div class="row grid">
									<div class="col-md-6 col-sm-6" >
										<label class="label col-md-4 col-sm-4 col-xs-2"><?php echo $fila3['f_label']?></label>
										<div class="campo col-md-8 col-sm-8 col-xs-12" id="<?php echo "form_ext_".$fila3['id_form']?>" name="<?php echo "form_ext_".$fila3['id_form']?>" placeholder="<?php echo $fila3['f_default']?>" type="campo"></div>
									</div>	
								</div>	
                   	<?php
                   			}
                    ?>
                   		</div>
					</div>
                   	<?php		
                   	   	}
                    ?>
					
					
					<div class="label-h">Cargar foto</div>
					<div class="caja-campos row">
						<div class="row grid">
							<label class="label col-md-2 col-sm-2 col-xs-2 col-md-offset-3 col-sm-offset-3 col-xs-offset-3" style="">Foto CAC:*</label>
						</div>
						<div class="row grid">
							<div id="marco-foto2" class="col-md-7 col-sm-6 col-xs-12 col-md-offset-3 col-sm-offset-2">
								<div  id="cont-image_preview2" class=""><img src="" id="foto_preview2" /></div>
							</div>	
						</div>
						
					</div>	


					<hr>

					<div class="">
						<input type="submit" value="Modificar" name="btn_modificar_producto" class="btn btn-block btn-sm btn-info">
					</div>

					
					<br />
				

			</form>

			</div>
		</div>
		<?php require "views/directivos/footer_directivo.php" ?>
	</div>
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