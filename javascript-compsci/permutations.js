//Generate all permutations of [1,2,3]
//e.g., (1,2,3),(3,2,1),(2,1,3)...


function getPermutations(input, currentPerm){

	if (input.length == 0){
		console.log(currentPerm);
		return;
	}

	for (var i = 0; i<input.length; i++){
		var cloned = input.slice(0); 
		var subject = cloned.splice(i,1)[0];
		getPermutations(cloned, currentPerm.concat(subject));
	}

}

debugger;
getPermutations([1,2,3],[]);
