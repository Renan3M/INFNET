(function () {
    

    angular
        .module('MainModule')
        .controller('LoginController', loginController);

    loginController.$inject = ['$scope', 'HandlerFactoryPublico', 'FormValidationService', '$state'];

    function loginController($scope, HandlerFactoryPublico, FormValidationService, $state) {
        /* jshint validthis:true */
        var vm = this;
        vm.notifyError = $scope.notifyError;
        vm.loginIncorreto = false;
        vm.statusMensagem;
        vm.title = 'loginController';
        vm.validarLogin = validarLogin;
        vm.aderir = aderir;

        calcularAltura();

        HandlerFactoryPublico.inicializarMenus().then(x => { }).catch(error => {
            console.log(error);
        });

        HandlerFactoryPublico.inicializarPartidas().then(x => { }).catch(error => {
            console.log(error);
        });

      

        /*
         * Funções públicas
         */
        function validarLogin() {
            if (isFormValido()) {
                HandlerFactoryPublico.login(vm.email, vm.CPF) // Devolve os Menus nesse método, conforme o que for permitido ao sócio.
                    .then(validarLoginResponse).catch(error => {
                    vm.loginIncorreto = true;
                        vm.statusMensagem = 'Usuário não existe!'; });

            }
        }

        function aderir() {
            $state.go('wizard');
        }

        /*
         * Funções privadas
         */
        function isFormValido() {
            var form = $('#form-login');
            var campos = {
                'input-email': {
                    required: true
                },
                'input-senha': {
                    required: true
                }
            }
            var mensagens = {}
            var isValido = FormValidationService.validarFormulario(form, campos, mensagens);

            return isValido();
        }

        function validarLoginResponse(result) {
                $scope.$emit('usuarioLogado', result); // Evento será escutado pela nossa masterController
        }

        function calcularAltura() {
            $('.altura').height(window.innerHeight);
        }
    }
})();
