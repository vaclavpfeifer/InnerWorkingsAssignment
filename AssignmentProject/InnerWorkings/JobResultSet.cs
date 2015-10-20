using System;
using System.Collections.Generic;

namespace InnerWorkings
{
    public class JobResultSet
    {
        public JobResultSet()
        {
            this.Results = new List<Tuple<string, float>>();
        }

        public List<Tuple<string, float>> Results { get; private set; }
    }
}