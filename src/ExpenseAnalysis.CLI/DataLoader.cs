using ExpenseAnalysis.Common.Model;
using ExpenseAnalysis.Common.Model.Osh;
using ExpenseAnalysis.Common.Model.Visa;
using OfficeOpenXml;
using System.Globalization;

namespace ExpenseAnalysis.CLI;

public class DataLoader
{
    public MonthlyReport GetMonthlyReport(string reportsDirPath)
    {
        var monthlyReport = new MonthlyReport
        {
            Month = 4,
            Year = 2024
        };

        var files = Directory.GetFiles(reportsDirPath);
        foreach (var file in files)
        {
            var fileName = Path.GetFileName(file);
            if (fileName.Contains("Visa.Leumi", StringComparison.CurrentCultureIgnoreCase))
            {
                var month = fileName.Split(".")[2];
                var cardSuffix = fileName.Split(".")[3];
                Console.WriteLine($"Visa.Leumi - From: {month}, Card: {cardSuffix}");
                var leumiVisaReport = LoadLeumiVisaExcel(file, month, cardSuffix);
                monthlyReport.AddVisaReport(leumiVisaReport);
            }

            else if (fileName.Contains("Osh", StringComparison.CurrentCultureIgnoreCase))
            {
                var from = fileName.Split(".")[1];
                var to = fileName.Split(".")[3];
                Console.WriteLine($"Osh - From: {from}, To: {to}");
                var startDate = DateTime.ParseExact($"{fileName.Split(".")[1]}/{fileName.Split(".")[2]}/2024", "d/M/yyyy", CultureInfo.InvariantCulture);
                var endDate = DateTime.ParseExact($"{fileName.Split(".")[4]}/{fileName.Split(".")[5]}/2024", "d/M/yyyy", CultureInfo.InvariantCulture);
                var leumiOshReport = LoadLeumiOshExcel(file, startDate, endDate);
                monthlyReport.SetOshReport(leumiOshReport);
            }
            else if (fileName.Contains("Visa.Cal", StringComparison.CurrentCultureIgnoreCase))
            {
                var month = fileName.Split(".")[2];
                var cardSuffix = fileName.Split(".")[3];
                Console.WriteLine($"Visa.Cal - From: {month}, Card: {cardSuffix}");
                var calVisaReport = LoadCalVisaExcel(file, month, cardSuffix);
                monthlyReport.AddVisaReport(calVisaReport);
            }
        }

        return monthlyReport;
    }

    public VisaReport LoadCalVisaExcel(string filePath, string month, string cardSuffix)
    {
        using ExcelPackage package = new ExcelPackage(new FileInfo(filePath));
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        ExcelWorksheet worksheet = package.Workbook.Worksheets.First();

        var records = new List<VisaRecord>();
        for (int i = 5; i <= worksheet.Dimension.End.Row && worksheet.Cells[i, 1] != null && !string.IsNullOrEmpty(worksheet.Cells[i, 1].Text); i++)
        {
            DateTime date = worksheet.Cells[i, 1].GetValue<DateTime>();
            string businessPlaceName = worksheet.Cells[i, 2].GetValue<string>();
            var dealAmount = Price.FromExcelCell(worksheet.Cells[i, 3]);
            var chargeCost = Price.FromExcelCell(worksheet.Cells[i, 4]);
            string dealKind = worksheet.Cells[i, 5].GetValue<string>();
            string category = worksheet.Cells[i, 6].GetValue<string>();
            string notes = worksheet.Cells[i, 7].GetValue<string>();

            var record = new VisaRecord()
            {
                Date = date,
                BusinessPlaceName = businessPlaceName,
                DealAmount = dealAmount,
                DealKind = dealKind,
                Notes = notes,
                Category = category,
                ChargeCost = chargeCost
            };

            records.Add(record);
        }

        Console.WriteLine("Done");
        return new VisaReport(CardType.Cal, DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month, int.Parse(cardSuffix), records);
    }

    public VisaReport LoadLeumiVisaExcel(string filePath, string month, string cardSuffix)
    {
        using ExcelPackage package = new ExcelPackage(new FileInfo(filePath));
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        ExcelWorksheet worksheet = package.Workbook.Worksheets.First();

        List<VisaRecord> records = new List<VisaRecord>();
        for (int i = 12; i <= worksheet.Dimension.End.Row && worksheet.Cells[i, 1] != null && !string.IsNullOrEmpty(worksheet.Cells[i, 1].Text); i++)
        {
            var date = worksheet.Cells[i, 1].ToDateTime();
            string businessPlaceName = worksheet.Cells[i, 2].GetValue<string>();
            var dealAmount = Price.FromExcelCell(worksheet.Cells[i, 3]);
            string dealKind = worksheet.Cells[i, 4].GetValue<string>();
            string notes = worksheet.Cells[i, 5].GetValue<string>();
            var chargeCost = Price.FromExcelCell(worksheet.Cells[i, 6]);

            var record = new VisaRecord()
            {
                Date = date,
                BusinessPlaceName = businessPlaceName,
                DealAmount = dealAmount,
                DealKind = dealKind,
                Notes = notes,
                ChargeCost = chargeCost
            };

            records.Add(record);
        }

        return new VisaReport(CardType.Leumi, DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month, int.Parse(cardSuffix), records);
    }

    public OshReport LoadLeumiOshExcel(string filePath, DateTime startDate, DateTime endDate)
    {
        using ExcelPackage package = new ExcelPackage(new FileInfo(filePath));
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        ExcelWorksheet worksheet = package.Workbook.Worksheets.First();

        var reports = new List<OshRecord>();
        for (int i = 13; i <= worksheet.Dimension.End.Row && worksheet.Cells[i, 1] != null && !string.IsNullOrEmpty(worksheet.Cells[i, 1].Text); i++)
        {
            var date = worksheet.Cells[i, 1].ToDateTime();
            var valueDate = worksheet.Cells[i, 2].ToDateTime();
            var description = worksheet.Cells[i, 3].GetValue<string>();
            var referenceNumber = worksheet.Cells[i, 4].GetValue<int>();
            var debit = worksheet.Cells[i, 5].ToPrice();
            var credit = worksheet.Cells[i, 6].ToPrice();
            var balance = worksheet.Cells[i, 7].GetValue<double>();
            var notes = worksheet.Cells[i, 8].GetValue<string>();

            var record = new OshRecord()
            {
                Date = date,
                ValueDate = valueDate,
                Description = description,
                ReferenceNumber = referenceNumber,
                Debit = debit,
                Credit = credit,
                Balance = balance,
                Notes = notes
            };

            reports.Add(record);
        }

        return new OshReport(startDate, endDate, reports);
    }
}