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
        private ISupplierService _service;

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
            return View("../Account/Login");
        }

        [HttpGet]
        public ActionResult Suppliers()
        {
            // Query all suppliers
            return View("Suppliers");
        }

        [HttpGet]
        public ActionResult Supplier(int id)
        {
            // Query specific supplier table
            return View("Supplier");
        }

        [HttpGet]
        public ActionResult AddSupplier()
        {
            // Query specific supplier table
            var model = new Supplier();
            return View("Supplier", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSupplier(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Insert supplier
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return View("Error");
            }
            return View("Supplier");
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult EditSupplier(int id)
        {
            // Get supplier and display
            return View("Supplier");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSupplier(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Insert edited supplier
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return View("Error");
            }
            return View("Supplier");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSupplier(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Delete selected supplier
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return View("Error");
            }
            return View("Supplier");
        }
    }
}
