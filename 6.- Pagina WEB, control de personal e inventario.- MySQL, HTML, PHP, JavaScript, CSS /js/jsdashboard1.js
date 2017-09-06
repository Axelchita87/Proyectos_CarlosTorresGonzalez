var dataGraficas=[];
//Funciones generales
      function rd_datos(options){

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
          datos=rd_datos(d_opciones)
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
               
               default: 
                      console.log(cont)
                      break;
          }

          switch(type){
        	     case 'barra':
                      var grafico = new google.visualization.ColumnChart(document.getElementById(cont));
                      //var i_grafico = new google.visualization.ColumnChart(document.getElementById(i_cont));
                      break;
               case 'pastel':
                      var grafico = new google.visualization.PieChart(document.getElementById(cont));
                      //var i_grafico = new google.visualization.PieChart(document.getElementById(i_cont));
                      break;
               case 'poli':
                      var grafico = new google.visualization.AreaChart(document.getElementById(cont));
                      //var i_grafico = new google.visualization.AreaChart(document.getElementById(i_cont));
                      break;
               case 'geo':
                      var grafico = new google.visualization.GeoChart(document.getElementById(cont));
                      //var i_grafico = new google.visualization.GeoChart(document.getElementById(i_cont));
                      break;
               case 'tabla':
                      var grafico = new google.visualization.Table(document.getElementById(cont));
                      //var i_grafico = new google.visualization.Table(document.getElementById(i_cont));
                      break; 
               default: 
                      var grafico = new google.visualization.ColumnChart(document.getElementById(cont));
                      //var i_grafico = new google.visualization.ColumnChart(document.getElementById(i_cont));
                      break;
          }

         

        	grafico.draw(data, options);
          //options.width=500;
          //options.height=270;
          //i_grafico.draw(data, options);
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
          var_opc.categoria='estado';
          var_opc.tipo_tabla='pastel';  
          var_opc.funcion='geo_ventas';
          dibujarGrafico('geo','grafica1', var_opc,
                          {//title: 'Ventas totales por estado',
                           hAxis: {title: 'Día', titleTextStyle: {color: '#00a65a'}},
                           vAxis: {title: 'Cantidad de productos', titleTextStyle: {color: '#00a65a'}},
                           backgroundColor:'#ffffff',
                           legend:{position: 'right', textStyle: {color: '#00a65a', fontSize: 13}},
                           region:'MX',
                           resolution: 'provinces',
                           height:300,
                           tipo_grafica:'geo',
                           //datalessRegionColor:'#00a65a',
                           //magnifyingGlass.enable:'true',
                           colorAxis:{colors:["#00a65a"]}
                          },
                          'i_grafica1'
                        );         

          //Fin de Graficas visibles

            console.log("Creadas");
            //console.log(dataGraficas);
            //console.log(dataGraficas[5]);
        }

        function repintar(){

          

          repintarGrafico(dataGraficas[2][1], 
                          dataGraficas[2][0],
                          'grafica1',
                          'geo'
                        );

          

          console.log("repintadas");
          console.log(dataGraficas);
          //console.log(dataGraficas[5]);

        }


        


        $(function(){

          

          

          




          
        })

        //inicializar

          function iniciar(){
            
            filtrar({'promotor':'0', 'estado':'0', 'fecha_i':'2015/03/17', 'fecha_f':'2015/06/17', 'cac':'0'});
          }

          


        google.load("visualization", "1", {packages:["corechart"]});
        google.load("visualization", "1", {packages:["table"]});
        google.setOnLoadCallback(function(){iniciar();});


