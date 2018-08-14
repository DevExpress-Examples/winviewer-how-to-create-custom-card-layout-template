using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCustomLayoutTemplateExample {
    public static class DataGenerator {
        public static object GenerateTestData() {
            IList<DataRow> data = new List<DataRow>();
            Random rand = new Random(DateTime.Now.Second);
            
            var countries = new string[] { "USA", "Canada", "Argentina", "Brazil" };
            foreach(string country in countries) {
                for(int i = 0; i < 100; i++)
                    data.Add(new DataRow {
                        Country = country,
                        Sales = rand.NextDouble() * 100 * i,
                        SalesTarget = rand.NextDouble()* 100 * i,
                        SalesDate = DateTime.Now.AddDays(((i % 2 == 0 ? -1 : 1) * i) + rand.Next(10, 40))
                    });
            }
            return data;
        }
    }
    public class DataRow {
        public string Country { get; set; }
        public double Sales { get; set; }
        public double SalesTarget { get; set; }
        public DateTime SalesDate { get; set; }
    }
}
