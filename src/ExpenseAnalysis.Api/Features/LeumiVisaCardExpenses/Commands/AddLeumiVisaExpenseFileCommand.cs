using System.Globalization;
using CsvHelper;
using ExpenseAnalysis.Api.Entities;
using ExpenseAnalysis.Api.Entities.ExpenseRecord;
using ExpenseAnalysis.Api.Entities.Reports;
using ExpenseAnalysis.Api.Features.LeumiVisaCardExpenses.Requests;
using ExpenseAnalysis.Api.Infrastructure;
using MediatR;

namespace ExpenseAnalysis.Api.Features.LeumiVisaCardExpenses.Commands;

public class AddLeumiVisaExpenseFileCommand : IRequest<Unit>
{
    public AddLeumiVisaExpenseFileRequest Request { get; set; } = null!;

    public class AddLeumiVisaExpenseFileCommandHandler : IRequestHandler<AddLeumiVisaExpenseFileCommand, Unit>
    {
        private readonly ApplicationDbContext _dbContext;

        public AddLeumiVisaExpenseFileCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AddLeumiVisaExpenseFileCommand cmd, CancellationToken cancellationToken)
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

            var filePath = await UploadFile(cancellationToken, file);

            using var reader = new StreamReader(file.OpenReadStream());
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<LeumiVisaCardExpenseRecord.CsvMap>();
            var records = csv.GetRecords<LeumiVisaCardExpenseRecord>().ToList();

            var report = new LeumiVisaCardExpenseReport()
            {
                DebitDate = cmd.Request.DebitDate,
                ReportFilePath = filePath,
                Records = records
            };

            _dbContext.LeumiVisaCardExpenseReports.Add(report);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private static async Task<string> UploadFile(CancellationToken cancellationToken, IFormFile file)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            Directory.CreateDirectory(uploadsFolder); // Ensure the folder exists

            var filePath = Path.Combine(uploadsFolder,
                string.Join("-", DateTime.Now.ToString("yyyy.MM.dd.HH.mm"), file.FileName));

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream, cancellationToken);
            return filePath;
        }
    }
} 