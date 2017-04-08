using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Model
{
    /// <summary>
    /// Сущность для работы с таблицей БД.
    /// </summary>
    public class OperationResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime Time { get; set; }
        public string Operation { get; set; }
        [Required]
        public string Result { get; set; }
    }
}
