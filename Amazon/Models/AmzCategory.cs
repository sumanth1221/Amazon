using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Models
{
    [Table("AMZ_CATEGORY")]
    public partial class AmzCategory
    {
        public AmzCategory()
        {
            AmzProducts = new HashSet<AmzProduct>();
        }

        [Key]
        [Column("CTGY_ID")]
        public int CtgyId { get; set; }
        [Column("DEPT_ID")]
        public int? DeptId { get; set; }
        [Column("CTGY_NME")]
        [StringLength(100)]
        [Unicode(false)]
        public string? CtgyNme { get; set; }
        [Column("CTGY_DSCR")]
        [StringLength(500)]
        [Unicode(false)]
        public string? CtgyDscr { get; set; }
        [Column("ACT_IND")]
        public bool? ActInd { get; set; }
        [Column("CTGY_ICON")]
        [MaxLength(1)]
        public byte[]? CtgyIcon { get; set; }

        [ForeignKey("DeptId")]
        [InverseProperty("AmzCategories")]
        public virtual AmzDepartment? Dept { get; set; }
        [InverseProperty("Ctgy")]
        public virtual ICollection<AmzProduct> AmzProducts { get; set; }
    }
}
