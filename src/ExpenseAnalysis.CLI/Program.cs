// See https://aka.ms/new-console-template for more information
using System.Text;
using ExpenseAnalysis.CLI;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Console.OutputEncoding = Encoding.GetEncoding("Windows-1255");
var aggregatedRecord = new Loader().GetAggregatedRecord("C:\\Leumi-To-Program\\xlsx");

//loader.LoadCalVisaExcel("C:\\Leumi-To-Program\\Visa.Cal.April.4314.xlsx");
//loader.LoadLeumiVisaExcel("C:\\Leumi-To-Program\\xlsx\\Visa.Leumi.April.1842.xlsx");
//loader.LoadLeumiVisaExcel("C:\\Leumi-To-Program\\xlsx\\Visa.Leumi.April.1842.xlsx");
Console.WriteLine("Hello, World!");

