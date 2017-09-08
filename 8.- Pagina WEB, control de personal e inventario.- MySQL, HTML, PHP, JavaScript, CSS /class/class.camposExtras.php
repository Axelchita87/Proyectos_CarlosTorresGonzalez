<?php
require_once 'class.db.php';
if(isset($_POST['btn_alta'])||isset($_POST['btn_modificar_directivo']))
require_once 'class/class_imgUpldr.php';


class Campos{

	function altaCampo($f_alias,$f_label,$f_tipo,$f_default,$id_seccion){
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
	
	function actualizarCampo($id_form,$f_alias,$f_label,$f_tipo,$f_default){
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

	function eliminarCampo($id_form){
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

	function getCampos($id_seccion){
		global $obj_db;
		$r='';
		$nombreSeccion;
		$qry="SELECT * 
			  FROM form_extra 
			  WHERE id_seccion='".$id_seccion."'
			  ORDER BY f_alias";

		$resp=$obj_db->consulta($qry);

		if($id_seccion==1){$nombreSeccion='btn_usuario';}
		if($id_seccion==2){$nombreSeccion='btn_cac';}
		if($id_seccion==3){$nombreSeccion='btn_producto';}

		if($resp!=false){
			foreach($resp as $fila){

				$textTipo = '';
				if($fila['f_tipo']=='0'){$textTipo = 'No definido';};
                if($fila['f_tipo']=='1'){$textTipo = 'Texto';}
                if($fila['f_tipo']=='2'){$textTipo = 'Multiselección';}

				$r.= '<div class="form-group row">'.
                    '<div class="t_d_label col-md-3 col-sm-3 col-xs-3" id=""><div type="text" name="p_alias_'.$fila['id_form'].'" id="p_alias_'.$fila['id_form'].'" class="i_alias form-control" placeholder="Alias">'.$fila['f_alias'].'</div></div>'.
                    '<div class="t_d_value col-md-3 col-sm-3 col-xs-3"><div type="text" name="p_label_'.$fila['id_form'].'" id="p_label_'.$fila['id_form'].'" class="i_label form-control" placeholder="Label">'.$fila['f_label'].'</div></div>'.
                    '<div class="t_d_value col-md-2 col-sm-2 col-xs-2"><div type="text" name="p_tipo_'.$fila['id_form'].'" id="p_tipo_'.$fila['id_form'].'" class="i_tipo form-control" placeholder="Tipo">'.
                    $textTipo.
                    '</div></div>'.
                    '<div class="t_d_value col-md-2 col-sm-2 col-xs-2"><div type="text" name="p_default_'.$fila['id_form'].'" id="p_default_'.$fila['id_form'].'" class="i_default form-control" placeholder="Valor por defecto">'.$fila['f_default'].'</div></div>'.
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


}

$campos=new Campos();

if(isset($_POST['f'])){
	if($_POST['f']=='altaCampo'){
		$campos=new Campos();
		$f_alias=$_POST['alias'];
		$f_label=$_POST['label'];
		$f_tipo=$_POST['tipo'];
		$f_default=$_POST['default'];
		$id_seccion=$_POST['seccion'];
		$campos->altaCampo($f_alias,$f_label,$f_tipo,$f_default,$id_seccion);
	}
	


	if($_POST['f']=='cambiarCampo'){
		$campos=new Campos();
		$id_form=$_POST['id_form'];
		$f_alias=$_POST['alias'];
		$f_label=$_POST['label'];
		$f_tipo=$_POST['tipo'];
		$f_default=$_POST['default'];
		$campos->actualizarCampo($id_form,$f_alias,$f_label,$f_tipo,$f_default);
	}
	


	if($_POST['f']=='borrarCampo'){
		$campos=new Campos();
		$id_form=$_POST['id_form'];		
		$campos->eliminarCampo($id_form);
	}

	if($_POST['f']=='getCampos'){
		$campos=new Campos();
		$id_seccion=$_POST['seccion'];		
		$campos->getCampos($id_seccion);
	}
	
};

?>

