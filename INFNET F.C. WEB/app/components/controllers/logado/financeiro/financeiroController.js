(function () {

    /***
     * Cojitando criar um Model para Ingresso e criar um vinculo de AssinaturaIngresso e não AssinaturaPartida, 
     * pois não faz sentido o sócio ter uma partida e poder altera-la.
     ***/

    angular
        .module('MainModule')
        .controller('FinanceiroController', financeiroController);

    financeiroController.$inject = ['$scope', 'HandlerFactoryLogado'];

    function financeiroController($scope, HandlerFactoryLogado) {

        /* jshint validthis:true */

        buscarAssinaturaSocio();
        $scope.setPaymentType = selecionarTipoPagamento;
        $scope.tipoPagamento = 0;
        $scope.Assinatura = {};

        function buscarAssinaturaSocio() {
            HandlerFactoryLogado.buscarAssinaturaSocio(parseInt(sessionStorage.getItem("idUsuario"))).then(result => {
                if (result)
                    $scope.Assinatura = result;
            });
        }

        function selecionarTipoPagamento(tipo) {
            if (tipo == "boleto") {
                $scope.tipoPagamento = 0;

            } else {
                $scope.tipoPagamento = 1;
            }
        }

    }
})();
