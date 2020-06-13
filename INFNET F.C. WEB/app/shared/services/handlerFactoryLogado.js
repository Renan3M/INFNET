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
                return HandlerFactory.ajax('api/Assinatura/GetAssinaturaSocio', 'POST', { 'ID': idSocio });
            },
            gerarCobrancas: function (idSocio, tipoPagamento) {
                return HandlerFactory.ajax('api/Cobranca/GerarCobrancasSocio', 'POST', {
                    'ID': idSocio, 'TipoPagamento': tipoPagamento });
            },
            buscarCobrancasSocio: function(idSocio) {
                return HandlerFactory.ajax('api/Cobranca/BuscarCobrancasSocio', 'POST', { 'ID': idSocio });
            },
            pagarCobranca: function (idCobranca) {
                return HandlerFactory.ajax('api/Cobranca/PagarCobranca', 'POST', { 'ID': idCobranca });
            }
        };
    }
})();