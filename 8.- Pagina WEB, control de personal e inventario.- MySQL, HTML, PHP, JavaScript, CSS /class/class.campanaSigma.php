<?php
require_once 'class.db.php';

/*****************************
      ERRORES

      1 No se pudieron añadir las respuestas
      2 No se encontró la lista de usuarios
      3 No se encontró el nombre de usuario
      4 Error al eliminar el cuestionario
      5 No se pudo obtener un cuestionario

*****************************/

    class clCampanas{

    	  function setCampana($nombre,$fecha_creada,$periodo,$select_tiendas){
            global $obj_db;
            $r = '';

            $qry="INSERT INTO campanas (nombre_campana,fecha_creada,periodo_campana,select_tiendas)
                       VALUES ('".$nombre."','".$fecha_creada."','".$periodo."','".$select_tiendas."')";


            $result = $obj_db->tarea($qry);
            if($result!=false){
?>
              <script>
                if(confirm("El registro se cargó exitosamente, \ndesea capturar otro registro?")){
                  document.location.href="index.php?command=campanas_sigma";
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
                document.location.href="index.php?command=campanas_sigma";
                
              </script>
<?php
                $r['debug']='';       
                  $r['error']=1;
            }


            echo json_encode($r);exit;
        }

        

        

        function get_campanas(){
            global $obj_db;
            $r = '';

            $qry="SELECT id_campana, nombre_campana, fecha_creada, periodo_campana, campana_eliminada
                    FROM campanas
                   WHERE 1";
            $result = $obj_db->consulta($qry);
            if($result!=false){
                  $r['campana']=$result;
                  $r['debug']='Se obtuvo correctamente la lista de campanas';       
                  $r['error']=false;
            }else{
                  $r['campana']=[array('id_campana'=>"0",'nombre_campana'=>' ','fecha_creada'=>" ",'periodo_campana'=>' ', 'campana_eliminada'=>"0")];
                  $r['debug']='Error al obtener la lista de campanas';       
                  $r['error']=2;
            }


            return json_encode($r);exit;
        }

        
        function eliminar_campana($id){
          global $obj_db;
          $qry="UPDATE campanas 
            SET campana_eliminada=1  
            WHERE id_respuesta = ".$id;

          $resp=$obj_db->tarea($qry);
          if($resp!=false){

            $r['debug']='Se ha eliminado la campana, correctamente';       
            $r['error']=false;
          }
          else{
            $r['debug']='Hubo un error al eliminar la campana';       
            $r['error']=4;
          }

          echo json_encode($r);exit;
        }        
    
    }

function postToString($arrayPost){
  $_r=[];
  foreach ($_POST as $key => $value) {

    if ($key=='select_tiendas'){
        $_r[]=$value;
    }
    $_r = json_encode($_r);
    return $_r;
  }
}


$datos = new clCampanas();

if (isset($_POST['funcion'])){


  if($_POST['funcion'] =='get_campanas'){
    $datos->get_campanas();
  }
  if($_POST['funcion'] =='eliminar_campana'){
    $id = isset($_POST['id'])?$_POST['id']:0;
    $datos->eliminar_cuestionario($id);
  }
  
}
if(isset($_POST['btn_enviar_alta_campana'])){
  if ($_POST['btn_enviar_alta_campana']=="Guardar"){
    
    $nombre       = isset($_POST['nombre-campana'])? $_POST['nombre-campana']:'';
    $fecha_creada = date('Ymd');
    $periodo      = isset($_POST['range-campana'])? $_POST['range-campana']:''; 
    $tiendas      = isset($_POST['select_tiendas'])? postToString($_POST['select_tiendas']):''; 

    $datos->setCampana($nombre,$fecha_creada,$periodo,$tiendas);
  }
}


?>