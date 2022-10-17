using System.ComponentModel.DataAnnotations;

namespace Amazon.ViewModels
{
    public class SignupViewModel
    {
        public int UserId { get; set; }
        public string? UserNme { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Eamil")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        public string? UserEmail { get; set; }
        public string? UserPhNo { get; set; }
        public bool? ActInd { get; set; }
        public string? PassWord { get; set; }
        public int UserRoleId { get; set; }
        public string? UserRoleCode { get; set; }
        public string? UserStsCode { get; set; }

    }
}
