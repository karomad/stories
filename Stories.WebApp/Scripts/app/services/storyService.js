(function () {
    'use strict';
    angular
        .module('myapp')
        .factory('storyService', ['$http', 'appSettings', function ($http, appSettings) {
            var service = {};
            var _loadStories = function (first, pagesize) {
                return $http.get(appSettings.BaseUrl + 'Story/GetUserStories?first=' + first + '&pagesize=' + pagesize).then(function (result) {
                    return result;
                });
            };
            var _getStoryDetails = function (storyId) {
                return $http.get(appSettings.BaseUrl + 'Story/GetStoryDetails?storyId=' + storyId).then(function (result) {
                    return result;
                });
            };
            var _saveStory = function (data) {
                return $http.post(appSettings.BaseUrl + 'Story/SaveStory', data).then(function (result) {
                    return result;
                });
            };
            service.loadStories = _loadStories;
            service.getStoryDetails = _getStoryDetails;
            service.saveStory = _saveStory;

            return service;
        }]);
})();