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
        /// Calculate Margin on items.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="margin"></param>
        /// <returns></returns>
        double CalculateMarginOnItems(IEnumerable<Item> items, double margin);

        /// <summary>
        /// Calculate tax on single item (if taxable)
        /// </summary>
        /// <param name="item"></param>
        /// <param name="tax"></param>
        /// <returns></returns>
        double CalculateTaxOnItem(Item item, double tax);

        /// <summary>
        /// Calculate final Sum.
        /// </summary>
        /// <param name="itemPrices"></param>
        /// <returns></returns>
        double CalculateFinalSum(IEnumerable<double> itemPrices);
    }
}