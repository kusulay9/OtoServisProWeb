using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisPro.Entities.Servis
{
    public class Model
    {
        [Key]
        public int ModelId { get; set; }
        public string ModelAd { get; set; }
        public int MarkaId { get; set; }
        public bool Silindi { get; set; }

        public virtual Marka Marka { get; set; }
        public List<Isemri> Isemri { get; set; }

    }
}
