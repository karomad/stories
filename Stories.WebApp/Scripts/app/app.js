(function () {
    'use strict';

    angular.module('myapp', ['ngRoute', 'ngTagsInput', 'angularMoment', 'angular-ladda'])

      .constant('appSettings', {
          BaseUrl: 'http://localhost:3848/',
      })
    .config(['$httpProvider', function ($httpProvider) {
        $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
    }]);

})();