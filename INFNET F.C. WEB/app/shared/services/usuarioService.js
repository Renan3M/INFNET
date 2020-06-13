(function () {


    angular
        .module('MainModule')
        .factory('UsuarioService', usuarioService);

    function usuarioService() {

        var usuario = {
            idUsuario: 0,
            nome: '',
            lstMenu: []
        }

        function getSid() {
            return btoa(JSON.stringify({ UsuarioId: getIdUsuario() }));

        }

        function getIdUsuario() {
            return usuario.idUsuario;
        }

        function getNome() {
            return usuario.nome;
        }


        function getLstMenu() {
            return usuario.lstMenu;
        }

        function setIdUsuario(value) {
            usuario.idUsuario = value;
        }

        function setNome(value) {
            usuario.nome = value;

        }

        function setLstMenu(value) {
            usuario.lstMenu = value;
        }


        function saveToSessionStorage(idUsuario, nome, lstMenu) {
            sessionStorage.setItem('idUsuario', idUsuario);
            sessionStorage.setItem('nome', nome);
            sessionStorage.setItem('lstMenu', angular.toJson(lstMenu));

            setAll(idUsuario, nome,lstMenu);
        }

        function saveMenuSessionStorage(lstMenu) {
            sessionStorage.setItem('lstMenu', angular.toJson(lstMenu));

            setLstMenu(lstMenu);
        }

        function setAll(idUsuario, nome, lstMenu) {
            setIdUsuario(idUsuario);
            setNome(nome);
            setLstMenu(lstMenu);
        }

        function loadFromSessionStorage() {

            setAll(sessionStorage.getItem('idUsuario'), sessionStorage.getItem('nome'), angular.fromJson(sessionStorage.getItem('lstMenu')));
        }

        function clear() {
            usuario = {
                idUsuario: 0,
                nome: '',
                lstMenu: []
            }
        }

        return {
            saveToSessionStorage: saveToSessionStorage,
            saveMenuSessionStorage: saveMenuSessionStorage,
            loadFromSessionStorage: loadFromSessionStorage,
            getSid: getSid,
            getIdUsuario: getIdUsuario,
            getNome: getNome,
            getLstMenu: getLstMenu,
            clear: clear
        }
    }
})();