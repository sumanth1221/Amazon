using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Amazon.Data;
using Amazon.Models;
using Amazon.ViewModels;

namespace Amazon.Repositories
{
    public class DepartmentRepository
    {
        public DeptCtgyViewModel CreateDepartment()
        {
           
            var dRepo = new DepartmentRepository();
            var department = new DeptCtgyViewModel()
            {
                Department = dRepo.GetDepartments()
                
            };
            return department;
        }

        public ProductViewModel productViewModel()
        {
            var cRepo = new CategoryRepository();
            var dRepo = new DepartmentRepository();
            var product = new ProductViewModel()
            {
                Department = dRepo.GetDepartments(),
                Category = cRepo.GetCategories()
            };
            return product;
        }
        public IEnumerable<SelectListItem> GetDepartments()
        {
            using (var context = new AmazonContext())
            {
                List<SelectListItem> departments = context.AmzDepartments.AsNoTracking()
                    .OrderBy(n => n.DeptNme)
                    .Where(n => n.ActInd == true)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.DeptId.ToString(),
                            Text = n.DeptNme
                        }).ToList();
                var Departmenttip = new SelectListItem()
                {
                    Value = null,
                    Text = "Select Department"
                };
                departments.Insert(0, Departmenttip);
                return new SelectList(departments, "Value", "Text");
            }
        }
    }
}
