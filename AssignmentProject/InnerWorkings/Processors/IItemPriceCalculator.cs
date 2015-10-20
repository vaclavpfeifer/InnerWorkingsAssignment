namespace InnerWorkings.Processors
{
    public interface IItemPriceCalculator
    {
        float CalculatePrice(Item item, float margin, float tax);
    }
}