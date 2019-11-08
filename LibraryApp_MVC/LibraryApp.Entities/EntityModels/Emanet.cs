namespace LibraryApp.Entities.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Emanet")]
    public partial class Emanet
    {
        public int EmanetID { get; set; }

        public int? OgrenciID { get; set; }

        public int? KitapID { get; set; }

        [Required(ErrorMessage = "Öðrenci numarasý boþ geçilemez")]
        public int? OgrNo { get; set; }

        [Required(ErrorMessage = "Kitap numarasý boþ geçilemez")]
        public int? KtpNo { get; set; }

        [StringLength(50)]
        public string OgrAdi { get; set; }

        [StringLength(50)]
        public string OgrSoyadi { get; set; }

        [StringLength(50)]
        public string KtpAdi { get; set; }

        public bool? KtpDurum { get; set; }

        [Required(ErrorMessage = "Tarih boþ geçilemez")]
        [Column(TypeName = "smalldatetime")]
        public DateTime? KitapOduncVerilmeTarihi { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? KitapIadeTarihi { get; set; }

        public int? OgrCezaPuani { get; set; }

        public virtual Kitap Kitap { get; set; }

        public virtual Ogrenci Ogrenci { get; set; }
    }
}
