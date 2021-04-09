using CommonBasicStandardLibraries.CollectionClasses;

namespace SecomdLibrary
{
    public interface ICodeTracking
    {
        void Add(string description, EnumRelation relation = EnumRelation.ToMethod);
        void AddMethod();
        void Clear();
        CustomBasicList<TrackingModel> GetTrackingData { get; }
        void Process();
    }
}