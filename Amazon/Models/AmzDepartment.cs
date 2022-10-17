using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Models
{
    [Table("AMZ_DEPARTMENT")]
    public partial class AmzDepartment
    {
        public AmzDepartment()
        {
            AmzCategories = new HashSet<AmzCategory>();
        }

        [Key]
        [Column("DEPT_ID")]
        public int DeptId { get; set; }
        [Column("DEPT_NME")]
        [StringLength(100)]
        [Unicode(false)]
        public string? DeptNme { get; set; }
        [Column("DEPT_DSCR")]
        [StringLength(500)]
        [Unicode(false)]
        public string? DeptDscr { get; set; }
        [Column("ACT_IND")]
        public bool? ActInd { get; set; }
        [Column("DEPT_ICON")]
        [MaxLength(1)]
        public byte[]? DeptIcon { get; set; }

        [InverseProperty("Dept")]
        public virtual ICollection<AmzCategory> AmzCategories { get; set; }
    }
}
