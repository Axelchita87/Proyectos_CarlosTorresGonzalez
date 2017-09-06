
<?php
require_once 'class/class.altas.php';
//session_start();
if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){

?>

  <body class="skin-blue sidebar-mini">
    

  <style>

  #reporte {position:relative;}
  #reporte .header{color:#333;font-weight: bolder; text-align: center;}
  #reporte .label{color:#333;}
  #reporte .campo{color:#333;}
  #reporte #foto{border:1px solid #ccc; width:120px;height:150px;position:absolute; right:20px;}
  #reporte img{max-width: 100%; max-height: 100%; top:0; bottom: 0; right:0; left:0;position:absolute; margin: auto;}
  #detalles, #cuotas{clear: both;}

  #cont-detalles table {width:100%;}

  /*.cont-graficas{min-height: 300px; border:#FFF solid 1px; transition:border 1s;}
  .cont-graficas:hover{border:#F11111 solid 1px;}*/
  .menu-edit{position:absolute;top:5px; right:5px; list-style: none; cursor:pointer; text-align: right;z-index:100;}
  .menu-edit li img{border:solid #fff .5px;padding:3px;}
  .menu-edit li img:hover{border:solid #ccc .5px;transition:border .5s}
  .menu-edit li .submenu-edit{list-style: none;}
  .menu-edit li .submenu-edit li{cursor:pointer;display:block;text-align: left; padding:3px 20px; background-color: #eee; border-bottom:#aaa solid 1px;font-weight:bold;}
  .menu-edit li .submenu-edit li:hover{background-color:#999; color:#FFF;transition:background-color .5s, color .5s;}


.modalmask, .modalmask2{
    position: fixed;
    font-family: Arial, sans-serif;
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    background: rgba(0,0,0,0.8);
    z-index: 99999;
    opacity:1;
    -webkit-transition: opacity 400ms ease-in;
    -moz-transition: opacity 400ms ease-in;
    transition: opacity 400ms ease-in;
    pointer-events: none;
    display:none;
}
.modalmask, .modalmask2{
    pointer-events: auto;
}

.modalbox{
    /*width: 400px;*/
    position: relative;
    padding: 5px 20px 13px 20px;
    background: #fff;
    border-radius:3px;
    -webkit-transition: all 500ms ease-in;
    -moz-transition: all 500ms ease-in;
    transition: all 500ms ease-in;
     text-align: center
}

.modalmask2 .modalbox{padding: 5px 35px 13px 35px;}

.modalbox img{width:45%; border: 1px solid #999; margin:3px;}
.btn-grafica{cursor:pointer;}

.modalmask .movedown, .modalmask2 .movedown{       
    margin:10% auto;
    float:none;
}


.close {
    background: #606061;
    color: #FFFFFF;
    line-height: 25px;
    position: absolute;
    right: 1px;
    text-align: center;
    top: 1px;
    width: 24px;
    text-decoration: none;
    font-weight: bold;
    border-radius:3px;
 
}
 
.close:hover {
    background: #FAAC58;
    color:#222;
}


</style> 

    <script type="text/javascript">
       function cuantosDias(mes, anyo)
       {
          var cuantosDias = 31;
          if (mes == "Abril" || mes == "Junio" || mes == "Septiembre" || mes == "Noviembre")
        cuantosDias = 30;
          if (mes == "Febrero" && (anyo/4) != Math.floor(anyo/4))
        cuantosDias = 28;
          if (mes == "Febrero" && (anyo/4) == Math.floor(anyo/4))
        cuantosDias = 29;
          return cuantosDias;
      }

      function cuantosDias2(humanMonth, year) {
        return new Date(year || new Date().getFullYear(), humanMonth, 0).getDate();
      }

      function limpiar_tabla(contenedor){
        $(contenedor).html("");
      }

      function constuctor_header_tabla(array_value,contenedor){
        var s="";
        s+= "<thead>";
        s+= " <tr>";
        array_value.forEach(function(value){
          s+= " <th>"+ value +"</th>";          
        });
        s+= "<th>Opciones</th>"
        s+= " </tr>";
        s+= "</thead>";
        $(contenedor).append(s);
      }

      function constuctor_body_tabla(columnas,contenedor,array_value){
        var s="";
        s+= "<tbody>";
        s+= " <tr>";
        for(i=0;i<columnas;i++){
          s+= " <td></td>";          
        };
        s+= " <td>\n"+
                "<a class='btn btn-primary' href='index.php?command=asistencia_detalles&id=usuario'>V</a>\n"+
                "<a class='btn btn-primary'>E</a>\n"+
            "</td>";
        s+= " </tr>";
        s+= "</tbody>";
        $(contenedor).append(s);
      }

      function tabla_semanas(){
        var s;
        var tabla = {};
        tabla.headers = Array("Nombre","Lunes","Martes","Miércoles","Jueves","Viernes","Sábado","Domingo");
        
        limpiar_tabla("#asistencia1");
        constuctor_header_tabla(tabla.headers,"#asistencia1");
        constuctor_body_tabla(tabla.headers.length,"#asistencia1");     
        
      }

      function tabla_dias(){
        var s;
        var tabla = {};
        var dias = cuantosDias2(new Date().getMonth());
        console.log(dias);

        tabla.headers = new Array();

        tabla.headers.push("Nombre");

        for(var i=1; i<=dias; i++){
          tabla.headers.push(i);
        }        
        
        limpiar_tabla("#asistencia1");
        constuctor_header_tabla(tabla.headers,"#asistencia1");
        constuctor_body_tabla(tabla.headers.length,"#asistencia1");     
        
      }
      
      $(function () {
        tabla_dias();
        $("#asistencia1").dataTable();        
      });
    </script>


<div class="wrapper">
      
      

      <?php require "views/directivos/menu_vertical.php" ?>      
      <?php require "views/directivos/header_directivo.php" ?>

      
      <div class="content-wrapper">

        <!-- Main content -->
        <section class="content-header">
          <h1>
            Asistencia
            <small>Version 3.0</small>            
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
            <li class="active">Asistencia</li>
          </ol>
        </section>
      
       <!-- Main content -->
        <section class="content">  

          <div class="col-md-12 col-sm-12 col-xs-12"> <!-- Inicia contenedor de tabla -->

            <div id="asistencia-grafica" class="box box-primary">
              <div class="box-header with-border">
                <h3 class="box-title">Tabla de Asistencia</h3>
                <div class="box-tools pull-right">
                  <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                  <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                </div>
              </div>

              <div class="box-body">
                <div class="form-group row">  
                  <label class="col-md-2 col-sm-2 col-xs-12">Visualizar por: </label> 
                  <div class="col-md-3 col-sm-5 col-xs-12">
                    <select name="asistencia_view" id="permiso" class="form-control">
                      <option value="0">Día</option>
                      <option value="1">Semana</option>
                      <option value="2">Mes</option>
                    </select>
                  </div>
                </div>

                <div class="row">
                  <div class="col-md-12 col-sm-12 col-xs-12">
                  <table id="asistencia1" class="table table-bordered table-hover">
                    <thead>
                      <tr>
                        <th>Rendering engine</th>
                        <th>Browser</th>
                        <th>Platform(s)</th>
                        <th>Engine version</th>
                        <th>CSS grade</th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr>
                        <td>Trident</td>
                        <td>Internet
                          Explorer 4.0</td>
                        <td>Win 95+</td>
                        <td> 4</td>
                        <td>X</td>
                      </tr>
                    </tbody>
                  </table>
                </div>
                </div>
              </div>         

            </div>
          </div> <!-- Termina contenedor de tabla -->
    
        </section>
      
      </div>

      <?php require "views/directivos/footer_directivo.php"; ?>

</div>
</body>

<?php

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