//1, 11, 21, 1211, 111221, 312211, 13112221

var sequence = [];
sequence.push("1");
function generateLookSaySeq(n, iter){
	var charArray = n.split('');
	var currentNumber = charArray[0];
	var occurences = 1;
	var outputString = "";
	for(var i = 1; i < charArray.length; i++){
		if (currentNumber == charArray[i]){
			occurences++;
		}	
		else{
			outputString += occurences.toString() + currentNumber;
			occurences = 1;
			currentNumber = charArray[i];
		}
	}

	outputString += occurences.toString() + currentNumber;

	sequence.push(outputString);

	if (iter >= 20)
		return;

	iter++;
	generateLookSaySeq(outputString, iter);
}

generateLookSaySeq("1", 1);

