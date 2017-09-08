<?php
session_start();
require_once 'config/index.php';
include('mpdf/mpdf.php');

if(isset($_REQUEST['command'])){
$command=$_REQUEST['command'];
}

if(isset($command)){

require $arre[$command]['view'];

}
else{
require $arre['home']['view'];
}

?>