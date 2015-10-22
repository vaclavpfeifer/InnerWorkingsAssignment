namespace InnerWorkings.Business
{
    public class ExtraMargin : MarginBase
    {
        private readonly double _extraMargin;

        public ExtraMargin(double baseMargin = 11, double extraMargin = 5) 
            : base(baseMargin)
        {
            this._extraMargin = extraMargin;
        }

        public override double GetMargin()
        {
            return this._baseMargin + this._extraMargin;
        }
    }
}