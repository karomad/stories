(function () {
    'use strict';
    angular
        .module('myapp')
        .factory('groupService', ['$http', 'appSettings', function ($http, appSettings) {
            var service = {};
            var _loadGroups = function (first, pagesize) {
                return $http.get(appSettings.BaseUrl + 'Group/GetAllGroups?first=' + first + '&pagesize=' + pagesize).then(function (result) {
                    return result;
                });
            };
            var _joinOrLeaveGroup = function (groupId, join) {
                return $http.post(appSettings.BaseUrl + 'Group/joinOrLeaveGroup?groupId=' + groupId + '&join=' + join).then(function (result) {
                    return result;
                });
            };
            var _saveGroup = function (group) {
                return $http.post(appSettings.BaseUrl + 'Group/SaveGroup', group).then(function (result) {
                    return result;
                });
            };
            var _searchGroups = function (searchText) {
                return $http.get(appSettings.BaseUrl + 'Group/SearchGroups?searchText=' +  searchText).then(function (result) {
                    return result;
                });
            };

            service.loadGroups = _loadGroups;
            service.joinOrLeaveGroup = _joinOrLeaveGroup;
            service.saveGroup = _saveGroup;
            service.searchGroups = _searchGroups;
            return service;
        }]);
})();