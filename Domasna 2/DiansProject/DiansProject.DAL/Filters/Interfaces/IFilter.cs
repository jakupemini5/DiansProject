using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.DAL.Filters.Interfaces
{
    public interface IFilter<I, O>
    {
        O execute(I input);
    }
}
