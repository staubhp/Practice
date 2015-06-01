//Generate all combinations of football scores that add up to 21
//Possible football scores: 6,1,2,3

var _scorePool = [6,7,2,3];
var _scoreCombinations = [];

function getScores(index, currentScore, currentCombination){
	if (currentScore == 21){
		_scoreCombinations.push(currentCombination);
		console.log(currentCombination);
		return;
	}

	if (index == _scorePool.length){
		return;
	}

	if (currentScore > 21){
		return;
	}


	for (var i = index; i<_scorePool.length; i++){
		getScores(index, currentScore+_scorePool[i], currentCombination.concat(_scorePool[i]));
	}
}

debugger;
getScores(0, 0, []);


