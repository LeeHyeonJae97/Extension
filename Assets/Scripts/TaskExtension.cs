using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Extension
{
    public static class TaskExtension
    {
        public static IEnumerator ToCoroutine(this Task task)
        {
            yield return new WaitUntil(() => task.IsCompleted);
        }
    }
}
