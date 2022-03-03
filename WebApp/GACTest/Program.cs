using ReportService;

ReportToFile<string> report = new();
List<string> testList = new() { "Test string 1", "Test string 2" };
report.CreateReport("testreport.txt", testList);
