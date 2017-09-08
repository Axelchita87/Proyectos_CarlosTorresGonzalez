$(function(){

  recuperaImagen=function(cont, c_input) {
    var cabecera = "<\?xml version=\"1.0\" encoding=\"ISO-8859-1\" standalone=\"no\"?><!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\" \"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">";
  
    var svg = (cont[0]).getElementsByTagName("svg")[0];
    var svg_xml = cabecera+(new XMLSerializer).serializeToString(svg);   // extract the data as SVG text
    var data_uri = "data:image/svg+xml;base64," + window.btoa(svg_xml);
  
    var image = new Image();
    image.src = data_uri;
    


    image.onload = function()
      {
        var canvas = document.createElement("canvas");
        canvas.width = image.width;
        canvas.height = image.height;

        var context = canvas.getContext("2d");
        context.clearRect(0, 0, image.width, image.height);
        context.drawImage(image, 0, 0);

        var a = document.createElement("a");
        a.download = "file.jpg";
        a.href = canvas.toDataURL("image/jpeg");
        //a.click ();
        c_input.attr('value',canvas.toDataURL("image/jpeg"));
        //window.open(a.href, "_blank");
      };
    if (image.complete == true){image.onload()}
    
  };

  $('#imprimir').click(function(){

    var cont_panel_general= '<div class="panel panel-default col-md-6 col-sm-6 col-xs-12" style="min-height:270px;float:left;padding:5px;" id="reporte">'+
                              '<div class="header panel-heading">Reporte General</div><div class="panel-body">'+
                                $("#reporte .panel-body").html()+
                              '</div>'+
                            '</div>';

    var arr_panel_general= [$("#campo-periodo").html(),$("#campo-inventarioi").html(),$("#campo-ventas").html(),$("#campo-stock").html(),$("#img-foto").attr('src')];

    $("#dg").val(arr_panel_general);
    recuperaImagen($("#i_grafica1 div div"), $('#g1'));
    recuperaImagen($("#i_grafica2 div div"), $('#g2'));
    recuperaImagen($("#i_grafica3 div div"), $('#g3'));
    recuperaImagen($("#i_grafica4 div div"), $('#g4'));
    $("#tg").val($("#i_cont-detalles div div").html());

    console.log($('#dg').val()+"\n"+$('#g1').val()+"\n"+$('#g2').val()+"\n"+$('#g3').val()+"\n"+$('#g4').val()+"\n"+$('#tg').val());

    id = setTimeout(function(){
      if($('#dg').val()!='' && $('#g1').val()!='' && $('#g2').val()!='' && $('#g3').val()!='' && $('#g4').val()!='' && $('#tg').val()!=''){
        $('#f_imprimir').submit();
        clearTimeout(id);
      }
    }, 300);
    
  });

  $('#imprimir_perfil_usuario').click(function(e){
    console.log("hola")
    e.preventDefault(); //prevents the default submit action
    var action = $('#form-alta').attr('action');
    $('#form-alta').attr('action','imprimir.php?command=imprimir_perfil_usuario');
    $('#form-alta').closest('form').attr('target', '_blank').submit().removeAttr('target');
    $('#form-alta').attr('action',action);
  });
  $('#imprimir_perfil_usuarioA').click(function(e){
    console.log("hola")
    e.preventDefault(); //prevents the default submit action
    var action = $('#form-alta').attr('action');
    $('#form-alta').attr('action','imprimir.php?command=imprimir_perfil_usuarioA');
    $('#form-alta').closest('form').attr('target', '_blank').submit().removeAttr('target');
    $('#form-alta').attr('action',action);
  });
          
})

        //inicializar


