using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisPro.Entities.Servis
{
    public class Musteri
    {
        [Key]
        public int MusteriId { get; set; }
        [MaxLength(100)]
        public string AdSoyad { get; set; } //Adı Soyadı / Unvanı
        [MaxLength(20)]
        public string Telefon { get; set; }
        [MaxLength(50)]
        public string Eposta { get; set; }
        [MaxLength(500)]
        public string Adres { get; set; }
        public List<Isemri> Isemris { get; set; }
    }
}
