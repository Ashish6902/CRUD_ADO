using CRUD_ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CRUD_ADO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBcontext dbcontext = new DBcontext();
            List<Student> obj = dbcontext.GetData();
            return View(obj);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Student stu)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    DBcontext dBcontext = new DBcontext();
                    bool check = dBcontext.createData(stu);
                    if (check == true)
                    {
                        TempData["InsertMessage"] = "Data Has been Insrted";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            DBcontext dBcontext = new DBcontext();
            var row = dBcontext.GetData().Find(model=>model.ID == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(int id,Student stu)
        {
            
                if (ModelState.IsValid == true)
                {
                    DBcontext dBcontext = new DBcontext();
                    bool check = dBcontext.UpdateData(stu);
                    if (check == true)
                    {
                        TempData["UpdateMessage"] = "Data Has been updated";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
        }
        public ActionResult Delete(int id)
        {
            DBcontext dBcontext = new DBcontext();
            var row = dBcontext.GetData().Find(model => model.ID == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int id, Student stu)
        {

            
                DBcontext dBcontext = new DBcontext();
                bool check = dBcontext.DeletData(stu);
                if (check == true)
                {
                    TempData["DeleteMessage"] = "Data Has been updated";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            
            return View();
        }
        public ActionResult Details(int id)
        {
            DBcontext dBcontext = new DBcontext();
            var row = dBcontext.GetData().Find(model => model.ID == id);
            return View(row);
        }
        
        public ActionResult Search(int id)
        {
            DBcontext dbcontext = new DBcontext();
            List<Student> obj = dbcontext.SearchData(id);
            return View(obj);
        }
    }
}