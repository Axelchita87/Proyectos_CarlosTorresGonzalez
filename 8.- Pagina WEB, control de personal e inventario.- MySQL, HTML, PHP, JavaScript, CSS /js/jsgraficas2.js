var dataGraficas={};
//Funciones generales
      function r_datos(options){

          options=(options==typeof(undefined))?'':options;
          params=options;
        var datos = $.ajax({
          url:'class/datosgrafica2.php',
    		  type:'post',
    		  dataType:'json',
          data:params,
    		  async:false    		
    	 }).responseText;
        return datos
      }

     
        //Argumentos: ([tipo de gráfica],[contenedor],[opciones de datos],[opciones de gráfica])
      	function dibujarGrafico(type,cont,d_opciones,g_opciones,i_cont) {

          graficaID = cont.replace('grafica','grafica-');
          dataGraficas[graficaID] = $.extend({},dataGraficas[graficaID]) || {};

          dataGraficas[graficaID]['var_opc'] = $.extend({},d_opciones) || {};
          dataGraficas[graficaID]['var_opc2'] = $.extend({},g_opciones) || {};

          datos=r_datos(d_opciones)
          v_datos = JSON.parse(datos);
        	var data = google.visualization.arrayToDataTable(v_datos);

        	var options = g_opciones||{
          	title: 'Ventas Totales Octubre 2014',
          	hAxis: {title: 'Día', titleTextStyle: {color: 'blue'}},
          	vAxis: {title: 'Cantidad de productos', titleTextStyle: {color: 'blue'}},
          	backgroundColor:'#ffffff',
          	legend:{position: 'right', textStyle: {color: 'blue', fontSize: 13}},
            height:300
        	};          
          

          dataGraficas[graficaID]['data'] = $.extend([],v_datos);

          switch(type){
        	     case 'barra':
                      var grafico = new google.visualization.ColumnChart(document.getElementById(cont));
                      var i_grafico = new google.visualization.ColumnChart(document.getElementById(i_cont));
                      break;
               case 'pastel':
                      var grafico = new google.visualization.PieChart(document.getElementById(cont));
                      var i_grafico = new google.visualization.PieChart(document.getElementById(i_cont));
                      break;
               case 'poli':
                      var grafico = new google.visualization.AreaChart(document.getElementById(cont));
                      var i_grafico = new google.visualization.AreaChart(document.getElementById(i_cont));
                      break;
               case 'geo':
                      var grafico = new google.visualization.GeoChart(document.getElementById(cont));
                      var i_grafico = new google.visualization.GeoChart(document.getElementById(i_cont));
                      break;
               case 'tabla':
                      var grafico = new google.visualization.Table(document.getElementById(cont));
                      var i_grafico = new google.visualization.Table(document.getElementById(i_cont));
                      break; 
               default: 
                      var grafico = new google.visualization.ColumnChart(document.getElementById(cont));
                      var i_grafico = new google.visualization.ColumnChart(document.getElementById(i_cont));
                      break;
          }

         

        	grafico.draw(data, options);
          options.width=500;
          options.height=270;
          i_grafico.draw(data, options);
      	}


        function repintarGrafico(tablaDatos, options, cont, tipo) {
          var data = google.visualization.arrayToDataTable(tablaDatos);
          console.log('Cont: '+cont)

          switch(tipo){
               case 'barra':
                      var grafico = new google.visualization.ColumnChart(document.getElementById(cont));
                      break;
               case'pastel':
                      var grafico = new google.visualization.PieChart(document.getElementById(cont));
                      break;
               case'poli':
                      var grafico = new google.visualization.AreaChart(document.getElementById(cont));
                      break;
               case'geo':
                      var grafico = new google.visualization.GeoChart(document.getElementById(cont));
                      break;
               case'tabla':
                      var grafico = new google.visualization.Table(document.getElementById(cont));
                      break; 
               default: 
                      var grafico = new google.visualization.ColumnChart(document.getElementById(cont));
                      break;
          }

          grafico.draw(data, options);
        }

//Funciones para graficar
        
        function filtrar(tipo) {

          var var_opc = $.extend( {}, tipo );

          //Inicio de Gaficas Visibles

            dataGraficas['cont-detalles']={}

            abr_opciones = dataGraficas['cont-detalles']['opciones'] = {
              id:'cont-detalles',
              tipo:'tabla',
              titulo:'',
              titulo_label_x:'',
              titulo_label_y:'',
              input:'tg',
              i_div:'i_cont-detalles',
              contenedor:'cont-detalles'
            };

            abr_var_opc = dataGraficas['cont-detalles']['var_opc'] = {
              promotor :  $('#promotor').val(),
              estado   :  $('#estados').val(),
              fecha_i  :  $('#fecha_i').val(),
              fecha_f  :  $('#fecha_f').val(),
              categoria:  'ventas',
              valores  :  [$('#operadores_grafica').val()+":"+$('#valores_grafica').val()],
              n_serie  :  $('#names_textarea').val(),
              v_series :  $('#value_textarea').val(),
              c_series :  $('#categoria_textarea').val(),
              funcion  :  'tabla_detalles'
            };

            abr_var_opc.tipo_tabla='tabla';

            abr_var_opc2 = dataGraficas['cont-detalles']['var_opc2'] = {        
              title: 'Detalles de ventas',
              hAxis: {title: 'Día', titleTextStyle: {color: 'blue'}},
              vAxis: {title: 'Cantidad de productos', titleTextStyle: {color: 'blue'}},
              backgroundColor:'#ffffff',
              legend:{position: 'right', textStyle: {color: 'blue', fontSize: 13}},
              cssClassNames:{headerCell: 'headerCell',tableCell: 'tableCell'}     
            };

            console.log(dataGraficas)

            for (var valor in dataGraficas){
              console.log('DIV:'+dataGraficas[valor]['opciones'].id)
              //dibujarGrafico(dataGraficas[valor]['opciones'].tipo,dataGraficas[valor]['opciones'].contenedor, dataGraficas[valor]['var_opc'],dataGraficas[valor]['var_opc2'],dataGraficas[valor]['opciones'].i_div);

              abr_opciones = dataGraficas[valor]['opciones'];
              abr_var_opc = dataGraficas[valor]['var_opc']
              abr_var_opc.promotor = $('#promotor').val(),
              abr_var_opc.estado   = $('#estados').val(),
              abr_var_opc.fecha_i  = $('#fecha_i').val(),
              abr_var_opc.fecha_f  = $('#fecha_f').val(),
              
              abr_var_opc2 = dataGraficas[valor]['var_opc2'];

              dibujarGrafico(abr_opciones.tipo,abr_opciones.contenedor,abr_var_opc,abr_var_opc2,abr_opciones.i_div);
            }



          //Fin de Graficas visibles

          $.redimensionar_SlidePanel();
 
        }

        function repintar(){

          for (var valor in dataGraficas){
            repintarGrafico(dataGraficas[valor].data,dataGraficas[valor].var_opc2,dataGraficas[valor].opciones.contenedor,dataGraficas[valor].opciones.tipo);
          }


          $.redimensionar_SlidePanel();
          console.log("repintadas");
          //console.log(dataGraficas[5]);

        }


        function datos_generales(){
            var valores = r_datos({'promotor':$('#promotor').val(), 'estado':$('#estados').val(), 'fecha_i':$('#fecha_i').val(), 'fecha_f':$('#fecha_f').val(),'cac':$('#cac_menu').val(),'categoria':'inventario','funcion':'datos_generales'});

            var v_valores = JSON.parse(valores);

            //Ocultar foto de promotor
            if($('#promotor').val()!=0){
              $('#foto').show();

              //Recuperar información
              console.log(v_valores[0][1])
              $('#campo-inventarioi').html(v_valores[0][0]=='N/D'?"No disponible":v_valores[0][0]);
              $('#campo-ventas').html(v_valores[0][1]=='N/D'?"No disponible":v_valores[0][1]);
              $('#campo-stock').html(v_valores[0][2]=='N/D'?"No disponible":v_valores[0][2]);
              $('#img-foto').attr('src',v_valores[0][3]=='N/D'?"No disponible":"uploads/usuarios/thumbs/"+v_valores[0][3]);
            }else{
			        $('#campo-inventarioi').html(v_valores[0][0]=='N/D'?"No disponible":v_valores[0][0]);
              $('#campo-ventas').html(v_valores[0][1]=='N/D'?"No disponible":v_valores[0][1]);
              $('#campo-stock').html(v_valores[0][2]=='N/D'?"No disponible":v_valores[0][2]);
              $('#img-foto').attr('src',v_valores[0][3]=='N/D'?"No disponible":"images/"+v_valores[0][3]);
              $('#foto').hide();
            }


        }


        $(function(){

          $('#foto').hide();

          //Recoge datos de fecha

          $('#fecha_f').hide();

          $('#fecha_i').datetimepicker({format:'Y/m/d',defaultDate:new Date()});
          $('#fecha_f').datetimepicker({
            format:'Y/m/d',
              onShow:function( ct ){
                this.setOptions({
                  minDate:jQuery('#fecha_i').val()?jQuery('#fecha_i').val():false
                })
              },
              timepicker:false
          });

          $('#fecha_i').on('change', function(){
            if($('#fecha_i').val()!=''){
              $('#fecha_f').show();

              //Reporte General
              $('#campo-periodo').html($('#fecha_i').val())
            }
            datos_generales();
          })
          $('#fecha_f').on('change', function(){
            $('#campo-periodo').html($('#fecha_i').val()+" al "+$('#fecha_f').val())
            datos_generales();
          })


          //Visualizar tabla

          $('#cont-detalles').toggle();
          $('#btn-detalles').click(function(){
            $('#cont-detalles').toggle('slow');
          });

          $(window).resize(function(){
            repintar();
          });

          $('#btn_buscar_filtrar').click(function (){
            filtrar({'promotor':$('#promotor').val(), 'estado':$('#estados').val(), 'fecha_i':$('#fecha_i').val(), 'fecha_f':$('#fecha_f').val(), 'cac':$('#cac_menu').val()});
            datos_generales();
          })


          
        })

        //inicializar

          function iniciar(){
            $('#fecha_i').val(function(){
              fecha = new Date().getFullYear()+"/"+("0" + (new Date().getMonth()+1)).slice(-2)+"/"+("0" + new Date().getDate()).slice(-2);

              $('#campo-periodo').html(fecha);
              return(fecha)
            });
            $('#fecha_i').change();
            filtrar({'promotor':$('#promotor').val(), 'estado':$('#estados').val(), 'fecha_i':$('#fecha_i').val(), 'fecha_f':$('#fecha_f').val(), 'cac':$('#cac_menu').val()});
            datos_generales();
          }

          


        google.load("visualization", "1", {packages:["corechart"]});
        google.load("visualization", "1", {packages:["table"]});
        google.setOnLoadCallback(function(){iniciar();});


