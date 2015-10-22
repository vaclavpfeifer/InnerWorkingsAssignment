using System.Collections.Generic;

namespace InnerWorkings.Business
{
    public interface IItemPriceCalculator
    {
        /// <summary>
        /// Calculate Single item price.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="margin"></param>
        /// <param name="tax"></param>
        /// <returns></returns>
        double CalculatePrice(Item item, double margin, double tax);

        /// <summary>
        /// Calculate final Sum.
        /// </summary>
        /// <param name="itemPrices"></param>
        /// <returns></returns>
        double CalculateFinalSum(IEnumerable<double> itemPrices);
    }
}