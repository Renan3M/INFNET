(function () {

    angular.module('MainModule').service('UtilService', UtilService);

    function UtilService() {

        this.dateToReference = dateToReference;
        this.referenceToDate = referenceToDate;
        this.formatDate = formatDate;

        return this;

        function dateToReference(date) {

            var month = moment(date).get('month') + 1;
            var year = String(moment(date).get('year'));

            month = month < 10 ? '0' + month : String(month);

            return parseInt(year + month);
        }

        function referenceToDate(referenceInNumber) {

            var refenceInString = referenceInNumber.toString();
            return moment(refenceInString, "YYYYMM").toDate();
        }

        function formatDate(date, format) {

            if (format)
                return moment(date).format(format);

            return moment(date).toDate();
        }
    }
})();