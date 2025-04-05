using System.Globalization;
using CsvHelper;
using ExpenseAnalysis.Api.Entities;
using ExpenseAnalysis.Api.Entities.ExpenseRecord;
using ExpenseAnalysis.Api.Infrastructure;
using ExpenseAnalysis.Common.Api.Requests;
using MediatR;

namespace ExpenseAnalysis.Api.Features.OshExpenses.Commands;

public class AddOshExpenseFileCommand : IRequest<Unit>
{
    public AddOshExpenseFileRequest Request { get; set; } = null!;

    public class AddOshExpenseFileCommandHandler : IRequestHandler<AddOshExpenseFileCommand, Unit>
    {
        private readonly ApplicationDbContext _dbContext;

        public AddOshExpenseFileCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AddOshExpenseFileCommand cmd, CancellationToken cancellationToken)
        {
            var file = cmd.Request.File;

            if (file == null || file.Length == 0)
            {
                throw new Exception("No file uploaded.");
            }

            if (!file.FileName.EndsWith(".csv"))
            {
                throw new Exception("File name must end with '.csv'");
            }
            
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            Directory.CreateDirectory(uploadsFolder); // Ensure the folder exists

            var filePath = Path.Combine(uploadsFolder, string.Join("-", DateTime.Now.ToString("yyyy.MM.dd.HH.mm"), file.FileName));
        
            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream, cancellationToken);

            using var reader = new StreamReader(file.OpenReadStream());
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<OshExpenseRecord.CsvMap>();
            var records = csv.GetRecords<OshExpenseRecord>();
            
            var oshReport = new OshExpenseReport()
            {
                StartDate = cmd.Request.StartDate,
                EndDateTime = cmd.Request.EndDate,
                ReportFilePath = filePath,
                Records = records.ToList()
            }; 
            
            _dbContext.OshExpenseReports.Add(oshReport);
            
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}