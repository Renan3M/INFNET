(function () {

    var app = angular.module('MainModule');
    app.directive('timer', timer);
    //app.directive('pageHeader', pageHeader);    
    app.directive('imgProduto', imgProduto);
    app.directive('imgExperiencia', imgExperiencia);
    app.directive('imgTime', imgTime);

    app.directive('pageHeader', pageHeader);
    app.directive('pageBlock', pageBlock);

    app.directive('autocompleteInput', autocompleteInput);
    app.directive('disableOnRequest', disableOnRequest);

    /*Diretiva de cabeçalho de página, recebe o título e renderiza o layout*/
    function pageHeader() {
        return {
            restrict: 'E',
            scope: {
                breadcrumb: "="
            },
            templateUrl: 'app/shared/directives/template/page-header.html',
            link: function (s, e, a) {
                e.find('h1').text(a.pageTitle);
            }
        }
    }

    /*Diretiva de timer, recebe uma data e calcula o tempo até a data*/
    function timer() {
        return {
            restrict: 'E',
            scope: {
                date: '@'
            },
            link: function (s, e, a) {
                function CountDownTimer(dt) {
                    var end = new Date(dt);

                    var _second = 1000;
                    var _minute = _second * 60;
                    var _hour = _minute * 60;
                    var _day = _hour * 24;
                    var timer;

                    function showRemaining() {
                        var now = new Date();
                        var distance = end - now;
                        if (distance < 0) {
                            clearInterval(timer);
                            angular.element(e).html('Encerrado');
                            return;
                        }
                        else {
                            s.days = Math.floor(distance / _day);
                            s.hours = Math.floor((distance % _day) / _hour);
                            s.minutes = Math.floor((distance % _hour) / _minute);
                            s.seconds = Math.floor((distance % _minute) / _second);

                            angular.element(e).html(s.days + ' dias ' + s.hours + 'h ' + s.minutes + 'min ' + s.seconds + 's');
                        }
                    }
                    timer = setInterval(showRemaining, 1000);
                }
                CountDownTimer(s.date);
            }
        }
    }

    imgProduto.$inject = ['Host'];
    function imgProduto(Host) {

        return {
            restrict: 'E',
            scope: true,
            link: function (s, e, a) {
                var folder = Host + 'produtos/';
                var imgId = a.imageId;
                s.alt = a.imageAlt;
                s.fullpath = folder + imgId;
                s.class = a.imageClass;
            },
            template: "<img ng-src='{{fullpath}}' alt='{{alt}}' />"
        }
    }

    imgExperiencia.$inject = ['Host'];
    function imgExperiencia() {

        return {
            restrict: 'E',
            scope: true,
            link: function (s, e, a) {
                var folder = Host + 'experiencia/';
                var imgId = a.imageId;
                s.alt = a.imageAlt;
                s.fullpath = folder + imgId;
            },
            template: "<img ng-src='{{fullpath}}' alt='{{alt}}' />"
        }
    }

    function imgTime() {

        return {
            restrict: 'E',
            scope: {
                'imageId': '@',
                'imageClass': '@',
                'imageAlt': '@'
            },
            template: "<img class='{{imageClass}}' ng-src='{{imageId}}' alt='{{imageAlt}}' />"
        }
    }

    //function pageHeader() {
    //    return {
    //        restrict: 'E',
    //        scope: true,
    //        templateUrl: 'app/shared/directives/template/page-header.html',
    //        replace: true,
    //        transclude: true,
    //        link: link
    //    }

    //    function link(scope, element, attr) {
    //        scope.title = attr.title;
    //    }
    //}

    function pageBlock() {
        return {
            restrict: 'E',
            scope: true,
            templateUrl: 'app/shared/directives/template/page-block.html',
            replace: true,
            transclude: true,
            link: link
        }

        function link(scope, element, attr) {
            scope.blockId = attr.blockId;
            scope.title = attr.title || attr.blockTitle;
            App.init("uiBlocks");
        }
    }

    autocompleteInput.$inject = ['$filter'];
    function autocompleteInput($filter) {
        return {
            restrict: 'E',
            scope: {
                hints: "=",
                selectedValue: "="
            },
            templateUrl: "app/shared/directives/template/autocomplete-input.html",
            controller: ["$scope", function ($scope) {

                $scope.inputText = "";
                $scope.hintsEnabled = false;
                $scope.selectedHints = [];

                //$scope.escolherOpcao = function (hint) {
                //    console.log("ex");
                //    $scope.inputText = hint.nome;
                //    $scope.selectedValue = hint.id;
                //}

                //$scope.updateHints = function () {
                //    var v = $scope.inputText;
                //    $scope.selectedHints = $filter('filter')($scope.hints, { nome: v }).slice(0, 5);
                //    $scope.hintsEnabled = true;
                //}

                //$scope.disableAutoComplete = function () {
                //    setTimeout(function () { $scope.hintsEnabled = false; }, 100);
                //}

            }],
            link: function (s, e, a) {

                s.escolherOpcao = function (hint) {

                    s.inputText = hint.nome;

                    s.selectedValue = hint.id;
                    s.hintsEnabled = false;
                }

                s.updateHints = function () {
                    s.selectedValue = '';
                    var v = s.inputText;
                    if (v.length > 3) {
                        s.selectedHints = $filter('filter')(s.hints, v);
                        s.hintsEnabled = true;
                    } else {
                        if (s.hintsEnabled)
                            s.hintsEnabled = false;
                    }
                }

                s.disableAutoComplete = function () {
                    //s.hintsEnabled = false;
                    setTimeout(function () { s.hintsEnabled = false; }, 100);
                }

                //e.find('input').bind('keyup', function () {

                //    var v = s.inputText;

                //    s.selectedHints = $filter('filter')(s.hints, { nome: v }).slice(0,5);
                //    s.hintsEnabled = true;
                //});

                //e.find('input').bind('blur', function () {
                //    s.hintsEnabled = false;
                //});
            }
        }
    }

    disableOnRequest.$inject = ['Host', '$rootScope'];
    function disableOnRequest(Host, $rootScope) {

        return {
            restrict: 'E',
            link: function (scope, element, attr) {

                var url = "";

                scope.$on('AjaxLoading', function (e, data) {
                    disableButton(true);
                });

                scope.$on('AjaxFinish', function (e, data) {
                    disableButton(false);
                    $rootScope.$on('$stateChangeStart', function (e) {
                        disableButton(true);
                    });
                });

                function disableButton(disable) {
                    angular.element("button").prop('disabled', disable);

                    if(disable)
                        angular.element("button").addClass('disabled');
                    else
                        angular.element("button").removeClass('disabled');
                }
            }
        }
    }

}());