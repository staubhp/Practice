//Given an array of integers, find the largest increasing subsequence of integers in the array.
//Input: [10, 3, 7, 9, 0, 15]
//Output: 1 & 3 (indices)


var inputArray = [10, 3, 7, 9, 0, 15];
var result = {
	startIndex:0,
	endIndex:-1,
	length: function(){
		return this.endIndex - this.startIndex;
	}
}

function getLargestSubsequence(arr){
debugger;
	var startIndex = 0;
	var endIndex = -1;
	
	//for each int
	//if next int > current int, set endindex = i+1
	//if endindex-startindex > result.length, result.start = startindex, result.end = endindex
	for (var i = 0; i<arr.length; i++){
		if (i != arr.length-1 && arr[i] < arr[i+1]){
			   endIndex = i+1;
		}
		else{
			   startIndex = i+1;
			   endIndex = -1;
		}


		if (endIndex-startIndex > result.length()){
			   result.endIndex = endIndex;
			   result.startIndex = startIndex;
		}
	}
		
	return result;
}

var largestSubsequence = getLargestSubsequence(inputArray);
alert("Start: " + largestSubsequence.startIndex+", End: " + largestSubsequence.endIndex);
