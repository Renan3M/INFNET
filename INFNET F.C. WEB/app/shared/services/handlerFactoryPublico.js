(function () {
    

    angular
        .module('MainModule')
        .factory('HandlerFactoryPublico', handlerFactoryPublico);

    handlerFactoryPublico.$inject = ['HandlerFactory'];

    function handlerFactoryPublico(HandlerFactory) {

        return {
            login: function (email, cpf) {
                return HandlerFactory.ajax('api/Socio/AutenticarUsuario', 'POST', { Email: email, CPF: cpf });
            },
            inicializarPlanos: function () {
                return HandlerFactory.ajax('api/Plano/InicializarPlanosBasicos', 'POST');
            },
            cadastrarSocioPlano: function (socio) {
                return HandlerFactory.ajax('api/Socio/CadastrarSocioPlano', 'POST',socio);
            },
            inicializarMenus: function () {
                return HandlerFactory.ajax('api/Menu/InicializarMenus', 'POST');
            },
            inicializarPartidas: function () {
                return HandlerFactory.ajax('api/Partida/InicializarPartidas', 'POST');
            }
        };
    }
})();