using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Statistics
    {

        //Läser in json-filen och sparar det i en array som används i resten av programmet.
        private static int[] _jsonNumbers
        {
            get
            {
                //Json filen måste ligga i användare och den måste heta data.json
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/data.json");
                string jsonString = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<int[]>(jsonString);
            }
        }
        private static List<int> Mode()
        {
            var keyList = new List<int>();

            var counts = _jsonNumbers.GroupBy(i => i).Select(group => new { group.Key, Count = group.Count() });

            var itemsMax = counts.Where(x => x.Count == counts.Max(y => y.Count));

            foreach (var item in itemsMax.OrderBy(x => x.Key))
            {
                keyList.Add(item.Key);
            }

            return keyList;
        }

        //metod för beräkning av standardavikelse
        private static double GetStandardDeviation()
        {
            double deviation = _jsonNumbers.Average();
            double avarageDeviation = _jsonNumbers.Select(val => (val - deviation) * (val - deviation)).Sum();
            double standardDeviation = Math.Round(Math.Sqrt(avarageDeviation / _jsonNumbers.Length), 1);

            return standardDeviation;
        }
        //metod för beräkning av medianvärde
        private static int GetMedian()
        {
            var sortednums = _jsonNumbers.OrderBy(number => number).ToList();
            //hittar talet i mitten på talserien:
            int itemIndex = sortednums.Count / 2;
            //om jämnt värde i mitten på talserien:
            if (sortednums.Count % 2 == 0)
            {
                return (sortednums[itemIndex] + sortednums[itemIndex - 1]) / 2;
            }
            //om ojämnt värde i mitten på talsträngen
            else
            {
                return sortednums[itemIndex];
            }
        }
        private static double GetMean() // Metoden beräknar medelvärdet av datan från Json-filen.
        {
            double sum = 0;
            foreach (int x in _jsonNumbers)
            {
                sum += x;
            }
            return Math.Round(sum / _jsonNumbers.Length, 1);
        }
        public static dynamic DescriptiveStatistics() // Metoden anropar returvärdet från uträkningsmetoderna och skapar en Dictionary som returneras.
        {
            dynamic allData = new Dictionary<string, object>() { };

            StringBuilder sb = new StringBuilder();
            foreach (var item in Mode())
            {
                sb.Append($"{item} ");
            }

            allData.Add("Maximum", _jsonNumbers.Max());
            allData.Add("Minimum", _jsonNumbers.Min());
            allData.Add("Medelvärde", GetMean());
            allData.Add("Median", GetMedian());
            allData.Add("Typvärde", sb);
            allData.Add("Variationsbredd", _jsonNumbers.Max() - _jsonNumbers.Min());
            allData.Add("Standardavvikelse", GetStandardDeviation());

            return allData;
        }
    }
}

