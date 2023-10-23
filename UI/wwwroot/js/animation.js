var animation = function () {

    function toggleHeight(selector) {
        var element = document.querySelector(selector);

        if (!element)
            notification.error(`Could not find element ${selector} to animate!`);

        binding.clickToTrigger(element, function () {
            if (element.style.maxHeight === "0") {
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
            toggleHeight: function (selector) {
                toggleHeight(selector);
            }
        };
    }();
}();