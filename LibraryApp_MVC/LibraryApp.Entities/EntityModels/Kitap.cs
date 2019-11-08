namespace LibraryApp.Entities.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kitap")]
    public partial class Kitap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kitap()
        {
            Emanet = new HashSet<Emanet>();
        }

        public int KitapID { get; set; }

        public int KitapNo { get; set; }

        [Required(ErrorMessage = "Kitap adý boþ geçilemez")]
        [StringLength(50)]
        public string KitapAdi { get; set; }

        [Required(ErrorMessage = "Yazar adý boþ geçilemez")]
        [StringLength(50)]
        public string YazarAdi { get; set; }

        [Required(ErrorMessage = "Yazar soyadý boþ geçilemez")]
        [StringLength(50)]
        public string YazarSoyadi { get; set; }

        public int? Stok { get; set; }

        [Required(ErrorMessage = "Tarih boþ geçilemez")]
        [Column(TypeName = "smalldatetime")]
        public DateTime? KitapEklenmeTarihi { get; set; }

        public bool? Silindi { get; set; }

        public bool? KitapDurum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emanet> Emanet { get; set; }
    }
}
