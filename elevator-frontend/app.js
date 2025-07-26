angular.module('elevatorApp', []);

setInterval(function () {
    elevatorService.getStatus().then(function (response) {
        $rootScope.$broadcast('elevatorStatusUpdated', response.data);
    });
}, 5000);