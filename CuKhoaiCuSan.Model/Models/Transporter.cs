namespace CuKhoaiCuSan.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transporter")]
    public partial class Transporter
    {
        [Key]
        [Column(Order = 0)]
        public Guid TransporterID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string TransporterCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string TransporterName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}
