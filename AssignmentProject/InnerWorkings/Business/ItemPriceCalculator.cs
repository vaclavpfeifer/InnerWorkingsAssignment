using System;
using System.Collections.Generic;
using System.Linq;

namespace InnerWorkings.Business
{
    public class ItemPriceCalculator : IItemPriceCalculator
    {
        public double CalculatePrice(Item item, double margin, double tax)
        {
            // check for input argument?

            double taxFees = 0;
            double marginFees = 0;

            // calculate tax
            if(!item.IsTaxFree)
            {
                taxFees = item.Price * tax/100;
            }

            // calculate MarginType
            marginFees = item.Price * margin/100;

            return item.Price + taxFees + marginFees;
        }

        public double CalculateFinalSum(IEnumerable<double> itemPrices)
        {
            var finalSum = itemPrices.Sum() + 0.0001;

            //finalSum = Math.Round(finalSum, 2, MidpointRounding.ToEven);

            finalSum = Math.Floor(finalSum*100);

            if (((int)finalSum % 2) != 0)
            {
                finalSum++;
            }

            return finalSum / 100;
        }
    }
}
