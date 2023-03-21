using Suppliers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Suppliers.Controllers
{

    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        public HomeController()
        {
            this._repository = new Repository();
        }
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }


        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public ActionResult savecompany(SupplierEntity model)
        {
            _repository.AddSupplier(model);
            TempData["Message"] = "Successfully saved";
            return RedirectToAction("Index");

        }


        [AllowAnonymous]
        public ActionResult SearchCompany(SupplierEntity model)
        {
            var verify = _repository.GetSupplierByCompany(model.Name);

            if (verify == null)
            {
                TempData["Message"] = string.Format("Could not find the Company");
            }
            else
            {
                SupplierEntity reg = new SupplierEntity();
                reg.TelephoneNO = verify.TelephoneNO;               
                ViewBag.Data = reg;
                ViewBag.tel = verify.TelephoneNO;
                ViewBag.name = "";
                return View("Index");

                }       
            return RedirectToAction("Index", "Home");
        }


    }
}