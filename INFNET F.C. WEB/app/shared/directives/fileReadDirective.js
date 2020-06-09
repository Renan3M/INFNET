angular
    .module('MainModule')
    .directive("fileRead", [function () {
        return {
            restrict: 'A',
            scope: {
                fileRead: "="
            },
            link: function (s, e, a) {
                e.bind("change", onChange);

                function onChange(event) {
                    s.$apply(function () {
                        s.fileRead = event.target.files[0];
                    });

                    //var reader = new FileReader();
                    //reader.onload = onLoad;
                    //reader.readAsArrayBuffer(event.target.files[0]);
                }

                function onLoad(event) {
                    s.$apply(function () {
                        s.fileRead = event.target.result;
                    });
                }
            }
        }
    }]);