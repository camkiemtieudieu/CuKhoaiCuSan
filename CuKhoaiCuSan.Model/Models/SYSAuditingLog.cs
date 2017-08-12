namespace CuKhoaiCuSan.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SYSAuditingLog")]
    public partial class SYSAuditingLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int SYSAuditingLogID { get; set; }

        [StringLength(50)]
        public string ActionName { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}
