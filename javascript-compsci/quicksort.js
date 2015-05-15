function quickSort(items, left, right){
	if (left < right){
		var p = partition(items, left, right);
		quickSort(items, left, p-1);
		quickSort(items, p+1, right);
	}
}


function partition(items, left, right){
	var pivotIndex = Math.floor((left+right)/2);
	var pivotValue = items[pivotIndex];
	var i = left;
	var j = right;
	while (i <= j){
		while (items[i] < pivotValue)
			i++;

		while (items[j] > pivotValue)
			j--;
	}

	if (i <= j){
		swap(items, i, j);

		i++;
		j--;
	}
}

function swap(items, i, j){
	var temp = items[i];
	items[i] = items[j];
	items[j] = temp;
}

quickSort([6,3,1,1,7,93,10,4,5,8]);
