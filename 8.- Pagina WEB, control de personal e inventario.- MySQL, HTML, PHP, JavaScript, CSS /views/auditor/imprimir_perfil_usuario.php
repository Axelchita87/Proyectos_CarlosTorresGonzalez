<?php
require_once 'class/class.db.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='auditor'){

//Inicio script PDF


ob_start();

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
						usuario.anexo1 
				FROM usuario 
				LEFT JOIN estados ON estados.id_estado=usuario.user_estado 
				LEFT JOIN municipios ON municipios.id_municipio=usuario.user_municipio 
				LEFT JOIN permiso ON permiso.right_id=usuario.id_right  
				WHERE id_usuario=".$_POST['usuario']." LIMIT 1";
	//echo json_encode($consulta);exit;
	
    $result = $obj_db->consulta($consulta);
    if($result!=false){
		$i=0;
        foreach($result as $fila){
        	$fila['enombre']=utf8_encode($fila['enombre']);
        	$fila['mnombre']=utf8_encode($fila['mnombre']);



$usuario = isset($fila['user_name'])&&$fila['user_name']!=''?								$fila['user_name']:"No disponible";
$contrasena = isset($fila['contrasena'])&&$fila['contrasena']!=''?							"******":"No disponible";
$permiso = isset($fila['permiso'])&&$fila['permiso']!=''?									$fila['permiso']:"No disponible";
$telefono_local = isset($fila['user_telefono'])&&$fila['user_telefono']!=''?				$fila['user_telefono']:"No disponible";
$telefono_celular = isset($fila['user_celular'])&&$fila['user_celular']!=''?				$fila['user_celular']:"No disponible";
$correo = isset($fila['user_correo'])&&$fila['user_correo']!=''?							$fila['user_correo']:"No disponible";
$foto = isset($fila['user_foto'])&&$fila['user_foto']!=''?									"/uploads/usuarios/thumbs/".$fila['user_foto']:"No disponible";
$apellido_paterno = isset($fila['apellido_paterno'])&&$fila['apellido_paterno']!=''?		$fila['apellido_paterno']:"No disponible";
$apellido_materno = isset($fila['apellido_materno'])&&$fila['apellido_materno']!=''?		$fila['apellido_materno']:"No disponible";
$nombre = isset($fila['user_nombre'])&&$fila['user_nombre']!=''?							$fila['user_nombre']:"No disponible";
$direccion = isset($fila['user_direccion'])&&$fila['user_direccion']!=''?					$fila['user_direccion']:"No disponible";
$estado = isset($fila['enombre'])&&$fila['enombre']!=''?									$fila['enombre']:"No disponible";
$municipio = isset($fila['mnombre'])&&$fila['mnombre']!=''?									$fila['mnombre']:"No disponible";
$f_nacimiento = isset($fila['f_nacimiento'])&&$fila['f_nacimiento']!=''?					$fila['f_nacimiento']:"No disponible";
$l_nacimiento = isset($fila['l_nacimiento'])&&$fila['l_nacimiento']!=''?					$fila['l_nacimiento']:"No disponible";
$nacionalidad = isset($fila['user_nacionalidad'])&&$fila['user_nacionalidad']!=''?			$fila['user_nacionalidad']:"No disponible";
$genero = isset($fila['user_sexo'])&&$fila['user_sexo']!=''?								$fila['user_sexo']:"No disponible";
if($genero=='1'){$genero="Hombre";}
if($genero=='2'){$genero="Mujer";}
$nombre_emergencia1 = isset($fila['nombre_emergencia1'])&&$fila['nombre_emergencia1']!=''?	$fila['nombre_emergencia1']:"No disponible";
$numero_emergencia1 = isset($fila['numero_emergencia1'])&&$fila['numero_emergencia1']!=''?	$fila['numero_emergencia1']:"No disponible";
$nombre_emergencia2 = isset($fila['nombre_emergencia2'])&&$fila['nombre_emergencia2']!=''?	$fila['nombre_emergencia1']:"No disponible";
$numero_emergencia2 = isset($fila['numero_emergencia2'])&&$fila['numero_emergencia2']!=''?	$fila['numero_emergencia1']:"No disponible";
$anexo1 = isset($fila['anexo1'])&&$fila['anexo1']!=''?										$fila['anexo1']:"No disponible";

        }
    }

    
?> 


<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en"> 
<head> 
<title>Impresión</title> 

<style type="text/css">

#header,
#footer {color: #aaa;font-size: 0.9em;}
#header{border-bottom: .5px solid #69b40f;height:1.5cm;}
#footer {border-top: .5px solid #69b40f;color:#69b40f;}
#header table,#footer table {width: 100%;border-collapse: collapse;border: none;padding:0;}
#header td,#footer td {padding: 0;width: 50%;}
.page-number {text-align: center;}
#logo-encabezado{height:50px;}

</style>
<link href="css/estilos_ep.css" type="text/css" rel="stylesheet">


<style>
body {font-family: "Arial";font-size: 14px;color: #333;line-height: 1.42857;}
.caja-campos {margin: 10px;position: relative;}
.col-md-10 {float: left;min-height: 1px;padding-left: 15px;padding-right: 15px;position: relative;}
.label-h {background-color: #69b40f;color: #fff;padding: 3px;text-align: center; font-weight: bold}
.cont-form {border: none;margin: 0 auto;}
#contenedor {padding: 0;}
.col-izq{width: 75%;}
.label {font-weight: bold;padding:.05cm;}
.col-md-2 {width: 20%;float: left;}
.campo {background-color: #eee;min-height: 20px; padding:.05cm;font-size: 12px;}
.col-md-5 {width: 60%;float: left;}
.grid{margin-top: .2cm;}
.col-md-6{width:50%;float:left;}
.col-md-4{width:38%;float:left;}
.col-md-8{width:57%;float:left;}
.col-md-7 {width: 58.3333%;float:left;}
.col-md-9 {width: 73%;float:left;}
.col-md-3 {width: 23%;float:left;}
</style>

</head> 
<body> 

<div id="contenedor">

			<div class="cont-form col-md-10" id="">

					<br>
					<div class="label-h">Datos generales</div>
					<div class="caja-campos row">
						
						<div class="col-md-10 col-izq">	
							<div class="row grid">
								<div class="label col-md-2">Usuario:</div>
								<div id="usuario" name="usuario" class="campo col-md-5"><?php echo $usuario; ?></div>	 								
    						</div>

    						<div class="row grid">
    							<div class="label col-md-2">Contraseña:</div>
								<div class="campo col-md-5" id="contrasena" name="contrasena"><?php echo $contrasena; ?></div>								
							</div>

							<div class="row grid">
								<div class="label col-md-2">Permiso:</div>
								<div class="campo col-md-5" id="permiso" name="permiso"><?php echo $permiso; ?></div>								
							</div>

							<div class="row grid">
								<div class="label col-md-2">Tel. de Casa:</div>
								<div id="telefono-local" name="telefono-local" class="campo col-md-5"><?php echo $telefono_local; ?></div>								
							</div>

							<div class="row grid">
								<div class="label col-md-2">Celular:</div>
								<div id="telefono-celular" name="telefono-celular" class="campo col-md-5"><?php echo $telefono_celular; ?></div>								
							</div>

							<div class="row grid">
								<div class="label col-md-2">Correo(s):</div>	
								<div id="correo" name="correo" class="campo col-md-5"><?php echo $correo; ?></div>								
							</div>

						</div>
                        
                        <div class="col-md-2 col-der">
							<div id="marco-foto">
								<div style="" class="label"> Foto:</div>
								<div id="cont-image_preview"><img id="foto_preview" src="<?php echo $foto; ?>" style="display: none;"></div>
							</div>
						</div>

					</div>
					
					

					<div class="label-h">Nombre</div>
					<div class="caja-campos  row">
						<div class="col-md-12 col-sm-12 col-xs-12">
							<div class="row grid">
								<div class="label col-md-2 col-sm-2 col-xs-2">Apellido Paterno</div>
								<div type="campo" placeholder="Apellido Paterno" name="apellido-paterno" class="campo col-md-5"><?php echo $apellido_paterno; ?></div>
							</div>
	 						<div class="row grid">
		 						<div class="label col-md-2 col-sm-2 col-xs-2">Apellido Materno</div>
	 							<div type="campo" placeholder="Apellido Materno" name="apellido-materno" class="campo col-md-5"><?php echo $apellido_materno; ?></div>
							</div>
							<div class="row grid">
								<div class="label col-md-2 col-sm-2 col-xs-2">Nombre(s)</div>
								<div type="campo" placeholder="Nombre" name="nombre" class="campo col-md-5"><?php echo $nombre; ?></div>
							</div>
						</div>
					</div>		

					<div class="label-h">Dirección actual</div>
					<div class="caja-campos  row">
						<div class="col-md-12 col-sm-12 col-xs-12">
							<div class="row grid">
								<div class="label col-md-2">Calle, Número</div>
								<div id="direccion" name="direccion" class="campo col-md-5"><?php echo $direccion; ?></div>
								
							</div>	

							<div class="row grid">
								<div style="" class="label col-md-2">Estado:</div>
								<div class="campo col-md-5" id="estado" name="estado"><?php echo $estado; ?></div>
                        		
                        	</div>

                        	<div class="row grid">
                        		<div style="" class="label col-md-2">Municipio:</div>
								<div id="municipio" name="municipio" class="campo col-md-5"><?php echo $municipio; ?></div>
								
							</div>
						</div>
					</div>
					
					

					<div class="label-h">Otros</div>
					<div class="caja-campos row">
						<div class="col-md-12 col-sm-12 col-xs-12">
							<div class="row grid" >
								<div class="col-md-6"> 
									<div class="label col-md-4">Fecha de Nacimiento:</div>
									<div name="f-nacimiento" class="campo col-md-8"><?php echo $f_nacimiento; ?></div>
								</div>
								<div class="col-md-6">
									<div class="label col-md-4">Lugar de Nacimiento:</div>
									<div name="l-nacimiento" class="campo col-md-8"><?php echo $l_nacimiento; ?></div>
								</div>
								
							</div>

							<div class="row grid">
								<div class="col-md-6 col-sm-6">
									<div class="label col-md-4">Nacionalidad:</div>
									<div name="nacionalidad" class="campo col-md-8"><?php echo $nacionalidad; ?></div>
								</div>
								<div class="col-md-6 col-sm-6">
									<div class="label col-md-4">Genero: </div>
									<div id="genero" name="genero" class="campo col-md-8"><?php echo $genero; ?></div>
								</div>
							</div>
							
							<div class="label">Encaso de emergencia llamar a: </div>
							<div class="row grid">	
								<div class="col-md-8">		
									<div class="label col-md-3">Nombre </div>			
									<div name="nombre-emergencia1" class="campo col-md-9"><?php echo $nombre_emergencia1; ?></div>
								</div>
								<div class="col-md-4">
									<div class="label col-md-3">Teléfono: </div>
									<div name="numero-emergencia1" class="campo col-md-9"><?php echo $numero_emergencia1; ?></div>
								</div>
								
							</div>
							
							<div class="row grid">
								<div class="col-md-8">
									<div class="label col-md-3">Nombre </div>
									<div name="nombre-emergencia2" class="campo col-md-9"><?php echo $nombre_emergencia2; ?></div>
								</div>
								<div class="col-md-4">
									<div class="label col-md-3">Teléfono: </div>	
									<div name="numero-emergencia2" class="campo col-md-9"><?php echo $numero_emergencia2; ?></div>
								</div>
							</div>	
							<div class="row grid">
								<div class="col-md-12">
									<div class="label col-md-3">Comentarios: </div>
									<div type="campo" placeholder="Anexo1" id="anexo1" name="anexo1" class="campo col-md-9"><?php echo $anexo1; ?></div>
								</div>								
							</div>							
						</div>
					</div>
			
					
					<br>
			</div>
		</div>



</body> 
</html> 

<?php

$html = ob_get_contents();
ob_end_clean();

$mpdf = new mPDF('',    // mode - default ''
'Letter',    // format - A4, for example, default ''
0,     // font size - default 0
'',    // default font family
15,    // margin_left
15,    // margin right
28,    // margin top
16,    // margin bottom
9,     // margin header
9,     // margin footer
'L');  // L - landscape, P - portrait

//Configuración

//$mpdf->setAutoTopMargin="pad";
//$mpdf->setAutoBottomMargin="pad";

//Documento

$mpdf->SetHTMLHeader('
<div id="header">
  <table>
    <tr>
      <td><strong>Perfíl de Usuarios<strong></td>
      <td style="text-align: right;"><img id="logo-encabezado" src="images/logoP.jpg"></td>
    </tr>
  </table>
</div>
');
$mpdf->SetHTMLFooter('
<div id="footer">
  <div class="page-number">{PAGENO}</div>
</div>
  ');
$mpdf->WriteHTML($html);

$mpdf->Output();

exit;

?>


<?php

//Fin Script PDF

}
else{
?>
<script>
alert("tu no tienes permiso para ver este contenido");
document.location.href="index.php?command=home";
</script>
<?php
}
?>