namespace LibraryApp.Entities.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yetkili")]
    public partial class Yetkili
    {
        public int YetkiliID { get; set; }

        [Required(ErrorMessage = "Yetkili ad� bo� ge�ilemez")]
        [StringLength(50)]
        public string YetkiliAd { get; set; }

        [Required(ErrorMessage = "Yetkili �ifresi bo� ge�ilemez")]
        [StringLength(50)]
        public string YetkiliSifre { get; set; }

        public bool? Silindi { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? SonGirisTarihi { get; set; }
    }
}
