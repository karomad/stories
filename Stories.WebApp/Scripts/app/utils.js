(function () {
    'use strict';

    angular
        .module('myapp')
        .factory('$responsHandler', [function () {
            var service = {};
            var _handle = function (data, successCallBack) {
                if (data.Status == 200) {
                    if (successCallBack) {
                        successCallBack();
                    }
                }
                else if (data.Status == 408 || data.status == 408 || data.Status == 401 || data.status == 401) {
                    location.replace('/User/Login');
                }
                else if (data.Error){
                    toastr.error(data.Error, 'Error');
                }
                else {
                    toastr.error('An error occured', 'Error');
                }
            };
            service.handle = _handle;
            return service;
        }]);
})();