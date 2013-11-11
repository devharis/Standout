using System;
using System.Web.Mvc;
using SWTS.Filters;
using SWTS.Models;
using SWTS.Models.Interface;

namespace SWTS.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        private readonly ISupplierService _service;

        public HomeController()
            : this(new SupplierService())
        {

        }

        public HomeController(ISupplierService service)
        {
            this._service = service;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View("../Account/Login");
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult LoadMenu()
        {
            try
            {
                var model = this._service.GetAllSuppliers();
                return PartialView("_Menu", model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                TempData["UserMessage"] = "Error, all suppliers couldn't be retrived";
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Supplier(int id)
        {
            try
            {
                var model = this._service.GetSupplier(id);
                return View("Supplier", model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                TempData["UserMessage"] = "Error, supplier couldn't be retrived";
                return View("Error");   
            }
        }

        [HttpGet]
        public ActionResult AddSupplier()
        {
            var model = new Supplier();
            return View("AddSupplier", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSupplier(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    supplier = this._service.AddSupplier(supplier);
                    TempData["UserMessage"] = "Supplier added successfully";
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                TempData["UserMessage"] = "Error, couldn't add user";
                return View("Error");
            }
            return RedirectToAction("Supplier", new { id = supplier.SupplierId});
        }

        [HttpGet]
        public ActionResult EditSupplier(int id)
        {
            try
            {
                var model = this._service.GetSupplier(id);
                TempData["UserMessage"] = "Supplier retrived successfully";
                return PartialView("_EditSupplier", model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                TempData["UserMessage"] = "Error, supplier couldn't be retrived";
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSupplier(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._service.Update(supplier);
                    TempData["UserMessage"] = "Supplier updated successfully";
                    
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                TempData["UserMessage"] = "Error, supplier couldn't be updated";
                return View("Error");
            }
            return RedirectToAction("Supplier", new { id = supplier.SupplierId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSupplier(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["UserMessage"] = "Supplier deleted successfully";
                    this._service.DeleteSupplier(id);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                TempData["UserMessage"] = "Error, supplier couldn't be deleted";
                return View("Error");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
