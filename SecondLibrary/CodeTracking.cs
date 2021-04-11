using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.Misc;
using CommonBasicStandardLibraries.BasicDataSettingsAndProcesses;
using CommonBasicStandardLibraries.CollectionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SecomdLibrary
{
    public class CodeTracking : ICodeTracking
    {
        readonly DateTime _StartDate = DateTime.Now;

        readonly CustomBasicList<TrackingModel> _Items = new();
        readonly CustomBasicList<TrackingMethodModel> _Methods = new();

        public void Add(string description, EnumRelation relation = EnumRelation.ToMethod, [CallerMemberName] string CallerMemberName = "")
        {
            if (string.IsNullOrEmpty(description)) { throw new ArgumentNullException(nameof(description)); }

            //string xMethod = CustomStackTrace.GetMethodName(CustomStackTrace.EnumMethodDetail.WithClass,5);

            TrackingModel tmpItem = _Items.FirstOrDefault(x => x.Method == CallerMemberName && x.Description == description);
            if (tmpItem is null)
            {
                TrackingModel xNewItem = new()
                {
                    Date = DateTime.Now,
                    Description = description,
                    Relation = relation,
                    Method = CallerMemberName
                };
                _Items.Add(xNewItem);
            }
            else
            {
                tmpItem.Counter += 1;
                tmpItem.Date = DateTime.Now;
            }
        }

        public void AddMethod([CallerMemberName] string CallerMemberName = "")
        {
            //string xMethod = CustomStackTrace.GetMethodName(CustomStackTrace.EnumMethodDetail.WithClass, 5);

            TrackingMethodModel tmpMethod = _Methods.FirstOrDefault(x => x.Method == CallerMemberName);
            if (tmpMethod is null)
            {
                TrackingMethodModel xNewMethod = new()
                {
                    Date = DateTime.Now,
                    Method = CallerMemberName
                };
                xNewMethod.Counter += 1;

                _Methods.Add(xNewMethod);
            }
            else
            {
                tmpMethod.Date = DateTime.Now;
                tmpMethod.Counter += 1;
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
                        TrackingMethodModel tmpMethod = _Methods.FirstOrDefault(x => x.Method == xItem.Method);
                        if (tmpMethod == null) { throw new Exception("Method not found."); }
                        xItem.TimeSpan = xItem.Date - tmpMethod.Date;
                        break;

                    case EnumRelation.ToPrevious:
                        TrackingModel tmpItem = _Items[_Items.IndexOf(xItem) - 1];
                        xItem.TimeSpan = xItem.Date - tmpItem.Date;
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