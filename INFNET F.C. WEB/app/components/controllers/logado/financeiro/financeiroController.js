(function () {

    /***
     * Cojitando criar um Model para Ingresso e criar um vinculo de AssinaturaIngresso e não AssinaturaPartida, 
     * pois não faz sentido o sócio ter uma partida e poder altera-la.
     ***/

    angular
        .module('MainModule')
        .controller('FinanceiroController', financeiroController);

    financeiroController.$inject = ['$scope', 'HandlerFactoryLogado', '$state'];

    function financeiroController($scope, HandlerFactoryLogado, $state) {

        /* jshint validthis:true */
        var idUsuario = parseInt(sessionStorage.getItem("idUsuario"));

        buscarAssinaturaSocio();
        buscarCobrancasSocio();

        $scope.setPaymentType = selecionarTipoPagamento;
        $scope.paymentType = 0;

        $scope.Assinatura = {};
        $scope.Cobrancas = [];
        $scope.ativarAssinatura = ativarAssinatura;
        $scope.pagarCobranca = pagarCobranca;

        function buscarAssinaturaSocio() {
            HandlerFactoryLogado.buscarAssinaturaSocio(idUsuario).then(result => {
                if (result) {
                    $scope.Assinatura = result;
                    $scope.Assinatura.status = result.flG_ATIVA ? "ATIVA" : "INATIVA";
                    $scope.Assinatura.planO_FK.nome = result.planO_FK.nome != null ? result.planO_FK.nome : "Sem plano";
                    $scope.paymentType = result.TIPO_PAGAMENTO
                }
            });
        }

        function pagarCobranca(cobId, index) {
            HandlerFactoryLogado.pagarCobranca(cobId).then(result => {
                $scope.Cobrancas[index].flG_PAGA = true;
            });
        }

        function buscarCobrancasSocio() {
            HandlerFactoryLogado.buscarCobrancasSocio(idUsuario).then(result => {
                if (result) {
                    $scope.Cobrancas = result;
                }
            });
        }

        function ativarAssinatura() {
            if ($scope.paymentType == 0) {
                $scope.$emit("SweetAlertConfirm", "Forma de pagamento", "Você tem certeza que prefere utilizar boleto? Com o cartão você receberá 10% de desconto do valor total.", () => {
                    HandlerFactoryLogado.gerarCobrancas(idUsuario, $scope.paymentType).then(result => {
                        $scope.Cobrancas = result.cobrancas;
                        sessionStorage.setItem('socioAtivo', true);
                        $scope.$emit('SaveMenuList', result.menus);
                        $state.reload();
                    });
                });
            } else {
                HandlerFactoryLogado.gerarCobrancas(idUsuario, $scope.paymentType).then(result => {
                    $scope.Cobrancas = result.cobrancas;
                    sessionStorage.setItem('socioAtivo', true);
                    $scope.$emit('SaveMenuList', result.menus);
                    $state.reload();
                });
            }

        }

        function selecionarTipoPagamento(tipo) {
            if (tipo == "boleto") {
                $scope.paymentType = 0;

            } else {
                $scope.paymentType = 1;
            }
        }

    }
})();
