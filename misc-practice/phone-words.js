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

var _input = "7516"; //PLAN, SLAM, etc

function getPossibleWords(input){
	var splinput = input.split('');
	for (var i = 0; i<splinput.length; i++){
		var chars = numberToChars[splinput[i]];
		buildPossibleWords(chars, "");

	}
}

function buildPossibleWords(chars, currentWord){

}

