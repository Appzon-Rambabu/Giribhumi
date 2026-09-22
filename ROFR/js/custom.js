!function () {
    setTimeout(function () {
        $('.bgoverlay').css('display', 'none').one('transitionend webkitTransitionEnd oTransitionEnd otransitionend MSTransitionEnd', function () {
        });
    }, 1000);
}();

