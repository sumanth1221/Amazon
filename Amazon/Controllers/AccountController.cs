using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Amazon.Data;
using Amazon.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Amazon.ViewModels;
using Amazon.Enums;

namespace Amazon.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {

       // private readonly ILogger<AccountController> _logger;

        public int SessionID = 0;
        public const string SessionKey = "_Key";
        public string SessionName = "UserName";

        private readonly AmazonContext _context;

        public AccountController(AmazonContext context)
        {
            _context = context;
        }
        //[Route("")]
        //[Route("index")]
        //[Route("~/")]
        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AmzUser UserData)
        {
            if (ModelState.IsValid)
            {
                using (AmazonContext context = new AmazonContext())
                {
                    var obj = context.AmzUsers.Where(a => a.UserEmail.Equals(UserData.UserEmail) && a.PassWord.Equals(UserData.PassWord) && a.ActInd.Equals(true)).FirstOrDefault();
                    if (obj != null)
                    {  
                        var roles =context.AmzUserRoles.Where(a => a.UserRoleId.Equals(obj.UserRoleId)).FirstOrDefault();
                        
                        HttpContext.Session.SetString("SessionRole", JsonConvert.SerializeObject(roles.UserRoleCode));
                        HttpContext.Session.SetString("SessionKey", JsonConvert.SerializeObject(obj.UserId.ToString()));
                        return RedirectToAction("Index", "Items");
                        
                    }
                    else
                    {
                        ViewBag.error = "Invalid Username or Password";
                        return View("Login");
                    }
                }
            }
            return View(UserData);
        }


        [Route("Logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("SessionKey");
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [Route("Signup")]
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [Route("Signup")]
        [HttpPost]
        public ActionResult Signup(SignupViewModel signupviewmodel)
        {
            var obj = _context.AmzUsers.Where(a => a.UserEmail.Equals(signupviewmodel.UserEmail)).FirstOrDefault();
            if (obj == null)
            {
                AmzUser Users = new AmzUser();
                AmzUserRole UserRoles = _context.AmzUserRoles.Where(p => p.UserRoleCode == UserRoleEnum.Customer.ToString()).FirstOrDefault();
                Users.UserRoleId = UserRoles.UserRoleId;
                Users.ActInd = true;
                Users.UserEmail = signupviewmodel.UserEmail;
                Users.UserNme = signupviewmodel.UserNme;
                Users.UserPhNo = signupviewmodel.UserPhNo;
                Users.PassWord = signupviewmodel.PassWord;
                _context.Attach(Users);
                _context.Entry(Users).State = EntityState.Added;
                _context.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.error = "Email Already Exists";
                return View("Signup");
            }
        }

    }
}
