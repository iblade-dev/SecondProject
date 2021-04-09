using System;

namespace SecomdLibrary
{
    public class TrackingModel
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public EnumRelation Relation { get; set; }
        public string Method { get; set; }

        public TimeSpan TimeSpan { get; set; }
        public string Output { get; set; }
    }


    public class TrackingFuncModel
    {
        public DateTime Date { get; set; }
        public string Method { get; set; }
        /// <summary>
        /// Counts the number of times that the function is called  
        /// </summary>
        public long Counter { get; set; }

    }

}
