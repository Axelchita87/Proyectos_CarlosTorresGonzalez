<style>

 .modalmask, .modalmask2{
    position: fixed;
    font-family: Arial, sans-serif;
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    background: rgba(0,0,0,0.8);
    z-index: 99999;
    opacity:1;
    -webkit-transition: opacity 400ms ease-in;
    -moz-transition: opacity 400ms ease-in;
    transition: opacity 400ms ease-in;
    pointer-events: none;
    display:none;
}
.modalmask, .modalmask2{
    pointer-events: auto;
}

.modalbox{
    /*width: 400px;*/
    position: relative;
    padding: 5px 20px 13px 20px;
    background: #fff;
    border-radius:3px;
    -webkit-transition: all 500ms ease-in;
    -moz-transition: all 500ms ease-in;
    transition: all 500ms ease-in;
     text-align: left;
}

.modalmask2 .modalbox{padding: 5px 35px 13px 35px;}

.modalbox img{width:100%}
.btn-grafica{cursor:pointer;}
.modalbox .cont-img-chart{float:left; width:20%; border: 1px solid #999; margin:3px;min-width: 80px;}
.modalbox .cont-img-chart:hover{box-shadow: 10px 10px 5px #ccc;}
.modalbox .cont-img-chart.cont-chart-active{border: 3px solid #999;}

.modalmask .movedown, .modalmask2 .movedown{       
    margin:10% auto;
    float:none;
    height:70%;
    overflow: auto
}

.modalbox .ctrl-opciones-panel{border-bottom: 1px solid #ccc}
.modalbox ul{text-align: left;}
.modalbox ul li{display: inline-block; padding: 5px; cursor: pointer}
.modalbox ul li:hover{background-color: #eee;}
.modalbox ul li.tab-active{border-right:1px solid #ccc;border-top:1px solid #ccc;border-left:1px solid #ccc; font-weight: bold;}
.modalbox #paneles{position:relative;min-height: 100%;clear:both;}
.modalbox .panel-guardar-grafica{position:relative;clear:both;margin-bottom: 10px;}
.modalbox .row {margin-left: 0px;margin-right: 0px;}

.panel-aceptar-mensaje{position:absolute;bottom: 10px; right:20px;};

@media screen and (min-width: 768px) {
	.panel-aceptar-mensaje{position:relative;clear:both;margin-bottom: 10px;};
}

</style> 

<script>

	$(function(){
		$('#btn_aceptar_mensaje').on('click',function(){
      		$("#btn_enviar_reporte").click();
      	})
	})

</script>


<div id="modal1" class="modalmask">
    <div class="modalbox movedown  col-md-8 col-sm-8 col-xs-12">
        <div id="panel-datos"><!-- Inicia panel mensaje -->
          <h2 style="text-align:center;">Mensaje promo boletos</h2>
          <div class="row grid">
          	<p>Se les recuerda que la asistencia se tomará a través de la aplicación Transmobile.</p>
          </div>
		</div>

                <br />

      
        <div class="panel-aceptar-mensaje">
            <button value="aceptar-mensaje" name="btn_aceptar_mensaje" id="btn_aceptar_mensaje" class="btn btn-block btn-sm btn-info ">Aceptar</button>
        </div>

    </div>
</div>