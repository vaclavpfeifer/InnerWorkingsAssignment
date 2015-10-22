namespace InnerWorkings.Business
{
    public class MarginBase : IMargin
    {
        protected readonly double _baseMargin;

        public MarginBase(double baseMargin = 11)
        {
            this._baseMargin = baseMargin;
        }

        public virtual double GetMargin()
        {
            return _baseMargin;
        }
    }
}
