using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisPro.Entities.Web
{
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }
        [MaxLength(100)]
        public string Baslik { get; set; }
        [MaxLength(500)]
        public string Tanimlama { get; set; }
        [MaxLength(500)]
        public string ResimYol { get; set; } //Resim Yolu 
    }

}
