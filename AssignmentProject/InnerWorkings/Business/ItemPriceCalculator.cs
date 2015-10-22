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

            return Math.Round(item.Price + taxFees + marginFees, 2, MidpointRounding.ToEven);
        }

        public double CalculateMarginOnItems(IEnumerable<Item> items, double margin)
        {
            // TODO: check for null and empty. check for divede by zero!
            return items.Sum(item => item.Price) * margin/100;
        }

        public double CalculateTaxOnItem(Item item, double tax)
        {
            if (item.IsTaxFree) return 0;

            return item.Price*tax/100;
        }

        public double CalculateFinalSum(IEnumerable<double> itemPrices)
        {
            var finalSum = itemPrices.Sum() + 0.0001;

            finalSum = Math.Floor(finalSum*100);

            if (((int)finalSum % 2) != 0)
            {
                finalSum++;
            }

            return finalSum / 100;
        }
    }
}
