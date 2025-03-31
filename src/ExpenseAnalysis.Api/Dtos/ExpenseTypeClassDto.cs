using ExpenseAnalysis.Api.Entities;

namespace ExpenseAnalysis.Api.Dtos;

public class ExpenseTypeClassDto : IMapFrom<ExpenseTypeClass>
{
    public int Id { get; set; }
    
    public string Name { get; set; }
}