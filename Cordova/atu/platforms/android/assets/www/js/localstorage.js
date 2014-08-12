
var ls = {
	set: function(key, obj){
		localStorage.setItem(key, obj);
	},

	get: function(key){
		return localStorage.getItem(key);		
	}
};