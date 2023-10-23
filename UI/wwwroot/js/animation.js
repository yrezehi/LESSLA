var animation = function () {

    function toggleHeight(onClickSelector, selector) {
        var element = document.querySelector(selector);

        binding.clickToTrigger(document.querySelector(onClickSelector), function () {
            if (element.style.maxHeight === "0px") {
                element.style.transition = "max-height 0.6s linear";
                element.style.maxHeight = `${element.scrollHeight}px`;
            } else {
                element.style.maxHeight = "0";
                element.style.overflow = "hidden";
            }
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