var input = [5,2,1,6,7,10,1,0];

function selectionSort(input, sortedUpTo){
	var smallest;
	var smallestIndex = -1;
	for (var i = sortedUpTo+1; i<input.length; i++){
		if (!smallest || input[i] < smallest){
			smallest = input[i];
			smallestIndex = i;
		}

	}

	//swap
	sortedUpTo++;
	var temp = input[sortedUpTo];
	input[sortedUpTo] = smallest;
	input[smallestIndex] = temp;

	if (sortedUpTo == input.length-1)
		return input;

	return selectionSort(input, sortedUpTo);
}

var output = selectionSort(input, -1);
alert(output);
