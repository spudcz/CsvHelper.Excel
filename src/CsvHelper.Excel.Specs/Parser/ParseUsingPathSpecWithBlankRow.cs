using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;

namespace CsvHelper.Excel.Specs.Parser
{
    public class ParseUsingPathSpecWithBlankRow : ExcelParserSpec
    {
        public ParseUsingPathSpecWithBlankRow() : base("parse_by_path_with_blank_row", includeBlankRow: true)
        {
            var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                ShouldSkipRecord = record => Enumerable.Range(0, record.Row.ColumnCount).Select(x => record.Row[x]).All(string.IsNullOrEmpty)
            };
            using var parser = new ExcelParser(Path, null, csvConfiguration);
            Run(parser);
        }
    }
}