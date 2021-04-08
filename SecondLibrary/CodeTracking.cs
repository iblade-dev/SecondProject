using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    //first sample.
    public class cCodeTracking
    {
        readonly IList<cCodeTrackingStruct> xItems = new List<cCodeTrackingStruct>();

        public void Add(String Description, eRelation Relation = eRelation.ToFunction)
        {
            cCodeTrackingStruct xItem = new cCodeTrackingStruct
            {
                _Date = DateTime.Now,
                _Description = Description,
                _Relation = Relation,
                _Method = cStackTrace.Get_MethodName(cStackTrace.eMethodDetail.WithClass, 2)
            };
            xItems.Add(xItem);

        }

        public String Display()
        {
            String xDisplay = "";
            foreach (cCodeTrackingStruct xItem in xItems)
            {
                xDisplay += $"{xItem._Date}  {xItem._Method}  {xItem._Description}";
                xDisplay += Environment.NewLine;
            }
            return xDisplay;
        }

        public void Clear()
        {
            xItems.Clear();
        }
    }


    class cCodeTrackingStruct
    {
        public DateTime _Date { get; set; }
        public String _Description { get; set; }
        public eRelation _Relation { get; set; }
        public String _Method { get; set; }
    }

    public enum eRelation
    {
        Absolute = 1,
        ToFunction = 2,
        ToPrevious = 3,
        ToItem = 4
    }

}
