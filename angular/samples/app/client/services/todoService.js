var TodoService = function ($log){

  var logger = $log.getInstance("TodoService");
  logger.log("I am in the service");

	this.todos = [
	{text:'learn angular', done:true},
	{text:'build an angular app', done:false}];
	
	this.getCategory = function(){
		return 'sample category';
	};
};
app.service('TodoService', TodoService);