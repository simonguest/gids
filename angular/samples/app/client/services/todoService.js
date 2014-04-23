var TodoService = function ($log){

	this.todos = [
	{text:'learn angular', done:true},
	{text:'build an angular app', done:false}];
	
	this.getCategory = function(){
		return 'sample category';
	};
};
app.service('TodoService', TodoService);