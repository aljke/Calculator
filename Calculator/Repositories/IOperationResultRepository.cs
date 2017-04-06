using Calculator.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Repositories
{
    public interface IOperationResultRepository
    {
        void Add(OperationResult result);
        IEnumerable<OperationResult> GetAll();
    }
}
