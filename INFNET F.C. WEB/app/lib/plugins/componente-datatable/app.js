/// <reference path="template/datatable.html" />
(function () {
    'use strict';

    var app = angular.module('asc.datatable', []);

    app.directive('myDatatable', function ($filter, $compile) {

        return {

            restrict: 'EA',
            scope: true,
            transclude: true,
            templateUrl: '/app/lib/plugins/componente-datatable/template/datatable.html',
            controller: function ($scope) {

                (function (s) {

                    var b, currentList, pages, currentOrder, reverse;

                    s.$on('InitDatatable', function (event, array) {

                        b = array;
                        currentList = b;
                        pages = createPages(b, 10);

                        initDatatable(pages);
                        //s.$apply();

                    });
                    s.$on('SearchConfig', function (event, config) {

                        /*dynamic search*/

                        //var config = [
                        //    {
                        //        searchFor: 'nome',
                        //        buttonLabel: 'Procurar por nome'
                        //    },
                        //    {
                        //        searchFor: 'codigo',
                        //        buttonLabel: 'Procurar por codigo'
                        //    },
                        //    {
                        //        searchFor: 'cpf'
                        //    }
                        //];

                        s.searchFilters = [];
                        config.forEach(function (e, i, a) {

                            s['searchParam' + i] = {};
                            s['searchParam' + i].searchFor = e.searchFor;
                            s['searchParam' + i].buttonLabel = e.buttonLabel || 'Search';
                            s['searchParam' + i].model = '';

                            s.searchFilters.push(s['searchParam' + i]);
                        });

                        s.$apply();
                    });
                    s.$on('ClearDatatable', function () {
                        delete s.lst;
                        delete s.pages;
                    });

                    s.nextPage = nextPage;
                    s.prevPage = prevPage;
                    s.goToPage = goToPage;
                    s.searchByName = searchByName;
                    s.loadResults = loadResults;
                    s.removeFilters = removeFilters;
                    s.search = search;
                    s.orderBy = orderBy;
                    s.selecionarTodos = selecionarTodos;

                    function nextPage() {
                        if (++s.currPage <= pages.lastPage)
                            s.lst = pages['page' + s.currPage];
                        else
                            s.currPage--;
                    }
                    function prevPage() {
                        if (--s.currPage !== 0)
                            s.lst = pages['page' + s.currPage];
                        else
                            s.currPage++;
                    }
                    function goToPage(pageNumber) {
                        if (pageNumber <= pages.lastPage) {
                            s.currPage = pageNumber;
                            s.lst = pages['page' + pageNumber];
                        }
                        else
                            alert('Página inexistente');
                    }
                    function searchByName(name) {
                        var result = $filter('filter')(currentList, { nome: name });
                        if (result.length) {
                            currentList = result;
                            pages = createPages(currentList, s.resultsPerPage);
                            initDatatable(pages);
                        }
                        else
                            alert('Nenhum encontrado');
                    }
                    function search(searchFilter) {

                        var filter = {};
                        filter[searchFilter.searchFor] = searchFilter.model;

                        var result = $filter('filter')(currentList, filter);
                        if (result.length) {
                            currentList = result;
                            pages = createPages(currentList, s.resultsPerPage);
                            initDatatable(pages);
                        }
                        else
                            alert('Nenhum encontrado');
                    }
                    function orderBy(param) {
                        if (param) {
                            if (!currentOrder) {
                                currentOrder = param;
                                reverse = true;
                            }
                            else {
                                if (currentOrder === param)
                                    reverse = reverse ? false : true;
                                else
                                    reverse = false;
                            }


                            var result = $filter('orderBy')(currentList, param, reverse);
                            if (result.length) {
                                currentList = result;
                                pages = createPages(currentList, s.resultsPerPage);
                                initDatatable(pages);
                                currentOrder = param;
                            }
                        }
                    }
                    function loadResults(resultsPerPage) {
                        pages = createPages(currentList, resultsPerPage);
                        initDatatable(pages);
                    }
                    function removeFilters() {
                        currentList = b;
                        pages = createPages(b, s.resultsPerPage);
                        initDatatable(pages);
                    }
                    function initDatatable(pages) {
                        s.currPage = 1
                        s.lst = pages['page' + s.currPage];
                        s.pages = pages.pages;
                        s.lastPage = pages.lastPage;
                    }
                    function selecionarTodos() {

                        var t = selecionarTodasPaginas(pages);
                        s.$emit('selecionarTodos', t);

                        function selecionarTodasPaginas(allPages) {
                            var pgs = Object.keys(allPages);
                            var a = [];

                            //length - 1 para não pegar propriedade lastPage
                            for (var i = 0; i < pgs.length - 1; i++) {

                                for (var y = 0; y < allPages[pgs[i]].length; y++) {

                                    if (allPages[pgs[i]][y].Cep) {
                                        allPages[pgs[i]][y].check = allPages[pgs[i]][y].check ? false : true;
                                        a.push(allPages[pgs[i]][y]);
                                    }
                                }
                            }
                            return a;
                        }
                    }

                }($scope));
            },
            link: function (s, e, a, c, t) {
                t(s.$new(), function (clone) {

                    var heads = angular.element(clone).find('thead tr th');
                    for (var i = 1; i < heads.length; i++) {/*Primeira coluna não possui filtro*/
                        var el = angular.element(heads[i]);
                        if (el)
                            el.attr('ng-click', "orderBy('" + el.text().toLowerCase() + "')");
                    }

                    /*função de selecionar todos na página*/
                    var element = angular.element(heads[0]);
                    element.attr('ng-click', 'selecionarTodos()');

                    $compile(clone)(s);
                    e.append(clone);
                });
            }

        }

        /*
         * @param {Array} a Lista de itens
         * @param {Number} n Número de itens por página
         */
        function createPages(a, n) {

            //var date = new Date();
            //console.log(date.getSeconds() + ':' + date.getMilliseconds());


            var r = {};
            var currentPage = 0;

            var t = a.length;
            var s = t % n;
            var numberOfPages = t / n;

            if (s !== 0) {
                numberOfPages++;
            }

            var start;
            var end;

            for (var i = 1; i <= numberOfPages; i++) {
                currentPage = i;

                start = (i - 1) * n;
                end = i * n;

                r['page' + currentPage] = a.slice(start, end);
            }

            r.lastPage = currentPage;

            //var date2 = new Date();
            //console.log(date2.getSeconds() + ':' + date2.getMilliseconds());

            return r;
        }
    });
})();