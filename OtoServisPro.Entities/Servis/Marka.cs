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
        public bool Silindi { get; set; } //State/Status
        public virtual Marka Markas { get; set; }
        public List<Model> Model { get; set; }


    }
}