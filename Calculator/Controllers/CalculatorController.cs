using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Calculator.Repositories;
using Calculator.Model;
using Newtonsoft.Json.Linq;

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
                Time = DateTime.Now,
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