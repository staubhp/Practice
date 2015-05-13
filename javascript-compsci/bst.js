function Node(val){
	this.value = val;
	this.left = null;
	this.right = null
}

function BinarySearchTree(){
	this._root= null;
}

BinarySearchTree.prototype = {
	add: function(value){
		  if (this._root == null){
			    this._root = new Node(value);
		  }
		  else{
			    var current = this._root;
			    while (true){
					if (current.value > value){
						  if (current.left == null){
							    current.left = new Node(value);
							    break;
						  }
						  else{
							    current = current.left;
						  }
					}
					else if (current.value < value){
						  if (current.right == null){
							    current.right = new Node(value);
							    break;
						  }
						  else{
							    current = current.right;
						  }
					}			  
			    }
		  }
	},
	contains: function(value){
		  if (this._root == null)
			    return false;

		  var current = this._root;
		  while (true){
			    if (current.value == value)
					return true;

			    if (current.value > value){
					if (current.left == null){
						  return false;
					}
					else{
						  current = current.left;
					}
			    }
			    else if (current.value < value){
					if (current.right == null){
						  return false;
					}
					else{
						  current = current.right;
					}
			    }
		  }

	},
	remove: function(value){}
}



var bst = new BinarySearchTree;
var root = new Node(8);

