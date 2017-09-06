<?php
/*define("HOST","localhost");
define("USER","metrack_m25");
define("PSS","roootm25");
define("DB","sigma");*/

define("HOST","localhost");
define("USER","root");
define("PSS","");
define("DB","sigma");
@mysql_query('SET NAMES "utf8"');

class Conexion{
public $link;
public $arre;

	function conect_db(){
	$this->link=@mysql_connect(HOST,USER,PSS)or die("Error en la conexion_db");
	mysql_select_db(DB,$this->link);
	}

	function consulta($qry){
	$resp=mysql_query($qry,$this->link);
	if($resp!=false){
	$this->arre=array();
	while($row=mysql_fetch_assoc($resp)){
	$this->arre[]=$row;
	}
	return $this->arre;
	mysql_free_result($qry);
	mysql_close($qry);
	}
	else{
	return false;
	}
	}

	function tarea($qry){
	$resp=mysql_query($qry,$this->link);
	if($resp!=false){
	return true;
	mysql_free_result($qry);
	mysql_close($qry);
	}
	else{
	return false;
	}
	}
}
$obj_db=new Conexion();
$obj_db->conect_db();
?>