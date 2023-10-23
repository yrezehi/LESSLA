var animation = function () {

    function toggle(selector, show = true) {
        var element = document.querySelector(selector);

        if (!element)
            notification.error(`Could not find element ${selector} to animate!`);

        binding.clickToTrigger(element, function () {
            if (show) {
                element.style.maxHeight = element.scrollHeight;
                element.s
            } else {

            }
        });
    }

    function show(selector) {

    }

    return function () {
        return {
            hideViaHeight: hide,
            showViaHeight: show
        };
    }();
}();