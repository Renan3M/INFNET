(function () {
    'use strict';
    var app = angular.module('asc.cropper', []);

    app.directive('cropper', cropperDirective);

    function cropperDirective() {

        return {
            restrict: 'EA',
            scope: {
                url: '@',
                width: '@',
                height: '@',
                widthPreview: '@',
                heightPreview: '@'
            },
            templateUrl: '/app/lib/plugins/componente-imagem/angular/template/croppertemplate.html',
            link: function (s, e, a) {
                s.width = a.width;
                s.height = a.height;
            },
            controller: ['$scope', function ($scope) {

                var console = window.console || { log: function () { } };
                var $image = $('#image');
                var $download = $('#download');
                var options = {
                    aspectRatio: $scope.width / $scope.height,
                    preview: '.img-preview',
                    cropBoxResizable: false
                };

                var $inputImage = $('#inputimage');
                var URL = window.URL || window.webkitURL;
                var blobURL;

                //if (!$scope.widthPreview)
                //    $scope.widthPreview = $scope.width;

                //if (!$scope.heightPreview)
                //    $scope.heightPreview = $scope.height;

                if ($scope.width > 600 && $scope.height > 600) {
                    $scope.widthPreview = $scope.width * 0.3;
                    $scope.heightPreview = $scope.height * 0.3;
                } else if ($scope.width > 300 && $scope.height > 300) {
                    $scope.widthPreview = $scope.width * 0.5;
                    $scope.heightPreview = $scope.height * 0.5;
                } else {
                    $scope.widthPreview = $scope.width;
                    $scope.heightPreview = $scope.height;
                }

                // Cropper
                $image.cropper(options);

                // Usar setas para dar zoom e rodar a imagem
                $(document.body).on('keydown', function (e) {

                    if (!$image.data('cropper') || this.scrollTop > 300) {
                        return;
                    }

                    switch (e.which) {
                        /*Left*/
                        case 37:
                            e.preventDefault();
                            $image.cropper('rotate', -90);
                            break;

                            /*Up*/
                        case 38:
                            e.preventDefault();
                            $image.cropper('zoom', 0.1);
                            break;

                            /*Right*/
                        case 39:
                            e.preventDefault();
                            $image.cropper('rotate', 90);
                            break;

                            /*Down*/
                        case 40:
                            e.preventDefault();
                            $image.cropper('zoom', -0.1);
                            break;
                    }

                });


                /*Salvar imagem*/
                $scope.saveCroppedImage = saveCroppedImage;
                function saveCroppedImage() {

                    var image = $image.cropper('getCroppedCanvas',
                         {
                             width: $scope.width,
                             height: $scope.height
                         });

                    $(image).attr('id', 'croppedImage');
                    //$('#getcroppedcanvasmodal').modal('show');
                    $('#getcroppedcanvasmodal .modal-body').html(image);

                    var dataUrl = document.getElementById('croppedImage').toDataURL();
                    $scope.$emit('croppedBase64', dataUrl);

                }

                /*Reset do cropper*/
                $scope.resetCropper = resetCropper;
                function resetCropper() {
                    $image.cropper('destroy');
                    $image.cropper(options);

                    $scope.$emit('resetCropper');
                }

                $scope.$on('saveCroppedImage', function (e) {
                    saveCroppedImage();
                });

                /*Carregar uma imagem por fora da diretiva*/
                $scope.$on('loadImage', function (e, imagem) {
                    //$image.cropper('reset').cropper('replace', imagem);
                    $image.one('built.cropper', function () {}).cropper('reset').cropper('replace', imagem);
                    $inputImage.val('');
                    $scope.$emit('imageLoaded');
                });


                // Import image


                if (URL) {
                    $inputImage.change(function () {
                        var files = this.files;
                        var file;

                        if (!$image.data('cropper')) {
                            return;
                        }

                        if (files && files.length) {
                            file = files[0];

                            if (/^image\/\w+$/.test(file.type)) {

                                blobURL = URL.createObjectURL(file);
                                $image.one('built.cropper', function () {
                                    URL.revokeObjectURL(blobURL);
                                }).cropper('reset').cropper('replace', blobURL);
                                $inputImage.val('');
                                $scope.$emit('newImageLoaded');
                            } else {
                                window.alert('Por favor, escolha um arquivo de imagem');
                            }
                        }
                    });
                } else {
                    $inputImage.prop('disabled', true).parent().addClass('disabled');
                }
            }]
        }
    }
})();