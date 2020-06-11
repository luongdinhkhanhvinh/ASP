namespace CDTH17.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        public int MaHD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHD { get; set; }

        [StringLength(30)]
        public string Hoten { get; set; }

        [StringLength(30)]
        public string DiaChi { get; set; }

        [StringLength(12)]
        public string DienThoai { get; set; }

        [StringLength(50)]
        public string EMail { get; set; }
    }
}
