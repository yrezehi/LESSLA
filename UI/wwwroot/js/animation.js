var animation = function () {

    function toggleHeight(clickableSelector, triggerSelector) {
        binding.clickToTrigger(document.querySelector(clickableSelector), function (_) {
            var triggerElement = document.querySelector(triggerSelector);
            if (triggerElement.style.maxHeight === "0px") {
                triggerElement.style.transition = "max-height 0.25s linear";
                triggerElement.style.maxHeight = `${triggerElement.scrollHeight}px`;
            } else {
                triggerElement.style.maxHeight = "0";
                triggerElement.style.overflow = "hidden";
            }
        });
    }

    return function () {
        return {
            toggleHeight: function (clickableSelector, triggerSelector) {
                toggleHeight(clickableSelector, triggerSelector);
            }
        };
    }();
}();