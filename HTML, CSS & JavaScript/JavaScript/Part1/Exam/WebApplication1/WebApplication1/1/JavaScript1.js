function StartTest() {
    var args = [8, 1, 6, -9, 4, 4, -2, 10, -1];
    //var args = [6, 1, 3, -5, 8, 7, -6];
    //var args = [9, -9, -8, -8, -7, -6, -5, -1, -7, -6];
    console.log(Solve(args));
}

function Solve(args) {
    var numbers = new Array(args.length);
    var numbersLenght = numbers.length;
    var i = 0;
    var maxSum = 0;
    var currentSum = 0;
    for (i = 0; i < numbersLenght; i++) {
        numbers[i] = parseInt(args[i]);
    }

    for (i = 0; i < numbersLenght; i++) {
        for (var j = i; j < numbersLenght; j++) {
            {
                currentSum += numbers[j];
                if (currentSum > maxSum) {
                    maxSum = currentSum;
                }
            }
        }
        currentSum = 0;
    }
    return maxSum;
}