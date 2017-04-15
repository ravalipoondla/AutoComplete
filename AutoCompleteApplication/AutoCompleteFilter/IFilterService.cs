using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCompleteFilter
{
    public interface IFilterService
    {
        List<string> Filter(string filterText,int limit);
    }
}
