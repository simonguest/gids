function TodoController($scope, $log, TodoService) {

  $scope.todos = [
    {text:'learn angular', done:true},
    {text:'build an angular app', done:false}];

  // $scope.$watchCollection('todos', function(newTodos){
  //   $log.log('todos has been updated');
  //   for (var f=0; f<newTodos.length; f++){
  //     newTodos[f].category = $scope.getCategory(newTodos[f]);
  //   }
  //   $scope.todos = newTodos;
  // });
 
  $scope.addTodo = function() {
    $scope.todos.push({text:$scope.todoText, done:false});
    $scope.todoText = '';
  };
 
  $scope.remaining = function() {
    var count = 0;
    angular.forEach($scope.todos, function(todo) {
      count += todo.done ? 0 : 1;
    });
    return count;
  };
 
  $scope.archive = function() {
    var oldTodos = $scope.todos;
    $scope.todos = [];
    angular.forEach(oldTodos, function(todo) {
      if (!todo.done) $scope.todos.push(todo);
    });
  };

  $scope.getCategory = function(todo) {
    $log.log('getCategory function was called');
    return TodoService.getCategory(todo);
  };
}