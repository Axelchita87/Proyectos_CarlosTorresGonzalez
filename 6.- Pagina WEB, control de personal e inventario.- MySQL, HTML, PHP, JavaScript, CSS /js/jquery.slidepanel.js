/*************************************************
      SlidePanel JS v2.0
      @author Fabio Mangolini
      http://www.responsivewebmobile.com
**************************************************/
(function($) {

	$.SlidePanel = function(options) {
		//default status is closed
		status = 'close';

		//initialize the panel show/hide button 
        $('#slidein-panel-btn').css({'position': 'absolute', 'top': 0, 'right':-$('#slidein-panel-btn').outerWidth()+'px'});

        //initialize the panel
        //$('#slidein-panel').css({'position': 'absolute', 'top': 0, 'left': -$('#slidein-panel').outerWidth(), 'height': $(window).height()});
        $('#slidein-panel').css({'position': 'absolute', 'top': 0, 'left': -$('#slidein-panel').outerWidth(), 'height': '100%'});

        //show and hide the panel depending on status
		$('#slidein-panel-btn, #btn_buscar_filtrar').click(
			function() {
				if(status == 'close') {
					status = 'open';
					$('#slidein-panel').animate({'left':0});
				}
				else if(status == 'open') {
					status = 'close';
					$('#slidein-panel').animate({'left':-$('#slidein-panel').outerWidth()});
				}
			}
		);
	};

	$.redimensionar_SlidePanel = function(){
		$('#slidein-panel').css({'height': '100%'});
	}

})(jQuery);