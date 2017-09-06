<?php
require_once 'class.db.php';




class Formularios{

	function altaFormulario($f_alias,$f_label,$f_tipo,$f_default,$id_seccion){
		global $obj_db;
		$qry="INSERT INTO form_extra(f_alias,f_label,f_tipo,f_default,id_seccion)"
		." VALUES('".$f_alias."','".$f_label."','".$f_tipo."','".$f_default."','".$id_seccion."')";
	
		
		$resp=$obj_db->tarea($qry);
		if($resp!=false){
			return false;
		}
		else{
			echo (true);
			return true;
		}
	}

	function altaPregunta($f_alias,$f_label,$f_tipo,$f_default,$id_seccion,$id_form){
		global $obj_db;

		$qry="SELECT f_default 
				 FROM form_extra 
		      WHERE id_form='".$id_form."'";		

		$resp=$obj_db->consulta($qry);

		if($resp!=false){
			foreach($resp as $fila){
				
						$preguntas = array('a'=>$f_alias,'l'=>$f_label,'t'=>$f_tipo,'d'=>$f_default,'s'=>$id_seccion);
					
					if($fila['f_default']=='')
						$array_json = json_encode($preguntas);
					else
						$array_json = $fila['f_default'].",".json_encode($preguntas);
				
				$qry="UPDATE form_extra 
				  	SET f_default='".$array_json."' 
		      	  	WHERE id_form='".$id_form."'";
	
				//$qry="INSERT INTO form_extra(f_alias,f_label,f_tipo,f_default,id_seccion)"
				//." VALUES('".$f_alias."','".$f_label."','".$f_tipo."','".$f_default."','".$id_seccion."')";
	
				$resp=$obj_db->tarea($qry);
				if($resp!=false){
					return false;
				}
				else{
					echo (true);
					return true;
				}

				return false;
			}
		}
		else{
			echo (true);
			return true;
		}

		
	}
	
	function actualizarFormulario($id_form,$f_alias,$f_label,$f_tipo,$f_default){
		global $obj_db;
		$qry="UPDATE form_extra
			  SET f_alias='".$f_alias."',
			  	  f_label='".$f_label."',
			  	  f_tipo='".$f_tipo."',
			  	  f_default='".$f_default."' 			  	  
			  WHERE id_form='".$id_form."'";	

		//echo json_encode($qry);exit;

		$resp=$obj_db->tarea($qry);
		if($resp!=false){
			return false;
		}
		else{
			echo (true);
			return true;
		}
	}

	function actualizarPregunta($id_form,$f_alias,$f_label,$f_tipo,$f_default,$indice_p){
		global $obj_db;
		$qry="SELECT f_default, id_form   
			  FROM form_extra 
			  WHERE id_form='".$id_form."' 
			  ORDER BY f_alias";

		$resp=$obj_db->consulta($qry);

		if($resp!=false){

			foreach($resp as $fila){
				//decodificar json
				$preguntas = json_decode("[".$fila['f_default']."]");

				if (count($preguntas)>0){
					$preguntas[$indice_p]->a=$f_alias;
					$preguntas[$indice_p]->l=$f_label;
					$preguntas[$indice_p]->t=$f_tipo;
					$preguntas[$indice_p]->d=$f_default;
					$preguntas[$indice_p]->s="4";
            	}
            	else{
            	 echo true;
            	 return true;
            	}
        	}

        		$a_r = str_replace(array('[',']'),'',json_encode($preguntas));
        		$qry="UPDATE form_extra 
				  	SET f_default=".json_encode($a_r)." 
		      	  	WHERE id_form='".$id_form."'";
	
				$resp=$obj_db->tarea($qry);
				if($resp!=false){
					return false;
				}
				else{
					echo (true);
					return true;
				}

        	echo json_encode($r);
			return true;
		}else{
			echo true;
			return true;
		}
	}

	function eliminarFormulario($id_form){
		global $obj_db;
		$qry="DELETE FROM form_extra 
			  WHERE id_form='".$id_form."'";	

		$resp=$obj_db->tarea($qry);
		if($resp!=false){
			return false;
		}
		else{
			echo (true);
			return true;
		}

	}

	function eliminarPregunta($id_form, $indice_p){
		global $obj_db;
		
		$qry="SELECT f_default, id_form   
			  FROM form_extra 
			  WHERE id_form='".$id_form."' 
			  ORDER BY f_alias";

		$resp=$obj_db->consulta($qry);

		if($resp!=false){

			foreach($resp as $fila){
				//decodificar json
				$preguntas = json_decode("[".$fila['f_default']."]");

				if (count($preguntas)>0){
					array_splice($preguntas, $indice_p,1);
            	}
            	else{
            	 echo true;
            	 return true;
            	}
        	}

        		$a_r = str_replace(array('[',']'),'',json_encode($preguntas));
        		$qry="UPDATE form_extra 
				  	SET f_default=".json_encode($a_r)." 
		      	  	WHERE id_form='".$id_form."'";
	
				$resp=$obj_db->tarea($qry);
				if($resp!=false){
					return false;
				}
				else{
					echo (true);
					return true;
				}

        	echo json_encode($r);
			return true;
		}else{
			echo true;
			return true;
		}


	}

	function getFormulario($id_seccion){
		global $obj_db;
		$r='';
		$nombreSeccion;
		$qry="SELECT * 
			  FROM form_extra 
			  WHERE id_seccion='".$id_seccion."'
			  ORDER BY f_alias";

		$resp=$obj_db->consulta($qry);

		if($id_seccion==4){$nombreSeccion='btn_formulario';}

		if($resp!=false){
			foreach($resp as $fila){


				$r.= '<div class="form-group row">'.
                    '<div class="t_d_value col-md-9 col-sm-9 col-xs-9"><div type="text" name="p_label_'.$fila['id_form'].'" id="p_label_'.$fila['id_form'].'" class="i_label form-control" placeholder="Label">'.$fila['f_label'].'</div></div>'.
                    '<div class="t_d_value col-md-1 col-sm-1 col-xs-1" style="text-align:center"><button class="btn btn-primary btn-xs-add-ask" id="p_f_'.$fila['id_form'].'">+</button></div>'.
                    '<div class="t_d_value col-md-1 col-sm-1 col-xs-1" style="text-align:center"><button class="btn btn-primary btn-xs-change '.$nombreSeccion.'" >O</button></div>'.
                    '<div class="t_d_value col-md-1 col-sm-1 col-xs-1" style="text-align:center"><button class="btn btn-primary btn-xs-delete" id="'.$fila['id_form'].'">x</button></div>'.
                '</div>';          		
        	}
			echo $r;
			return true;
		}else{
			echo true;
			return true;
		}
	
	}

	function getPregunta($id_seccion){
		global $obj_db;
		$r='';
		$nombreSeccion;
		$qry="SELECT * 
			  FROM form_extra 
			  WHERE id_form='".$id_seccion."'
			  ORDER BY f_alias";

		$resp=$obj_db->consulta($qry);

		if($id_seccion==4){$nombreSeccion='btn_formulario';}

		if($resp!=false){
			foreach($resp as $fila){


				$r.= '<div class="form-group row">'.
                    '<div class="t_d_value col-md-8 col-sm-8 col-xs-8"><div type="text" name="p_label_'.$fila['id_form'].'" id="p_label_'.$fila['id_form'].'" class="i_label form-control" placeholder="Label">'.$fila['f_label'].'</div></div>'.
                    '<div class="t_d_value col-md-1 col-sm-1 col-xs-1" style="text-align:center"><button class="btn btn-primary btn-xs-add-ask" id="p_f_'.$fila['id_form'].'">+</button></div>'.
                    '<div class="t_d_value col-md-1 col-sm-1 col-xs-1" style="text-align:center"><button class="btn btn-primary btn-xs-change '.$nombreSeccion.'" >O</button></div>'.
                    '<div class="t_d_value col-md-1 col-sm-1 col-xs-1" style="text-align:center"><button class="btn btn-primary btn-xs-delete" id="'.$fila['id_form'].'">x</button></div>'.
                '</div>';          		
        	}
			echo $r;
			return true;
		}else{
			echo true;
			return true;
		}
	
	}

	function getFormularios($id_seccion){
		global $obj_db;
		$r='';
		$nombreSeccion;
		$qry="SELECT * 
			  FROM form_extra 
			  WHERE id_seccion='".$id_seccion."'
			  ORDER BY f_alias";

		$resp=$obj_db->consulta($qry);

		if($id_seccion==4){$nombreSeccion='btn_formulario';}

		if($resp!=false){
			foreach($resp as $fila){

				$textTipo = '';
				if($fila['f_tipo']=='0'){$textTipo = 'No definido';};
                if($fila['f_tipo']=='1'){$textTipo = 'Texto';}
                if($fila['f_tipo']=='2'){$textTipo = 'Multiselección';}

				$r.= '<div class="row grid">'.
                    '<div class="t_d_label col-md-2 col-sm-2 col-xs-2" id=""><div type="text" name="p_alias_'.$fila['id_form'].'" id="p_alias_'.$fila['id_form'].'" class="i_alias campo col-md-12 col-sm-12 col-xs-12" placeholder="Alias">'.$fila['f_alias'].'</div></div>'.
                    '<div class="t_d_value col-md-3 col-sm-3 col-xs-3"><div type="text" name="p_label_'.$fila['id_form'].'" id="p_label_'.$fila['id_form'].'" class="i_label campo col-md-12 col-sm-12 col-xs-12" placeholder="Label">'.$fila['f_label'].'</div></div>'.
                    '<div class="t_d_value col-md-2 col-sm-2 col-xs-2"><div type="text" name="p_tipo_'.$fila['id_form'].'" id="p_tipo_'.$fila['id_form'].'" class="i_tipo campo col-md-12 col-sm-12 col-xs-12" placeholder="Tipo">'.
                    $textTipo.
                    '</div></div>'.
                    '<div class="t_d_value col-md-2 col-sm-2 col-xs-2"><div type="text" name="p_default_'.$fila['id_form'].'" id="p_default_'.$fila['id_form'].'" class="i_default campo col-md-12 col-sm-12 col-xs-12" placeholder="Valor por defecto">'.$fila['f_default'].'</div></div>'.
                    '<div class="t_d_value col-md-1 col-sm-1 col-xs-1" style="text-align:center"><button class="btn btn-primary btn-xs-change '.$nombreSeccion.'" >O</button></div>'.
                    '<div class="t_d_value col-md-1 col-sm-1 col-xs-1" style="text-align:center"><button class="btn btn-primary btn-xs-delete" id="'.$fila['id_form'].'">x</button></div>'.
                '</div>';          		
        	}
			echo $r;
			return true;
		}else{
			echo true;
			return true;
		}
	
	}


	function replace_utf8($string){
		$string = preg_replace_callback('/u([0-9a-fA-F]{4})/', function ($match) {
			return mb_convert_encoding(pack('H*', $match[1]), 'UTF-8', 'UCS-2BE');
		}, $string);

		return $string;
	}

	function getPreguntas($id_seccion,$id_form){
		global $obj_db;
		$r='';
		$nombreSeccion;
		$qry="SELECT f_default, id_form   
			  FROM form_extra 
			  WHERE id_seccion='".$id_seccion."' AND id_form='".$id_form."' 
			  ORDER BY f_alias";

		$resp=$obj_db->consulta($qry);

		if($id_seccion==4){$nombreSeccion='btn_pregunta';}
		if($resp!=false){


			foreach($resp as $fila){

				//decodificar json
				
				$preguntas = json_decode("[".$fila['f_default']."]");

				if (count($preguntas)>0){
					$i = -1;
					foreach ($preguntas as $p) {

						$i++;

						$textTipo = '';
						if($p->t=='0'||$p->t==''){$textTipo = 'No definido';};
                		if($p->t=='1'){$textTipo = 'Texto';}
                		if($p->t=='2'){$textTipo = 'Multiselección';}

						$r.= '<div class="row grid">'.
	                    	'<div class="t_d_label col-md-2 col-sm-2 col-xs-2" id=""><div type="text" name="p_alias_'.$i.'" id="p_alias_'.$i.'" class="i_alias campo col-md-12 col-sm-12 col-xs-12" placeholder="Alias">'.$this->replace_utf8($p->a).'</div></div>'.
                    		'<div class="t_d_value col-md-3 col-sm-3 col-xs-3"><div type="text" name="p_label_'.$i.'" id="p_label_'.$i.'" class="i_label campo col-md-12 col-sm-12 col-xs-12" placeholder="Label">'.$this->replace_utf8($p->l).'</div></div>'.
                    		'<div class="t_d_value col-md-2 col-sm-2 col-xs-2"><div type="text" name="p_tipo_'.$i.'" id="p_tipo_'.$i.'" class="i_tipo campo col-md-12 col-sm-12 col-xs-12" placeholder="Tipo">'.
                    		$textTipo.
                    		'</div></div>'.
                    		'<div class="t_d_value col-md-2 col-sm-2 col-xs-2"><div type="text" name="p_default_'.$i.'" id="p_default_'.$i.'" class="i_default campo col-md-12 col-sm-12 col-xs-12" placeholder="Valor por defecto">'.$this->replace_utf8($p->d).'</div></div>'.
                    		'<div class="t_d_value col-md-1 col-sm-1 col-xs-1" style="text-align:center"><button class="btn btn-primary btn-xs-change '.$nombreSeccion.'" >O</button></div>'.
                    		'<div class="t_d_value col-md-1 col-sm-1 col-xs-1" style="text-align:center"><button class="btn btn-primary btn-xs-delete" id="'.$i.'">x</button></div>'.
                		'</div>';

                	}
            	}
            	else{
            	 echo '1';
            	 return true;
            	}
        	}
			echo $r;
			return true;
		}else{
			echo true;
			return true;
		}
	
	}

	function getTablaRespuestas($id_form){
		global $obj_db;
		$r = array();
		
		//Labels de las tablas
		$qry="SELECT f_default, id_form   
			  FROM form_extra 
			  WHERE id_form='".$id_form."'
			  ORDER BY f_alias";

		$resp=$obj_db->consulta($qry);

		if($resp!=false){
			foreach ($resp as $fila) {
				$preguntas = json_decode("[".$fila['f_default']."]");
				if (count($preguntas)>0){
					$r['labels'][0] =  'Usuario';
					$r['labels'][1] =  'Fecha';
					$i = 1;
					foreach ($preguntas as $p) {
						$i++;	
						$r['labels'][$i] =  $p->l;
					}
				}else{
					$r['labels'][0] =  'N/D';
				}	
            }
		}else{
			$r['labels'][0] =  'N/D';
			
		}

		//Datos
		$qry="SELECT respuestas.cont_respuestas, respuestas.fecha, respuestas.id_formulario, usuario.user_name  
			  FROM respuestas 
			  LEFT JOIN usuario 
			  		 ON respuestas.user_id=usuario.id_usuario
			  WHERE id_formulario='".$id_form."' 
			  ORDER BY fecha";

		
		$resp=$obj_db->consulta($qry);

		if($resp!=false){

			$i=-1;
			foreach ($resp as $fila) {				
				$preguntas = json_decode("[".$fila['cont_respuestas']."]");
				if (count($preguntas)>0){
					$i++;
					foreach ($preguntas as $p=>$v_r) {
						$j=1;
						
						foreach($r['labels'] as $valor){
							$r['datos'][$i][] = 'N/D';
						}
						
						$r['datos'][$i][0] = $fila['user_name'];
						$r['datos'][$i][1] = $fila['fecha'];					
						foreach ($v_r as $v_r2=>$v_r3){
							$j++;
							$r['datos'][$i][$j] = isset($v_r3)&&$v_r3!=''?$v_r3:'';
						}					
					}					
				}else{
					$r['datos'][0][0] =  'N/D';
				}	
            }
		}else{
			if($r['labels'][0]=='N/D'){
				$r['datos'][0][0] =  'N/D';
			}else{
				foreach($r['labels'] as $valor){
					$r['datos'][0][] = 'N/D';
				}
				//print_r($r);exit;
			}
			
		}

		echo json_encode($r);	
	}

	function crearContPreguntas(){
		foreach( $_POST as $name => $value ) {
			$busqueda = strpos($name, 'p_');
			if($busqueda!==false)
	        	$s[$name]=$value;
		}
		return json_encode($s);
	}

	function guardarRespuestas($id_form, $user_id, $cont_preguntas,$fecha){
		global $obj_db;

		$qry="INSERT INTO respuestas(id_formulario, user_id, cont_respuestas,fecha)"
		." VALUES('".$id_form."','".$user_id."','".$cont_preguntas."','".$fecha."')";
		
		$resp=$obj_db->tarea($qry);
		if($resp!=false){
	?>
			<script>
				if(confirm("Tu cuestionario ha sido enviado exitosamente,\deseas enviar otro formulario?")){
					document.location.href="?command=contestar_formulario&formulario=p_f_<?php echo $id_form; ?>";
				}
				else{
					document.location.href="?command=promotor";
				}
			</script>
	<?php
		}
		else{
			echo (true);
			return true;
		}
	}


}

$formularios=new Formularios();

if(isset($_POST['f'])){
	if($_POST['f']=='altaFormulario'){
		$formularios=new Formularios();
		$f_alias='';
		$f_label=$_POST['label'];
		$f_tipo='';
		$f_default='';
		$id_seccion=$_POST['seccion'];
		$formularios->altaFormulario($f_alias,$f_label,$f_tipo,$f_default,$id_seccion);
	}

	if($_POST['f']=='altaPregunta'){
		$formularios=new Formularios();
		$f_alias=$_POST['alias'];
		$f_label=$_POST['label'];
		$f_tipo=$_POST['tipo'];
		$f_default=$_POST['default'];
		$id_seccion=$_POST['seccion'];
		$id_form=$_POST['id_form'];
		$formularios->altaPregunta($f_alias,$f_label,$f_tipo,$f_default,$id_seccion,$id_form);
	}
	


	if($_POST['f']=='cambiarFormulario'){
		$formularios=new Formularios();
		$id_form=$_POST['id_form'];
		$f_alias=$_POST['alias'];
		$f_label=$_POST['label'];
		$f_tipo=$_POST['tipo'];
		$f_default=$_POST['default'];
		$formularios->actualizarFormulario($id_form,$f_alias,$f_label,$f_tipo,$f_default);
	}
	

	if($_POST['f']=='cambiarPregunta'){
		$formularios=new Formularios();
		$id_form=$_POST['id_form'];
		$f_alias=$_POST['alias'];
		$f_label=$_POST['label'];
		$f_tipo=$_POST['tipo'];
		$f_default=$_POST['default'];
		$indice_p=$_POST['indice_p'];
		$formularios->actualizarPregunta($id_form,$f_alias,$f_label,$f_tipo,$f_default,$indice_p);
	}


	if($_POST['f']=='borrarFormulario'){
		$formularios=new Formularios();
		$id_form=$_POST['id_form'];		
		$formularios->eliminarFormulario($id_form);
	}

	if($_POST['f']=='borrarPregunta'){
		$formularios=new Formularios();
		$indice_p=$_POST['indice_p'];		
		$id_form=$_POST['id_form'];		
		$formularios->eliminarPregunta($id_form,$indice_p);
	}

	if($_POST['f']=='getFormulario'){
		$formularios=new Formularios();
		$id_seccion=$_POST['seccion'];		
		$formularios->getFormulario($id_seccion);
	}

	if($_POST['f']=='getPreguntas'){
		$formularios=new Formularios();
		$id_form=$_POST['id_form'];		
		$id_seccion=$_POST['seccion'];		
		$formularios->getPreguntas($id_seccion, $id_form);
	}

	if($_POST['f']=='getTablaRespuestas'){
		$formularios=new Formularios();
		$id_form=$_POST['id_form'];		
		$formularios->getTablaRespuestas($id_form);
	}
	
};

if(isset($_POST['btn_alta'])){
	if($_POST['btn_alta']=='Guardar'){
		$id_form=$_POST['id_form'];	
		$user_id=$_SESSION['user_id'];		
		$cont_preguntas=$formularios->crearContPreguntas();
		$fecha = date('Y-m-d H:i:s');
		$formularios->guardarRespuestas($id_form, $user_id, $cont_preguntas,$fecha);
	}
}

?>

