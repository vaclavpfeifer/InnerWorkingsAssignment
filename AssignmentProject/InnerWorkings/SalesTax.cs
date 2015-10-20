namespace InnerWorkings
{
    public class SalesTax : ITax
    {
        private readonly float _salesTax;

        public SalesTax(float tax)
        {
            this._salesTax = tax;
        }

        public float getTax()
        {
            return this._salesTax;
        }
    }
}