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
    
    public DbSet<ExpenseTypeClass> ExpenseTypeClasses { get; set; }
    
    public DbSet<CalCardExpenseRecord> CalCardExpenseRecords { get; set; }
    
    public DbSet<LeumiVisaCardExpenseRecord> LeumiVisaCardExpenseRecords { get; set; }
    
    public DbSet<OshExpenseRecord> OshExpenseRecords { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure entity relationships, indexes, etc. here
    }
}