(function () {
    var app = angular.module('MainModule', ['ngAnimate', 'ngLocale', 'ui.router', 'asc.cropper', 'asc.datatable', 'ngSanitize', 'ngCsv', 'ui.utils.masks']);

    var hostConfig = { DEV: '', HML: '', PRD: '' };

    app.constant('Host', hostConfig.DEV);
    app.constant('Controles', {
        dashboardController: 'C008'
    });

    app.config(['$stateProvider', '$urlRouterProvider', '$httpProvider', configStates]);
    function configStates($stateProvider, $urlRouterProvider, $httpProvider) {
        var root = "app/components/views/";

        moment().locale('pt-BR');
        $httpProvider.interceptors.push('HttpInterceptorFactory');

        $urlRouterProvider.otherwise("/");
        $stateProvider
            .state('login', {
                //     cache: false,
                url: "/",
                templateUrl: root + "login.html",
                controller: "LoginController",
                controllerAs: "login"
            })

            .state('wizard', {
                url: "/wizard",
                templateUrl: root + "wizard/index.html",
                controller: "WizardController",
                controllerAs: "wizard"
            })

            .state('logado', {
                //     cache: false,
                abstract: true,
                url: "/logado",
                templateUrl: root + "logado.html",
                controller: "MasterLogadoController",
                controllerAs: "logado"
            })
            .state('logado.dashboard', {
                url: "/dashboard",
                templateUrl: root + "dashboard.html",
                controller: "DashboardController",
                controllerAs: "dashboard"
            })
            .state('logado.suporte', {
                url: "/suporte",
                templateUrl: root + "suporte/index.html",
                controller: "SuporteController",
                controllerAs: "suporte"
            })
            .state('logado.financeiro', {
                url: "/financeiro",
                templateUrl: root + "financeiro/index.html",
                controller: "FinanceiroController",
                controllerAs: "financeiro"
            });
    }

    app.run(['$rootScope', 'HttpCancelService', 'NotificationService', 'TokenService', '$templateCache', runConfig]);
    function runConfig($rootScope, HttpCancelService, NotificationService, TokenService, $templateCache) {

        /*
         * Função de notificaçao de erro na requisição
         * Adiciona a função ao prototype de todos os $scope
         */
        var scope = Object.getPrototypeOf($rootScope);
        scope.notifyError = notifyError;

        $rootScope.$on('TokenInvalido', function (e) {
            NotificationService.sweetAlertErrorConfirm("", "Token inválido", function () {
                location.href = '/';
            });
        });

        $rootScope.$on('$stateChangeStart', stateChangeStart);

        function notifyError(mensagem) {

            /*Evento capturado pela masterController*/
            if (mensagem)
                $rootScope.$broadcast('SweetAlertError', mensagem);
            else
                $rootScope.$broadcast('notifyErrorRequest');
        }

        function stateChangeStart(e, toState, toParams, fromState, fromParams) {
            HttpCancelService.cancelRequests();
            if (toState.name.startsWith('logado', 0)) {
                $('#page-container').removeClass('sidebar-o-xs');


                if (!TokenService.isTokenValido()) {
                    TokenService.notifyUnauthorized();
                }
            }
        }
    }

}());