using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Web;
using Amazon.ViewModels;
using Amazon.Data;
using Newtonsoft.Json;
using Amazon.Models;
using Amazon.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Controllers
{
    public class ProductController : Controller
    {
        private readonly AmazonContext _context;
        public ProductController(AmazonContext context)
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
                return View(GetProductViewModels());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }


        [HttpGet]
        public List<ProductViewModel> GetProductViewModels()
        {
            int CustId = int.Parse((string)JsonConvert.DeserializeObject(HttpContext.Session?.GetString("SessionKey") ?? ""));
            List<ProductViewModel> productViewModel = new List<ProductViewModel>();
            var ProductViewModels = (from p in _context.AmzDepartments
                                     join r in _context.AmzCategories on p.DeptId equals r.DeptId
                                     join q in _context.AmzProducts on r.CtgyId equals q.CtgyId
                                    select new
                                    {
                                        q.ProdId,
                                        p.DeptNme,
                                        r.CtgyNme,
                                        q.ProdNme,
                                        q.ProdPrce,
                                        q.ActInd,
                                        q.ProdQnty,
                                        q.ProdDesc,
                                        q.ProdImg
                                    }
                          ).ToList();

            foreach (var o in ProductViewModels)
            {
                productViewModel.Add(new ProductViewModel
                {
                    ProdId = o.ProdId,
                    ProdDesc = o.ProdDesc,
                    ProdQnty = o.ProdQnty,
                    ProdPrce = o.ProdPrce,
                    ProdNme = o.ProdNme,   
                    CtgyNme = o.CtgyNme,
                    DeptNme = o.DeptNme,
                    ProdImg = o.ProdImg,
                    ActInd = o.ActInd
                });
            }
            return productViewModel;
        }

        [HttpGet]
        public ActionResult Create()
        {
            var CustID = JsonConvert.DeserializeObject(HttpContext.Session?.GetString("SessionKey") ?? "");
            var CustRole = (string)JsonConvert.DeserializeObject(HttpContext.Session?.GetString("SessionRole") ?? "");
            if (CustID != null && CustRole == Enums.UserRoleEnum.Admin.ToString())
            {
                var repo = new DepartmentRepository();
                var DepartmentList = repo.productViewModel();
                return View(DepartmentList);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }


        [HttpPost]
        public async Task<IActionResult> Create(IFormFile file, ProductViewModel productmodel)
        {
            AmzProduct product = new AmzProduct();

            if (file != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var extension = Path.GetExtension(file.FileName);

                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    product.ProdImg = dataStream.ToArray();
                }
            }
            product.ProdNme = productmodel.ProdNme;
            product.ProdPrce = productmodel.ProdPrce;
            product.ActInd = true;
            product.ProdDte = DateTime.Now;
            product.ProdQnty = productmodel.ProdQnty;
            product.ProdDesc = productmodel.ProdDesc;
            product.CtgyId = productmodel.SelectedCategoryId;

            _context.AmzProducts.Add(product);
            _context.SaveChanges();
            TempData["Message"] = "File successfully uploaded to Database";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            AmzProduct amzProduct = _context.AmzProducts.Where(a => a.ProdId.Equals(id)).FirstOrDefault();
            _context.AmzProducts.Remove(amzProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult edit(int id)
        {
            AmzProduct amzproduct = _context.AmzProducts.Where(p => p.ProdId == id).FirstOrDefault();
            return View(amzproduct);
        }
        [HttpPost]
        public IActionResult edit(AmzProduct productModel)
        {
            _context.Attach(productModel);
            _context.Entry(productModel).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult GetCategories( int id) 
        {
            if (id != 0)
            {
                var repo = new CategoryRepository();
                IEnumerable<SelectListItem> SubCategories = repo.GetCategories(id);
                return Json(SubCategories);
            }
            return null;
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var CustID = JsonConvert.DeserializeObject(HttpContext.Session?.GetString("SessionKey") ?? "");
            var CustRole = (string)JsonConvert.DeserializeObject(HttpContext.Session?.GetString("SessionRole") ?? "");
            if (CustID != null && CustRole == Enums.UserRoleEnum.Admin.ToString())
            {
                return View(GetProductByIdViewModels(id));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }


        [HttpGet]
        public List<ProductViewModel> GetProductByIdViewModels(int id)
        {
            int CustId = int.Parse((string)JsonConvert.DeserializeObject(HttpContext.Session?.GetString("SessionKey") ?? ""));
            List<ProductViewModel> productViewModel = new List<ProductViewModel>();
            var ProductViewModels = (from p in _context.AmzDepartments
                                     join r in _context.AmzCategories on p.DeptId equals r.DeptId
                                     join q in _context.AmzProducts on r.CtgyId equals q.CtgyId
                                     where q.ProdId== id
                                     select new
                                     {
                                         q.ProdId,
                                         p.DeptNme,
                                         r.CtgyNme,
                                         q.ProdNme,
                                         q.ProdPrce,
                                         q.ActInd,
                                         q.ProdQnty,
                                         q.ProdDesc,
                                         q.ProdImg
                                     }
                          ).ToList();

            foreach (var o in ProductViewModels)
            {
                productViewModel.Add(new ProductViewModel
                {
                    ProdId = o.ProdId,
                    ProdDesc = o.ProdDesc,
                    ProdQnty = o.ProdQnty,
                    ProdPrce = o.ProdPrce,
                    ProdNme = o.ProdNme,
                    CtgyNme = o.CtgyNme,
                    DeptNme = o.DeptNme,
                    ProdImg = o.ProdImg,
                    ActInd = o.ActInd
                });
            }
            return productViewModel;
        }


    }
}



