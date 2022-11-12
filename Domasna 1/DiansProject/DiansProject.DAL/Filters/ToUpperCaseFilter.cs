using DiansProject.DAL.Filters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.DAL.Filters
{
    public class ToUpperCaseFilter : IFilter<string>
    {
        public string execute(string input)
        {
            return input.ToUpper();
        }
    }
}
