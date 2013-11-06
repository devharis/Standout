using System;
using System.Web.Mvc;
using SWTS.Models;

namespace SWTS.Controllers
{
    [Authorize]
    public class IndexController : Controller
    {

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View("Index");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Suppliers");
            }
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View("Index", model);
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
