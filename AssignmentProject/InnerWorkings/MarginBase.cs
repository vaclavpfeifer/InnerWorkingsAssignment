using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerWorkings
{
    public interface IMargin
    {
        float GetMargin();
    }

    public class MarginBase : IMargin
    {
        protected readonly float _baseMargin;

        public MarginBase(float baseMargin = 11)
        {
            this._baseMargin = baseMargin;
        }

        public virtual float GetMargin()
        {
            return _baseMargin;
        }
    }

    public class ExtraMargin : MarginBase
    {
        private readonly float _extraMargin;

        public ExtraMargin(float baseMargin = 11, float extraMargin = 5) 
            : base(baseMargin)
        {
            this._extraMargin = extraMargin;
        }

        public override float GetMargin()
        {
            return this._baseMargin + this._extraMargin;
        }
    }
}
