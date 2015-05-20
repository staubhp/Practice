//Given an array A of integers and an integer value M, find two integers from A whose sum is M.

var A = [1,4,2,10,9,5,6,2,0];

function findSum(A, M){
	var found = false;
	var i = 0, j = 0;
	for (i = 0; i < A.length; i++){
		for (j = 0; j < A.length; j++){
			if (i != j && (A[i]+A[j] == M))
			{
				found = true; 
				break;
			}

		}
		if (found)
			break;
	}

	if (found)
		alert("Elements " + A[i] + " and " + A[j] + " sum up to " + M);
	else
		alert("No elements were found that sum up to " + M);
}

