using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementTool
{
    public class Vak
    {
        public string Naam { get; set; }
        public int Rijen { get; set; }
        public int Kolommen { get; set; }
        public Groep Groep { get; set; }
        public List<Stoel> Stoelen { get; set; } = new();
        public int BeschikbareStoelen { get; set; }
        private Random rnd = new();

        public Vak(string naam)
        {
            Naam = naam;
            Rijen = rnd.Next(3, 11);
            Kolommen = rnd.Next(1, 4);
            BeschikbareStoelen = Rijen * Kolommen;
        }
        public Vak(string naam, int rij, int kolommen)
        {
            Naam = naam;
            Rijen = rij;
            Kolommen = kolommen;
            BeschikbareStoelen = Rijen * Kolommen;
            for (int i = 0; i < BeschikbareStoelen; i++)
            {
                AddStoel();
            }
        }

        public void AddStoel()
        {
            if (Stoelen.Count == 0)
            {
                //Make a method that can get the rijnummer and kolomnummer of a stoel from the last index of stoelen.
                Stoelen.Add(new Stoel(Naam, 1, 1));
            }
            else
            {
                int nieuwrijnummer = GetNextRijNummer();
                int nieuwkolomnummer = GetNextStoelNummer();
                Stoelen.Add(new Stoel(Naam, nieuwrijnummer, nieuwkolomnummer));
            }
        }
        public bool CheckContainsGroup()
        {
            if (Groep != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool PassenBezoekersErIn(int bezoekers)
        {
            if (BeschikbareStoelen - bezoekers >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddBezoekerEerstLegeStoel(Bezoeker bezoeker)
        {
            foreach (var stoel in this.Stoelen)
            {
                if (stoel.IsBezet == false)
                {
                    stoel.Bezoeker = bezoeker;
                    stoel.IsBezet = true;
                    this.BeschikbareStoelen--;
                    break;
                }
            }
        }
        public bool CheckAvailableFrontRow(int aantal)
        {
            int beschikbareStoelen = 0;
            foreach (Stoel stoel in Stoelen)
            {
                if (stoel.Rijnummer == 1 && !stoel.IsBezet)
                {
                    beschikbareStoelen++;
                }
            }
            return beschikbareStoelen >= aantal;
        }

        private int GetNextRijNummer()
        {
            int rijNummer = Stoelen.Last().Rijnummer;
            if (rijNummer > Rijen)
            {
                return 1;
            }
            else
            {
                return rijNummer + 1;
            }
        }

        private int GetNextStoelNummer()
        {
            int rijNummer = Stoelen.Last().Rijnummer;
            int stoelNummer = Stoelen.Last().Stoelnummer;
            if (rijNummer == Rijen)
            {
                return stoelNummer + 1;
            }
            else
            {
                return stoelNummer;
            }
        }





    }
}
