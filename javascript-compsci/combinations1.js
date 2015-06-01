//Given 6 balls numbered 1-6, you can only choose 4 balls at a time
//Generate all combinations of 4 balls

var balls = [1,2,3,4,5,6];
var combinations = [];

var getCombinations = function(currentBalls, index){
	if (currentBalls.length == 4){
		combinations.push(currentBalls);
		console.log(currentBalls);
		return;
	}else{
		for (var i = index; i<balls.length; i++){
			getCombinations(currentBalls.concat(balls[i]), i+1);
		}
	}
}

debugger;
getCombinations([], 0);
