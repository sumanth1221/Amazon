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

    public class UserController : Controller
    {
        private readonly AmazonContext _context;
        public UserController(AmazonContext context)
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
                List<UserViewModel> UserViewModel = new List<UserViewModel>();
                var UserViewModels = (from p in _context.AmzUsers
                                          join r in _context.AmzUserRoles on p.UserRoleId equals r.UserRoleId
                                      select new
                                          {
                                              p.UserNme,
                                              p.UserId,
                                              p.UserEmail,
                                              p.UserPhNo,
                                              p.ActInd,
                                              r.UserRoleId,
                                              r.UserRoleCode
                                          }
                              ).ToList();

                foreach (var o in UserViewModels)
                {
                    UserViewModel.Add(new UserViewModel
                    {
                        UserNme = o.UserNme,
                        UserId = o.UserId,
                        UserEmail = o.UserEmail,
                        UserPhNo = o.UserPhNo,
                        ActInd = o.ActInd,
                        UserRoleId = o.UserRoleId,
                        UserRoleCode = o.UserRoleCode
                    });
                }
                return View(UserViewModel);
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
                var repo = new UserRoleRepository();
                var UserRoleList = repo.CreateUserRoles();
                return View(UserRoleList);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        public IActionResult Create(UserViewModel userView)
        {
            AmzUser User = new AmzUser();

            User.UserRoleId = userView.SelectedUserRoleId;
            User.UserNme = userView.UserNme;
            User.UserEmail = userView.UserEmail;
            User.UserPhNo = userView.UserPhNo;
            User.PassWord = userView.PassWord;
            User.ActInd = true;
            _context.AmzUsers.Add(User);
            _context.SaveChanges();
            TempData["Message"] = "File successfully uploaded to Database";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            AmzUser AmzUser = _context.AmzUsers.Where(a => a.UserId.Equals(id)).FirstOrDefault();
            _context.AmzUsers.Remove(AmzUser);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult edit(int id)
        {
            AmzUser AmzUser = _context.AmzUsers.Where(p => p.UserId == id).FirstOrDefault();
            return View(AmzUser);
        }

        [HttpPost]
        public IActionResult edit(AmzUser UserModel)
        {
            _context.Attach(UserModel);
            _context.Entry(UserModel).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
