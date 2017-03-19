(function () {
    'use strict';

    angular
        .module('myapp')
        .controller('groupsListController', ['$scope', '$filter', '$timeout', '$responsHandler', 'appSettings', 'groupService', function ($scope, $filter, $timeout, $responsHandler, appSettings, groupService) {
            $scope.groups = [];
            $scope.showValidationErrors = false;
            $scope.current = {};
            $scope.isLoading = false;

            $timeout(function () {
                $scope.loadMoreGroups();
            }, 0);
            $scope.loadMoreGroups = function () {
                $scope.isLoading = true;
                groupService.loadGroups($scope.groups.length, 6).then(function (result) {
                    $responsHandler.handle(result.data, function () {
                        $scope.isLoading = false;
                        angular.forEach(result.data.Data, function (item, index) {
                            
                            $scope.groups.push(item);
                        });
                    });
                }, $responsHandler.handle);
            };
            $scope.joinOrLeaveGroup = function (group, join) {
                groupService.joinOrLeaveGroup(group.Id, join).then(function (result) {
                    $responsHandler.handle(result.data, function () {
                        group.IsInGroup = join;
                        group.MembersCount += result.data.Data;
                    });
                }, $responsHandler.handle);
            };
            $scope.createNewGroup = function () {
                angular.element("#groupModal").modal({
                    backdrop: 'static',
                    keyboard: true
                }, 'show');
            };
            $scope.saveGroup = function (isValid) {
                if (!isValid) {
                    $scope.showValidationErrors = true;
                    return;
                }
                $scope.isLoading = true;
                groupService.saveGroup($scope.current).then(function (result) {
                    $responsHandler.handle(result.data, function () {
                        $scope.isLoading = false;
                        $scope.groups.push(result.data.Data);
                        $scope.current = {};
                        angular.element("#groupModal").modal('hide');
                    });
                }, $responsHandler.handle);

            };
        }]);
})();