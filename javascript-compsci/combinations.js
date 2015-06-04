//Generate all combinations of football scores that add up to 21
//Possible football scores: 6,7,2,3

var _scorePool = [6,7,2,3];
var _scoreCombinations = [];


function getScores(currentScore, currentCombination){
	if (currentScore == 21){
		debugger;
		var sorted = currentCombination.sort().toString();
		if (_scoreCombinations.indexOf(sorted) < 0){
			_scoreCombinations.push(sorted);
			console.log(currentCombination);
		}
		return;
	}

//	if (index == _scorePool.length){
//		return;
//	}

	if (currentScore > 21){
		return;
	}


	for (var i = 0; i<_scorePool.length; i++){
		getScores(currentScore+_scorePool[i], currentCombination.concat(_scorePool[i]));
	}
}

debugger;
getScores(0, []);
alert(_scoreCombinations.length + " combos found");


