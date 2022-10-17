using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Amazon.ViewModels
{
    public class ProductViewModel
    {
        public int DeptId { get; set; }
        public string? DeptNme { get; set; }
        public int CtgyId { get; set; }
        public string? CtgyNme { get; set; }
        [Key]
        public long ProdId { get; set; }
        public string? ProdNme { get; set; }
        public int? ProdQnty { get; set; }
        public string? ProdDesc { get; set; }
        public double? ProdPrce { get; set; }
        public int? ProdQltyInt { get; set; }
        public string? ProdQlty1 { get; set; }
        public string? ProdQlty2 { get; set; }
        public string? ProdQlty3 { get; set; }
        public string? ProdQlty4 { get; set; }
        public DateTime? ProdDte { get; set; }
        public bool? IsRvrt { get; set; }
        public bool? ActInd { get; set; }
        public byte[]? ProdImg { get; set; }

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
