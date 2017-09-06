<?php

require_once 'class.db.php';

/**************************
	Errores

1 	Existe el producto
***************************/

    class clBarcodeReportes{

    	function get_producto_reporte($code){
			global $obj_db;
      		//$s = [];
			
			//Rellenar todos los alias
			$consulta = "SELECT producto.id_producto, inventario.codigo, producto.producto_name, producto.producto_precio
	    	    	       FROM inventario
                      LEFT JOIN producto
                             ON producto.id_producto = inventario.id_producto
	    	    		  WHERE codigo = ".$code." 
	    	    	   	  LIMIT 1";

	    	$result = $obj_db->consulta($consulta);    	
	    	if($result!=false){
				foreach($result as $fila){
					$s['id_producto'][]	 = $fila['id_producto'];
					$s['codigo'][] 		 = $fila['codigo']==''?'n/d':$fila['codigo'];
					$s['nombre'][] 		 = $fila['producto_name']==''?'n/d':$fila['producto_name'];	
					$s['precio'][] 		 = $fila['producto_precio']==''?'n/d':$fila['producto_precio'];					
				}
				$s['error'] = false;

			}else{
					$s['id_producto'][]  = "";
					$s['codigo'][] 		 = "";
					$s['nombre'][] 		 = "";	
					$s['precio'][] 		 = "";
					$s['error'][] 		 = "1";				
			}
			
			echo json_encode($s);exit;
		}

		
    }



if(isset($_POST['funcion'])){

    $datos = new clBarcodeReportes();

	if($_POST['funcion'] =='get_producto_reporte'){
		$code = $_POST['code'];
 		$datos->get_producto_reporte($code);
	}else{
    	echo "";
  	}   

}


?>