using Calculator.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Repositories
{
    /// <summary>
    /// Интерфейсная переменная репозитория позволяет абстрагироваться от 
    /// работы с конкретным поставщиком данных. Нам нужны только 2 операции в данном приложении.
    /// </summary>
    public interface IOperationResultRepository
    {
        void Add(OperationResult result);
        /// <summary>
        /// Для возвращаемого значения лучше использовать как можно более точный тип, а не базовый.
        /// Потому List, а не IEnumerable.
        /// </summary>
        /// <returns></returns>
        List<OperationResult> GetAll();
    }
}
