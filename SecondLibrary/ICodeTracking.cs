using CommonBasicStandardLibraries.CollectionClasses;

namespace SecomdLibrary
{
    public interface ICodeTracking
    {
        void Add(string description, EnumRelation relation = EnumRelation.ToMethod);
        void AddFunction();
        void Process();
        void Clear();
        CustomBasicList<TrackingModel> GetTrackingData { get; }
        //string Display();
    }
}