using System.Collections.Generic;
using InnerWorkings.Business;

namespace InnerWorkings
{
    public class Job
    {
        public List<Item> Items { get; set; }

        public IMargin Margin { get; set; }

        public ITax Tax { get; set; }
    }

}
