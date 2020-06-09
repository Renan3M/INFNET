(function () {

    var formValidationService = function () {

        var _this = this;

        this.validarFormulario = function ($formulario, regras, mensagens) {

            jQuery.validator.addMethod("validateFlag", function (value, element) {
                return this.optional(element) || value != 'noflag';
            }, "Escolha uma bandeira de cartão");
            jQuery.validator.addMethod("validateCardExp", function (value, element) {
                return this.optional(element) || function () {
                    var hoje = new Date();
                    var mes = value.split('/')[0];
                    var ano = value.split('/')[1];
                    var anoAtual = hoje.getFullYear();
                    var mesAtual = hoje.getMonth() + 1;
                    if (mes > 12 || ano < anoAtual) {
                        return false;
                    }
                    else if (ano == anoAtual && mes < mesAtual) {
                        return false;
                    }
                    else
                        return true;
                }();
            }, "Data de validade inválida. Certifique-se de digitar 4 dígitos para o ano");
            jQuery.validator.addMethod("validateCpf", function (value, element) {
                return this.optional(element) || _this.validarCPF(value.replace('.', '').replace('.', '').replace('-', ''));
            });
            jQuery.validator.addMethod("validateGender", function (value, element) {
                return this.optional(element) || value != 'N';
            });
            
            var campoObrigatorio = "Campo obrigatório";
            var cpfInvalido = "CPF inválido";
            var generoObrigatorio = "Escolha um sexo";
            var emailInvalido = "Email inválido";

            $.validator.messages.required = campoObrigatorio;
            $.validator.messages.validateCpf = cpfInvalido;
            $.validator.messages.validateGender = generoObrigatorio;
            $.validator.messages.email = emailInvalido;

            var options = {
                errorClass: 'help-block animated fadeInDown',
                errorElement: 'div',
                errorPlacement: function (error, e) {
                    jQuery(e).parents('.form-group > div').append(error);
                },
                highlight: function (e) {
                    jQuery(e).closest('.form-group').removeClass('has-error').addClass('has-error');
                    jQuery(e).closest('.help-block').remove();
                },
                success: function (e) {
                    jQuery(e).closest('.form-group').removeClass('has-error');
                    jQuery(e).closest('.help-block').remove();
                },
                rules: regras,
                messages: mensagens
            }

            return validate;

            function validate() {
                var $validator = $formulario.validate(options);
                var $valid = $formulario.valid();

                if (!$valid) {
                    $validator.focusInvalid();
                    return false;
                }
                else
                    return true;
            }                        
        }

        this.obterCampos = function ($formulario) {
            return $formulario.find('input[type="text"], input[type="password"], input[type="date"], select');
        }

        this.validarPreenchimento = function (campos) {
            var t = campos.length;
            var valid = true;
            for (var i = 0; i < t; i++) {
                //console.log(campos[i].value);
                if (campos[i].value.trim() == '') {
                    campos[i].setCustomValidity('Campo obrigatório');
                    campos[i].onkeyup = function () { this.setCustomValidity(''); };
                    valid = false;
                    break;
                }
                else {
                    campos[i].setCustomValidity('');
                    valid = true;
                }
            }
            return valid;
        }

        this.desabilitarCampos = function (campos) {
            var t = campos.length;
            for (var i = 0; i < t; i++) {
                angular.element(campos[i]).attr('disabled', 'disabled');
            }
        }

        this.habilitarCampos = function (campos) {
            var t = campos.length;
            for (var i = 0; i < t; i++) {
                angular.element(campos[i]).removeAttr('disabled');
            }
        }

        this.validarConfirmacaoSenha = function (passwordInput, passwordConfirmationInput) {
            if (passwordInput.value != '' && passwordConfirmationInput.value != '') {

                if (passwordInput.value != passwordConfirmationInput.value) {
                    $(passwordInput).on('focus', function () {
                        passwordConfirmationInput.setCustomValidity('');
                    });
                    $(passwordConfirmationInput).on('keyup', function () {
                        passwordConfirmationInput.setCustomValidity('');
                    });
                    passwordConfirmationInput.setCustomValidity('As senhas digitadas estão diferentes');
                    return false;
                }
                else {
                    passwordConfirmationInput.setCustomValidity('');
                    return true;
                }
            }
            else
                return false;
        }

        this.validarCPF = function (strCPF) {
            for (var i = 0; i <= 9; i++) { var d = i.toString(); var invalid = d + d + d + d + d + d + d + d + d + d + d; if (strCPF == invalid) return false; }; var Soma; var Resto; Soma = 0; for (i = 1; i <= 9; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i); Resto = (Soma * 10) % 11; if ((Resto == 10) || (Resto == 11)) Resto = 0; if (Resto != parseInt(strCPF.substring(9, 10))) return false; Soma = 0; for (i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i); Resto = (Soma * 10) % 11; if ((Resto == 10) || (Resto == 11)) Resto = 0; if (Resto != parseInt(strCPF.substring(10, 11))) return false; return true;
        }


        return this;
    }

    angular.module('MainModule').service('FormValidationService', formValidationService);

}());