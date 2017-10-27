using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Utility
    {
        public static string[] SplitInParts(this String str, Int32 partLength, bool b = false)
        {
            List<string> output = new List<string>();

            if (str == null)
                throw new ArgumentNullException("s");
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", "partLength");

            for (int i = 0; i < str.Length - partLength; i++)
            {
                output.Add(str.Substring(i, partLength));
            }

            if (b)
            {
                if (output.Count <= 2)
                {
                    return new string[] { };
                }

                output.RemoveAt(0);
                output.RemoveAt(output.Count - 1);
            }

            return output.ToArray();
        }

        public static void InvokeEx<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke
        {
            if (@this.InvokeRequired)
            {
                @this.Invoke(action, new object[] { @this });
            }
            else
            {
                action(@this);
            }
        }

        public static IEnumerable<T> GetEnumValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
