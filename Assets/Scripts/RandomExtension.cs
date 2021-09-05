using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extension
{
    public static class RandomExtension
    {
        public static Vector2 onUnitRect
        {
            get
            {
                int random = UnityEngine.Random.Range(0, 4);
                switch (random)
                {
                    case 0:
                        return new Vector2(-1, UnityEngine.Random.value * 2 - 1);

                    case 1:
                        return new Vector2(1, UnityEngine.Random.value * 2 - 1);

                    case 2:
                        return new Vector2(UnityEngine.Random.value * 2 - 1, -1);

                    case 3:
                        return new Vector2(UnityEngine.Random.value * 2 - 1, 1);

                    default:
                        return Vector2.zero;
                }
            }
        }

        public static Vector3 onUnitRectXZ
        {
            get
            {
                int random = UnityEngine.Random.Range(0, 4);
                switch (random)
                {
                    case 0:
                        return new Vector3(-1, 0, UnityEngine.Random.value * 2 - 1);

                    case 1:
                        return new Vector3(1, 0, UnityEngine.Random.value * 2 - 1);

                    case 2:
                        return new Vector3(UnityEngine.Random.value * 2 - 1, 0, -1);

                    case 3:
                        return new Vector3(UnityEngine.Random.value * 2 - 1, 0, 1);

                    default:
                        return Vector3.zero;
                }
            }
        }

        public static Vector2 InsideUnitRect { get { return new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)); } }

        public static Vector3 InsideUnitRectXZ { get { return new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)); } }
    }
}
