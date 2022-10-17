using Amazon.Data;
using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Amazon.Controllers
{
   
    public class DepartmentController : Controller
    {
        private readonly AmazonContext _context;
        public DepartmentController(AmazonContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var CustID = JsonConvert.DeserializeObject(HttpContext.Session?.GetString("SessionKey") ?? "");
            var CustRole = (string)JsonConvert.DeserializeObject(HttpContext.Session?.GetString("SessionRole") ?? "");
            if (CustID != null && CustRole == Enums.UserRoleEnum.Admin.ToString())
            {
                IEnumerable<AmzDepartment> department = _context.AmzDepartments.ToList();
                return View(department);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            var CustID = JsonConvert.DeserializeObject(HttpContext.Session?.GetString("SessionKey") ?? "");
            var CustRole = (string)JsonConvert.DeserializeObject(HttpContext.Session?.GetString("SessionRole") ?? "");
            if (CustID != null && CustRole == Enums.UserRoleEnum.Admin.ToString())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }


        [HttpPost]
        public IActionResult Create(AmzDepartment departmentmodel)
        {
            AmzDepartment department = new AmzDepartment();

            department.DeptNme = departmentmodel.DeptNme;
            department.DeptDscr = departmentmodel.DeptDscr;
            department.ActInd = true;
            _context.AmzDepartments.Add(department);
            _context.SaveChanges();
            TempData["Message"] = "File successfully uploaded to Database";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            AmzDepartment AmzDepartment = _context.AmzDepartments.Where(a => a.DeptId.Equals(id)).FirstOrDefault();
            _context.AmzDepartments.Remove(AmzDepartment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult edit(int id)
        {
            AmzDepartment AmzDepartment = _context.AmzDepartments.Where(p => p.DeptId == id).FirstOrDefault();
            return View(AmzDepartment);
        }

        [HttpPost]
        public IActionResult edit(AmzDepartment DepartmentModel)
        {
            _context.Attach(DepartmentModel);
            _context.Entry(DepartmentModel).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
