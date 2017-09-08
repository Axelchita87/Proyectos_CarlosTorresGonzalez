<?php
require_once 'class/class.altaReporte.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='promotor'){
?>

<body class="skin-blue sidebar-mini">

	<style type="text/css">
        .scanner-laser{
            position: absolute;
            margin: 40px;
            height: 30px;
            width: 30px;
        }
        .laser-leftTop{
            top: 0;
            left: 0;
            border-top: solid red 5px;
            border-left: solid red 5px;
        }
        .laser-leftBottom{
            bottom: 0;
            left: 0;
            border-bottom: solid red 5px;
            border-left: solid red 5px;
        }
        .laser-rightTop{
            top: 0;
            right: 0;
            border-top: solid red 5px;
            border-right: solid red 5px;
        }
        .laser-rightBottom{
            bottom: 0;
            right: 0;
            border-bottom: solid red 5px;
            border-right: solid red 5px;
        }
        #QR-Code{
        	width:150px; 
        	height:150px; 
        	position:fixed;
        	bottom:10px;
        	right:10px;
        	padding:0;
        	z-index: 1000;
        	margin-right: 50px;
        	margin-bottom: 10px;
        }

        #QR-Code .panel-primary{
        	width:200px;
        	height:160px;
        }

        #QR-Code .panel-body{
        	padding:0;
        }

        </style>

	<script>


	$(function(){

          //recuperar datos 
      r_datos = function(options){

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

		
      	//Validar los campos obligatorios
		 $("#btn_guardar_reportes").on('click',function() {
            var tr_array = $("#registros tbody").children("tr")
            var error = 0;

                if(tr_array<=0){
                    alert("No has cargado ningún producto");
                    return true
                }

                if (confirm("Estas a puto de enviar un informe, \nestas seguro de querer enviarlo?")) {
                    
                    tr_array.each(function(index){

                        var equipo      = $(this).attr('id').replace('tr_','');
                        var cantidad    = $(this).children('.cantidad_inventario').html();
                        var precio_total = $(this).children('.td_precio_total').html();

                        reporte = r_datos({funcion:'guardar_reporte', grupo:123456789, equipo:equipo, cantidad:cantidad, precio_total:precio_total,datos_cac:''});
                        reporte_parse = JSON.parse(reporte);
                        error += reporte_parse['error'];
                        console.log(reporte_parse['error']);

                    })

                    if (error>0){
                        alert("ubo un error al cargar alguno de los archivos");
                        document.location.href="index.php?command=reportes_promotor";
                    }else{
                        alert("Las ventas se cargaron exitosamente");
                        document.location.href="index.php?command=reportes_promotor";
                    }

                    //r_datos({funcion:'guardar_reporte'});
					
					return true;
				} else{

					if($("#modal1").is(':hidden')){
						$("#modal1").toggle();
		 				return false;
					}else{
						return true;
					}						
				}
			
		});


		 

        $("#registros").dataTable({
       		"paging":   false,
       		"ordering": false,
       		"info":     false
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

					
				
					<br />
					<div class="box box-primary">
						<div class="box-header">
							<h4 style="float:left;">Escaner</h4>
							<div style="width:50%;float:right;margin-top: 5px;margin-bottom: 5px;text-align: right;">
		                    	<select id="cameraId" class="form-control" style="display: inline-block;width: auto;"></select>
                    			<button id="save" data-toggle="tooltip" title="Capturar Imagen" type="button" class="btn btn-primary btn-sm disabled"><span class="glyphicon glyphicon-picture"></span></button>
                    			<button id="play" data-toggle="tooltip" title="Escanear" type="button" class="btn btn-primary btn-sm"><span class="glyphicon glyphicon-play"></span></button>
                    			<button id="stop" data-toggle="tooltip" title="Detener" type="button" class="btn btn-primary btn-sm"><span class="glyphicon glyphicon-stop"></span></button>
                    			<button id="stopAll" data-toggle="tooltip" title="Detener Cámara" type="button" class="btn btn-primary btn-sm"><span class="glyphicon glyphicon-stop"></span></button>
                			</div>
                		</div>

						<div class="box-body">
                            <div>
							     <div class="col-md-12 col-sm-12 col-xs-12">
								    <table id="registros" class="table table-bordered table-hover">
                          				<thead>
			                        	    <th>Producto</th>
			                        	    <th>Cantidad</th>
			                        	    <th>Precio p/u</th>
			                        	    <th>Precio Total</th>
			                        	    <th>&nbsp;</th>
                      				    </thead>
                          				<tbody class="empty">
                        
                      	     			</tbody>
                    		            </table>  								
							     </div>
                            </div>							
						</div>

                        <div class="box-footer">
                            <div class="col-md-3 col-sm-3 col-xs-12 pull-right">
                                <div class="form-group row">    
                                    <label class="col-md-4 col-sm-4 col-xs-12">Total</label>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i>$</i></span>              
                                            <div name="sumaPrecioTotal" id="sumaPrecioTotal" class="form-control"></div>
                                        </div>
                                    </div>                          
                                </div>
                            </div>
                        </div>
					</div>
					

					<div class="">
						<button type="submit" value="Guardar" name="btn_guardar_reportes" id="btn_guardar_reportes"  class="btn btn-primary">Guardar</button>
						<button type="submit" value="Cancelar" name="btn_cancelar_reportes" id="btn_cancelar_reportes" class="btn btn-primary">Cancelar</button>
					</div>

					
					<br />
				

			

			</section>
		</div>




						<div id="QR-Code" class="container" >
            				<div class="panel panel-primary">
                				<div class="panel-body">
	                				<div style="text-align: center;">
                    					<div class="well" style="position: relative;display: inline-block;">
	                        				<canvas id="qr-canvas" width="150" height="112.5"></canvas>
                        					<div class="scanner-laser laser-rightBottom" style="opacity: 0.5;"></div>
                        					<div class="scanner-laser laser-rightTop" style="opacity: 0.5;"></div>
                        					<div class="scanner-laser laser-leftBottom" style="opacity: 0.5;"></div>
                        					<div class="scanner-laser laser-leftTop" style="opacity: 0.5;"></div>
                    					</div>
                    					<div class="well" style="position: relative;display:none;" >
	                        				<label id="zoom-value" width="100">Zoom: 2</label>
                        					<input type="range" id="zoom" value="20" min="10" max="30" onchange="Page.changeZoom();"/>
                        					<label id="brightness-value" width="100">Brightness: 0</label>
                        					<input type="range" id="brightness" value="0" min="0" max="128" onchange="Page.changeBrightness();"/>
	                        				<label id="contrast-value" width="100">Contrast: 0</label>
                        					<input type="range" id="contrast" value="0" min="0" max="64" onchange="Page.changeContrast();"/>
                        					<label id="threshold-value" width="100">Threshold: 0</label>
                        					<input type="range" id="threshold" value="0" min="0" max="512" onchange="Page.changeThreshold();"/>
                        					<label id="sharpness-value" width="100">Sharpness: off</label>
                        					<input type="checkbox" id="sharpness" onchange="Page.changeSharpness();"/>
                        					<label id="grayscale-value" width="100">grayscale: off</label>
                        					<input type="checkbox" id="grayscale" onchange="Page.changeGrayscale();"/>
                    					</div>
                					</div>
                					<div class="col-md-6" style="text-align: center;display:none">
	                    				<div id="result" class="thumbnail">
                        					<div class="well" style="position: relative;display: inline-block;">
	                            				<img id="scanned-img" src="" width="320" height="240">
                        					</div>
                        					<div class="caption">
	                            				<h3>Scanned result</h3>
                           						<p id="scanned-QR"></p>
                        					</div>
                    					</div>
                					</div>
            					</div>
        					</div>
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