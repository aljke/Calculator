var isCalculated = false;

function buttonPressed(char) {
    if (isCalculated) {
        if (!isNumeric(char) && (char !== '.')) {
            document.calc.result.value += char;
            isCalculated = false;
        } 
    } else  
        document.calc.result.value += char;
}

// Clears calculator input screen
function clearScreen() {
    isCalculated = false;
    document.calc.result.value = "";
}

// Calculates input values
function calculate() {
    isCalculated = true;
    var input = document.calc.result.value;
    if (input.length) {
        var res;
        try {
            res = eval(input);
            document.calc.result.value = res;
        } catch (err) {
            document.calc.result.value = "Error!";
            res = "Unhandled error";
            input = null;
        }
        insertDB(input, res);
    }
}

function insertDB(exp, res) {
    $.ajax({
        type: "POST",
        url: ajaxUrl,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({expression : exp, result : res}),
        dataType: "JSON",
        success: function (data) {
        },
        error: function (x, e) {
        }
    });
}

function isNumeric(str) {
    return /^\d+$/.test(str);
}
