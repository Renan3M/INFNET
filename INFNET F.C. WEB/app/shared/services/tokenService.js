(function () {
    

    angular
        .module('MainModule')
        .factory('TokenService', tokenService);

    tokenService.$inject = ['$rootScope'];

    function tokenService($rootScope) {

        var token;

        function getToken() {
            if (!token) {
                token = sessionStorage.getItem('token');

                if (!token) {
                    return 'Basic';
                }
                return 'Basic ' + token;
            }

            return 'Basic ' + token;
        }

        function setToken(value) {
            token = value;
        }

        function saveToSessionStorage(token) {
            sessionStorage.setItem('token', token);

            setToken(token);
        }

        function notifyUnauthorized() {
            $rootScope.$broadcast('TokenInvalido');
        }

        function isTokenValido() {
            return !!(token || sessionStorage.getItem('token'));
        }

        function clearToken() {
            token = null;
        }

        return {
            getToken: getToken,
            saveToSessionStorage: saveToSessionStorage,
            notifyUnauthorized: notifyUnauthorized,
            isTokenValido: isTokenValido,
            clear: clearToken
        }


    }
})();