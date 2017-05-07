using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCompleteFilter
{
    /// <summary>
    /// File Filter Service which checks for the specific test from the words in the file
    /// </summary>
    public class FileFilterService : IFilterService
    {
        public List<string> FilterWithLimit(string filterText,int limit)
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["WordsDictionaryFilePath"]);

            string lstStrings = System.IO.File.ReadAllText(filePath);
            string[] words = lstStrings.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var result = (from word in words.AsParallel()
                          where word.ToLower().StartsWith(filterText.ToLower())
                          select word).Distinct().Take(limit).ToList<string>();
            return result;
        }

        public List<string> Filter(string filterText)
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["WordsDictionaryFilePath"]);

            string lstStrings = System.IO.File.ReadAllText(filePath);
            string[] words = lstStrings.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var result = (from word in words.AsParallel()
                          where word.ToLower().StartsWith(filterText.ToLower())
                          select word).Distinct().ToList<string>();
            return result;
        }
    }
}
