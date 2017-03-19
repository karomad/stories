(function () {
    'use strict';
    angular
        .module('appLogin')
        .factory('loginService', ['$http', 'appSettings', function ($http, appSettings) {
            var service = {};
            var _login = function (data) {
                return $http.post(appSettings.BaseUrl + 'User/Login?name=' + data).then(function (result) {
                    return result;
                });
            };
            service.login = _login;
            return service;
        }]);
})();