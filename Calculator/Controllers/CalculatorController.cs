using Calculator.Model;
using Calculator.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;

namespace Calculator.Controllers
{
    /// <summary>
    /// В контроллере экшены возвращают главную вьюху с калькулятором и вьюху с результатами.
    /// Еще один метод вызывается через ajax для вставки записей в таблицу БД.
    /// </summary>
    public class CalculatorController : Controller
    {
        private readonly IOperationResultRepository _repository;

        public CalculatorController(IOperationResultRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Метод принимает данные с клиента в формате json парсит их для получения значений для вставки в БД.
        /// </summary>
        /// <param name="jsonbody">Данные из клиента (выражения и результат вычисления).</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertDB([FromBody]JToken jsonbody)
        {
            var expression = jsonbody.Value<string>("expression");
            var result = jsonbody.Value<string>("result");
            var row = new OperationResult
            {
                Time = DateTime.UtcNow, //Время UTC позволит корректно отображать его могласно локальному времени клиента
                Operation = expression,
                Result = result
            };
            _repository.Add(row);
            return NoContent();
        }

        public IActionResult Results()
        {
            var model = _repository.GetAll();
            return View(model);
        }
    }
}