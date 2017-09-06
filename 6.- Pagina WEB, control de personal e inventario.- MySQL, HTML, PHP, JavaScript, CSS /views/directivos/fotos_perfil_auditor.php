<?php
session_start();
if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){
?>

<body>
<table border="0" class="table-responsive" height="100%">
<td>
<div class="fondo_mate text-right" style="border-radius:0px; width:240px;
	 padding-top:2px; height:99.8%;">
<div class="col-lg-12 text-success" style="font-size:17px;">
<?php echo "Hola! ".$_SESSION['user']; ?>
</div>
<br />
<br />
      <div class="btn btn-sm btn-block btn-success" 
onclick="document.getElementById('ventas').style.display='none',document.getElementById('fotos').style.display='none',document.getElementById('altas').style.display='block'">Altas</div>
<div id="altas" class="text-danger" style="display:none;">
<div class="text-danger text-center"><a href="index.php?command=alta_directivo">Directivo</a></div>
<div class="text-danger text-center"><a href="index.php?command=alta_auditor">Auditor</a></div>
<div class="text-danger text-center"><a href="index.php?command=alta_promotor">Promotor</a></div>
</div> 
<br/>

      <div class="btn btn-sm btn-block btn-success" 
onclick="document.getElementById('altas').style.display='none',document.getElementById('fotos').style.display='none',document.getElementById('ventas').style.display='block'">Ventas</div>
<div id="ventas" class="text-danger" style="display:none;">
<div class="text-danger text-center"><a href="index.php?command=ventas_xpromotor">Por promotor</a></div>
<div class="text-danger text-center"><a href="index.php?command=ventas_xregion">Por region</a></div>
<div class="text-danger text-center"><a href="index.php?command=ventas_xdia">Por dia</a></div>
<div class="text-danger text-center"><a href="index.php?command=ventas_xfiltro">Por filtro</a></div>
</div> 

<br />
      <div class="btn btn-sm btn-block btn-success" 
onclick="document.getElementById('altas').style.display='none',document.getElementById('ventas').style.display='none',document.getElementById('fotos').style.display='block'">Fotos</div>
<div id="fotos" class="text-danger" style="display:none;">
<div class="text-danger text-center"><a href="index.php?command=fotos_cac">CAC</a></div>
<div class="text-danger text-center"><a href="index.php?command=fotos_perfil_auditor">Perfil auditores</a></div>
<div class="text-danger text-center"><a href="index.php?command=fotos_perfil_promotor">Perfil promotores</a></div>

</div> 


<br />
      	
</div>
</td>
<td valign="top" width="100%">
<div id="contenedor">
perfiles auditor
</div>
</td>
</table>

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
