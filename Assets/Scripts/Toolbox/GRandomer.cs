using UnityEngine;
using System.Collections.Generic;
namespace Toolbox
{
    public class GRandomer
    {
        //
        // Static Methods
        //
        public static T RandomArray<T>(T[] arrary)
        {
            if (arrary != null && arrary.Length > 0)
            {
                return arrary[GRandomer.RandomMinAndMax(0, arrary.Length)];
            }
            return default(T);
        }

        public static T RandomList<T>(List<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return default(T);
            }
            return list[GRandomer.RandomMinAndMax(0, list.Count)];
        }

        public static int RandomMinAndMax(int min, int max)
        {
            return Random.Range(min,max);
        }

        public static bool RandomPro10000(int pro)
        {
            return GRandomer.RandomMinAndMax(0, 10000) < pro;
        }

        public static void RandomArrayUnique<T>(T[] arrary)
        {
            if (arrary != null && arrary.Length > 0)
            {
                int temp = 0;
                int len=arrary.Length;
                for (int i = 0; i< len;i++ )
                {
                    temp = Random.Range(0,len);
                    T value = arrary[temp];
                    arrary[temp] = arrary[i];
                    arrary[i] = value;
                }
            }
        }
    }
}
