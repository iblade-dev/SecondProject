using System;
using System.Diagnostics;
namespace SecomdLibrary
{
    public class CustomStackTrace
    {
        public enum EnumMethodDetail
        {
            OnlyMethodName = 1,
            WithClass = 2
        }

        public static string GetMethodName(EnumMethodDetail methodDetail, int level = 1)
        {
            StackTrace st = new();
            StackFrame sf = st.GetFrame(level);
            string xClassName = "";
            string[] xSplit = sf.GetMethod().ReflectedType.ToString().Split('.', StringSplitOptions.RemoveEmptyEntries);
            if (xSplit.Length >= 1)
            {
                xClassName = xSplit[1];
            }
            string xMethodName = sf.GetMethod().Name;
            switch (methodDetail)
            {
                case EnumMethodDetail.OnlyMethodName: { return xMethodName; }
                case EnumMethodDetail.WithClass: { return xClassName + "." + xMethodName; }
                default: { return null; }
            }
        }
    }
}