(function () {
    

    angular
        .module('MainModule')
        .service('NotificationService', notificationService);

    function notificationService() {

        this.sweetAlert = sweetAlert;
        this.sweetAlertConfirm = sweetAlertConfirm;
        this.sweetAlertSuccess = sweetAlert.bind(this, 'success');
        this.sweetAlertError = sweetAlert.bind(this, 'error');
        this.sweetAlertErrorConfirm = sweetAlertErrorConfirm;
        this.sweetAlertErrorRequest = sweetAlertErrorRequest;
        this.sweetAlertSessionExpired = sweetAlertSessionExpired;

        return this;

        /*Notificacoes com SweetAlert*/
        function sweetAlert(type, title, text) {
            swal({ title: title, text: text, type: type, confirmButtonColor: "#eeb317" });
        }

        function sweetAlertErrorConfirm(title, text, confirmFn) {

            swal({ title: title, text: text, type: 'error', confirmButtonColor: "#eeb317" }, confirmFn);
        }

        function sweetAlertErrorRequest(confirmFn) {
            
            swal({ title: "Erro.", text: "Ocorreu um erro durante a requisição.", type: 'error', confirmButtonColor: "#eeb317" }, confirmFn);
        }

        function sweetAlertConfirm(title, text, confirmFn) {
            swal({
                title: title || 'Atenção',
                text: text,
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: "#EEB317",
                confirmButtonText: "OK",
                cancelButtonText: "Cancelar",
                closeOnConfirm: true,
                closeOnCancel: true
            }, confirmFn);
        }

        //function sweetAlertSuccess(title, text, confirmFn) {
        //    swal({
        //        title: title || 'Sucesso',
        //        text: text,
        //        type: 'success',
        //        //showCancelButton: true,
        //        confirmButtonColor: "#EEB317",
        //        confirmButtonText: "OK",
        //        closeOnConfirm: true
        //    }, confirmFn);
        //}

        function sweetAlertSessionExpired(confirmFn) {
            swal({ title: "Sessão expirada.", text: "Você não está logado ou sua sessão expirou, faça login novamente para acessar o sistema.", type: 'error', confirmButtonColor: "#eeb317" }, confirmFn);
        }
    }
})();