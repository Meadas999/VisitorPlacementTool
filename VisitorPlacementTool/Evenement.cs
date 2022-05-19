using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementTool
{
    public class Evenement
    {
        public string? Naam { get; set; }
        public List<Vak> Vakken { get; set; } = new();

        public Evenement(string naam)
        {
            Naam = naam;
        }
        public void AddBezoekerToStoel(Bezoeker bezoeker)
        {
            int vak = CheckAvailableVak(1);
            if (vak != -1)
            {
                this.Vakken[vak].AddBezoekerEerstLegeStoel(bezoeker);
            }
        }

        public bool AddGroupToStoelen(List<Bezoeker> bezoekers)
        {
            bool bevestigd = false;
            try
            {
                foreach (Vak v in Vakken)
                {
                    if (CheckForKids(bezoekers))
                    {
                        if (!v.CheckContainsGroup() && v.CheckAvailableFrontRow(bezoekers.Count))
                        {
                            v.Groep = new Groep(bezoekers);
                            foreach (Bezoeker bezoeker in v.Groep.Groepsleden)
                            {
                                Stoel stoel = GetEmptyFirstRowStoel(v);
                                stoel.Bezoeker = bezoeker;
                                stoel.IsBezet = true;
                                v.BeschikbareStoelen--;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Er is geen plek meer voor deze groep", ex.Message);
            }
            finally
            {
                bevestigd = true;
            }
            return bevestigd;
        }
        public int CheckAvailableVak(int aantalBezoekers)
        {
            foreach (var vak in Vakken)
            {
                if (vak.PassenBezoekersErIn(aantalBezoekers))
                {
                    return Vakken.IndexOf(vak);
                }
            }
            return -1;
        }

        private bool CheckForKids(List<Bezoeker> bezoekers)
        {
            foreach (Bezoeker bezoeker in bezoekers)
            {
                if (!bezoeker.Volwassen)
                {
                    return true;
                }
            }
                return false;
        }

        private Stoel GetEmptyFirstRowStoel(Vak v)
        {
            foreach (Stoel stoel in v.Stoelen)
            {
                if (stoel.Rijnummer == 1 && !stoel.IsBezet)
                { 
                    return stoel;
                }
            }
            return null;
        }
        
        



    }
}
