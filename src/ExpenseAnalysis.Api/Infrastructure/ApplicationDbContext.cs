using ExpenseAnalysis.Api.Entities;
using ExpenseAnalysis.Api.Entities.ExpenseRecord;
using ExpenseAnalysis.Api.Entities.Reports;
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
    
    // Reports
    public DbSet<OshExpenseReport> OshExpenseReports { get; set; } = null!;
    
    public DbSet<CalCardExpenseReport> CalCardExpenseReports { get; set; } = null!;
    
    public DbSet<LeumiVisaCardExpenseReport> LeumiVisaCardExpenseReports { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<OshExpenseRecord>()
            .Property(x => x.Date)
            .HasColumnType("timestamp without time zone");
        
        modelBuilder.Entity<OshExpenseRecord>()
            .Property(x => x.ValueDate)
            .HasColumnType("timestamp without time zone");
        // Using data annotations in entity classes instead of Fluent API
    }
}