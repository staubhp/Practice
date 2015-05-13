function merge(left, right){
	var i=0, j =0;
	var result = [];
	while (i < left.length && j < right.length){
		if (left[i] < right[j])
			result.push(left[i++]);
		else
			result.push(right[j++]);
	}

	return result.concat(left.slice(i)).concat(right.slice(j));
}

function mergeSort(input){
	if (input.length < 2)
		return input;

	var mid = Math.floor(input.length/2);
	var left = input.slice(0, mid);
	var right = input.slice(mid);

	return merge(mergeSort(left), mergeSort(right));

}


alert(mergeSort([6,2,1,1,9,3]));
