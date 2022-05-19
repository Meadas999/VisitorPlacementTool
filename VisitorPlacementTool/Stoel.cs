using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementTool
{
    public class Stoel
    {
        public string Stoelnaam { get;}
        public Bezoeker Bezoeker { get; set; }
        public int Rijnummer { get; set; }
        public int Stoelnummer { get; set; }
        public bool IsBezet { get; set; }

        public Stoel(string vaknaam, int rijnummer, int stoelnummer)
        {
            this.Stoelnaam = $"{vaknaam}{stoelnummer}-{rijnummer}";
            Rijnummer = rijnummer;
            Stoelnummer = stoelnummer;
            IsBezet = false;
        }
        
        
    }
}
