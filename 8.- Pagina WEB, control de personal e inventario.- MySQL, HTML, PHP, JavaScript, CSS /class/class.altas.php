hp
require_once 'class.db.php';
if(isset($_POST['btn_alta'])||isset($_POST['btn_modificar_directivo']))
require_once 'class/class_imgUpldr.php';


class Altas{
public $jsonEstado;
	function altaDirectivo($user_name,$user_pass,$right_id,$foto,$apellido_paterno,$apellido_materno,$user_nombre,$user_direccion,$user_estado,$user_municipio,$user_telefono,$user_celular,$user_correo,$f_nacimiento,$l_nacimiento,$user_nacionalidad,$user_sexo,$nombre_emergencia1,$numero_emergencia1,$nombre_emergencia2,$numero_emergencia2,$anexo1,$anexo2,$no_seguro_social,$no_cuenta,$usuario_activo){
		global $obj_db;
		$qry="INSERT INTO usuario(user_name,user_pass,id_right,user_foto,apellido_paterno,apellido_materno,user_nombre,user_direccion,user_estado,user_municipio,user_telefono,user_celular,user_correo,f_nacimiento,l_nacimiento,user_nacionalidad,user_sexo,nombre_emergencia1,numero_emergencia1,nombre_emergencia2,numero_emergencia2,anexo1,anexo2,no_seguro_social,no_cuenta,user_activo)"
		." VALUES('".$user_name."','".$user_pass."','".$right_id."','".$foto."','".$apellido_paterno."','".$apellido_materno."','".$user_nombre."','".$user_direccion."','".$user_estado."','".$user_municipio."','".$user_telefono."','".$user_celular."','".$user_correo."','".$f_nacimiento."','".$l_nacimiento."','".$user_nacionalidad."','".$user_sexo."','".$nombre_emergencia1."','".$numero_emergencia1."','".$nombre_emergencia2."','".$numero_emergencia2."','".$anexo1."','".$anexo2."','".$no_seguro_social."','".$no_cuenta."','".$usuario_activo."')";
//print_r($qry);exit;

		$resp=$obj_db->tarea($qry);
		if($resp!=false){
?>
			<script>
				if(confirm("Alta de Directivo exitosa, desea capturar otro usuario?")){
					document.location.href="?command=alta_directivo";
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
	
	function actualizarDirectivo($user_name,$user_pass,$right_id,$foto,$apellido_paterno,$apellido_materno,$user_nombre,$user_direccion,$user_estado,$user_municipio,$user_telefono,$user_celular,$user_correo,$f_nacimiento,$l_nacimiento,$user_nacionalidad,$user_sexo,$nombre_emergencia1,$numero_emergencia1,$nombre_emergencia2,$numero_emergencia2,$user_anexo1,$user_anexo2,$id_usuario,$no_seguro_social,$no_cuenta,$usuario_activo){
		global $obj_db;
		$qry="UPDATE usuario
			  SET user_name='".$user_name."',
			  	  user_pass='".$user_pass."',
			  	  id_right='".$right_id."',
			  	  user_foto='".$foto."',
			  	  apellido_paterno='".$apellido_paterno."',
			  	  apellido_materno='".$apellido_materno."',
			  	  user_nombre='".$user_nombre."',
			  	  user_direccion='".$user_direccion."',
			  	  user_estado='".$user_estado."',
			  	  user_municipio='".$user_municipio."',
			  	  user_telefono='".$user_telefono."',
			  	  user_celular='".$user_celular."',
			  	  user_correo='".$user_correo."',
			  	  f_nacimiento='".$f_nacimiento."',
			  	  l_nacimiento='".$l_nacimiento."',
			  	  user_nacionalidad='".$user_nacionalidad."',
			  	  user_sexo='".$user_sexo."',
			  	  nombre_emergencia1='".$nombre_emergencia1."',
			  	  numero_emergencia1='".$numero_emergencia1."',
			  	  nombre_emergencia2='".$nombre_emergencia2."',
			  	  numero_emergencia2='".$numero_emergencia2."',
			  	  anexo1='".$user_anexo1."',
			  	  anexo2='".$user_anexo2."',
			  	  no_seguro_social='".$no_seguro_social."',
			  	  no_cuenta='".$no_cuenta."',
			  	  user_activo='".$usuario_activo."'
			  WHERE id_usuario='".$id_usuario."'";	
//echo $qry;exit;
		$resp=$obj_db->tarea($qry);
		if($resp!=false){
?>
			<script>
				if(confirm("Los cambios fueron exitosos. Deseas ver más usuarios?")){
					document.location.href="?command=perfil_directivo";
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


	function crearformExtra(){
		foreach( $_POST as $name => $value ) {
			$busqueda = strpos($name, 'form_ext_');
			if($busqueda!==false)
	        	$s[$name]=$value;
		}
		if (isset($s)){
			return json_encode($s);
		}
	}



	function getEstados(){
		global $obj_db;
		$qry="SELECT * FROM estados";
		$resp=$obj_db->consulta($qry);
		if($resp!=false){
			return $resp;	
		}		
		else{
			return false;	
		}

	}

	function getMunicipios($estado){
		global $obj_db;
		$qry="SELECT * FROM municipios WHERE id_estado='".$estado."'";
		$resp=$obj_db->consulta($qry);
		if($resp!=false){
	
			return $resp;	
		}		
		else{
			return false;	
		}

	}


	}

$altas=new Altas();


if(isset($_POST['form_ext'])){
	
}
 

if(isset($_POST['btn_alta']) && $_POST['usuario']!="" && $_POST['contrasena']!="" && $_POST['permiso']!=""){


	$subir = new imgUpldr;
	if (isset($_FILES['Foto1']))
		$subir->init($_FILES['Foto1']);

	$user_name=$_POST['usuario'];
	$user_pass=$_POST['contrasena'];
	$right_id=$_POST['permiso'];
	$user_foto=$subir->_name;
	$apellido_paterno=$_POST['apellido-paterno'];
	$apellido_materno=$_POST['apellido-materno'];
	$nombre=$_POST['nombre'];
	$user_direccion=$_POST['direccion'];
	$user_estado=$_POST['estado'];
	$est=explode("-", $user_estado);
	$estado=$est[count($est)-1];
	$user_municipio=$_POST['municipio'];
	$user_telefono=$_POST['telefono-local'];
	$user_celular=$_POST['telefono-celular'];
	$user_correo=$_POST['correo'];
	$f_nacimiento=$_POST['f-nacimiento'];
	$l_nacimiento=$_POST['l-nacimiento'];
	$nacionalidad=$_POST['nacionalidad'];
	$user_sexo=$_POST['sex'];
	$nombre_emergencia1=$_POST['nombre-emergencia1'];
	$numero_emergencia1=$_POST['numero-emergencia1'];
	$nombre_emergencia2=$_POST['nombre-emergencia2'];
	$numero_emergencia2=$_POST['numero-emergencia2'];
	$anexo1=$_POST['anexo1'];
	$anexo2=$altas->crearformExtra();
	$no_seguro_social=$_POST['no_seguro_social'];
	$no_cuenta =$_POST['no_cuenta'];
	$usuario_activo=isset($_POST["usuario_activo"]) ? 1 : 0;


	//$user_foto=utf8_encode($_FILES['Foto1'].['name']);
	$altas->altaDirectivo($user_name,$user_pass,$right_id,$user_foto,$apellido_paterno,$apellido_materno,$nombre,$user_direccion,$user_estado,$user_municipio,$user_telefono,$user_celular,$user_correo,$f_nacimiento,$l_nacimiento,$nacionalidad,$user_sexo,$nombre_emergencia1,$numero_emergencia1,$nombre_emergencia2,$numero_emergencia2,$anexo1,$anexo2,$no_seguro_social,$no_cuenta,$usuario_activo);

}


if(isset($_POST['btn_modificar_directivo']) && $_POST['usuario']!="" && $_POST['permiso']!=""){

		
	$subir = new imgUpldr;
	if (isset($_FILES['Foto1'])&& isset($_POST['name_foto'])){
		if ($_POST['name_foto']==''){
			$subir->init($_FILES['Foto1']);
			$user_foto=$subir->_name;
		}else{
			$user_foto=$_POST['name_foto'];
		}
	}


	$user_name=$_POST['usuario'];
	$user_pass=$_POST['contrasena'];
	$right_id=$_POST['permiso'];
	//$user_foto=utf8_encode($subir->_name);
	$apellido_paterno=$_POST['apellido-paterno'];
	$apellido_materno=$_POST['apellido-materno'];
	$nombre=$_POST['nombre'];
	$user_direccion=$_POST['direccion'];
	$user_estado=$_POST['estado'];
	$user_municipio=$_POST['municipio'];
	$user_telefono=$_POST['telefono-local'];
	$user_celular=$_POST['telefono-celular'];
	$user_correo=$_POST['correo'];
	$f_nacimiento=$_POST['f-nacimiento'];
	$l_nacimiento=$_POST['l-nacimiento'];
	$nacionalidad=$_POST['nacionalidad'];
	$user_sexo=$_POST['sex'];
	$nombre_emergencia1=$_POST['nombre-emergencia1'];
	$numero_emergencia1=$_POST['numero-emergencia1'];
	$nombre_emergencia2=$_POST['nombre-emergencia2'];
	$numero_emergencia2=$_POST['numero-emergencia2'];
	$anexo1=$_POST['anexo1'];
	$anexo2=$altas->crearformExtra();
	$id_usuario=$_POST['id_usuario'];
	$no_seguro_social=$_POST['no_seguro_social'];
	$no_cuenta =$_POST['no_cuenta'];
	$usuario_activo = isset( $_POST['usuario_activo'] ) ? 1 : 0;
	

	//$user_foto=utf8_encode($_FILES['Foto1'].['name']);
	$altas->actualizarDirectivo($user_name,$user_pass,$right_id,$user_foto,$apellido_paterno,$apellido_materno,$nombre,$user_direccion,$user_estado,$user_municipio,$user_telefono,$user_celular,$user_correo,$f_nacimiento,$l_nacimiento,$nacionalidad,$user_sexo,$nombre_emergencia1,$numero_emergencia1,$nombre_emergencia2,$numero_emergencia2,$anexo1,$anexo2,$id_usuario,$no_seguro_social,$no_cuenta,$usuario_activo);

}




if(isset($_POST['get_estados'])){

	$r=array("<opinion value='0'>Selecciona...</opinion>");
	$consulta = "SELECT id_municipio, nombre FROM municipios WHERE id_estado=".$_POST['get_estados'];
    $result = $obj_db->consulta($consulta);
    if($result!=false){
        foreach($result as $fila){
        	$r[0].="<option value='".$fila['id_municipio']."'>".utf8_encode($fila['nombre']).'</option>';
        	
        }
    }
	echo json_encode($r);

}


if(isset($_POST['get_perfil_usuario'])){
	$r=array();
	$consulta = "SELECT usuario.user_name,
						usuario.user_pass,
						permiso.right_name AS permiso,
						usuario.user_telefono,
						usuario.user_celular,
						usuario.user_correo,
						usuario.user_foto,
						usuario.apellido_paterno,
						usuario.apellido_materno,
						usuario.user_nombre,
						usuario.user_direccion,
						estados.nombre AS enombre,
						municipios.nombre AS mnombre,
						usuario.f_nacimiento,
						usuario.l_nacimiento,
						usuario.user_nacionalidad,
						usuario.user_sexo,
						usuario.nombre_emergencia1,
						usuario.numero_emergencia1,
						usuario.nombre_emergencia2,
						usuario.numero_emergencia2,
						usuario.id_right,
						usuario.user_estado,
						usuario.user_municipio, 
						usuario.anexo1,
						usuario.anexo2,
						usuario.user_activo, 
						usuario.no_seguro_social,
						usuario.no_cuenta
				FROM usuario 
				LEFT JOIN estados ON estados.id_estado=usuario.user_estado 
				LEFT JOIN municipios ON municipios.id_municipio=usuario.user_municipio 
				LEFT JOIN permiso ON permiso.right_id=usuario.id_right  
				WHERE id_usuario=".$_POST['get_perfil_usuario']." LIMIT 1";
	//echo json_encode($consulta);exit;
	
    $result = $obj_db->consulta($consulta);
    if($result!=false){
		$i=0;
        foreach($result as $fila){
        	$fila['enombre']=utf8_encode($fila['enombre']);
        	$fila['mnombre']=utf8_encode($fila['mnombre']);
			foreach($fila as $column){
        		$r[] = $column;
			}
        }
    }
	echo json_encode($r);
}

//Recuperar datos de cac
if(isset($_POST['get_perfil_cac'])){
	$r=array();
	$consulta = "SELECT cac.cac_direccion,
						estados.nombre AS eenombre,
						municipios.nombre AS mnombre,
						cac.cac_telefono,
						cac.foto_cac,
						cac.id_estado,
						cac.id_municipio,
						cac.cac_name,
						cac.anexo2,
						cac.suspendido_cac
				FROM cac 
				LEFT JOIN estados ON cac.id_estado = estados.id_estado
				LEFT JOIN municipios ON cac.id_municipio = municipios.id_municipio 
				WHERE id_cac=".$_POST['get_perfil_cac']." LIMIT 1";
	//echo json_encode($consulta);exit;
	
    $result = $obj_db->consulta($consulta);
    if($result!=false){
		$i=0;
        foreach($result as $fila){
        	$fila['eenombre']=utf8_encode($fila['eenombre']);
        	$fila['mnombre']=utf8_encode($fila['mnombre']);
			foreach($fila as $column){
        		$r[] = $column;
			}
        }
    }
	echo json_encode($r);
}

//Recuperar datos de cac
if(isset($_POST['get_perfil_producto'])){
	$r=array();
	$consulta = "SELECT producto.producto_name, 
						categorias.nombre_categoria,
						producto.producto_descrip,
						producto.producto_foto,
						producto.producto_precio,
						producto.id_categoria,
						producto.anexo2
				FROM producto
				LEFT JOIN categorias
					   ON producto.id_categoria = categorias.id_categoria

				WHERE id_producto=".$_POST['get_perfil_producto']." LIMIT 1";
	//echo json_encode($consulta);exit;
	
    $result = $obj_db->consulta($consulta);
    if($result!=false){
		$i=0;
        foreach($result as $fila){
			foreach($fila as $column){
        		$r[] = $column;
			}
        }
    }
	echo json_encode($r);
}


/*else if(isset($_POST['get_estado'])){
$estados=$altas->getEstados();
?>
<select name="estado" class="form-control" id="estadoSelect" onchange="getMunicipios('estadoSelect')">
<?php
foreach($estados as $row):
?>
<option><?php echo $row['id_estado']."-".utf8_encode($row['nombre']); ?></option>
<?php
endforeach;
?>
</select>
<?php
}
else if(isset($_POST['EstadoOk'])){
$estado=$_POST['EstadoOk'];
$st1=$estado{0};
$st2=$estado{1};
$id_estado=$st1.$st2;
$municipio=$altas->getMunicipios($id_estado);
?>
<select name="municipio" class="form-control" id="municipioSelect">
<?php
foreach($municipio as $row):
?>
<option><?php echo utf8_encode($row['nombre']); ?></option>
<?php
endforeach;
?>
</select>
<?php
}*/
?>

