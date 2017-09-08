var dataGraficas=[];
//Funciones generales
      function r_datos(options){

          options=(options==typeof(undefined))?'':options;
          params=options;
        var datos = $.ajax({
          url:'class/datosgrafica.php',
    		  type:'post',
    		  dataType:'json',
          data:params,
    		  async:false    		
    	 }).responseText;
        return datos
      }

     
        //Argumentos: ([tipo de gráfica],[contenedor],[opciones de datos],[opciones de gráfica])
      	function dibujarGrafico(type,cont,d_opciones,g_opciones,i_cont) {
          datos=r_datos(d_opciones)
          v_datos = JSON.parse(datos);
        	var data = google.visualization.arrayToDataTable(v_datos);

        	var options = g_opciones||{
          	title: 'Ventas Totales Octubre 2014',
          	hAxis: {title: 'Día', titleTextStyle: {color: 'blue'}},
          	vAxis: {title: 'Cantidad de productos', titleTextStyle: {color: 'blue'}},
          	backgroundColor:'#ffffff',
          	legend:{position: 'right', textStyle: {color: 'blue', fontSize: 13}},
          	width:500,
            height:300
        	};

          switch(cont){
               case 'grafica1':
                      dataGraficas[0]=[];
                      dataGraficas[0][0]= $.extend({},options);
                      dataGraficas[0][1]=$.extend([],v_datos);
                      break;
               case 'grafica2':
                      dataGraficas[1]=[];
                      dataGraficas[1][0]= $.extend({},options);
                      dataGraficas[1][1]=$.extend([],v_datos);
                      break;
               case 'grafica3':
                      console.log(v_datos);
                      dataGraficas[2]=[];
                      dataGraficas[2][0]= $.extend({},options);
                      dataGraficas[2][1]=$.extend([],v_datos);
                      break;
               case 'grafica4':
                      dataGraficas[3]=[];
                      dataGraficas[3][0]= $.extend({},options);
                      dataGraficas[3][1]=$.extend([],v_datos);
                      break;
               case 'grafica5':
                      dataGraficas[4]=[];
                      dataGraficas[4][0]= $.extend({},options);
                      dataGraficas[4][1]=$.extend([],v_datos);
                      break; 
               case 'cont-detalles':
                      dataGraficas[5]=[];
                      dataGraficas[5][0]= $.extend({},options);
                      dataGraficas[5][1]=$.extend([],v_datos);
                      break;
			   case 'cont-cuotas':
                      dataGraficas[6]=[];
                      dataGraficas[6][0]= $.extend({},options);
                      dataGraficas[6][1]=$.extend([],v_datos);
                      break;
               default: 
                      console.log(cont)
                      break;
          }

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

          var_opc.categoria='producto';
          var_opc.tipo_tabla='pastel';
          var_opc.funcion='pastel_productos';

          //console.log(tipo);

          dibujarGrafico('pastel','grafica1',var_opc,
                          {title: 'Ventas totales de productos al día',
                           hAxis: {title: 'Día', titleTextStyle: {color: 'blue'}},
                           vAxis: {title: 'Cantidad de productos', titleTextStyle: {color: 'blue'}},
                           backgroundColor:'#ffffff',
                           legend:{position: 'right', textStyle: {color: 'blue', fontSize: 13}},
                           region:'MX',
                           resolution: 'provinces',
                           height:300,
                           tipo_grafica:'pastel',
                           pieHole:0.4
                          },
                          'i_grafica1'
                        );

          var_opc = $.extend( {}, tipo );
          var_opc.categoria='usuario';
          var_opc.funcion='barra_ventas_usuarios';
          dibujarGrafico('barra','grafica2', var_opc,
                          {//title: 'Ventas totales por usuario al dia',
                           hAxis: {title: 'Día', titleTextStyle: {color: 'blue'}},
                           vAxis: {title: 'Cantidad de productos', titleTextStyle: {color: 'blue'}},
                           backgroundColor:'#ffffff',
                           legend:{position: 'right', textStyle: {color: 'blue', fontSize: 13}},
                           //region:'MX',
                           //resolution: 'provinces',
                            height:300,
                           //isStacked: true,
                           tipo_grafica:'barra'
                          },
                          'i_grafica2'
                        );

          var_opc = $.extend( {}, tipo );
          var_opc.categoria='estado';
          var_opc.tipo_tabla='pastel';  
          var_opc.funcion='geo_ventas';
          dibujarGrafico('geo','grafica3', var_opc,
                          {//title: 'Ventas totales por estado',
                           hAxis: {title: 'Día', titleTextStyle: {color: 'blue'}},
                           vAxis: {title: 'Cantidad de productos', titleTextStyle: {color: 'blue'}},
                           backgroundColor:'#ffffff',
                           legend:{position: 'right', textStyle: {color: 'blue', fontSize: 13}},
                           region:'MX',
                           resolution: 'provinces',
                           height:300,
                           tipo_grafica:'geo',
                           //magnifyingGlass.enable:'true',
                           colorAxis:{colors:["blue"]}
                          },
                          'i_grafica3'
                        );

          var_opc = $.extend( {}, tipo );
          var_opc.categoria='inventario';
          var_opc.funcion='barra_ventas_promedio';
          dibujarGrafico('poli','grafica4', var_opc,
                          {//title: 'Promedio de inventario y total de ventas',
                           hAxis: {title: 'Día', titleTextStyle: {color: 'blue'}},
                           vAxis: {title: 'Cantidad de productos', titleTextStyle: {color: 'blue'}},
                           backgroundColor:'#ffffff',
                           legend:{position: 'right', textStyle: {color: 'blue', fontSize: 13}},
                           region:'MX',
                           resolution: 'provinces',
                           height:300,
                           tipo_grafica:'barra',
                           viewWindow: {min: 0}
                          },
                          'i_grafica4'
                        );

          var_opc = $.extend( {}, tipo );
          var_opc.categoria='inventario';
          var_opc.funcion='barra_ventas_totales';
          dibujarGrafico('barra','grafica5', var_opc,
                          {//title: 'Promedio de inventario y total de ventas',
                           hAxis: {title: 'Día', titleTextStyle: {color: 'blue'}},
                           vAxis: {title: 'Cantidad de productos', titleTextStyle: {color: 'blue'}},
                           backgroundColor:'#ffffff',
                           legend:{position: 'right', textStyle: {color: 'blue', fontSize: 13}},
                           region:'MX',
                           resolution: 'provinces',
                           height:300,
                           tipo_grafica:'pastel'
                          },
                          'i_grafica5'
                        );
						
		  var_opc = $.extend( {}, tipo );
          var_opc.categoria='cuotas';
          var_opc.funcion='tabla_cuotas_cac';
          dibujarGrafico('tabla','cont-cuotas', var_opc,
                          {//title: 'Detalles de cuotas',
                           hAxis: {title: 'Día', titleTextStyle: {color: 'blue'}},
                           vAxis: {title: 'Cantidad de productos', titleTextStyle: {color: 'blue'}},
                           backgroundColor:'#ffffff',
                           legend:{position: 'right', textStyle: {color: 'blue', fontSize: 13}},
                           cssClassNames:{headerCell: 'headerCell',tableCell: 'tableCell'}
                                                     
                          },
                          'i_cont-detalles'
                        );

          var_opc = $.extend( {}, tipo );
          var_opc.categoria='ventas';
          var_opc.funcion='tabla_detalles';
          dibujarGrafico('tabla','cont-detalles', var_opc,
                          {//title: 'Detalles de ventas',
                           hAxis: {title: 'Día', titleTextStyle: {color: 'blue'}},
                           vAxis: {title: 'Cantidad de productos', titleTextStyle: {color: 'blue'}},
                           backgroundColor:'#ffffff',
                           legend:{position: 'right', textStyle: {color: 'blue', fontSize: 13}},
                           cssClassNames:{headerCell: 'headerCell',tableCell: 'tableCell'}
                                                     
                          },
                          'i_cont-detalles'
                        );

          //Fin de Graficas visibles

            console.log("Creadas");
            //console.log(dataGraficas);
            //console.log(dataGraficas[5]);
        }

        function repintar(){

          repintarGrafico(dataGraficas[0][1], 
                          dataGraficas[0][0],
                          'grafica1',
                          'pastel'
                        );
          

          repintarGrafico(dataGraficas[1][1], 
                          dataGraficas[1][0],
                          'grafica2',
                          'barra'
                        );

          repintarGrafico(dataGraficas[2][1], 
                          dataGraficas[2][0],
                          'grafica3',
                          'geo'
                        );

          repintarGrafico(dataGraficas[3][1], 
                          dataGraficas[3][0],
                          'grafica4',
                          'barra'
                        );

          repintarGrafico(dataGraficas[4][1], 
                          dataGraficas[4][0],
                          'grafica5',
                          'barra'
                        );
						
		  repintarGrafico(dataGraficas[6][1], 
                          dataGraficas[6][0],
                          'cont-cuotas',
                          'tabla'
                        );
		  
          repintarGrafico(dataGraficas[5][1], 
                          dataGraficas[5][0],
                          'cont-detalles',
                          'tabla'
                        );

          console.log("repintadas");
          console.log(dataGraficas);
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

          $('#fecha_f').parent().parent().hide();

          //$('#fecha_i').datetimepicker({format:'Y/m/d',defaultDate:new Date()});
          //$('#fecha_f').datetimepicker({
          //  format:'Y/m/d',
          //    onShow:function( ct ){
          //      this.setOptions({
          //        minDate:jQuery('#fecha_i').val()?jQuery('#fecha_i').val():false
          //      })
          //    },
          //    timepicker:false
          //});

          $('#fecha_i').on('change', function(){
            if($('#fecha_i').val()!=''){
              $('#fecha_f').parent().parent().show();

              //Reporte General
              $('#campo-periodo').html($('#fecha_i').val())
            }

          })
          $('#fecha_f').on('change', function(){
            $('#campo-periodo').html($('#fecha_i').val()+" al "+$('#fecha_f').val())

          })


          //Visualizar tabla
		  
		      
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


