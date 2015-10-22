using System;
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
                priceList.Add(item.Price);

                double taxOnItem = _itemPriceCalculator.CalculateTaxOnItem(item, job.Tax.getTax());
                priceList.Add(taxOnItem);

                double itemPriceRounded = Math.Round(item.Price + taxOnItem, 2, MidpointRounding.ToEven);

                this._outWriter.WriteLine($"{item.Name}: " + $"{itemPriceRounded:0.00}");
            }
            double marginPrice = _itemPriceCalculator.CalculateMarginOnItems(job.Items, job.Margin.GetMargin());
            priceList.Add(marginPrice);

            this._outWriter.WriteLine($"total: ${_itemPriceCalculator.CalculateFinalSum(priceList):0.00}");
        }
    }
}