<?php
require_once 'class/class.camposExtras.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){
?>

  <body class="skin-blue sidebar-mini">

<style>
.controls.form_extra{
	text-align: right;
}


.row{
	margin-left:5px;
	margin-right:5px;
}


.i_alias, .i_label, .i_tipo, .i_default{width:100%;}

</style>

<script>

$(function(){

      function ajaxPreguntas(options){
          options=(options==typeof(undefined))?'':options;
          params=options;
        var datos = $.ajax({
              url:'class/class.formulariosPersonalizados.php',
              type:'post',
              async: false,
              data:params,
              success:function(data){
                   /* if(data==false){
                        getPreguntas('4');
                        return data;
                    }*/
              }          
         }).responseText;
        return datos
      }

      google.load("visualization", "1", {packages:["table"]});
      google.setOnLoadCallback(iniciador);

      function drawTable(cont) {

        respuestas = ajaxPreguntas({f:'getTablaRespuestas', id_form:cont});
        if (typeof(respuestas)!='undefined')
        v_datos = JSON.parse(respuestas);
        //console.log(v_datos['datos']);

        v_data=[];

        v_data.push(v_datos['labels']);
         //console.log(v_datos['labels'])
        v_datos['datos'].forEach(function(value){
         
          v_data.push(value);
        })
		
		console.log(v_data);

        var data = google.visualization.arrayToDataTable(v_data);

        var table = new google.visualization.Table(document.getElementById('cont_resupestas_'+cont));

        table.draw(data, {showRowNumber: true});
      }

      function iniciador(){

        <?php
            global $obj_db;
            $consulta3 = "SELECT id_form, f_label FROM form_extra WHERE id_seccion=4 ORDER BY f_label ASC";
            $result3 = $obj_db->consulta($consulta3);
            if($result3!=false){

                foreach($result3 as $fila3){
        ?>        
                        drawTable(<?php echo $fila3['id_form'] ?>)
                    
        <?php
                }
            }
        ?>

      }
   
})

</script>

<div class="wrapper">      
      
      <?php require "views/directivos/menu_vertical.php" ?>      
      <?php require "views/directivos/header_directivo.php" ?>


      <div class="content-wrapper">

        
        <!-- Main content -->
        <section class="content"> 

            <section class="content-header">
                <h1>
                    Respuestas de Cuestionarios
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                    <li><a href="#">Formularios personalizados</a></li>
                </ol>
            </section>

            <div id="">

                <div class="box box-primary">
                    <div>Cuestionarios:</div>
                    
                    <?php
                        global $obj_db;
                        $consulta3 = "SELECT id_form, f_label FROM form_extra WHERE id_seccion=4 ORDER BY f_label ASC";
                        $result3 = $obj_db->consulta($consulta3);
                        if($result3!=false){

                            foreach($result3 as $fila3){
                    ?>        


                      <div class="box-header"><h4>Preguntas de: <?php echo $fila3['f_label'] ?> </h4></div>
                      <div class="box-body">
                      	<div class="form-group row">
                              <div class="box-title col-md-2 col-sm-2 col-xs-2">Enviado Por:</div>
                              <div class="box-title col-md-9 col-sm-9 col-xs-9">Preguntas</div>
                    	 </div>
                          <div id="cont_resupestas_<?php echo $fila3['id_form'] ?>">                            
                          </div>
                      </div>

                      <hr>
                      <?php
                              }
                          }
                      ?>

                      <br />

                </div>

            </div>
        </section>        
    </div>
      <?php require "views/directivos/footer_directivo.php" ?>
</div>
</body>
<?php
}
else if($_SESSION['permiso']!='directivo'){
?>
<script>
alert("tu no tienes permiso para ver este contenido");
document.location.href="index.php?command=home";
</script>
<?php
}
?>