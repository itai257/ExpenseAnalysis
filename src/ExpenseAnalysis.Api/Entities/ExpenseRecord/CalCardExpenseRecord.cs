using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseAnalysis.Api.Entities.ExpenseRecord;

[Table("CalCardExpenseRecords")]
public class CalCardExpenseRecord : BaseCardExpenseRecord
{
    /// <summary>
    /// The branch or industry (corresponds to "ענף").
    /// </summary>
    [StringLength(100)]
    public string Branch { get; set; } = string.Empty;
}