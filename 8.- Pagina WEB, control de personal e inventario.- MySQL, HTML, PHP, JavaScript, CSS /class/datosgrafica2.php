<?php
	
	require_once '../class/class.db.php';
	

	class clGraficas{

		private $consulta;
		private $tipo_categoria='id_usuario';

		//public $filtro = "WHERE ventas.fecha>='20141016' and ventas.fecha<='20141020'";
		public $filtro = "WHERE '1'='1'";
		public $type_tabla='';
		public $intervalos = array('FECHA');
		public $f_fecha = "d";
		public $fechas = array();

		public function f_filtro($x,$v){
			if ($x=='fecha_i'&&$_POST['fecha_f']==''&&$v!=''){$this->filtro .= ' and ventas.fecha="'.$v.'"';}
			if ($x=='fecha_f'&&$_POST['fecha_i']!=''&&$v!=''){$this->filtro .= ' and ventas.fecha>="'.str_replace("/", "", $_POST['fecha_i']).'" and ventas.fecha<="'.$v.'"';}
			if ($x=='promotor'&&$v!=0){$this->filtro .= ' and ventas.id_usuario='.$v;}
			if ($x=='cac'&&$v!=0){$this->filtro .= ' and ventas.id_cac='.$v;}
			if ($x=='producto'&&$v!=0){$this->filtro .= ' and ventas.id_usuario='.$v;}
			if ($x=='estado'&&$v!=0){$this->filtro .= ' and ventas.id_estado='.$v;}
			if ($x=='municipio'&&$v!=0){$this->filtro .= ' and ventas.id_usuario='.$v;}
			
			return $this->filtro;
		}

		public function formato_fecha($dato_fecha, $formato){
			$o_fecha = new DateTime($dato_fecha);
			if ($formato!=''){return $o_fecha->format($formato);}
			else{return $dato_fecha;}
		}

		function asignar_tablas(){
			//Asignamos nombre de tabla y campo que contiene los nombres
			switch($this->tipo_categoria){
				case'id_usuario': return array('usuario','user_name');break;
				case 'id_cac': return array('cac','cac_name');break;
				case 'id_producto': return array('producto','producto_name');break;
				case 'id_estado': return array('estados','nombre');break;
				case 'id_municipio': return array('municipio','nombre');break;
				default: return $this->tipo_categoria;
			}
		}

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


		public function pastel_productos(){
			global $obj_db;
			
			$consulta = "SELECT DISTINCT(ventas.id_producto), producto.producto_name, SUM(ventas.n_ventas) AS n_ventas
					 FROM ventas
					 LEFT JOIN producto
					 		ON ventas.id_producto=producto.id_producto ".
					 $this->filtro." 
					 GROUP BY id_producto";

			//echo json_encode($consulta);exit;
			

			$result = $obj_db->consulta($consulta);
			$this->intervalos[0]=array('Producto', 'Valor');
			if($result!=false){
				foreach($result as $fila){
					$this->intervalos[] = array($fila['producto_name'],(double)$fila['n_ventas']);
				}
			}else{
				$this->intervalos[] = array('N/D',0);
			}
			echo json_encode($this->intervalos);exit;

		}

		
		

		public function tabla_detalles(){
			global $obj_db;
			//Cabeceras
				$this->intervalos[0] = array('No. Venta','Fecha','Producto','Promotor','IMEI', 'Servicio','Tienda','Ciudad de Tienda','Region','Cantidad','Ventas','Stock');
				//echo json_encode($this->intervalos);exit;
			
			//Datos
			$consulta = "SELECT ventas.id_ventas, ventas.fecha, ventas.id_producto, producto.producto_name, ventas.id_usuario, usuario.user_name, ventas.imei, ventas.id_servicio, cac.cac_name, municipios.nombre AS cmunicipio, ventas.inventarioi, ventas.n_ventas, ventas.total, cac.anexo2 AS cac_anexo2
					 	 FROM ventas
					 	 LEFT JOIN usuario
					 			 ON ventas.id_usuario=usuario.id_usuario
					 	 LEFT JOIN producto
					 			 ON ventas.id_producto=producto.id_producto 
					 	 LEFT JOIN municipios
					 			 ON ventas.id_municipio=municipios.id_municipio 
					 	 LEFT JOIN cac
					 			 ON ventas.id_cac=cac.id_cac ".

					 	 $this->filtro." 					 
					 	 ORDER BY ventas.fecha ASC";

					 	 //echo json_encode($consulta);exit;

		 	$result = $obj_db->consulta($consulta);
			if($result!=false){
				foreach($result as $fila){
					
					if ($fila['id_servicio']=='0'){ $fila['id_servicio'] = 'N/A';}
					if ($fila['id_servicio']=='1'){ $fila['id_servicio'] = 'Renta';}
					if ($fila['id_servicio']=='2'){ $fila['id_servicio'] = 'Amigo Kit';}

					//Campos extras
					$cac_ce=$this->aliasAndValor($fila['cac_anexo2'], '2');

					$this->intervalos[]=array($fila['id_ventas'],$fila['fecha'],$fila['producto_name'],$fila['user_name'],$fila['imei'],$fila['id_servicio'],$fila['cac_name'],utf8_encode($fila['cmunicipio']),$cac_ce['region_cac'],$fila['inventarioi'],$fila['n_ventas'],$fila['total']);
				}
			}

			


			echo json_encode($this->intervalos);exit;

		}



		public function datos_generales(){
			global $obj_db;
			
			$usuario = isset($_POST['promotor'])? $_POST['promotor'] : '0';
			$foto = ($usuario!=0)?recuperar_foto($usuario):'no-image.jpg';

				$consulta = "SELECT ventas.fecha, ROUND(AVG(ventas.inventarioi),1) AS inventarioi, SUM(ventas.n_ventas)  AS n_ventas, ROUND(AVG(ventas.total),1) AS total
					 	 FROM ventas ".
					 	 $this->filtro." 					 
					 	 GROUP BY ventas.fecha
					 	 ORDER BY ventas.fecha DESC
						 LIMIT 1";
			
				

			//echo json_encode($consulta);exit;

			$result = $obj_db->consulta($consulta);
			if($result!=false){
				foreach($result as $fila){
					if($fila){
						if ($foto!=false){$fila['user_foto']=$foto;}
						$this->intervalos[0] = array($fila['inventarioi'],$fila['n_ventas'],$fila['total'],$foto);
					}
				}
			}else{
				$this->intervalos[0] = array('N/D','N/D','N/D',$foto);
			}
			echo json_encode($this->intervalos);exit;

		}

		function decode_llaves($string){
			$campos;
			$cadenas;


			$r[] = str_replace(array('sum{usuario}','sum{estado}','sum{municipio}','sum{cac}','sum{producto}','sum{inventario inicial}','sum{numero de ventas}','sum{canal}','sum{fecha}','sum{servicio}','sum{total}',
								'{usuario}','{estado}','{municipio}','{cac}','{producto}','{inventario inicial}','{numero de ventas}','{canal}','{fecha}','{servicio}','{total}'),

							 array('SUM(usuario.user_name) AS s_usuario', 
							  'SUM(estados.nombre) AS s_estadon',
							  'SUM(municipios.nombre) AS s_municipion',
							  'SUM(cac.cac_name) AS s_cac',
							  'SUM(producto.producto_name) AS s_producto',
							  'SUM(ventas.inventarioi) AS s_inventarioi',
							  'SUM(ventas.total) AS s_total',
							  'SUM(ventas.canal) AS s_canal',
							  'SUM(ventas.fecha) AS s_fecha',
							  'SUM(ventas.servicio) AS s_servicio',
							  'SUM(ventas.n_ventas) AS s_n_ventas',

							  'DISTINCT (IFNULL(usuario.user_name,"")) AS usuario', 
							  'DISTINCT (IFNULL(estados.nombre,"")) AS estadon',
							  'DISTINCT (IFNULL(municipios.nombre,"")) AS municipion',
							  'DISTINCT (IFNULL(cac.cac_name,"")) AS cac',
							  'DISTINCT (IFNULL(producto.producto_name,"")) AS producto',
							  'DISTINCT (IFNULL(ventas.inventarioi,"")) AS inventarioi',
							  'DISTINCT (IFNULL(ventas.total,"")) AS total',
							  'DISTINCT (IFNULL(ventas.canal,"")) AS canal',
							  'DISTINCT (IFNULL(ventas.fecha,"")) AS fecha',
							  'DISTINCT (IFNULL(ventas.servicio,"")) AS servicio',
							  'DISTINCT (IFNULL(ventas.n_ventas,"")) AS n_ventas'
							  ),
							  strtolower($string));
			$r[]= str_replace(array('sum{usuario}','sum{estado}','sum{municipio}','sum{cac}','sum{producto}','sum{inventario inicial}','sum{numero de ventas}','sum{canal}','sum{fecha}','sum{servicio}','sum{total}',
							   '{usuario}','{estado}','{municipio}','{cac}','{producto}','{inventario inicial}','{numero de ventas}','{canal}','{fecha}','{servicio}','{total}'),
							 array('s_usuario', 
							  's_estadon',
							  's_municipion',
							  's_cac',
							  's_producto',
							  's_inventarioi',
							  's_total',
							  's_canal',
							  's_fecha',
							  's_servicio',
							  's_n_ventas',

							  'usuario', 
							  'estadon',
							  'municipion',
							  'cac',
							  'producto',
							  'inventarioi',
							  'total',
							  'canal',
							  'fecha',
							  'servicio',
							  'n_ventas'
							  ),
							  strtolower($string));
			$r[] = str_replace(array('sum','{usuario}','{estado}','{municipio}','{cac}','{producto}','{inventario inicial}','{numero de ventas}','{canal}','{fecha}','{servicio}','{total}'),
							 array('',
							  'usuario.user_name AS usuario', 
							  'estados.nombre AS estadon' ,
							  'municipios.nombre AS municipion',
							  'cac.cac_name AS cac',
							  'producto.producto_name AS producto',
							  'ventas.inventarioi AS inventarioi',
							  'ventas.total AS total',
							  'ventas.canal AS canal',
							  'ventas.fecha AS fecha',
							  'ventas.servicio AS servicio',
							  'ventas.n_ventas AS n_ventas'
							  ),
							  strtolower($string));

			return $r;
		}

		function pastel_personal($campo,$valor){
			global $obj_db;

			$c_serie = $this->decode_llaves('{fecha}');

			$n_serie = strpos($_POST['n_serie'],'{')===false ? $_POST['n_serie'] : $this->decode_llaves($_POST['n_serie']);
			$v_serie = $this->decode_llaves($_POST['v_series']);
			$this->intervalos=array();
			$join =' LEFT JOIN usuario ON ventas.id_usuario=usuario.id_usuario '.
				   ' LEFT JOIN estados ON ventas.id_estado=estados.id_estado '.
				   ' LEFT JOIN municipios ON ventas.id_municipio=municipios.id_municipio '.
				   ' LEFT JOIN cac ON ventas.id_cac=cac.id_cac '.
				   ' LEFT JOIN categorias ON ventas.id_categoria=categorias.id_categoria '.
				   ' LEFT JOIN producto ON ventas.id_producto=producto.id_producto ';
			$agrupar=" GROUP BY campo ASC";
			$encode_utf = false;


			global $obj_db;
			
			/*$consulta = "SELECT DISTINCT(".$campo.") AS campo, ".$op."".$valor.") AS n_valor
					 FROM ventas 
					 ".$join." ".
					 $this->filtro." ".
					 $agrupar;
			*/

			$consulta = "SELECT ".$n_serie[0].", ".$v_serie[0]."
				 	 FROM ventas 
				 	 ".$join." ".
				 	 $this->filtro." 
				  	 GROUP BY ".$n_serie[1]." ASC";
			//echo json_encode($consulta);exit;

			$result = $obj_db->consulta($consulta);
			$this->intervalos[0]=array('Producto', 'Valor');
			if($result!=false){
				foreach($result as $fila){
					if ($encode_utf==true){
						$this->intervalos[] = array(utf8_encode($fila[$n_serie[1]]),(double)$fila[$v_serie[1]]);
					}else{
						$this->intervalos[] = array($fila[$n_serie[1]],(double)$fila[$v_serie[1]]);
					}
				}
			}else{
				$this->intervalos[] = array('N/D',0);
			}
			echo json_encode($this->intervalos);exit;

		}


		public function barra_personal($campo,$valor){
			global $obj_db;

			$c_serie = $this->decode_llaves('{fecha}');

			$n_serie = strpos($_POST['n_serie'],'{')===false ? $_POST['n_serie'] : $this->decode_llaves($_POST['n_serie']);
			$v_serie = $this->decode_llaves($_POST['v_series']);
			$this->intervalos=array();
			$join =' LEFT JOIN usuario ON ventas.id_usuario=usuario.id_usuario '.
				   ' LEFT JOIN estados ON ventas.id_estado=estados.id_estado '.
				   ' LEFT JOIN municipios ON ventas.id_municipio=municipios.id_municipio '.
				   ' LEFT JOIN cac ON ventas.id_cac=cac.id_cac '.
				   ' LEFT JOIN categorias ON ventas.id_categoria=categorias.id_categoria '.
				   ' LEFT JOIN producto ON ventas.id_producto=producto.id_producto ';

			//Categorías
				$consulta = "SELECT ".$c_serie[0]."
					 	 FROM ventas 
					 	 ".$join." ".
					 	 $this->filtro." 

					  	 ORDER BY ".$c_serie[1]." ASC";

				//echo json_encode($consulta);exit;
					 	 
				$result = $obj_db->consulta($consulta);
				$this->intervalos[] = array($c_serie[1]);
				if($result!=false){
					foreach($result as $fila){
						$this->intervalos[] = array($fila[$c_serie[1]]);
					}
				}


			//Label
			
			if(strpos($_POST['n_serie'],'{')===false ){
				$label_serie=explode(',', $n_serie);
					foreach($label_serie as $fila){
						$this->intervalos[0][] = $fila;
						//echo json_encode($fila);exit;
					}
			}else{
				if(substr_count($_POST['n_serie'], '{')<2){
					$consulta = "SELECT ".$n_serie[0]."
					 	 FROM ventas 
					 	 ".$join." ".
					 	 $this->filtro." 
					  	 ORDER BY ".$n_serie[1]." ASC";

					//echo json_encode($consulta);exit;
					 	 
					$result = $obj_db->consulta($consulta);
					if($result!=false){
						foreach($result as $fila){
							$this->intervalos[0][] = $fila[$n_serie[1]];
						}
					}
				}
			}

			

			//Valores
			$consulta = "SELECT ".$v_serie[2].", ".$n_serie[2].", ".$c_serie[2]."
					 	 FROM ventas 
					 	 ".$join." ".
					 	 $this->filtro." 
					  	 ORDER BY ".$v_serie[1]." ASC";

			//echo json_encode($consulta);exit;
					 	 
			$result = $obj_db->consulta($consulta);
			if($result!=false){
				//Inicializamos los datos en 0
				


				for ($i=1; $i<sizeof($this->intervalos);$i++){ 
					for($j=1; $j<sizeof($this->intervalos[0]);$j++){
						$this->intervalos[$i][$j]=0;
					}
				}

				

				foreach($result as $fila){
					for ($i=1; $i<sizeof($this->intervalos);$i++){ 
						for($j=1; $j<sizeof($this->intervalos[0]);$j++){
							if ($this->intervalos[0][$j]==$fila[$n_serie[1]]&&$this->intervalos[$i][0]==$fila[$c_serie[1]]){
								$this->intervalos[$i][$j]+=(double)$fila[$v_serie[1]];			
							}
						}
					}
				}

			}else{
				$this->intervalos[0]=array('Fecha', 'N/D');
				$this->intervalos[1]=array($_POST['fecha_i'],0);
			}





			echo json_encode($this->intervalos);exit;

		}



		function geo_personal(){
			global $obj_db;
			
			$consulta = "SELECT DISTINCT(ventas.id_estado), estados.nombre, SUM(ventas.n_ventas) AS n_ventas
					 FROM ventas
					 LEFT JOIN estados
					 		ON ventas.id_estado=estados.id_estado ".
					 $this->filtro." 					 
					 GROUP BY estados.nombre";

			

			$result = $obj_db->consulta($consulta);
			$this->intervalos[0]=array('Estado', 'Ventas');
			if($result!=false){
				foreach($result as $fila){
					$this->intervalos[] = array($fila['nombre'],(double)$fila['n_ventas']);
				}
			}else{
				$this->intervalos[] = array('N/D',0);
			}
			echo json_encode($this->intervalos);exit;

		}

		function tabla_personal(){
			global $obj_db;

			$c_serie = $this->decode_llaves('{fecha}');

			$n_serie = strpos($_POST['n_serie'],'{')===false ? $_POST['n_serie'] : $this->decode_llaves($_POST['n_serie']);
			$v_serie = $this->decode_llaves($_POST['v_series']);
			$this->intervalos=array();
			$join =' LEFT JOIN usuario ON ventas.id_usuario=usuario.id_usuario '.
				   ' LEFT JOIN estados ON ventas.id_estado=estados.id_estado '.
				   ' LEFT JOIN municipios ON ventas.id_municipio=municipios.id_municipio '.
				   ' LEFT JOIN cac ON ventas.id_cac=cac.id_cac '.
				   ' LEFT JOIN categorias ON ventas.id_categoria=categorias.id_categoria '.
				   ' LEFT JOIN producto ON ventas.id_producto=producto.id_producto ';

			//Categorías
				$consulta = "SELECT ".$c_serie[0]."
					 	 FROM ventas 
					 	 ".$join." ".
					 	 $this->filtro." 

					  	 ORDER BY ".$c_serie[1]." ASC";

				//echo json_encode($consulta);exit;
					 	 
				$result = $obj_db->consulta($consulta);
				$this->intervalos[] = array($c_serie[1]);
				if($result!=false){
					foreach($result as $fila){
						$this->intervalos[] = array($fila[$c_serie[1]]);
					}
				}


			//Label
			
			if(strpos($_POST['n_serie'],'{')===false ){
				$label_serie=explode(',', $n_serie);
					foreach($label_serie as $fila){
						$this->intervalos[0][] = $fila;
						//echo json_encode($fila);exit;
					}
			}else{
				if(substr_count($_POST['n_serie'], '{')<2){
					$consulta = "SELECT ".$n_serie[0]."
					 	 FROM ventas 
					 	 ".$join." ".
					 	 $this->filtro." 
					  	 ORDER BY ".$n_serie[1]." ASC";

					//echo json_encode($consulta);exit;
					 	 
					$result = $obj_db->consulta($consulta);
					if($result!=false){
						foreach($result as $fila){
							$this->intervalos[0][] = $fila[$n_serie[1]];
						}
					}
				}
			}

			

			//Valores
			$consulta = "SELECT ".$v_serie[2].", ".$n_serie[2].", ".$c_serie[2]."
					 	 FROM ventas 
					 	 ".$join." ".
					 	 $this->filtro." 
					  	 ORDER BY ".$v_serie[1]." ASC";

			//echo json_encode($consulta);exit;
					 	 
			$result = $obj_db->consulta($consulta);
			if($result!=false){
				//Inicializamos los datos en 0
				


				for ($i=1; $i<sizeof($this->intervalos);$i++){ 
					for($j=1; $j<sizeof($this->intervalos[0]);$j++){
						$this->intervalos[$i][$j]=0;
					}
				}

				

				foreach($result as $fila){
					for ($i=1; $i<sizeof($this->intervalos);$i++){ 
						for($j=1; $j<sizeof($this->intervalos[0]);$j++){
							if ($this->intervalos[0][$j]==$fila[$n_serie[1]]&&$this->intervalos[$i][0]==$fila[$c_serie[1]]){
								$this->intervalos[$i][$j]+=(double)$fila[$v_serie[1]];			
							}
						}
					}
				}

			}else{
				$this->intervalos[0]=array('Fecha', 'N/D');
				$this->intervalos[1]=array($_POST['fecha_i'],0);
			}





			echo json_encode($this->intervalos);exit;
		}

		function operador_valor($s){

			foreach($s as $s_aux){
				$r = explode(':', $s_aux);
				foreach($r as $r_aux){
					$a[][]=	$r_aux;
				}
			};
			//echo json_encode(array($a));exit;
			return $a;
		}


		
	}



if (isset($_POST['funcion'])){

	$grafica = new clGraficas();

	if(isset($_POST['fecha_i'])){$grafica->f_filtro('fecha_i',str_replace('/', '', $_POST['fecha_i']));}
	if(isset($_POST['fecha_f'])){$grafica->f_filtro('fecha_f',str_replace('/', '', $_POST['fecha_f']));}
	if(isset($_POST['promotor'])){$grafica->f_filtro('promotor',$_POST['promotor']);}
	if(isset($_POST['estado'])){$grafica->f_filtro('estado',$_POST['estado']);}
	if(isset($_POST['cac'])){$grafica->f_filtro('cac',$_POST['cac']);}


	if($_POST['funcion']=='pastel_productos')
		$grafica->pastel_productos();
	if($_POST['funcion']=='pastel_personal'){
		$valores = $grafica->operador_valor($_POST['valores']);
		$grafica->pastel_personal($_POST['categoria'],$valores);
	}
	if($_POST['funcion']=='barra_ventas_usuarios')
		$grafica->barra_ventas_usuarios();
	if($_POST['funcion']=='barra_personal')
		$grafica->barra_personal($_POST['categoria'],'n_ventas');
	if($_POST['funcion']=='geo_ventas')
		$grafica->geo_ventas();
	if($_POST['funcion']=='geo_personal')
		$grafica->geo_personal();
	if($_POST['funcion']=='barra_ventas_totales')
		$grafica->barra_ventas_totales();
	if($_POST['funcion']=='tabla_detalles')
		$grafica->tabla_detalles();
	if($_POST['funcion']=='tabla_personal')
		$grafica->tabla_personal();	
	if($_POST['funcion']=='datos_generales')
		$grafica->datos_generales();	
}


//Recupera foto
	if(isset($_POST['get_foto'])){
		if ($_POST['get_foto']!=0){
			global $obj_db;
			$consulta = "SELECT user_foto FROM usuario WHERE id_usuario=".$_POST['get_foto']." LIMIT 1";
			$result = $obj_db->consulta($consulta);
    		if($result!=false){
	        	foreach($result as $fila){
        		$r=array($fila['user_foto']);
    	    	}
    		}
    		echo json_encode($r);
    	}else{
    		echo json_encode(false);
    	}
	}

	function recuperar_foto($usuario){
		if ($usuario!=0){
			global $obj_db;
			$consulta = "SELECT user_foto FROM usuario WHERE id_usuario=".$usuario." LIMIT 1";
			$result = $obj_db->consulta($consulta);
    		if($result!=false){
	        	foreach($result as $fila){
        		$r=array($fila['user_foto']);
    	    	}
    		}
    		return $r;
    	}else{
    		return false;
    	}
	}

?>
