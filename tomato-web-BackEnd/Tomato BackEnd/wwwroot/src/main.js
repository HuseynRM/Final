if ($('#timepicker').length) {
    $('#timepicker').clockpicker({
        placement: 'bottom',
        autoclose: true
    });
}

if ($('[data-toggle="datepicker"]').length) {
    $('[data-toggle="datepicker"]').datepicker();
}

if ($(':input[type=number]').length) {
    $(':input[type=number]').on('mousewheel', function (e) {
        e.preventDefault();
    });
}
if ($('.menu-items').length) {
    const defaultFilter = $('.tagsort-active').attr('data-filter');
    const $grid = $('.menu-items').isotope({
        itemSelector: '.menu-item',
        layoutMode: 'fitRows',
        filter: defaultFilter
    });

    $('.menu-tags').on('click', 'span', function () {
        $('.menu-tags span').removeClass('tagsort-active');

        $(this).toggleClass('tagsort-active');

        const filterValue = $(this).attr('data-filter');

        $grid.isotope({
            filter: filterValue
        });
    });
}

// add Intersection observer api
const header = document.querySelector('.page-header');
const nav = document.querySelector('.header');
const navHeight = nav.getBoundingClientRect().height;

const opacityNav = function (entries) {
    const [entry] = entries;

    if (!entry.isIntersecting) nav.classList.add('darker-bg');
    else nav.classList.remove('darker-bg');
};
const obsOptions = {
    root: null,
    threshold: 0,
    rootMargin: `-${navHeight}px`
};

const observer = new IntersectionObserver(opacityNav, obsOptions);
observer.observe(header);
