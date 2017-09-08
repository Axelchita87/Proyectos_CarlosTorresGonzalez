<?php
require_once 'class.db.php';



/**************************
	Errores
1		No se encontraron productos
2       Código ya existe
3       Producto no existe
4       Producto no existe en inventario
5 		No se pudo agregar el producto a la venta

***************************/

    class clInventarios{

    	function lista_de_productos(){
			global $obj_db;
      		//$s = [];
			
			//Rellenar todos los alias
			$consulta = "SELECT producto.id_producto as id_p, producto.producto_name, inventario.id_producto, inventario.cantidad, inventario.codigo, inventario.fecha_ultimo_inventario
	    	    	       FROM producto
                      LEFT JOIN inventario
                             ON producto.id_producto = inventario.id_producto
	    	    		  WHERE 1
	    	    	   ORDER BY producto_name ASC";

	    	$result = $obj_db->consulta($consulta);    	
	    	if($result!=false){
				foreach($result as $fila){
					$s['id'][]			 = $fila['id_p'];
					$s['nombre'][] 		 = $fila['producto_name'];
					$s['cantidad'][] 	 = $fila['cantidad']==''?'0':$fila['cantidad'];
					$s['codigo'][] 		 = $fila['codigo']==''?'n/d':$fila['codigo'];
					$s['fecha'][]		 = $fila['fecha_ultimo_inventario']==''?'n/d':$fila['fecha_ultimo_inventario'];
				}
				$s['error'] = false;

			}else{
					$s['id'][] 			 = "";
					$s['nombre'][] 		 = "";
					$s['cantidad'][] 	 = "";
					$s['codigo'][] 		 = "";
					$s['fecha'][] 		 = "";
					$s['error'] = 1;
			}
			
			echo json_encode($s);exit;
		}

		/**********     FUNCIONES PARA CÓDIGO    ****************/

		//Validar si existe producto en Inventario

		function valida_prod_inv($id_producto){
			global $obj_db;

			// Validar si existe usuario
			$qry_user = "SELECT id_producto
	    	    	       FROM inventario                      
	    	    		  WHERE id_producto=".$id_producto;

	    	   
	    	   		
			$result_user = $obj_db->consulta($qry_user);

			if ($result_user!=false){
				return true;
			}else{
				return false;
			}
		}

		//Validar si existe producto en Productos

		function valida_prod_productos($id_producto){
			global $obj_db;

			// Validar si existe usuario
			$qry_user = "SELECT id_producto
	    	    	       FROM producto                      
	    	    		  WHERE id_producto=".$id_producto;
		
			$result_user = $obj_db->consulta($qry_user);

			if ($result_user!=false){
				return true;
			}else{
				return false;
			}
		}

		//Validar si existe codigo en otro producto en Inventario

		function valida_existe_codigo_prod($codigo,$id_producto){
			global $obj_db;

			// Validar si existe usuario
			$qry_code = "SELECT codigo
	    	    	       FROM inventario                      
	    	    		  WHERE codigo=".$codigo." AND (codigo=".$codigo." AND id_producto NOT IN (".$id_producto."))";
			
			$result_code = $obj_db->consulta($qry_code);

			if ($result_code!=false){
				return true;
			}else{
				return false;
			}
		}

		function crear_producto_inventario($id_producto){
			global $obj_db;

			$qry_insert = "INSERT INTO inventario (id_producto,cantidad,codigo,fecha_ultimo_inventario)
									 VALUES (".$id_producto.",0,0,'".date('Y-m-d')."')";
			//print_r($qry_insert);exit;
			$result_insert = $obj_db->tarea($qry_insert);
			
			if ($result_insert!=false){
				return true;
			}else{
				return false;
			}
		}

		function actualizar_codigo($str_codigo, $id_producto, $new_codigo){
			global $obj_db;	

			if($this->valida_prod_productos($id_producto)){

				if ($this->valida_prod_inv($id_producto)){	
					
	    			if(!$this->valida_existe_codigo_prod($new_codigo,$id_producto)){
			    		$qry="UPDATE inventario 
	    	    		 	 	SET codigo='".$new_codigo."' 
			  		   	   	WHERE id_producto	=".$id_producto;
			  			$result_qry = $obj_db->tarea($qry);
			  			if($result_qry!=false){
					  		$s['error'] = false;
			  			}else{
				  			$s['error'] = 4; // Producto no existe
						}
					}else{
						$s['error'] = 2; // Error ya existe ese código
					}
					
				}else{

					$s['error'] = 4; // Producto no existe

					if($this->crear_producto_inventario($id_producto)){
						$s['debug'][] = 'Producto creado en inventario';
						$this->actualizar_codigo($str_codigo, $id_producto, $new_codigo);					
					}

					

				};
			}else{

				$s['error'] = 3; // Producto no existe

			}

			echo json_encode($s);exit;
		}


		/*****************  FIN DE FUNCIONES PARA CÓDIGO         ***********************/



		function actualizar_inventario($id_producto, $new_inventario){
			
			global $obj_db;	

			if($this->valida_prod_productos($id_producto)){

				if ($this->valida_prod_inv($id_producto)){	
					
	    			$qry="UPDATE inventario 
	    	    	 	 	 SET cantidad='".$new_inventario."' 
			  		   	   WHERE id_producto	=".$id_producto;
			  		$result_qry = $obj_db->tarea($qry);
			  		if($result_qry!=false){
						$s['error'] = false;
			  		}else{
				  		$s['error'] = 4; // Producto no existe
					}
										
				}else{
					if($this->crear_producto_inventario($id_producto)){
						$s['debug'][] = 'Producto creado en inventario';
						$this->actualizar_inventario($id_producto, $new_inventario);					
					}
					$s['error'] = 4; // Producto no existe
				};
			}else{
				$s['error'] = 3; // Producto no existe
			}
			
			echo json_encode($s);exit;
		}

		function alta_venta($id_gupo_venta, $id_usuario, $id_producto, $cantidad, $precio_unidad){
			
			global $obj_db;	

	    			$qry="INSERT INTO ventas  ()
	    	    	 	 	 SET cantidad='".$new_inventario."' 
			  		   	   WHERE id_producto	=".$id_producto;
			  		$result_qry = $obj_db->tarea($qry);
			  		if($result_qry!=false){
						$s['error'] = false;
			  		}else{
				  		$s['error'] = 5; // No se pudo añadir la venta del producti
					}
										
			echo json_encode($s);exit;
		}
    
    }



if(isset($_POST['funcion'])){

    $datos = new clInventarios();

	if($_POST['funcion'] =='lista_de_productos'){
		$datos->lista_de_productos();
	}elseif($_POST['funcion'] =='actualizar_codigo'){
		$old_codigo = $_POST['old_value'];
		$id_producto = $_POST['id_producto'];
		$new_codigo = $_POST['new_value'];

		$datos->actualizar_codigo($old_codigo,$id_producto,$new_codigo);
	}elseif($_POST['funcion'] =='actualizar_inventario'){
		$id_producto = $_POST['id_producto'];
		$new_codigo = $_POST['new_value'];

		$datos->actualizar_inventario($id_producto,$new_codigo);
	}else{
    	echo "";
  	}   

}


?>