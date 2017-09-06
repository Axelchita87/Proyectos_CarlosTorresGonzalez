<?php

	require_once 'class/class.db.php';

    

    global $obj_db;
	$filtro = ' WHERE 1 ';

    	function f_filtro($x,$v){
    		$f='';
			if ($x=='fecha_i'&&$_GET['fecha_f']==''&&$v!=''){$f .= ' and DATE_FORMAT( fecha, "%Y%m%d" )="'.$v.'" ';}
          	if ($x=='fecha_f'&&$_GET['fecha_i']!=''&&$v!=''){$f .= ' and DATE_FORMAT( fecha, "%Y%m%d" )>="'.str_replace("/", "", $_GET['fecha_i']).'" and DATE_FORMAT( fecha, "%Y%m%d" )<="'.$v.'" ';}
          	if ($x=='promotor'&&$v!=0){$f .= ' and id_usuario='.$v." ";}
          	if ($x=='cac'&&$v!=0){$f .= ' and id_tienda='.$v;}
          	//if ($x=='producto'&&$v!=0){$f .= ' and respuesta_cuestionario_nutrioli.id_usuario='.$v;}
          	if ($x=='estado'&&$v!=0){$f .= ' and cac.id_estado='.$v." ";}
          	//if ($x=='municipio'&&$v!=0){$f .= ' and ventas.id_usuario='.$v;}
      
          	//WHERE  DATE_FORMAT( fecha, '%Y%m%d' ) >=".date("Ym")."01 AND DATE_FORMAT( fecha, '%Y%m%d' )<=".date("Ymd");
			
			return $f;
		}

		function aliasAndValor($cadena, $seccion){
			global $obj_db;
			$s=array();

			$cadena = str_replace('form_ext_', '', $cadena);

			$a_json = json_decode('['.$cadena.']');

			//Rellenar todos los alias
			$consulta3 = "SELECT f_alias
	    	    	     FROM form_extra
	    	    		 WHERE id_seccion = ".$seccion;

	    	$result = $obj_db->consulta($consulta3);    	
	    	if($result!=false){
				foreach($result as $fila){
					$s[$fila['f_alias']] = '';
				}
			}
			
			//Buscamos el alias que corresponde a cada id y agregamos su valor
			foreach( $a_json as $name) {
	    	    foreach( $name as $value1 => $value ) {

	    	    	$consulta5 = "SELECT f_alias
	    	    			   	 FROM form_extra
	    	    			   	 WHERE id_form = ".$value1."
	    	    			     LIMIT 1";
	    	    	
	    	    			   
	    	    	$result = $obj_db->consulta($consulta5);
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



	if(isset($_GET['fecha_i'])){
		if($_GET['fecha_i']!=''){
			$filtro .= f_filtro('fecha_i',str_replace('/', '', $_GET['fecha_i']));
		}
	}
	if(isset($_GET['fecha_f'])){
		if($_GET['fecha_f']!=''){
			$filtro .= f_filtro('fecha_f',str_replace('/', '', $_GET['fecha_f']));
		}
	}
	if(isset($_GET['promotor'])){
		if($_GET['promotor']!='0'){
			//$filtro .= f_filtro('promotor',$_GET['promotor']);
		}
	}
	if(isset($_GET['estado'])){
		if($_GET['estado']!='0'){
			//$filtro .= f_filtro('estado',$_GET['estado']);
		}
	}
	if(isset($_GET['cac'])){
		if($_GET['cac']!=''){
			//$filtro .= f_filtro('cac',$_GET['cac']);
		}
	}

	//echo json_encode($this->intervalos);exit;
			
	//Datos



			$consulta="SELECT respuestas2.respuestas 
                    	 FROM respuestas2 
                        ".$filtro." AND respuestas2.cancelado=0" ;

            $consulta_usuarios = "SELECT id_usuario, user_name
            					   FROM usuario 
            					  WHERE 1";
            $consulta_campanas = "SELECT id_campana, nombre_campana
            					   FROM campanas 
            					  WHERE 1";



					 	 
	
	$resultado = $obj_db->consulta($consulta);
	$resultado_usuarios = $obj_db->consulta($consulta_usuarios);
	$resultado_campanas = $obj_db->consulta($consulta_campanas);
	

	if($resultado!=false && $resultado_usuarios!=false && $resultado_campanas!=false){


		foreach ($resultado_usuarios as $fila_usuario) {
			$array_usuarios['usuarios'][] = $fila_usuario['user_name'];
			$array_usuarios['id_usuarios'][] = $fila_usuario['id_usuario'];
		}

		foreach ($resultado_campanas as $fila_campanas) {
			$array_campanas['campanas'][] = $fila_campanas['nombre_campana'];
			$array_campanas['id_campanas'][] = $fila_campanas['id_campana'];
		}
//print_r($array_usuarios['usuarios']);
//print_r(array_search("Mena",$array_usuarios['usuarios']));exit;

		date_default_timezone_set('America/Mexico_City');

		if (PHP_SAPI == 'cli')
			die('Este archivo solo se puede ver desde un navegador web');

		/** Se agrega la libreria PHPExcel */
		require_once 'reporteexcel/lib/PHPExcel/PHPExcel.php';

		// Se crea el objeto PHPExcel
		$objPHPExcel = new PHPExcel();

		// Se asignan las propiedades del libro
		$objPHPExcel->getProperties()->setCreator("Menacorp") //Autor
							 ->setLastModifiedBy("Menacorp") //Ultimo usuario que lo modificó
							 ->setTitle("Reporte Excel con PHP y MySQL")
							 ->setSubject("Reporte Excel con PHP y MySQL")
							 ->setDescription("Reporte detallado")
							 ->setKeywords("reporte aventas detalles")
							 ->setCategory("Reporte excel");

		$tituloReporte = " Reporte detallado ";
		$titulosColumnas = array(' Tienda ',' Evaluador ',' Campaña ',' Fecha ','Tienda Activada',' SAP ',' Evento Competencia ',' Marca Competencia ',' Hay modulo ', ' Hay promocionales ', ' Hay sarteneta ', ' POP ',' Licencia ',' Sonido ', ' Adicional ', ' Producto suficiente ', ' Degustación ', ' Uniforme ', ' Encargado ' , 'marmol_ibre_s',' marmol_quemado_s ' ,' vidrio_limpios_s ' ,' marquesina_libre_s ' ,' socio_libre_s ' ,' paredes_libres_s ' ,' madera_libre_s ' ,' mesas_libres_s ' ,' silones_libres_s ' ,' cuadros_libres_s ' ,' macetas_buenas_s ' ,' puertas_limpias_s ' ,' elevadores_limpios_s ' ,' lampas_libres_s ' ,' botoneras_libres_s ' ,' puertasServicio_libres_s ' ,' ceniceros_limpios_s ' ,' plantasArtificiales_limpias_s ' ,' pisosMarmol_s ' ,' terraza_limpia_s ' ,' piso_limpios_s ' ,' botonera_libre_s ' ,' contenedor_libre_s ' ,' verticales_libre_s ' ,' puestas_ele_s ' ,' piso_ele_s ' ,' pared_libre_s ' ,' barandal_libres_s ' ,' pared_manchado_s ' ,' pollos_limpios_s ' ,' puertas_ductos_s ' ,' botes_limpios_s ' ,' bajo_basura_s ' ,' ducto_basura_s ' ,' escaleras_limpias_s ' ,' azotea_barrida_s ' , ' Puntualidad ', ' Abordaje ', ' Ubicación ', ' Objetivo de venta ', ' Frase rectora ', ' Argumentos de venta ', ' Comunica precio ', ' Imagen de la persona ', 'Congruencia de la marca', ' Presentación del producto ', ' Manejo y limpieza ', ' Observaciones ','Logro Objetivo', "Objetivo de Venta");
		$letraColumnas = array('A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','AA','AB','AC','AD','AE','AF',"AG");

		$objPHPExcel->setActiveSheetIndex(0)
        		    ->mergeCells('A1:'.$letraColumnas[count($letraColumnas)-1].'1');
						
		// Se agregan los titulos del reporte
		$objPHPExcel->setActiveSheetIndex(0)
					->setCellValue('A1',$tituloReporte)
        		    ->setCellValue($letraColumnas[0].'3',  $titulosColumnas[0])
		            ->setCellValue($letraColumnas[1].'3',  $titulosColumnas[1])
        		    ->setCellValue($letraColumnas[2].'3',  $titulosColumnas[2])
            		->setCellValue($letraColumnas[3].'3',  $titulosColumnas[3])
            		->setCellValue($letraColumnas[4].'3',  $titulosColumnas[4])
            		->setCellValue($letraColumnas[5].'3',  $titulosColumnas[5])
            		->setCellValue($letraColumnas[6].'3',  $titulosColumnas[6])
            		->setCellValue($letraColumnas[7].'3',  $titulosColumnas[7])
            		->setCellValue($letraColumnas[8].'3',  $titulosColumnas[8])
            		->setCellValue($letraColumnas[9].'3',  $titulosColumnas[9]) 
            		->setCellValue($letraColumnas[10].'3',  $titulosColumnas[10])          		
            		->setCellValue($letraColumnas[11].'3',  $titulosColumnas[11])
            		->setCellValue($letraColumnas[12].'3',  $titulosColumnas[12])
            		->setCellValue($letraColumnas[13].'3',  $titulosColumnas[13])
            		->setCellValue($letraColumnas[14].'3',  $titulosColumnas[14])
            		->setCellValue($letraColumnas[15].'3',  $titulosColumnas[15])
            		->setCellValue($letraColumnas[16].'3',  $titulosColumnas[16])
            		->setCellValue($letraColumnas[17].'3',  $titulosColumnas[17])
            		->setCellValue($letraColumnas[18].'3',  $titulosColumnas[18])
            		->setCellValue($letraColumnas[19].'3',  $titulosColumnas[19])
            		->setCellValue($letraColumnas[20].'3',  $titulosColumnas[20])
		            ->setCellValue($letraColumnas[21].'3',  $titulosColumnas[21])
        		    ->setCellValue($letraColumnas[22].'3',  $titulosColumnas[22])
            		->setCellValue($letraColumnas[23].'3',  $titulosColumnas[23])
            		->setCellValue($letraColumnas[24].'3',  $titulosColumnas[24])
            		->setCellValue($letraColumnas[25].'3',  $titulosColumnas[25])
            		->setCellValue($letraColumnas[26].'3',  $titulosColumnas[26])
            		->setCellValue($letraColumnas[27].'3',  $titulosColumnas[27])
            		->setCellValue($letraColumnas[28].'3',  $titulosColumnas[28])
            		->setCellValue($letraColumnas[29].'3',  $titulosColumnas[29])
            		->setCellValue($letraColumnas[30].'3',  $titulosColumnas[30])
            		->setCellValue($letraColumnas[31].'3',  $titulosColumnas[31])
            		->setCellValue($letraColumnas[32].'3',  $titulosColumnas[32]);
		
		//Se agregan los datos de los alumnos
		$i = 4;

		foreach ($resultado as $fila) {

			

				$json = json_decode($fila['respuestas']);
				
				$fila_nombre_evaluador = isset($json->nombre_evaluador)		?$json->nombre_evaluador			:'';
				if (is_numeric($fila_nombre_evaluador)){
					$key_usuario = array_search($fila_nombre_evaluador,$array_usuarios['id_usuarios']);
					$fila_nombre_evaluador = $key_usuario===false?'':$array_usuarios['usuarios'][$key_usuario];					
				}

				$fila_nombre_encargado = isset($json->persona_evento)		?$json->persona_evento			:'';
				if (is_numeric($fila_nombre_encargado)){
					$key_usuario = array_search($fila_nombre_encargado,$array_usuarios['id_usuarios']);
					$fila_nombre_encargado = $key_usuario===false?'':$array_usuarios['usuarios'][$key_usuario];					
				}

				$fila_nombre_campana = isset($json->nombre_campana)		?$json->nombre_campana			:'';
				if (is_numeric($fila_nombre_campana)){
					$key_campana = array_search($fila_nombre_campana,$array_campanas['id_campanas']);
					$fila_nombre_campana = $key_campana===false?'':$array_campanas['campanas'][$key_campana];					
				}

				$imprimir = true;

				if (isset($_GET['evaluador'])){
					if($_GET['evaluador']!='0'){
						if($_GET['evaluador'] != $json->nombre_evaluador){
							$imprimir = false;
						}
					}
				}

				if (isset($_GET['encargado'])){
					if($_GET['encargado']!='0'){
						if($_GET['encargado'] != $json->persona_evento){
							$imprimir = false;
						}
					}
				}

				if (isset($_GET['campana'])){
					if($_GET['campana']!='0'){
						if($_GET['campana'] != $json->nombre_campana){
							$imprimir = false;
						}
					}
				}


//print_r($fila);	exit;
						//exit;
					if ($imprimir){

						$json_tienda_activada 		        = isset($json->tienda_activada) 	&& $json->tienda_activada 		== 'on' ? "Si" : "No";
     					$json_personal_uniforme		        = isset($json->personal_uniforme) 	&& $json->personal_uniforme 		== 'on' ? "Si" : "No";
						$json_lavado_piso				    = isset($json->lavado_piso) 		&& $json->lavado_piso 				== 'on' ? "Si" : "No";
						$json_lavado_vidrios 				= isset($json->lavado_vidrios) 		&& $json->lavado_vidrios 				== 'on' ? "Si" : "No";
						$json_frente 		                = isset($json->frente) 			    && $json->frente 			== 'on' ? "Si" : "No";
						$json_derecho 				    	= isset($json->derecho) 		    && $json->derecho 					== 'on' ? "Si" : "No";
						$json_izquierdo				        = isset($json->izquierdo) 			&& $json->izquierdo 				== 'on' ? "Si" : "No";
						$json_posteriores				    = isset($json->posteriores) 		&& $json->posteriores 				== 'on' ? "Si" : "No";
						$json_lavado_alberca 			    = isset($json->lavado_alberca) 		&& $json->lavado_alberca 			== 'on' ? "Si" : "No";
						$json_lobbys_limpieza 	            = isset($json->lobbys_limpieza)     && $json->lobbys_limpieza 	== 'on' ? "Si" : "No";
						$json_escaleras 			        = isset($json->escaleras) 		    && $json->escaleras 			== 'on' ? "Si" : "No";
						$json_alfombras 	                = isset($json->alfombras) 	        && $json->alfombras 	== 'on' ? "Si" : "No";
						$json_cine                      	= isset($json->cine) 	            && $json->cine 	== 'on' ? "Si" : "No";
						$json_marmol_ibre_s 				    = isset($json->marmol_ibre_s) 		&& $json->marmol_ibre_s 				== 'on' ? "Si" : "No";
						$json_marmol_quemado_s 				    = isset($json->marmol_quemado_s)    && $json->marmol_quemado_s 				== 'on' ? "Si" : "No";
						$json_vidrio_limpios_s 				    = isset($json->vidrio_limpios_s)    && $json->vidrio_limpios_s 				== 'on' ? "Si" : "No";
						$json_marquesina_libre_s				= isset($json->marquesina_libre_s) 		    	&& $json->marquesina_libre_s 				== 'on' ? "Si" : "No";
						$json_socio_libre_s				        = isset($json->socio_libre_s) 		    	    && $json->socio_libre_s 				== 'on' ? "Si" : "No";
						$json_paredes_libres_s				    = isset($json->paredes_libres_s) 		    	&& $json->paredes_libres_s 				== 'on' ? "Si" : "No";
						$json_madera_libre_s				    = isset($json->madera_libre_s) 		    	    && $json->madera_libre_s 				== 'on' ? "Si" : "No";
						$json_mesas_libres_s 				    = isset($json->mesas_libres_s) 		    	    && $json->mesas_libres_s 				== 'on' ? "Si" : "No";
						$json_silones_libres_s 				    = isset($json->silones_libres_s) 		    	&& $json->silones_libres_s 				== 'on' ? "Si" : "No";
						$json_cuadros_libres_s 				    = isset($json->cuadros_libres_s) 		    	&& $json->cuadros_libres_s 				== 'on' ? "Si" : "No";
						$json_macetas_buenas_s 				    = isset($json->macetas_buenas_s) 		    	&& $json->macetas_buenas_s 				== 'on' ? "Si" : "No";
						$json_puertas_limpias_s 				= isset($json->puertas_limpias_s) 		    	&& $json->puertas_limpias_s 				== 'on' ? "Si" : "No";
						$json_elevadores_limpios_s 				= isset($json->elevadores_limpios_s) 		    && $json->elevadores_limpios_s 				== 'on' ? "Si" : "No";
						$json_lampas_libres_s				    = isset($json->lampas_libres_s) 		    	&& $json->lampas_libres_s 				== 'on' ? "Si" : "No";
						$json_botoneras_libres_s				= isset($json->botoneras_libres_s) 		    	&& $json->botoneras_libres_s 				== 'on' ? "Si" : "No";
						$json_puertasServicio_libres_s 			= isset($json->puertasServicio_libres_s) 		&& $json->puertasServicio_libres_s 				== 'on' ? "Si" : "No";
						$json_ceniceros_limpios_s				= isset($json->ceniceros_limpios_s) 		    && $json->ceniceros_limpios_s 				== 'on' ? "Si" : "No";
						$json_plantasArtificiales_limpias_s		= isset($json->plantasArtificiales_limpias_s)   && $json->plantasArtificiales_limpias_s 				== 'on' ? "Si" : "No";
						$json_pisosMarmol_s 				= isset($json->pisosMarmol_s) 		    	&& $json->pisosMarmol_s 				== 'on' ? "Si" : "No";
						$json_terraza_limpia_s				= isset($json->terraza_limpia_s) 		    	&& $json->terraza_limpia_s 				== 'on' ? "Si" : "No";
       	                //Area de servicio de PH al piso
 		     			$json_piso_limpios_s				= isset($json->piso_limpios_s) 		    	&& $json->piso_limpios_s 				== 'on' ? "Si" : "No";
						$json_botonera_libre_s				= isset($json->botonera_libre_s) 		    	&& $json->botonera_libre_s 				== 'on' ? "Si" : "No";
						$json_contenedor_libre_s				= isset($json->contenedor_libre_s) 		    	&& $json->contenedor_libre_s 				== 'on' ? "Si" : "No";
						$json_verticales_libre_s				= isset($json->verticales_libre_s) 		    	&& $json->verticales_libre_s 				== 'on' ? "Si" : "No";
						$json_puestas_ele_s 				= isset($json->puestas_ele_s) 		    	&& $json->puestas_ele_s 				== 'on' ? "Si" : "No";
						$json_piso_ele_s 				= isset($json->piso_ele_s) 		    	&& $json->piso_ele_s 				== 'on' ? "Si" : "No";
						$json_pared_libre_s				= isset($json->pared_libre_s) 		    	&& $json->pared_libre_s 				== 'on' ? "Si" : "No";
						$json_barandal_libres_s 				= isset($json->barandal_libres_s) 		    	&& $json->barandal_libres_s 				== 'on' ? "Si" : "No";
						$json_pared_manchado_s				= isset($json->pared_manchado_s) 		    	&& $json->pared_manchado_s 				== 'on' ? "Si" : "No";
						$json_pollos_limpios_s				= isset($json->pollos_limpios_s) 		    	&& $json->pollos_limpios_s 				== 'on' ? "Si" : "No";
						$json_puertas_ductos_s				= isset($json->puertas_ductos_s) 		    	&& $json->puertas_ductos_s 				== 'on' ? "Si" : "No";
						$json_botes_limpios_s				= isset($json->botes_limpios_s) 		    	&& $json->botes_limpios_s 				== 'on' ? "Si" : "No";
						$json_bajo_basura_s				= isset($json->bajo_basura_s) 		    	&& $json->bajo_basura_s 				== 'on' ? "Si" : "No";
						$json_ducto_basura_s				= isset($json->ducto_basura_s) 		    	&& $json->ducto_basura_s 				== 'on' ? "Si" : "No";
						$json_escaleras_limpias_s				= isset($json->escaleras_limpias_s) 		    	&& $json->escaleras_limpias_s 				== 'on' ? "Si" : "No";
						$json_azotea_barrida_s				= isset($json->azotea_barrida_s) 		    	&& $json->azotea_barrida_s 				== 'on' ? "Si" : "No";
						$json_puntualidad 			= isset($json->puntualidad) 		&& $json->puntualidad 			== 'on' ? "Si" : "No";
						$json_abordaje 				= isset($json->abordaje) 			&& $json->abordaje 				== 'on' ? "Si" : "No";
						$json_ubicacion 			= isset($json->ubicacion) 			&& $json->ubicacion 			== 'on' ? "Si" : "No";
						$json_objetivo 				= isset($json->objetivo) 			&& $json->objetivo 				== 'on' ? "Si" : "No";
						$json_frase 				= isset($json->frase) 				&& $json->frase 				== 'on' ? "Si" : "No";
						$json_argumentos 			= isset($json->argumentos) 			&& $json->argumentos 			== 'on' ? "Si" : "No";
						$json_precio 				= isset($json->precio) 				&& $json->precio 				== 'on' ? "Si" : "No";
						$json_imagen_persona 		= isset($json->imagen_persona) 		&& $json->imagen_persona 		== 'on' ? "Si" : "No";
						$json_congruencia 			= isset($json->congruencia) 		&& $json->congruencia 			== 'on' ? "Si" : "No";
						$json_presentacion_producto = isset($json->presentacion_producto)&& $json->presentacion_producto== 'on' ? "Si" : "No";
						$json_manejo_limpieza 		= isset($json->manejo_limpieza) 	&& $json->manejo_limpieza 		== 'on' ? "Si" : "No";
						$json_logro_objetivo 		= isset($json->logro_objetivo) 		&& $json->logro_objetivo 		== 'on' ? "Si" : "No";

				
						
						//print_r(isset($json->nombre_evaluador));
						//print_r("<br>");

							//Reescribir el campo de servicios

							//Obtener campos personalizados
							//print_r($cac_ce);exit;

						 	$objPHPExcel->setActiveSheetIndex(0)
						 			->setCellValue($letraColumnas[0].$i,  isset($json->nombre_tiendas)			?$json->nombre_tiendas				:'')
				        		    ->setCellValue($letraColumnas[1].$i,  $fila_nombre_evaluador)
						            ->setCellValue($letraColumnas[2].$i,  $fila_nombre_campana)
				        		    ->setCellValue($letraColumnas[3].$i,  isset($json->fecha)					?$json->fecha						:'')
				        		    ->setCellValue($letraColumnas[4].$i,  $json_tienda_activada)
				        		    ->setCellValue($letraColumnas[4].$i,  $json_personal_uniforme)
				            		->setCellValue($letraColumnas[5].$i,  isset($json->sap)						?$json->sap							:'')
				            		->setCellValue($letraColumnas[6].$i,  isset($json->tipo_evento)				?$json->tipo_evento					:'')
				            		->setCellValue($letraColumnas[7].$i,  isset($json->marca_competencia)		?$json->marca_competencia			:'')
				            		->setCellValue($letraColumnas[8].$i,   $json_lavado_piso)
				            		->setCellValue($letraColumnas[9].$i,   $json_lavado_vidrios)
				            		->setCellValue($letraColumnas[10].$i,  $json_frente)
				            		->setCellValue($letraColumnas[11].$i,  $json_derecho)
				            		->setCellValue($letraColumnas[12].$i,  $json_izquierdo)
				            		->setCellValue($letraColumnas[13].$i,  $json_posteriores)
				            		->setCellValue($letraColumnas[14].$i,  $json_lavado_alberca)
				            		->setCellValue($letraColumnas[15].$i,  $json_lobbys_limpieza)
				            		->setCellValue($letraColumnas[16].$i,  $json_escaleras)
				            		->setCellValue($letraColumnas[17].$i,  $json_alfombras)
				            		->setCellValue($letraColumnas[17].$i,  $json_cine)
				            		->setCellValue($letraColumnas[18].$i,  $fila_nombre_encargado)
				            		->setCellValue($letraColumnas[20].$i,  $json_marmol_ibre_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_marmol_quemado_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_vidrio_limpios_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_marquesina_libre_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_socio_libre_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_paredes_libres_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_madera_libre_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_mesas_libres_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_silones_libres_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_cuadros_libres_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_macetas_buenas_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_puertas_limpias_sa)
				            		->setCellValue($letraColumnas[20].$i,  $json_elevadores_limpios_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_lampas_libres_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_botoneras_libres_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_puertasServicio_libres_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_ceniceros_limpios_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_plantasArtificiales_limpias_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_pisosMarmol_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_terraza_limpia_s)
            		                //Area de servicio de PH al piso
				            		->setCellValue($letraColumnas[20].$i,  $json_piso_limpios_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_botonera_libre_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_contenedor_libre_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_verticales_libre_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_puestas_ele_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_piso_ele_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_apared_libre_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_barandal_libres_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_pared_manchado_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_pollos_limpios_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_puertas_ductos_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_botes_limpios_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_bajo_basura_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_ducto_basura_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_escaleras_limpias_s)
				            		->setCellValue($letraColumnas[20].$i,  $json_azotea_barrida_s)
				            		->setCellValue($letraColumnas[19].$i,  $json_puntualidad)
				            		->setCellValue($letraColumnas[20].$i,  $json_abordaje)
				            		->setCellValue($letraColumnas[21].$i,  $json_ubicacion)
				            		->setCellValue($letraColumnas[22].$i,  $json_objetivo)
						            ->setCellValue($letraColumnas[23].$i,  $json_frase)
				        		    ->setCellValue($letraColumnas[24].$i,  $json_argumentos)
				            		->setCellValue($letraColumnas[25].$i,  $json_precio)
				            		->setCellValue($letraColumnas[26].$i,  $json_imagen_persona)
				            		->setCellValue($letraColumnas[27].$i,  $json_congruencia)
				            		->setCellValue($letraColumnas[28].$i,  $json_presentacion_producto)
				            		->setCellValue($letraColumnas[29].$i,  $json_manejo_limpieza)
				            		->setCellValue($letraColumnas[30].$i,  isset($json->cuestionario_observaciones)?$json->cuestionario_observaciones:'')
				            		->setCellValue($letraColumnas[31].$i,  $json_logro_objetivo)
				            		->setCellValue($letraColumnas[32].$i,  isset($json->json_porcentaje_objetivo)		?$json->json_porcentaje_objetivo			:'0');
									$i++;
					}

		}


		$estiloTituloReporte = array(
        	'font' => array(
	        	'name'      => 'Verdana',
    	        'bold'      => true,
        	    'italic'    => false,
                'strike'    => false,
               	'size' =>16,
	            	'color'     => array(
    	            	'rgb' => 'FFFFFF'
        	       	)
            ),
	        'fill' => array(
				'type'	=> PHPExcel_Style_Fill::FILL_SOLID,
				'color'	=> array('argb' => 'FF69B40F')
			),
            'borders' => array(
               	'allborders' => array(
                	'style' => PHPExcel_Style_Border::BORDER_NONE                    
               	)
            ), 
            'alignment' =>  array(
        			'horizontal' => PHPExcel_Style_Alignment::HORIZONTAL_CENTER,
        			'vertical'   => PHPExcel_Style_Alignment::VERTICAL_CENTER,
        			'rotation'   => 0,
        			'wrap'          => TRUE
    		)
        );

		$estiloTituloColumnas = array(
            'font' => array(
                'name'      => 'Arial',
                'bold'      => true,                          
                'color'     => array(
                    'rgb' => 'FFFFFF'
                )
            ),
            'fill' 	=> array(
				'type'		=> PHPExcel_Style_Fill::FILL_GRADIENT_LINEAR,
				'rotation'   => 90,
        		'startcolor' => array(
            		'rgb' => '8BC04A'
        		),
        		'endcolor'   => array(
            		'argb' => 'FF69B40F'
        		)
			),
            'borders' => array(
            	'top'     => array(
                    'style' => PHPExcel_Style_Border::BORDER_MEDIUM ,
                    'color' => array(
                        'rgb' => '263414'
                    )
                ),
                'bottom'     => array(
                    'style' => PHPExcel_Style_Border::BORDER_MEDIUM ,
                    'color' => array(
                        'rgb' => '1F3404'
                    )
                )
            ),
			'alignment' =>  array(
        			'horizontal' => PHPExcel_Style_Alignment::HORIZONTAL_CENTER,
        			'vertical'   => PHPExcel_Style_Alignment::VERTICAL_CENTER,
        			'wrap'          => TRUE
    		));
			
		$estiloInformacion = new PHPExcel_Style();

		$estiloInformacion->applyFromArray(
			array(
           		'font' => array(
               	'name'      => 'Arial',
               	'size'		=> 10,            
               	'color'     => array(
                   	'rgb' => '000000'
               	)
           	),
           	'fill' 	=> array(
				'type'		=> PHPExcel_Style_Fill::FILL_SOLID,
				'color'		=> array('argb' => 'FFE6FFC8')
			),
           	'borders' => array(
               	'left'     => array(
                   	'style' => PHPExcel_Style_Border::BORDER_THIN ,
	                'color' => array(
    	            	'rgb' => '263414'
                   	)
               	)             
           	)
        ));
        $estiloInformacion2 = new PHPExcel_Style();

        $estiloInformacion2->applyFromArray(
			array(
			'font' => array(
               	'name'      => 'Arial',
               	'size'		=> 10,            
               	'color'     => array(
                   	'rgb' => '000000'
               	)
           	),
           	'fill' 	=> array(
				'type'		=> PHPExcel_Style_Fill::FILL_SOLID,
				'color'		=> array('argb' => 'FFFFFFFF')
			),
           	'borders' => array(
               	'left'     => array(
                   	'style' => PHPExcel_Style_Border::BORDER_THIN ,
	                'color' => array(
    	            	'rgb' => '263414'
                   	)
               	)             
           	)
        ));
		 
		$objPHPExcel->getActiveSheet()->getStyle('A1:'.$letraColumnas[count($letraColumnas)-1].'1')->applyFromArray($estiloTituloReporte);
		$objPHPExcel->getActiveSheet()->getStyle('A3:'.$letraColumnas[count($letraColumnas)-1].'3')->applyFromArray($estiloTituloColumnas);		
		//Se agregan los datos de los alumnos
		$j = 4;
		foreach ($resultado as $fila) {
		 			if($j%2){
            			$objPHPExcel->getActiveSheet()->setSharedStyle($estiloInformacion, "A".($j).":".$letraColumnas[count($letraColumnas)-1].($j));
            		}else{
            			$objPHPExcel->getActiveSheet()->setSharedStyle($estiloInformacion2, "A".($j).":".$letraColumnas[count($letraColumnas)-1].($j));
            		}
					$j++;
		}
				
		for($i = 'A'; $i <= $letraColumnas[count($letraColumnas)-1]; $i++){
			$objPHPExcel->setActiveSheetIndex(0)			
				->getColumnDimension($i)->setAutoSize(TRUE);
		}

		$objDrawing = new PHPExcel_Worksheet_HeaderFooterDrawing();
		$objDrawing->setName('PHPExcel logo');
		$objDrawing->setPath('images/128px-HTC_logo.png');
		$objDrawing->setHeight(36);
		$objPHPExcel->getActiveSheet()->getHeaderFooter()->addImage($objDrawing, PHPExcel_Worksheet_HeaderFooter::IMAGE_HEADER_RIGHT);
		$objPHPExcel->getActiveSheet()->getHeaderFooter()->setOddHeader("&L&H&BReporte detallado \nFecha: &D &R&G");
		$objPHPExcel->getActiveSheet()->getHeaderFooter()->setOddFooter('&L&B Reporte desarrollado por Menacorp &RPage &P of &N');


		
		// Se asigna el nombre a la hoja
		$objPHPExcel->getActiveSheet()->setTitle('Detalles');

		// Se activa la hoja para que sea la que se muestre cuando el archivo se abre
		$objPHPExcel->setActiveSheetIndex(0);
		// Inmovilizar paneles 
		//$objPHPExcel->getActiveSheet(0)->freezePane('A4');
		$objPHPExcel->getActiveSheet(0)->freezePaneByColumnAndRow(0,4);

		// Se manda el archivo al navegador web, con el nombre que se indica (Excel2007)
		header('Content-Type: application/vnd.openxmlformats-officedocument.spreadsheetml.sheet');
		header('Content-Disposition: attachment;filename="Reportedeventas.xlsx"');
		header('Cache-Control: max-age=0');

		$objWriter = PHPExcel_IOFactory::createWriter($objPHPExcel, 'Excel2007');
		$objWriter->save('php://output');
		exit;
		
	}
	else{
		print_r('No hay resultados para mostrar');
	}
?>