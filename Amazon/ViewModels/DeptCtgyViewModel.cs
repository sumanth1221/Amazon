using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Amazon.ViewModels
{
    public class DeptCtgyViewModel
    {
        public int DeptId { get; set; }
        public string? DeptNme { get; set; }
        public int CtgyId { get; set; }
        public string? CtgyNme { get; set; }
        public string? CtgyDscr { get; set; }
        public bool? ActInd { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int SelectedCategoryId { get; set; }
        public IEnumerable<SelectListItem> Category { get; set; }


        [Required]
        [Display(Name = "Department")]
        public int SelectedDepartmentId { get; set; }
        public IEnumerable<SelectListItem> Department { get; set; }
    }
}
