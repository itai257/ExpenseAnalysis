using ExpenseAnalysis.CLI.Model;
using OfficeOpenXml;

namespace ExpenseAnalysis.CLI;

public class Loader
{
    public AggregatedRecord GetAggregatedRecord(string reportsDirPath)
    {
        var aggregatedRecord = new AggregatedRecord();
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
                aggregatedRecord.AddLeumiVisaReport(leumiVisaReport);
            }

            else if (fileName.Contains("Osh", StringComparison.CurrentCultureIgnoreCase))
            {
                var from = fileName.Split(".")[1];
                var to = fileName.Split(".")[3];
                Console.WriteLine($"Osh - From: {@from}, To: {to}");
                var leumiOshReport = LoadLeumiOshExcel(file, @from, to);
                aggregatedRecord.AddLeumiOshReport(leumiOshReport);
            }
            else if (fileName.Contains("Visa.Cal", StringComparison.CurrentCultureIgnoreCase))
            {
                var month = fileName.Split(".")[2];
                var cardSuffix = fileName.Split(".")[3];
                Console.WriteLine($"Visa.Cal - From: {month}, Card: {cardSuffix}");
                var calVisaReport = LoadCalVisaExcel(file, month, cardSuffix);
                aggregatedRecord.AddCalVisaReport(calVisaReport);
            }
        }

        return aggregatedRecord;
    }

    public CalVisaReport LoadCalVisaExcel(string filePath, string month, string cardSuffix)
    {
        using ExcelPackage package = new ExcelPackage(new FileInfo(filePath));
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        ExcelWorksheet worksheet = package.Workbook.Worksheets.First();

        var reports = new List<CalVisaReportRecord>();
        for (int i = 5; i <= worksheet.Dimension.End.Row && worksheet.Cells[i, 1] != null && !string.IsNullOrEmpty(worksheet.Cells[i, 1].Text); i++)
        {
            DateTime date = worksheet.Cells[i, 1].GetValue<DateTime>();
            string businessPlaceName = worksheet.Cells[i, 2].GetValue<string>();
            var dealAmount = Price.FromExcelCell(worksheet.Cells[i, 3]);
            var chargeCost = Price.FromExcelCell(worksheet.Cells[i, 4]);
            string dealKind = worksheet.Cells[i, 5].GetValue<string>();
            string branch = worksheet.Cells[i, 6].GetValue<string>();
            string notes = worksheet.Cells[i, 7].GetValue<string>();

            var report = new CalVisaReportRecord(date, businessPlaceName, dealAmount, chargeCost, dealKind, branch, notes);
            reports.Add(report);
            Console.WriteLine(report);
        }

        Console.WriteLine("Done");
        return new CalVisaReport(reports, month, cardSuffix);
    }

    public LeumiVisaReport LoadLeumiVisaExcel(string filePath, string month, string cardSuffix)
    {
        using ExcelPackage package = new ExcelPackage(new FileInfo(filePath));
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        ExcelWorksheet worksheet = package.Workbook.Worksheets.First();

        List<LeumiVisaReportRecord> reports = new List<LeumiVisaReportRecord>();
        for (int i = 12; i <= worksheet.Dimension.End.Row && worksheet.Cells[i, 1] != null && !string.IsNullOrEmpty(worksheet.Cells[i, 1].Text); i++)
        {
            var date = worksheet.Cells[i, 1].ToDateTime();
            string businessPlaceName = worksheet.Cells[i, 2].GetValue<string>();
            var dealAmount = Price.FromExcelCell(worksheet.Cells[i, 3]);
            string dealKind = worksheet.Cells[i, 4].GetValue<string>();
            string notes = worksheet.Cells[i, 5].GetValue<string>();
            var chargeCost = Price.FromExcelCell(worksheet.Cells[i, 6]);

            var report = new LeumiVisaReportRecord(date, businessPlaceName, dealAmount, dealKind, notes, chargeCost);
            reports.Add(report);
            Console.WriteLine(report);
        }

        Console.WriteLine("Done");
        return new LeumiVisaReport(reports, month, cardSuffix);
    }

    public LeumiOshReport LoadLeumiOshExcel(string filePath, string from, string to)
    {
        using ExcelPackage package = new ExcelPackage(new FileInfo(filePath));
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        ExcelWorksheet worksheet = package.Workbook.Worksheets.First();

        List<LeumiOshReportRecord> reports = new List<LeumiOshReportRecord>();
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

            var report = new LeumiOshReportRecord(date, 
                valueDate,
                description,
                referenceNumber,
                debit,
                credit,
                balance,
                notes);
            reports.Add(report);
            Console.WriteLine(report);
        }

        Console.WriteLine("Done");
        return new LeumiOshReport(reports, from, to);
    }
}