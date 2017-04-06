using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.Model;

namespace Calculator.Repositories
{
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

        public IEnumerable<OperationResult> GetAll()
        {
            return _context.Results.ToList();
        }
    }
}
