using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Amazon.Data;
using Amazon.Models;
using Amazon.ViewModels;

namespace Amazon.Repositories
{
    public class UserRoleRepository
    {
        public UserViewModel CreateUserRoles()
        {

            var dRepo = new UserRoleRepository();
            var UserRole = new UserViewModel()
            {
                UserRole = dRepo.GetUserRoles()

            };
            return UserRole;
        }
        public IEnumerable<SelectListItem> GetUserRoles()
        {
            using (var context = new AmazonContext())
            {
                List<SelectListItem> UserRoles = context.AmzUserRoles.AsNoTracking()
                    .OrderBy(n => n.UserRoleCode)
                    .Where(n => n.ActInd == true)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.UserRoleId.ToString(),
                            Text = n.UserRoleCode
                        }).ToList();
                var UserRoletip = new SelectListItem()
                {
                    Value = null,
                    Text = "Select UserRole"
                };
                UserRoles.Insert(0, UserRoletip);
                return new SelectList(UserRoles, "Value", "Text");
            }
        }
    }
}
