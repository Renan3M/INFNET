'use strict';

(function () {

    angular.module('MainModule').factory('HandlerFactoryPublico', handlerFactoryPublico);

    handlerFactoryPublico.$inject = ['HandlerFactory'];

    function handlerFactoryPublico(HandlerFactory) {

        return {
            login: function login(email, cpf) {
                return HandlerFactory.ajax('api/Socio/AutenticarUsuario', 'POST', { Email: email, CPF: cpf });
            },
            inicializarPlanos: function inicializarPlanos() {
                return HandlerFactory.ajax('api/Plano/InicializarPlanosBasicos', 'POST');
            },
            cadastrarSocioPlano: function cadastrarSocioPlano(socio) {
                return HandlerFactory.ajax('api/Socio/CadastrarSocioPlano', 'POST', socio);
            },
            inicializarMenus: function inicializarMenus() {
                return HandlerFactory.ajax('api/Menu/InicializarMenus', 'POST');
            },
            inicializarPartidas: function inicializarPartidas() {
                return HandlerFactory.ajax('api/Partida/InicializarPartidas', 'POST');
            }
        };
    }
})();

