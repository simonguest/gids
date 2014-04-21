var TodoService = function ($log){
	
	this.getCategory = function(){
		return 'sample category';
	};
};
app.service('TodoService', TodoService);