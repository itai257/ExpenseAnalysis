using ExpenseAnalysis.Api.Entities;
using ExpenseAnalysis.Api.Entities.ExpenseRecord;
using Microsoft.EntityFrameworkCore;

namespace ExpenseAnalysis.Api.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    // Entity collections
    public DbSet<ExpenseTypeClass> ExpenseTypeClasses { get; set; } = null!;
    
    public DbSet<CalCardExpenseRecord> CalCardExpenseRecords { get; set; } = null!;
    
    public DbSet<LeumiVisaCardExpenseRecord> LeumiVisaCardExpenseRecords { get; set; } = null!;
    
    public DbSet<OshExpenseRecord> OshExpenseRecords { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Using data annotations in entity classes instead of Fluent API
    }
}