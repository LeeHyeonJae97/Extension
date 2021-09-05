using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extension
{
    public static class MathfExtension
    {
        public static int Range(int value, int min, int max)
        {
            if (value < min)
            {
                return value + max;
            }
            else if (value >= max)
            {
                return value - max;
            }
            else
            {
                return value;
            }
        }
    }
}
