<?php
require_once 'class.db.php';

    class clDatos{

    	function aliasAndValor($cadena, $seccion){
			global $obj_db;
			$s=array();

			$cadena = str_replace('form_ext_', '', $cadena);

			$a_json = json_decode('['.$cadena.']');

			//Rellenar todos los alias
			$consulta = "SELECT f_alias
	    	    	     FROM form_extra
	    	    		 WHERE id_seccion = ".$seccion;

	    	$result = $obj_db->consulta($consulta);    	
	    	if($result!=false){
				foreach($result as $fila){
					$s[$fila['f_alias']] = '';
				}
			}
			
			//Buscamos el alias que corresponde a cada id y agregamos su valor
			foreach( $a_json as $name) {
	    	    foreach( $name as $value1 => $value ) {

	    	    	$consulta = "SELECT f_alias
	    	    			   	 FROM form_extra
	    	    			   	 WHERE id_form = ".$value1."
	    	    			     LIMIT 1";
	    	    	
	    	    			   
	    	    	$result = $obj_db->consulta($consulta);
					if($result!=false){
						foreach($result as $fila){
							$s[$fila['f_alias']] = $value;
							//print_r($s);
						}
					}

	    	 		
	    	    }
	    	}
			return $s;
		}

        function get_foto_usuario($id_usuario){
            global $obj_db;

            $consulta = "SELECT user_foto
                     FROM usuario
                     WHERE id_usuario=$id_usuario
                     LIMIT 1";

            $result = $obj_db->consulta($consulta);
            if($result!=false){
                foreach($result as $fila){
                    $r = $fila['user_foto'];
                }
            }else{
                $r = '';
            }
            echo $r;exit;
        }

        function get_dash_ventas1(){
            global $obj_db;

            $consulta = "SELECT SUM(n_ventas) AS n_ventas
                     FROM ventas                      
                     WHERE fecha>=".date("Ym")."01 AND fecha<=".date("Ymd");

            $result = $obj_db->consulta($consulta);
            if($result!=false){
                foreach($result as $fila){
                    $r = $fila['n_ventas'];
                }
            }else{
                $r = '';
            }
            echo $r;exit;
        }

        function get_total_vendedores(){
            global $obj_db;

            $consulta = "SELECT id_usuario
                     FROM usuario
                     WHERE id_right=3 AND user_activo=1";

            $result = $obj_db->consulta($consulta);
            if($result!=false){
                    $r = count($result);
            }else{
                $r = '';
            }
            echo $r;exit;
        }

        function get_total_productos(){
            global $obj_db;

            $consulta = "SELECT id_producto
                     FROM producto";

            $result = $obj_db->consulta($consulta);
            if($result!=false){
                    $r = count($result);
            }else{
                $r = '';
            }
            echo $r;exit;
        }

        function get_dash_meta_mensual(){
            global $obj_db;
			//Cabeceras
				$this->intervalos[0] = array('Tienda','Región',
													  'Cuota Mes M8','Ventas M8','RestaM8',
													  'Cuota Mes Desire 510','Ventas Desire 510','Resta Desire 510',
													  'Cuota Mes Desire 320','Ventas Desire 320','Resta Desire 320',
													  'Cuota Mes Otros','Ventas Otros','Resta Otros');
				//echo json_encode($this->intervalos);exit;
			
			//Datos
			$consulta = "SELECT ventas.id_ventas, ventas.fecha, ventas.id_producto, producto.producto_name, ventas.id_usuario, usuario.user_name, ventas.imei, ventas.id_servicio, cac.cac_name, municipios.nombre AS cmunicipio, ventas.inventarioi, ventas.n_ventas, ventas.total, cac.anexo2 AS cac_anexo2, 
			SUM(CASE WHEN producto.id_producto='3' THEN ventas.n_ventas ELSE 0 END) AS v_m8,
			SUM(CASE WHEN producto.id_producto='32' THEN ventas.n_ventas ELSE 0 END) AS v_d510,
			SUM(CASE WHEN producto.id_producto='33' THEN ventas.n_ventas ELSE 0 END) AS v_d320,
			SUM(CASE WHEN producto.id_producto!='3' AND producto.id_producto!='32' AND producto.id_producto!='33' THEN ventas.n_ventas ELSE 0 END) AS v_o
					 	 FROM ventas
					 	 LEFT JOIN usuario
					 			 ON ventas.id_usuario=usuario.id_usuario
					 	 LEFT JOIN producto
					 			 ON ventas.id_producto=producto.id_producto 
					 	 LEFT JOIN municipios
					 			 ON ventas.id_municipio=municipios.id_municipio 
					 	 LEFT JOIN cac
					 			 ON ventas.id_cac=cac.id_cac 
					 	 WHERE fecha>".date("Ym")."01 AND fecha<".date("Ymd")."  	
						 GROUP BY cac_name ASC 				 
					 	 ORDER BY ventas.fecha ASC";

					 	 //echo json_encode($consulta);exit;

		 	$result = $obj_db->consulta($consulta);
			if($result!=false){
				foreach($result as $fila){
					

					//Campos extras
					$cac_ce=$this->aliasAndValor($fila['cac_anexo2'], '2');
					
					
					$resta_m8 = $cac_ce['cuota_mes_m8']!=''?($cac_ce['cuota_mes_m8']-$fila['v_m8']):'';
					$resta_d510 = $cac_ce['cuota_mes_desire510']!=''?($cac_ce['cuota_mes_desire510']-$fila['v_d510']):'';
					$resta_d320 = $cac_ce['cuota_mes_desire320']!=''?($cac_ce['cuota_mes_desire320']-$fila['v_d320']):'';
					$resta_o = $cac_ce['cuota_mes_otros']!=''?$cac_ce['cuota_mes_otros']-$fila['v_o']:'';
					
					$ventas_m8 = $cac_ce['cuota_mes_m8']!=''?$fila['v_m8']:'';
					$ventas_d510 = $cac_ce['cuota_mes_desire510']!=''?$fila['v_d510']:'';
					$ventas_d320 = $cac_ce['cuota_mes_desire320']!=''?$fila['v_d320']:'';
					$ventas_o = $cac_ce['cuota_mes_otros']!=''?$fila['v_o']:'';

					$meta_mes_m8 = $cac_ce['cuota_mes_m8']==''||$cac_ce['cuota_mes_m8']==0?0:(100/$cac_ce['cuota_mes_m8'])*$ventas_m8;
					$meta_mes_d510 = $cac_ce['cuota_mes_desire510']==''||$cac_ce['cuota_mes_desire510']==0?0:(100/$cac_ce['cuota_mes_desire510'])*$ventas_d510;
					$meta_mes_d320 = $cac_ce['cuota_mes_desire320']==''||$cac_ce['cuota_mes_desire320']==0?0:(100/$cac_ce['cuota_mes_desire320'])*$ventas_d320;

					if($cac_ce['cuota_mes_m8']!='' AND $cac_ce['cuota_mes_desire510']!='' AND $cac_ce['cuota_mes_desire320']!='' ){
						$meta_mes = ($meta_mes_m8+$meta_mes_d510+$meta_mes_d320)/3;
						$r_aux[]=$meta_mes;
					}
				
				}

				$r=0;

        if (count($r_aux)>0){
				  foreach($r_aux as $value) {
  					$r+=$value/count($r_aux);
				  }
        }else{
          $r=0;
        }

			}else{
				$r=0;
			}

			$r = round($r, 2);
			
			echo $r;exit;
        }

        function get_ventas_mes6(){
            global $obj_db;

            $consulta = "SELECT SUM(n_ventas) AS n_ventas, MONTH(fecha)
                     FROM ventas
                     WHERE fecha>".date('Ymd', strtotime('-5 month'))." AND fecha<".date("Ymd")." 
                     GROUP BY MONTH(fecha)";

                     //echo json_encode($consulta);exit;

            $result = $obj_db->consulta($consulta);
            if($result!=false){  

            	$sig_mes=0;         	

                for ($i=-5; $i < 1; $i++) { 
                  $sig_mes = $sig_mes==1?2:date('n', strtotime(''.$i.' month'));

                  //Inicializa las variables en 0;
                  $r['mes'][] = +$sig_mes;  
                  $r['valor'][] = 0; 

                  foreach($result AS $key){                   

                    if ($key['MONTH(fecha)']==$sig_mes){
                      //print_r($key['MONTH(fecha)']."==".$sig_mes);
                        $r['valor'][count($r['valor'])-1] = +$key['n_ventas'];                                                
                      }
                  }

                }
            }else{
                $r = '';
            }


            echo json_encode($r);exit;
        }

        function get_productos_chart_dash(){
            global $obj_db;

            $consulta = "SELECT SUM(ventas.n_ventas) AS n_ventas, producto.producto_name 
                     FROM ventas 
                     INNER JOIN producto ON ventas.id_producto=producto.id_producto 
                     WHERE fecha>".date("Ym")."01 AND fecha<".date("Ymd")." 
                     GROUP BY producto_name ASC";

                     //echo json_encode($consulta);exit;

            $result = $obj_db->consulta($consulta);
            if($result!=false){           	
                	foreach($result AS $value){
                    		$r['valores'][] = +$value['n_ventas'];   
                    		$r['nombres'][] = $value['producto_name'];                  		
                	}
            }else{
                $r['valores'][] = 0;   
                $r['nombres'][] = '';
            }


            echo json_encode($r);exit;
        }

        function get_productos_resumen_dash(){
            global $obj_db;
            $r = '';

            $consulta = "SELECT id_producto, producto_name, producto_descrip, producto_foto, producto_precio
                     FROM producto 
                     ORDER BY id_producto DESC
                     LIMIT 4";

                     //echo json_encode($consulta);exit;

            $result = $obj_db->consulta($consulta);
            if($result!=false){           	
                	foreach($result AS $value){

                			$r   .='<li class="item">'.
                      					'<div class="product-img">'.
                        					'<img src="uploads/productos/thumbs/'.$value['producto_foto'].'" alt="Product Image"/>'.
                      					'</div>'.
                      					'<div class="product-info">'.
                        					'<a href="javascript::;" class="product-title">'.$value['producto_name'].'<span class="label label-warning pull-right">$'.$value['producto_precio'].'</span></a>'.
                        					'<span class="product-description">'.
                          						$value['producto_descrip'].
                        					'</span>'.
                      					'</div>'.
                    				'</li><!-- /.item -->'.
                    				' ';
           		
                	}
            }else{
                $r = '';
            }


            echo $r;exit;
        }

        function get_usuarios_resumen_dash(){
            global $obj_db;
            $r = '';

            $consulta = "SELECT usuario.id_usuario, usuario.user_name, usuario.user_foto, SUM(ventas.n_ventas) AS n_ventas, ventas.fecha
                     FROM usuario 
                     LEFT JOIN ventas ON ventas.id_usuario=usuario.id_usuario 
                     WHERE id_right=3 AND user_activo=1 
                     GROUP BY id_usuario 
                     ORDER BY n_ventas DESC
                     LIMIT 8";

            /*$consulta = "SELECT usuario.id_usuario, usuario.user_name, usuario.user_foto, SUM(ventas.n_ventas) AS n_ventas, ventas.fecha
                     FROM usuario 
                     INNER JOIN ventas ON ventas.id_usuario=usuario.id_usuario 
                     WHERE fecha>".date("Ym")."01 AND fecha<".date("Ymd")." 
                     GROUP BY id_usuario 
                     ORDER BY n_ventas DESC
                     LIMIT 8";*/

                     //echo json_encode($consulta);exit;

            $result = $obj_db->consulta($consulta);
            if($result!=false){           	
                	foreach($result AS $value){

                			$r   .='<li>'.
                          				'<img src="uploads/usuarios/thumbs/'.$value['user_foto'].'" alt="User Image"/>'.
                          				'<a class="users-list-name" href="#">'.$value['user_name'].'</a>'.
                          				'<span class="users-list-date">'.$value['n_ventas'].'</span>'.
                        			'</li><!-- /.item -->'.
                    				' ';
           		
                	}
            }else{
                $r = '';
            }


            echo $r;exit;
        }
    
    }



if (isset($_POST['funcion'])){

    $datos = new clDatos();

	if($_POST['funcion'] =='get_foto_usuario'){
        $id_usuario = $_POST['id_usuario'];
        
		$datos->get_foto_usuario($id_usuario);
	}

    if($_POST['funcion'] =='get_dash_ventas1'){        
        $datos->get_dash_ventas1();
    }

    if($_POST['funcion'] =='get_total_vendedores'){        
        $datos->get_total_vendedores();
    }

    if($_POST['funcion'] =='get_total_productos'){        
         $datos->get_total_productos();
    }

    if($_POST['funcion'] =='get_dash_meta_mensual'){        
        $datos->get_dash_meta_mensual();
    }

    if($_POST['funcion'] =='get_ventas_mes6'){
    	$datos->get_ventas_mes6();
    }

    if($_POST['funcion'] =='get_productos_chart_dash'){
    	$datos->get_productos_chart_dash();
    }

    if($_POST['funcion'] =='get_productos_resumen_dash'){
    	$datos->get_productos_resumen_dash();
    }

    if($_POST['funcion'] =='get_usuarios_resumen_dash'){
    	$datos->get_usuarios_resumen_dash();
    }

}


?>