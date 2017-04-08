using Microsoft.EntityFrameworkCore;

namespace Calculator.Model
{
    /// <summary>
    /// Класс для работы с данными средствами EF.
    /// </summary>
    public class CalculatorContext : DbContext
    {
        public CalculatorContext(DbContextOptions<CalculatorContext> options)
            : base(options)
        {
        }

        // У нас только одна таблица
        public DbSet<OperationResult> Results { get; set; }
    }
}
