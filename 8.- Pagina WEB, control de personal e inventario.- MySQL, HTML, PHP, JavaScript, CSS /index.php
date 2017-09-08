<?php
session_start();
require_once 'config/index.php';
if(isset($_REQUEST['command'])){
$command=$_REQUEST['command'];
}
?>
<!DOCTYPE html>
<html>

<head>
	<meta charset="UTF-8">
	<meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <!-- <link rel="stylesheet" href="./css/bootstrap.css" /> -->
    <!-- <link rel="stylesheet" href="./css/bootstrap-responsive.min.css" /> -->

    <!-- Includes FontAwesome -->
    <!-- <link rel="stylesheet" href="./css/font-awesome.min.css" /> -->

    <!-- SlidePanel Css --> 
    <!-- <link rel="stylesheet" href="./css/stylesheet.css" /> -->

    <!-- <script src="./js/jquery-1.10.0.min.js"></script> -->
    <!-- <script src="./js/bootstrap.min.js"></script> -->


<?php
if(isset($command)){

?>

<title>
Smovil.com.mx
</title>

 <?php     
    foreach ($arre[$command]['css'] as $value) {
        echo "<link rel='stylesheet' type='text/css' href='".$value."' />";
    } 
    
 ?>


<?php 
    foreach ($arre[$command]['js'] as $value) {
        echo "<script src='".$value."'></script>";
    }  
?>

</head>
<?php

if(file_exists(FILE_CONFIG)){
    require $arre[$command]['view'];
}else{
    require $arre['install']['view'];
}

}
else{
    $command='home';
?>
<head>
<title>
Smobile.com.::.
</title>
 <?php     
    foreach ($arre['home']['css'] as $value) {
        echo "<link rel='stylesheet' type='text/css' href='".$value."' />";
    } 
    
 ?>

<?php 
    foreach ($arre['home']['js'] as $value) {
        echo "<script src='".$value."'></script>";
    }  
?>


</head>
<?php 
if(file_exists(FILE_CONFIG)){
    require $arre['home']['view'];
}else{
     require $arre['install']['view'];
}
}
?>



<?php 
    foreach ($arre[$command]['js_sub'] as $value) {
        echo "<script src='".$value."'></script>";
    }  
?>

</html>