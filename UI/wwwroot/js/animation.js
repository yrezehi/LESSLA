var animation = function () {

    function toggle(selector, show = true) {
        var element = document.querySelector(selector);

        if (!element)
            notification.error(`Could not find element ${selector} to animate!`);

        binding.clickToTrigger(element, function () {
            if (show) {
                element.style.maxHeight = element.scrollHeight;
                element.style.overflow = "visible";
            } else {
                element.style.maxHeight = "0";
                element.style.overflow = "hidden";
            }
        });
    }

    return function () {
        return {
            hideViaHeight: function (element) {
                toggle(element, true);
            },
            showViaHeight: function (element) {
                toggle(element, false);
            }
        };
    }();
}();