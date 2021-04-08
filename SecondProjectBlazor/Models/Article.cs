using SecomdLibrary;
using System.Threading.Tasks;
namespace SecondProjectBlazor.Models
{
    public class Article
    {
        private readonly ICodeTracking _tracking;
        public Article(ICodeTracking tracking)
        {
            //System.Threading.Thread.Sleep(100); //this time, can't be async.
            _tracking = tracking;
            //_tracking.Add("Constructor");
        }

        public async Task FirstInitAsync()
        {
            await Task.Delay(100);
            _tracking.Add("Constructor");
        }

        public async Task LoadAsync()
        {
            await Task.Delay(200); //pretend its doing for 200 milliseconds.
            _tracking.Add("Load");
            await RefreshDataAsync();
        }
        public async Task RefreshDataAsync()
        {
            await Task.Delay(50);
            _tracking.Add("Get Auxiliary tables");
            await Task.Delay(75);
            _tracking.Add("Get Article Tables");
            await Task.Delay(50);
            await OperationAAsync();
        }
        private async Task OperationAAsync()
        {
            await Task.Delay (10);
            _tracking.Add("Operation A.1", EnumRelation.ToPrevious);

            await Task.Delay (75);
            _tracking.Add("Operation A.2", EnumRelation.ToPrevious);

            await Task.Delay (75);
            _tracking.Add("Operation A.3", EnumRelation.ToFunction);

        }
    }
}