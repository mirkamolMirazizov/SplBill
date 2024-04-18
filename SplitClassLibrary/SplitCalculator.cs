using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitClassLibrary
{
        public class SplitCalculator
    {
        public static decimal SplitAmount(decimal totalAmount, int numberOfPeople)
        {
            if (numberOfPeople <= 0)
                throw new ArgumentException("Number of people must be greater than zero.");

            return totalAmount / numberOfPeople;
        }

        public static Dictionary<string, decimal> CalculateTips(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            var result = new Dictionary<string, decimal>();
            foreach (var item in mealCosts)
            {
                var tip = item.Value * (decimal)(tipPercentage / 100);
                result.Add(item.Key, Math.Round(tip, 2));
            }
            return result;
        }


    }
}
