var testApp = angular.module('testApp', []);

testApp.controller('AddController', ['$scope', function($scope){
    $scope.result = null;
    $scope.add = function(x, y)
    {
        console.assert(x, 'x should not be undefined');
        console.assert(y, 'y should not be undefined');
        $scope.result = parseInt(x) + parseInt(y);
    }
}]);