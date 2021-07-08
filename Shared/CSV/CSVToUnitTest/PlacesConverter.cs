using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.CSV.CSVToUnitTest
{
    public class PlacesConverter
    {
        public static IEnumerable<object[]> Convert ()
        {
            string[] csvLines = File.ReadAllLines("Places.csv");
            var testCases = new List<object[]>();

            foreach (var csvLine in csvLines)
            {
                IEnumerable<string> values = csvLine.Split(',');
                List<string> valuesstring = new List<string>();
                foreach (var item in values)
                {
                    valuesstring.Add(item.ToString());
                }

                object[] testCase = valuesstring.Cast<object>().ToArray();

                testCases.Add(testCase);
            }
            return testCases;
        }
    }
}
