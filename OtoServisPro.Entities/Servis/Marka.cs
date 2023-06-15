using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisPro.Entities.Servis
{
    public class Marka
    {
        [Key]
        public int MarkaId { get; set; }
        public string MarkaAd { get; set; }
        public virtual Marka Markas { get; set; }

    }
}