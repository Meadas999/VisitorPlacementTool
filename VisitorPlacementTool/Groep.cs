using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementTool
{
    public class Groep
    {
        public List<Bezoeker> Groepsleden { get; set; } = new();
        public bool ValidGroup { get; set; }

        public Groep(List<Bezoeker> groepsleden)
        {
            if (CheckIfGroupValid(groepsleden))
            {
                Groepsleden = groepsleden;
                ValidGroup = true;
            }
            else
            {
                throw new Exception("Groep is niet geldig");
            }
        }
            public bool CheckIfGroupValid(List<Bezoeker> groepsleden)
            {
                int volwassen = 0;
                int kind = 0;
                foreach (Bezoeker b in groepsleden)
                {
                    if (b.Volwassen)
                    {
                        volwassen++;
                    }
                    else
                    {
                        kind++;
                    }
                }
                if (kind > 0 && volwassen > 0 || kind == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
