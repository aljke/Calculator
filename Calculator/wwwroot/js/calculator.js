var isCalculated = false;

function buttonPressed(id) {
    document.calc.result.value += id;
}

// Clears calculator input screen
function clearScreen() {
    document.calc.result.value = "";
}

// Calculates input values
function calculate() {
    var input = document.calc.result.value;
    if ((input.length > 0) && (input !== "Error")) {
        var res;
        try {
            res = eval(input);
            document.calc.result.value = res;
        } catch (err) {
            document.calc.result.value = "Error";
            res = "Unhandled error";
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