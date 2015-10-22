using System.Collections.Generic;
using InnerWorkings.Adapters;
using InnerWorkings.Business;

namespace InnerWorkings.Processors
{
    public class JobProcessorSimple : IJobProcessor
    {
        private readonly IItemPriceCalculator _itemPriceCalculator;
        private readonly IOutputWriter _outWriter;

        public JobProcessorSimple(IItemPriceCalculator itemPriceCalculator, IOutputWriter outWriter)
        {
            this._itemPriceCalculator = itemPriceCalculator;
            this._outWriter = outWriter;
        }

        void IJobProcessor.ProcessJob(Job job)
        {
            var priceList = new List<double>();
            foreach(var item in job.Items)
            {
                double itemPrice = _itemPriceCalculator.CalculatePrice(
                    item, job.Margin.GetMargin(), job.Tax.getTax());
                priceList.Add(itemPrice);

                this._outWriter.WriteLine($"{item.Name}: ${itemPrice}");
            }
            this._outWriter.WriteLine($"total: ${_itemPriceCalculator.CalculateFinalSum(priceList)}");
        }
    }
}