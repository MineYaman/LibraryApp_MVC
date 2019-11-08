namespace LibraryApp.Entities.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ogrenci")]
    public partial class Ogrenci
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ogrenci()
        {
            Emanet = new HashSet<Emanet>();
        }

        public int OgrenciID { get; set; }

        public int OgrenciNo { get; set; }

        [Required(ErrorMessage = "Öðrenci adý boþ geçilemez")]
        [StringLength(50)]
        public string OgrenciAdi { get; set; }

        [Required(ErrorMessage = "Öðrenci soyadý boþ geçilemez")]
        [StringLength(50)]
        public string OgrenciSoyadi { get; set; }

        public int? OgrenciCezaPuani { get; set; }

        public bool? Silindi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emanet> Emanet { get; set; }
    }
}
