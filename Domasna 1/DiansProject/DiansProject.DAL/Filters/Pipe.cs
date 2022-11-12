using DiansProject.DAL.Filters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.DAL.Filters
{
    public class Pipe<T>
    {
        private List<IFilter<T>> filters = new List<IFilter<T>>();

        public void addFilter(IFilter<T> filter)
        {
            filters.Add(filter);
        }

        public T runFilters(T input)
        {
            foreach (IFilter<T> filter in  filters)
            {
                input = filter.execute(input);

            }
            return input;
        }
    }
}
