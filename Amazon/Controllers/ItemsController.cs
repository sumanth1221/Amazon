using Amazon.Data;
using Amazon.Repositories;
using Amazon.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Amazon.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AmazonContext _context;
        public ItemsController(AmazonContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(string Search)
        {
            if(Search != null)
            {
                return View(GetProductViewModels(Search));
            }
            else
                return View(GetProductViewModels());

        }


        [HttpGet]
        public List<ProductViewModel> GetProductViewModels(string Searchby)
        {
            var repo = new DepartmentRepository();
            var DepartmentList = repo.productViewModel();
            ViewBag.Department = DepartmentList.Department;

            List<ProductViewModel> productViewModel = new List<ProductViewModel>();
            var ProductViewModels = (from p in _context.AmzDepartments
                                     join r in _context.AmzCategories on p.DeptId equals r.DeptId
                                     join q in _context.AmzProducts on r.CtgyId equals q.CtgyId
                                     where q.ProdNme.Contains(Searchby) || q.ProdDesc.Contains(Searchby)
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
                    ActInd = o.ActInd,
                    Category = DepartmentList.Category,
                    Department = DepartmentList.Department
                }) ;
            }
            return productViewModel;
        }
   

    [HttpGet]
    public List<ProductViewModel> GetProductViewModels()
    {
        var repo = new DepartmentRepository();
        var DepartmentList = repo.productViewModel();
        ViewBag.Department = DepartmentList.Department;

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
                ActInd = o.ActInd,
                Category = DepartmentList.Category,
                Department = DepartmentList.Department
            });
        }
        return productViewModel;
    }
}
}
