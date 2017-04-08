
//Когда будет нажана кнопка "=", буде выведен результат. Мы хотим запретить вводить цифры к результату,
//а только позволим вводить операции после вычисленного результата. После операции можно уже вводить цифры.
//Для этого определяем флаг нажатия кнопки "=".
var isCalculated = false;

//Обработчик клиуков цифр и операций
function buttonPressed(char) {
    //Если была нажата кнопка "="
    if (isCalculated) {
        //позволяем добавлять в поле ввода только символы операций (и не позволяем цифры и точку)
        if (!isNumeric(char) && (char !== '.')) {
            document.calc.result.value += char;
            isCalculated = false; //и сбрасываем флаг после ввода любой операции
        } 
    } else  //Если же кнопка "=" не была нажата, вводим что угодно в поле калькулятора
        document.calc.result.value += char;
}

//Обработчик клика очищения поля калькулятора
function clearScreen() {
    isCalculated = false; //флаг нажатия "=" надо сбросить, иначе в некоторых ситуациях не сможем вводить цифры в пустое поле ввода
    document.calc.result.value = "";
}

//Обработчик клика кнопки "="
function calculate() {
    isCalculated = true;  //устанавливаем флаг нажатия кнопки "="
    var input = document.calc.result.value;
    if (input.length > 0 ) { //будем вычислять результат, только если поле ввода не пустое
        var res;
        try {
            res = eval(input); //вычисления результата. Стандартная функция js
            document.calc.result.value = res; //результат на поле калькулятора
        } catch (err) { // если в процессе вычисления получаем ошибку, сообщаем об этом в поле ввода.
            document.calc.result.value = "Error!";
            res = "Unhandled error"; //а это сообщение заносим в БД в качестве результата вычисления
            input = null; //в качестве выражения в БД внесётся NULL
        }
        insertDB(input, res); // вызов самой вставки в БД
    }
}

//ajax-запрос вызовёт вставку в БД как экшн контроллера
//передаём ему параметрами выражение и результат вычисления
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

//регулярным выражениеми проверяем, является ли символ цифрой. 
function isNumeric(str) {
    return /^\d+$/.test(str);
}
