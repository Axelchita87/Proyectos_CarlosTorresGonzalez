<?php
require_once 'class/class.campanaSigma.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){
?>

 <body class="skin-blue sidebar-mini">

<style>
#image-file{
	display:none;
}

.input-group-addon{min-width: 40px;}

</style>	

<script>
$(function(){//Funciones para validar fotografía


		//recuperar datos	
	  r_datos = function(options){

          options=(options==typeof(undefined))?'':options;
          params=options;
        var datos = $.ajax({
          url:'class/class.campanaSigma.php',
    		  type:'post',
    		  dataType:'json',
          data:params,
    		  async:false    		
    	 }).responseText;
        return datos
      }


	  
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
					Campañas
				</h1>
				<ol class="breadcrumb">
            		<li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            		<li><a href="#">Alta de Tiendas</a></li>
          		</ol>
			</section>


			<div id="" class="">

		
			<form action="" method="POST" enctype="multipart/form-data" role="form" id="form-alta-campana">
				<br />
				<div class="box box-primary">
					<div class="box-header"><h4>Camaña</h4></div>
					<div class="box-body">
						<div class="col-md-6 col-sm-6 col-xs-12">
							<div class="form-group row">
								<label class="col-md-4 col-sm-4 col-xs-12" style="">Nombre*</label>
								<div class="col-md-8 col-sm-8 col-xs-12">
									<div class="input-group">
										<span class="input-group-addon"><i class="fa fa-shopping-cart"></i></span>
										<input class="form-control" name="nombre-campana" id="nombre-campana" type="text" placeholder="Nombre de la campaña">
									</div>
								</div>								
							</div>	
							<div class="form-group row">
								<label class="col-md-4 col-sm-4 col-xs-12" style="">Tiendas</label>
								<div class="col-md-8 col-sm-8 col-xs-12">
									<div class="input-group">
										<span class="input-group-addon"><i class="fa fa-shopping-cart"></i></span>
										<select class="form-control" name="select_tiendas" id="select_tiendas" multiple>
											<?php
												global $obj_db;
												$qry = "SELECT id_cac, cac_name 
														FROM cac ";
												$result = $obj_db->consulta($qry);
												if($result!=false){
									                 foreach($result as $fila){
											        	echo "<option value='".$fila['id_cac']."'>".$fila['cac_name']."</option>";
											        }
            									}
											?>

										</select>
									</div>
								</div>								
							</div>	
						</div>	
						<div class="col-md-6 col-sm-6 col-xs-12">
							<div class="form-group">
                        		<label class="col-md-4 col-sm-4 col-xs-12">Periodo:</label>
                        		<div class="col-md-8 col-sm-8 col-xs-12">
                        			<div  class="input-group">
                          				<div class="input-group-addon"><i class="fa fa-calendar"></i></div>
                          				<input type="text" class="form-control pull-right" id="range_campana" name="range-campana" />
                        			</div><!-- /.input group -->
                      			</div><!-- /.form group --> 					
                      		</div>
	 					</div>				
					</div>
				</div>


						<div class="">
							<button type="submit" value="Guardar" name="btn_enviar_alta_campana" class="btn btn-primary">Guardar</button>
							<button type="submit" value="Cancelar" name="btn_cancelar_alta_campana" class="btn btn-primary">Limpiar</button>
						</div>
 
					<br />

			</form>
			</div>

			<div>	
				<div class="box box-primary">
					<div class="box-header"><h4>Listado de Campañas</h4></div>

					<div class="box-body">
						<div class="col-md-12 col-sm-12 col-xs-12">
							<table id="example2" class="table table-bordered table-hover">
                    			<thead>
                      				<tr>
                        				<th>Campaña</th>
                        				<th>Fecha de Creación</th>
                        				<th>Periodo</th>
                        				<th>Opciones</th>                      					
                        			</tr>
                    			</thead>
                    			<tbody>
                    				<?php
                          				//Recupera la lista de productos y general las opciones de select
										$valores_campana = json_decode($datos->get_campanas());
										//print_r($valores_campana->campana);
										
										$count_id = count($valores_campana->campana);										

										for($i=0; $i<$count_id; $i++) {

											$value_id 			= isset($valores_campana->campana[$i]->id_campana) 			? $valores_campana->campana[$i]->id_campana 		: '';
											$value_nombre		= isset($valores_campana->campana[$i]->nombre_campana)		? $valores_campana->campana[$i]->nombre_campana		: '';
											$value_fecha		= isset($valores_campana->campana[$i]->fecha_creada)		? $valores_campana->campana[$i]->fecha_creada		: '';
											$value_periodo 		= isset($valores_campana->campana[$i]->periodo_campana)		? $valores_campana->campana[$i]->periodo_campana	: '';
											$value_eliminada 	= isset($valores_campana->campana[$i]->campana_eliminada)	? $valores_campana->campana[$i]->campana_eliminada	: '';

											$btn_ver = '<button '.
															'class="btn btn-primary pull-right" '.
															'data-original-title="Añadir Cuestionario" '.
															'title="" data-toggle="tooltip" '.
															'data-widget="Añadir '.
															'Cuestionario" '.
															"onclick=\"javascript:location='index.php?command=cuestionario1_directivo'\">";
											$btn_editar = '<button></button>';
											$btn_eliminar = '<button></button>';



                            				echo "<tr id='tr_prod_".$value_id."'>";
                        					echo "	<td>".$value_nombre."</td>";
                        					echo "	<td>".$value_fecha."</td>";
                        					echo "	<td>".$value_periodo."</td>";
                        					echo "	<td></td>";
                      						echo "</tr>";                            				
                      					}                          					
                        			?>                      					
                      			</tbody>
                      		</table>
						</div>							
					</div>
				</div>

			</div>

		</section>
	</div>
	<?php require "views/directivos/footer_directivo.php"; ?>
</div>

<script type="text/javascript">
      $(function () {
        $('#range_campana').daterangepicker("option", "dateFormat", "yy-mm-dd"); 
		$("#example2").dataTable({
        	"aaSorting": [[ 2, "desc" ]]
    	});     
      });
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