namespace InnerWorkings.Processors
{
    public interface IJobProcessor
    {
        JobResultSet ProcessJob(Job job, IItemPriceCalculator itemPriceCalculator);
    }
}