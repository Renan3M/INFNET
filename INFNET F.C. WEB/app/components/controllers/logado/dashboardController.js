(function () {

    angular
        .module('MainModule')
        .controller('DashboardController', dashboardController);

    dashboardController.$inject = ['$scope', 'HandlerFactoryLogado', '$timeout'];

    function dashboardController($scope, HandlerFactoryLogado, $timeout) {

        if(sessionStorage.getItem('socioAtivo') == null)
            $scope.$emit("SweetAlertNotification", "Sócio deve finalizar sua compra", "Por favor, vá na aba financeiro e realize a compra ou o pagamento do seu plano para ter acesso à loja de vantagens.");


        var vm = this;
        vm.title = 'dashboardController';

        $scope.proximosJogos = [];

        HandlerFactoryLogado.obterProximasPartidas().then(x => {
            $scope.proximosJogos = x.reverse();
          
        }).catch(error => console.log(error));
    }
})();
