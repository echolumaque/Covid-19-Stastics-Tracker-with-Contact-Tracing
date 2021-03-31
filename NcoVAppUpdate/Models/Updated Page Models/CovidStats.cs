using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NcoVAppUpdate
{

    public partial class CovidStats
    {
        [JsonProperty("response")]
        public List<Response> Response { get; set; }
    }
    public partial class Response
    {
        [JsonProperty("cases")]
        public Cases Cases { get; set; }

        [JsonProperty("deaths")]
        public Deaths Deaths { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }
    }

    public partial class Cases
    {
        [JsonProperty("new")]
        public string New { get; set; }

        [JsonProperty("active")]
        public long Active { get; set; }

        [JsonProperty("recovered")]
        public long Recovered { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }

    public partial class Deaths
    {
        [JsonProperty("new")]
        public string New { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }
}

