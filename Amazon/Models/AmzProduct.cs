using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Models
{
    [Table("AMZ_PRODUCT")]
    public partial class AmzProduct
    {
        [Key]
        [Column("PROD_ID")]
        public long ProdId { get; set; }
        [Column("CTGY_ID")]
        public int? CtgyId { get; set; }
        [Column("PROD_NME")]
        [StringLength(100)]
        [Unicode(false)]
        public string? ProdNme { get; set; }
        [Column("PROD_QNTY")]
        public int? ProdQnty { get; set; }
        [Column("PROD_DESC")]
        [StringLength(500)]
        [Unicode(false)]
        public string? ProdDesc { get; set; }
        [Column("PROD_PRCE")]
        public double? ProdPrce { get; set; }
        [Column("PROD_QLTY_INT")]
        public int? ProdQltyInt { get; set; }
        [Column("PROD_QLTY_1")]
        [StringLength(500)]
        [Unicode(false)]
        public string? ProdQlty1 { get; set; }
        [Column("PROD_QLTY_2")]
        [StringLength(500)]
        [Unicode(false)]
        public string? ProdQlty2 { get; set; }
        [Column("PROD_QLTY_3")]
        [StringLength(500)]
        [Unicode(false)]
        public string? ProdQlty3 { get; set; }
        [Column("PROD_QLTY_4")]
        [StringLength(500)]
        [Unicode(false)]
        public string? ProdQlty4 { get; set; }
        [Column("PROD_DTE", TypeName = "datetime")]
        public DateTime? ProdDte { get; set; }
        [Column("IS_RVRT")]
        public bool? IsRvrt { get; set; }
        [Column("ACT_IND")]
        public bool? ActInd { get; set; }
        [Column("PROD_IMG")]
        public byte[]? ProdImg { get; set; }

        [ForeignKey("CtgyId")]
        [InverseProperty("AmzProducts")]
        public virtual AmzCategory? Ctgy { get; set; }
    }
}
