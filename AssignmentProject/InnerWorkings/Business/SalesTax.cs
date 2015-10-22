namespace InnerWorkings.Business
{
    public class SalesTax : ITax
    {
        private readonly double _salesTax;

        public SalesTax(double tax)
        {
            this._salesTax = tax;
        }

        public double getTax()
        {
            return this._salesTax;
        }
    }
}