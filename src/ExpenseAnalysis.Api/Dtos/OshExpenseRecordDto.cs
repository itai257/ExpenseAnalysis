using AutoMapper;
using ExpenseAnalysis.Api.Entities;
using ExpenseAnalysis.Api.Entities.ExpenseRecord;

namespace ExpenseAnalysis.Api.Dtos;

public class OshExpenseRecordDto : IMapFrom<OshExpenseRecord>
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime ValueDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Reference { get; set; } = string.Empty;
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    public decimal Balance { get; set; }
    public string Note { get; set; } = string.Empty;
    
    public string? TypeClassName { get; set; } = string.Empty;
} 