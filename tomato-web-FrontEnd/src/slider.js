// Slick slider
if ($('.slick-slider')) {
    $('.slick-slider').slick({
        slidesToShow: 2,
        dots: true,
        autoplay: false,
        arrows: false,
        infinite: false,
        draggable: true,
        responsive: [
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 1
                }
            }
        ]
    });
}

$('.trusted-slider').slick({
    slidesToShow: 1,
    dots: true,
    autoplay: true,
    arrows: false,
    infinite: false,
    draggable: true
});

if ($('.single-shop-carousel')) {
    $('.single-shop-carousel').slick({
        autoplay: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        asNavFor: '.single-shop-carousel-nav'
    });
}

$('.single-shop-carousel-nav').slick({
    slidesToShow: 3,
    slidesToScroll: 1,
    asNavFor: '.single-shop-carousel',
    focusOnSelect: true
});
// FlexSlider
$(window).on('load', function () {
    if ($('.special-slider').length) {
        $('.special-slider').flexslider({
            animation: 'slide',
            controlNav: false,
            directionNav: false,
            slideshow: true,
            slideshowSpeed: 3000
        });
    }

    $('.prev').on('click', function () {
        $('.special-slider').flexslider('prev');
        return false;
    });

    $('.next').on('click', function () {
        $('.special-slider').flexslider('next');
        return false;
    });
});

// owl carousel
if ($('.owl-carousel').length) {
    $('.owl-carousel').owlCarousel({
        loop: false,
        center: false,
        margin: 30,
        dots: false,
        responsive: {
            0: {
                items: 2
            },
            600: {
                items: 3
            },
            1000: {
                items: 5
            }
        }
    });
}

// Popup Plugin heheh
if ($('.about-photo img').length) {
    $('.about-photo img').magnificPopup({
        type: 'image',
        removalDelay: 300,
        mainClass: 'mfp-fade',
        gallery: {
            enabled: true,
            navigateByImgClick: true,
            preload: [0, 1]
        }
    });
}
