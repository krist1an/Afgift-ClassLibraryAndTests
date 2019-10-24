using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace RegistreringsAfgift
{
    public class Afgift
    {
        public const string PrisErUnderNulBesked = "Pris er under nul";

        // Har valgt at bruge typen decimal som er mere passende til valutaenheder

        public decimal BilAfgift(decimal pris)
        {
            
            // Undersøger pris, hvis den er < 0 bliver der smidt en exception

            if (pris < 0m)
            {
                throw new ArgumentOutOfRangeException(nameof(pris), pris, PrisErUnderNulBesked);
            }

            if (pris <= 200000m)
            {
                return pris * 0.85m;
            }

            return (pris * 1.5m) - 130000m;

        }


        // kalder BilAfgift med pris og returnere 20% af den

        public decimal ElBilAfgift(decimal pris)
        {
            return BilAfgift(pris) * 0.2m;
        }


    }
}
