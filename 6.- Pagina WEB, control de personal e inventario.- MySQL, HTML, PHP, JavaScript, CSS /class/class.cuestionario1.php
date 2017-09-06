<?php
require_once 'class.db.php';

/*****************************
      ERRORES

      1 No se pudieron añadir las respuestas
      2 No se encontró la lista de usuarios
      3 No se encontró el nombre de usuario
      4 Error al eliminar el cuestionario
      5 No se pudo obtener un cuestionario
      6 Error al actualizar las respuestas
      7 No se encontraron usuarios para la imagen

*****************************/

    class clCuestionario1{

      public function f_filtro($x,$v){
          if ($x=='fecha_i'&&$_POST['fecha_f']==''&&$v!=''){$this->filtro .= ' and DATE_FORMAT( fecha, "%Y%m%d" )="'.$v.'" ';}
          if ($x=='fecha_f'&&$_POST['fecha_i']!=''&&$v!=''){$this->filtro .= ' and DATE_FORMAT( fecha, "%Y%m%d" )>="'.str_replace("/", "", $_POST['fecha_i']).'" and DATE_FORMAT( fecha, "%Y%m%d" )<="'.$v.'" ';}
          if ($x=='promotor'&&$v!=0){$this->filtro .= ' and id_usuario='.$v." ";}
          if ($x=='cac'&&$v!=0){$this->filtro .= ' and id_tienda='.$v;}
          //if ($x=='producto'&&$v!=0){$this->filtro .= ' and respuesta_cuestionario_nutrioli.id_usuario='.$v;}
          if ($x=='estado'&&$v!=0){$this->filtro .= ' and cac.id_estado='.$v." ";}
          //if ($x=='municipio'&&$v!=0){$this->filtro .= ' and ventas.id_usuario='.$v;}
      
          //WHERE  DATE_FORMAT( fecha, '%Y%m%d' ) >=".date("Ym")."01 AND DATE_FORMAT( fecha, '%Y%m%d' )<=".date("Ymd");

          return $this->filtro;
        }

        

    	  function setCuestionario1($fecha,$respuestas,$id_cuestionario){
            global $obj_db;
            $r = '';

            $qry="INSERT INTO respuestas2 (fecha,respuestas,id_cuestionario)
                       VALUES ('".$fecha."','".(string)$respuestas."','".$id_cuestionario."')";
            $result = $obj_db->tarea($qry);
            if($result!=false){

              $command_string = "";
              if (isset($_GET['command']) && $_GET['command']=='cuestionario1_promotor'){
                $command_string = "cuestionario1_promotor";
              }else if(isset($_GET['command']) && $_GET['command']=='cuestionario1_auditor'){
                $command_string = "cuestionario1_auditor";
              }else if(isset($_GET['command']) && $_GET['command']=='cuestionario1_directivo'){
                $command_string = "cuestionario1_directivo";
              }
?>
              <script>
                if(confirm("El registro se cargó exitosamente, \ndesea capturar otro registro?")){
                  document.location.href="index.php?command=<?php echo $command_string; ?>";
                }
                else{
                  document.location.href="";
                }
              </script>
<?php

                  $r['debug']='';      	
                	$r['error']=false;
            }else{
?>
               <script>
                alert("Ha ocurrido un error, no se pudo guardar el formulario \n por favor intentelo de nuevo.")
                document.location.href="index.php?command=cuestionario1_auditor";
                
              </script>
<?php
                $r['debug']='';       
                  $r['error']=1;
            }


            echo json_encode($r);exit;
        }

        function get_usuarios(){
            global $obj_db;
            $r = '';

            $qry="SELECT id_usuario, User_name
                    FROM usuario
                   WHERE user_activo=1 AND id_right=3";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['usuarios']=$result;
                  $r['debug']='Se obtuvo correctamente la lista de usuarios';       
                  $r['error']=false;
            }else{
                  $r['usuarios']='';
                  $r['debug']='Error al obtener la lista de usuarios';       
                  $r['error']=2;
            }


            echo json_encode($r);exit;
        }

        function get_auditores(){
            global $obj_db;
            $r = '';

            $qry="SELECT id_usuario, User_name
                    FROM usuario
                   WHERE user_activo=1 AND id_right!=3";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['evaluador']=$result;
                  $r['debug']='Se obtuvo correctamente la lista de usuarios';       
                  $r['error']=false;
            }else{
                  $r['evaluador']='';
                  $r['debug']='Error al obtener la lista de usuarios';       
                  $r['error']=2;
            }


            echo json_encode($r);exit;
        } 

        function get_campanas(){
            global $obj_db;
            $r = '';

            $qry="SELECT id_respuesta,respuestas
                    FROM respuestas2
                   WHERE 1";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente la lista de usuarios';       
                  $r['error']=false;
            }else{
                  $r['camapana']='';
                  $r['debug']='Error al obtener la lista de usuarios';       
                  $r['error']=2;
            }


            echo json_encode($r);exit;
        }

        function get_campanas_list(){
            global $obj_db;
            $r = '';

            $qry="SELECT id_campana, nombre_campana 
                    FROM campanas
                   WHERE 1";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente la lista de campanas';       
                  $r['error']=false;
            }else{
                  $r['campana']=[array('id_campana'=>"0",'nombre_campana'=>' ' )];
                  $r['debug']='Error al obtener la lista de campanas';       
                  $r['error']=2;
            }


            //return json_encode($r);exit;
            echo json_encode($r);exit;
        }

        function get_tiendas_list(){
            global $obj_db;
            $r = '';

            $qry="SELECT id_cac, cac_name 
                    FROM cac
                   WHERE suspendido_cac = 0 
                ORDER BY cac_name";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente la lista de campanas';       
                  $r['error']=false;
            }else{
                  $r['campana']=[array('id_tienda'=>"0",'nombre_tienda'=>' ')];
                  $r['debug']='Error al obtener la lista de campanas';       
                  $r['error']=2;
            }


            //return json_encode($r);exit;
            echo json_encode($r);exit;
        }

        function get_grafica_campana(){
          global $obj_db;
            $r = '';

            $qry="SELECT respuestas
                    FROM respuestas2
                   WHERE 1";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente la lista de usuarios';       
                  $r['error']=false;
            }else{
                  $r['camapana']='';
                  $r['debug']='Error al obtener la lista de usuarios';       
                  $r['error']=2;
            }


            echo json_encode($r);exit;
        }

        function get_comunicacion(){
          global $obj_db;
            $r = '';

            $qry="SELECT respuestas
                    FROM respuestas2
                   WHERE 1";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente la lista de usuarios';       
                  $r['error']=false;
            }else{
                  $r['camapana']='';
                  $r['debug']='Error al obtener la lista de usuarios';       
                  $r['error']=2;
            }


            echo json_encode($r);exit;
        }

        function get_imagen(){
          global $obj_db;
            $r = '';

            $qry="SELECT respuestas
                    FROM respuestas2
                   WHERE 1";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente la lista de usuarios';       
                  $r['error']=false;
            }else{
                  $r['camapana']='';
                  $r['debug']='Error al obtener la lista de usuarios';       
                  $r['error']=2;
            }


            echo json_encode($r);exit;
        }

        function get_encargado_grafica(){
          global $obj_db;
            $r = '';

            $qry="SELECT respuestas
                    FROM respuestas2
                   WHERE 1";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente la lista de usuarios';       
                  $r['error']=false;
            }else{
                  $r['camapana']='';
                  $r['debug']='Error al obtener la lista de usuarios';       
                  $r['error']=2;
            }


            echo json_encode($r);exit;
        }

        function get_encargados_grafica(){
          global $obj_db;
            $r = '';

            $qry="SELECT respuestas
                    FROM respuestas2
                   WHERE 1";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente la lista de usuarios';       
                  $r['error']=false;
            }else{
                  $r['camapana']='';
                  $r['debug']='Error al obtener la lista de usuarios';       
                  $r['error']=2;
            }


            echo json_encode($r);exit;
        }

        function get_detalles_cuestionario(){
          global $obj_db;
            $r = '';

            $qry="SELECT id_respuesta,respuestas,fecha 
                    FROM respuestas2
                   WHERE 1 
                ORDER BY id_respuesta ASC";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente la lista de usuarios';       
                  $r['error']=false;
            }else{
                  $r['camapana']='';
                  $r['debug']='Error al obtener la lista de usuarios';       
                  $r['error']=2;
            }


            echo json_encode($r);exit;
        }

        function get_detalles_modificar_cuestionario($respuestas, $id_cuestionario){
          global $obj_db;
            $r = '';

            //$qry="INSERT INTO respuestas2 (fecha,respuestas,id_cuestionario)
            //           VALUES ('".$fecha."','".(string)$respuestas."','".$id_cuestionario."')";


            $qry = "UPDATE respuestas2 
                    SET respuestas = '".$respuestas."'  
                    WHERE id_respuesta = ".$id_cuestionario;

            $result = $obj_db->tarea($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Las respuestas se actualizaron correctamente';       
                  $r['error']=false;
            }else{
                  $r['camapana']='';
                  $r['debug']='Error al actualizar las respuestas';
                  $r['error']=6;
            }
//echo $qry;
//exit;
            return json_encode($r);
        }

        function get_usuario_nombre($id){
          global $obj_db;
            $r = '';
            if ($id != "null") {  
              $get_usuario = " id_usuario=".$id." ";
              $limit_get_usuario = " LIMIT 1 ";
            }else{
              $get_usuario = " 1 ";
              $limit_get_usuario = "";
            } 


            $qry="SELECT id_usuario, user_name 
                    FROM usuario 
                   WHERE ".$get_usuario." 
                   ".$limit_get_usuario;

            $result = $obj_db->consulta($qry);
            if($result!=false){
                  foreach($result as $fila){
                    $r['usuario_name'][]=$fila['user_name'];
                    $r['usuario_id'][]  =$fila['id_usuario'];
                  }
                  $r['debug']='Se obtuvo correctamente el nombre de usuario';       
                  $r['error']=false;
            }else{
                  $r['usuario_name']='';
                  $r['debug']='Error al obtener el nombre deusuario';       
                  $r['error']=3;
            }


            echo json_encode($r);exit;
        }

        function get_all_usuario_nombre(){
          global $obj_db;
            $r = '';
            

            $qry="SELECT id_usuario, user_name 
                    FROM usuario";

            $result = $obj_db->consulta($qry);
            if($result!=false){
                  foreach($result as $fila){
                    $r['usuario_name'][]=$fila['user_name'];
                    $r['usuario_id'][]  =$fila['id_usuario'];
                  }
                  $r['debug']='Se obtuvo correctamente el nombre de usuario';       
                  $r['error']=false;
            }else{
                  $r['usuario_name']='';
                  $r['debug']='Error al obtener el nombre deusuario';       
                  $r['error']=3;
            }


            echo json_encode($r);exit;
        }

        function get_campana_nombre($id){
          global $obj_db;
            $r = '';

            $qry="SELECT respuestas 
                    FROM respuestas2
                   WHERE id_respuesta=".$id." 
                   LIMIT 1";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$fila['user_name'];
                  $r['debug']='Se obtuvo correctamente el nombre de usuario';       
                  $r['error']=false;
            }else{
                  $r['campana']='';
                  $r['debug']='Error al obtener el nombre deusuario';       
                  $r['error']=3;
            }


            echo json_encode($r);exit;
        }

        function get_campana_nombre_lista($id){
          global $obj_db;
            $r = '';

            $qry="SELECT nombre_campana 
                    FROM campanas
                   WHERE id_campana=".$id." 
                   LIMIT 1";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente el nombre de usuario';       
                  $r['error']=false;
            }else{
                  $r['campana']=[array('nombre_campana'=>"")];
                  $r['debug']='Error al obtener el nombre deusuario';       
                  $r['error']=3;
            }


            echo json_encode($r);exit;
        }

        function get_all_campana_nombre_lista(){
          global $obj_db;
            $r = '';

            $qry="SELECT nombre_campana, id_campana  
                    FROM campanas";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente el nombre de usuario';       
                  $r['error']=false;
            }else{
                  $r['campana']=[array('nombre_campana'=>"")];
                  $r['debug']='Error al obtener el nombre deusuario';       
                  $r['error']=3;
            }


            echo json_encode($r);exit;
        }

        
        function get_buscar(){
          global $obj_db;
            $r = '';

            $qry="SELECT id_respuesta,respuestas 
                    FROM respuestas2
                   WHERE 1";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente la lista de usuarios';       
                  $r['error']=false;
            }else{
                  $r['camapana']='';
                  $r['debug']='Error al obtener la lista de usuarios';       
                  $r['error']=2;
            }


            echo json_encode($r);exit;
        }

        function get_comparar($ids){
          global $obj_db;
            $r = '';

            $qry="SELECT id_respuesta,respuestas 
                    FROM respuestas2
                   WHERE 1";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente la lista de usuarios';       
                  $r['error']=false;
            }else{
                  $r['camapana']='';
                  $r['debug']='Error al obtener la lista de usuarios';       
                  $r['error']=2;
            }


            echo json_encode($r);exit;
        }

        function eliminar_cuestionario($id){
          global $obj_db;
          $qry="UPDATE respuestas2 
            SET cancelado=1  
            WHERE id_respuesta = ".$id;

          $resp=$obj_db->tarea($qry);
          if($resp!=false){

            $r['debug']='Se ha eliminado el cuestionario, correctamente';       
            $r['error']=false;
          }
          else{
            $r['debug']='Hubo un error al eliminar el cuestionario';       
            $r['error']=4;
          }

          echo json_encode($r);exit;
        }

        function get_cuestionario($id){
          global $obj_db;
            $r = '';

            $qry="SELECT id_respuesta,respuestas,fecha 
                    FROM respuestas2
                   WHERE id_respuesta=$id AND cancelado=0 
                   LIMIT 1";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente el cuestionario';       
                  $r['error']=false;
            }else{
                  $r['camapana']='';
                  $r['debug']='Error al obtener un cuestionario';       
                  $r['error']=5;
            }

            echo json_encode($r);exit;
        }

        function get_tiendas_activas(){
          global $obj_db;
            $r = '';

            $qry="SELECT id_respuesta,respuestas,fecha 
                    FROM respuestas2
                   WHERE cancelado=0";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente el cuestionario';       
                  $r['error']=false;
            }else{
                  $r['camapana']='';
                  $r['debug']='Error al obtener un cuestionario';       
                  $r['error']=5;
            }

            echo json_encode($r);exit;
        }

        function recuperarRespuestas($id_cuestionario){
          global $obj_db;
            $r = '';

            $qry="SELECT id_respuesta,respuestas,fecha 
                    FROM respuestas2
                   WHERE cancelado=0 AND id_respuesta=".$id_cuestionario;
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente el cuestionario';       
                  $r['error']=false;
            }else{
                  $r['camapana']='';
                  $r['debug']='Error al obtener un cuestionario';       
                  $r['error']=5;
            }

            return $r['campana'];
        }

        function combinarRespuestas($respuestasDB, $respuestasPOST){

          foreach ($respuestasPOST as $key => $value) {
            
              //if( array_key_exists ( $key , $respuestasDB ) ){
                $respuestasDB->{$key} = $value; 
              //}            
          }


/*
  echo "<br>";
  echo "respuestasDB<br>";
  print_r($respuestasDB);
  echo "<br>";
  echo "respuestasPOST<br>";
  print_r($respuestasPOST);
  echo "<br>";
  */

          foreach ($respuestasDB as $key => $value) {
 

              if( !array_key_exists ( $key , $respuestasPOST ) ){
                if ($key != "nombre_tiendas" && 
                    $key != "nombre_evaluador" && 
                    $key != "nombre_campana" && 
                    $key != "fecha" && 
                    //$key != "tienda_activada" && 
                    $key != "sap" && 
                    $key != "tipo_evento" && 
                    $key != "marca_competencia" &&
                    $key != "persona_evento" && 
                    $key != "cuestionario_observaciones" && 
                    $key != "porcentaje_objetivo" && 
                    $key != "btn_guardar_cuestionario1"){

                    unset($respuestasDB->{$key});


                  }
              }
          }
          



          return json_encode( $respuestasDB );
        }


        function get_imagen_persona($id){
            global $obj_db;
            $r = '';

            $qry="SELECT user_foto 
                    FROM usuario 
                   WHERE id_usuario=".$id."   
                   LIMIT 1";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  foreach($result as $fila){
                    $r['foto'][]=$fila['user_foto'];
                  }
                  $r['debug']='Se obtuvo correctamente el cuestionario';       
                  $r['error']=false;
            }else{
                  $r['foto'][]="no-image.jpg";
                  $r['debug']='No se encontraron usuarios para la imagen';       
                  $r['error']=7;
            }

            echo json_encode($r);
        }
    
    }

$datos = new clCuestionario1();

if (isset($_POST['funcion'])){

  if($_POST['funcion'] =='get_encargado'){
    $datos->get_usuarios();
	}
  if($_POST['funcion'] =='get_evaluador'){
    $datos->get_auditores();
  }
  if($_POST['funcion'] =='get_campana'){
    $datos->get_campanas();
  }
  if($_POST['funcion'] =='get_campanas_list'){
    $datos->get_campanas_list();
  }
  if($_POST['funcion'] =='get_grafica_campana'){
    $datos->get_grafica_campana();
  }
  if($_POST['funcion'] =='get_comunicacion'){
    $datos->get_comunicacion();
  }
  if($_POST['funcion'] =='get_imagen'){
    $datos->get_imagen();
  }
  if($_POST['funcion'] =='get_encargado_grafica'){
    $datos->get_encargado_grafica();
  }
  if($_POST['funcion'] =='get_encargados_grafica'){
    $datos->get_encargado_grafica();
  }
  if($_POST['funcion'] =='get_buscar'){
    $datos->get_buscar();
  }
  if($_POST['funcion'] =='get_comparar'){
    $ids = isset($_POST['ids'])?$_POST['ids']:array(0);
    $datos->get_comparar($ids);
  }
  if($_POST['funcion'] =='get_detalles_cuestionario'){
    $datos->get_detalles_cuestionario();
  }
  if($_POST['funcion'] =='get_usuario_nombre'){
    $id = isset($_POST['id'])?$_POST['id']:0;

    $datos->get_usuario_nombre($id);
  }
  if($_POST['funcion'] =='get_all_usuario_nombre'){
    $id = isset($_POST['id'])?$_POST['id']:0;
    $datos->get_all_usuario_nombre();
  }
  if($_POST['funcion'] =='get_campana_nombre'){
    $id = isset($_POST['id'])?$_POST['id']:0;

    $datos->get_campana_nombre($id);
  }
  if($_POST['funcion'] =='get_campana_nombre_lista'){
    $id = isset($_POST['id'])?$_POST['id']:0;
    $datos->get_campana_nombre_lista($id);
  }
  if($_POST['funcion'] =='get_tiendas_list'){
    $datos->get_tiendas_list();
  }
  if($_POST['funcion'] =='get_all_campana_nombre_lista'){
    $id = isset($_POST['id'])?$_POST['id']:0;

    $datos->get_all_campana_nombre_lista($id);
  }
  if($_POST['funcion'] =='eliminar_cuestionario'){
    $id = isset($_POST['id'])?$_POST['id']:0;
    $datos->eliminar_cuestionario($id);
  }
  if($_POST['funcion'] =='get_cuestionario'){
    $id = isset($_POST['id'])?$_POST['id']:0;
    $datos->get_cuestionario($id);
  }
  if($_POST['funcion'] =='get_tiendas_activas'){
    $id = isset($_POST['id'])?$_POST['id']:0;
    $datos->get_tiendas_activas();
  }
  if($_POST['funcion'] == 'get_imagen_persona'){
    $id = isset($_POST['id'])?$_POST['id']:0;
    $datos->get_imagen_persona($id);
  }
  
  
}
if(isset($_POST['btn_guardar_cuestionario1'])){
  if ($_POST['btn_guardar_cuestionario1']=="Guardar"){
    $fecha = date('Ymd');
    $respuestas = json_encode($_POST);
    $id_cuestionario = 1;

    $datos->setCuestionario1($fecha,$respuestas,$id_cuestionario);
  }
}

if(isset($_POST['click_modificar_cuestionario1'])){
  if ($_POST['click_modificar_cuestionario1']=="Guardar"){

    $respuestas_post = isset($_POST) ? $_POST : [''];
    
    $id_cuestionario = isset( $_GET['id_cuestionario'] ) && is_numeric($_GET['id_cuestionario']) ? $_GET['id_cuestionario'] : 0;
    $respuestasEnBase = $datos->recuperarRespuestas($id_cuestionario);
    $respuestasEnBase = json_decode($respuestasEnBase[0]['respuestas']);

    $res = $datos->combinarRespuestas($respuestasEnBase, $respuestas_post);

    //$respuestas = json_encode($_POST);

    //echo $respuestas;
    //exit;

    $datos->get_detalles_modificar_cuestionario( $res, $id_cuestionario );    

  }
}


?>