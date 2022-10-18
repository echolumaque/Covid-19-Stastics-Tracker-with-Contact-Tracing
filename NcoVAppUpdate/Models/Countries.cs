using System.Collections.Generic;

namespace NcoVAppUpdate.Models
{
    public class Countries
    {
        public string Get { get; set; }
        public IEnumerable<object> Parameters { get; set; }
        public IEnumerable<object> Errors { get; set; }
        public int Results { get; set; }
        public IEnumerable<string> Response { get; set; }
    }
}