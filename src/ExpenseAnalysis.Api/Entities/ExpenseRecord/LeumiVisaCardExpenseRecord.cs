using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseAnalysis.Api.Entities.ExpenseRecord;

[Table("LeumiVisaCardExpenseRecords")]
public class LeumiVisaCardExpenseRecord : BaseCardExpenseRecord
{
    /// <summary>
    /// Additional details (corresponds to "פרטים").
    /// </summary>
    [StringLength(500)]
    public string Details { get; set; } = string.Empty; // TODO: Can fit Note from baseclass?
}