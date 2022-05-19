using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementTool
{
    public class Bezoeker
    {
        public DateTime GeboorteDatum { get; set; }
        public int ID { get; set; }
        public static int NextID = 1;
        public Stoel Stoel { get; set; }
        public bool Volwassen { get; set; }

        public Bezoeker(DateTime geboortedatum)
        {
            this.GeboorteDatum = geboortedatum;
            this.ID = NextID;
            if (DateTime.Now.Year - geboortedatum.Year > 12)
            {
                this.Volwassen = true;
            }
            else
            {
                this.Volwassen = false;
            }
            NextID++;
        }
        
        
    }
}
