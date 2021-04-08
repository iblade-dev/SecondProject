using CommonBasicStandardLibraries.CollectionClasses;

namespace SecomdLibrary
{
    public interface ICodeTracking
    {
        void Add(string description, EnumRelation relation = EnumRelation.ToFunction);
        void Clear();
        CustomBasicList<TrackingModel> GetTrackingData { get; }
        //string Display();
    }
}