using DiansProject.DAL.Filters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.DAL.Filters
{
    public class Pipe<I,O>
    {
        private List<IFilter<I,O>> filters = new List<IFilter<I,O>>();

        public void addFilter(IFilter<I,O> filter)
        {
            filters.Add(filter);
        }

        public O runFilters(I input)
        {
            O output = default(O);
            foreach (IFilter<I,O> filter in  filters)
            {
                output = filter.execute(input);

            }
            return output;
        }
    }
}
