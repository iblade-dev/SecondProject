using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class cStackTrace
    {
        public enum eMethodDetail
        {
            OnlyMethodName = 1,
            WithClass = 2
        }

        public static string Get_MethodName(eMethodDetail MethodDetail, int Level = 1)
        {
            StackTrace st = new();
            StackFrame sf = st.GetFrame(Level);

            string xClassName = "";
            string[] xSplit = sf.GetMethod().ReflectedType.ToString().Split('.', StringSplitOptions.RemoveEmptyEntries);
            if (xSplit.Length >= 1)
                xClassName = xSplit[1];

            string xMethodName = sf.GetMethod().Name;

            switch (MethodDetail)
            {
                case eMethodDetail.OnlyMethodName: { return xMethodName; }
                case eMethodDetail.WithClass: { return xClassName + "." + xMethodName; }
                default: { return null; }
            }

        }
    }
}
