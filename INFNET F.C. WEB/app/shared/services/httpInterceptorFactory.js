(function () {
    

    angular.module('MainModule').factory('HttpInterceptorFactory', httpInterceptorFactory);
    httpInterceptorFactory.$inject = ['$q', '$rootScope'];

    function httpInterceptorFactory ($q, $rootScope) {

        var loadingCount = 0;
        var methodNames = [];

        return {
            request: function (config) {

                //if (++loadingCount === 1)
                $rootScope.$broadcast('AjaxLoading', config.url);

                return config || $q.when(config);
            },

            response: function (response) {

                //if (--loadingCount === 0)
                $rootScope.$broadcast('AjaxFinish', response.config.url);

                return response || $q.when(response);
            },

            responseError: function (response) {

                //if (--loadingCount === 0)
                $rootScope.$broadcast('AjaxFinish', response.config.url);

                return $q.reject(response);
            }
        };

    }

    


}());