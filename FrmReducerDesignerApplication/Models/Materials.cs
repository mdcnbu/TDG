using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Materials
    {
        public string MaterialCardId { get; set; }
        public string MaterialType { get; set; }
        public string HeatingType { get; set; }
        public string HardnessValue { get; set; }
        public string ContactFatigueLimit { get; set; }
        public string BendingFatigueLimit { get; set; }
    }
}
