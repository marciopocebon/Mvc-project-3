/**
Core script to handle the entire theme and core functions
**/
var MediCo = function(){
	var homeSearch = function() {
		'use strict';
		/* top search in header on click function */
		var quikSearch = jQuery("#quik-search-btn");
		var quikSearchRemove = jQuery("#quik-search-remove");
		
		quikSearch.on('click',function() {
			jQuery('.dez-quik-search').animate({'width': '100%' });
			jQuery('.dez-quik-search').delay(500).css({'left': '0'  });
		});
		
		quikSearchRemove.on('click',function() {
			jQuery('.dez-quik-search').animate({'width': '0%' ,  'right': '0'  });
			jQuery('.dez-quik-search').css({'left': 'auto'  });
		});	
		/* top search in header on click function End*/
	}
	
	var MagnificPopup = function(){
		'use strict';	
		/* magnificPopup function */
		jQuery('.mfp-gallery').magnificPopup({
			delegate: '.mfp-link',
			type: 'image',
			tLoading: 'Loading image #%curr%...',
			mainClass: 'mfp-img-mobile',
			gallery: {
				enabled: true,
				navigateByImgClick: true,
				preload: [0,1] // Will preload 0 - before current, and 1 after the current image
			},
			image: {
				tError: '<a href="%url%">The image #%curr%</a> could not be loaded.',
				titleSrc: function(item) {
					return item.el.attr('title') + '<small>by Marsel Van Oosten</small>';
				}
			}
		});
		/* magnificPopup function end */
		
		/* magnificPopup for paly video function */		
		jQuery('.video').magnificPopup({
			type: 'iframe',
			iframe: {
				markup: '<div class="mfp-iframe-scaler">'+
						 '<div class="mfp-close"></div>'+
						 '<iframe class="mfp-iframe" frameborder="0" allowfullscreen></iframe>'+
						 '<div class="mfp-title">Some caption</div>'+
						 '</div>'
			},
			callbacks: {
				markupParse: function(template, values, item) {
					values.title = item.el.attr('title');
				}
			}
		});
		/* magnificPopup for paly video function end*/
		
	}
	
	/* Header Height ============ */
	var handelResizeElement = function(){
		var HeaderHeight = $('.header').height();
		$('.header').css('height', HeaderHeight);
	}
	
	var scrollTop = function (){
		'use strict';
		var scrollTop = jQuery("button.scroltop");
		/* page scroll top on click function */	
		scrollTop.on('click',function() {
			jQuery("html, body").animate({
				scrollTop: 0
			}, 1000);
			return false;
		})

		jQuery(window).bind("scroll", function() {
			var scroll = jQuery(window).scrollTop();
			if (scroll > 900) {
				jQuery("button.scroltop").fadeIn(1000);
			} else {
				jQuery("button.scroltop").fadeOut(1000);
			}
		});
		/* page scroll top on click function end*/
	}
	
	var handelAccordian = function(){
		/* accodin open close icon change */	 	
		jQuery('#accordion').on('hidden.bs.collapse', function(e){
			jQuery(e.target)
				.prev('.panel-heading')
				.find("i.indicator")
				.toggleClass('glyphicon-minus glyphicon-plus');
		});
		jQuery('#accordion').on('shown.bs.collapse', function(e){
			jQuery(e.target)
				.prev('.panel-heading')
				.find("i.indicator")
				.toggleClass('glyphicon-minus glyphicon-plus');
		});
		/* accodin open close icon change end */
	}
	
	var handelPlaceholder = function(){
		/* input placeholder for ie9 & ie8 & ie7 */
		jQuery.support.placeholder = ('placeholder' in document.createElement('input'));
		/* input placeholder for ie9 & ie8 & ie7 end*/
		
		/*fix for IE7 and IE8  */
		if (!jQuery.support.placeholder) {
			jQuery("[placeholder]").focus(function () {
				if (jQuery(this).val() == jQuery(this).attr("placeholder")) jQuery(this).val("");
			}).blur(function () {
				if (jQuery(this).val() == "") jQuery(this).val(jQuery(this).attr("placeholder"));
			}).blur();

			jQuery("[placeholder]").parents("form").submit(function () {
				jQuery(this).find('[placeholder]').each(function() {
					if (jQuery(this).val() == jQuery(this).attr("placeholder")) {
						 jQuery(this).val("");
					}
				});
			});
		}
		/*fix for IE7 and IE8 end */
	}
	
	var equalHeight = function(container) {
	
		var currentTallest = 0, 
			currentRowStart = 0, 
			rowDivs = new Array(), 
			$el, topPosition = 0;
			
		$(container).each(function() {
			$el = $(this);
			$($el).height('auto')
			topPostion = $el.position().top;

			if (currentRowStart != topPostion) {
				for (currentDiv = 0; currentDiv < rowDivs.length; currentDiv++) {
					rowDivs[currentDiv].height(currentTallest);
				}
				rowDivs.length = 0; // empty the array
				currentRowStart = topPostion;
				currentTallest = $el.height();
				rowDivs.push($el);
			} else {
				rowDivs.push($el);
				currentTallest = (currentTallest < $el.height()) ? ($el.height()) : (currentTallest);
			}
			for (currentDiv = 0; currentDiv < rowDivs.length; currentDiv++) {
				rowDivs[currentDiv].height(currentTallest);
			}
		});
	}
	
	var footerAlign = function() {
		'use strict';
		jQuery('.site-footer').css('display', 'block');
		jQuery('.site-footer').css('height', 'auto');
		var footerHeight = jQuery('.site-footer').outerHeight();
		jQuery('.footer-fixed > .page-wraper').css('padding-bottom', footerHeight);
		jQuery('.site-footer').css('height', footerHeight);
	}
	
	var fileInput = function(){
		'use strict';
		/* Input type file jQuery */	 	 
		jQuery(document).on('change', '.btn-file :file', function() {
			var input = jQuery(this);
			var	numFiles = input.get(0).files ? input.get(0).files.length : 1;
			var	label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
			input.trigger('fileselect', [numFiles, label]);
		});
		
		jQuery('.btn-file :file').on('fileselect', function(event, numFiles, label) {
			input = jQuery(this).parents('.input-group').find(':text');
			var log = numFiles > 10 ? numFiles + ' files selected' : label;
		
			if (input.length) {
				input.val(log);
			} else {
				if (log) alert(log);
			}
		});
		/* Input type file jQuery end*/
	}
	
	var headerFix = function(){
		'use strict';
		/* Main navigation fixed on top  when scroll down function custom */		
		jQuery(window).bind('scroll', function () {
			var menu = jQuery('.sticky-header');
			if ($(window).scrollTop() > menu.offset().top) {
				menu.addClass('is-fixed');
			} else {
				menu.removeClass('is-fixed');
			}
		});
		/* Main navigation fixed on top  when scroll down function custom end*/
	}
	
	var masonryBox = function(){
		'use strict';
		/* masonry by  = bootstrap-select.min.js */ 
		var self = $("#masonry");
		self.imagesLoaded(function () {
			self.masonry({
				gutterWidth: 15,
				isAnimated: true,
				itemSelector: ".card-container"
			});
		});

		jQuery(".filters").on('click','li',function(e) {
			e.preventDefault();
			var filter = $(this).attr("data-filter");
			self.masonryFilter({
				filter: function () {
					if (!filter) return true;
					return $(this).attr("data-filter") == filter;
				}
			});
		});
		/* masonry by  = bootstrap-select.min.js end */
	}
	
	var setDivHeight = function(){	
		'use strict';
		var allHeights = [];
		jQuery('.dzseth > div, .dzseth .img-cover').each(function(e){
			allHeights.push(jQuery(this).height());
		})

		jQuery('.dzseth > div, .dzseth .img-cover').each(function(e){
			var maxHeight = Math.max.apply(Math,allHeights);
			jQuery(this).css('height',maxHeight);
		})
		
		allHeights = [];
		/* Removice */
		var screenWidth = $( window ).width();
		if(screenWidth < 991)
		{
			jQuery('.dzseth > div, .dzseth .img-cover').each(function(e){
				jQuery(this).css('height','');
			})
		}	
	}
	
	var counter = function(){
		if(jQuery('.counter').length)
		{
			jQuery('.counter').counterUp({
				delay: 10,
				time: 3000
			});
		}
		
	}
	
	var handelVideo = function(){
		/* Video responsive function */	
		jQuery('iframe[src*="youtube.com"]').wrap('<div class="embed-responsive embed-responsive-16by9"></div>');
		jQuery('iframe[src*="vimeo.com"]').wrap('<div class="embed-responsive embed-responsive-16by9"></div>');	
		/* Video responsive function end */
	}
	
	var handelFilterMasonary = function(){
		/* gallery filter activation = jquery.mixitup.min.js */ 
		if (jQuery('#image-gallery-mix').length) {
			jQuery('.gallery-filter').find('li').each(function () {
				$(this).addClass('filter');
			});
			jQuery('#image-gallery-mix').mixItUp();
		};
		if(jQuery('.gallery-filter.masonary').length){
			jQuery('.gallery-filter.masonary').on('click','span', function(){
				var selector = $(this).parent().attr('data-filter');
				jQuery('.gallery-filter.masonary span').parent().removeClass('active');
				jQuery(this).parent().addClass('active');
				jQuery('#image-gallery-isotope').isotope({ filter: selector });
				return false;
			});
		}
		/* gallery filter activation = jquery.mixitup.min.js */
	}
	
	var handelBootstrapSelect = function(){
		/* Bootstrap Select box function by  = bootstrap-select.min.js */ 
		jQuery('select').selectpicker();
		/* Bootstrap Select box function by  = bootstrap-select.min.js end*/
	}
	
	var handelBootstrapTouchSpin = function(){
		jQuery("input[name='demo_vertical2']").TouchSpin({
		  verticalbuttons: true,
		  verticalupclass: 'glyphicon glyphicon-plus',
		  verticaldownclass: 'glyphicon glyphicon-minus'
		});
		
	}
	
	var handelCountDown = function(){
		/* Time Countr Down Js */
		if($(".countdown").length)
		{
			$('.countdown').countdown({date: '30 march 2018 23:5'}, function() {
				$('.countdown').text('we are live');
			});
		}
		/* Time Countr Down Js End */
	}
	
	var handelCustomScroll = function(){
		/* all available option parameters with their default values */
		if($(".content").length)
		{
			$(".content").mCustomScrollbar({
				setWidth:false,
				setHeight:false,
				axis:"y"
			});	
		}
	}
	
	var handelSideBarMenu = function(){
		$('.openbtn').on('click',function(e){
			e.preventDefault();
			if($('#mySidenav').length > 0)
			{
				document.getElementById("mySidenav").style.left = "0";
			}

			if($('#mySidenav1').length > 0)
			{
				document.getElementById("mySidenav1").style.right = "0";
			}
			
		})
		
		$('.closebtn').on('click',function(e){
			e.preventDefault();
			if($('#mySidenav').length > 0)
			{
				document.getElementById("mySidenav").style.left = "-300px";
			}
			
			if($('#mySidenav1').length > 0)
			{
				document.getElementById("mySidenav1").style.right = "-820px";
			}
		})
	}
	
	return {
		init:function(){
			handelResizeElement();
			homeSearch();
			MagnificPopup();
			handelAccordian();
			scrollTop();
			handelPlaceholder();
			footerAlign();
			fileInput();
			headerFix();
			setDivHeight();
			counter();
			handelVideo();
			handelFilterMasonary();
			handelCountDown();
			handelCustomScroll();
			handelSideBarMenu();
		},
		
		load:function(){
			masonryBox();
			handelBootstrapSelect();
			handelBootstrapTouchSpin();
			equalHeight('.equal-wraper .equal-col');
		}
	}
	
}();


/* Document.ready Start */	
jQuery(document).ready(function() {
    'use strict';
	MediCo.init();
});
/* Document.ready END */



/* Window Load START */
jQuery(window).load(function () {
	'use strict'; 
	MediCo.load();
	
	setTimeout(function(){
		jQuery('#loading-area').remove();
	}, 0);
	
});
/*  Window Load END */

	


	