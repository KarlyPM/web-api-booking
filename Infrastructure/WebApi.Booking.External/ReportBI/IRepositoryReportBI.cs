namespace Bg.Hcm.InfraestructuraExternal.ReportOracleBI
{
    public interface IRepositoryReportBI
    {
        public Task<string?> ResponseReport(string reportPath, Dictionary<string, List<string>> parametros);

        public Task<List<dynamic>> ReportDataTableAsync(string reportPath, Dictionary<string, List<string>> parametros);


    }
}
