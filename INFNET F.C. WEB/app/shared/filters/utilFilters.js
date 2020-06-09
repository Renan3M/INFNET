(function () {

    angular.module('MainModule').filter('DateFormat', date);
    function date() {
        return filter;
        function filter(input, format) {
            if (!input) return;

            if (format)
                return moment(input).format(format);
            return moment(input).toDate();
        }
    }

    angular.module('MainModule').filter('toString', toString);
    function toString() {

        return filter;

        function filter(input) {
            if (input)
                return input.toString();
        }
    }

})();