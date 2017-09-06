<?php
define("HOME","home");
define("LOGIN","login");
define("DIRECTIVO","directivo");
define("ALTA_DIRECTIVO","alta_directivo");
define("ALTA_AUDITOR","alta_auditor");
define("AUDITOR","auditor");
define("PROMOTOR","promotor");

$arre=array();

$arre=array("home"=>array("view"=>"views/home/index.php",
		  "css"=>array(
		  			  "css/bootstrap.css"
		  			  ),
		  "js"=>array(
		  			  "js/funciones.js"
		  			 )),
	    "directivo"=>array("view"=>"views/directivos/index.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
		"alta_directivo"=>array("view"=>"views/directivos/alta_directivo.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
		"perfil_directivo"=>array("view"=>"views/directivos/perfil_directivo.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
		"modificar_directivo"=>array("view"=>"views/directivos/modificar_directivo.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),  		    
	    "alta_cac"=>array("view"=>"views/directivos/alta_cac.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "perfil_cac"=>array("view"=>"views/directivos/perfil_cac.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
		"modificar_cac"=>array("view"=>"views/directivos/modificar_cac.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "alta_producto"=>array("view"=>"views/directivos/alta_producto.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "perfil_producto"=>array("view"=>"views/directivos/perfil_producto.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "modificar_producto"=>array("view"=>"views/directivos/modificar_producto.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),		  	    
	    "ventas"=>array("view"=>"views/directivos/ventas.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "ventas2"=>array("view"=>"views/directivos/ventas2.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),	   
	    "fotos"=>array("view"=>"views/directivos/fotos.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "form_extras"=>array("view"=>"views/directivos/form_extras.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	   	"agregar_formulario"=>array("view"=>"views/directivos/agregar_formulario.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	   	"editar_formulario"=>array("view"=>"views/directivos/editar_formulario.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	   	"respuestas_cuestionarios"=>array("view"=>"views/directivos/respuestas_cuestionarios.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),	   	
	    "directivos_imprimir_ventas"=>array("view"=>"views/directivos/imprimir_ventas.php"),
	    "imprimir_perfil_usuario"=>array("view"=>"views/directivos/imprimir_perfil_usuario.php"),
	    "imprimir"=>array("view"=>"views/directivos/imprimir.php"),
	    "salir"=>array("view"=>"views/logout/index.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),



	    "auditor"=>array("view"=>"views/auditor/index.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "perfil_auditor_usuarios"=>array("view"=>"views/auditor/perfil_usuario.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "perfil_auditor_cac"=>array("view"=>"views/auditor/perfil_cac.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "perfil_auditor_producto"=>array("view"=>"views/auditor/perfil_producto.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "ventas_auditor"=>array("view"=>"views/auditor/ventas.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "fotos_auditor"=>array("view"=>"views/auditor/fotos.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	   	"cuestionarios_auditor"=>array("view"=>"views/auditor/respuestas_cuestionarios.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "directivos_imprimir_ventasA"=>array("view"=>"views/auditor/imprimir_ventas.php"),
	    "imprimir_perfil_usuarioA"=>array("view"=>"views/auditor/imprimir_perfil_usuario.php"),
	    "imprimir_auditor"=>array("view"=>"views/auditor/imprimir.php"),

	    "promotor"=>array("view"=>"views/promotor/index.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "fotos_promotor"=>array("view"=>"views/promotor/fotos_promotor.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "reportes_promotor"=>array("view"=>"views/promotor/reportes_promotor.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "fotos_promotor"=>array("view"=>"views/promotor/fotos_promotor.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "producto_promotor"=>array("view"=>"views/promotor/perfil_producto.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 )),
	    "contestar_formulario"=>array("view"=>"views/promotor/contestar_formulario.php",
		  "css"=>array(
		  			  "css/estilos_ep.css",
		  			  "js/datepicker/jquery.datetimepicker.css"
		  			  ),
		  "js"=>array(
		  			  "js/jquery-1.9.0.js",
		  			  "js/jsapi.js",
		  			  "js/jsgraficas.js",
		  			  "js/jsimprimir.js",
		  			  "js/datepicker/jquery.js",
		  			  "js/datepicker/jquery.datetimepicker.js",
		  			  "js/bootstrap-tooltip.js"
		  			 ))
);

define("DIR_IMAGES","images/");
?>