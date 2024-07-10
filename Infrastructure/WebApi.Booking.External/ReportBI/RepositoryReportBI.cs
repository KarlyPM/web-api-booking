using Microsoft.Extensions.Configuration;
using ServiceReference1;
using ServiceReference2;
using System.Data;
using System.Text;
using System.Xml;


namespace Bg.Hcm.InfraestructuraExternal.ReportOracleBI
{
    public class RepositoryReportBI : IRepositoryReportBI
    {
        //private readonly ILogger<RepositoryReportBI> _log;
        private readonly string spConsulta;

        private readonly IConfiguration _conf;

        public RepositoryReportBI(IConfiguration conf)
        {
            _conf = conf;
           //pConsulta = _conf.GetSection("SP:External:Report:Consulta").Value;
        }

        private static ReportRequest CrearReporte(string reportPath, Dictionary<string, List<string>> parametros)
        {
            List<ParamNameValue> paramNameValueList = new();

            foreach (var param in parametros)
            {
                var paramNameValue = new ParamNameValue
                {
                    label = param.Key,
                    name = param.Key,
                    multiValuesAllowed = false,
                    refreshParamOnChange = false,
                    selectAll = false,
                    templateParam = false,
                    useNullForAll = false,
                    values = param.Value.ToArray()
                };

                paramNameValueList.Add(paramNameValue);

            }
            var paramNameValues = new ParamNameValues
            {
                listOfParamNameValues = paramNameValueList.ToArray()
            };

            return new ReportRequest
            {
                attributeFormat = "xml",
                reportAbsolutePath = reportPath,
                byPassCache = false,
                sizeOfDataChunkDownload = -1,
                flattenXML = true,
                parameterNameValues = paramNameValues
            };
        }

        public async Task<string?> ResponseReport(string reportPath, Dictionary<string, List<string>> parametros)
        {
            string user = Environment.GetEnvironmentVariable("") ?? "";
            string pwd = _conf[""] ?? "";
            string valorMetodo = String.Empty;

            if (string.IsNullOrEmpty(user))
            {
                Console.WriteLine("usuario");

            }
            if (string.IsNullOrEmpty(pwd))
            {
                Console.WriteLine("contraseña");


            }

            ReportServiceClient client = new();
            SecurityServiceClient ds = new();

            var token = await ds.loginAsync(user, pwd);
            var reportRequest = CrearReporte(reportPath, parametros);
            var response = await client.runReportInSessionAsync(reportRequest, token);

            string result = System.Text.Encoding.UTF8.GetString(response.reportBytes);

            XmlDocument xmlDoc = new();
            xmlDoc.LoadXml(result);

            XmlNodeList nodeListCount = xmlDoc.GetElementsByTagName("METODO");

            foreach (XmlNode node in nodeListCount)
            {
                valorMetodo = node.InnerText;
            }

            if (valorMetodo == "VACIO") return null;


            return RemoveInvalidXmlChars(xmlDoc.InnerXml);
        }

        public async Task<List<dynamic>> ReportDataTableAsync(string reportPath, Dictionary<string, List<string>> parametros)
        {
            reportPath += ".xdo";

            var result = await ResponseReport(reportPath, parametros);

            if (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("error en el proceso");
            }

            DataTable dataTable = ConvertXmlToDataTable(result!);

            var list = ConvertDataTableToList(dataTable);

            return list;
        }

        private static DataTable ConvertXmlToDataTable(string xmlContent)
        {
            using StringReader reader = new(xmlContent);
            using var xmlReader = XmlReader.Create(reader);

            DataSet dataSet = new();
            dataSet.ReadXml(xmlReader);

            if (dataSet.Tables.Count > 0)
            {
                return dataSet.Tables[0];
            }
            return new DataTable();

        }

        public static List<dynamic> ConvertDataTableToList(DataTable dataTable)
        {
            List<dynamic> dynamicList = new();

            foreach (DataRow row in dataTable.Rows)
            {
                dynamic dataObject = new System.Dynamic.ExpandoObject();
                var dataObjectDictionary = (IDictionary<string, object>)dataObject;

                foreach (DataColumn column in dataTable.Columns)
                {
                    string val = (row[column] + "");

                    object value = string.IsNullOrEmpty(val) ? null : row[column];
                    dataObjectDictionary.Add(ConvertToCamelCase(column.ColumnName) + "", value);
                }

                dynamicList.Add(dataObject);
            }

            return dynamicList;
        }


        public static string ConvertToCamelCase(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            string[] words = input.Split(new char[] { ' ', '_', '-' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                return input;
            }

            StringBuilder result = new StringBuilder(words[0].ToLower());

            for (int i = 1; i < words.Length; i++)
            {
                result.Append(char.ToUpper(words[i][0]));
                result.Append(words[i].Substring(1).ToLower());
            }

            return result.ToString();
        }

        public static string RemoveInvalidXmlChars(string text)
        {
            var validXmlChars = text.Where(ch => XmlConvert.IsXmlChar(ch)).ToArray();
            return new string(validXmlChars);
        }


    }

}

