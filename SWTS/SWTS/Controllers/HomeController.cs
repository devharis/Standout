using System;
using System.Web.Mvc;
using SWTS.Filters;
using SWTS.Models;
using SWTS.Models.Interface;

namespace SWTS.Controllers
{
    /// <summary>
    ///  This class main task is to take care of the controller actions for suppliers.
    ///  The class uses TempData[] for success and error messages to display for the user
    /// </summary>

    [Authorize]
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        // fields
        private readonly ISupplierService _service;

        public HomeController()
            : this(new SupplierService())
        {

        }

        public HomeController(ISupplierService service)
        {
            this._service = service;
        }

       /**
        * GET: Login/Account
        * 
        * Method which renders a login view
        * 
        * @params
        * @returns View Account/Login
        */
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View("../Account/Login");
        }

        /**
         * GET: /Home/Index
         * 
         * Method which renders a startpage view after login
         * 
         * @params
         * @returns View Home/Index
         */
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }
        #region READ SUPPLIERS
        /**
         * GET: /Home/_Menu
         * 
         * Method which queries all suppliers,
         * returns them in a partialview and 
         * builds up a menu section
         * 
         * @params
         * @returns View Home/_Menu
         */
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

        /**
         * GET: /Home/Supplier
         * 
         * Method which queries specific supplier,
         * Renders values in a Supplier view
         * 
         * @params int id
         * @returns View Home/Supplier
         */
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
        #endregion
        #region ADD SUPPLIER
        /**
         * GET: /Home/AddSupplier
         * 
         * Method which creates a new Supplier model
         * Returns model with a Add view
         * 
         * @params
         * @returns View Home/AddSupplier
         */
        [HttpGet]
        public ActionResult AddSupplier()
        {
            var model = new Supplier();
            return View("AddSupplier", model);
        }

        /**
         * POST: /Home/AddSupplier
         * 
         * Method which triggers when user tries
         * to submit a new supplier.
         * 
         * @params Supplier supplier
         * @returns RedirectToAction Supplier
         */
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
        #endregion
        #region EDIT SUPPLIER
        /**
         * GET: /Home/EditSupplier
         * 
         * Method which queries specific supplier
         * and renders it with a Edit partialview.
         * 
         * @params int id
         * @returns PartialView _EditSupplier
         */
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
        
        /**
         * POST: /Home/EditSupplier
         * 
         * Method which triggers when user tries
         * to submit the edited supplier.
         * 
         * @params Supplier supplier
         * @returns RedirectToAction Home/Supplier
         */
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
        #endregion
        #region DELETE SUPPLIER
        /**
         * POST: /Home/DeleteSupplier
         * 
         * Method which deletes selected user by 
         * suppliers id.
         * 
         * @params int id
         * @returns RedirectToAction Home/Supplier
         */
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
        #endregion
    }
}
