(function () {
    'use strict';

    angular
        .module('myapp')
        .controller('storiesListController', ['$scope', '$filter', '$timeout', '$responsHandler', 'appSettings', 'storyService', function ($scope, $filter, $timeout, $responsHandler, appSettings, storyService) {
            $scope.stories = [];
            $scope.current = {};
            $scope.isLoading = false;

            $timeout(function () {
                $scope.loadMoreStories();
            },
            0);

            $scope.loadMoreStories = function () {

                $scope.isLoading = true;
                storyService.loadStories($scope.stories.length, 6).then(function (result) {
                    $responsHandler.handle(result.data, function () {
                        $scope.isLoading = false;
                        angular.forEach(result.data.Data, function (item, index) {
                            $scope.stories.push(item);
                        });
                    });
                }, $responsHandler.handle);
            };
            $scope.storyDetails = function (storyId) {
                storyService.getStoryDetails(storyId).then(function (result) {
                    $responsHandler.handle(result.data, function () {
                        $scope.current = result.data.Data;
                        angular.element("#storyDetailsModal").modal({
                            backdrop: 'static',
                            keyboard: true
                        }, 'show');
                    });
                }, $responsHandler.handle);
            };
        }])
        .controller('storyController', ['$scope', '$filter', '$timeout', '$q', '$responsHandler', 'appSettings', 'storyService', 'groupService', function ($scope, $filter, $timeout, $q, $responsHandler, appSettings, storyService, groupService) {
            $scope.tags = [];
            $scope.current = {};
            $scope.showValidationErrors = false;
            $scope.isLoading = false;

            $timeout(function () {
                storyService.getStoryDetails(storyId).then(function (result) {
                    $responsHandler.handle(result.data, function () {
                        $scope.current = result.data.Data;
                        $scope.tags = $scope.current.Groups;
                    });
                }, $responsHandler.handle);

            }, 0);
            $scope.loadGroups = function ($query) {
                var deferred = $q.defer();
                groupService.searchGroups($query).then(function (result) {
                    $responsHandler.handle(result.data, function () {
                        deferred.resolve(result.data.Data);
                    });
                }, $responsHandler.handle);

                return deferred.promise;
            };

            $scope.saveStory = function (isValid) {
                if (!isValid || $scope.tags.length == 0) {
                    $scope.showValidationErrors = true;
                    return;
                }
                $scope.isLoading = true;
                $scope.current.Groups = $scope.tags;
                storyService.saveStory($scope.current).then(function (result) {
                   
                    $responsHandler.handle(result.data, function () {
                        $scope.isLoading = false;
                        toastr.info('Saved successfully', 'Info');
                        storyId = result.data.Data;
                        $scope.showValidationErrors = false;
                    });
                }, $responsHandler.handle);

            };


        }]);

})();