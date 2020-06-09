/*Este arquivo contem as diretivas de atributo customizadas*/

(function () {
    var app = angular.module('MainModule');
    app.directive('preventDefault', preventDefault);
    app.directive('slider', slider);
    app.directive('tooltiptop', tooltiptop);
    app.directive('condAttr', condAttr);
    app.directive('fixedHeader', fixedHeader);
    //app.directive('preventDuplicate', preventDuplicate);
    //app.directive('breadcrumb', breadcrumb);

    /*Diretiva para evitar a propagação do evento de clique*/
    function preventDefault() {
        return {
            restrict: 'A',
            link: function (s, e, a) {
                e.bind('click', function (ev) {
                    ev.preventDefault();
                });
            }
        }
    }

    /*Diretiva de slider criada para corrigir problema de renderização do slider com ng-repeat*/
    function slider() {

        return {
            restrict: 'A',
            scope: {
                watch: "@"
            },
            link: function (s, e, a) {

                // container do slider
                var $slider = jQuery(e);

                // configurações do slider através de atributos data
                var $sliderArrows = $slider.data('slider-arrows') ? $slider.data('slider-arrows') : false;
                var $sliderDots = $slider.data('slider-dots') ? $slider.data('slider-dots') : false;
                var $sliderNum = $slider.data('slider-num') ? $slider.data('slider-num') : 1;
                var $sliderAuto = $slider.data('slider-autoplay') ? $slider.data('slider-autoplay') : false;
                var $sliderAutoSpeed = $slider.data('slider-autoplay-speed') ? $slider.data('slider-autoplay-speed') : 3000;

                //watch do atributo 'watch', se o $scope passar o valor 'isLoaded', carrega o slider
                var clearWatch = s.$watch('watch', function (newValue, oldValue) {
                    if (newValue == 'isLoaded') {
                        $slider.slick({
                            arrows: $sliderArrows,
                            dots: $sliderDots,
                            slidesToShow: $sliderNum,
                            autoplay: $sliderAuto,
                            autoplaySpeed: $sliderAutoSpeed
                        });
                        clearWatch();
                    }
                });
            }
        }
    }

    function tooltiptop() {
        return {
            restrict: 'A',
            link: function (s, e, a) {
                e.attr('data-toggle', 'tooltip');
                e.attr('data-original-title', a.tooltiptop);

                $('[data-toggle="tooltip"]').tooltip({ 'placement': 'top', container: "body" });
            }
        }
    }

    /*Diretiva para adicionar ou remover um atributo baseado numa condição*/
    function condAttr() {
        return {
            restrict: 'A',
            scope: {
                condAttr: "=",
                condAttrValue: "@"
            },
            link: function (s, e) {

                s.$watch('condAttr', function (v) {
                    var value = s.condAttrValue;

                    e.attr(value, function () {

                        if (!s.condAttr) {
                            return value;
                        }
                        else {
                            return null;
                        }
                    });
                });


            }
        }
    }

    function fixedHeader() {
        return {
            restrict: 'A',
            scope: true,
            controller: function ($scope, $rootScope) {

                var $table;
                var $tableFixed;

                var _pageId;
                $scope.$on('InitFixedHeader', function (e, blockId) {
                    $("table.fixed-header").remove();
                    $table = $("table[fixed-header]");
                    $tableFixed = $table.clone();

                    $table.parent().css("position", "relative")
                    $tableFixed.css("position", "absolute");
                    $tableFixed.addClass("fixed-header");
                    $tableFixed.removeAttr("fixed-header");
                    $tableFixed.find("tbody").remove().end().insertBefore($table);
                    $tableFixed.css("background-color", "white");
                    $tableFixed.find("i").remove();
                    $tableFixed.hide();
                });

                $(window).scroll(function () {

                    if (!$table || !$tableFixed)
                        return;

                    var offset = $(window).scrollTop();
                    var top = $(window).scrollTop() + $("#header-navbar").outerHeight(true) - $table.offset().top;

                    var tableOffsetTop = $table.offset().top;
                    var tableOffsetBottom = tableOffsetTop + $table.height() - $table.find("thead").height();

                    if (offset < tableOffsetTop || offset > tableOffsetBottom) {
                        $tableFixed.hide();
                    } else {

                        $tableFixed.css("top", top);

                        $tableFixed.show();
                    }
                });

            }
        }
    }

    /*Diretiva para bloquear requisição duplicada*/
    //preventDuplicate.$inject = ['Host', '$http'];
    //function preventDuplicate(Host, $http) {
    //
    //    return {
    //        restrict: 'A',
    //        scope: {
    //            anotherButtonsToBlock: '='
    //        },
    //        link: function (scope, element, attr) {
    //
    //            var url = "";
    //
    //            element.bind('click', function () {
    //                scope.$on('AjaxLoading', function (e, data) {
    //
    //                    if (!url)
    //                        url = data.replace(Host, "");
    //
    //                    disableButton(true);
    //                });
    //            });
    //
    //            scope.$on('AjaxFinish', function (e, data) {
    //                if (url == data.replace(Host, "")) {
    //
    //                    url = "";
    //
    //                    if (!containsOtherRequest()) {
    //                        setTimeout(function () {
    //
    //                            disableButton(false);
    //
    //                        }, 500);
    //                    }
    //                }
    //            });
    //
    //            function containsOtherRequest() {
    //
    //                scope.$on('AjaxLoading', function (e, data) {
    //                    if (!data.endsWith(".html"))
    //                        url = data.replace(Host, "");
    //                });
    //
    //                return !!url;
    //            }
    //
    //
    //            function disableButton(disable) {
    //
    //                element.prop('disabled', disable);
    //
    //                if (scope.anotherButtonsToBlock.length) {
    //
    //                    scope.anotherButtonsToBlock.forEach(function (anotherButtonToBlock) {
    //                        angular.element(anotherButtonToBlock).prop('disabled', disable);
    //                    });
    //                }
    //            }
    //        }
    //    }
    //}

    /*Diretiva para gerar breadcrumb*/
    //function breadcrumb() {
    //    return {
    //        restrict: 'A',
    //        replace: true,
    //        transclude: true,
    //        template: '<div class="col-sm-5 text-right hidden-xs">' +
    //                    '<ol class="breadcrumb push-10-t" ng-transclude></ol>' +
    //                  '</div>'
    //    }
    //}
}());