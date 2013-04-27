function StartTest() {
    var args = [
        "def func sum[5, 3, 7, 2, 6, 3]",
        "def func2 [5, 3, 7, 2, 6, 3]",
        "def func3 min[func2]",
        "def func4 max[5, 3, 7, 2, 6, 3]",
        "def func5 avg[5, 3, 7, 2, 6, 3]",
        "def func6 max[func2, func3, func4 ]",
        "sum [func6, func4]"];
    console.log(Solve(args));
}

function Solve(args) {
    var commands = new Array();
    var result = 0;
    var allCommands = new Array();
    for (var i = 0; i < args.length; i++) {
        commands.push(args[i]);
    }
    for (var row in commands) {
        var command = commands[row] + "";
        if (StartsWith(command, 'def')) {
            var indexOfOpenBracket = command.indexOf('[');
            var indexOfCloseBracket = command.indexOf(']');
            var indexOfFirstSpace = command.indexOf(' ');
            var funcContent = command.substring(indexOfFirstSpace, indexOfOpenBracket);
            funcContent = funcContent.trim();
            funcContent = funcContent.split(' ');
            var funcName = funcContent[0];
            if (funcContent.length > 1) {
                var funcAction = funcContent[1];
            }
            var arrayContent = command.substring(indexOfOpenBracket + 1, indexOfCloseBracket);
            arrayContent = arrayContent.trim();
            arrayContent = arrayContent.split(', ');
            for (var i = 0; i < arrayContent.length; i++) {
                if (isNaN(arrayContent[i])) {
                    continue;
                }
                arrayContent[i] = parseInt(arrayContent[i]);
            }
            allCommands.push({
                Name: funcName,
                Content: arrayContent,
                Action: funcAction
            });
        }
    }
    for (var i = 0; i < allCommands.length; i++) {
        var tempArray = new Array();
        for (var j = 0; j < allCommands[i].Content.length; j++) {
            if (isNaN(allCommands[i].Content[j])) {
                var name = allCommands[i].Content[j];
                for (var k = 0; k < allCommands.length; k++) {
                    if (allCommands[k].Name == name) {
                        tempArray.push(allCommands[k].Content);
                    }
                }
            }
            else {
                tempArray.push(allCommands[i].Content[j]);
            }
            for (var j = 0; j < tempArray.length; j++) {
                allCommands[i].Content[j] = tempArray[j];
            }
        }
    }
    for (var i = 0; i < allCommands.length; i++) {
        if (allCommands[i].Action == 'sum') {
            result = CalculateSum(allCommands[i].Content)
        }
        else if (allCommands[i].Action == 'max') {
            result = CalculateMax(allCommands[i].Content)
        }
        else if (allCommands[i].Action == 'min') {
            result = CalculateMin(allCommands[i].Content)
        }
        else if (allCommands[i].Action == 'avg') {
            result = CalculateAverage(allCommands[i].Content)
        }
    }
    return result;
}

function CalculateAverage(array) {
    var average = parseInt(CalculateSum(array) / array.length);
    return average;
}

function CalculateMin(array) {
    var min = array[0];
    for (var i = 0; i < array.length; i++) {
        if (min > array[i]) {
            min = array[i];
        }
    }
    return min;
}

function CalculateMax(array) {
    var max = array[0];
    for (var i = 0; i < array.length; i++) {
        if (max < array[i]) {
            max = array[i];
        }
    }
    return max;
}

function CalculateSum(array) {
    var sum = 0;
    for (var i = 0; i < array.length; i++) {
        sum += array[i];
    }
    return sum;
}

function StartsWith(text, value) {
    text = text + "";
    value = value + "";
    var startsWith = true;
    for (var i = 0; i < value.length; i++) {
        if (value.charAt(i) != text.charAt(i)) {
            return false;
        }
    }
    return true;
}
