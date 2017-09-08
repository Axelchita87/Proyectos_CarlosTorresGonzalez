<?php
require_once 'class/class.db.php';

if(isset($_SESSION['user']) && $_SESSION['permiso']=='directivo'){

//Inicio script PDF

?>

<?php
ob_start();
?> 


<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en"> 
<head> 
<title>Impresión</title> 

<style type="text/css">

#header,
#footer {color: #aaa;font-size: 0.9em;}
#header{border-bottom: .5px solid #F11111;height:1.5cm;}
#footer {border-top: .5px solid #F11111;color:#F11111;}
#header table,#footer table {width: 100%;border-collapse: collapse;border: none;padding:0;}
#header td,#footer td {padding: 0;width: 50%;}
.page-number {text-align: center;}
#logo-encabezado{height:50px;}

</style>

</head> 
<body> 

<div id="contenedor">
    
</div>



</body> 
</html> 

<?php

$html = ob_get_contents();
ob_end_clean();

$mpdf = new mPDF('',    // mode - default ''
'Letter',    // format - A4, for example, default ''
0,     // font size - default 0
'',    // default font family
15,    // margin_left
15,    // margin right
28,    // margin top
16,    // margin bottom
9,     // margin header
9,     // margin footer
'L');  // L - landscape, P - portrait

//Configuración

//$mpdf->setAutoTopMargin="pad";
//$mpdf->setAutoBottomMargin="pad";

//Documento

$mpdf->SetHTMLHeader('
<div id="header">
  <table>
    <tr>
      <td>Título</td>
      <td style="text-align: right;"><img id="logo-encabezado" src="images/logoP.jpg"></td>
    </tr>
  </table>
</div>
');
$mpdf->SetHTMLFooter('
<div id="footer">
  <div class="page-number">{PAGENO}</div>
</div>
  ');
$mpdf->WriteHTML($html);

$mpdf->Output();

exit;

?>


<?php

//Fin Script PDF

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