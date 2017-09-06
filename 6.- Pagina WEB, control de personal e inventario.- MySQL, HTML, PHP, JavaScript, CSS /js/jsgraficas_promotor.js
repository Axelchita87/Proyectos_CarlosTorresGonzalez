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
               
			   case 'cont-cuotas':
                      dataGraficas[0]=[];
                      dataGraficas[0][0]= $.extend({},options);
                      dataGraficas[0][1]=$.extend([],v_datos);
					  break;
               default: 
                      console.log(cont)
                      break;
          }
			

          switch(type){
        	     case 'barra':
                      var grafico = new google.visualization.ColumnChart(document.getElementById(cont));
                      break;
               case 'pastel':
                      var grafico = new google.visualization.PieChart(document.getElementById(cont));
                      break;
               case 'poli':
                      var grafico = new google.visualization.AreaChart(document.getElementById(cont));
                      break;
               case 'geo':
                      var grafico = new google.visualization.GeoChart(document.getElementById(cont));
                      break;
               case 'tabla':
                      var grafico = new google.visualization.Table(document.getElementById(cont));
                      break; 
               default: 
                      var grafico = new google.visualization.ColumnChart(document.getElementById(cont));
                      break;
          }

         			

        	grafico.draw(data, options);
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

         
						
		  var_opc = $.extend( {}, tipo );
          var_opc.categoria='cuotas';
          var_opc.funcion='tabla_cuotas_usuario';
          dibujarGrafico('tabla','cont-cuotas', var_opc,
                          {title: 'Detalles de cuotas',
                           hAxis: {title: 'Día', titleTextStyle: {color: 'blue'}},
                           vAxis: {title: 'Cantidad de productos', titleTextStyle: {color: 'blue'}},
                           backgroundColor:'#ffffff',
                           legend:{position: 'right', textStyle: {color: 'blue', fontSize: 13}},
                           cssClassNames:{headerCell: 'headerCell',tableCell: 'tableCell'}
                                                     
                          },
                          'i_cont-detalles'
                        );

         

          //Fin de Graficas visibles

          $.redimensionar_SlidePanel();
            console.log("Creadas");
            //console.log(dataGraficas);
            //console.log(dataGraficas[5]);
        }

        function repintar(){

          
						
		  repintarGrafico(dataGraficas[0][1], 
                          dataGraficas[0][0],
                          'cont-cuotas',
                          'tabla'
                        );
		  


          $.redimensionar_SlidePanel();
          console.log("repintadas");
          console.log(dataGraficas);
          //console.log(dataGraficas[5]);

        }



        $(function(){        


          //Visualizar tabla

          $(window).resize(function(){
            repintar();
          });

          $('#btn_buscar_filtrar').click(function (){
            filtrar({'promotor':$('#promotor').val(), 'estado':$('#estados').val(), 'fecha_i':$('#fecha_i').val(), 'fecha_f':$('#fecha_f').val(), 'cac':$('#cac_menu').val()});
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
          }

          


        google.load("visualization", "1", {packages:["corechart"]});
        google.load("visualization", "1", {packages:["table"]});
        google.setOnLoadCallback(function(){iniciar();});


