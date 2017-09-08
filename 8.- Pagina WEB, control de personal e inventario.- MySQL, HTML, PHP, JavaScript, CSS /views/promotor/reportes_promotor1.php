<?php
require_once 'class/class.altaReporte.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='promotor'){
?>

<body class="skin-blue sidebar-mini">

	<script>


	$(function(){


		var HighScore = localStorage.getItem('highScore');
		if (HighScore == null || HighScore == "null") {
  			HighScore = 0;
		}

		r_cac = function(options){
			console.log("opciones:"+options);
          options=(options==typeof(undefined))?'':options;
          params=options;
        var datos = $.ajax({
          url:'class/class.altaReporte.php',
    		  type:'post',
    		  dataType:'json',
          data:params,
    		  async:false    		
    	 }).responseText;
        return datos
      	}


      	$('#cacR').on('change',function(){
      		var datos_cac = JSON.parse(r_cac({datos_cac:$(this).val()}));

      		x1=typeof null === datos_cac[0]?'No disponible':datos_cac[0];
      		x2=typeof null === datos_cac[1]?'No disponible':datos_cac[1];

      		$('#cont-estado').html(x1);
      		$('#cont-municipio').html(x2);
      		$('#estado').val(datos_cac[2]);
      		$('#municipio').val(datos_cac[3]);

      		

      	})

      	//Validar los campos obligatorios
		 $("#form-alta").submit(function() {

		 		var x1 = $("#cacR").val();
				var x2 = $("#gama").val();
				var x3 = $("#equipo").val();
				var x4 = $("#inventario-inicial").val();
				var x5 = $("#ventas").val();
				if (x1=='0'||x2=='0'||x3=='0'||x4==''||x5=='') {
					alert("Por favor llena los datos necesarios");
					return false;
				} else{

					if($("#modal1").is(':hidden')){
						$("#modal1").toggle();
		 				return false;
					}else{
						var valor_gama = $("#gama").val();
		 				var valor_equipo = $("#equipo").val();
						localStorage[valor_gama+'.'+valor_equipo] = $("#inventario-inicial" ).val();
						return true;
					}						
				}
			
		});


		 function guardar_variable_local(valor){
		 	localStorage[$("#gama").val()][$("#equipo").val()]=valor;
		 }

		 $( "#gama, #equipo" ).change(function(){
		 	if ($("#gama").val()!='0' && $("#equipo").val()!='0'){

		 		var valor_gama = $("#gama").val();
		 		var valor_equipo = $("#equipo").val();
		 		localStorage[valor_gama+'.'+valor_equipo] = localStorage[valor_gama+'.'+valor_equipo]||'';

		 		$("#inventario-inicial" ).val(localStorage[valor_gama+'.'+valor_equipo])
		 		console.log($("#inventario-inicial" ).val())
		 	}
		 })


		 $( "#inventario-inicial" ).click(function() {
			if(confirm( "Estás seguro de querer cambiar\nel valor del inventario inicial?" )){
				$( "#inventario-inicial" ).focus();
			}else{
				$('#inventario-inicial').blur();
			};
		 });



  	});

	</script>


	<style>
		
	</style>
    <!-- Site wrapper -->
    <div class="wrapper">

      	<?php require "views/promotor/header_promotor.php"; ?>
      	<?php require "views/promotor/menu_vertical.php"; ?>
        <!-- Content Wrapper. Contains page content -->
      	<div class="content-wrapper">


			<section class="content-header">
          		<h1>
		            Reportes
            		<small>Reportes</small>
          		</h1>
          		<ol class="breadcrumb">
		            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            		<li><a href="#">Reportes</a></li>
          		</ol>
       		</section>


			<section id="" class="content">

		<?php	
		$consulta = "SELECT usuario.id_usuario, usuario.user_name, usuario.user_nombre, usuario.apellido_paterno, usuario.user_estado, estados.nombre AS enombre, usuario.user_foto, usuario.user_municipio 
					 FROM usuario 
					 LEFT JOIN estados
					 		 ON usuario.user_estado=estados.id_estado
					 WHERE id_usuario=".$_SESSION['user_id']." LIMIT 1";
					$result = $obj_db->consulta($consulta);
		                		if($result!=false){
                          			foreach($result as $fila){
                          				$fila['enombre']=$fila['enombre'];
         ?>
				<form action="index.php?command=reportes_promotor" method="POST" enctype="multipart/form-data" id="form-alta" role="form">
				
					<br />
					<div class="box box-primary">
						<div class="box-header"><h4>Datos personales</h4></div>

						<div class="box-body">
							<div class="col-md-10 col-sm-10 col-xs-10">
								<div class="form-group row">					
									<label class="col-md-2 col-sm-2 col-xs-2" style="">Nombre</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-user"></i></span>
											<div class="form-control"><?php echo $fila['user_nombre']." ".$fila['apellido_paterno']; ?></div>								
										</div>
									</div>
								</div>
								<div class="form-group row">	
									<label class="col-md-2 col-sm-2 col-xs-2" style="">Región</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-dot-circle-o"></i></span>
											<div class="form-control"><?php echo utf8_encode($fila['enombre']); ?></div>								
										</div>
									</div>
								</div>
								<div class="form-group row">	
									<label class="col-md-2 col-sm-2 col-xs-2" style="">Fecha</label>
									<div class="col-md-5 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
											<div class="form-control"><?php echo date('Y/m/d'); ?></div>								
										</div>
									</div>
								</div>
							</div>
							<div class="col-md-2 col-sm-2 col-xs-5">
								<div class="form-group row">
									<div id="marco-foto" style="top:0">
										<label class="" style="">Foto:</label>

										<div id="cont-image_preview" ><img src="uploads/usuarios/<?php echo $fila['user_foto']==''?'no-image.jpg':$fila['user_foto']; ?>" id="foto_preview"/></div>
										<div class="">
											<input name="Foto1" id="image-file" type="file" class="" >
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
					

					<div class="box box-primary">
						<div class="box-header"><h4>Datos de la Plaza</h4></div>
						<div class="box-body">
							<div class="col-md-6 col-sm-6 col-xs-6">
								<div class="form-group row">
		 							<label class="col-md-4 col-sm-4 col-xs-12">Tienda*</label>
	 								<div class="col-md-8 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-shopping-cart"></i></span>
											<select name="cacR" id="cacR" class="form-control">
			 									<option value="0">Selecciona...</option>
												<?php
												global $obj_db;
                        						$consulta = "SELECT id_cac, cac_name FROM cac ORDER BY cac_name ASC";
                        						$result = $obj_db->consulta($consulta);
                        						if($result!=false){
		                          					foreach($result as $fila){
                          								echo "<option class='' value ='".$fila['id_cac']."'>".$fila['cac_name']."</option>";
                          							}
                        						}
                        						?>
											</select>											
										</div>
						 			</div>
						 		</div>		
	 						</div>	
	 						<div class="col-md-6 col-sm-6 col-xs-12">
		 						<div class="form-group row">
									<label class="col-md-4 col-sm-4 col-xs-12">Estado</label>
									<input type="hidden" name="estado" id="estado" value="0">
									<div class="col-md-8 col-sm-8 col-xs-12">
										<div id="cont-estado" class="form-control">No disponible</div>
									</div>
	 							</div>
	 							<div class="form-group row">
		 							<label class="col-md-4 col-sm-4 col-xs-12">Ciudad</label>
	 								<input type="hidden" name="municipio" id="municipio" value="0">
	 								<div class="col-md-8 col-sm-8 col-xs-12">
										<div id="cont-municipio" class="form-control">No Disponible</div>
									</div>
	 							</div>
	 						</div>
						</div>	
					</div>

					<div class="box box-primary">
						<div class="box-header"><h4>Datos del Equipo</h4></div>
						<div class="box-body">							
							<div class="col-md-6 col-sm-6 col-xs-12">
								<div class="form-group row">	
									<label class="col-md-4 col-sm-4 col-xs-12">Gama*</label>
									<div class="col-md-8 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-tasks"></i></span>				
											<select name="gama" id="gama" class="form-control">
												<option value="0">Selecciona...</option>
												<?php
												global $obj_db;
                        						$consulta = "SELECT id_categoria, nombre_categoria FROM categorias ORDER BY id_categoria ASC";
                        						$result = $obj_db->consulta($consulta);
                        						if($result!=false){
		                          					foreach($result as $fila){
                          								echo "<option class='' value ='".$fila['id_categoria']."'>".$fila['nombre_categoria']."</option>";
                          							}
                        						}
                        						?>
											</select>								
										</div>
									</div>
								</div>				

								<div class="form-group row">
									<label class="col-md-4 col-sm-4 col-xs-12" style="">Equipo*</label>
									<div class="col-md-8 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-archive"></i></span>
											<select name="equipo" id="equipo" class="form-control">
												<option value="0">Selecciona...</option>
												<?php
												global $obj_db;
                        						$consulta = "SELECT id_producto, producto_name FROM producto ORDER BY producto_name ASC";
                        						$result = $obj_db->consulta($consulta);
                        						if($result!=false){
			                          				foreach($result as $fila){
                          								echo "<option class='text-danger text-center' value ='".$fila['id_producto']."'>".$fila['producto_name']."</option>";
                          							}
                        						}
                        						?>
											</select>								
										</div>
									</div>
								</div>
							</div>

							<div class="col-md-6 col-sm-6 col-xs-12">
								<div class="form-group row">
									<label class="col-md-4 col-sm-4 col-xs-12" style="">IMEI</label>
									<div class="col-md-8 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-barcode"></i></span>
											<input name="imei" type="text" class="form-control">								
										</div>
									</div>
								</div>
								<div class="form-group row">
									<label class="col-md-4 col-sm-4 col-xs-12">Venta directa</label>
									<div class="col-md-8 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-user"></i></span>
											<select name="venta-directa" class="form-control">
												<option>N/A</option>
												<option>Si</option>
												<option>No</option>
											</select>								
										</div>
									</div>
								</div>
							</div>
						</div>	
					</div>

					<div class="box box-primary">
						<div class="box-header"><h4>Datos de ventas</h4></div>
						<div class="box-body">								
							<div class="col-md-6 col-sm-6 col-xs-12">
								<div class="form-group row">
									<label class="col-md-3 col-sm-3 col-xs-3">Inventario Inicial*</label>
									<div class="col-md-8 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-bar-chart-o"></i></span>
											<input name="inventario-inicial" id="inventario-inicial" type="text" class="form-control">
										</div>
									</div>
								</div>
								<div class="form-group row">	
									<label class="col-md-3 col-sm-3 col-xs-3">Ventas*</label>
									<div class="col-md-8 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-truck"></i></span>
											<input name="ventas" id="ventas" type="text" class="form-control">
										</div>
									</div>
								</div>							
							</div>
							<div class="col-md-6 col-sm-6 col-xs-12">
								<div class="form-group row">
									<label class="col-md-3 col-sm-3 col-xs-3">Canal de Ventas</label>
									<input name="canal" type="hidden" value="HTC VDM">
									<div class="col-md-8 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-star"></i></span>
											<div class="form-control">HTC VDM</div>
										</div>
									</div>
							</div>	
								<div class="form-group row">
									<label class="col-md-3 col-sm-3 col-xs-3">Servicio</label>
									<div class="col-md-8 col-sm-8 col-xs-12">
										<div class="input-group">
											<span class="input-group-addon"><i class="fa fa-cogs"></i></span>							
											<select id="servicio" name="servicio" class="form-control">
												<option value='0'>N/A</option>
												<option value='1'>Renta</option>
												<option value='2'>Amigo Kit</option>
											</select>
										</div>
									</div>
								</div>
							</div>
						</div>						
					</div>
					
					
					<div class="">
						<button type="submit" value="Guardar" name="btn_enviar_reporte" id="btn_enviar_reporte"  class="btn btn-primary">Guardar</button>
						<button type="submit" value="Cancelar" name="btn_cancelar_reportes" id="btn_cancelar_reportes" class="btn btn-primary">Cancelar</button>
					</div>

					
					<br />
				

				</form>
			<?php
									}
								}
			?>
			</section>
		</div>
		<?php require "views/promotor/mensaje.php" ?>
		<?php require "views/promotor/footer_promotor.php" ?>	
	</div>
</div>

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