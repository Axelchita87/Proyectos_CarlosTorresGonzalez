<?php
require_once 'class/class.db.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){
?>

<body>

<!-- Add jQuery library -->
	<script type="text/javascript" src="js/lib/jquery-1.10.1.min.js"></script>

	<!-- Add mousewheel plugin (this is optional) -->
	<script type="text/javascript" src="js/lib/jquery.mousewheel-3.0.6.pack.js"></script>

	<!-- Add fancyBox main JS and CSS files -->
	<script type="text/javascript" src="js/source/jquery.fancybox.js?v=2.1.5"></script>
	<link rel="stylesheet" type="text/css" href="js/source/jquery.fancybox.css?v=2.1.5" media="screen" />

	<!-- Add Button helper (this is optional) -->
	<link rel="stylesheet" type="text/css" href="js/source/helpers/jquery.fancybox-buttons.css?v=1.0.5" />
	<script type="text/javascript" src="js/source/helpers/jquery.fancybox-buttons.js?v=1.0.5"></script>

	<!-- Add Thumbnail helper (this is optional) -->
	<link rel="stylesheet" type="text/css" href="js/source/helpers/jquery.fancybox-thumbs.css?v=1.0.7" />
	<script type="text/javascript" src="js/source/helpers/jquery.fancybox-thumbs.js?v=1.0.7"></script>

	<!-- Add Media helper (this is optional) -->
	<script type="text/javascript" src="js/source/helpers/jquery.fancybox-media.js?v=1.0.6"></script>

	<script type="text/javascript">
		$(document).ready(function() {
			
			$('.fancybox-thumbs').fancybox({
				prevEffect : 'none',
				nextEffect : 'none',

				closeBtn  : false,
				arrows    : false,
				nextClick : true,

				helpers : {
					thumbs : {
						width  : 50,
						height : 50
					}
				}
			});

			//recuperar datos	
	  		r_datos = function(options){

	        options=(options==typeof(undefined))?'':options;
    	    params=options;
        	var datos = $.ajax({
          			url:'class/funcionesFotos.php',
    		  		type:'post',
    		  		dataType:'json',
          			data:params,
    		  		async:false    		
    	 		}).responseText;
        	return datos
      		}

			$('#promotor_fotos').on('change',function(){
				var a=$('#promotor_fotos').val();
				var b=$('#cac_fotos').val();
				var c=$('#fotos_clasificacion').val();
				var valores = r_datos({'get_foto_usuario':a,'get_foto_cac':b,'get_foto_clasificacion':c})

				v_valores= JSON.parse(valores)
				$('#contenedor-galeria').html(v_valores[0]);
			})

			$('#cac_fotos').on('change',function(){
				var a=$('#promotor_fotos').val();
				var b=$('#cac_fotos').val();
				var c=$('#fotos_clasificacion').val();
				var valores = r_datos({'get_foto_usuario':a,'get_foto_cac':b,'get_foto_clasificacion':c});

				v_valores = JSON.parse(valores)
				$('#contenedor-galeria').html(v_valores[0]);
			})
			
			$('#fotos_clasificacion').on('change',function(){
				var a=$('#promotor_fotos').val();
				var b=$('#cac_fotos').val();
				var c=$('#fotos_clasificacion').val();
				var valores = r_datos({'get_foto_usuario':a,'get_foto_cac':b,'get_foto_clasificacion':c});

				v_valores = JSON.parse(valores)
				$('#contenedor-galeria').html(v_valores[0]);
			})

			function ini(){
				var valores = r_datos({'get_foto_usuario':'0','get_foto_cac':'0','get_foto_clasificacion':'0'});

				v_valores = JSON.parse(valores)
				$('#contenedor-galeria').html(v_valores[0]);	
			}

			ini();

			
		});
	</script>


		
<div border="0" class="table-responsive">
	<?php require "views/directivos/menu_vertical.php" ?>

	<div id="contenido">
		<?php require "views/directivos/header_directivo.php" ?>		
		<div id="contenedor">
			

			<h3  id="titulo">Galería Tiendas</h3>
				<div id="contenedor-galeria">
					
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