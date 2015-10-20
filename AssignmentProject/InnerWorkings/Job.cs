using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerWorkings
{
    public class Job
    {
        public List<Item> Items { get; set; }

        public IMargin Margin { get; set; }

        public ITax Tax { get; set; }
    }

    public interface IJobProcessor
    {
        JobResultSet ProcessJob(Job job, IItemPriceCalculator itemPriceCalculator);
    }

    public class JobProcessor : IJobProcessor
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

    public class JobResultSet
    {
        public JobResultSet()
        {
            this.Results = new List<Tuple<string, float>>();
        }

        public List<Tuple<string, float>> Results { get; private set; }
    }


    //public class JobProcessorParallel : IJobProcessor
    //{
    //    void IJobProcessor.CalculateJob(Job job)
    //    {
    //        Parallel.ForEach<Item>(job.Items, )
    //    }
    //}
}
