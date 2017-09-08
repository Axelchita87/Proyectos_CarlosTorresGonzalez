<?php

	require_once 'class/class.db.php';

    

    global $obj_db;
	$filtro = ' WHERE 1 ';

    	function f_filtro($x,$v){
    		$f='';
			if ($x=='fecha_i'&&$_GET['fecha_f']==''&&$v!=''){$f .= " AND ventas.fecha='".$v."'";}
			if ($x=='fecha_f'&&$_GET['fecha_i']!=''&&$v!=''){$f .= " AND ventas.fecha>='".str_replace("/", "", $_GET['fecha_i'])."' and ventas.fecha<='".$v."'";}
			if ($x=='promotor'&&$v!=0){$f .= ' AND ventas.id_usuario='.$v;}
			if ($x=='cac'&&$v!=0){$f .= ' AND ventas.id_cac='.$v;}
			if ($x=='producto'&&$v!=0){$f .= ' AND ventas.id_producto='.$v;}
			if ($x=='estado'&&$v!=0){$f .= ' AND ventas.id_estado='.$v;}
			if ($x=='municipio'&&$v!=0){$f .= ' AND ventas.id_usuario='.$v;}
			
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
			$filtro .= f_filtro('promotor',$_GET['promotor']);
		}
	}
	if(isset($_GET['estado'])){
		if($_GET['estado']!='0'){
			$filtro .= f_filtro('estado',$_GET['estado']);
		}
	}
	if(isset($_GET['cac'])){
		if($_GET['cac']!=''){
			$filtro .= f_filtro('cac',$_GET['cac']);
		}
	}

	//echo json_encode($this->intervalos);exit;
			
	//Datos
			$consulta = "SELECT ventas.id_ventas, ventas.fecha, ventas.id_producto, IFNULL(producto.producto_name,'') AS producto_name, ventas.id_usuario, IFNULL(usuario.user_name,'') AS user_name, IFNULL(ventas.imei,'') AS user_correo, ventas.id_servicio, IFNULL(cac.cac_name,'') AS cac_name, IFNULL(municipios.nombre,'') AS cmunicipio, ventas.inventarioi, ventas.n_ventas, ventas.total, ventas.total, cac.anexo2 AS cac_anexo2
					 	 FROM ventas
					 	 LEFT JOIN usuario
					 			 ON ventas.id_usuario=usuario.id_usuario
					 	 LEFT JOIN producto
					 			 ON ventas.id_producto=producto.id_producto 
					 	 LEFT JOIN municipios
					 			 ON ventas.id_municipio=municipios.id_municipio 					 			 
					 	 LEFT JOIN cac
					 			 ON ventas.id_cac=cac.id_cac ".

					 	 $filtro." 					 
					 	 ORDER BY ventas.fecha ASC";

					 	 //print_r($consulta);exit;
	
	$resultado = $obj_db->consulta($consulta);
	if($resultado!=false){						
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
		$titulosColumnas = array(' No. Venta ',' Fecha ',' Producto ',' Promotor ',' IMEI ',' Servicio ',' Tiendas ', 'Ciudad de Tienda', 'Region', ' Cantidad ',' Ventas ',' Stock ');
		$letraColumnas = array('A','B','C','D','E','F','G','H','I','J','K','L');

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
            		->setCellValue($letraColumnas[11].'3',  $titulosColumnas[11]);
		
		//Se agregan los datos de los alumnos
		$i = 4;
		foreach ($resultado as $fila) {
					//Reescribir el campo de servicios
					if ($fila['id_servicio']=='0'){ $fila['id_servicio'] = 'N/A';}
					if ($fila['id_servicio']=='1'){ $fila['id_servicio'] = 'Renta';}
					if ($fila['id_servicio']=='2'){ $fila['id_servicio'] = 'Amigo Kit';}

					//Obtener campos personalizados
					$cac_ce=aliasAndValor($fila['cac_anexo2'], '2');
					//print_r($cac_ce);exit;

		 	$objPHPExcel->setActiveSheetIndex(0)
        		    ->setCellValue($letraColumnas[0].$i,  $fila['id_ventas'])
		            ->setCellValue($letraColumnas[1].$i,  $fila['fecha'])
        		    ->setCellValue($letraColumnas[2].$i,  $fila['producto_name'])
            		->setCellValue($letraColumnas[3].$i, $fila['user_name'])
            		->setCellValue($letraColumnas[4].$i, $fila['user_correo'])
            		->setCellValue($letraColumnas[5].$i, $fila['id_servicio'])
            		->setCellValue($letraColumnas[6].$i, $fila['cac_name'])
            		->setCellValue($letraColumnas[7].$i, $fila['cmunicipio'])
            		->setCellValue($letraColumnas[8].$i, $cac_ce['region_cac'])
            		->setCellValue($letraColumnas[9].$i, $fila['inventarioi'])
            		->setCellValue($letraColumnas[10].$i, $fila['n_ventas'])
            		->setCellValue($letraColumnas[11].$i, $fila['total']);
					$i++;
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