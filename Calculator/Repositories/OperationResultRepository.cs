using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.Model;

namespace Calculator.Repositories
{
    /// <summary>
    /// Класс реализует IOperationResultRepository. Класс работает с данными средствами EF.
    /// OperationResultRepository будет подставляться через DI в переменные типа IOperationResultRepository.
    /// </summary>
    public class OperationResultRepository : IOperationResultRepository
    {
        private readonly CalculatorContext _context;

        public OperationResultRepository(CalculatorContext context)
        {
            _context = context;
        }

        public void Add(OperationResult result)
        {
            _context.Results.Add(result);
            _context.SaveChanges();
        }

        public List<OperationResult> GetAll()
        {
            return _context.Results.ToList();
        }
    }
}
