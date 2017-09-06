<?php
require_once 'class.db.php';
if(!isset($_POST['datos_cac']))
require_once 'class/class_imgUpldr.php';

class AltaR{
	function altaReporte($id_usuario,$id_estado,$id_municipio,$id_cac,$id_categoria,$id_producto,$imei,$inventarioi,$n_ventas,$canal,$fecha,$id_servicio,$total,$semana,$mes,$ano){
	global $obj_db;
	$qry="INSERT INTO ventas(id_usuario,id_estado,id_municipio,id_cac,id_categoria,id_producto,imei,inventarioi,n_ventas,canal,fecha,id_servicio,total,semana,mes,ano)"
	." VALUES('".$id_usuario."','".$id_estado."','".$id_municipio."','".$id_cac."','".$id_categoria."','".$id_producto."','".$imei."','".$inventarioi."','".$n_ventas."','".$canal."','".$fecha."','".$id_servicio."','".$total."','".$semana."','".$mes."','".$ano."')";
	
	//echo json_encode(array($qry));exit;
	$resp=$obj_db->tarea($qry);
	if($resp!=false){
	?>
	<script>
	if(confirm("Reporte enviado exitosamente, desea enviar otro reporte?")){
	document.location.href="index.php?command=reportes_promotor";
	}
	else{
	document.location.href="index.php?command=promotor";
	}
	</script>
	<?php

	return true;
		}
	else{
	return false;
		}
	}

	function altaReporte2($id_usuario,$id_estado,$id_municipio,$id_cac,$id_categoria,$id_producto,$imei,$inventarioi,$n_ventas,$canal,$fecha,$id_servicio,$total,$semana,$mes,$ano){
	global $obj_db;
	$qry="INSERT INTO ventas(id_usuario,id_estado,id_municipio,id_cac,id_categoria,id_producto,imei,inventarioi,n_ventas,canal,fecha,id_servicio,total,semana,mes,ano)"
	." VALUES('".$id_usuario."','".$id_estado."','".$id_municipio."','".$id_cac."','".$id_categoria."','".$id_producto."','".$imei."','".$inventarioi."','".$n_ventas."','".$canal."','".$fecha."','".$id_servicio."','".$total."','".$semana."','".$mes."','".$ano."')";
	
	//echo json_encode(array($qry));exit;
	$resp=$obj_db->tarea($qry);
		if($resp!=false){
			$s['debugg'] = "Se agrego la venta con exito";
			$s['error']=false;
		}
		else{
			$s['debugg']="Hubo un problema al agregar el registro de venta";
			$s['error']=1;
		}
			echo json_encode($s);exit;
	}


	function altaFoto($id_usuario, $id_cac, $foto_cac_name, $fecha, $id_fotos_clasificacion){
	global $obj_db;
	$qry="INSERT INTO fotos_cac(id_usuario,id_cac,foto_cac_name,fecha, id_fotos_clasificacion)"
	." VALUES('".$id_usuario."','".$id_cac."','".$foto_cac_name."','".$fecha."','".$id_fotos_clasificacion."')";
	
	$resp=$obj_db->tarea($qry);
	if($resp!=false){
	?>
	<script>
	if(confirm("La fotografía se ha enviado exitosamente, desea enviar otra imagen?")){
	document.location.href="index.php?command=fotos_promotor";
	}
	else{
	document.location.href="index.php?command=promotor";
	}
	</script>
	<?php

	return true;
		}
	else{
	return false;
		}
	}

	function altaFotoAuditor($id_usuario, $id_cac, $id_encargado, $foto_cac_name, $fecha, $id_fotos_clasificacion){
	global $obj_db;
	$qry="INSERT INTO fotos_cac(id_usuario,id_cac,id_encargado,foto_cac_name,fecha, id_fotos_clasificacion)"
	." VALUES('".$id_usuario."','".$id_cac."','".$id_encargado."','".$foto_cac_name."','".$fecha."','".$id_fotos_clasificacion."')";
	
	$resp=$obj_db->tarea($qry);
	if($resp!=false){
	?>
	<script>
	if(confirm("La fotografía se ha enviado exitosamente, desea enviar otra imagen?")){
	document.location.href="index.php?command=subir_fotos_auditor";
	}
	else{
	document.location.href="index.php?command=auditor";
	}
	</script>
	<?php

	return true;
		}
	else{
	return false;
		}
	}


	function altaCac($cac_name, $cac_direccion, $id_estado, $id_municipio, $cac_telefono, $foto_cac, $fecha_cac, $anexo2, $suspendido_cac){
		global $obj_db;
		$qry="INSERT INTO cac(cac_name,cac_direccion,id_estado,id_municipio,cac_telefono,foto_cac,fecha_cac,anexo2, suspendido_cac)"
		." VALUES('".$cac_name."','".$cac_direccion."','".$id_estado."','".$id_municipio."','".$cac_telefono."','".$foto_cac."','".$fecha_cac."','".$anexo2."','".$suspendido_cac."')";
	
		$resp=$obj_db->tarea($qry);
		if($resp!=false){
	?>
			<script>
				if(confirm("El registro del nuevo CAC ha sido exito, desea enviar otra solicitud?")){
					document.location.href="index.php?command=alta_cac";
				}
				else{
					document.location.href="index.php?command=directivo";
				}
			</script>
	<?php

			return true;
		}
		else{
			return false;
		}
	}

	function acatualizarCac($cac_name, $cac_direccion, $id_estado, $id_municipio, $cac_telefono, $foto_cac, $fecha_cac, $anexo2, $id_cac,$tienda_activa){
		global $obj_db;
		$qry="UPDATE cac
			  SET cac_name='".$cac_name."',
			  	  cac_direccion='".$cac_direccion."',
			  	  id_estado='".$id_estado."',
			  	  id_municipio='".$id_municipio."',
			  	  cac_telefono='".$cac_telefono."',
			  	  foto_cac='".$foto_cac."',
			  	  fecha_cac='".$fecha_cac."',
			  	  anexo2='".$anexo2."',
			  	  suspendido_cac='".$tienda_activa."'
			  WHERE id_cac='".$id_cac."'";

		//echo json_encode($qry);exit;

		$resp=$obj_db->tarea($qry);
		if($resp!=false){
?>
			<script>
				if(confirm("Los cambios fueron exitosos. Deseas ver más CACs?")){
					document.location.href="?command=perfil_cac";
				}
				else{
					document.location.href="?command=ventas";
				}
			</script>
	<?php

			return true;
		}
		else{
			return false;
		}
	}

	function altaProducto($producto_name, $id_categoria, $producto_descrip, $producto_foto, $producto_precio, $anexo2){
		global $obj_db;
		$qry="INSERT INTO producto(producto_name, id_categoria, producto_descrip, producto_foto, producto_precio, anexo2)"
		." VALUES('".$producto_name."','".$id_categoria."','".$producto_descrip."','".$producto_foto."','".$producto_precio."','".$anexo2."')";
	
		$resp=$obj_db->tarea($qry);
		if($resp!=false){
	?>
			<script>
				if(confirm("El registro del nuevo Producto ha sido exito, desea enviar otra solicitud?")){
					document.location.href="index.php?command=alta_producto";
				}
				else{
					document.location.href="index.php?command=directivo";
				}
			</script>
	<?php

			return true;
		}
		else{
			return false;
		}
	}

	function actualizarProducto($producto_name,$id_categoria, $producto_descrip, $producto_foto, $producto_precio, $anexo2, $id_producto){
		global $obj_db;
		$qry="UPDATE producto
			  SET producto_name='".$producto_name."', 
			  	  id_categoria='".$id_categoria."',
			  	  producto_descrip='".$producto_descrip."', 
			  	  producto_foto='".$producto_foto."', 
			  	  producto_precio='".$producto_precio."',
			  	  anexo2='".$anexo2."'
			  WHERE id_producto='".$id_producto."'";

			//echo json_encode($qry);exit;

		$resp=$obj_db->tarea($qry);
		if($resp!=false){
	?>
			<script>
				if(confirm("Los cambios fueron exitosos. Deseas ver más Productos?")){
					document.location.href="index.php?command=perfil_producto";
				}
				else{
					document.location.href="index.php?command=ventas";
				}
			</script>
	<?php

			return true;
		}
		else{
			return false;
		}
	}

	function crearformExtra(){
		foreach( $_POST as $name => $value ) {
			$busqueda = strpos($name, 'form_ext_');
			if($busqueda!==false)
	        	$s[$name]=$value;
		}
		return json_encode($s);
	}


}


$altas=new AltaR();

//if(isset($_POST['btn_enviar_reporte']) && $_POST['n_ventas']!="" && $_POST['inventarioi']!="" && $_POST['producto']!="0"){
if(isset($_POST['btn_enviar_reporte'])){

	$id_usuario		= $_SESSION['user_id'];
	$id_estado		= isset($_POST['estado'])				?$_POST['estado']				:0;
	$id_municipio	= isset($_POST['municipio'])			?$_POST['municipio']			:0;
	$id_cac			= isset($_POST['cacR'])					?$_POST['cacR']					:0;
	$id_categoria	= isset($_POST['gama'])					?$_POST['gama']					:0;
	$id_producto	= isset($_POST['equipo'])				?$_POST['equipo']				:0;
	$imei			= isset($_POST['imei'])					?$_POST['imei']					:0;
	$inventarioi	= isset($_POST['inventario-inicial'])	?$_POST['inventario-inicial']	:0;
	$n_ventas		= isset($_POST['ventas'])				?$_POST['ventas']				:0;
	$canal			= isset($_POST['canal'])				?$_POST['canal']				:0;
	$fecha 			= Date('Ymd');
	$id_servicio	= isset($_POST['servicio'])				?$_POST['servicio']				:0;
	$total			= $_POST['inventario-inicial']-$_POST['ventas'];
	$semana 		= '';
	$mes			= Date('m');
	$ano 			= Date('Y');

	//$user_foto=utf8_encode($_FILES['Foto1'].['name']);
	$altas->altaReporte($id_usuario,$id_estado,$id_municipio,$id_cac,$id_categoria,$id_producto,$imei,$inventarioi,$n_ventas,$canal,$fecha,$id_servicio,$total,$semana,$mes,$ano);

}

if(isset($_POST['btn_enviar_foto_cac'])){

	$subir = new imgUpldr;
	if (isset($_FILES['Foto1'])){
		$subir->_dest='uploads/cacs/';
		$subir->init($_FILES['Foto1']);
	}

	$id_usuario=$_SESSION['user_id'];
	$id_cac=$_POST['cac'];
	$foto_cac_name=$subir->_name;
	$fecha=date('Y-m-d H:i:s');
	$id_fotos_clasificacion=$_POST['id_fotos_clasificacion'];

$altas->altaFoto($id_usuario, $id_cac, $foto_cac_name, $fecha, $id_fotos_clasificacion);

}

if(isset($_POST['btn_enviar_foto_auditor'])){

	$subir = new imgUpldr;
	if (isset($_FILES['Foto1'])){
		$subir->_dest='uploads/cacs/';
		$subir->init($_FILES['Foto1']);
	}

	$id_usuario=$_SESSION['user_id'];
	$id_cac=$_POST['cac'];
	$id_encargado=$_POST['encargado'];
	$foto_cac_name=$subir->_name;
	$fecha=date('Y-m-d H:i:s');
	$id_fotos_clasificacion=$_POST['id_fotos_clasificacion'];

$altas->altaFotoAuditor($id_usuario, $id_cac, $id_encargado, $foto_cac_name, $fecha, $id_fotos_clasificacion);

}

if(isset($_POST['btn_enviar_alta_cac'])){

	$subir = new imgUpldr;
	if (isset($_FILES['Foto1'])){
		$subir->_dest='uploads/cacs/';
		$subir->init($_FILES['Foto1']);
	}

	$cac_name=$_POST['nombre-cac'];
	$cac_direccion=$_POST['direccion-cac'];
	$id_estado=$_POST['estado'];
	$id_municipio=$_POST['municipio'];
	$cac_telefono=$_POST['telefono-cac'];
	$foto_cac=$subir->_name;
	$fecha_cac=date('Y-m-d H:i:s');
	$anexo2=$altas->crearformExtra();
	$suspendido_cac = isset($_POST['tienda_activa']) ? 0 : 1;

$altas->altaCac($cac_name, $cac_direccion, $id_estado, $id_municipio, $cac_telefono, $foto_cac, $fecha_cac, $anexo2, $suspendido_cac);

}

if(isset($_POST['btn_enviar_modificar_cac'])){

	$subir = new imgUpldr;
		if ($_POST['name_foto']==''){
			$subir->_dest='uploads/cacs/';
			$subir->init($_FILES['Foto1']);
			$foto_cac=$subir->_name;
		}else{
			$foto_cac=$_POST['name_foto'];
		}

	$cac_name=$_POST['nombre-cac'];
	$cac_direccion=$_POST['direccion-cac'];
	$id_estado=$_POST['estado'];
	$id_municipio=$_POST['municipio'];
	$cac_telefono=$_POST['telefono-cac'];
	//$foto_cac=utf8_encode($subir->_name);
	$fecha_cac=date('Y-m-d H:i:s');
	$anexo2=$altas->crearformExtra();
	$tienda_activa = isset( $_POST['tienda_activa'] ) ? 0 : 1;
	$id_cac=$_POST['id_cac'];

$altas->acatualizarCac($cac_name, $cac_direccion, $id_estado, $id_municipio, $cac_telefono, $foto_cac, $fecha_cac, $anexo2, $id_cac,$tienda_activa);

}

if(isset($_POST['btn_enviar_alta_producto'])){

	$subir = new imgUpldr;
	if (isset($_FILES['Foto1'])){
		$subir->_dest='uploads/productos/';
		$subir->init($_FILES['Foto1']);
	}

	$producto_name=$_POST['nombre-producto'];
	$id_categoria=$_POST['gama'];
	$producto_descrip=$_POST['descripcion-producto'];
	$producto_foto=$subir->_name;
	$producto_precio=$_POST['precio-producto'];
	$anexo2=$altas->crearformExtra();
	
$altas->altaProducto($producto_name, $id_categoria, $producto_descrip, $producto_foto, $producto_precio, $anexo2);

}

if(isset($_POST['btn_enviar_modificar_producto'])){

	$subir = new imgUpldr;
		if ($_POST['name_foto']==''){
			$subir->_dest='uploads/productos/';
			$subir->init($_FILES['Foto1']);
			$producto_foto=$subir->_name;
		}else{
			$producto_foto=$_POST['name_foto'];
		}

	$producto_name=$_POST['nombre-producto'];
	$id_categoria=$_POST['gama'];
	$producto_descrip=$_POST['descripcion-producto'];
	//$producto_foto=utf8_encode($subir->_name);
	$producto_precio=$_POST['precio-producto'];
	$anexo2=$altas->crearformExtra();
	$id_producto=$_POST['id_producto'];
	
$altas->actualizarProducto($producto_name, $id_categoria, $producto_descrip, $producto_foto, $producto_precio, $anexo2, $id_producto );

}

if(isset($_POST['datos_cac'])&&!isset($_POST['funcion'])){
	$r=array();
	$consulta = "SELECT cac.id_estado, cac.id_municipio, municipios.nombre AS nombrem, estados.nombre AS nombree FROM cac LEFT JOIN municipios ON cac.id_municipio=municipios.id_municipio LEFT JOIN estados ON cac.id_estado=estados.id_estado WHERE id_cac=".$_POST['datos_cac'];
    
    $result = $obj_db->consulta($consulta);
    if($result!=false){
        foreach($result as $fila){
        	$r[0]=utf8_encode($fila['nombree']);
        	$r[1]=utf8_encode($fila['nombrem']);
        	$r[2]=$fila['id_estado'];
        	$r[3]=$fila['id_municipio'];
        }
    }

	echo json_encode($r);
}

//if(isset($_POST['btn_enviar_reporte']) && $_POST['n_ventas']!="" && $_POST['inventarioi']!="" && $_POST['producto']!="0"){
if(isset($_POST['funcion'])){
	if ($_POST['funcion']=='guardar_reporte'){

		if(!isset($_SESSION)) { session_start(); }

		$id_usuario		= $_SESSION['user_id'];
		$id_estado		= isset($_POST['estado'])				?$_POST['estado']				:0;
		$id_municipio	= isset($_POST['municipio'])			?$_POST['municipio']			:0;
		$id_cac			= isset($_POST['cacR'])					?$_POST['cacR']					:0;
		$id_categoria	= isset($_POST['gama'])					?$_POST['gama']					:0;
		$id_producto	= isset($_POST['equipo'])				?$_POST['equipo']				:0;
		$imei			= isset($_POST['imei'])					?$_POST['imei']					:0;
		$inventarioi	= isset($_POST['inventario-inicial'])	?$_POST['inventario-inicial']	:0;
		$n_ventas		= isset($_POST['cantidad'])				?$_POST['cantidad']				:0;
		$canal			= isset($_POST['canal'])				?$_POST['canal']				:0;
		$fecha 			= Date('Ymd');
		$id_servicio	= isset($_POST['servicio'])				?$_POST['servicio']				:0;
		$total			= isset($_POST['precio_total'])					?$_POST['precio_total']				:0;
		$semana 		= '';
		$mes			= Date('m');
		$ano 			= Date('Y');

		//$user_foto=utf8_encode($_FILES['Foto1'].['name']);
		$alta_reporte = $altas->altaReporte2($id_usuario,$id_estado,$id_municipio,$id_cac,$id_categoria,$id_producto,$imei,$inventarioi,$n_ventas,$canal,$fecha,$id_servicio,$total,$semana,$mes,$ano);
	
		
	}
}


?>

