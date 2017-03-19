
(function () {
    'use strict';

    angular
        .module('myapp')
        .controller('signalrController', ['$scope', function ($scope) {
            var notificationFactory = jQuery.connection.notificationHub;
            notificationFactory.client.notify = function (message) {
                toastr.options = {
                    "positionClass": "toast-bottom-right",
                    "closeButton": true,
                }
                toastr.info(message.Body, message.FromUser);
            };
            jQuery.connection.hub.start().done(function () {
                notificationFactory.server.register(currentUserId);
            });
        }]);

})();
