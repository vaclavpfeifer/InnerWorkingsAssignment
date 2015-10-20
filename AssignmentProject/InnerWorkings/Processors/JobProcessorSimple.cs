using System;

namespace InnerWorkings.Processors
{
    public class JobProcessorSimple : IJobProcessor
    {
        JobResultSet IJobProcessor.ProcessJob(Job job, IItemPriceCalculator itemPriceCalculator)
        {
            var jobResult = new JobResultSet();

            foreach(var item in job.Items)
            {
                float itemPrice = itemPriceCalculator.CalculatePrice(
                    item, job.Margin.GetMargin(), job.Tax.getTax());

                jobResult.Results.Add(new Tuple<string, float>(item.Name, itemPrice));
            }

            return jobResult;
        }
    }
}