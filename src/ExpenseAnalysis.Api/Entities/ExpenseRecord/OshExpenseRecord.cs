using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseAnalysis.Api.Entities.ExpenseRecord;

[Table("OshExpenseRecords")]
public class OshExpenseRecord
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
    public DateTime Date { get; set; }
    
    /// <summary>
    /// The value date (corresponds to "תאריך ערך").
    /// </summary>
    [Required]
    public DateTime ValueDate { get; set; }

    /// <summary>
    /// A description of the transaction (corresponds to "תיאור").
    /// </summary>
    [StringLength(255)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// A reference or voucher number (corresponds to "אסמכתא").
    /// </summary>
    [StringLength(50)]
    public string Reference { get; set; } = string.Empty;

    /// <summary>
    /// Debit amount (corresponds to "בחובה").
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal Debit { get; set; }

    /// <summary>
    /// Credit amount (corresponds to "בזכות").
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal Credit { get; set; }

    /// <summary>
    /// The balance in NIS (corresponds to "היתרה בש"ח").
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal Balance { get; set; }
    
    /// <summary>
    /// A note or remark (e.g. "הערות"/"הערה").
    /// </summary>
    [StringLength(500)]
    public string Note { get; set; } = string.Empty;
    
    // Foreign key for ExpenseTypeClass
    public int? TypeClassId { get; set; }
    
    // Navigation property with ForeignKey attribute
    [ForeignKey("TypeClassId")]
    public ExpenseTypeClass? TypeClass { get; set; }
}