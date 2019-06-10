using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurtownie_ETL_Support
{
    public static class Utils
    {
        public static int IndexOf(this string[] array, string toLook)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(toLook)) return i;
            }

            return -1;
        }
    }
}
