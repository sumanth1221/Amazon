using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Amazon.Data;
namespace Amazon.Repositories
{
    public class CategoryRepository
    {
        public IEnumerable<SelectListItem> GetCategories()
        {
            List<SelectListItem> categories = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "Select Category First"
                }
            };
            return categories;
        }

        public IEnumerable<SelectListItem> GetCategories(int DeptId)
        {
            using (var context = new AmazonContext())
            {
                IEnumerable<SelectListItem> categories = context.AmzCategories.AsNoTracking()
                    .OrderBy(n => n.CtgyNme)
                    .Where(n => n.DeptId == DeptId && n.ActInd == true)
                    .Select(n =>
                       new SelectListItem
                       {
                           Value = n.CtgyId.ToString(),
                           Text = n.CtgyNme
                       }).ToList();
                return new SelectList(categories, "Value", "Text");
            }
        }
    }
}

