
(function () {

    

    angular.module('MainModule').factory('HandlerFactory', handlerFactory);
    handlerFactory.$inject = ['$http', '$q', 'TokenService', 'UsuarioService', 'Host', 'HttpCancelService', 'NotificationService'];

    function handlerFactory($http, $q, TokenService, UsuarioService, Host, HttpCancelService, NotificationService) {

        return {
            ajax: http,
            ajaxSuccess: ajaxSuccess,
            ajaxRequest: ajaxRequest
        }

        //Função para requisições, recebe url, método da chamada e a data a ser enviada. Retorna uma promessa com os resultados já parseados para um objeto;
        function http(url, method, jsonData) {

            // Não quero chamar as controladoras desse projeto e sim da API. Pode ser necessário alterar isso.
            Host = 'http://localhost:64301/'
            var data = angular.toJson(jsonData);
            var defer = $q.defer();

            /*Criando a promessa de cancelamento da requisição*/
            var cancelRequest = $q.defer();
            /*Adicionando promessa a lista de requisições pendentes*/
            HttpCancelService.addRequest(cancelRequest);

            var options = {
                url: Host + url,
                method: method,
                data: data,
                crossDomain: true,
                timeout: cancelRequest.promise,
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                    'Authorization': TokenService.getToken(),
                    'Sid': UsuarioService.getSid()
                },
                xhrFields: {
                    withCredentials: true
                }

            };

            var httpResponse = $http(options);
            httpResponse.then(processResponse).catch(processError);

            return defer.promise;


            function processResponse(response, status) {

                defer.resolve(response.data);

            }
            function processError(e, status) {

                if (e !== null || status !== -1) {

                    var r = angular.fromJson(e);

                    /*Token Inválido*/
                    if (r.StatusOperacao === 401) {

                        /*Cancela requisições pendentes*/
                        HttpCancelService.cancelRequests();

                        /*Notifica o serviço de token*/
                        TokenService.notifyUnauthorized();

                    }
                    else {
                        //Rejeitando a promessa passando um objeto com a mensagem de erro;
                        //NotificationService.sweetAlertErrorRequest(function () { });
                        $('.block').removeClass('block-opt-refresh');
                        defer.reject({ Mensagem: 'Não foi possível completar a requisição.' });
                    }



                }
            }
        }

        function ajaxRequest(url, method, data, isFile) {

            var defer = $q.defer();

            /*Criando a promessa de cancelamento da requisição*/
            var cancelRequest = $q.defer();
            /*Adicionando promessa a lista de requisições pendentes*/
            HttpCancelService.addRequest(cancelRequest);

            var httpResponse = $http({
                url: url,
                method: method,
                data: isFile ? data : angular.toJson(data),
                timeout: cancelRequest.promise,
                headers: {
                    'Accept': isFile ? undefined : 'application/json',
                    'Content-Type': isFile ? undefined : 'application/json',
                    'Authorization': TokenService.getToken(),
                    'Sid': UsuarioService.getSid()
                },
                transformResponse: angular.identity,
                xhrFields: {
                    withCredentials: true
                }

            });
            httpResponse.then(processResponse, processError);

            return defer.promise;

            function processResponse(response, status, headers) {
                try {
                    defer.resolve(angular.fromJson(response.data));
                } catch (e) {
                    /*Caso o retorno não seja JSON*/
                    defer.resolve({ file: response, headers: headers() });
                }
            }
            function processError(e, status) {

                switch (e.status) {
                    case -1:
                        /*Requisições canceladas*/
                        break;
                    case 401:
                        /*Cancela requisições pendentes*/
                        HttpCancelService.cancelRequests();

                        /*Notifica o serviço de token*/
                        TokenService.notifyUnauthorized();
                        break;
                    case 404:
                        defer.reject({ Mensagem: 'O caminho especificado não foi encontrado.' });
                        break;
                    case 500:
                        defer.reject({ Mensagem: 'Ocorreu um erro no servidor durante a requisição.' });
                        break;
                    default:
                        defer.reject({ Mensagem: 'Não foi possível completar a requisição.' });
                        break;
                }
            }
        }

        function ajaxSuccess(url, method, jsonData) {
            return {
                success: function (callbackSuccess) {

                    http(url, method, jsonData)
                        .then(callbackSuccess)
                        .catch(notifyError);
                }
            };

            function notifyError(e) {
                NotificationService.sweetAlertErrorRequest(function () { });
            }
        }
        
    }

}());