using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.Misc;
using CommonBasicStandardLibraries.BasicDataSettingsAndProcesses;
using CommonBasicStandardLibraries.CollectionClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecomdLibrary
{
    public class CodeTracking : ICodeTracking
    {
        readonly DateTime _StartDate = DateTime.Now;

        readonly CustomBasicList<TrackingModel> _Items = new();
        readonly CustomBasicList<TrackingFuncModel> _Funcs = new();

        public void Add(string description, EnumRelation relation = EnumRelation.ToMethod)
        {
            string xMethod = CustomStackTrace.GetMethodName(CustomStackTrace.EnumMethodDetail.WithClass,5);

            TrackingModel xNewItem = new()
            {
                Date = DateTime.Now,
                Description = description,
                Relation = relation,
                Method = xMethod
            };
            _Items.Add(xNewItem);
        }

        public void AddFunction()
        {
            string xMethod = CustomStackTrace.GetMethodName(CustomStackTrace.EnumMethodDetail.WithClass, 5);
            TrackingFuncModel tmpFunc = _Funcs.FirstOrDefault(x => x.Method == xMethod);
            if (tmpFunc is null)
            {
                TrackingFuncModel xNewFunc = new()
                {
                    Date = DateTime.Now,
                    Method = xMethod
                };
                xNewFunc.Counter += 1;

                _Funcs.Add(xNewFunc);
            }
            else
            {
                tmpFunc.Date = DateTime.Now;
                tmpFunc.Counter += 1;
            }
        }

        public CustomBasicList<TrackingModel> GetTrackingData => _Items.ToCustomBasicList(); //so i can use blazor to display it.

        public void Process()
        {
            if (_Items is null || _Items.Count == 0) { throw new ArgumentNullException(nameof(_Items)); }

            foreach (TrackingModel xItem in _Items)
            {
                switch (xItem.Relation)
                {
                    case EnumRelation.Absolute:
                        xItem.TimeSpan = _StartDate - xItem.Date;
                        break;

                    case EnumRelation.ToMethod:
                        TrackingFuncModel tmpFunc = _Funcs.FirstOrDefault(x => x.Method == xItem.Method);
                        if (tmpFunc == null) { throw new Exception("Method not found."); }
                        xItem.TimeSpan = tmpFunc.Date - xItem.Date;
                        break;

                    case EnumRelation.ToPrevious:
                        TrackingModel tmpItem = _Items[_Items.IndexOf(xItem) - 1];
                        xItem.TimeSpan = tmpItem.Date - xItem.Date;
                        break;

                    case EnumRelation.ToItem:
                        throw new NotImplementedException();

                    default:
                        throw new NotImplementedException();
                }
                xItem.Output = $"{xItem.Method}   {xItem.Description}   {xItem.TimeSpan.TotalMilliseconds}";

            }
        }

        public void Clear()
        {
            _Items.Clear();
        }
    }
}