var animation = function () {

    function toggleHeight(clickableSelector, triggerSelector) {
        binding.clickToTrigger(document.querySelector(clickableSelector), function (_) {
            var triggerSelector = document.querySelector(triggerSelector);
            if (triggerSelector.style.maxHeight === "0px") {
                triggerSelector.style.transition = "max-height 0.25s linear";
                triggerSelector.style.maxHeight = `${triggerSelector.scrollHeight}px`;
            } else {
                triggerSelector.style.maxHeight = "0";
                triggerSelector.style.overflow = "hidden";
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