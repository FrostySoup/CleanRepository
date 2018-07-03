using System.Collections.Generic;
using Data.Model;

namespace CustomMultipartFormDataStreamProvider.FileColumnsFormatter
{
    public interface IFileColumnsFormatter
    {
        Dictionary<string, int> ReadColumnIndexes(string[] headers);

        Company FormCompany(string[] values, List<int> columnsList);

        List<int> FormValidColumnsList(Dictionary<string, int> extractedColumnsDictionary);
    }
}
