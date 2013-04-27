//Write script that asks for a digit and depending on the input shows the 
//name of that digit (in English) using a switch statement.

function SolveQuadraticExpression() {
    var number = parseInt(document.getElementById("number").value);

    if (number > 99) {
        console.log("The number is: " + ProvideHundreds(number), ProvideTens(number), ProvideOnes(number));
    }
    else if (number > 20 && number < 100) {
        console.log("The number is: " + ProvideTens(number) + ProvideOnes(number));
    }
    else if (number < 20 && number != 0) {
        console.log("The number is: " + ProvideOnes(number));
    }
    else if (number == 0) {
        console.log("The number is: 0");
    }
}

function ProvideOnes(number) {
    var result;
    var resultAsNumber = parseInt(number % 100);
    var andConnection = "";
    if (number > 20) {
        var andConnection = " and ";
    }
    if (resultAsNumber < 10 || resultAsNumber > 20) {
        resultAsNumber = parseInt(number % 10);
        switch (resultAsNumber) {
            case 1: result = " one"; break;
            case 2: result = " two"; break;
            case 3: result = " three"; break;
            case 4: result = " four"; break;
            case 5: result = " five"; break;
            case 6: result = " six"; break;
            case 7: result = " seven"; break;
            case 8: result = " eight"; break;
            case 9: result = " nine"; break;
            default: result = ""; break;
        }
        return result;
    }

    else {
        switch (resultAsNumber) {
            case 10: result = andConnection + "ten"; break;
            case 11: result = andConnection + "eleven"; break;
            case 12: result = andConnection + "twelve"; break;
            case 13: result = andConnection + "thirtheen"; break;
            case 14: result = andConnection + "fourtheen"; break;
            case 15: result = andConnection + "fiftheen"; break;
            case 16: result = andConnection + "sixtheen"; break;
            case 17: result = andConnection + "seventeen"; break;
            case 18: result = andConnection + "eighteen"; break;
            case 19: result = andConnection + "nineteen"; break;
            default: result = ""; break;
        }
        return result;
    }
}

function ProvideTens(number) {
    var result = parseInt(number / 10);
    var resultAsNumber = parseInt(result % 10);
    if (resultAsNumber == 0) {
        result = " and";
    }
    else {
        switch (resultAsNumber) {
            case 2: result = " twenty"; break;
            case 3: result = " thirthy"; break;
            case 4: result = " forty"; break;
            case 5: result = " fifty"; break;
            case 6: result = " sixty"; break;
            case 7: result = " seventhy"; break;
            case 8: result = " eighty"; break;
            case 9: result = " ninety"; break;
            default: result = ""; break;
        }
    }
    return result;
}

function ProvideHundreds(number) {
    var hundreds = "";
    var result = parseInt(number / 100);
    switch (result) {
        case 1: hundreds = "One hundred"; break;
        case 2: hundreds = "Two hundred"; break;
        case 3: hundreds = "Three hundred"; break;
        case 4: hundreds = "Four hundred"; break;
        case 5: hundreds = "Five hundred"; break;
        case 6: hundreds = "Six hundred"; break;
        case 7: hundreds = "Seven hundred"; break;
        case 8: hundreds = "Eight hundred"; break;
        case 9: hundreds = "Nine hundred"; break;
        default: hundreds = ""; break;
    }
    return hundreds;
}

