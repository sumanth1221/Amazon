using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Models
{
    [Table("AMZ_USER")]
    public partial class AmzUser
    {
        [Key]
        [Column("USER_ID")]
        public int UserId { get; set; }
        [Column("USER_ROLE_ID")]
        public int? UserRoleId { get; set; }
        [Column("USER_NME")]
        [StringLength(50)]
        [Unicode(false)]
        public string? UserNme { get; set; }
        [Column("USER_EMAIL")]
        [StringLength(50)]
        [Unicode(false)]
        public string? UserEmail { get; set; }
        [Column("USER_PH_NO")]
        [StringLength(50)]
        [Unicode(false)]
        public string? UserPhNo { get; set; }
        [Column("ACT_IND")]
        public bool? ActInd { get; set; }
        [Column("PASS_WORD")]
        [StringLength(50)]
        [Unicode(false)]
        public string? PassWord { get; set; }
        [Column("USER_ICON")]
        public byte[]? UserIcon { get; set; }

        [ForeignKey("UserRoleId")]
        [InverseProperty("AmzUsers")]
        public virtual AmzUserRole? UserRole { get; set; }
    }
}
