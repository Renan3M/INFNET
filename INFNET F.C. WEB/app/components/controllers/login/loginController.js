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
        vm.ValidaCPF = ValidaCPF;
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

        function ValidaCPF() {

            var cpfValido = /^(([0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}))$/;
            if (cpfValido.test(vm.CPF) == false) {

                vm.CPF = vm.CPF.replace(/\D/g, ""); //Remove tudo o que não é dígito

                if (vm.CPF.length == 11) {
                    vm.CPF = vm.CPF.replace(/(\d{3})(\d)/, "$1.$2"); //Coloca um ponto entre o terceiro e o quarto dígitos
                    vm.CPF = vm.CPF.replace(/(\d{3})(\d)/, "$1.$2"); //Coloca um ponto entre o terceiro e o quarto dígitos
                    //de novo (para o segundo bloco de números)
                    vm.CPF = vm.CPF.replace(/(\d{3})(\d{1,2})$/, "$1-$2"); //Coloca um hífen entre o terceiro e o quarto dígitos
                } else {
                    console.log("CPF invalido");
                }

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
