namespace CDTH17.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewQuyen")]
    public partial class viewQuyen
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDRole { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string RoleName { get; set; }
    }
}
