using Microsoft.AspNetCore.Mvc.Rendering;

namespace Amazon.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public int? UserRoleId { get; set; }
        public string? UserNme { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhNo { get; set; }
        public bool? ActInd { get; set; }
        public string? PassWord { get; set; }
        public string? UserRoleCode { get; set; }

        public int SelectedUserRoleId { get; set; }
        public IEnumerable<SelectListItem> UserRole { get; set; }
    }
}
