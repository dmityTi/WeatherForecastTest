using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Models
{
    public class SelectOptionsData
    {
        public int[] AmountDays { get; set; } = Enumerable.Range(1, 5).ToArray();
        public List<CityOption> Cities { get; set; }
        public List<string> Providers { get; set; }
        public List<string> Units { get; set; }
        public List<string> Languages { get; set; }
    }

    public class CityOption
    {
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
