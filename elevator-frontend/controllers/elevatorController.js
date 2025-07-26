angular.module('elevatorApp')
  .controller('ElevatorController', ['$scope', 'ElevatorService', function($scope, ElevatorService) {
    $scope.floor = 0;
    $scope.status = {};

    $scope.callElevator = function() {
      ElevatorService.call($scope.floor).then(loadStatus);
    };

    $scope.start = function() {
      ElevatorService.start().then(loadStatus);
    };

    $scope.stop = function() {
      ElevatorService.stop().then(loadStatus);
    };

    $scope.openDoors = function() {
      ElevatorService.openDoors().then(loadStatus);
    };

    $scope.closeDoors = function() {
      ElevatorService.closeDoors().then(status);
    };

    function loadStatus() {
      ElevatorService.getStatus().then(function(response) {
        $scope.status = response.data;
      });
    }

    $scope.$on('elevatorStatusUpdated', function (event, status) {
    $scope.status = status;
    $scope.$apply();
});

    loadStatus();
  }]);
