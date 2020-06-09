(function () {
    

    angular
        .module('MainModule')
        .controller('MasterController', masterController);

    masterController.$inject = ['$rootScope', '$scope', '$state', 'TokenService', 'UsuarioService', 'NotificationService'];

    function masterController($rootScope, $scope, $state, TokenService, UsuarioService, NotificationService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'masterController';        

        $scope.$on('usuarioLogado', login);


        $scope.$on('notifyErrorRequest', function (e, mensagem) {
            NotificationService.sweetAlertErrorRequest();
        });

        $scope.$on('SweetAlertError', function (e, mensagem) {
            NotificationService.sweetAlertError("Erro", mensagem);
        });

        $scope.$on('SweetAlertNotification', function (e, title, mensagem) {
            NotificationService.sweetAlert('warning', title, mensagem);
        });

        /*Notificacao de confirmação*/
        $scope.$on('SweetAlertConfirm', function (e, title, mensagem, confirmFn) {
            NotificationService.sweetAlertConfirm(title, mensagem, confirmFn);
        });

        $scope.$on('SweetAlertSuccess', function (e, title, mensagem, confirmFn) {
            NotificationService.sweetAlertSuccess(title, mensagem, confirmFn);
        });

        function login(e, dados) {
            var menuEmpenho = [];

            UsuarioService.saveToSessionStorage(dados.socio.id, dados.socio.nome, dados.menus);
            
            TokenService.saveToSessionStorage(dados.token);

            $state.go('logado.dashboard');
        }

    }
})();
