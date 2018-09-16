using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HeatType
    {
        public int HeatId { get; set; }
        public int CardId { get; set; }
        public string HeatingType { get; set; }
        public string MaterialCardId { get; set; }
    }
}
