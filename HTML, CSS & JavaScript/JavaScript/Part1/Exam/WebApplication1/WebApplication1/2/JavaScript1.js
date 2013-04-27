function StartTest() {
    //var args = ["3 4", "1 3", "lrrd", "dlll", "rddd"];
    //var args = ["5 8", "0 0", "rrrrrrrd", "rludulrd", "durlddud", "urrrldud", "ulllllll"];
    var args = ["5 8", "0 0", "rrrrrrrd", "rludulrd", "lurlddud", "urrrldud", "ulllllll"];
    console.log(Solve(args));
}

function Solve(args) {
    var size = args[0].split(' ');
    var N = size[0];
    var M = size[1];
    var startPossition = args[1].split(' ');
    var startRow = startPossition[0];
    var startCol = startPossition[1];
    var arrayWithValues = new Array();
    var counter = 1;
    var row = 0;
    var col = 0;
    var currentPossitionRow = startRow;
    var currentPossitionCol = startCol;
    var sum = 0;
    var path = 0;
    var isLost = false;
    for (row = 0; row < N; row++) {
        arrayWithValues[row] = []
        for (col = 0; col < M; col++) {
            arrayWithValues[row][col] = counter;
            counter++;
        }
    }
    var arrayWithDirections = new Array();
    for (row = 0; row < N; row++) {
        var directions = args[2 + row] + "";
        arrayWithDirections[row] = [];
        for (var col = 0; col < M; col++) {
            arrayWithDirections[row][col] = directions.charAt(col);
        }
    }
    while (true) {
        var movement = arrayWithDirections[currentPossitionRow][currentPossitionCol];
        arrayWithDirections[currentPossitionRow][currentPossitionCol] = 'o';
        sum += arrayWithValues[currentPossitionRow][currentPossitionCol];

        switch (movement) {
            case 'l': currentPossitionCol--; break;
            case 'r': currentPossitionCol++; break;
            case 'u': currentPossitionRow--; break;
            case 'd': currentPossitionRow++; break;
            case 'o': isLost = true; break;
        }
        if (isLost == false) {
            if (currentPossitionCol < 0 || currentPossitionCol >= M || currentPossitionRow < 0 || currentPossitionRow >= N) {
                return "out " + sum;
            }
            path++;
        }
        else {
            path++;
            return "lost " + path;
            break;
        }
    }
}
