(function () {
    

    angular
        .module('MainModule')
        .factory('HttpCancelService', httpCancelService);


    function httpCancelService() {

        var pendingRequests = [];


        return {
            cancelRequests: cancelRequests,
            addRequest: addRequest
        }


        function cancelRequests() {
            pendingRequests.forEach(cancel);
            pendingRequests.length = 0;


            function cancel(p) {
                p.resolve();
            }
        }

        function addRequest(req) {
            pendingRequests.push(req);
        }

    }
})();