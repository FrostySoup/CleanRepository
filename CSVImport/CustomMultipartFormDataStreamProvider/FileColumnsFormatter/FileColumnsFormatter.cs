using System;
using System.Collections.Generic;
using System.Linq;
using Data.Model;

namespace CustomMultipartFormDataStreamProvider.FileColumnsFormatter
{
    public class FileColumnsFormatter: IFileColumnsFormatter
    {
        private readonly List<string> _columnContainer = new List<string>{ "CounterPartID", "Name", "IsBuyer", "IsSeller", "Phone", "Fax" };

        private const int IndexNotFound = -1;

        public Dictionary<string, int> ReadColumnIndexes(string[] headers)
        {
            return headers.Select((v, i) => new { Key = v, Value = i })
                .ToDictionary(o => o.Key, o => o.Value);
        }

        public List<int> FormValidColumnsList(Dictionary<string, int> extractedColumnsDictionary)
        {
            List<int> columnsList = new List<int>();

            foreach (var columnName in _columnContainer)
            {
                columnsList.Add(extractedColumnsDictionary.ContainsKey(columnName)
                    ? extractedColumnsDictionary[columnName]
                    : IndexNotFound);
            }

            return columnsList;
        }

        public Company FormCompany(string[] values, List<int> columnsList)
        {
            var newCompany = new Company();

            if (ValueIsValid(columnsList, values, 0))
            {
                newCompany.ExternalId = values[columnsList[0]];
            }

            if (ValueIsValid(columnsList, values, 1))
            {
                newCompany.TradingName = values[columnsList[1]];
            }

            if (ValueIsValid(columnsList, values, 2))
            {
                newCompany.IsForwarder = values[columnsList[2]].Equals("Yes", StringComparison.InvariantCultureIgnoreCase);
            }

            if (ValueIsValid(columnsList, values, 3))
            {
                newCompany.IsWarehouse = values[columnsList[3]].Equals("Yes", StringComparison.InvariantCultureIgnoreCase);
            }

            if (ValueIsValid(columnsList, values, 4))
            {
                newCompany.Phone = values[columnsList[4]];
            }

            if (ValueIsValid(columnsList, values, 5))
            {
                newCompany.Fax = values[columnsList[5]];
            }

            return newCompany;
        }

        private bool ValueIsValid(List<int> columnsList, string[] values, int i)
        {
            return columnsList.Count > i && values.Length > i && columnsList[i] != IndexNotFound;
        }
    }
}
