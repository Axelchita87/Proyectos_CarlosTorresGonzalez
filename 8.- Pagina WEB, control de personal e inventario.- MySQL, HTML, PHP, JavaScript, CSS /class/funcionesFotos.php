<?php
require_once 'class.db.php';

$filtro = " WHERE 1 "; 

function f_filtro($x,$v){
 global $filtro;

          if ($x=='fecha_i'&&$_POST['fecha_f']==''&&$v!=''){$filtro .= ' and DATE_FORMAT( fecha, "%Y%m%d" )="'.$v.'" ';}
          if ($x=='fecha_f'&&$_POST['fecha_i']!=''&&$v!=''){$filtro .= ' and DATE_FORMAT( fecha, "%Y%m%d" )>="'.str_replace("/", "", $_POST['fecha_i']).'" and DATE_FORMAT( fecha, "%Y%m%d" )<="'.$v.'" ';}
          if ($x=='week_i'&&$_POST['fecha_f']==''&&$v!=''){$filtro .= ' and YEARWEEK(fecha,1) = '.date("oW",strtotime($v)).' ';}
          if ($x=='week_f'&&$_POST['fecha_i']&&$v!=''){$filtro .= ' and YEARWEEK(fecha,1) >= '.date("oW",strtotime($_POST['fecha_i'])).' and YEARWEEK(fecha,1) <= '.date("oW",strtotime($v));}
          if ($x=='promotor'&&$v!=0){$filtro .= ' and id_usuario='.$v." ";}
          if ($x=='cac'&&$v!=0){$filtro .= ' and id_tienda='.$v;}
          //if ($x=='producto'&&$v!=0){$filtro .= ' and respuesta_cuestionario_nutrioli.id_usuario='.$v;}
          if ($x=='estado'&&$v!=0){$filtro .= ' and cac.id_estado='.$v." ";}

}


function fotos_todo(){
    global $obj_db;
    global $filtro; 

    $r=array("");

    $consulta = "SELECT  
                        CONCAT(
                            YEAR(fecha),
                            WEEK(fecha,1),
                            IF(WEEK(fecha)<10,
                                CONCAT(
                                    WEEK(fecha,1),
                                    0
                                ),
                                WEEK(fecha)
                            )
                        ) AS alldate, 
                        YEAR(fecha) AS year, 
                        WEEK(fecha,1)  AS week,
                        DAY(fecha) AS day,
                        MONTH(fecha) AS month  
                    FROM fotos_cac
                   ".$filtro." 
                GROUP BY alldate ASC ";

    $consulta2 = "SELECT foto_cac_name, 
                         fecha, 
                         YEAR(fecha) AS year, 
                         WEEK(fecha,1)  AS week, 
                        id_cac, 
                        id_usuario,
                        foto_comentario   
                    FROM fotos_cac
                   ".$filtro." 
                ORDER BY fecha, id_cac ASC , id_usuario ASC ";
//print_r($consulta);
//print_r($consulta2);exit;
    
    $result = $obj_db->consulta($consulta);

    $result2 = $obj_db->consulta($consulta2);

    if($result!=false){
        foreach($result as $fila){

            $strHead = '';
            $strFooter = '';

            //$timestamp  =mktime(0, 0, 0, 1, 1, $fila['year']);
            //$timestamp  +=$fila['week']*7*24*60*60;
            $semana = date("W",mktime(0,0,0,$fila['month'],$fila['day'],$fila['year']));
            $diaSemana=date("w",mktime(0,0,0,$fila['month'],$fila['day'],$fila['year']));

            if($diaSemana==0)
                $diaSemana=7;

            //$ultimoDia  = $timestamp-date("w", mktime(0, 0, 0, 1, 1, $fila['year']))*24*60*60;
            //$startWeek  = $ultimoDia-86400*(date('N',$ultimoDia)-1);      

            $startWeek=date("Y-m-d",mktime(0,0,0,$fila['month'],$fila['day']-$diaSemana+1,$fila['year']));
            $ultimoDia=date("Y-m-d",mktime(0,0,0,$fila['month'],$fila['day']+(7-$diaSemana),$fila['year']));

            $nameFotoPrincipal = (isset($result2) && $result2!=false) ? $result2[0]["foto_cac_name"] : '';

            $strHead    =   '<div class="col-md-12 col-sm-12 col-xs-12">'."\n".
                                '<div class="box box-primary ">'."\n".
                                    '<div class="box-header">'."\n".
                                        '<h4>Año: '.$fila['year'].', Semana: '.$fila['week'].' </h4>'."\n".
                                        '<small>Del '.$startWeek." al ".$ultimoDia.'</small>'."\n".
                                        '<div class="box-tools pull-right">'."\n".
                                        //'<button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>'."\n".
                                        '</div>'."\n".
                                    '</div>'."\n".
                                    '<div class="box-body">'."\n".
                                        '<div class="col-md-12 col-sm-12 col-xs-12">'."\n".
                                            '<div class="col-md-3 col-sm-3 col-xs-12">'."\n".
                                                '<div class="contImgPrimcipal">'."\n".
                                                    '<img  src="uploads/cacs/thumbs/'.$nameFotoPrincipal.'" alt="" />'."\n".
                                                '</div>'."\n".
                                            '</div>'."\n".
                                            '<div class="col-md-9 col-sm-9 col-xs-12">'."\n".
                                                '<h2 class="page-header">Galería de imágenes</h2>'."\n".
                                                '<div class="box-body"></div>'."\n".
                                            '</div>'."\n".
                                        '</div>'."\n".
                                        '<div id="bottom-thumbs-'.$fila['week'].'" class="bottom-thumbs bottom fancybox-margin col-md-12 col-sm-12 col-xs-12">'."\n".
                                            '<ul style="">';
                                            

            $r[0].=$strHead;
            $contador = 0;
//print_r($result2[0]["foto_cac_name"]);
            if($result2!=false){
                foreach($result2 as $fila2){

                    if ($fila['year'] == $fila2['year'] && $fila['week'] == $fila2['week']){
                        
                       $r[0].=  '<li>'.
                                    "<a class=\"fancybox-thumbs img-thumbnail\" data-fancybox-group=\"thumb\" data-comment=\"".$fila2['foto_comentario']."\" href=\"uploads/cacs/".$fila2['foto_cac_name']."\"><img src=\"uploads/cacs/thumbs/".$fila2['foto_cac_name']."\" alt=\"\" /></a>\n".
                                '</li>';
                        $contador++;
                    }
                }
            }

            $strFooter = '                  </ul>'."\n".
                        '               </div>'."\n".
                        '               <div class="col-md-12 col-sm-12 col-xs-12">'."\n".
                        '                   <input id="range_'.$fila['week'].'" class="range_slide" type="text" name="range_'.$fila['week'].'" value="" />'."\n".
                        '               </div>'."\n".
                        '           </div>'."\n".
                        '           <div class="box-footer">'."\n".
                        '               <small class="pull-right">'.$contador.' imagenes</small>'."\n".
                        '           </div>'."\n".
                        '       </div>'."\n".
                        '   </div>'."\n".

                        ' '."\n".

                        '<script>'."\n".
                        '   $("#bottom-thumbs-'.$fila['week'].' ul").css("width","'.(($contador+1)*42).'")'."\n".
                        '   $("#range_'.$fila['week'].'").ionRangeSlider({'."\n".
                        '        min: 0,'."\n".
                        '        max: '.$contador.','."\n".
                        '        type: "single",'."\n".
                        '        step: 0.1,'."\n".
                        '        postfix: " imágenes",'."\n".
                        '        prettify: false,'."\n".
                        '        hasGrid: true,'."\n".
                        '        onChange:function(data){'."\n".
                        '           var ancho_total = $("#bottom-thumbs-'.$fila['week'].' ul").width();'."\n".
                        '           var ancho_visible = $("#bottom-thumbs-'.$fila['week'].'").width();'."\n".
                        '           var ancho_total_visible = ancho_total-ancho_visible;'."\n".
                        '           var posicion_visible = ((ancho_total_visible / 100)* data.fromPers);'."\n". 
                        '           $("#bottom-thumbs-'.$fila['week'].' ul").css("margin-left","-"+posicion_visible+"px")'."\n".  
                        '        }'."\n".
                        '    });'."\n".

                        //'   $("#range_'.$fila['week'].'").on("change",function(){'."\n".
                        //'       alert($(this).prop("value"));'."\n".
                        //'   })'."\n".
                            
                        '</script>';



            $r[0].=$strFooter;
        }
    }

    return $r;
}

$r_val='';

if(isset($_POST['get_foto_usuario']) && isset($_POST['get_foto_cac'])&&isset($_POST['get_foto_clasificacion'])){

    isset($_POST['fecha_i']) ? f_filtro('fecha_i',str_replace("/", "", $_POST['fecha_i'])) : '';
    isset($_POST['fecha_i']) ? f_filtro('week_i',str_replace("/", "-", $_POST['fecha_i'])) : '';
    isset($_POST['fecha_f']) ? f_filtro('fecha_f',str_replace("/", "", $_POST['fecha_f'])) : '';
    isset($_POST['fecha_f']) ? f_filtro('week_f',str_replace("/", "-", $_POST['fecha_f'])) : '';
    isset($_POST['get_foto_cac'])       && $_POST['get_foto_cac']       != 0 ? f_filtro('cac',$_POST['get_foto_cac']) : '';
    isset($_POST['get_foto_usuario'])   && $_POST['get_foto_usuario']   != 0 ? f_filtro('promotor',$_POST['get_foto_usuario']) : '';

        $r_val=fotos_todo();

    echo json_encode($r_val);
}


?>