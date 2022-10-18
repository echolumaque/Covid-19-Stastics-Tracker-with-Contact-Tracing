using System;
using System.Collections.Generic;

namespace NcoVAppUpdate.Models
{
    //public class Cases
    //{
    //    public string New { get; set; }
    //    public int Active { get; set; }
    //    public int Recovered { get; set; }
    //    public int Total { get; set; }
    //}

    //public class Deaths
    //{
    //    public string New { get; set; }
    //    public int Total { get; set; }
    //}

    //public class CasesResponse
    //{
    //    public Cases Cases { get; set; }
    //    public Deaths Deaths { get; set; }
    //    public DateTime Time { get; set; }
    //}

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Cases
    {
        public string New { get; set; }
        public int Active { get; set; }
        public int Recovered { get; set; }
        public int Total { get; set; }
    }

    public class Deaths
    {
        public string New { get; set; }
        public int Total { get; set; }
    }

    public class Response
    {
        public Cases Cases { get; set; }
        public Deaths Deaths { get; set; }
        public DateTime Time { get; set; }
    }

    public class CovidCases
    {
        public IEnumerable<Response> Response { get; set; }
    }
}