using DiansProject.DAL.Filters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.DAL.Filters
{
    public class ToIntParseFilter : IFilter<string,int>
    {
        public int execute(string input)
        {
            if (string.IsNullOrEmpty(input))
                return -1;
            return int.Parse(input);
        }
    }
}
