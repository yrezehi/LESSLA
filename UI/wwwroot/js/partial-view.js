var partialView = function () {

    function modal(endpoint, triggerElement) {
        binding.clickToTrigger(triggerElement, function () {
            request.viewRequest(endpoint).then(function(response) {
                if (response.success) {
                    var genericModalElement = document.querySelector("#generic-modal");

                    genericModalElement.innerHTML = "";
                    genericModalElement.appendChild(dom.createElement(response.data));

                    var modal = new Modal(genericModalElement);
                    modal.show();
                }
            });
        });        
    }

    return function () {
        return Object.freeze({
            modal: modal
        });
    }();
}();