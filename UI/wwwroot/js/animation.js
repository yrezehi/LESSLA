var animation = function () {

    function toggleHeight(clickableSelector, selector) {
        document.querySelectorAll(clickableSelector).forEach(function (clickableElement) {
            binding.clickToTrigger(clickableElement.closest(selector), function (event) {
                if (event.target.style.maxHeight === "0px") {
                    event.target.style.transition = "max-height 0.25s linear";
                    event.target.style.maxHeight = `${event.target.scrollHeight}px`;
                } else {
                    event.target.style.maxHeight = "0";
                    event.target.style.overflow = "hidden";
                }
            });
        });
    }

    return function () {
        return {
            toggleHeight: function (onClickSelector, selector) {
                toggleHeight(onClickSelector, selector);
            }
        };
    }();
}();