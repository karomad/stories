(function () {
    'use strict';

    angular.module('appLogin', ['ngRoute', 'angular-ladda'])

      .constant('appSettings', {
          BaseUrl: 'http://localhost:3848/',
      })
    .config(['$httpProvider', function ($httpProvider) {
        $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
    }]);

})();