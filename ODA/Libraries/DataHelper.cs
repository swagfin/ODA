using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Libraries
{
    public static class DataHelper
    {
        public static string ConvertToString(IEnumerable<string> list, int take = 3)
        {
            string finalString = string.Empty;
            int start = 0;
            var newList = list.Take(take);
            foreach (var item in newList)
                if (start > 0)
                    finalString += "," + item;
                else
                    finalString += item;
            //Finally
            return finalString;
        }
    }

}
