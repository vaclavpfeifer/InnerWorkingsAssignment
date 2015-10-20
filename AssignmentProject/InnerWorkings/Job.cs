using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerWorkings
{
    public class Job
    {
        public List<Item> Items { get; set; }

        public IMargin Margin { get; set; }

        public ITax Tax { get; set; }
    }

}
