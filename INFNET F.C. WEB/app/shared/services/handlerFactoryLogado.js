(function () {
    

    angular
        .module('MainModule')
        .factory('HandlerFactoryLogado', handlerFactoryLogado);

    handlerFactoryLogado.$inject = ['HandlerFactory'];

    function handlerFactoryLogado(HandlerFactory) {

        return {

            obterProximasPartidas: function () {
                return HandlerFactory.ajax('api/Partida/ObterProximasPartidas', 'GET');
            },
            enviarDuvida: function (duvida) {
                return HandlerFactory.ajax('api/Duvida/EnviarDuvida', 'POST', duvida);
            },
            buscarAssinaturaSocio: function (idSocio) {
                return HandlerFactory.ajax('api/Assinatura', 'GET', idSocio);
            }
        };
    }
})();