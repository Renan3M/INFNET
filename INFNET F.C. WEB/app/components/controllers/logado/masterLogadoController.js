(function () {

    angular
        .module('MainModule')
        .controller('MasterLogadoController', masterLogadoController);

    masterLogadoController.$inject = ['$state', 'UsuarioService', 'TokenService', 'HandlerFactoryLogado'];

    function masterLogadoController($state, UsuarioService, TokenService, HandlerFactoryLogado) {

        /* jshint validthis:true */

        var vm = this;

        vm.title = 'masterLogadoController';
        vm.menus = [];
      
        vm.usuario = {};
        vm.logout = logout;

        init();

        function init() {


            if (UsuarioService.getLstMenu().length == 0 || !UsuarioService.getNome()) {
                UsuarioService.loadFromSessionStorage();
            }

            vm.usuario.nome = UsuarioService.getNome();

            if (vm.menus.length == 0 ) {
                vm.menus = UsuarioService.getLstMenu();
            };

        }


        function logout(e, usuario) {
            sessionStorage.clear();
            UsuarioService.clear();
            TokenService.clear();
            $state.go('login');
        }    
    }
}) ();
