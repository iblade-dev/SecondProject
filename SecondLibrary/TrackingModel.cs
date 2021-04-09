using System;

namespace SecomdLibrary
{
    public class TrackingModel
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public EnumRelation Relation { get; set; }
        public string Method { get; set; }
        public long Counter { get; set; }
    }

}
