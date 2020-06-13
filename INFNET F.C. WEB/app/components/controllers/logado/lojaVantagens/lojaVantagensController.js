(function () {

    angular
        .module('MainModule')
        .controller('LojaVantagensController', lojaVantagensController);

    lojaVantagensController.$inject = ['$scope', 'HandlerFactoryLogado', '$timeout'];

    function lojaVantagensController($scope, HandlerFactoryLogado, $timeout) {

        var vm = this;
        vm.title = 'lojaVantagensController';

        $scope.idPartidaSelecionada;
        $scope.showSetores = false;

        $scope.proximosJogos = [];
        $scope.selecionarSetor = (idPartida) => {
            $scope.idPartidaSelecionada = idPartida;
            $scope.showSetores = true;
        }

        $scope.comprarIngresso = () => {
            $timeout(() => {
                $scope.$emit('SweetAlertSuccess', 'Compra realizada com sucesso');
            }, 4000);
        }

        HandlerFactoryLogado.obterProximasPartidas().then(x => {
            $scope.proximosJogos = x.reverse();
          
        }).catch(error => console.log(error));
    }
})();
