(function () {
    'use strict';

    angular
        .module('appLogin')
        .controller('loginController', ['$scope', '$filter', '$timeout', 'appSettings', 'loginService', function ($scope, $filter, $timeout, appSettings, loginService) {
            $scope.User = {};
            $scope.showValidationErrors = false;
            $scope.isLoading = false;
            $scope.login = function (isValid) {
                if (!isValid) {
                    $scope.showValidationErrors = true;
                    return;
                }
                $scope.isLoading = true;
                loginService.login($scope.User.Name).then(function (result) {
                    if (result.data.Status == 200) {

                        location.replace('/Home/Index');
                    }
                    else if (result.data.Error) {
                        $scope.isLoading = false;
                        toastr.error(result.data.Error, 'Error');
                    }
                    else {
                        $scope.isLoading = false;
                        toastr.error('', 'Error');
                    }
                },
                function (err)
                {
                    toastr.error(err.data, 'Error');
                });
            };

        }]);
})();