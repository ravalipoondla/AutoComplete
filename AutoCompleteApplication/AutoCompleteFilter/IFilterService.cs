using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCompleteFilter
{
    public interface IFilterService
    {
        List<string> FilterWithLimit(string filterText,int limit);
        List<string> Filter(string filterText);
    }
}
