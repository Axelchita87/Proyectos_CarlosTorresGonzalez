/*!
 * IE10 viewport hack for Surface/desktop Windows 8 bug
 * Copyright 2014 Twitter, Inc.
 * Licensed under the Creative Commons Attribution 3.0 Unported License. For
 * details, see http://creativecommons.org/licenses/by/3.0/.
 */

// See the Getting Started docs for more information:
// http://getbootstrap.com/getting-started/#support-ie10-width

(function () {
  'use strict';
  if (navigator.userAgent.match(/IEMobile\/10\.0/)) {
    var msViewportStyle = document.createElement('style')
    msViewportStyle.appendChild(
      document.createTextNode(
        '@-ms-viewport{width:auto!important}'
      )
    )
    document.querySelector('head').appendChild(msViewportStyle)
  }
})();

//OwlcarouselHome
$(document).ready(function() {
 
  var owl = $("#owl-demo");
 
  owl.owlCarousel({
   navigationText: [
      "<i class='icon-chevron-left icon-white'><</i>",
      "<i class='icon-chevron-right icon-white'>></i>"
      ],
	  items: 10 , 
      itemsCustom : [
        [0, 4],
        [450, 4],
		 [500, 6],
        [600, 6],
        [700, 7],
		 [800, 7],
		 [900, 7],
        [1000, 8],
        [1200, 10],
        [1400, 10],
        [1600, 12]
      ],
      navigation : true,
	  pagination : false,
	  responsive : true, 
 
  });
 
});


//Toogle Up
$("#MenuToggle").click(function(event){
		event.preventDefault();
		$('#myMenu ul').slideToggle('slow');	
	});
	
	$('.datepicker').datepicker({
    	language: 'es',
	});

//Countdown
$(document).on('ready', iniciarTemporizador);

			function iniciarTemporizador() {
				
			var fechaFinal = new Date(2014, 08, 01, 12, 00, 00);
			var fechaHoy = new Date();
			
			var diferenciaMilisegundos = fechaFinal.getTime() - fechaHoy.getTime();
			var diferenciaSegundos = (diferenciaMilisegundos/1000);
			
			var clock = $(".reloj").FlipClock({
				clockFace: 'DailyCounter'
			});
			
			clock.setTime(diferenciaSegundos);
			clock.setCountdown(true);
			
			}
			
// Countdown Iniciativa Home
var clock = $('.clock_iniciativa').FlipClock(3600, {
		countdown: true
});		
//Panel
$("#flip").click(function(){
	$(".panelgt").slideToggle();
});

//FileInput
$('.fileinput').fileinput()

//INICIO > Panel Toggle 
$(document).on('click', '.panel-heading span.clickable', function (e) {
    var $this = $(this);
    if (!$this.hasClass('panel-collapsed')) {
        $this.parents('.panel').find('.panel-body').slideUp();
        $this.addClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-minus').addClass('glyphicon-plus');
    } else {
        $this.parents('.panel').find('.panel-body').slideDown();
        $this.removeClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-plus').addClass('glyphicon-minus');
    }
});
$(document).on('click', '.panel div.clickable', function (e) {
    var $this = $(this);
    if (!$this.hasClass('panel-collapsed')) {
        $this.parents('.panel').find('.panel-body').slideUp();
        $this.addClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-minus').addClass('glyphicon-plus');
    } else {
        $this.parents('.panel').find('.panel-body').slideDown();
        $this.removeClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-plus').addClass('glyphicon-minus');
    }
});
$(document).ready(function () {
    $('.panel-heading span.clickable').click();
    $('.panel div.clickable').click();
});


