using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.Misc;
using CommonBasicStandardLibraries.BasicDataSettingsAndProcesses;
using CommonBasicStandardLibraries.CollectionClasses;
using System;
namespace SecomdLibrary
{
    public class CodeTracking : ICodeTracking
    {
        readonly CustomBasicList<TrackingModel> _xItems = new();
        public void Add(string description, EnumRelation relation = EnumRelation.ToFunction)
        {
            TrackingModel xItem = new TrackingModel
            {
                Date = DateTime.Now,
                Description = description,
                Relation = relation,
                Method = CustomStackTrace.GetMethodName(CustomStackTrace.EnumMethodDetail.WithClass, 2)
            };
            _xItems.Add(xItem);
        }

        public CustomBasicList<TrackingModel> GetTrackingData => _xItems.ToCustomBasicList(); //so i can use blazor to display it.

        //public string Display()
        //{
        //    StrCat cats = new();
        //    foreach (var xItem in _xItems)
        //    {
        //        cats.AddToString($"{xItem.Date} {xItem.Method} {xItem.Description}", Constants.vbCrLf);
        //    }
        //    string output = cats.GetInfo();
        //    return output;
        //}
        public void Clear()
        {
            _xItems.Clear();
        }
    }
}