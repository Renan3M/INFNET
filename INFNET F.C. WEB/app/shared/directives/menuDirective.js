(function () {

    angular
        .module('MainModule')
        .directive('toggleSubmenu', menuDirective);

    function menuDirective() {
        // Usage:
        //     <a toggle-submenu></a>
        // Creates:
        //

        function link(scope, element, attrs) {

            element.bind('click', function (e) {

                var $link = jQuery(this);

                // Get link's parent
                var $parentLi = $link.parent('li');

                if ($parentLi.hasClass('open')) { // If submenu is open, close it..
                    $parentLi.removeClass('open');
                } else { // .. else if submenu is closed, close all other (same level) submenus first before open it
                    $link
                        .closest('ul')
                        .find('> li')
                        .removeClass('open');

                    $parentLi
                        .addClass('open');
                }
            });
        }

        var directive = {
            link: link,
            restrict: 'A'
        };

        return directive;
    }

})();