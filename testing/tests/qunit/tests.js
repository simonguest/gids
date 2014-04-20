var injector = angular.injector(['ng', 'testApp']);

module('Math tests', {
    setup: function () {
        this.$scope = injector.get('$rootScope').$new();
        var $controller = injector.get('$controller');
        $controller('AddController', {
            $scope: this.$scope
        });
    }});

test('Adds two numbers correctly', function () {
    this.$scope.add(12, 13);
    equal(this.$scope.result, 25, "Should add these two numbers correctly");
});

test('Handles non-integer values correctly', function () {
    this.$scope.add(12, 'ABC');
    deepEqual(this.$scope.result, NaN, "Should return NaN on non-integer input");
});