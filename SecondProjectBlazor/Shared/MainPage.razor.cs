using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Net.Http;
using SecomdLibrary;
using SecondProjectBlazor.Models;
using System.Threading.Tasks;
using CommonBasicStandardLibraries.CollectionClasses;

namespace SecondProjectBlazor.Shared
{
    public partial class MainPage
    {
        //string _content = "";

        CustomBasicList<TrackingModel> _tracks = new();
        

        [Inject]
        private ICodeTracking Tracks { get; set; }

        
        [Inject]
        private Article Article { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await Article.FirstInitAsync();
            await Article.LoadAsync();
            _tracks = Tracks.GetTrackingData;
            //_content = Tracks.Display();
        }

    }
}

// xDisplay += $"{xItem._Date}  {xItem._Method}  {xItem._Description}";
//xDisplay += Environment.NewLine;

//Date = DateTime.Now,
//                Description = description,
//                Relation = relation,
//                Method = CustomStackTrace.GetMethodName(CustomStackTrace.EnumMethodDetail.WithClass, 2)


//class Program
//{
//    public static cCodeTracking xCodeTracking = new();

//    static void Main(string[] args)
//    {

//        Article xArticle = new();
//        xArticle.Load();

//        Console.WriteLine(xCodeTracking.Display());
//    }


//    class Article
//    {
//        public Article()
//        {
//            System.Threading.Thread.Sleep(100);
//            xCodeTracking.Add("Constructor");
//        }

//        public void Load()
//        {
//            System.Threading.Thread.Sleep(200);
//            xCodeTracking.Add("Load");
//            RefreshData();
//        }

//        public void RefreshData()
//        {
//            System.Threading.Thread.Sleep(50);
//            xCodeTracking.Add("Get Auxiliary tables");

//            System.Threading.Thread.Sleep(75);
//            xCodeTracking.Add("Get Article Tables");

//            System.Threading.Thread.Sleep(50);

//            OperationA();
//        }

//        private void OperationA()
//        {
//            System.Threading.Thread.Sleep(10);
//            xCodeTracking.Add("Operation A.1", eRelation.ToPrevious);

//            System.Threading.Thread.Sleep(75);
//            xCodeTracking.Add("Operation A.2", eRelation.ToPrevious);

//            System.Threading.Thread.Sleep(75);
//            xCodeTracking.Add("Operation A.3", eRelation.ToFunction);

//        }
//    }

//}
