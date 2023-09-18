using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniro.BusinessLogic.Extansions
{
    public static class CollectionExtansions
    {
        public static bool Has<T>(this T[] array, T value) where T : class
        {
            foreach (var item in array)
            {
                if(item == value)
                    return true;
            }
            return false;
        }
        public static bool Has(this Guid[] array, Guid value)
        {
            foreach (var item in array)
            {
                if (item == value)
                    return true;
            }
            return false;
        }
    }
}
