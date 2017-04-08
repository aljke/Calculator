using Calculator.Model;
using Calculator.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;

namespace Calculator.Controllers
{
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

        [HttpPost]
        public IActionResult InsertDB([FromBody]JToken jsonbody)
        {
            var expression = jsonbody.Value<string>("expression");
            var result = jsonbody.Value<string>("result");
            var row = new OperationResult
            {
                Time = DateTime.UtcNow,
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