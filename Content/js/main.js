


	////------- Custom Carousel
	$('.custom-carousel').each(function(){
		var owl = jQuery(this),
			itemsNum = $(this).attr('data-appeared-items'),
			sliderNavigation = $(this).attr('data-navigation');
			
		if ( sliderNavigation == 'false' || sliderNavigation == '0' ) {
			var returnSliderNavigation = false
		}else {
			var returnSliderNavigation = true
		}
		if( itemsNum == 1) {
			var deskitemsNum = 1;
			var desksmallitemsNum = 1;
			var tabletitemsNum = 1;
		} 
		else if (itemsNum >= 2 && itemsNum < 4) {
			var deskitemsNum = itemsNum;
			var desksmallitemsNum = itemsNum - 1;
			var tabletitemsNum = itemsNum - 1;
		} 
		else if (itemsNum >= 4 && itemsNum < 8) {
			var deskitemsNum = itemsNum -1;
			var desksmallitemsNum = itemsNum - 2;
			var tabletitemsNum = itemsNum - 3;
		} 
		else {
			var deskitemsNum = itemsNum -3;
			var desksmallitemsNum = itemsNum - 6;
			var tabletitemsNum = itemsNum - 8;
		}
		owl.owlCarousel({
			slideSpeed : 100,
			stopOnHover: true,
			autoPlay: true,
			navigation : returnSliderNavigation,
			pagination: false,
			lazyLoad : true,
			items : itemsNum,
			itemsDesktop : [1000,deskitemsNum],
			itemsDesktopSmall : [900,desksmallitemsNum],
			itemsTablet: [600,tabletitemsNum],
			itemsMobile : false,
			transitionStyle : "goDown",
		});
	});
	


	/*----------------------------------------------------*/
	/*	Change Slider Nav Icons
	/*----------------------------------------------------*/
	
	$('.touch-slider').find('.owl-prev').html('<i class="general foundicon-left-arrow"></i>');
	$('.touch-slider').find('.owl-next').html('<i class="general foundicon-right-arrow"></i>');
	
	$('.touch-carousel, .testimonials-carousel').find('.owl-prev').html('<i class="fa fa-chevron-left"></i>');
	$('.touch-carousel, .testimonials-carousel').find('.owl-next').html('<i class="fa fa-chevron-right"></i>');
	$('.read-more').append('<i class="general foundicon-right-arrow"></i>');

	$('.slider-carousel').find('.owl-prev').html('<i class="general foundicon-left-arrow"></i>');
	$('.slider-carousel').find('.owl-next').html('<i class="general foundicon-right-arrow"></i>');

	$('.slider-carousel, .testimonials-carousel').find('.owl-prev').html('<i class="fa fa-circle" aria-hidden="true" "></i>');
	$('.slider-carousel, .testimonials-carousel').find('.owl-next').html('<i class="fa fa-circle" aria-hidden="true" "></i>');
	$('.read-more').append('<i class="general foundicon-right-arrow"></i>');










