(function () {

    angular
        .module('MainModule')
        .controller('SuporteController', suporteController);

    suporteController.$inject = ['$scope', 'HandlerFactoryLogado', '$timeout'];

    function suporteController($scope, HandlerFactoryLogado, $timeout) {
        $scope.duvida = {
            IDSOCIO_FK: parseInt(sessionStorage.getItem("idUsuario")),
            Nome: sessionStorage.getItem("nome"),
            Assunto: null,
            Mensagem: null
        };

        $scope.sendeInformationen = enviarInformacoes;

        function enviarInformacoes() {
            HandlerFactoryLogado.enviarDuvida($scope.duvida).then(a => {
                $scope.$emit("SweetAlertSuccess", "Nós estamos trabalhando para te responder o mais breve possível, por favor aguarde.", null,null)
            })
        }
    }

})()