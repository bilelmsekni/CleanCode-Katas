using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamingAndCommenting.Solution
{
    public class CalculatorEnhanced
    {
        public double CalculateDiscount(int nbOfArticles, double articlePrice)
        {
            if (EligibleForDiscount(nbOfArticles))
            {
                return 0;
            }

            if (ShouldApplyThreeForPriceOfTwoDiscount(nbOfArticles))
            {
                return ApplyThreeForPriceOfTwoDiscount(nbOfArticles, articlePrice);
            }
            return ApplyFiftyOffDiscount(nbOfArticles, articlePrice);
        }

        private static double ApplyThreeForPriceOfTwoDiscount(int nbOfArticles, double articlePrice)
        {            
            return (nbOfArticles / 3) * articlePrice;
        }

        private static double ApplyFiftyOffDiscount(int nbOfArticles, double articlePrice)
        {
            return nbOfArticles * articlePrice / 2;
        }

        private bool ShouldApplyThreeForPriceOfTwoDiscount(int nbOfArticles)
        {
            return nbOfArticles < 11;
        }

        private bool EligibleForDiscount(int nbOfArticles)
        {
            return nbOfArticles < 3;
        }
    }
}
