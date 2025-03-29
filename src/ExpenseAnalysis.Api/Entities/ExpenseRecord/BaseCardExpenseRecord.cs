using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseAnalysis.Api.Entities.ExpenseRecord;

// Base class with common properties for an expense record.
public abstract class BaseCardExpenseRecord
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// The date of the transaction.
    /// For Cal and Leumi Visa this corresponds to the provided date field.
    /// For Osh, this is the primary transaction date.
    /// </summary>
    [Required]
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// Business or vendor name.
    /// For Cal and Leumi Visa, this is the business name.
    /// For Osh, this property may remain unused.
    /// </summary>
    [StringLength(255)]
    public string BusinessName { get; set; } = string.Empty;

    /// <summary>
    /// The amount of the transaction (e.g. "סכום עסקה" or "סכום העסקה").
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal? TransactionAmount { get; set; }

    /// <summary>
    /// The charged amount (e.g. "סכום חיוב").
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal? ChargeAmount { get; set; }

    /// <summary>
    /// The type of transaction (e.g. "סוג עסקה").
    /// </summary>
    [StringLength(100)]
    public string TransactionType { get; set; } = string.Empty;

    /// <summary>
    /// A note or remark (e.g. "הערות"/"הערה").
    /// </summary>
    [StringLength(500)]
    public string Note { get; set; } = string.Empty;
    
    // Foreign key for ExpenseTypeClass
    public int? TypeClassId { get; set; }
    
    // Navigation property with ForeignKey attribute
    [ForeignKey("TypeClassId")]
    public virtual ExpenseTypeClass? TypeClass { get; set; }
}