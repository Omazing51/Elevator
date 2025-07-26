angular.module('elevatorApp')
  .service('ElevatorService', ['$http', function($http) {
    const API_URL = 'http://localhost:5185/api/elevator';

    this.call = function(floor) {
      return $http.post(`${API_URL}/call`, floor);
    };

    this.start = function() {
      return $http.post(`${API_URL}/start`);
    };

    this.stop = function() {
      return $http.post(`${API_URL}/stop`);
    };

    this.openDoors = function() {
      return $http.post(`${API_URL}/open-doors`);
    };

    this.closeDoors = function() {
      return $http.post(`${API_URL}/close-doors`);
    };

    this.getStatus = function() {
      return $http.get(`${API_URL}/status`);
    };
  }]);
