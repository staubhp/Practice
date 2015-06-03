//A phone's number pad has letters under each number
//Given a string of numbers (e.g., '112') return all of the possible words that correspond to those numbers (e.g., 'ABE')


var numberToChars={
	1:[],
	2:['A','B','C'],
	3:['D','E','F'],
	4:['G','H','I'],
	5:['J','K','L'],
	6:['M','N','O'],
	7:['P','Q','R','S'],
	8:['T','U','V'],
	9:['W','X','Y','Z']
}

var _input = "7526"; //PLAN, SLAM, etc

function getPossibleWords(input){
	var splinput = input.split('');
	var charArrays = [];
	for (var i = 0; i<splinput.length; i++){
		charArrays.push(numberToChars[splinput[i]]);
	}
	buildPossibleWords(charArrays, "", 0);
}

function buildPossibleWords(charArrays, currentWord, index){
	if (index >= charArrays.length){
		console.log(currentWord);
		return;
	}

	for(var j = 0; j<charArrays[index].length; j++){
		buildPossibleWords(charArrays, currentWord + charArrays[index][j], index+1);
	}
}


getPossibleWords(_input);
