using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper;
using CsvHelper.Configuration;

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
    [Column(TypeName = "timestamp without time zone")] 
    public DateTime? Date { get; set; }
    
    /// <summary>
    /// The value date (corresponds to "תאריך ערך").
    /// </summary>
    [Required]
    [Column(TypeName = "timestamp without time zone")] 
    public DateTime? ValueDate { get; set; }

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
    
    public int? TypeClassId { get; set; }
    
    [ForeignKey("TypeClassId")]
    public ExpenseTypeClass? TypeClass { get; set; }
    
    public Guid? OshReportId { get; set; }
    
    [ForeignKey("OshReportId")]
    public OshExpenseReport? OshReport { get; set; }

    public sealed class CsvMap : ClassMap<OshExpenseRecord>
    {
        public CsvMap()
        {
            Map(m => m.Date).Index(0).Convert(x =>
            {
                var value = x.Row.GetField(0) ?? string.Empty;
                return string.IsNullOrEmpty(value) ? null : DateTime.Parse(value);
            });
            Map(m => m.ValueDate).Index(1).Convert(x =>
            {
                var value = x.Row.GetField(0) ?? string.Empty;
                return string.IsNullOrEmpty(value) ? null : DateTime.Parse(value);
            });
            Map(m => m.Description).Index(2);
            Map(m => m.Reference).Index(3);
            Map(m => m.Debit).Index(4);
            Map(m => m.Credit).Index(5);
            Map(m => m.Balance).Index(6);
            Map(m => m.Note).Index(7);
        }
    }
}