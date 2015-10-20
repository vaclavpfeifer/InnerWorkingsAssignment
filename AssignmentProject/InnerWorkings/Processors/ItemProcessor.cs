namespace InnerWorkings.Processors
{
    public class ItemProcessor : IItemPriceCalculator
    {
        public float CalculatePrice(Item item, float margin, float tax)
        {
            // check for input argument?

            float taxFees = 0;
            float marginFees = 0;

            // calculate tax
            if(!item.IsTaxFree)
            {
                taxFees = item.Price * tax/100;
            }

            // calculate Margin
            marginFees = item.Price * margin/100;

            return item.Price + taxFees + marginFees;
        }
    }
}
