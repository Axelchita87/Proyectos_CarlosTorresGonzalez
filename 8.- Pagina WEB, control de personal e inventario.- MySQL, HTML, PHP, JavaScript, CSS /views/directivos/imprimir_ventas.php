<?php

ob_start();


if(isset($_POST['dg'])){
    $dg = explode(",",$_POST['dg']);    
}

if(isset($_POST['g1'])){
    $g1 = $_POST['g1']; 
}


if(isset($_POST['g2'])){
    $g2 = $_POST['g2']; 
}


if(isset($_POST['g3'])){
    $g3 = $_POST['g3']; 
}


if(isset($_POST['g4'])){
    $g4 = $_POST['g4']; 
}


if(isset($_POST['g5'])){
    $g5 = $_POST['g5']; 
}

if(isset($_POST['tg'])){
    $tg = str_replace('\\',"",$_POST['tg']);    
}

?> 


<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en"> 
<head> 
<title></title> 



<style>

.charts-inline-block{position:relative;display:-moz-inline-box;display:inline-block}
* html .charts-inline-block,*:first-child+html .charts-inline-block{display:inline}
.charts-custom-button{margin:2px;border:0;padding:0;font-family:Arial,sans-serif;color:#000;background:#ddd url(//ssl.gstatic.com/editor/button-bg.png) repeat-x top left;text-decoration:none;list-style:none;vertical-align:middle;cursor:default;outline:none}
.charts-custom-button-outer-box,.charts-custom-button-inner-box{border-style:solid;border-color:#aaa;vertical-align:top}
.charts-custom-button-outer-box{margin:0;border-width:1px 0;padding:0}
.charts-custom-button-inner-box{margin:0 -1px;border-width:0 1px;padding:3px 4px;white-space:nowrap}
* html .charts-custom-button-inner-box{left:-1px}
* html .charts-custom-button-rtl .charts-custom-button-outer-box{left:-1px}
* html .charts-custom-button-rtl .charts-custom-button-inner-box{right:auto}
*:first-child+html .charts-custom-button-inner-box{left:-1px}
*:first-child+html .charts-custom-button-rtl .charts-custom-button-inner-box{left:1px}
::root .charts-custom-button{line-height:0}
::root .charts-custom-button-outer-box{line-height:0}
::root .charts-custom-button-inner-box{line-height:normal}
.charts-custom-button-disabled{background-image:none!important;opacity:.3;-moz-opacity:.3;filter:alpha(opacity=30)}
.charts-custom-button-disabled .charts-custom-button-outer-box,.charts-custom-button-disabled .charts-custom-button-inner-box{color:#333!important;border-color:#999!important}
* html .charts-custom-button-disabled,*:first-child+html .charts-custom-button-disabled{margin:2px 1px!important;padding:0 1px!important}
.charts-custom-button-hover .charts-custom-button-outer-box,.charts-custom-button-hover .charts-custom-button-inner-box{border-color:#9cf #69e #69e #7af!important}
.charts-custom-button-active,.charts-custom-button-checked{background-color:#bbb;background-position:bottom left}
.charts-custom-button-focused .charts-custom-button-outer-box,.charts-custom-button-focused .charts-custom-button-inner-box{border-color:orange}
.charts-custom-button-collapse-right,.charts-custom-button-collapse-right .charts-custom-button-outer-box,.charts-custom-button-collapse-right .charts-custom-button-inner-box{margin-right:0}
.charts-custom-button-collapse-left,.charts-custom-button-collapse-left .charts-custom-button-outer-box{margin-left:0}
.charts-custom-button-collapse-left .charts-custom-button-inner-box{margin-left:0;border-left:1px solid #fff}
.charts-custom-button-collapse-left.charts-custom-button-checked .charts-custom-button-inner-box{border-left:1px solid #ddd}
* html .charts-custom-button-collapse-left .charts-custom-button-inner-box,*:first-child+html .charts-custom-button-collapse-left .charts-custom-button-inner-box{left:0}
.charts-flat-button{position:relative;margin:2px;border:1px solid #000;padding:2px 6px;font:normal 13px 'Trebuchet MS',Tahoma,Arial,sans-serif;color:#fff;background-color:#8c2425;cursor:pointer;outline:none}
.charts-flat-button-disabled{border-color:#888;color:#888;background-color:#ccc;cursor:default}
.charts-flat-button-hover{border-color:#8c2425;color:#8c2425;background-color:#eaa4a5}
.charts-flat-button-active,.charts-flat-button-selected,.charts-flat-button-checked{border-color:#5b4169;color:#5b4169;background-color:#d1a8ea}
.charts-flat-button-focused{border-color:#5b4169}
.charts-flat-button-collapse-right{margin-right:0}
.charts-flat-button-collapse-left{margin-left:0;border-left:none}
.charts-button{color:#036;border-color:#036;background-color:#69c}
.charts-button-disabled{border-color:#333;color:#333;background-color:#999}
.charts-button-hover{color:#369;border-color:#369;background-color:#9cf}
.charts-button-active{color:#69c;border-color:#69c}
.google-visualization-table-table{font-family:arial,helvetica;font-size:10pt;cursor:default;margin:0;background:white;border-spacing:0}
.google-visualization-table-table tbody{background:transparent}
.google-visualization-table-table *{margin:0;vertical-align:middle;padding:2px}
.google-visualization-table-tr-head .gradient,.google-visualization-table-tr-head-nonstrict .gradient,.google-visualization-table-div-page .gradient{background:#fff url('//ssl.gstatic.com/charts/static/table-title-bg.gif') repeat-x left bottom;background:-moz-linear-gradient(top,rgba(255,255,255,1) 0%,rgba(249,250,253,1) 30%,rgba(238,242,247,1) 60%,rgba(228,233,244,1) 100%);background:-webkit-gradient(linear,left top,left bottom,color-stop(0%,rgba(255,255,255,1)),color-stop(30%,rgba(249,250,253,1)),color-stop(60%,rgba(238,242,247,1)),color-stop(100%,rgba(228,233,244,1)));background:-webkit-linear-gradient(top,rgba(255,255,255,1) 0%,rgba(249,250,253,1) 30%,rgba(238,242,247,1) 60%,rgba(228,233,244,1) 100%);background:-o-linear-gradient(top,rgba(255,255,255,1) 0%,rgba(249,250,253,1) 30%,rgba(238,242,247,1) 60%,rgba(228,233,244,1) 100%);background:-ms-linear-gradient(top,rgba(255,255,255,1) 0%,rgba(249,250,253,1) 30%,rgba(238,242,247,1) 60%,rgba(228,233,244,1) 100%);background:linear-gradient(to bottom,rgba(255,255,255,1) 0%,rgba(249,250,253,1) 30%,rgba(238,242,247,1) 60%,rgba(228,233,244,1) 100%);filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#ffffff',endColorstr='#e4e9f4',GradientType=0)}
.google-visualization-table-tr-head,.google-visualization-table-tr-head td,.google-visualization-table-tr-head-nonstrict{font-weight:bold;text-align:center}
.google-visualization-table-tr-even,.google-visualization-table-tr-even td,.google-visualization-table-tr-even-nonstrict{background-color:#fff}
.google-visualization-table-tr-odd,.google-visualization-table-tr-odd td,.google-visualization-table-tr-odd-nonstrict{background-color:#fafafa}
.google-visualization-table-tr-sel,.google-visualization-table-tr-sel td,.google-visualization-table-tr-sel-nonstrict{background-color:#d6e9f8}
.google-visualization-table-tr-over,.google-visualization-table-tr-over td,.google-visualization-table-tr-over-nonstrict{background-color:#e7e9f9}
.google-visualization-table-sorthdr{cursor:pointer}
.google-visualization-table-sortind{color:#ccc;font-size:9px;padding-left:6px}
.google-visualization-table-th{border:1px solid #eee;padding:6px}
.google-visualization-table-th-webkit td,.google-visualization-table-th-webkit-nonstrict{background-color:#fff;border:1px solid #eee;padding:6px}
.google-visualization-table-td-freeze-rightmost{border-right-width:4px}
.google-visualization-table-td{border:1px solid #eee;padding-right:3px;padding-left:3px;padding-top:2px;padding-bottom:2px}
.google-visualization-table-td-bool{text-align:center;font-family:'Arial Unicode MS',Arial,Helvetica}
.google-visualization-table-td-center{text-align:center}
.google-visualization-table-td-number{text-align:right;white-space:nowrap}
.google-visualization-table-seq{text-align:right;color:#666}
.google-visualization-table-div-page{margin:2px 0 0;padding:0;border:0}
.google-visualization-table-div-page [role='button']{display:inline-block;cursor:pointer}
.google-visualization-table-page-numbers{display:inline-block;margin:2px 0;padding:0}
.google-visualization-table-page-numbers .page-number{display:inline-block;border:1px ButtonShadow outset;border-radius:3px;color:black;font-size:.8em;line-height:.9em;min-width:1.5em;margin:2px .25em;padding:.15em .3em .2em .25em;text-align:center;text-decoration:none}
.google-visualization-table-page-numbers .page-number.current{font-weight:bold}
.google-visualization-table-page-numbers .page-number:hover{background:#fefefe;border-color:#fefefe}
.google-visualization-table-loadtest{padding-left:6px}



/*BOOTSTRAP*/



.panel{width:11cm;font-family:'Arial'; font-size: 13px;padding:5px;color: #333;}
#reporte .header {color: #333;text-align: center;background-color: #f5f5f5;}
#reporte .header th{padding:10px;font-size: 12.5px;border-bottom: 1px solid #ddd;}
.label {font-size: 11px;font-weight: bold;text-align: left;}
.campo{font-size: 11px;}

#foto {border: 1px solid #ccc;height: 3cm;width: 2cm;margin-left: .8cm;}
#img-foto{max-height: 3cm;max-width: 2cm;}

.col-sm-4, .col-md-4, .col-xs-6, .col-sm-8, .col-md-8    {
    min-height: 1px;
    padding-left: 15px;
    padding-right: 15px;
    position: relative;
}



#graficas {width:100%;}
.img_chart{width:9cm;}
#graficas .espacio-tr > td{padding-bottom: 1em;}
#graficas .borde-td{border:1px solid #ddd;margin-top:10px;}
.google-visualization-table-table{width:100%;margin-top: 20px;}
h1.title-table{font-size:14px;text-align:center;}
.headerCell {font-size: 10px; background: #e11111;color:#FFF;padding:10px;font-weight: bold;}
.tableCell {font-size: 10px;}
.panel-body td{width:100px;height:3.5cm;}


</style>
<style type="text/css">

#header,
#footer {
    color: #aaa;
    font-size: 0.9em;
}

#header{
    border-bottom: .5px solid #69b40f;
    height:1.5cm;
}

#footer {
  border-top: .5px solid #69b40f;
  color:#69b40f;
}

#header table,
#footer table {
    width: 100%;
    border-collapse: collapse;
    border: none;
    padding:0;
}

#header td,
#footer td {
  padding: 0;
  width: 50%;
}

.page-number {
  text-align: center;
}


#logo-encabezado{height:50px;}

</style>


</head> 
<body> 

<div id="contenedor">
    
    
    <table id="graficas">
        <tr class="espacio-tr">
            <td class="borde-td">
              <table class="panel panel-default col-md-6" id="reporte">
                <tr class="header panel-heading"><th colspan="2">Reporte General</th></tr>
                <tbody>
                  <tr class="panel-body">
                    <td class="col-md-8 col-sm-8 col-xs-6 panel-izq"> 
                        <div class="row grid">
                            <span class="label col-md-6 col-sm-6 col-xs-12">Periodo:</span><div id="campo-periodo" class="campo col-md-6 col-sm-6 col-xs-12"><?php echo $dg[0]; ?></div>
                        </div>
                        <div class="row grid">  
                            <span class="label col-md-6 col-sm-6 col-xs-12">Inventario Inicial:</span><div id="campo-inventarioi" class="campo col-md-6 col-sm-6 col-xs-12"><?php echo $dg[1]; ?></div>
                        </div>
                        <div class="row grid">
                            <span class="label col-md-6 col-sm-6 col-xs-12">Total de ventas:</span><div id="campo-ventas" class="campo col-md-6 col-sm-6 col-xs-12"><?php echo $dg[2]; ?></div>
                        </div>
                        <div class="row grid">
                            <span class="label col-md-6 col-sm-6 col-xs-12">En stock:</span><div id="campo-stock" class="campo col-md-6 col-sm-6 col-xs-12"><?php echo $dg[3]; ?></div>
                        </div>
                    </td> 
                    <td class="col-md-4 col-sm-4 col-xs-6 panel-der">
                        <div class="row grid">  
                            <div id="foto" class=""><img src="<?php echo $dg[4]; ?>" id="img-foto"></div>
                        </div>
                    </td>                   
                  </tr>
                </tbody>
              </table>
            </td>
            <td class="borde-td"><img src="<?php echo $g1; ?>" class="img_chart"></td>
        </tr>
        <tr class="espacio-tr">
            <td class="borde-td"><img src="<?php echo $g2; ?>" class="img_chart"></td>
            <td class="borde-td"><img src="<?php echo $g3; ?>" class="img_chart"></td>
        </tr>
        <tr class="espacio-tr">
            <td class="borde-td"><img src="<?php echo $g4; ?>" class="img_chart"></td>
        </tr>
    </table>

     <?php echo $tg; ?>

    
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
$mpdf->packTableData = "true";


//Documento

$mpdf->SetHTMLHeader('
<div id="header">
  <table>
    <tr>
      <td>Reporte</td>
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