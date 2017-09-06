<?php
require_once 'class/class.formulariosPersonalizados.php';
//session_start();
if(isset($_SESSION['user']) && $_SESSION['permiso']=='promotor'){


//Funciones extras

	function replace_utf8($string){
		$string = preg_replace_callback('/u([0-9a-fA-F]{4})/', function ($match) {
			return mb_convert_encoding(pack('H*', $match[1]), 'UTF-8', 'UCS-2BE');
		}, $string);

		return $string;
	}

?>

<body class="skin-blue sidebar-mini">

	<style type="text/css">
		




	</style>

	<script LANGUAGE="JavaScript">
			

	$(function(){//Funciones para validar fotografía
	  //Oculta contenedor	
	    contenedor = $('#foto_preview'); 
		contenedor.hide();	


	  //recuperar datos	
	  r_datos = function(options){

          options=(options==typeof(undefined))?'':options;
          params=options;
        var datos = $.ajax({
          url:'class/class.formulariosPersonalizados.php',
    		  type:'post',
    		  dataType:'json',
          data:params,
    		  async:false    		
    	 }).responseText;
        return datos
      }
		 

		//Validar los campos obligatorios
		 $("#form-alta").submit(function() {

			if (confirm("Estas a pundo de enviar un cuestionario.\nDeseas continuar?")) {
				return true;
			} else
				return false;
		});



	})
			
						
		</script>

    <!-- Site wrapper -->
    <div class="wrapper">

      	<?php require "views/promotor/header_promotor.php"; ?>
      	<?php require "views/promotor/menu_vertical.php"; ?>
        <!-- Content Wrapper. Contains page content -->
      	<div class="content-wrapper">


			<section class="content-header">
          		<h1>
		            Cuestionarios
            		<small>Cuestionarios</small>
          		</h1>
          		<ol class="breadcrumb">
		            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            		<li><a href="#">Cuestionarios</a></li>
          		</ol>
       		</section>

			<section id="" class="container">

				<form action="index.php?command=contestar_formulario&formulario=<?php echo $_GET['formulario'] ?>" method="POST" enctype="multipart/form-data" style="width:100%" id="form-alta" role="form">
				
					<br />
						
						<?php
							global $obj_db;
                    		$consulta3 = "SELECT f_default, f_label  FROM form_extra WHERE id_form=".str_replace('p_f_', '', $_GET['formulario'])." ORDER BY f_alias ASC";
                        	$result3 = $obj_db->consulta($consulta3);
                       		if($result3!=false){
                       			foreach($result3 as $fila3){
                    	?>
                    <div class="box box-primary">
						<div class="box-header"><h4>Formulario <?php echo  $fila3['f_label']; ?></h4></div>
						<div class="box-body">	
							<div class="col-md-12 col-sm-12 col-xs-12">
								<input id="id_form" name="id_form" type="hidden" value="<?php echo str_replace('p_f_', '', $_GET['formulario']); ?>">
						<?php
		                    	

		                    		//decodificar json
				
									$preguntas = json_decode("[".$fila3['f_default']."]");

									if (count($preguntas)>0){
										$i = -1;
										foreach ($preguntas as $p) {

											$i++;
						?>
										<div class="form-group row">
											<div class="col-md-11 col-sm-11" >
												<label class="col-md-4 col-sm-4 col-xs-2"><?php echo replace_utf8($p->l); ?></label>
												<div class="col-md-5 col-sm-8 col-xs-12">
													<input class="form-control" id="<?php echo "p_".$i; ?>" name="<?php echo "p_".$i; ?>" placeholder="<?php echo replace_utf8($p->d); ?>" type="campo">
												</div>
											</div>	
										</div>	
                		<?php
                						}
            						}



		            	?>
                         		
                         			
                   		<?php
                   				}
                    	?>
	                   		</div>
						</div>
					</div>
                   		<?php		
	                   	   	}
                    	?>	
					
					<hr>
					<div class="">
						<button type="submit" value="Guardar" name="btn_alta" class="btn btn-primary">Guardar</button>
					</div>

					<br />
				

				</form>
			</section>
		</div>
		<?php require "views/promotor/footer_promotor.php" ?>
		
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
