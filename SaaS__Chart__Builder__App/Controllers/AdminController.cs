using Microsoft.Ajax.Utilities;
using SaaS__Chart__Builder__App.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

public static class HtmlExtensions
{
    public static MvcHtmlString Nl2Br(this HtmlHelper htmlHelper, string text)
    {
        if (string.IsNullOrEmpty(text))
            return MvcHtmlString.Create(text);
        else
        {
            StringBuilder builder = new StringBuilder();
            string[] lines = text.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                if (i > 0)
                    builder.Append("<br/>\n");
                builder.Append(HttpUtility.HtmlEncode(lines[i]));
            }
            return MvcHtmlString.Create(builder.ToString());
        }
    }
}
namespace SaaS__Chart__Builder__App.Controllers

{
    public class AdminController : Controller
    {
        Dbmodel db = new Dbmodel();
        public object Configuration { get; private set; }

        // GET: Admin/ClientList
        public ActionResult ClientList()
        {
            var ClientList = db.Shop__Client.OrderByDescending(x => x.ID_).ToList();
            return View(ClientList);
        }
        // GET: Admin/GetClients
        public ActionResult GetClients()
        {
            var ChartList = db.Dashboard__Chart____88____core__Menus.OrderByDescending(x => x.ID).ToList();
            return View(ChartList);
        }
        // GET: Admin/GetClientsByCity
        public JsonResult GetClientsByCity()
        {
            db.Configuration.LazyLoadingEnabled = false;

            var ClientList = db.Shop__Client.GroupBy(e => e.Adress).Select(group => new
            {
                Metric = group.Key,
                Count = group.Count()
            });

            return Json(ClientList, JsonRequestBehavior.AllowGet);
        }
        // GET: Admin/OrderList
        public ActionResult OrderList()
        {
            var CommandeList = db.Shop__Commande.OrderByDescending(x => x.ID_).ToList();
            return View(CommandeList);
        }
        // GET: Admin/ProductList
        public ActionResult ProductList()
        {
            var ProductList = db.Shop__Product.OrderByDescending(x => x.ID_).ToList();
            return View(ProductList);
        }
        // GET: Admin/GetProduct
        public ActionResult GetProduct()
        {
            var ProductList = db.Dashboard__Chart____88____core__Menus.OrderByDescending(x => x.ID).ToList();
            return View(ProductList);
        }
        // GET: Admin/GetOrder
        public ActionResult GetOrder()
        {
            var ChartList = db.Dashboard__Chart____88____core__Menus.OrderByDescending(x => x.ID).ToList();
            return View(ChartList);
        }
        // GET: Admin/GetOrderBymonth
        public JsonResult GetOrderBymonth()
        {
            db.Configuration.LazyLoadingEnabled = false;

            var OrderList = db.Shop__Commande.GroupBy(e => e.Date__Commande.Value.Month).Select(group => new
            {
                Metric = group.Key,
                Count = group.Count()
            });

            return Json(OrderList, JsonRequestBehavior.AllowGet);
        }
        // Get: Admin/CreateChart
        public ActionResult CreateChart()
        {
            List<core__Menus> MenuList = db.core__Menus.ToList();
            List<Dashboard__Chart> ChartList = db.Dashboard__Chart.ToList();
            ViewData["menus"] = MenuList;
            ViewData["charts"] = ChartList;
            return View();
        }
        // Post: Admin/CreateChart
        [HttpPost]
        public ActionResult CreateChart(Dashboard__Chart____88____core__Menus chartMenu, string Menu, string Chart)
        {
            List<core__Menus> MenuList = db.core__Menus.ToList();
            List<Dashboard__Chart> ChartList = db.Dashboard__Chart.ToList();

            core__Menus cm = MenuList.Find(m => m.Title.Equals(Menu));
            Dashboard__Chart cl = ChartList.Find(c => c.Title.Equals(Chart));

            Dashboard__Chart____88____core__Menus chartMenuu = new Dashboard__Chart____88____core__Menus
            {
                ID = Guid.NewGuid(),
                Title = chartMenu.Title,
                X_Axis = chartMenu.X_Axis,
                Y_Axis = chartMenu.Y_Axis,
                ID____core__Menus = cm.ID_,
                ID____Dashboard__Chart = cl.ID_
            };
            var chartName = "GetClients";
            if (cm.Title == "Commande")
            {
                chartName = "GetOrder";
            }
            if (cm.Title == "Product")
            {
                chartName = "GetProduct";
            }
            if (cm.Title == "Client")
            {
                chartName = "GetClients";
            }
            using (Dbmodel Dbmodel = new Dbmodel())
            {
                try
                {
                    Dbmodel.Dashboard__Chart____88____core__Menus.Add(chartMenuu);
                    Dbmodel.SaveChanges();

                }
                catch (Exception e)
                {
                    return View(e.Message);
                }

                return RedirectToAction(chartName);
            }
        }
        // Get: Admin/IndexChart
        public ActionResult IndexChart()
        {
            var ChartList = db.Dashboard__Chart____88____core__Menus.OrderByDescending(x => x.ID).ToList();
            return View(ChartList);
        }
        // Get: Admin/DeleteChart
        public ActionResult DeleteChart()
        {
            List<Dashboard__Chart> ChartList = db.Dashboard__Chart.ToList();
            // Dashboard__Chart ch = ch.getElementById(c => c.ID_).;

            if (ChartList == null)
            {
                return HttpNotFound();
            }

            // PS.Delete(p);
            //  PS.Commit();
            return RedirectToAction("Index");
        }
        // Post: Admin/QueryBuilder
        public ActionResult QueryBuilder(ViewModel vm)
        {
            var conn = ConfigurationManager.ConnectionStrings["Dbmodel"].ConnectionString;
            if (vm.request != null)
            {
                string laRequete = vm.request;

                using (SqlConnection connection = new SqlConnection(conn))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();

                    string lastString = "";
                    using (SqlCommand command = new SqlCommand(laRequete, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            StringBuilder builder = new StringBuilder();

                            do
                            {
                                int count = reader.FieldCount;
                                while (reader.Read())
                                {
                                    for (int i = 0; i < count; i++)
                                    {
                                        builder.Append(reader.GetValue(i) + " _ ").ToString();
                                    }
                                    builder.Append("\n");
                                }
                            } while (reader.NextResult());
                            lastString = builder.ToString();
                        }
                    }
                    ViewModel kk = new ViewModel { lastString = lastString };
                    return View(kk);
                }
            }
            ViewModel ff = new ViewModel();

            return View(ff);
        }
        // Get: Admin/SelectProperties
        [HttpGet]
        public ActionResult SelectProperties(string id)
        {
            var mymodel = new ViewModel();

            var listP = db.Dashboard__Chart__Property.Where(s => s.ID____Dashboard__Chart.ToString() == id).ToList();
            mymodel.Chart_Property = listP;
            mymodel.Chart_Menus = db.Dashboard__Chart____88____core__Menus.ToList();
            var listDashProp = db.Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property.ToList();

            List<Dashboard__Chart__Property> ListProp = new List<Dashboard__Chart__Property>();
            foreach (var prop in listDashProp)
            {
                var theOne = db.Dashboard__Chart__Property.Where(s => s.ID_ == prop.ID____Dashboard__Chart__Property).FirstOrDefault();

                ListProp.Add(theOne);
            }
            mymodel.selectedProerties = ListProp;

            mymodel.theId = id;
            return View(mymodel);
        }
        // Post: Admin/SelectProperties
        [HttpPost]
        public ActionResult SelectProperties(ViewModel vm, FormCollection collection)
        {
            string test = "";
            if (!string.IsNullOrEmpty(collection["form_coll"]))
            {
                var likk = vm.theId;
                string checkResp = collection["form_coll"];
                var tableau = checkResp.Split(',');
                //string id_dachb=
                foreach (var el in tableau)
                {
                    Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property Chart_Menu_Property = new Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property
                    {
                        ID_ = Guid.NewGuid(),
                        ID____Dashboard__Chart__Property = Guid.Parse(el),
                        //ID____Dashboard__Chart____88____core__Menus = Guid.Parse(vm.theId)
                    };

                    using (Dbmodel Dbmodel = new Dbmodel())
                    {
                        Dbmodel.Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property.Add(Chart_Menu_Property);
                        Dbmodel.SaveChanges();
                        var listDashProp = Dbmodel.Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property.ToList();
                    }
                }
            }
            return RedirectToAction("FillProperties");
        }
        // Get: Admin/FillProperties
        [HttpGet]
        public ActionResult FillProperties(string id)
        {
            var mymodel = new ViewModel();

            var listP = db.Dashboard__Chart__Property.Where(s => s.ID____Dashboard__Chart.ToString() == id).ToList();
            mymodel.Chart_Property = listP;
            mymodel.Chart_Menus = db.Dashboard__Chart____88____core__Menus.ToList();
            var listDashProp = db.Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property.ToList();

            List<Dashboard__Chart__Property> ListProp = new List<Dashboard__Chart__Property>();
            foreach (var prop in listDashProp)
            {
                var theOne = db.Dashboard__Chart__Property.Where(s => s.ID_ == prop.ID____Dashboard__Chart__Property).FirstOrDefault();

                ListProp.Add(theOne);
            }
            mymodel.selectedProerties = ListProp;

            mymodel.theId = id;
            return View(mymodel);
        }
        // Post: Admin/FillProperties
        [HttpPost]
        public ActionResult FillProperties(FormCollection collection)
        {
            if (!string.IsNullOrEmpty(collection["theIds"]))
            {
                if (!string.IsNullOrEmpty(collection["selectedOnes"]))

                {
                    var tableauOne = collection["theIds"].Split(',');
                    var tableauTwo = collection["selectedOnes"].Split(',');
                    for (int i = 0; i < tableauOne.Length; i++)
                    {
                        Guid id = new Guid(tableauOne[i]);
                        var el = db.Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property.Where(s=>s.ID____Dashboard__Chart__Property==id).ToList().FirstOrDefault();
                        el.Value = tableauTwo[i];
                        if (TryUpdateModel(el))
                        {
                            try
                            {
                                db.SaveChanges();

                            }
                            catch (RetryLimitExceededException /* dex */)
                            {
                                //Log the error (uncomment dex variable name and add a line here to write a log.
                                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                            }
                        }
                    }

                }
            }
            return RedirectToAction("ViewProperties");
        }
        // Post: Admin/ViewProperties
        public ActionResult ViewProperties(string id)
        {
            var mymodel = new ViewModel();

            var listDashProp = db.Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property.ToList();
            List<Dashboard__Chart__Property> ListProp = new List<Dashboard__Chart__Property>();
            foreach (var prop in listDashProp)
            {
                var theOne = db.Dashboard__Chart__Property.Where(s => s.ID_ == prop.ID____Dashboard__Chart__Property).FirstOrDefault();

                ListProp.Add(theOne);
            }
            mymodel.selectedProerties = ListProp;
            var thetwo = db.Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property.ToList();
            mymodel.Menu_Chart_Properties = thetwo;
            mymodel.theId = id;
            return View(mymodel);
        }
        // Post: Admin/DeleteData
        [HttpPost]
        public ActionResult DeleteData(Guid ID)
        {
            using (Dbmodel db = new Dbmodel())
            {
                Dashboard__Chart____88____core__Menus ListProp = db.Dashboard__Chart____88____core__Menus.Where(x => x.ID == ID).FirstOrDefault<Dashboard__Chart____88____core__Menus>();
                db.Dashboard__Chart____88____core__Menus.Remove(ListProp);
                db.SaveChanges();
                return Json(new {success = true, message = "Deleted Successfully"}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}