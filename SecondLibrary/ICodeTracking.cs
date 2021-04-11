using CommonBasicStandardLibraries.CollectionClasses;
using System.Runtime.CompilerServices;

namespace SecomdLibrary
{
    public interface ICodeTracking
    {
        void Add(string description, EnumRelation relation = EnumRelation.ToMethod, [CallerMemberName] string CallerMemberName = "");
        void AddMethod([CallerMemberName] string CallerMemberName = "");
        void Clear();
        CustomBasicList<TrackingModel> GetTrackingData { get; }
        void Process();
    }
}