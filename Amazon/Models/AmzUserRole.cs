using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Models
{
    [Table("AMZ_USER_ROLE")]
    public partial class AmzUserRole
    {
        public AmzUserRole()
        {
            AmzUsers = new HashSet<AmzUser>();
        }

        [Key]
        [Column("USER_ROLE_ID")]
        public int UserRoleId { get; set; }
        [Column("USER_ROLE_CODE")]
        [StringLength(50)]
        [Unicode(false)]
        public string? UserRoleCode { get; set; }
        [Column("ACT_IND")]
        public bool? ActInd { get; set; }

        [InverseProperty("UserRole")]
        public virtual ICollection<AmzUser> AmzUsers { get; set; }
    }
}
