using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BootstrapMVC.Models;
using System.IO;
using BootstrapMVC.Helpers;
using System.Collections;
using System.Xml.Linq;
using System.Threading.Tasks;



namespace BootstrapMVC.Controllers
{
    public class StoresController : Controller
    {

//            currentDomain.UnhandledException+= UnhandledException.currentDomain_UnhandledException;
           

        public delegate int Comparator(Product x, Product y);

        private StoresEntities db = new StoresEntities();

        ObjectLearner oLearner = new ObjectLearner();
       
        

        //// GET: Items 
        //public ActionResult Index()
        //{
        //    var products = db.Products 
        //        .Where(p => p.Name.Contains("Deepa")).ToList();
        //    // .Select(p);
        //    List<Product> prodList = products.ToList();
        //    return View(prodList);

        //    // return View(db.Products.ToList());

        //}
        //[HttpGet][ActionName("Index")]
        ////[ValidateAntiForgeryToken]
        //public ActionResult Search(string searchOption, string searchText)
        //{
        //    //if (int id == 1)
        //    //    sortBy = "Name";
        //    if (searchOption != null && searchText != null)
        //    {
        //        Product prod = new Product();
        //        List<Product> SelectedList = db.Products.ToList();
        //     //   int locateName = db.Products.ToList().IndexOf(prod);
        //        var products = from p in db.Products
        //                       where prod.Name.Contains(searchText)
        //                       select p;

        //        //return RedirectToAction("Index",); 
        //        return View(db.Products.ToList());

        //                   }
        //    else
        //    {
        //        return View(db.Products.ToList());
        //    }

        //}

        static void currentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) 
        {
            Exception ex = (Exception)e.ExceptionObject;

            // logging and warning messages

//            Console.WriteLine("Runtime terminating: {0}", e.IsTerminating);
       
        }

         [HttpGet] 
        public ActionResult Index(string sortBy, string searchText, int priceMinRange=0, int priceMaxRange=25000)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(currentDomain_UnhandledException);
           // Application.ThreadException += new UnhandledExceptionEventHandler(currentDomain_UnhandledException);
             #region Unhandled Exception Test
            //string testUnhandle = null;
            //testUnhandle.ToString();

            #endregion

            

            #region List to Array
            //List<Product> baseList = db.Products.ToList();
            //// int arraySize= baseList.Count;
            //Product[] productArray = baseList.ToArray();
            //Array productDestinationArray = Array.CreateInstance(typeof(Product), baseList.Count);
            //Array.Copy(productArray, productArray.GetLowerBound(0) + 5
            //    , productDestinationArray, productDestinationArray.GetLowerBound(0), productDestinationArray.GetLowerBound(0) + 25);

            //Array.ConstrainedCopy(productArray, productArray.GetLowerBound(0) + 5
            //  , productDestinationArray, productDestinationArray.GetLowerBound(0), productDestinationArray.GetLowerBound(0) + 5);
             
         

            #endregion

            #region List to XML
            List<Product> xmlList = db.Products.ToList();
            var xmlFromList = new XElement("Products"
                , xmlList.Select(x => new XElement("Product"
                , new  XAttribute("Id", x.ID)
                , new XAttribute("Name", x.Name)
                , new XAttribute("Price", x.Price))));
               
            #endregion
            IQueryable iqueryable;
            oLearner.Equals(oLearner);
            var hashCode= oLearner.GetHashCode();
            var typeCurrentInstance= oLearner.GetType();
            var objStr= oLearner.ToString();

            //FormCollection fc = new FormCollection();
            //fc.Add("oLearner",oLearner.ToString());
           // ArrayList aList = new ArrayList();



             
            Logger.logger.Info("Inside  Store Index Info");
            Logger.logger.Fatal("Inside  Store Index Fatal");
            Logger.logger.Error("Inside  Store Index Error");
            Logger.logger.Debug("Inside  Store Index Debug");
            Logger.logger.Warn("Inside  Store Index Warn");
           
            //string sortBy2= null;
            //if (int id == 1)
            //    sortBy = "Name"; 


            #region Locating Object for an element- IComparable IndexOf has to implement Equals n GetHashCode
            Product prod = new Product();

            prod = db.Products.Find(20);
            int locateName = db.Products.ToList().IndexOf(prod);
            List<Product> productsLambda = db.Products.ToList();
            #endregion





            if (sortBy != null && !"".Equals(sortBy))
            {

                

                PriceComparer pComparer = new PriceComparer();
                NameComparer nComparer = new NameComparer();
                //List<Product> IndexofList = db.Products.ToList();
              



                Product p1; Product p2;
                //Comparator pcomparator = new Comparator(StoresController.compare(p1,p2));

                //test(new Comparator(Compare));
                //test(new Comparator(Compare1));
                //SortedList.Sort(pComparer);
                
                //db.Products.ToList().IndexOf(prod);
                if (sortBy == "ID")
                {
                    List<Product> SortedList = db.Products.ToList();
                    SortedList.Sort();
                    return View(SortedList);
                }
                if (sortBy == "Price")
                {
                    List<Product> SortedList = db.Products.ToList();
                    #region Interface with one method 
                    //SortedList.Sort(pComparer);
                    #endregion
                    #region Anonymous Methods
                    //SortedList.Sort(delegate(Product x, Product y)
                    //                            {
                                                    
                    //                                    if (x.Price > y.Price)
                    //                                         return 1;
                    //                                    else if (x.Price < y.Price)
                    //                                        return -1;
                    //                                    else
                    //                                        return 0;

                    //                            });
                    #endregion
                    #region Named Delegate
                    //SortedList.Sort(Compare);
                    #endregion
                    #region Lambda Expressions
                    SortedList.Sort((p3,p4) => p3.Price.CompareTo(p4.Price));
                    SortedList.OrderByDescending(p => p.Price).ToList();
                    #endregion
                    return View(SortedList);
                }
                else if (sortBy == "Name") 
                {
                    List<Product> SortedList = db.Products.ToList();
                    SortedList.Sort(nComparer);
                    SortedList.Reverse();
                    return View(SortedList);
                }
                else
                {
                    return View(db.Products.ToList());
                }
            }
            else
                {
                    var products = db.Products.ToList();
                    if (searchText != null && !"".Equals(searchText))
                    {
                        products = products
                       .Where(p => p.Name.Contains(searchText) && (p.Price > priceMinRange && p.Price <= priceMaxRange)).ToList();
                        List<Product> prodList = products.ToList();
                        

                        //var productPrice = db.Products.
                        //  Where(p => (p.Price > 0 && p.Price <= 10)).ToList();
                    }
                    else
                    {
                        products = products
                      .Where(p => (p.Price > priceMinRange && p.Price <= priceMaxRange)).ToList();
                        List<Product> prodList = products.ToList();
                        

                    }

                        return View("Index", products);

                }

        }

        [HttpPost] 
        public ActionResult SearchIndex(string sortBy, string searchOption ,string searchText,FormCollection formcol)
         {
             
             //string sortBy2= null;
             //if (int id == 1)
             //    sortBy = "Name";


             if (sortBy != null && !"".Equals(sortBy))
             {

                 Product prod = new Product();


                 prod = db.Products.Find(20);


                 PriceComparer pComparer = new PriceComparer();
                 NameComparer nComparer = new NameComparer();
                 List<Product> IndexofList = db.Products.ToList();
                 int locateName = db.Products.ToList().IndexOf(prod);
                 db.Products.ToList().IndexOf(prod);
                 if (sortBy == "ID")
                 {
                     List<Product> SortedList = db.Products.ToList();
                     SortedList.Sort();
                     return View("Index",SortedList);
                 }
                 if (sortBy == "Price")
                 {
                     List<Product> SortedList = db.Products.ToList();
                     SortedList.Sort(pComparer);
                     return View("Index",SortedList);
                 }
                 else if (sortBy == "Name")
                 {
                     List<Product> SortedList = db.Products.ToList();
                     SortedList.Sort(nComparer);
                     return View("Index",SortedList);
                 }
                 else
                 {
                     return View("Index",db.Products.ToList());
                 }
             }
             else
                 if (searchOption != null && searchText != null)
                 {
                     var products = db.Products
                    .Where(p => p.Name.Contains(searchText)).ToList();
                     List<Product> prodList = products.ToList();

                     var productPrice = db.Products.
                       Where(p => (p.Price > 0 && p.Price <= 10)).ToList();

                     return View("Index", productPrice);

                   
                 }
                 else
                 {
                     return View("Index",db.Products.ToList());
                 }

         }


        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product item = db.Products.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }


        public void test(Comparator comparator)
        {
             List<Product> IndexofList = db.Products.ToList();

             Product p1 = new Product();
             p1.Price = 10;
             Product p2 = new Product();
             p2.Price = 20;
             comparator(p1, p2);

        }
        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price,Image,DateCreated,LastUpdated,Details")] Product product)
        {
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
            {
                fileData = binaryReader.ReadBytes(Request.Files[0].ContentLength);
            }

            product.Image = fileData;

            //HttpPostedFileBase file = Request.Files[0];
          
            //FileStream fs = new FileStream(@"C:\Users\priyvasanthan\Documents\Visual Studio 2013\Projects\BootstrapMVC\BootstrapMVC\Content\pics\" + product.Name + Request.Files[0].FileName.Substring(Request.Files[0].FileName.Length - 4, 4), FileMode.Create, FileAccess.Write);
            //fs.Write(fileData, 0, fileData.Length);

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        private string Substring(string p)
        {
            throw new NotImplementedException();
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product item = db.Products.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price,Image,DateCreated,LastUpdated,Details")] Product product)
        {
            if(Request.Files.Count !=0)
            {
            byte[] fileData = null;
                using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                {
                    fileData = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                }

                product.Image = fileData;
            }


            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //[HttpGet]
        ////public void GetImage([Bind(Include = "ID")] int id) 
        //public void GetImage(int id)
        //{
        //    Product product = db.Products.Find(id);
        //    Response.ContentType = "image/jpeg";
        //    Response.OutputStream.Write(product.Image, 0, product.Image.Length);
        //}
        //[HttpGet]
        //public ActionResult DownloadImages()
        //{ 
        //    foreach(Product product in db.Products )
        //    {
        //      //  string fullName = Path.Combine(@"C:\Users\priyvasanthan\Downloads\Images", product.Name + product.ID);
                
        //        // Response.OutputStream.Read(product.Image, 0, product.Image.Length), System.Net.Mime.MediaTypeNames.Application.Octet, product.Name + product.ID);
        //        return 1;
        //    }
        //}

        [HttpGet]
        public async Task GetImage([Bind(Include = "ID")] int id)
        {
            Product product = db.Products.Find(id);
            Response.ContentType = "image/jpeg";
            await Response.OutputStream.WriteAsync(product.Image, 0, product.Image.Length);
           // Response.OutputStream.Write(product.Image, 0, product.Image.Length);
            

            //Response.OutputStream.WriteAsync(prod.Image, 0, prod.Image.Length).ContinueWith(task => {
            //    if (task.Status != TaskStatus.RanToCompletion) Response.Write("Image not loaded successfully");
            //});
        }
        [HttpGet]
        //public void GetImage([Bind(Include = "ID")] int id) 
        public void LoadImage()
        {
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
            {
                fileData = binaryReader.ReadBytes(Request.Files[0].ContentLength);
            }

           // Product product = db.Products.Find(id);
            Response.ContentType = "image/jpeg";
            Response.OutputStream.Write(fileData, 0, fileData.Length);
        }


        //public ActionResult View()
        //{
        //    return View();
        //}

        public ActionResult ListItem()
        {
            return View(db.View_ListItem.ToList());
        }
        public ActionResult ListItem_t()
        {
            return View(db.Products.ToList());
        }



        public ActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddItem([Bind(Include = "ID,Name,Price,Image,DateCreated,LastUpdated,Details")] Product product)
        {
            byte[] fileData = null;
            if (Request.Files.Count > 0)
            {
                using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                {
                    fileData = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                }


                product.Image = fileData;

                HttpPostedFileBase file = Request.Files[0];

                FileStream fs = new FileStream(@"C:\Users\priyvasanthan\Documents\Visual Studio 2013\Projects\BootstrapMVC\BootstrapMVC\Content\pics\" + product.Name + Request.Files[0].FileName.Substring(Request.Files[0].FileName.Length - 4, 4), FileMode.Create, FileAccess.Write);
                fs.Write(fileData, 0, fileData.Length);
            }


            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

      
        public static int Compare(Product x, Product y)
        {
            Console.Write("Delegate definition1");
            try
            {

                if (x.Price > y.Price)
                    return 1;
                else if (x.Price < y.Price)
                    return -1;
                else
                    return 0;
            }
            catch (ApplicationException appEx)
            {
                throw appEx;
            }
        }

        public static int Compare1(Product x, Product y)
        {
            Console.Write("Delegate definition2");
            try
            {

                if (x.Price < y.Price)
                    return 1;
                else if (x.Price > y.Price)
                    return -1;
                else
                    return 0;
            }
            catch (ApplicationException appEx)
            {
                throw appEx;
            }
        }
    }
}