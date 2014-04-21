app.directive('todoItem', [ 'TodoService', function(TodoService){
	return {
	    restrict: 'E',
		templateUrl:'templates/todoItemTemplate.html'
	};
}]);