using Amazon.Data;
using Amazon.Models;
using Amazon.Repositories;
using Amazon.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;

namespace Amazon.Controllers
{

    public class CategoryController : Controller
    {
        private readonly AmazonContext _context;
        public CategoryController(AmazonContext context)
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
                List<DeptCtgyViewModel> deptCtgyViewModel = new List<DeptCtgyViewModel>();
                var deptCtgyViewModels = (from p in _context.AmzDepartments
                                         join r in _context.AmzCategories on p.DeptId equals r.DeptId
                                         select new
                                         {
                                             p.DeptNme,
                                             r.CtgyId,
                                             r.CtgyNme,
                                             r.CtgyDscr,
                                             r.ActInd
                                         }
                              ).ToList();

                foreach (var o in deptCtgyViewModels)
                {
                    deptCtgyViewModel.Add(new DeptCtgyViewModel
                    {
                        CtgyId = o.CtgyId,
                        DeptNme = o.DeptNme,
                        CtgyNme = o.CtgyNme,
                        CtgyDscr = o.CtgyDscr,
                        ActInd = o.ActInd
                    });
                }
                return View(deptCtgyViewModel);
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
                var repo = new DepartmentRepository();
                var DepartmentList = repo.CreateDepartment();
                return View(DepartmentList);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        public IActionResult Create(DeptCtgyViewModel categorymodel)
        {
            AmzCategory category = new AmzCategory();

            category.DeptId = categorymodel.SelectedDepartmentId;
            category.CtgyNme = categorymodel.CtgyNme;
            category.CtgyDscr = categorymodel.CtgyDscr;
            category.ActInd = true;
            _context.AmzCategories.Add(category);
            _context.SaveChanges();
            TempData["Message"] = "File successfully uploaded to Database";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            AmzCategory AmzCategory = _context.AmzCategories.Where(a => a.CtgyId.Equals(id)).FirstOrDefault();
            _context.AmzCategories.Remove(AmzCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult edit(int id)
        {
            AmzCategory AmzCategory = _context.AmzCategories.Where(p => p.CtgyId == id).FirstOrDefault();
            return View(AmzCategory);
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
