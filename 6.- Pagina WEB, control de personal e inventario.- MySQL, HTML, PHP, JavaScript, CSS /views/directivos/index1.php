<?php
require_once 'class/class.db.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){
?>

<body>
<div border="0" class="table-responsive">
	<?php require "views/directivos/menu_vertical.php" ?>

	 <!-- BOOTSTRAP CONTENT -->
    <div class="container">
        <div class="row" >
            <div class="col-md-12 col-sm-12 col-xs-12" style="text-align:center">
                <br>
                <br>
                <h1>Bienvenido</h1>

                <br>

                <div><img src="images/512px-HTC_logo.png" style="max-width:500px; width:100%"/></div>
            </div>

            <div class="col-md-12 col-sm-12 col-xs-12" style="text-align:center">
                <p class="tituloApp">M2.5 Gestión de promotorías y ventas</p>
            </div>

        </div>
    </div>
</div>

</body>
<?php
}
else if($_SESSION['permiso']!='directivo'){
?>
<script>
alert("Tu no tienes permiso para ver este contenido");
document.location.href="index.php?command=home";
</script>
<?php
}
?>