var animation = function () {

    function toggleHeight(onClickSelector, selector) {
        var element = document.querySelector(selector);

        binding.clickToTrigger(document.querySelector(onClickSelector), function () {
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
            toggleHeight: function (onClickSelector, selector) {
                toggleHeight(onClickSelector, selector);
            }
        };
    }();
}();