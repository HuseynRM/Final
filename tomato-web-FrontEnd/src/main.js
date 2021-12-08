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

// add Intersection observer api
const header = document.querySelector('.page-header');
const nav = document.querySelector('.header');
const navHeight = nav.getBoundingClientRect().height;
console.log(navHeight);

const opacityNav = function (entries) {
    const [entry] = entries;
    console.log(entry);

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
