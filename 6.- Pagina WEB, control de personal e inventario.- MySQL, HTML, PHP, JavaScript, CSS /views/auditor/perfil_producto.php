<?php
require_once 'class/class.altaReporte.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='auditor'){
?>

 <body class="skin-blue sidebar-mini">


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

<div class="wrapper">      

      <?php require "views/auditor/menu_vertical.php" ?>      
      <?php require "views/auditor/header_auditor.php" ?>


      <div class="content-wrapper">

      
       <!-- Main content -->
        <section class="content"> 

        	<section class="content-header">
				<h1>
					Perfíl de Producto
				</h1>
				<ol class="breadcrumb">
            		<li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            		<li><a href="#">Perfíl de Producto</a></li>
          		</ol>
			</section>


			<div id="" class="">


			<form action="index.php?command=modificar_producto" method="POST" enctype="multipart/form-data" style="width:100%" id="form-alta">
				
					<br />
					<div class="box box-primary">
						<div class="box-header"><h4>Datos del Producto</h4></div>
						<div class="box-body">
							<div class="col-md-12 col-sm-12 col-xs-12">
								<div class="form-group row">
	 								<label class="col-md-2 col-sm-2 col-xs-2" style="">Producto*</label>
	 								<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-archive"></i></span>
	 										<select name="nombre-producto" id="nombre-producto" class="form-control"> 
			 									<option value="0">Selecciona...</option>
												<?php
												//global $obj_db;
                        						$consulta2 = "SELECT id_producto, producto_name FROM producto ORDER BY producto_name ASC";
                        						$result2 = $obj_db->consulta($consulta2);
                        						if($result2!=false){
		                          					foreach($result2 as $fila2){
                          								echo "<option class='' value ='".$fila2['id_producto']."'>".$fila2['producto_name']."</option>";
                          							}
                        						}
                        						?>
											</select>								
										</div>
									</div>
								</div>

								<div class="form-group row">	
									<label class="col-md-2 col-sm-2 col-xs-2">Gama</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-tasks"></i></span>				
											<div name="gama" id="gama" class="form-control"></div>
										</div>
									</div>							
								</div>

								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-2" style="">Descripción</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-comment-o"></i></span>
											<div name="descripcion-producto" id="descripcion-producto" class="form-control"></div>								
										</div>
									</div>
								</div>

								<div class="form-group row">
									<label class="col-md-2 col-sm-2 col-xs-2" style="">Precio</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon">$</span>
											<div name="precio-producto" id="precio-producto" class="form-control"></div>								
										</div>
									</div>
								</div>
	 						</div>											
						</div>
					</div>


					<?php
						global $obj_db;
                    	$consulta3 = "SELECT id_form, f_alias, f_label, f_default FROM form_extra WHERE id_seccion=3 ORDER BY f_alias ASC";
                        $result3 = $obj_db->consulta($consulta3);
                       	if($result3!=false){
                    ?>
                    <div class="box box-primary">
						<div class="box-header"><h4>Extras</h4></div>
						<div class="box-body">
							<div class="col-md-12 col-sm-12 col-xs-12">
								<input id="form_ext" name="form_ext" type="hidden" value="true">
						<?php
		                    	foreach($result3 as $fila3){
		            	?>
                         	
                        	 		<div class="form-group row">
										<label class="col-md-4 col-sm-4 col-xs-2"><?php echo $fila3['f_label']?></label>
										<div class="col-md-5 col-sm-8 col-xs-12">
											<div class="form-control" id="<?php echo "form_ext_".$fila3['id_form']?>" name="<?php echo "form_ext_".$fila3['id_form']?>" placeholder="<?php echo $fila3['f_default']?>" type="campo"></div>
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
                    </div>
						
					
					<div class="box box-primary">
						<div class="box-header"><h4>Cargar foto</h4></div>
						<div class="caja-campos row">
							<div class="form-group row">
								<label class="col-md-2 col-sm-2 col-xs-2 col-md-offset-2 col-sm-offset-2 col-xs-offset-2" style="">Foto CAC:*</label>
							</div>
							<div class="form-group row">
								<div id="marco-foto2" class="col-md-8 col-sm-6 col-xs-12 col-md-offset-2 col-sm-offset-3">
									<div  id="cont-image_preview2" class=""><img src="" id="foto_preview2" /></div>
								</div>	
							</div>
							
						</div>	

					</div>

			</form>

			</div>
		</section>
	</div>
		<?php require "views/auditor/footer_auditor.php"; ?>
</div>

</body>
<?php
}
else if($_SESSION['permiso']!='auditor'){
?>
<script>
alert("tu no tienes permiso para ver este contenido");
document.location.href="index.php?command=home";
</script>
<?php
}
?>