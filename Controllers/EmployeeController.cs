using EmpManagementSystem.Models;
using EmpManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace EmpManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        //parameter
        private ICRUD cRUD;
        private IFileUpload fileUpload;
        //constructor
        public EmployeeController(ICRUD cRUD)
        {
            this.cRUD = cRUD;
            this.fileUpload = new FileUpload();
        }

        //HTTP Get request
        public IActionResult Create()
        { //Creating new employee
            var empnew = new Employee();
            empnew.Id = cRUD.GetMaxId();
            return View(empnew);
        }

        [HttpPost]
        public async  Task<ActionResult> Create(Employee obj,IFormFile file)
        {
            if(ModelState.IsValid)
            {
                if(await fileUpload.UploadFile(file))
                {
                    obj.ImageName = fileUpload.FileName;
                    cRUD.AddEmployee(obj);
                    return RedirectToRoute(new { Action = "Index", Controller = "Employee" });
                }
                else
                {
                    ViewBag.ErrorMessage = "File Upload failed!";
                    return View(obj);
                }
            }
            else
            {
                ViewBag.Message = "Error adding employee to the database.";
                return View(obj);
            }

        }
           
            public IActionResult Index()
        {
            // 
            IndexViewModel model = new IndexViewModel();
            model.Employees = cRUD.GetEmployees();
            return View(model);
        }
        public IActionResult Details(int? id)
        {
            var  emp=cRUD.GetEmployee(id);
            if(emp==null)
            {
                return NotFound();
            }
            return View(emp);
        }

        //get
        public IActionResult Edit(int id)
        {
            var emp=cRUD.GetEmployee(id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit (Employee obj)
        {
            if(ModelState.IsValid)
            {
                cRUD.UpdateEmployee(obj);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Error editing employee";
                return View(obj);
            }

           
        }
        public IActionResult Delete(int id)
        {
            cRUD.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
