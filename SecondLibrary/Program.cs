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
