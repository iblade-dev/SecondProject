using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using SecomdLibrary;
using SecondProjectBlazor.Models;
using System.Threading.Tasks;
namespace SecondProjectBlazor.Shared
{
    public partial class MainPage
    {
        CustomBasicList<TrackingModel> _tracks = new();
        [Inject]
        private ICodeTracking Tracks { get; set; }
        [Inject]
        private Article Article { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await Article.FirstInitAsync();
            await Article.LoadAsync();
            Tracks.Process();
            _tracks = Tracks.GetTrackingData;
        }

    }
}