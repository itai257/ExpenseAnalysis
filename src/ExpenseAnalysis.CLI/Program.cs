// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using ExpenseAnalysis.CLI;
using ExpenseAnalysis.Common.Model;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Console.OutputEncoding = Encoding.GetEncoding("Windows-1255");
var monthlyReport = new DataLoader().GetMonthlyReport("C:\\Leumi-To-Program\\xlsx");
var serializedText = JsonSerializer.Serialize(monthlyReport, new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
File.WriteAllText($"C:\\Leumi-To-Program\\monthly_report_jsons\\{DateTime.Today.ToString("dd.MM.yyyy")}.json", serializedText, Encoding.GetEncoding("Windows-1255"));

//var dir = Directory.GetFiles("C:\\Leumi-To-Program\\monthly_report_jsons");
//var text = File.ReadAllText(dir[0]);
//var deserializedContent = JsonSerializer.Deserialize<MonthlyReport>(text);


//loader.LoadCalVisaExcel("C:\\Leumi-To-Program\\Visa.Cal.April.4314.xlsx");
//loader.LoadLeumiVisaExcel("C:\\Leumi-To-Program\\xlsx\\Visa.Leumi.April.1842.xlsx");
//loader.LoadLeumiVisaExcel("C:\\Leumi-To-Program\\xlsx\\Visa.Leumi.April.1842.xlsx");
Console.WriteLine("Hello, World!");