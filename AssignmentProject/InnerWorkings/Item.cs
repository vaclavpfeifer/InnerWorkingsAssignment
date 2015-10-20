using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerWorkings
{
    public class Item
    {
        private readonly bool _isTaxFree;

        public Item(bool isTaxFree = false)
        {
            this._isTaxFree = isTaxFree;
        }

        public bool IsTaxFree
        {
            get
            {
                return this._isTaxFree;
            }
        }

        public string Name { get; set; }
        public float Price { get; set; }
    }

    public class LetterHead : Item
    {
        public LetterHead(bool isTaxFree = false) 
            : base(isTaxFree)
        {
        }
    }

    public class Envelope : Item
    {
        public Envelope(bool isTaxFree = false)
            : base(isTaxFree)
        {
        }
    }

    public class BusinessCard : Item
    {
        public BusinessCard(bool isTaxFree = false)
            : base(isTaxFree)
        {
        }
    }

}
