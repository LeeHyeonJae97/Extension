using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extension
{
    public static class VectorExtension
    {
        #region Convert Vector2 <-> Vector3

        public static Vector3 ToVector3(this Vector2 vec)
        {
            return new Vector3(vec.x, 0, vec.y);
        }

        public static Vector2 ToVector2(this Vector3 vec)
        {
            return new Vector2(vec.x, vec.z);
        }

        #endregion

        #region Convert Vector -> VectorInt

        public static Vector2Int ToVector2Int(this Vector2 vec)
        {
            return new Vector2Int((int)vec.x, (int)vec.y);
        }

        public static Vector3Int ToVector3Int(this Vector3 vec)
        {
            return new Vector3Int((int)vec.x, (int)vec.y, (int)vec.z);
        }

        #endregion

        #region Round / Floor/ Ceil / RoundToInt / FloorToInt / CeilToInt

        public static Vector2 Round(this Vector2 vec)
        {
            return new Vector2(Mathf.Round(vec.x), Mathf.Round(vec.y));
        }

        public static Vector3 Round(this Vector3 vec)
        {
            return new Vector3(Mathf.Round(vec.x), Mathf.Round(vec.y), Mathf.Round(vec.z));
        }

        public static Vector2 Floor(this Vector2 vec)
        {
            return new Vector2(Mathf.Floor(vec.x), Mathf.Floor(vec.y));
        }

        public static Vector3 Floor(this Vector3 vec)
        {
            return new Vector3(Mathf.Floor(vec.x), Mathf.Floor(vec.y), Mathf.Floor(vec.z));
        }

        public static Vector2 Ceil(this Vector2 vec)
        {
            return new Vector2(Mathf.Ceil(vec.x), Mathf.Ceil(vec.y));
        }

        public static Vector3 Ceil(this Vector3 vec)
        {
            return new Vector3(Mathf.Ceil(vec.x), Mathf.Ceil(vec.y), Mathf.Ceil(vec.z));
        }

        public static Vector2 RoundToInt(this Vector2 vec)
        {
            return new Vector2(Mathf.RoundToInt(vec.x), Mathf.RoundToInt(vec.y));
        }

        public static Vector3 RoundToInt(this Vector3 vec)
        {
            return new Vector3(Mathf.RoundToInt(vec.x), Mathf.RoundToInt(vec.y), Mathf.RoundToInt(vec.z));
        }

        public static Vector2 FloorToInt(this Vector2 vec)
        {
            return new Vector2(Mathf.FloorToInt(vec.x), Mathf.FloorToInt(vec.y));
        }

        public static Vector3 FloorToInt(this Vector3 vec)
        {
            return new Vector3(Mathf.FloorToInt(vec.x), Mathf.FloorToInt(vec.y), Mathf.FloorToInt(vec.z));
        }

        public static Vector2 CeilToInt(this Vector2 vec)
        {
            return new Vector2(Mathf.CeilToInt(vec.x), Mathf.CeilToInt(vec.y));
        }

        public static Vector3 CeilToInt(this Vector3 vec)
        {
            return new Vector3(Mathf.CeilToInt(vec.x), Mathf.CeilToInt(vec.y), Mathf.CeilToInt(vec.z));
        }

        #endregion

        #region Random (vec.x ~ vec.y)

        public static float Random(this Vector2 vec)
        {
            return UnityEngine.Random.Range(vec.x, vec.y);
        }

        public static int RandomInt(this Vector2 vec)
        {
            return UnityEngine.Random.Range((int)vec.x, (int)vec.y);
        }

        public static int RandomInt(this Vector2Int vec)
        {
            return UnityEngine.Random.Range(vec.x, vec.y);
        }

        #endregion

        #region Rotate

        public static Vector2 Rotate(Vector2 org, Vector2 pivot, float angle)
        {
            float rad = angle * UnityEngine.Mathf.Deg2Rad;

            Vector2 moved = org - pivot;
            Vector2 rotated = new Vector2(UnityEngine.Mathf.Cos(rad) * moved.x - UnityEngine.Mathf.Sin(rad) * moved.y,
                UnityEngine.Mathf.Sin(rad) * moved.x + UnityEngine.Mathf.Cos(rad) * moved.y);

            return rotated + pivot;
        }

        public static Vector2[] Rotate(Vector2[] orgs, Vector2 pivot, float angle)
        {
            float rad = angle * UnityEngine.Mathf.Deg2Rad;

            Vector2[] rotateds = new Vector2[orgs.Length];
            for (int i = 0; i < rotateds.Length; i++)
            {
                Vector2 moved = orgs[i] - pivot;
                Vector2 rotated = new Vector2(UnityEngine.Mathf.Cos(rad) * moved.x - UnityEngine.Mathf.Sin(rad) * moved.y,
                    UnityEngine.Mathf.Sin(rad) * moved.x + UnityEngine.Mathf.Cos(rad) * moved.y).RoundToInt();

                rotateds[i] = rotated + pivot;
            }

            return rotateds;
        }

        #endregion

        #region Check included

        public static bool IncludedCube(this Vector3 vec3, Vector3 center, Vector3 size)
        {
            Vector3 leftBottomBack = center - size / 2;
            Vector3 rightTopForward = center + size / 2;

            if (leftBottomBack.x <= vec3.x && vec3.x <= rightTopForward.x
                && leftBottomBack.y <= vec3.y && vec3.y <= rightTopForward.y
                && leftBottomBack.z <= vec3.z && vec3.z <= rightTopForward.z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IncludedSphere(this Vector3 vec3, Vector3 center, float radius)
        {
            float sqrDst = (vec3 - center).sqrMagnitude;
            return sqrDst <= radius * radius;
        }

        #endregion

        #region Convert to eight directions

        public static Vector2 EightParts(this Vector2 vec)
        {
            Vector2 base1 = new Vector2(Mathf.Cos(Mathf.Deg2Rad * 22.5f), Mathf.Sin(Mathf.Deg2Rad * 22.5f));
            Vector2 base2 = new Vector2(Mathf.Cos(Mathf.Deg2Rad * 67.5f), Mathf.Sin(Mathf.Deg2Rad * 67.5f));

            if (-base2.x < vec.x && vec.x <= base2.x)
            {
                if (vec.y > 0) return Vector2.up;
                else return Vector2.down;
            }
            else if (base2.x < vec.x && vec.x <= base1.x)
            {
                if (vec.y > 0) return new Vector2(1, 1);
                else return new Vector2(1, -1);
            }
            else if (-base1.x < vec.x && vec.x <= -base2.x)
            {
                if (vec.y > 0) return new Vector2(-1, 1);
                else return new Vector2(-1, -1);
            }
            else if (vec.x <= -base1.x)
            {
                return Vector2.left;
            }
            else if (base1.x < vec.x)
            {
                return Vector2.right;
            }
            else
            {
                Debug.LogError("Error");
                return Vector2.zero;
            }
        }

        public static Vector3 EightParts(this Vector3 vec)
        {
            Vector3 base1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * 22.5f), 0, Mathf.Sin(Mathf.Deg2Rad * 22.5f));
            Vector3 base2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * 67.5f), 0, Mathf.Sin(Mathf.Deg2Rad * 67.5f));

            if (-base2.x < vec.x && vec.x <= base2.x)
            {
                if (vec.z > 0) return Vector3.forward;
                else return Vector3.back;
            }
            else if (base2.x < vec.x && vec.x <= base1.x)
            {
                if (vec.z > 0) return new Vector3(1, 0, 1);
                else return new Vector3(1, 0, -1);
            }
            else if (-base1.x < vec.x && vec.x <= -base2.x)
            {
                if (vec.z > 0) return new Vector3(-1, 0, 1);
                else return new Vector3(-1, 0, -1);
            }
            else if (vec.x <= -base1.x)
            {
                return Vector3.left;
            }
            else if (base1.x < vec.x)
            {
                return Vector3.right;
            }
            else
            {
                Debug.LogError("Error");
                return Vector3.zero;
            }
        }

        #endregion
    }
}
